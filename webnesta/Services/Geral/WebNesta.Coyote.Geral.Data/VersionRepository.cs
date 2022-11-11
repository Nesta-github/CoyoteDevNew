using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using WebNesta.Coyote.Core.Data;
using WebNesta.Coyote.Geral.Domain;

namespace WebNesta.Coyote.Geral.Data
{
    public class VersionRepository : IRepository, IVersionRepository
    {
        private string ConnectionString;
        public VersionRepository()
        {
            ConnectionString = "Data Source=177.153.236.228;Initial Catalog=COYOTE_DEV;User id=COYOTE_DEV;Password=%c0y0t3_DEV#";
        }
        public string GetVersion(string page)
        {
            try
            {

            
            var result = string.Empty;

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var query = @"select dbo.nesta_fn_Get_Object_Version(@p_Object_Name)";

                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                 //   command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_Object_Name", page);
                    SqlParameter outputIdParam = new SqlParameter("@r_result ", SqlDbType.NVarChar, 50)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(outputIdParam);
                    //command.ExecuteNonQuery();
                 //   result = outputIdParam.Value.ToString();

                     using (SqlDataReader rdr = command.ExecuteReader())
                     {
                         while (rdr.Read())
                         {
                             result = !rdr.IsDBNull(0) ? rdr.GetString(0) : null;
                         }
                     }
                }

                connection.Close();
            }

            return result;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw;
            }
        }
    }
}
