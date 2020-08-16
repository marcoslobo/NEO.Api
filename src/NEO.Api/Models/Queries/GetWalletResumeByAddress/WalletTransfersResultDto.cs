namespace NEO.Api
{
    public class WalletTransfersResultDto
    {
        public string AssetHash { get; set; }
        public string AssetName { get; set; }
        public decimal Amount { get; set; }
        public char InOut { get; set; }
        public string Symbol { get; set; }
        

    }
}
