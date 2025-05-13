using System.Data;
using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using SmartSeg.Core;

public static class CsvLoader
{
    public static IDataFrame LoadCsv(string path)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            PrepareHeaderForMatch = args => args.Header.Trim(),
            MissingFieldFound = null,
        };

        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, config);
        using var dr = new CsvDataReader(csv);
        var table = new DataTable();
        table.Load(dr);
        return new SmartDataFrame(table);
    }
}