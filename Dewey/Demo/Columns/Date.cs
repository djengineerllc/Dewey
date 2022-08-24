using System;

namespace Dewey.Demo
{
    public class Date : IColumn
    {
        private DateTime start = new DateTime(1995, 1, 1);
        private DateTime end = DateTime.Now;
        private Random rand;
        private int range;
        public Date(Random r)
        {
            rand = r;
            range = (end - start).Days;
        }
        public DateTime RandomDay()
        {        
            return start.AddDays(rand.Next(range));
        }
        public object ColumnValue(ColumnDescription colDesc)
        {
            string format;
            object value = null;
            if (colDesc.format == null || colDesc.format == string.Empty) { format = "{0:"+ColumnDescription.DEFAULT_FORMAT_DATE+"}"; }
            else { format = "{0:" + colDesc.format + "}"; }
            value = string.Format(format, RandomDay());
            return value;
        }
    }
}