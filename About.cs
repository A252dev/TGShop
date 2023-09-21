using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    internal class About
    {
        internal static async Task Description(ITelegramBotClient botClient, Update update)
        {
            var message = update.Message;

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

            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "About us...",
                replyMarkup: buttons);

            return;
        }
    }
}
