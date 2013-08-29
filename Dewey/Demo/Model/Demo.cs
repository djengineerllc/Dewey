using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Dewey.Demo
{
    [Api("Get demo data api")]
    [Route("/demo")]
    [Route("/demo/{rowCount}")]
    [Route("/demo/{rowCount}/{Columns}")]
    [Route("/demo/{rowCount}/{Columns}/{Culture}")]
    public class Demo
    {
        public static CultureInfo DEFAULT_CULTURE = CultureInfo.DefaultThreadCurrentCulture;
        public const int DEFAULT_ROW_COUNT = 10;
        public const string DEFAULT_COLUMN_TYPE = "string";
        public const string DEFAULT_FORMAT_STRING = "{0}";
        [ApiMember(Name = "Columns", Description = "Columns descriptions", IsRequired = true, AllowMultiple = true)]
        public ColumnDescription[] Columns { get; set; }
        [ApiMember(Name = "rowCount", Description = "Number of rows to return", DataType="int", IsRequired = false, AllowMultiple = false)]
        public int? rowCount { get; set; }
        [ApiMember(Name="Culture", Description="Culture used for formatting dates/currencies/decimals", DataType="string", IsRequired=false, AllowMultiple=false)]
        [ApiAllowableValues("Culture", new string [] { "en-US" })]
        public string Culture { get; set; }
    }
    public class ColumnDescription
    {
        public const string DEFAULT_FORMAT_NUMBER = "{0:N}";
        public const string DEFAULT_FORMAT_STRING = "w5";
        public const string DEFAULT_FORMAT_NAME = "standard";
        public const string DEFAULT_FORMAT_ADDRESS = "streetaddress";
        public const string DEFAULT_FORMAT_COMPANY = "name";
        public const string DEFAULT_FORMAT_INTERNET = "email";
        public const string DEFAULT_FORMAT_DATE = "G";
        public const double DEFAULT_MAX_NUMBER = 100d;
        public const double DEFAULT_MIN_NUMBER = -100d;
        [ApiMember(Name = "name", Description = "Column name", IsRequired = true, AllowMultiple = true)]
        public string name { get; set; }
        [ApiMember(Name = "type", Description = "Column data type", DataType="enum", IsRequired = false, AllowMultiple = false)]
        public string type { get; set; }
        [ApiMember(Name = "format", Description = "Format for column value", IsRequired = false, AllowMultiple = false)]
        public string format { get; set; }
        [ApiMember(Name = "max", Description = "Maximum value for random number", DataType = "double", IsRequired = false, AllowMultiple = false)]
        public double? max { get; set; }
        [ApiMember(Name = "min", Description = "Minimum value for random number", DataType = "double", IsRequired = false, AllowMultiple = false)]
        public double? min { get; set; }

        public ColumnDescription() { }
        public ColumnDescription(string Name, string Type, string Format, double? Max, double? Min)
        {
            name = Name;
            type = Type;
            format = Format;
            max = Max.HasValue ? Max.Value : DEFAULT_MAX_NUMBER;
            min = Min.HasValue ? Min.Value : DEFAULT_MIN_NUMBER;
        }
    }
}