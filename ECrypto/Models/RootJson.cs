﻿using ECrypto.Models.Base;
using System.Collections.Generic;

namespace ECrypto.Models
{
    public class JsonArray<T> where T : Model, new()
    {
        public List<T> Data { get; set; }
        public long Timestamp { get; set; }
    }

    public class JsonObject<T> where T : Model, new()
    {
        public T Data { get; set; }
        public long Timestamp { get; set; }
    }
}
