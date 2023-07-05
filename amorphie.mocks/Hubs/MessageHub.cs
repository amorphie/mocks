using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

public class MessageHub : Hub
{
    public async Task SendMessage(string method,string message)
    {
        await Clients.All.SendAsync(method, message, default);
    }
}
