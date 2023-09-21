using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.Balance;

namespace TelegramBot
{
    internal class Account
    {        
        internal async static Task HandlerCallbackQueryAsync(ITelegramBotClient botClient, Update update)
        {
            if (update.CallbackQuery != null)
            {
                var message = update.Message;
                var action = update.CallbackQuery.Message;
                string accountData = Shop.Call(null, botClient, update);
                string productData = Shop.Call(null, botClient, update);
                string vpnData = Shop.Call(null, botClient, update);

                if (productData == "spotify")
                {
                    // buy spotify code
                    await botClient.SendTextMessageAsync(
                        chatId: action.Chat.Id,
                        text: "Spotify");
                    return;
                }
                if (productData == "youtube")
                {
                    // buy product code
                    await botClient.SendTextMessageAsync(
                        chatId: action.Chat.Id,
                        text: "YouTube");
                    return;
                }
                if (productData == "netflix")
                {
                    // buy product code
                    await botClient.SendTextMessageAsync(
                        chatId: action.Chat.Id,
                        text: "Netflix");
                    return;
                }
                if (productData == "discord")
                {
                    // buy product code
                    await botClient.SendTextMessageAsync(
                        chatId: action.Chat.Id,
                        text: "Discord");
                    return;
                }
                if (productData == "vpn")
                {
                    await Catalog.VPNList(botClient, update);
                    return;
                }

                if (vpnData == "vpn1")
                {
                    // buy product code
                    await botClient.SendTextMessageAsync(
                        chatId: action.Chat.Id,
                        text: "Vpn1");
                    return;
                }
                if (vpnData == "vpn2")
                {
                    // buy product code
                    await botClient.SendTextMessageAsync(
                        chatId: action.Chat.Id,
                        text: "Vpn2");
                    return;
                }
                if (vpnData == "vpn3")
                {
                    // buy product code
                    await botClient.SendTextMessageAsync(
                        chatId: action.Chat.Id,
                        text: "Vpn3");
                    return;
                }
                if (vpnData == "vpn4")
                {
                    // buy product code
                    await botClient.SendTextMessageAsync(
                        chatId: action.Chat.Id,
                        text: "Vpn4");
                    return;
                }
                if (vpnData == "vpn5")
                {
                    // buy product code
                    await botClient.SendTextMessageAsync(
                        chatId: action.Chat.Id,
                        text: "Vpn5");
                    return;
                }

                if (accountData == "addBalance")
                {
                    // fix it
                    await botClient.SendTextMessageAsync(
                        chatId: action.Chat.Id,
                        text: "Введите сумму для пополнения:");
                    return;
                }

                if (accountData == "back")
                {                    
                    await Catalog.ButtonList(botClient, update);
                    return;
                }

                else await botClient.AnswerCallbackQueryAsync(productData);
            }
            else return;
        }
        public async static Task Profile(ITelegramBotClient botClient, Update update)
        {
            var message = update.Message;
            var userId = update.Message.From.Id;

            BotDbContext db = new BotDbContext();

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

            int id;
            int balance;

            var userInfo = db.Model.FirstOrDefault(x => x.User == userId);
            if (userInfo != null)
            {
                id = userInfo.Id;
                balance = userInfo.Balance;

                await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "😜 Id: " + message.From.Id + "\n" +
                "😱 Имя пользователя: " + message.From.Username + "\n" +
                "🇷🇺 Баланс: " + balance,
                replyMarkup: buttons);

                return;
            }
            else
            {
                Console.WriteLine("User not found");
            }
            return;
        }
    }
}
