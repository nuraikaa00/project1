using System;

namespace sweet_shop.Enums
{
    public enum Month
    {
        JANUARY, 
        FEBRUARY, 
        MARCH, 
        APRIL, 
        MAY, 
        JUNE, 
        JULY, 
        AUGUST, 
        SEPTEMBER, 
        OCTOBER, 
        NOVEMBER, 
        DECEMBER
        
        
    }

    public static class UtilMonth
    {
        public static string getRusMonth(this Month month)
        {
            switch (month)
            {
                case Month.JANUARY: return "Январь";
                case Month.FEBRUARY: return "Февраль";
                case Month.MARCH: return "Март";
                case Month.APRIL: return "Апрель";
                case Month.MAY: return "Май";
                case Month.JUNE: return "Июнь";
                case Month.JULY: return "Июль";
                case Month.AUGUST: return "Август";
                case Month.SEPTEMBER: return "Сентябрь";
                case Month.OCTOBER: return "Октябрь";
                case Month.NOVEMBER: return "Ноябрь";
                case Month.DECEMBER: return "Декабрь";
            }

            return null;
        }

        public static Month parseMonthRus(this string month)
        {
            switch (month)
            {
                case "Январь": return Month.JANUARY;
                case "Февраль": return Month.FEBRUARY;
                case "Март": return Month.MARCH;
                case "Апрель": return Month.APRIL;
                case "Май": return Month.MAY;
                case "Июнь": return Month.JUNE;
                case "Июль": return Month.JULY;
                case "Август": return Month.AUGUST;
                case "Сентябрь": return Month.SEPTEMBER;
                case "Октябрь": return Month.OCTOBER;
                case "Ноябрь": return Month.NOVEMBER;
                case "Декабрь": return Month.DECEMBER;
            }

            throw new Exception("Такой месяц не существует!");
        }
    }
}