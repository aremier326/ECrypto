using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECrypto.Models
{
    public class JsonArray<T>
    {
        public List<T> Data { get; set; }
        public long Timestamp { get; set; }
    }

    public class JsonObject<T>
    {
        public T Data { get; set; }
        public long Timestamp { get; set; }
    }
}
