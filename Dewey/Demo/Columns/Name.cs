using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dewey.Demo
{
    public class Name : IColumn
    {
        public object ColumnValue(ColumnDescription colDesc)
        {
            string format;
            object value = null;
            if (colDesc.format == null || colDesc.format == string.Empty) { format = ColumnDescription.DEFAULT_FORMAT_NAME; }
            else { format = colDesc.format; }
            format = format.Trim().ToLower();
            switch (format)
            {
                case "first":
                    value = Faker.Name.First();
                    break;
                case "last":
                    value = Faker.Name.Last();
                    break;
                case "standard":
                    value = Faker.Name.FullName(Faker.NameFormats.Standard);
                    break;
                case "withprefix":
                    value = Faker.Name.FullName(Faker.NameFormats.WithPrefix);
                    break;
                case "withsuffix":
                    value = Faker.Name.FullName(Faker.NameFormats.WithSuffix);
                    break;
            }
            return value;
        }
    }
}