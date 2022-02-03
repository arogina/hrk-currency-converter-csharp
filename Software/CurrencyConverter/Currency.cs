using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;


namespace CurrencyConverter
{
    public class Currency
    {
        public string Index { get; set; }
        public double Rate { get; set; }
        public List<Currency> Currencies = new List<Currency>();

        public void GetCurrencies()
        {
            string json = null;
            string url = @"https://api.hnb.hr/tecajn/v2";
            using (var webClient = new WebClient())
            {
                json = webClient.DownloadString(url);
            }
                
            if (json != null)
            {
                var data = JArray.Parse(json);
                foreach(var item in data)
                {
                    Currencies.Add(new Currency
                    {
                        Index = item["valuta"].Value<string>(),
                        Rate = double.Parse(item["srednji_tecaj"].Value<string>())
                    });
                }
            } else
            {
                throw new Exception("Currency data is not found!");
            }
        }
    }
}
