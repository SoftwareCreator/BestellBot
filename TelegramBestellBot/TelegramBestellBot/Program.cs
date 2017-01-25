using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using System.Windows.Forms;

namespace TelegramBestellBot
{
    class Program
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient("207190117:AAHNwEBiRQAx-T3nxSVR1uSiP5ZyN8dH-uo");
        static void Main(string[] args)
        {
            var me = Bot.GetMeAsync().Result;
            Bot.OnMessage += OnMessageReceived;
            Bot.OnReceiveError += OnErrorReceived;
            Bot.StartReceiving();
            bool stop = false;
            while (!stop)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.S && key.Modifiers == ConsoleModifiers.Alt)
                {
                    var result = MessageBox.Show("Wollen Sie die API wirklich beenden", "Beenden", MessageBoxButtons.YesNo);
                    Console.WriteLine(result);
                    //stop = true;
                }
            }
            Bot.StopReceiving();
            
        }

        private static void OnErrorReceived(object sender, Telegram.Bot.Args.ReceiveErrorEventArgs e)
        {
            Console.WriteLine(e.ApiRequestException);
        }

        private static void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            switch (e.Message.Type)
            {
                case Telegram.Bot.Types.Enums.MessageType.UnknownMessage:
                    break;
                case Telegram.Bot.Types.Enums.MessageType.TextMessage:
                    Messages.HandleTextMessages.Answer(bot, e.Message);
                    break;
                case Telegram.Bot.Types.Enums.MessageType.PhotoMessage:
                    break;
                case Telegram.Bot.Types.Enums.MessageType.AudioMessage:
                    break;
                case Telegram.Bot.Types.Enums.MessageType.VideoMessage:
                    break;
                case Telegram.Bot.Types.Enums.MessageType.VoiceMessage:
                    break;
                case Telegram.Bot.Types.Enums.MessageType.DocumentMessage:
                    break;
                case Telegram.Bot.Types.Enums.MessageType.StickerMessage:
                    break;
                case Telegram.Bot.Types.Enums.MessageType.LocationMessage:
                    break;
                case Telegram.Bot.Types.Enums.MessageType.ContactMessage:
                    break;
                case Telegram.Bot.Types.Enums.MessageType.ServiceMessage:
                    break;
                case Telegram.Bot.Types.Enums.MessageType.VenueMessage:
                    break;
                default:
                    break;
            }
        }

        private static async void OnMessageReceived(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            Telegram.Bot.Types.Message m = e.Message;
            switch (m.Text)
            {
                case "/stop":
                    Bot.StopReceiving();
                    break;
                case "/help":
                    await Bot.SendTextMessageAsync(m.Chat.Id, m.From + "\n Hilfe: \n This bot is not completley implemented");
                    break;
                default: Console.WriteLine(m.Text);
                    break;
            }
        }
    }
}
