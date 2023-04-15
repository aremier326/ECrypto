using System;

namespace ECrypto.Services.ApiEndpoints
{
    public static class ApiEndPoints
    {
        public static readonly string BaseEndpoint = "https://api.coincap.io/v2/";

        public static readonly string Assets = "assets/";

        public static string GetAsset(string id) => Assets + id;

        public static string GetMarkets(string id) => GetAsset(id) + "/markets";
    }
}
