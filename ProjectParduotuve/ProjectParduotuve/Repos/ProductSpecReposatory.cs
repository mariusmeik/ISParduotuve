using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Data.SqlClient;
using ProjectParduotuve.Models;

namespace ProjectParduotuve.Repos
{
    public class ProductSpecReposatory
    {
        public static List<ProductSpec> GetAllItems (){
            List<ProductSpec> list = new List<ProductSpec>();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = ConnConfig.pauliusServer;
                builder.UserID = ConnConfig.pauliusName;
                builder.Password = "";
                builder.InitialCatalog = "IT";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    String sql = "SELECT * FROM Produkto_specifikacija";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new ProductSpec() {
                                    id = reader.GetInt32(0),
                                    name = reader.GetString(1),
                                    weight = reader.GetDouble(2),
                                    price = reader.GetDouble(3),
                                    discount = reader.GetDouble(4),
                                    count = reader.GetDouble(5)
                                });
                            }
                        }
                    }
                }
                return list;
            }
            catch (SqlException e)
            {
                list.Add(new ProductSpec());
                return list;
            }
        }
    }
}