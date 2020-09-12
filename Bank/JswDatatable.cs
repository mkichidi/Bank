using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
   public static class JswDatatable
    {
        public static string userId = string.Empty;
        public static string PdFPath = string.Empty;

        public static string navigator = string.Empty;
        public static int accountNo;

        public static DataTable dt = new DataTable();
        public static DataTable dtDetails = new DataTable();
        public static DateTime submitDate = new DateTime();

        public static string product = string.Empty;
        public static string from = string.Empty;
        public static string to = string.Empty;
        public static string party = string.Empty;

        public static int bill = 0;
        public static string billForCon = "0";
        public static string SummAll = "0";
        public static decimal rate = 0;

        public static int Previous = 0;

        public static string ConvertNumbertoWords(long number)
        {
            string str = ConvertNumbertoWordsremove(number);
            return str.Substring(0, 1) + str.Substring(1).ToLower() + " only";
        }

        public static string ConvertNumbertoWordsremove(long number)
        {
            //if (number == 0) return "ZERO"; if (number < 0) return "minus " + ConvertNumbertoWordsremove(Math.Abs(number)); string words = ""; if ((number / 1000000) > 0) { words += ConvertNumbertoWordsremove(number / 100000) + " LAKES "; number %= 1000000; }
            //if ((number / 1000) > 0) { words += ConvertNumbertoWordsremove(number / 1000) + " THOUSAND "; number %= 1000; }
            //if ((number / 100) > 0) { words += ConvertNumbertoWordsremove(number / 100) + " HUNDRED "; number %= 100; }      //if ((number / 10) > 0)      //{      // words += ConvertNumbertoWords(number / 10) + " RUPEES ";      // number %= 10;      //}
            //if (number > 0) { if (words != "") words += "AND "; var unitsMap = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" }; var tensMap = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" }; if (number < 20) words += unitsMap[number]; else { words += tensMap[number / 10]; if ((number % 10) > 0) words += " " + unitsMap[number % 10]; } }
            //return words;

            if (number == 0) return "ZERO";
            if (number < 0) return "minus " + ConvertNumbertoWordsremove(Math.Abs(number));
            string words = "";
            if ((number / 10000000) > 0)
            {
                words += ConvertNumbertoWordsremove(number / 10000000) + " CRORE ";
                number %= 10000000;
            }
            if ((number / 100000) > 0)
            {
                words += ConvertNumbertoWordsremove(number / 100000) + " LAKH ";
                number %= 100000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWordsremove(number / 1000) + " THOUSAND ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWordsremove(number / 100) + " HUNDRED ";
                number %= 100;
            }
            //if ((number / 10) > 0)  
            //{  
            // words += ConvertNumbertoWords(number / 10) + " RUPEES ";  
            // number %= 10;  
            //}  
            if (number > 0)
            {
                if (words != "") words += "AND ";
                var unitsMap = new[]
                {
            "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"
        };
                var tensMap = new[]
                {
            "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"
        };
                if (number < 20) words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0) words += " " + unitsMap[number % 10];
                }
            }
            return words;
        }
    }
}
