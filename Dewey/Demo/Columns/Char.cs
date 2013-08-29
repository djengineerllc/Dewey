using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dewey.Demo
{
    public class Char : IColumn
    {
        Random rand;
        public Char(Random r) { rand = r; }
        public object ColumnValue(ColumnDescription colDesc)
        {
            char[] chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();
            int num = rand.Next(0, 26); // Zero to 25
            char let = (char)('a' + num);
            return let;
        }
    }
}