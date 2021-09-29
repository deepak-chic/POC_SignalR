using Microsoft.AspNetCore.SignalR;
using POC_SignalR.Service;
using System.Threading.Tasks;

namespace POC_SignalR.Hubs
{
    public class HubServer : Hub
    {
        private StockTicker _stockTicker;
        public static IHubContext<HubServer> Current { get; set; }

        public override Task OnConnectedAsync()
        {
            _stockTicker = StockTicker.GetInstance(Clients);
            Clients.Client(Context.ConnectionId).SendAsync("ReceiveConId", Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("SendMessage", message);
        }

        public async Task GetAllStocks()
        {
            _stockTicker = StockTicker.GetInstance(Clients);
            await Clients.All.SendAsync("GetAllStocks", _stockTicker.GetAllStocks());
        }
    }
}
