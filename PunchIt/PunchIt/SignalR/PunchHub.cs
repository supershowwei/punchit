using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace PunchIt.SignalR
{
    public class PunchHub : Hub
    {
        public static HashSet<string> Connections = new HashSet<string>();

        public void Punch()
        {
            Clients.All.punch();
        }

        public void Punched()
        {
            Clients.All.punched();
        }

        public override Task OnConnected()
        {
            Connections.Add(this.Context.ConnectionId);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Connections.Remove(this.Context.ConnectionId);

            return base.OnDisconnected(stopCalled);
        }
    }
}