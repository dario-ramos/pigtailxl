using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NJCourts.Models
{
    public static class Constants
    {
        public enum Comparison
        {
            EQUAL,
            GREATER,
            LOWER,
            RANGE
        }

        public static Comparison ComparisonFromString(string c)
        {
            if(c == "=")
            {
                return Comparison.EQUAL;
            }else if(c == ">")
            {
                return Comparison.GREATER;
            }else if(c == "<")
            {
                return Comparison.LOWER;
            }else if (c == "RANGE")
            {
                return Comparison.RANGE;
            }else
            {
                throw new InvalidCastException("Unknown comparison string: " + c);
            }
        }

        public static string ComparisonToString(this Comparison c)
        {
            switch (c)
            {
                case Comparison.EQUAL: return "=";
                case Comparison.GREATER: return ">";
                case Comparison.LOWER: return "<";
                case Comparison.RANGE: return "RANGE";
                default: throw new InvalidCastException("Unknown comparison enum: " + c.ToString());
            }
        }

        public static class FieldNames
        {
            public const string CASE_FILED_DATE = "njcCaseFiledDate";
            public const string CASE_STATUS = "njcCaseStatus";
            public const string CITY = "njcDebtorCity";
            public const string DEMAND_AMOUNT = "njcDemandAmount";
            public const string DOCKET_VALUE = "njcDocketValue";
            public const string STATE = "njcDebtorState";
            public const string VENUE = "njcVenue";
            public const string ZIP = "njcDebtorZip";
        }

        public static class Placeholders
        {
            public const char MULTIVALUE_FILTER_SEPARATOR = ',';
            public const string CASE_FILED_DATE_COMPARISON = "___njcCaseFiledDateComparison___";
            public const string DEMAND_AMOUNT_COMPARISON = "___njcDemandAmountComparison___";
            public const string ZIP_COMPARISON = "___njcZipComparison___";
        }

    }

}
