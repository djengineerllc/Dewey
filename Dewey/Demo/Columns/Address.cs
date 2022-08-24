using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dewey.Demo
{
    public class Address : IColumn
    {
        public object ColumnValue(ColumnDescription colDesc)
        {
            string format;
            object value = null;
            if (colDesc.format == null || colDesc.format == string.Empty) { format = ColumnDescription.DEFAULT_FORMAT_ADDRESS; }
            else { format = colDesc.format; }
            format = format.Trim().ToLower();
            switch (format)
            {
                case "city":
                    value = Faker.Address.City();
                    break;
                case "cityprefix":
                    value = Faker.Address.CityPrefix();
                    break;
                case "citysufix":
                    value = Faker.Address.CitySuffix();
                    break;
                case "country":
                    value = Faker.Address.Country();
                    break;
                case "secondaryaddress":
                    value = Faker.Address.SecondaryAddress();
                    break;
                case "streetaddress":
                    value = Faker.Address.StreetAddress();
                    break;
                case "streetname":
                    value = Faker.Address.StreetName();
                    break;
                case "streetsuffix":
                    value = Faker.Address.StreetSuffix();
                    break;
                case "ukcountry":
                    value = Faker.Address.UkCountry();
                    break;
                case "ukcounty":
                    value = Faker.Address.UkCounty();
                    break;
                case "ukpostcode":
                    value = Faker.Address.UkPostCode();
                    break;
                case "usstate":
                    value = Faker.Address.UsState();
                    break;
                case "usstateabbr":
                    value = Faker.Address.UsStateAbbr();
                    break;
                case "zipcode":
                    value = Faker.Address.ZipCode();
                    break;
            }
            return value;
        }
    }
}