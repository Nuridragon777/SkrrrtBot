﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using KnightBot.Config;
using System.Linq;
using KnightBot.util;
using KnightBot.Nsfw;
using KnightBot.Modules.NewServer;

namespace KnightBot.Modules.Nsfw
{
    public class NsfwModule : ModuleBase<SocketCommandContext>
    {
        Errors errors = new Errors();
        string placeholderGif = "https://gfycat.com/DecimalCheeryCornsnake";

        [Command("nsfw")]
        public async Task Nsfw(string type = null)
        {
            var chan = Context.Channel;
            var userName = Context.User as SocketGuildUser;

            if (type.Equals("join"))
            {
                var nsfwRole = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").NSFWRole);
                if (nsfwRole != null)
                {
                    if (!userName.Roles.Contains(nsfwRole))
                    {
                        await (Context.User as IGuildUser).AddRoleAsync(nsfwRole);
                        var embed = new EmbedBuilder() { Color = Colors.nsfwCol };
                        embed.Title = ("NSFW Join");
                        embed.Description = ("You have been given the nsfw role!");
                        await Context.Channel.SendMessageAsync("", false, embed);
                    }
                    else if (userName.Roles.Contains(nsfwRole)) await errors.sendError(chan, "You already have the nsfw role.", Colors.nsfwCol);
                }
                else await errors.sendError(chan, "The nsfw role does not exist.", Colors.nsfwCol);
            }
            if (type.Equals("leave"))
            {
                var nsfwRole = Context.Guild.Roles.FirstOrDefault(x => x.Name.ToString() == BotConfig.Load().NSFWRole);
                if (nsfwRole != null)
                {
                    if (userName.Roles.Contains(nsfwRole))
                    {
                        await (Context.User as IGuildUser).RemoveRoleAsync(nsfwRole);
                        var embed = new EmbedBuilder() { Color = Colors.nsfwCol };
                        embed.Title = ("NSFW Leave");
                        embed.Description = ("You have been removed from the nsfw role!");
                        await Context.Channel.SendMessageAsync("", false, embed);
                    }
                    else if (!userName.Roles.Contains(nsfwRole)) await errors.sendError(chan, "You do not have the nsfw role already.", Colors.nsfwCol);
                }
                else await errors.sendError(chan, "The nsfw role does not exist.", Colors.nsfwCol);
            }
            else if (chan.IsNsfw)
            {
                if (type == null) await errors.sendError(chan, "The parameter entered is not used. Try the help command to see all possible parameters.", Colors.nsfwCol);

                type = type.ToLower();

                if (type.Equals("butt"))
                {
                    //Display a random butt pic
                    await Context.Channel.SendMessageAsync("**No butt pics can be found :(** \n Enjoy this to pass time: " + placeholderGif);
                }
                else if (type.Equals("boobs"))
                {
                    //Display a random boobs pic
                    await Context.Channel.SendMessageAsync("**No boob pics can be found :(** \n Enjoy this to pass time: " + placeholderGif);
                }
                else if (type.Equals("create"))
                {
                    if (userName.Id == 211938243535568896)
                    {
                        await Context.Guild.CreateRoleAsync(BotConfig.Load().NSFWRole.ToString(), null, Color.Red, false, null);
                        var embed = new EmbedBuilder() { Color = Colors.nsfwCol };
                        embed.Title = ("NSFW Create");
                        embed.Description = ("You have created the nsfw role!");
                        await Context.Channel.SendMessageAsync("", false, embed);
                    }
                    else await errors.sendError(chan, "Only Blurr can do this command.", Colors.nsfwCol);
                }
                else
                {
                    await errors.sendError(chan, "The parameter entered is not used. Try the help command to see all possible parameters.", Colors.nsfwCol);
                    await Context.Message.DeleteAsync();
                }
            }
        }

        [Command("nsfw add")]
        [RequireNsfw]
        public async Task NsfwAdd(string name = null, string directory = null, string type = null)
        {
            var chan = Context.Channel;

            if (name != null)
            {
                if (directory != null)
                {
                    if (type != null)
                    {
                        if (type.ToLower().Equals("boobs"))
                        {
                            NsfwImage image = new NsfwImage(name, directory, ImageType.boobs);
                            await errors.sendError(chan, "Created the image object, but Knight needs to do the db part! (boobs)", Colors.nsfwCol);
                        }
                        else if (type.ToLower().Equals("butt"))
                        {
                            NsfwImage image = new NsfwImage(name, directory, ImageType.butt);
                            await errors.sendError(chan, "Created the image object, but Knight needs to do the db part! (butt)", Colors.nsfwCol);
                        }
                        else if (type.ToLower().Equals("gif"))
                        {
                            NsfwImage image = new NsfwImage(name, directory, ImageType.gif);
                            await errors.sendError(chan, "Created the image object, but Knight needs to do the db part! (gif)", Colors.nsfwCol);
                        }
                        else await errors.sendError(chan, "Types of images are as follows: boobs | butt | gif", Colors.nsfwCol);
                    }
                    else await errors.sendError(chan, "You must enter the type of image!\n" + BotConfig.Load().Prefix + "nsfw add <name> <link> <type>", Colors.nsfwCol);
                }
                else await errors.sendError(chan, "You must enter a link to the image!\n" + BotConfig.Load().Prefix + "nsfw add <name> <link> <type>", Colors.nsfwCol);
            }
            else await errors.sendError(chan, "You must enter a name of the image!\n" + BotConfig.Load().Prefix + "nsfw add <name> <link> <type>", Colors.nsfwCol);
        }
    }
}
