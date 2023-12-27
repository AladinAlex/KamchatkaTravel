using Telegram.Bot;
using Telegram.Bot.Types;

namespace KamchatkaTravel.TelegramApi
{
    public class Test
    {
        public async Task SendMessage()
        {
            var botClient = new TelegramBotClient("");
            long targetUserId = 1;
            ChatId chatId = new ChatId("AladinAlex");
            string messageText = "Hello";
            try
            {
                // Отправка сообщения
                await botClient.SendTextMessageAsync(chatId, messageText);
                //Console.WriteLine("Сообщение успешно отправлено!");
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}