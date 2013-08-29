using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dewey.Demo
{
    public interface IColumn
    {
        object ColumnValue(ColumnDescription colDesc);
    }
}
