using Microsoft.AspNetCore.SignalR;
using PowerplantUIL.Models;

namespace PowerplantUIL.Hubs;

public class PowerplantHub : Hub
{
    public Task SendResult(IEnumerable<ResultModel> result)
    {
        return Clients.All.SendAsync("ReceiveResult", result);
    }
}
