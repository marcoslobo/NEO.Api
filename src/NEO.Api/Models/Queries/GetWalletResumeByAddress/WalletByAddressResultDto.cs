using System.Collections.Generic;

namespace NEO.Api.Models
{
    public class WalletByAddressResultDto
    {
        public WalletByAddressResultDto()
        {
            AssetsValues = new List<WalletAssetValueDto>();
        }
        public string Address { get; set; }
        public List<WalletAssetValueDto> AssetsValues { get; set; }
    }
}
