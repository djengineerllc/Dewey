using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dewey.Demo
{
    public class String : IColumn
    {
        public object ColumnValue(ColumnDescription colDesc)
        {
            object value = null;
            string format = string.Empty;
            if (colDesc.format == null || colDesc.format == string.Empty) { format = ColumnDescription.DEFAULT_FORMAT_STRING; }
            else { format = colDesc.format; }
            format = format.Trim().ToLower();
            string formatType = format[0].ToString();
            int formatCount = 0;
            if (format.Length == 1) { formatCount = 1; }
            else { formatCount = int.Parse(format.Replace(formatType, "")); }
            switch (formatType)
            {
                case "w"://words
                    value = string.Join(" ", Faker.Lorem.Words(formatCount));
                    break;
                case "p"://paragraphs
                    value = string.Join(" ", Faker.Lorem.Paragraphs(formatCount));
                    break;
                case "s"://sentences
                    value = string.Join(" ", Faker.Lorem.Sentences(formatCount));
                    break;
            }
            return value;
        }
    }
}