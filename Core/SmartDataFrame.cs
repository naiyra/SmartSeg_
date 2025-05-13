using SmartSeg.Core;
using System.Data;

public class SmartDataFrame : IDataFrame
{
    private DataTable table;

    public SmartDataFrame(DataTable dataTable)
    {
        table = dataTable;
    }

    public List<string> GetColumnNames()
    {
        return table.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();
    }

    public string GetColumnType(string columnName)
    {
        var type = table.Columns[columnName].DataType;
        if (type == typeof(string)) return "categorical";
        if (type == typeof(int) || type == typeof(float) || type == typeof(double)) return "numeric";
        return "unknown";
    }

    public IEnumerable<object> GetColumnValues(string columnName)
    {
        return table.AsEnumerable().Select(row => row[columnName]);
    }

    public void SetColumnValues(string columnName, IEnumerable<object> values)
    {
        var valueList = values.ToList();

        // ✨ Fix: make sure the column is not read-only
        var col = table.Columns[columnName];
        if (col.ReadOnly)
        {
            col.ReadOnly = false;
        }

        for (int i = 0; i < table.Rows.Count && i < valueList.Count; i++)
        {
            table.Rows[i][columnName] = valueList[i];
        }
    }


    public IDataFrame Clone()
    {
        return new SmartDataFrame(table.Copy());
    }

    public int RowCount => table.Rows.Count;

    public DataTable GetInternalTable() => table; // Optional access
}
