using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dewey.Demo
{
    public class Internet : IColumn
    {
        public object ColumnValue(ColumnDescription colDesc)
        {
            string format;
            object value = null;
            if (colDesc.format == null || colDesc.format == string.Empty) { format = ColumnDescription.DEFAULT_FORMAT_INTERNET; }
            else { format = colDesc.format; }
            format = format.Trim().ToLower();
            switch (format)
            {
                case "domainname":
                    value = Faker.Internet.DomainName();
                    break;
                case "domainsuffix":
                    value = Faker.Internet.DomainSuffix();
                    break;
                case "domainword":
                    value = Faker.Internet.DomainWord();
                    break;
                case "email":
                    value = Faker.Internet.Email();
                    break;
                case "freeemail":
                    value = Faker.Internet.FreeEmail();
                    break;
                case "username":
                    value = Faker.Internet.UserName();
                    break;
            }
            return value;
        }
    }
}