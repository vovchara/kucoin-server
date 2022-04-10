using KukoinServer.Model;

namespace KukoinServer.Services
{
    public class KucoinMessagingService
    {
        internal Task<bool> ConnectToSocket(string pairId)
        {
            throw new NotImplementedException();
        }

        internal Task<MessageModel> GetLastMessage()
        {
            throw new NotImplementedException();
        }

        internal bool isConnected(string pairId)
        {
            throw new NotImplementedException();
        }
    }
}
