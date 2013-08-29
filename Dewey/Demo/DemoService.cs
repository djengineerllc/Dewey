using ServiceStack.Logging;
using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dewey.Demo
{
    public class DemoService : IService
    {
        private void UpdateDefaults(ref Demo request)
        {
            if (!request.rowCount.HasValue) { request.rowCount = Demo.DEFAULT_ROW_COUNT; }
        }
        public object Any(Demo request)
        {
            DemoResponse response = new DemoResponse();
            ILog log = LogManager.GetLogger(GetType());
            log.Info("Dewey Demo Services");
            UpdateDefaults(ref request);
            List<Tuple<int, int, string, object>> tuples = new List<Tuple<int, int, string, object>>();
            if (request.Columns.Length == 0) {
                log.Fatal("Must specify Columns in order to receive a table of data.");
                return null;
            }
            Random rand = new Random();
            response.Data = new List<List<object>>();
            for (int j = 0; j < request.rowCount; ++j)
            {
                List<object> row = new List<object>();
                for (int i = 0; i < request.Columns.Length; ++i)
                {
                    object value = null;
                    string format = "";
                    if (request.Columns[i].max == null) { request.Columns[i].max = ColumnDescription.DEFAULT_MAX_NUMBER; }
                    if (request.Columns[i].min == null) { request.Columns[i].min = ColumnDescription.DEFAULT_MIN_NUMBER; }
                    switch (request.Columns[i].type)
                    {
                        case "number":
                            format = "{0:" + request.Columns[i].format + "}";
                            value = string.Format(format, rand.NextDouble() * (request.Columns[i].max - request.Columns[i].min) + request.Columns[i].min);
                            break;
                        case "string":
                            if (request.Columns[i].format == null || request.Columns[i].format == string.Empty) { format = ColumnDescription.DEFAULT_FORMAT_STRING; }
                            else { format = request.Columns[i].format; }
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
                            break;
                        case "name":
                            if (request.Columns[i].format == null || request.Columns[i].format == string.Empty) { format = ColumnDescription.DEFAULT_FORMAT_NAME; }
                            else { format = request.Columns[i].format; }
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
                            break;
                        case "address":
                            if (request.Columns[i].format == null || request.Columns[i].format == string.Empty) { format = ColumnDescription.DEFAULT_FORMAT_ADDRESS; }
                            else { format = request.Columns[i].format; }
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
                                    value = Faker.Address.CitySufix();
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
                            break;
                        case "char":
                            break;
                        case "bool":
                            format = "{0:" + request.Columns[i].format + "}";
                            bool b = (int)Math.Round(rand.NextDouble(), 0) == 1 ? true : false;
                            value = b.ToString(format);
                            break;
                        case "date":
                            format = "{0:" + request.Columns[i].format + "}";
                            break;
                    }
                    row.Add(value); 
                }
                response.Data.Add(row);
            }
            return response;
        }
    }
}