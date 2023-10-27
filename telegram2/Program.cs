using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace ConsoleTelegramBot
{
    class Program
    {
        private static TelegramBotClient _botClient;

        static async Task Main(string[] args)
        {
            _botClient = new TelegramBotClient("6735666296:AAFuVhAsc8lJbtKmIoEDfF5ZctLyl3Aefg8");

            Console.WriteLine("Bot ishga tushirildi. Chiqib ketish uchun istalgan tugmani bosing.");

            int offset = 0;

            while (!Console.KeyAvailable)
            {
                var updates = await _botClient.GetUpdatesAsync(offset);

                foreach (var update in updates)
                {
                    if (update.Type == UpdateType.Message && update.Message.Text != null && update.Message.Text.ToLower().Contains("dotnet"))
                    {
                        string message = $"Ha, dotnet haqida gaplashamiz!";
                        await _botClient.SendTextMessageAsync(update.Message.Chat.Id, message, replyToMessageId: update.Message.MessageId);
                        offset = update.Id + 1;
                    }
                    else if(update.Type == UpdateType.Message && update.Message.Text.ToLower()=="/start")
                    {
                        string message = "Assalomu alekum sizga qanday yordam bera olamiz?";
                        await _botClient.SendTextMessageAsync(update.Message.Chat.Id, message);
                        offset = update.Id + 1;
                    }
                    
                }
                Thread.Sleep(1000);
            }
        }
    }
}
