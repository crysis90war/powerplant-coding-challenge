using Microsoft.AspNetCore.SignalR;
using Powerplant.Models;

namespace Powerplant.Hubs
{
    public class PowerplantHub : Hub
    {
        public Task SendResult(IEnumerable<ResultModel> result)
        {
            return Clients.All.SendAsync("ReceiveResult", result);
        }
    }
}
