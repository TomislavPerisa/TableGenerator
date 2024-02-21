using System.ComponentModel;
using System.Reflection;
namespace TableGeneratorLibrary
{
    public class Table<T>
    {
        private List<string> headers;
        private List<T>? rows;

        public Table()
        {
            headers = [.. typeof(T).GetProperties().Select(x => x.GetCustomAttributes<DisplayNameAttribute>().SingleOrDefault()?.DisplayName ?? x.Name)];
        }
        public Table(IEnumerable<T> data) : this()
        {
            rows = new List<T>(data);
        }

        public string[] GetHeaders()
        {
            return headers.ToArray();
        }

        public void AddRow(T row)
        {
            if (rows == null)
            {
                rows = new List<T>();
            }
            rows.Add(row);
        }

        public string Show()
        {
            string table = "";
            string row = "";
            foreach (var header in headers)
            {
                row += header + " ";
            }
            table += row+"\n";
            row = "";
            for (int i = 0; i <= (rows?.Count ?? 0); i++)
            {
                if (rows != null && i!=0)
                {
                    foreach (var attribute in typeof(T).GetProperties())
                    {
                        row += typeof(T).GetProperty(attribute.Name)!.GetValue(rows[i-1])!.ToString()+" ";
                    }
                }
                table += row;
                row = "";
            }
            return table;
        }
    }
}
