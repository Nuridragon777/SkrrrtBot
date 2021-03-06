﻿using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using KnightBot.Config;
using KnightBot.util;
using KnightBot.Modules.NewServer;
using KnightBot.Modules.Economy;

namespace KnightBot.Modules.Public
{
    [Group("help")]
    [Alias("hlp", "Help")]
    public class HelpModule : ModuleBase
    {

        Errors errors = new Errors();


        private int total;

        private BankConfig save = new BankConfig();


        [Command]
        private async Task Help()
        {
            var embed = new EmbedBuilder() { Color = Colors.helpCol };
            var footer = new EmbedFooterBuilder() { Text = "Requested by " + Context.User.Username };
            var generalField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "help general", Value = "Displays General Commands." };
            var musicField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "help music", Value = "Displays Music Commands." };
            var bankField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "help bank", Value = "Displays Bank Commands." };
            var aucField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "help auction", Value = "Displays Auction Commands." };
            var nsfwField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "help nsfw", Value = "Displays NSFW Commands." };
            var adminField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "help admin", Value = "Displays Admin Commands." };

            embed.Title = $"╋━━━━━━◥◣ KnightBot Help ◢◤━━━━━━╋";
            embed.Description = "More Commands Will Be Added Soon!";
            embed.WithFooter(footer);
            embed.WithCurrentTimestamp();
            embed.AddField(generalField);
            embed.AddField(musicField);
            embed.AddField(bankField);
            embed.AddField(aucField);
            embed.AddField(nsfwField);
            embed.AddField(adminField);

            await Context.Channel.SendMessageAsync("", false, embed);


            var result = BankConfig.Load("bank/" + Context.User.Id.ToString() + ".json").currentMoney;

            int bal = 10;

            total = result + bal;

            save.userID = BankConfig.Load("bank/" + Context.User.Id.ToString() + ".json").userID;
            save.currentMoney = total;
            save.currentPoints = BankConfig.Load("bank/" + Context.User.Id.ToString() + ".json").currentPoints;
            save.Save("bank/" + Context.User.Id.ToString() + ".json");


        }

        [Command("general")]
        [Alias("gen", "General")]
        private async Task GenHelp()
        {
            var embed = new EmbedBuilder() { Color = Colors.helpCol };
            var footer = new EmbedFooterBuilder() { Text = "Requested by " + Context.User.Username };
            var helpField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "help", Value = "Displays The Commands The KnightBot Can Do." };
            var dogField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "doggo", Value = "Displays A Random Dog Image!" };
            var catField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "cat", Value = "Displays A Random Cat Image!" };

            embed.Title = $"╋━━━━━━◥◣ KnightBot General Help ◢◤━━━━━━╋";
            embed.Description = "More Commands Will Be Added Soon!";
            embed.WithFooter(footer);
            embed.WithCurrentTimestamp();
            embed.AddField(helpField);
            embed.AddField(dogField);
            embed.AddField(catField);

            await Context.Channel.SendMessageAsync("", false, embed);

            var result = BankConfig.Load("bank/" + Context.User.Id.ToString() + ".json").currentMoney;

            int bal = 10;

            total = result + bal;

            save.userID = BankConfig.Load("bank/" + Context.User.Id.ToString() + ".json").userID;
            save.currentMoney = total;
            save.currentPoints = BankConfig.Load("bank/" + Context.User.Id.ToString() + ".json").currentPoints;
            save.Save("bank/" + Context.User.Id.ToString() + ".json");

        }

        [Command("music")]
        [Alias("MUSIC", "Music")]
        private async Task MusicHelp()
        {
            var embed = new EmbedBuilder() { Color = Colors.musicCol };
            var footer = new EmbedFooterBuilder() { Text = "Requested by " + Context.User.Username };
            var playField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "play <link directly to song on youtube>", Value = "Plays The Song In Your Voice Channel!" };
            var stopField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "stop", Value = "Stops The Songs That Is Currently Playing!" };

            embed.Title = $"╋━━━━━━◥◣ KnightBot Music Help ◢◤━━━━━━╋";
            embed.Description = "Here Are All Of The Music Commands!";
            embed.WithFooter(footer);
            embed.WithCurrentTimestamp();
            embed.AddField(playField);
            embed.AddField(stopField);

            await Context.Channel.SendMessageAsync("", false, embed);


            var result = BankConfig.Load("bank/" + Context.User.Id.ToString() + ".json").currentMoney;

            int bal = 10;

            total = result + bal;

            save.userID = BankConfig.Load("bank/" + Context.User.Id.ToString() + ".json").userID;
            save.currentMoney = total;
            save.currentPoints = BankConfig.Load("bank/" + Context.User.Id.ToString() + ".json").currentPoints;
            save.Save("bank/" + Context.User.Id.ToString() + ".json");

        }

        [Command("bank")]
        [Alias("Bank", "bnk")]
        private async Task BankHelp()
        {
            var embed = new EmbedBuilder() { Color = Colors.moneyCol };
            var footer = new EmbedFooterBuilder() { Text = "Requested by " + Context.User.Username };
            var bankField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "bank open", Value = "Opens A Bank Account In Your Name!" };
            var moneyField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "bank balance", Value = "Displays Your Current Balance!" };
            var transferField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "bank transfer <user> <amount>", Value = "Transfer Money To Another Player." };

            embed.Title = $"╋━━━━━━◥◣ KnightBot Bank Help ◢◤━━━━━━╋";
            embed.Description = "Here Are All Of The Bank Commands!";
            embed.WithFooter(footer);
            embed.WithCurrentTimestamp();
            embed.AddField(bankField);
            embed.AddField(moneyField);
            embed.AddField(transferField);

            await Context.Channel.SendMessageAsync("", false, embed);


            var result = BankConfig.Load("bank/" + Context.User.Id.ToString() + ".json").currentMoney;

            int bal = 10;

            total = result + bal;

            save.userID = BankConfig.Load("bank/" + Context.User.Id.ToString() + ".json").userID;
            save.currentMoney = total;
            save.currentPoints = BankConfig.Load("bank/" + Context.User.Id.ToString() + ".json").currentPoints;
            save.Save("bank/" + Context.User.Id.ToString() + ".json");

        }

        [Command("auction")]
        [Alias("auc", "Auction")]
        private async Task AucHelp()
        {
            var embed = new EmbedBuilder() { Color = Colors.moneyCol };
            var footer = new EmbedFooterBuilder() { Text = "Requested by " + Context.User.Username };
            var auctionField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "auction <amount> <quantity> <item>", Value = "Starts A New Auction." };
            var auctionEndField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "auctionend", Value = "Ends The Current Auction." };
            var auctionCheckField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "auctioncheck", Value = "Checks If There Is A Current Auction." };
            var bidField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "bid <amount>", Value = "Bid On The Current Auction." };

            embed.Title = $"╋━━━━━━◥◣ KnightBot Auction Help ◢◤━━━━━━╋";
            embed.Description = "Here Are All Of The Bank Commands!";
            embed.WithFooter(footer);
            embed.WithCurrentTimestamp();
            embed.AddField(auctionField);
            embed.AddField(auctionEndField);
            embed.AddField(auctionCheckField);
            embed.AddField(bidField);

            await Context.Channel.SendMessageAsync("", false, embed);

            var result = BankConfig.Load("bank/" + Context.User.Id.ToString() + ".json").currentMoney;

            int bal = 10;

            total = result + bal;

            save.userID = BankConfig.Load("bank/" + Context.User.Id.ToString() + ".json").userID;
            save.currentMoney = total;
            save.currentPoints = BankConfig.Load("bank/" + Context.User.Id.ToString() + ".json").currentPoints;
            save.Save("bank/" + Context.User.Id.ToString() + ".json");

        }

        [Command("admin")]
        [Alias("Admin", "administrator")]
        private async Task AdminHelp()
        {
            var embed = new EmbedBuilder() { Color = Colors.adminCol };
            var footer = new EmbedFooterBuilder() { Text = "Requested by " + Context.User.Username };
            var kickField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "kick <user> <reason>", Value = "Kicks The Specified User." };
            var banField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "ban <user> <reason>", Value = "Bans The Specified User." };
            var clearField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "clear <Amount>", Value = "Clears 1-100 Messages." };

            embed.Title = $"╋━━━━━━◥◣ KnightBot Admin Help ◢◤━━━━━━╋";
            embed.Description = "Here Are All Of The Bank Commands!";
            embed.WithFooter(footer);
            embed.WithCurrentTimestamp();
            embed.AddField(kickField);
            embed.AddField(banField);
            embed.AddField(clearField);

            await Context.Channel.SendMessageAsync("", false, embed);

            var result = BankConfig.Load("bank/" + Context.User.Id.ToString() + ".json").currentMoney;

            int bal = 10;

            total = result + bal;

            save.userID = BankConfig.Load("bank/" + Context.User.Id.ToString() + ".json").userID;
            save.currentMoney = total;
            save.currentPoints = BankConfig.Load("bank/" + Context.User.Id.ToString() + ".json").currentPoints;
            save.Save("bank/" + Context.User.Id.ToString() + ".json");

        }

        [Command("nsfw")]
        [Alias("Nsfw", "NSFW")]
        private async Task NsfwHelp()
        {
            var embed = new EmbedBuilder() { Color = Colors.nsfwCol };
            var footer = new EmbedFooterBuilder() { Text = "Requested by " + Context.User.Username };
            var joinField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "nsfw join", Value = "Adds The NSFW Role To You." };
            var leaveField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "nsfw leave", Value = "Removes The NSFW Role From You." };
            var buttField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "nsfw butt", Value = "Perfect For Any Butt Lovers." };
            var boobsField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "nsfw boobs", Value = "Perfect For Any Boobs Lovers." };
            var gifField = new EmbedFieldBuilder() { Name = ServerConfig.Load("servers/" + Context.Guild.Id.ToString() + ".json").serverPrefix + "nsfw gif", Value = "Sends A Random Gif ;)" };

            embed.Title = $"╋━━━━━━◥◣ KnightBot NSFW Help ◢◤━━━━━━╋";
            embed.Description = "Here Are All Of The NSFW Commands!";
            embed.WithFooter(footer);
            embed.WithCurrentTimestamp();
            embed.AddField(joinField);
            embed.AddField(leaveField);
            embed.AddField(buttField);
            embed.AddField(boobsField);
            embed.AddField(gifField);
            await Context.Channel.SendMessageAsync("", false, embed);

            var result = BankConfig.Load("bank/" + Context.User.Id.ToString() + ".json").currentMoney;

            int bal = 10;

            total = result + bal;

            save.userID = BankConfig.Load("bank/" + Context.User.Id.ToString() + ".json").userID;
            save.currentMoney = total;
            save.currentPoints = BankConfig.Load("bank/" + Context.User.Id.ToString() + ".json").currentPoints;
            save.Save("bank/" + Context.User.Id.ToString() + ".json");

        }

    }
}
