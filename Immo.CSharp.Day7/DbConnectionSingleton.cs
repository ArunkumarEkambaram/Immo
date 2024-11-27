using System.Data.SqlClient;

namespace Immo.CSharp.Day7
{
    /*
 * Class Should be sealed
 * Private Constructor
 * Static Instance 
 * Readonly property which return instance
 * (Optional : Thread Safe)
 * (Optional : Lazy Loading)
 */
    public sealed class DbConnectionSingleton
    {
        private static DbConnectionSingleton _instance = null;
        private SqlConnection _conn = null;
        private static readonly object _instanceLock = new object();

        private DbConnectionSingleton()
        {
            _conn = new SqlConnection("Server=EGAIK-PC; Database=QuickKartDB; Integrated Security=true; MultipleActiveResultSets=true;");
            //if (_conn.State != System.Data.ConnectionState.Open)
            //{
            //    _conn.Open();
            //}
        }

        public static DbConnectionSingleton Instance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new DbConnectionSingleton();
                    }
                    return _instance;
                }
            }
        }

        public SqlConnection GetConnection()
        {
            return _conn;
        }
    }
}
