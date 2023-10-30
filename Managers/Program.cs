using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=srv2\\pupils;Initial Catalog=ShoppingBook;Integrated Security=True";


            DataAccess d = new DataAccess();
            d.readData(connectionString);
            d.InsertData(connectionString);
        
        }
    }
}
