namespace NEO.Api.Models
{
    public class WalletAssetValueDto
    {
        public string AssetName { get; set; }
        public string AssetSymbol { get; set; }
        public string AssetHash { get; set; }
        public decimal Value { get; set; }
    }
}