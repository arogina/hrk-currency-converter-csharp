using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    public static class Logic
    {

        public static double ConvertToHRK(double amount, double rate)
        {
            return amount * rate;
        } 

        public static double ConvertFromHRK(double amount, double rate)
        {
            return amount / rate;
        }
    }
}
