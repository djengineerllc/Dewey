using System;
using System.Collections.Generic;

namespace Dewey.Demo
{
    public sealed class ColumnTypes
    {
        private readonly string name;
        private readonly int value;
        private static readonly Dictionary<string, ColumnTypes> nameInstance= new Dictionary<string, ColumnTypes>();
        private static readonly Dictionary<int, ColumnTypes> valInstance = new Dictionary<int, ColumnTypes>();
        
        public enum types { numberCol, stringCol, nameCol, addressCol, companyCol, internetCol, phonenumberCol, charCol, boolCol, dateCol };

        public static readonly ColumnTypes NUMBER = new ColumnTypes(0, types.numberCol.ToString());
        public static readonly ColumnTypes STRING = new ColumnTypes(1, types.stringCol.ToString());
        public static readonly ColumnTypes NAME = new ColumnTypes(2, types.nameCol.ToString());
        public static readonly ColumnTypes ADDRESS = new ColumnTypes(3, types.addressCol.ToString());
        public static readonly ColumnTypes COMPANY = new ColumnTypes(4, types.companyCol.ToString());
        public static readonly ColumnTypes INTERNET = new ColumnTypes(5, types.internetCol.ToString());
        public static readonly ColumnTypes PHONE_NUMBER = new ColumnTypes(6, types.phonenumberCol.ToString());
        public static readonly ColumnTypes CHAR = new ColumnTypes(7, types.charCol.ToString());
        public static readonly ColumnTypes BOOL = new ColumnTypes(8, types.boolCol.ToString());
        public static readonly ColumnTypes DATE = new ColumnTypes(9, types.dateCol.ToString());

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