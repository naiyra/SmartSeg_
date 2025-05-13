using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSeg.Core
{
    public interface IDataFrame
    {
        List<string> GetColumnNames();
        string GetColumnType(string columnName); // "numeric" / "categorical"
        IEnumerable<object> GetColumnValues(string columnName);
        void SetColumnValues(string columnName, IEnumerable<object> values);
        IDataFrame Clone();
        int RowCount { get; }
    }

}
