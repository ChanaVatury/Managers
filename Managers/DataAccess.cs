using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
     class DataAccess
    {
        public int InsertData(string connectionString)
        {
            string name, image;
            int categoryId, price;
            Console.WriteLine("Insert name");
            name = Console.ReadLine();
            Console.WriteLine("Insert categoryId");
            categoryId = int.Parse(Console.ReadLine());
            Console.WriteLine("Insert price");
            price = int.Parse(Console.ReadLine());
            Console.WriteLine("Insert image");
            image = Console.ReadLine();

            string query = "INSERT INTO Product(categoryId,name,price,image) " +
                "VALUES(@categoryId,@name,@price,@image)";
            using (SqlConnection n = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, n))
            {
                cmd.Parameters.Add("@categoryId", SqlDbType.Int).Value = categoryId;
                cmd.Parameters.Add("@name", SqlDbType.VarChar,50).Value = name;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = price;
                cmd.Parameters.Add("@image", SqlDbType.VarChar,50).Value = image;
                n.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                n.Close();
                return rowAffected;

            }

        }
        public void readData(string connectionString)
        {

            string query = "select * from Product";

            using (SqlConnection n = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, n);
                try
                {
                    n.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}",
                            reader[0], reader[1], reader[2], reader[3], reader[4]);

                    }
                    reader.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
