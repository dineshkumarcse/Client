using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Client();
        }
        static void Client()// SElva
        {
            var hubConnection = new HubConnectionBuilder()
            .WithUrl("https://localhost:5001/Watch")
            .Build();
            hubConnection.StartAsync().Wait();
            StartStop("Get", hubConnection);
            Console.ReadKey();
        }
        static bool StartStop(string inputrequest, HubConnection hubConnection)
        {
            if (inputrequest.Equals("Get", StringComparison.OrdinalIgnoreCase))
            {
                hubConnection.InvokeCoreAsync("Get", args: new[] { "Request" });
                hubConnection.On("Get", (string username) =>
                {
                    Console.Write(username);
                    return;
                });
            }
            else if (inputrequest.Equals("Start", StringComparison.OrdinalIgnoreCase))
            {
                hubConnection.InvokeCoreAsync("Start", args: new[] { "Request" });
                hubConnection.On("Start", (string username) =>
                {
                    Console.Write(username);
                    return;
                });
            }
            else if (inputrequest.Equals("Stop", StringComparison.OrdinalIgnoreCase))
            {
                hubConnection.InvokeCoreAsync("Stop", args: new[] { "Request" });
                hubConnection.On("Stop", (string username) =>
                {
                    Console.Write(username);
                    return;
                });
            }
            else if (inputrequest.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                Environment.Exit(0);
            }
            String input = Console.ReadLine();
            StartStop(input, hubConnection);
            return true;
        }
    }
}
