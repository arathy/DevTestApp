using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace DevTest
{
    public class VoteHub : Hub
    {
        [HubMethodName("NotifyClients")]
       
        public static void NotifyCurrentEmployeeInformationToAllClients()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<VoteHub>();

            // the update client method will update the connected client about any recent changes in the server data
            context.Clients.All.updatedClients();
        }
    }
}