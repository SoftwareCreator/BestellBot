using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegramBestellBot
{
    class Program
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient("207190117:AAHNwEBiRQAx-T3nxSVR1uSiP5ZyN8dH-uo");
        static void Main(string[] args)
        {
            var me = Bot.GetMeAsync().Result;
            Console.WriteLine(me.Id + " " + me.FirstName + " " + me.LastName);
            Bot.OnMessage += OnMessageReceived;
            Bot.OnReceiveError += OnErrorReceived;
            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
            
        }

        private static void OnErrorReceived(object sender, Telegram.Bot.Args.ReceiveErrorEventArgs e)
        {
            Console.WriteLine(e.ApiRequestException);
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
