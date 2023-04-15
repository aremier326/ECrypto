using ECrypto.Models.Base;
using Newtonsoft.Json;

namespace ECrypto.Models
{
    public class Currency : Model
    {
        private string? _priceUsd;
        private string? _changePercent24Hr;
        private string? _supply;
        private string? _maxSupply;
        private string? _volumeUsd24Hr;
        private string? _vwap24Hr;
        private string? _marketCapUsd;

        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("rank")]
        public string? Rank { get; set; }

        [JsonProperty("symbol")]
        public string? Symbol { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("supply")]
        public string? Supply
        {
            get => _supply;
            set => _supply = TransformBigNumber(value);
        }

        [JsonProperty("maxSupply")]
        public string? MaxSupply
        {
            get => _maxSupply;
            set
            {
                if (value == null)
                {
                    _maxSupply = "UNLIM";
                    return;
                }
                _maxSupply = TransformBigNumber(value);
            }
        }

        [JsonProperty("marketCapUsd")]
        public string? MarketCapUsd
        {
            get => _marketCapUsd;
            set => _marketCapUsd = TransformBigNumber(value);
        }

        [JsonProperty("volumeUsd24Hr")]
        public string? VolumeUsd24Hr
        {
            get => _volumeUsd24Hr;
            set => _volumeUsd24Hr = TransformBigNumber(value);
        }

        [JsonProperty("priceUsd")]
        public string? PriceUsd
        {
            get => _priceUsd;
            set => _priceUsd = TransformRegularNumber(value);
        }

        [JsonProperty("changePercent24Hr")]
        public string? ChangePercent24Hr
        {
            get => _changePercent24Hr;
            set => _changePercent24Hr = TransformRegularNumber(value);
        }

        [JsonProperty("vwap24Hr")]
        public string? Vwap24Hr
        {
            get => _vwap24Hr;
            set => _vwap24Hr = TransformRegularNumber(value);
        }
    }
}
