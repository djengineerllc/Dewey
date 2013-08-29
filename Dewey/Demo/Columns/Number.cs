using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dewey.Demo
{
    public class Number : IColumn
    {
        private Random rand { get; set; }
        public Number(Random r) { rand = r; }
        public object ColumnValue(ColumnDescription colDesc)
        {
            object value = null;
            string Format = string.Format("{0:{0}}", colDesc.format);
            value = string.Format(colDesc.format, rand.NextDouble() * (colDesc.max - colDesc.min) + colDesc.min);
            return value;
        }
    }
}