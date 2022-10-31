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
    public class AccountRepository : IRepository, IAccountRepository<Account>
    {
        private readonly string ConnectionString;
        public AccountRepository()
        {
            ConnectionString = "Data Source=10.33.30.12;Initial Catalog=NESTA_WSDL;User id=NESTA_WSDL;Password=%n3st@_WSDL#;";
            //ConnectionString = connectionString;
        }

        public Account GetAccount(string username)
        {
            Account account = null;

            using (var connection = new SqlConnection(this.ConnectionString))
            {

var query = @"select CREDCONN from CREDENTI 
            WHERE CREDUSER=@CREDUSER and AMBATIVO=1";

                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@CREDUSER", username);

                    using (SqlDataReader rdr = command.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            account = new Account();
                            account.GOIDGRUP = !rdr.IsDBNull(0) ? rdr.GetInt32(0) : 0;
                            account.PAIDPAIS = !rdr.IsDBNull(1) ? rdr.GetInt32(1) : 0;
                            account.TUDATECA = !rdr.IsDBNull(2) ? rdr.GetDateTime(2) : DateTime.Now;
                            account.USEMAILU = !rdr.IsDBNull(3) ? rdr.GetString(3): null;
                            account.USIDUSUA = !rdr.IsDBNull(4) ? rdr.GetString(4): null;
                            account.USLANGUE = !rdr.IsDBNull(5) ? rdr.GetString(5): null;
                            account.USNMNIUS = !rdr.IsDBNull(6) ? rdr.GetString(6): null;
                            account.USNMPRUS = !rdr.IsDBNull(7) ? rdr.GetString(7): null;
                            account.USNMSNUS = !rdr.IsDBNull(8) ? rdr.GetString(8) : null;
                            account.USNUMCEL = !rdr.IsDBNull(9) ? rdr.GetString(9) : null;
                            account.NOTIFY =   !rdr.IsDBNull(10) ? rdr.GetInt32(10) : 0;
                        }

                        command.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }

            return account;
        }

        public Account GetAccount(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool ValidateAccountAccess(string username, string password)
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var proc = @"nesta_sp_Credencial_Valida";

                connection.Open();

                using (var command = new SqlCommand(proc, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@p_User", username);
                    command.Parameters.AddWithValue("@p_Pass", password);
                    command.Parameters.AddWithValue("@p_idioma", "pt-BR");

                    SqlParameter outputIdParam = new SqlParameter("@p_out_retorno", SqlDbType.NVarChar)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(outputIdParam);

                    using (SqlDataReader rdr = command.ExecuteReader())
                    {
                        
                    }
                }
            }
      //
      //              char separator = ' ';
      //  string[] param_dados = new string[3];
      //  param_dados[0] = "@p_User" + separator + USIDUSUA;
      //  param_dados[1] = "@p_Pass" + separator + PASS_ATUAL;
      //  param_dados[2] = "@p_idioma" + separator + "pt-BR";
      //  string retorno = db.ExecProcedure("nesta_sp_Credencial_Valida", param_dados, "p_mensagem", separator);
      //  if (retorno == "OK")
      //  {
      //      DTACESSO = DateTime.Now;
      //      db._acao = "Usuário";
      //      db._resumo = "Acesso";
      //      db._alteracao = "Alteração de quantidade de acesso ao sistema";
      //      db.Update("update UTUTISEN set UTIDUTSE=UTIDUTSE+1 where USIDUSUA = '" + USIDUSUA + "'");
      //      return true;
      //  }
      //  else if (retorno != string.Empty)
      //  {
      //
      //      exception = new Exception(retorno);
      //      return false;
      //  }
      //  else
      //  {
      //      exception = new Exception("Bad Request");
      //      return false;
      //  }

            return false;
        }
    }
}
