using FastMember;
using System.Data;

namespace TennisAdministrator;

public static class ListToDataTable
{
    public static DataTable Convert<T>(List<T> data)
    {
        DataTable table = new DataTable();
        using (var reader = ObjectReader.Create(data))
        {
            table.Load(reader);
        }
        return table;
    }
}
