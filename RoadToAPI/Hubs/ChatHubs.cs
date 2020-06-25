using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadToAPI.Hubs
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ChatHubs : Hub
    {
        public async Task SendMessage(string user, string msg)
        {
            
            Console.WriteLine(Context);
            await Clients.Others.SendAsync("ReceiveMessage", user, msg);
        }
        public async Task SendPrivate(string toUserID, string msg)
        {
            Console.WriteLine(Context.UserIdentifier);
            //new HubConnectionContext().User.FindFirst
            var fromUser = Context.ConnectionId;
            //await 
        }
    }
}
