namespace KukoinServer.Model
{
    public class CoinItemModel
    {
        public string price { get; }
        public string size { get; }
        public string sequence { get; }

        public CoinItemModel(string[] item)
        {
            this.price = item[0];
            this.size = item[1];
            this.sequence = item[2];
        }
    }
}
