using Microsoft.AspNetCore.SignalR;
using PowerplantUIL.Models;

namespace PowerplantUIL.Hubs;

public class PowerplantHub : Hub
{
    public Task SendResult(IEnumerable<ResultModel> result)
    {
        return Clients.All.SendAsync("ReceiveResult", result);
    }

    public override Task OnConnectedAsync()
    {
        string connectionId = Context.ConnectionId;
        Clients.Client(connectionId).SendAsync($"Welcome to powerplant challenge hub {connectionId}", connectionId);
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        string connectionId = Context.ConnectionId;
        return base.OnDisconnectedAsync(exception);
    }
}
