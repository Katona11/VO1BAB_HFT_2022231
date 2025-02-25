﻿using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.SignalR;

namespace VO1BAB_HFT_20231.Endpoint.Services
{
    public class SignalRHub:Hub
    {
        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("Connected", Context.ConnectionId);
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            Clients.Caller.SendAsync("Disconnected", Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
