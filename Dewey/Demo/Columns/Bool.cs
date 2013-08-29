using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dewey.Demo
{
    public class Bool : IColumn
    {
        Random rand;
        public Bool(Random r) { rand = r; }
        public object ColumnValue(ColumnDescription colDesc)
        {
            string format;
            object value = null;
            format = "{0:" + colDesc.format + "}";
            bool b = (int)Math.Round(rand.NextDouble(), 0) == 1 ? true : false;
            value = b.ToString(format);
            return value;
        }
    }
}