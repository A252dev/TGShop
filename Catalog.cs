using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    internal class Catalog
    {
        public async static Task ButtonList(ITelegramBotClient botClient, Update update)
        {
            var action = update.CallbackQuery.Message;

            List<InlineKeyboardButton> one = new List<InlineKeyboardButton>
            {
                new InlineKeyboardButton("1")
                {
                    Text = "🎧 Spotify",
                    CallbackData = "spotify",
                },
            };
            List<InlineKeyboardButton> two = new List<InlineKeyboardButton>
            {
                new InlineKeyboardButton("2")
                {
                    Text = "🎬 YouTube",
                    CallbackData = "youtube",
                },
            };
            List<InlineKeyboardButton> three = new List<InlineKeyboardButton>
            {
                new InlineKeyboardButton("3")
                {
                    Text = "🍿 Netflix",
                    CallbackData = "netflix",
                },
            };
            List<InlineKeyboardButton> four = new List<InlineKeyboardButton>
            {
                new InlineKeyboardButton("4")
                {
                    Text = "🎮 Discord",
                    CallbackData = "discord",
                },
            };
            List<InlineKeyboardButton> five = new List<InlineKeyboardButton>
            {
                new InlineKeyboardButton("5")
                {
                    Text = "🔒 VPN",
                    CallbackData = "vpn",
                },
            };

            List<List<InlineKeyboardButton>> listButtons = new List<List<InlineKeyboardButton>>()
            {
                one, two, three, four, five
            };

            InlineKeyboardMarkup keyboardMarkup = new InlineKeyboardMarkup(listButtons);

            await botClient.SendTextMessageAsync(
                chatId: action.Chat.Id,
                text: "Список товаров:",
                replyMarkup: keyboardMarkup);
        }
        public async static Task List(ITelegramBotClient botClient, Update update)
        {
            var message = update.Message;

            List<InlineKeyboardButton> one = new List<InlineKeyboardButton>
            {
                new InlineKeyboardButton("1")
                {
                    Text = "🎧 Spotify",
                    CallbackData = "spotify",
                },
            };
            List<InlineKeyboardButton> two = new List<InlineKeyboardButton>
            {
                new InlineKeyboardButton("2")
                {
                    Text = "🎬 YouTube",
                    CallbackData = "youtube",
                },
            };
            List<InlineKeyboardButton> three = new List<InlineKeyboardButton>
            {
                new InlineKeyboardButton("3")
                {
                    Text = "🍿 Netflix",
                    CallbackData = "netflix",
                },
            };
            List<InlineKeyboardButton> four = new List<InlineKeyboardButton>
            {
                new InlineKeyboardButton("4")
                {
                    Text = "🎮 Discord",
                    CallbackData = "discord",
                },
            };
            List<InlineKeyboardButton> five = new List<InlineKeyboardButton>
            {
                new InlineKeyboardButton("5")
                {
                    Text = "🔒 VPN",
                    CallbackData = "vpn",
                },
            };

            List<List<InlineKeyboardButton>> listButtons = new List<List<InlineKeyboardButton>>()
            {
                one, two, three, four, five
            };

            InlineKeyboardMarkup keyboardMarkup = new InlineKeyboardMarkup(listButtons);

            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Список товаров:",
                replyMarkup: keyboardMarkup);
        }

        public async static Task VPNList(ITelegramBotClient botClient, Update update)
        {
            var action = update.CallbackQuery.Message;

            List<InlineKeyboardButton> one = new List<InlineKeyboardButton>
            {
                new InlineKeyboardButton("1")
                {
                    Text = "Vpn1",
                    CallbackData = "vpn1",
                },
            };
            List<InlineKeyboardButton> two = new List<InlineKeyboardButton>
            {
                new InlineKeyboardButton("2")
                {
                    Text = "Vpn2",
                    CallbackData = "vpn2",
                },
            };
            List<InlineKeyboardButton> three = new List<InlineKeyboardButton>
            {
                new InlineKeyboardButton("3")
                {
                    Text = "Vpn3",
                    CallbackData = "vpn3",
                },
            };
            List<InlineKeyboardButton> four = new List<InlineKeyboardButton>
            {
                new InlineKeyboardButton("4")
                {
                    Text = "Vpn4",
                    CallbackData = "vpn4",
                },
            };
            List<InlineKeyboardButton> five = new List<InlineKeyboardButton>
            {
                new InlineKeyboardButton("5")
                {
                    Text = "Vpn5",
                    CallbackData = "vpn5",
                },
            };

            List<InlineKeyboardButton> back = new List<InlineKeyboardButton>
            {
                new InlineKeyboardButton("back")
                {
                    Text = "Back",
                    CallbackData = "back",
                },
            };

            List<List<InlineKeyboardButton>> listButtons = new List<List<InlineKeyboardButton>>()
            {
                one, two, three, four, five, back
            };

            InlineKeyboardMarkup keyboardMarkup = new InlineKeyboardMarkup(listButtons);

            await botClient.SendTextMessageAsync(
                chatId: action.Chat.Id,
                text: "Выберите подходящий VPN:",
                replyMarkup: keyboardMarkup);

            return;
        }
    }
}
