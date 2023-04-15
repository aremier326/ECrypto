using System;
using System.Globalization;

namespace ECrypto.Models.Base
{
    public abstract class Model
    {
        public string ConvertBig(decimal num)
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

        public string TransformBigNumber(string value)
        {
            decimal val;
            decimal.TryParse(value, NumberStyles.Currency, new NumberFormatInfo() { NumberDecimalSeparator = "." }, out val);
            return ConvertBig(val);
        }
        public string TransformRegularNumber(string value)
        {
            decimal val;
            decimal.TryParse(value, NumberStyles.Currency, new NumberFormatInfo() { NumberDecimalSeparator = "." }, out val);
            val = Math.Round(val, 2);
            return val.ToString();
        }
    }
}
