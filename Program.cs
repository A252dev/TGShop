using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Reflection;
using System.Security.Cryptography;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.Balance;

namespace TelegramBot
{
    class Program
    {
        public static void Main()
        {
            var client = new TelegramBotClient("{token}");

            client.StartReceiving(Update, Error);
            Console.WriteLine("Bot is started...");
            Console.ReadLine();
        }

        public async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken cancellation)
        {
            var message = update.Message;

            //using var _db = new BotDbContext();                       
            await Account.HandlerCallbackQueryAsync(botClient, update);
            if (message != null)
            {
                if (message.Text.ToLower().Contains("/start"))
                {

                    List<KeyboardButton> firstLineButtons = new List<KeyboardButton>()
                    {
                        new KeyboardButton("🛒 Товары"),
                        new KeyboardButton("🙂 Баланс"),
                        new KeyboardButton("❓ О нас"),
                    };

                    var buttons = new ReplyKeyboardMarkup(firstLineButtons)
                    {
                        ResizeKeyboard = true,
                    };

                    using (BotDbContext db = new BotDbContext())
                    {
                        var userInfo = new Model
                        {
                            User = (int)message.Chat.Id,
                            Balance = 0,
                        };

                        var userId = message.Chat.Id;
                        bool haveData = db.Model.Any(x => x.User == userId);

                        if (haveData == true)
                        {
                            db.Model.Update(userInfo);
                        }
                        else
                        {
                            db.Add(userInfo);
                            db.SaveChanges();
                        }
                    }

                    string path = @"C:\Users\Agent\Downloads\Shop\logo.jpg";
                    var photo = new InputOnlineFile(new FileStream(path, FileMode.Open));

                    await botClient.SendPhotoAsync(
                        chatId: message.Chat.Id,
                        photo: photo,
                        caption: "👋 Привет, я бот магазина *AgentShop*",
                        replyMarkup: buttons);
                    Console.WriteLine(message.Chat.FirstName + " => writed => " + message.Text);
                    return;
                }

                if (message.Text.Contains("\U0001f6d2 Товары"))
                {
                    Catalog.List(botClient, update);
                    Console.WriteLine(message.Chat.FirstName + " => writed => " + message.Text);
                    return;
                }

                if (message.Text.Contains("🙂 Баланс"))
                {
                    Account.Profile(botClient, update);
                    Console.WriteLine(message.Chat.FirstName + " => writed => " + message.Text);
                    return;
                }

                if (message.Text.Contains("❓ О нас"))
                {
                    About.Description(botClient, update);
                    Console.WriteLine(message.Chat.FirstName + " => writed => " + message.Text);
                }

                if (int.TryParse(message.Text, out int summa))
                {

                    //add balance logic
                    await botClient.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: $"You are writted {summa}");
                    return;
                }

                if (message.Text.ToLower().Contains("/buy"))
                {
                    Shop.Buy(botClient, update);
                    Console.WriteLine(message.Chat.FirstName + " => writed => " + message.Text);
                    return;
                }

                return;
            }
            return;
        }

        private static Task Error(ITelegramBotClient botClient, Exception ex, CancellationToken cancel)
        {
            Console.WriteLine("Error");
            throw new NotImplementedException();
        }
    }
}