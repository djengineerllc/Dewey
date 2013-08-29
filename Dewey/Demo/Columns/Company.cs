using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dewey.Demo
{
    public class Company : IColumn
    {
        public object ColumnValue(ColumnDescription colDesc)
        {
            string format;
            object value = null;
            if (colDesc.format == null || colDesc.format == string.Empty) { format = ColumnDescription.DEFAULT_FORMAT_COMPANY; }
            else { format = colDesc.format; }
            format = format.Trim().ToLower();
            switch (format)
            {
                case "bs":
                    value = Faker.Company.BS();
                    break;
                case "catchphrase":
                    value = Faker.Company.CatchPhrase();
                    break;
                case "name":
                    value = Faker.Company.Name();
                    break;
                case "suffix":
                    value = Faker.Company.Suffix();
                    break;
            }
            return value;
        }
    }
}