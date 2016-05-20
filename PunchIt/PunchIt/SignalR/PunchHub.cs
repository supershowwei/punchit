using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace PunchIt.SignalR
{
    public class PunchHub : Hub
    {
        public void Punch()
        {
            Clients.All.punch();
        }

        public void Punched()
        {
            Clients.All.punched();
        }
    }
}