using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dewey.Demo
{
    public class PhoneNumber : IColumn
    {
        public object ColumnValue(ColumnDescription colDesc)
        {
            return Faker.Phone.Number();
        }
    }
}