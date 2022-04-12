using KukoinServer.Model;

namespace KukoinServer
{
    public class MessagesStorage
    {
        private CoinItemModel[] _asks; //todo think about another data type for cache
        private CoinItemModel[] _bids; //todo think about another data type for cache

        public void AddToChache(FullMessageModelDataChanges changes)
        {
            var asks = changes.asks;
            var bids = changes.bids;
            //todo conver to CoinItemModel s
        }

        public AsksBidsDTO GetMessages()
        {
            return null; //todo fix me
        }
    }
}
