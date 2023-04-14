using ECrypto.Models.Base;
using Newtonsoft.Json;

namespace ECrypto.Models
{
    public class Market : Model
    {
        private string _volumeUsd24Hr;
        private string _priceUsd;
        private string _volumePercent;

        [JsonProperty("exchangeId")]
        public string? ExchangeId { get; set; }

        [JsonProperty("baseId")]
        public string? BaseId { get; set; }

        [JsonProperty("quoteId")]
        public string? QuoteId { get; set; }

        [JsonProperty("baseSymbol")]
        public string? BaseSymbol { get; set; }

        [JsonProperty("quoteSymbol")]
        public string? QuoteSymbol { get; set; }
        
        [JsonProperty("volumeUsd24Hr")]
        public string? VolumeUsd24Hr
        {
            get => _volumeUsd24Hr;
            set
            {
                if (value == null)
                {
                    _volumeUsd24Hr = "0";
                }
                _volumeUsd24Hr = TransformBigNumber(value);
            }
        }

        [JsonProperty("priceUsd")]
        public string? PriceUsd
        {
            get => _priceUsd;
            set => _priceUsd = TransformRegularNumber(value);
        }

        [JsonProperty("volumePercent")]
        public string? VolumePercent
        {
            get => _volumePercent;
            set
            {
                if (value == null)
                {
                    _volumePercent = "0";
                }
                _volumePercent = TransformBigNumber(value);
            }
        }
    }
}
