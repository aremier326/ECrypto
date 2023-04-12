using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECrypto.Models
{
    public class Currency
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("symbol")]
        public string? Symbol { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("current_price")]
        public string? CurrentPrice { get; set; }

        [JsonProperty("market_cap")]
        public string? MarketCap { get; set; }

        [JsonProperty("market_cap_rank")]
        public string? MarketCapRank { get; set; }

        [JsonProperty("fully_diluted_valuation")]
        public string? FullyDilutedValuation { get; set; }

        [JsonProperty("total_volume")]
        public string? TotalVolume { get; set; }

        [JsonProperty("high_24h")]
        public string? High24h { get; set; }

        [JsonProperty("low_24h")]
        public string? Low24h { get; set; }

        [JsonProperty("price_change_24h")]
        public string? PriceChange24h { get; set; }

        [JsonProperty("price_change_percentage_24h")]
        public string? PriceChangePercentage24h { get; set; }

        [JsonProperty("market_cap_change_24h")]
        public string? MarketCapChange24H { get; set; }

        [JsonProperty("market_cap_change_percentage_24h")]
        public string? MarketCapChangePercentage24H { get; set; }

        [JsonProperty("circulating_supply")]
        public string? CirculatingSupply { get; set; }

        [JsonProperty("total_supply")]
        public string? TotalSupply { get; set; }

        [JsonProperty("max_supply")]
        public string? MaxSupply { get; set; }

        [JsonProperty("ath")]
        public string? ATH { get; set;}

        [JsonProperty("ath_change_percentage")]
        public string? ATHChangePercentage { get; set; }

        [JsonProperty("ath_date")]
        public string? ATHDate { get; set; }

        [JsonProperty("atl")]
        public string? ATL { get; set; }

        [JsonProperty("atl_change_percentage")]
        public string? ATLChangePercentage { get; set; }

        [JsonProperty("atl_date")]
        public string? ATLDate { get; set; }

        [JsonProperty("roi")]
        public string? ROI { get; set; }

        [JsonProperty("last_updated")]
        public string? LastUpdated { get; set; }
    }
}
