using Microsoft.AspNetCore.SignalR;
using Powerplant.Models;

namespace Powerplant.Hubs
{
    public class PowerplantHub : Hub
    {
        /// <summary>
        /// Receive the list of results and send back to all connected clients.
        /// </summary>
        /// <param name="result">List of results</param>
        /// <returns>Return list of results to all connected clients.</returns>
        public Task SendResult(IEnumerable<ResultModel> result)
        {
            return Clients.All.SendAsync("ReceiveResult", result);
        }
    }
}
