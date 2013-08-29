using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dewey.Demo
{
    public sealed class ColumnTypes
    {
        private readonly string name;
        private readonly int value;
        private static readonly Dictionary<string, ColumnTypes> nameInstance= new Dictionary<string, ColumnTypes>();
        private static readonly Dictionary<int, ColumnTypes> valInstance = new Dictionary<int, ColumnTypes>();

        public const string NUMBER_TYPE_NAME = "number";
        public const string STRING_TYPE_NAME = "string";
        public const string NAME_TYPE_NAME = "name";
        public const string ADDRESS_TYPE_NAME = "address";
        public const string COMPANY_TYPE_NAME = "company";
        public const string INTERNET_TYPE_NAME = "internet";
        public const string PHONENUMBER_TYPE_NAME = "phonenumber";
        public const string CHAR_TYPE_NAME = "char";
        public const string BOOL_TYPE_NAME = "bool";
        public const string DATE_TYPE_NAME = "date";

        public static readonly ColumnTypes NUMBER = new ColumnTypes(1, NUMBER_TYPE_NAME);
        public static readonly ColumnTypes STRING = new ColumnTypes(2, STRING_TYPE_NAME);
        public static readonly ColumnTypes NAME = new ColumnTypes(3, NAME_TYPE_NAME);
        public static readonly ColumnTypes ADDRESS = new ColumnTypes(4, ADDRESS_TYPE_NAME);
        public static readonly ColumnTypes COMPANY = new ColumnTypes(5, COMPANY_TYPE_NAME);
        public static readonly ColumnTypes INTERNET = new ColumnTypes(6, INTERNET_TYPE_NAME);
        public static readonly ColumnTypes PHONE_NUMBER = new ColumnTypes(7, PHONENUMBER_TYPE_NAME);
        public static readonly ColumnTypes CHAR = new ColumnTypes(8, CHAR_TYPE_NAME);
        public static readonly ColumnTypes BOOL = new ColumnTypes(9, BOOL_TYPE_NAME);
        public static readonly ColumnTypes DATE = new ColumnTypes(10, DATE_TYPE_NAME);

        private ColumnTypes(int value, string name)
        {
            nameInstance[name] = this;
            valInstance[value] = this;
            this.name = name;
            this.value = value;
        }

        public override string ToString() { return name; }
        public int ToInt() { return value; }

        public static explicit operator ColumnTypes(string str)
        {
            ColumnTypes result;
            if (nameInstance.TryGetValue(str, out result)) { return result; }
            else { throw new InvalidCastException(); }
        }
        public static explicit operator ColumnTypes(int idVal)
        {
            ColumnTypes result;
            if (valInstance.TryGetValue(idVal, out result)) { return result; }
            else { throw new InvalidCastException(); }
        }
        //public static implicit operator ColumnTypes(string name)
        //{
        //    ColumnTypes result;
        //    nameInstance.TryGetValue(name, out result);
        //    if (result != null) { return result; }
        //    else { throw new InvalidCastException(); }
        //}
        //public static implicit operator ColumnTypes(int idVal)
        //{
        //    ColumnTypes result;
        //    valInstance.TryGetValue(idVal, out result);
        //    if (result != null) { return result; }
        //    else { throw new InvalidCastException(); }
        //}
    }
}