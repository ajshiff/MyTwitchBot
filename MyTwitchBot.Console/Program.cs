using System;
using MyTwitchBot.TwitchApiClient;

namespace MyTwitchBot.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = new TwitchApiClient.TwitchApiClient();
            System.Console.WriteLine("Hello World!");
        }
    }
}
