using Microsoft.Owin;

using System;
using Owin;
using SignalRChat;
[assembly: OwinStartup(typeof(SignalRChat.Startup))]
namespace SignalRChat
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
            var hub = new ChatHub();
            hub.CheckCache();
            var timer = new System.Threading.Timer((e) =>
            {
                hub.Chat();

            },null , TimeSpan.Zero.Seconds, 1500);

        }
    }

}