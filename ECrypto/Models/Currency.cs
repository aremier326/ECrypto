using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;


namespace ECrypto.Models
{
    public class Currency
    {
        private string? _currentPrice;
        private string? _priceChange24h;
        private string? _priceChangePercentage24h;
        private string? _marketCap;
        private string? _marketCapChange24h;
        private string? _marketCapChangePercentage24h;
        private string? _circulatingSupply;
        private string? _totalVolume;
        private string? _ath;



        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("symbol")]
        public string? Symbol { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("current_price")]
        public string? CurrentPrice
        {
            get => _currentPrice;
            set => _currentPrice = TransformRegularNumber(value);
        }

        [JsonProperty("market_cap")]
        public string? MarketCap
        {
            get => _marketCap;
            set => _marketCap = TransformBigNumber(value);
        }

        [JsonProperty("market_cap_rank")]
        public string? MarketCapRank { get; set; }

        [JsonProperty("fully_diluted_valuation")]
        public string? FullyDilutedValuation { get; set; }

        [JsonProperty("total_volume")]
        public string? TotalVolume
        {
            get => _totalVolume;
            set => _totalVolume = TransformBigNumber(value);
        }

        [JsonProperty("high_24h")]
        public string? High24h { get; set; }

        [JsonProperty("low_24h")]
        public string? Low24h { get; set; }

        [JsonProperty("price_change_24h")]
        public string? PriceChange24h
        {
            get => _priceChange24h;
            set => _priceChange24h = TransformRegularNumber(value);
        }

        [JsonProperty("price_change_percentage_24h")]
        public string? PriceChangePercentage24h
        {
            get => _priceChangePercentage24h;
            set => _priceChangePercentage24h = TransformRegularNumber(value);
        }

        [JsonProperty("market_cap_change_24h")]
        public string? MarketCapChange24H
        {
            get => _marketCapChange24h;
            set => _marketCapChange24h = TransformRegularNumber(value);
        }

        [JsonProperty("market_cap_change_percentage_24h")]
        public string? MarketCapChangePercentage24H
        {
            get => _marketCapChangePercentage24h;
            set => _marketCapChangePercentage24h = TransformRegularNumber(value);
        }

        [JsonProperty("circulating_supply")]
        public string? CirculatingSupply
        {
            get => _circulatingSupply;
            set => _circulatingSupply = TransformBigNumber(value);
        }

        [JsonProperty("total_supply")]
        public string? TotalSupply { get; set; }

        [JsonProperty("max_supply")]
        public string? MaxSupply { get; set; }

        [JsonProperty("ath")]
        public string? ATH
        {
            get => _ath;
            set => _ath = TransformRegularNumber(value);
        }

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

        [JsonProperty("last_updated")]
        public string? LastUpdated { get; set; }

        private string ConvertBig(decimal num)
        {
            bool isB = false;
            bool isM = false;
            if (num > 1000000000)
            {
                num = num / 1000000000;
                isB = true;
            }
            else if (num > 1000000)
            {
                num = num / 1000000;
                isM = true;
            }
            num = Math.Round(num, 2);
            string res = num.ToString();
            if (isB) res = res + "b";
            if (isM) res = res + "m";
            return res;
        }

        private string TransformBigNumber(string value)
        {
            decimal val;
            decimal.TryParse(value, NumberStyles.Currency, new NumberFormatInfo() { NumberDecimalSeparator = "." }, out val);
            return ConvertBig(val);
        }
        private string TransformRegularNumber(string value)
        {
            decimal val;
            decimal.TryParse(value, NumberStyles.Currency, new NumberFormatInfo() { NumberDecimalSeparator = "." }, out val);
            val = Math.Round(val, 2);
            return val.ToString();
        }
    }
}
