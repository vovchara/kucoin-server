namespace KukoinServer.Model
{
    public class AsksBidsDTO
    {
        public CoinItemModel[] asks { get; }
        public CoinItemModel[] bids { get; }

        public AsksBidsDTO(CoinItemModel[] asks, CoinItemModel[] bids)
        {
            this.asks = asks;
            this.bids = bids;
        }
    }
}
