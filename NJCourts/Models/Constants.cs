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
            GREATER_OR_EQUAL,
            LOWER,
            LOWER_OR_EQUAL,
            NONE,
            RANGE
        }

        public static Comparison ComparisonFromString(string c)
        {
            if(c == "=")
            {
                return Comparison.EQUAL;
            }
            else if (c == "NONE")
            {
                return Comparison.NONE;
            }
            else if(c == ">")
            {
                return Comparison.GREATER;
            }else if(c == ">=")
            {
                return Comparison.GREATER_OR_EQUAL;
            }
            else if(c == "<")
            {
                return Comparison.LOWER;
            }
            else if (c == "<=")
            {
                return Comparison.LOWER_OR_EQUAL;
            }
            else if (c == "RANGE")
            {
                return Comparison.RANGE;
            }else
            {
                throw new InvalidCastException("Unknown comparison string: " + c == null? "null" : c);
            }
        }

        public static string ComparisonToString(this Comparison c)
        {
            switch (c)
            {
                case Comparison.EQUAL: return "=";
                case Comparison.GREATER: return ">";
                case Comparison.GREATER_OR_EQUAL: return ">=";
                case Comparison.LOWER: return "<";
                case Comparison.LOWER_OR_EQUAL: return "<=";
                case Comparison.NONE: return "NONE";
                case Comparison.RANGE: return "RANGE";
                default: throw new InvalidCastException("Unknown comparison enum: " + c.ToString());
            }
        }

        public static class DisplayFieldNames
        {
            public const string CASE_FILED_DATE = "CASE FILED DATE";
            public const string CASE_STATUS = "CASE STATUS";
            public const string CASE_TITLE = "CASE TITLE";
            public const string CASE_TYPE = "CASE TYPE";
            public const string COURT = "COURT";
            public const string DATE_TIME_OF_CREATION = "RECORDED ON";
            public const string DEBTOR_CITY = "CITY";
            public const string DEBTOR_FIRST_NAME = "DEBTOR FIRST NAME";
            public const string DEBTOR_LAST_NAME = "DEBTOR LAST NAME";
            public const string DEBTOR_STATE = "STATE";
            public const string DEBTOR_STREET = "DEBTOR STREET";
            public const string DEBTOR_ZIP = "ZIP";
            public const string DEMAND_AMOUNT = "DEMAND AMOUNT";
            public const string DOCKET_VALUE = "DOCKET VALUE";
            public const string ID = "ID";
            public const string VENUE = "VENUE";
        }

        public static class FieldNames
        {
            public const string CASE_FILED_DATE = "njcCaseFiledDate";
            public const string CASE_STATUS = "njcCaseStatus";
            public const string CASE_TITLE = "njcCaseTitle";
            public const string CASE_TYPE = "njcCaseType";
            public const string COURT = "njcCourt";
            public const string DATE_TIME_OF_CREATION = "njcDateTimeOfCreation";
            public const string DEBTOR_CITY = "njcDebtorCity";
            public const string DEBTOR_FIRST_NAME = "njcDebtorFirstName";
            public const string DEBTOR_LAST_NAME = "njcDebtorLastName";
            public const string DEBTOR_STATE = "njcDebtorState";
            public const string DEBTOR_STREET = "njcDebtorStreet";
            public const string DEBTOR_ZIP = "njcDebtorZip";
            public const string DEMAND_AMOUNT = "njcDemandAmount";
            public const string DOCKET_VALUE = "njcDocketValue";
            public const string ID = "njcId";
            public const string VENUE = "njcVenue";
        }

        public static class Placeholders
        {
            public const char MULTIVALUE_FILTER_SEPARATOR = ',';
            public const string CASE_FILED_DATE_COMPARISON = "___njcCaseFiledDateComparison___";
            public const string DEMAND_AMOUNT_COMPARISON = "___njcDemandAmountComparison___";
            public const string NEW_ZIP_LIST = "New List...";
            public const string ZIP_COMPARISON = "___njcZipComparison___";
        }

    }

}
