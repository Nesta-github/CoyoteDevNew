using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using WebNesta.Coyote.Core.Data;
using WebNesta.Coyote.Geral.Domain;

namespace WebNesta.Coyote.Geral.Data
{
    public class AccountRepository : IRepository, IAccountRepository<UTUTISEN, TUSUSUARI>
    {
        private string ConnectionString;
        public AccountRepository()
        {
            ConnectionString = "Data Source=177.153.236.228;Initial Catalog=COYOTE_DEV;User id=COYOTE_DEV;Password=%c0y0t3_DEV#";
        }

        public void SetConnectionString(string connection)
        {
            this.ConnectionString = connection;
        }

        public UTUTISEN GetCredential(string username)
        {
            UTUTISEN account = null;

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var query = @"SELECT USIDUSUA,USCDSEUS,UTDTCASE,UTHOCASE,USFLFLAG,UTDTINIC,UTIDUTSE,UTTENTAT FROM UTUTISEN WHERE USIDUSUA=@USIDUSUA";

                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("USIDUSUA", username);

                    using (SqlDataReader rdr = command.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            account = new UTUTISEN();
                            account.USIDUSUA = !rdr.IsDBNull(0) ? rdr.GetString(0) : null;
                            account.USCDSEUS = !rdr.IsDBNull(1) ? rdr.GetString(1) : null;
                            account.UTDTCASE = !rdr.IsDBNull(2) ? rdr.GetDateTime(2) : DateTime.Now;
                            account.UTHOCASE = !rdr.IsDBNull(3) ? rdr.GetString(3) : null;
                            account.USFLFLAG = !rdr.IsDBNull(4) ? rdr.GetDecimal(4) : (decimal?)null;                           /* DateTime?*/
                            account.UTDTINIC = !rdr.IsDBNull(5) ? rdr.GetDateTime(5) : (DateTime?)null;
                            account.UTIDUTSE = !rdr.IsDBNull(6) ? rdr.GetDecimal(6) : 0;
                            account.UTTENTAT = !rdr.IsDBNull(7) ? rdr.GetInt32(7) : (int?)null;
                        }
                    }
                }

                connection.Close();
            }

            return account;
        }
        
        public TUSUSUARI GetAccountByEmail(string email)
        {
              TUSUSUARI account = null;
          
              using (var connection = new SqlConnection(this.ConnectionString))
              {
                  var query = @$"SELECT GOIDGRUP,USIDUSUA,USEMAILU,USNMPRUS, USNUMCEL FROM TUSUSUARI WHERE USEMAILU = @USEMAILU";
          
                  connection.Open();
          
                  using (var command = new SqlCommand(query, connection))
                  {
                      command.CommandType = CommandType.Text;
                      command.Parameters.AddWithValue("USEMAILU", email);
          
                      using (SqlDataReader rdr = command.ExecuteReader())
                      {
                          while (rdr.Read())
                          {
                              account = new TUSUSUARI();
                              account.GOIDGRUP = !rdr.IsDBNull(0) ? rdr.GetDecimal(0) : (decimal?)null;
                              account.USIDUSUA = !rdr.IsDBNull(1) ? rdr.GetString(1) : null;
                              account.USEMAILU = !rdr.IsDBNull(2) ? rdr.GetString(2) : null;
                              //account.TUDATECA = !rdr.IsDBNull(2) ? rdr.GetDateTime(2) : DateTime.Now;
                              //account.USEMAILU = !rdr.IsDBNull(3) ? rdr.GetString(3) : null;
                              //account.USIDUSUA = !rdr.IsDBNull(4) ? rdr.GetString(4) : null;
                              //account.USLANGUE = !rdr.IsDBNull(5) ? rdr.GetString(5) : null;
                              //account.USNMNIUS = !rdr.IsDBNull(6) ? rdr.GetString(6) : null;
                              account.USNMPRUS = !rdr.IsDBNull(3) ? rdr.GetString(3) : null;
                              //account.USNMSNUS = !rdr.IsDBNull(8) ? rdr.GetString(8) : null;
                              account.USNUMCEL = !rdr.IsDBNull(4) ? rdr.GetString(4) : null;
                              //account.NOTIFY = !rdr.IsDBNull(10) ? rdr.GetInt32(10) : 0;
                          }
          
                          //  command.ExecuteNonQuery();
                      }
                  }
          
                  connection.Close();
              }
          
            return account;
        }
        
        public string ValidateAccountAccess(string username, string password, string lang)
        {
            var result = string.Empty;

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var proc = @"nesta_sp_Credential_Is_Valid";

                connection.Open();

                using (var command = new SqlCommand(proc, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_User", username);
                    command.Parameters.AddWithValue("p_Pass", password);
                    command.Parameters.AddWithValue("p_Culture", lang);

                    SqlParameter outputMessage = new SqlParameter("@p_Message", SqlDbType.NVarChar, 4000)
                    {
                        Direction = ParameterDirection.Output
                    };

                      SqlParameter outputMessageCode = new SqlParameter("@p_Msg_Code", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(outputMessageCode);
                    command.Parameters.Add(outputMessage);
                    command.ExecuteNonQuery();
                    result = string.Concat(outputMessageCode.Value.ToString(),"|", outputMessage.Value);
                }
            }

            return result;
        }

        public void UpdateAccessAccount(string username)
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var query = string.Concat("update UTUTISEN set UTIDUTSE=UTIDUTSE+1 where USIDUSUA = '", username, "'");

                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;

                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
        }

        public string ResetCredential(string username, string code)
        {
            var result = string.Empty;

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var proc = @"nesta_sp_Reset_Credential";

                /*
                 1 - sucesso
                 0 - erro
                >1 - codigo do erro específico
                  */
                connection.Open();

                using (var command = new SqlCommand(proc, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_User", username);
                    command.Parameters.AddWithValue("p_Pass", code);
                    command.Parameters.AddWithValue("p_Reset", "3");
                    command.Parameters.AddWithValue("p_idioma", "pt-BR");

                    SqlParameter outputIdParam = new SqlParameter("@p_mensagem", SqlDbType.NVarChar, 4000)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(outputIdParam);
                    command.ExecuteNonQuery();
                    result = outputIdParam.Value.ToString();
                }
            }

            return result;
        }
    }
}
