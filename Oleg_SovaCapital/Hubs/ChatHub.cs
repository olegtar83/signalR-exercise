using System;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;


namespace SignalRChat
{

    public class ChatHub : Hub
    {
        public static  IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();

        public override Task OnConnected()
        {
            return base.OnConnected();
        }



        public void CheckCache()
        {
          var clients = context.Clients.All;
          var cachedvalues = CacheManager.GetCache<string>();
          var result=  string.Join(",", cachedvalues.ToArray());
          clients.returnCachedValues(result);
        }

        public void Chat()
        {  
            var guid = Guid.NewGuid();
            var clients =context.Clients.All;
            CacheManager.SetCache(guid.ToString(), guid.ToString());
            clients.messageReceived(guid.ToString());
        }




    }
}