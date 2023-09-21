using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.Balance;

namespace TelegramBot
{
    public class Shop
    {
        public static string? Call(string result, ITelegramBotClient botClient, Update update)
        {
            var action = update.CallbackQuery.Data;           
            
            CallbackQuery youtube = new CallbackQuery()
            {
                Data = "youtube",
            };
            CallbackQuery spotify = new CallbackQuery()
            {
                Data = "spotify",
            };
            CallbackQuery netflix = new CallbackQuery()
            {
                Data = "netflix",
            };
            CallbackQuery discord = new CallbackQuery()
            {
                Data = "discord",
            };
            CallbackQuery vpn = new CallbackQuery()
            {
                Data = "vpn",
            };

            CallbackQuery vpn1 = new CallbackQuery()
            {
                Data = "vpn1",
            };
            CallbackQuery vpn2 = new CallbackQuery()
            {
                Data = "vpn2",
            };
            CallbackQuery vpn3 = new CallbackQuery()
            {
                Data = "vpn3",
            };
            CallbackQuery vpn4 = new CallbackQuery()
            {
                Data = "vpn4",
            };
            CallbackQuery vpn5 = new CallbackQuery()
            {
                Data = "vpn5",
            };

            CallbackQuery addBalance = new CallbackQuery()
            {
                Data = "addBalance",
            };
            CallbackQuery back = new CallbackQuery()
            {
                Data = "back",
            };

            List<CallbackQuery> accountData = new List<CallbackQuery>()
            {
                addBalance, back
            };
            List<CallbackQuery> product = new List<CallbackQuery>()
            {
                youtube, spotify, netflix, discord, vpn
            };
            List<CallbackQuery> vpnList = new List<CallbackQuery>()
            {
                vpn1, vpn2, vpn3, vpn4, vpn5
            };

            foreach (CallbackQuery call in accountData)
            {
                if (call.Data == action)
                {
                    result = call.Data;
                }
            }
            foreach (CallbackQuery call in product)
            {
                if (call.Data == action)
                {
                    result = call.Data;
                }
            }
            foreach (CallbackQuery call in vpnList)
            {
                if (call.Data == action)
                {
                    result = call.Data;
                }
            }

            return result;
        }
        public static bool AllLinesSold(string[] lines, bool allIsSold)
        {
            allIsSold = lines.All(line => line.Contains("=Sold"));
            if (allIsSold)
            {
                allIsSold = true;
            }
            else allIsSold = false;

            return allIsSold;
        }
        public async static Task Buy(ITelegramBotClient botClient, Update update)
        {           
            var message = update.Message;
            //var action = update.CallbackQuery.Message;
            var path = @"C:\Users\Agent\Desktop\text.txt";            

            if (System.IO.File.Exists(path))
            {
                Console.Clear();
                Console.WriteLine("Start buying...\n");

                int cost = 10;
                bool success = false;
                string[] lines = System.IO.File.ReadAllLines(path);
                bool allLinesIsSold = true;
                              
                var random = new System.Random();
                int randomNumber = random.Next(0, lines.Length);

                while (success == false)
                {
                    randomNumber = random.Next(0, lines.Length);
                    var getSoldLines = AllLinesSold(lines, allLinesIsSold);
                    if (getSoldLines)
                    {
                        await botClient.SendTextMessageAsync(
                            message.Chat.Id,
                            text: "Товар закончился! Можете подождать пополнения или взять что-нибудь другое.");
                        break;
                    }
                    if (lines[randomNumber].Contains("=Sold")) continue;

                    using (BotDbContext context = new BotDbContext())
                    {                        
                        var fullBalance = 0;
                        var userId = message.Chat.Id;
                        var user = context.Model.FirstOrDefault(x => x.User == userId);
                        if (user != null)
                        {
                            fullBalance = user.Balance;
                        }
                        bool haveMoney = context.Model.Any(x => x.Balance >= cost);                        
                        fullBalance = fullBalance - cost;
                        if (haveMoney)
                        {
                            user.Balance = fullBalance;
                            context.SaveChanges();

                            await botClient.SendTextMessageAsync(
                                message.Chat.Id,
                                text: "Успешная покупка!\n\n" +
                                "Ваш товар: " + lines[randomNumber] + "\n" +
                                "Спасибо за покупку ;)");

                            lines[randomNumber] = lines[randomNumber] + "=Sold";
                            System.IO.File.WriteAllLines(path, lines);
                            Console.WriteLine("Done!");
                            return;
                        }
                        else
                        {
                            List<InlineKeyboardButton> addBalanceButton = new List<InlineKeyboardButton>()
                            {
                                new InlineKeyboardButton("1")
                                {
                                    Text = "Пополнить баланс",
                                    CallbackData = "addBalance",
                                },
                            };

                            InlineKeyboardMarkup addBalanceMarkup = new InlineKeyboardMarkup(addBalanceButton);

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "У вас недостаточно средств! Пополнить баланс?",
                                replyMarkup: addBalanceMarkup);
                        }
                    }
                    success = true;
                }                
            }
            else
            {
                Console.WriteLine("File not found!");
                return;
            }
            return;
        }
    }
}
