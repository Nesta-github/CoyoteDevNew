using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WebNesta.Coyote.Core.Domain;

namespace WebNesta.Coyote.Geral.Domain
{
    public class Account : IDomain
    {
        public Account(string user = "-1")
        {
            if (user != "-1")
                CREDUSER = user;
        }

        /// <summary>
        /// Credencial do usuários
        /// </summary>
        public string CREDUSER { get; set; }
        public int GOIDGRUP { get; set; }
        public string USIDUSUA { get; set; }
        public string USLANGUE { get; set; }
        public string USNMPRUS { get; set; }
        public string USNMNIUS { get; set; }
        public string USNMSNUS { get; set; }
        public string USEMAILU { get; set; }
        public string USIMGB64 { get; set; }
        public string USNUMCEL { get; set; }
        public DateTime TUDATECA { get; set; }
        public DateTime DTACESSO { get; set; }
        public string PASS_ATUAL { get; set; }
        public string PASS1 { get; set; }
        public string PASS2 { get; set; }
        public int PAIDPAIS { get; set; }
        public string MASK { get; set; }
        public int NOTIFY { get; set; }
        public int USSMTPAC { get; set; }
        public Exception exception { get; set; }
        public bool ValidaSenhaAtual()
        {
            //Modeling db = new Modeling(CREDUSER);
            //char separator = ' ';
            //string[] param_dados = new string[3];
            //param_dados[0] = "@p_User" + separator + USIDUSUA;
            //param_dados[1] = "@p_Pass" + separator + PASS_ATUAL;
            //param_dados[2] = "@p_idioma" + separator + "pt-BR";
            //string retorno = db.ExecProcedure("nesta_sp_Credencial_Valida", param_dados, "p_mensagem", separator);
            //if (retorno == "OK")
            //{
            //    DTACESSO = DateTime.Now;
            //    db._acao = "Usuário";
            //    db._resumo = "Acesso";
            //    db._alteracao = "Alteração de quantidade de acesso ao sistema";
            //    db.Update("update UTUTISEN set UTIDUTSE=UTIDUTSE+1 where USIDUSUA = '" + USIDUSUA + "'");
            //    return true;
            //}
            //else if (retorno != string.Empty)
            //{
            //
            //    exception = new Exception(retorno);
            //    return false;
            //}
            //else
            //{
            //    exception = new Exception("Bad Request");
            //    return false;
            //}
            return false;
        }
        public bool AlterarSenha(bool padrao = false)
        {
            // Modeling db = new Modeling(CREDUSER);
            // bool retorno = false;
            // string[] param_dados = new string[4];
            // param_dados[0] = "@p_User#" + USIDUSUA;
            // param_dados[1] = "@p_Pass#" + PASS2;
            // if (padrao)
            //     param_dados[2] = "@p_Reset#2";
            // else
            //     param_dados[2] = "@p_Reset#3";
            // param_dados[3] = "@p_idioma#pt-BR";
            // string sqlUs = "update TUSUSUARI set USCDSEUS=(SELECT [dbo].[nesta_fn_Criptografa] ('" + PASS2 + "')) where USIDUSUA='" + USIDUSUA + "'";
            // db._acao = "Cadastro Usuário";
            // db._resumo = "Alteraçã de Senha";
            // db._alteracao = "Alteração de Senha de acesso ao sistema";
            // if (db.Update(sqlUs))
            // {
            //     if (db.ExecProcedure("nesta_sp_Reset_Credential", param_dados, "p_mensagem"))
            //     {
            //         db.Update("update TUSUSUARI set USSMTPAC=0 where USIDUSUA='" + USIDUSUA + "'");
            //         retorno = true;
            //     }
            //     else
            //     {
            //         exception = db.error;
            //         retorno = false;
            //     }
            // }
            // else
            // {
            //     exception = db.error;
            //     retorno = false;
            // }
            // return retorno;
            return false;
        }
        public bool RecoverSenha(string code)
        {
            //Modeling db = new Modeling(CREDUSER);
            ////Functions func = new Functions();
            ////string code = func.RandomString(8);
            //bool retorno = false;
            //string[] param_dados = new string[4];
            //param_dados[0] = "@p_User#" + USIDUSUA;
            //param_dados[1] = "@p_Pass#" + code;
            //param_dados[2] = "@p_Reset#3";
            //param_dados[3] = "@p_idioma#pt-BR";
            //db._acao = "Cadastro Usuário";
            //db._resumo = "Recuperação de Senha";
            //db._alteracao = "Recuperação de Senha de acesso ao sistema";
            //if (db.ExecProcedure("nesta_sp_Reset_Credential", param_dados, "p_mensagem"))
            //{
            //    List<Account> accounts = CarregaUsuario();
            //    db.Update("update TUSUSUARI set USSMTPAC=1 where USIDUSUA='" + USIDUSUA + "'");
            //    try
            //    {
            //        //Notifying.SendingWhats(accounts[0].USNUMCEL, "Nesta Notifier", string.Format("Senha de acesso ao sistema foi recuperada. \n*{0}*", code));
            //    }
            //    catch { }
            //    try
            //    {
            //        //Notifying.sendEmailSMTP(accounts[0].USEMAILU, 2, code);
            //        //NotifyingEmail email = new NotifyingEmail();
            //        //email.To.Add(accounts[0].USEMAILU);
            //        //email.Subject = "Coyote Contracts - Recuperação de Senha";
            //        //email.Body = string.Format("Nova senha para acesso ao sistema: {0}", code);
            //        //var task = System.Threading.Tasks.Task.Run(async () => { await email.Send(); });
            //        //task.Wait();
            //    }
            //    catch (Exception ex)
            //    { }
            //    retorno = true;
            //}
            //else
            //{
            //    exception = db.error;
            //    retorno = false;
            //}
            //return retorno;
            return false;
        }
        public bool ResetarSenha()
        {
            //Modeling db = new Modeling(CREDUSER);
            //bool retorno = false;
            //string[] param_dados = new string[4];
            //param_dados[0] = "@p_User#" + USIDUSUA;
            //param_dados[1] = "@p_Pass#12345678a!";
            //param_dados[2] = "@p_Reset#1";
            //param_dados[3] = "@p_idioma#pt-BR";
            //if (db.ExecProcedure("nesta_sp_Reset_Credential", param_dados, "p_mensagem"))
            //{
            //    retorno = true;
            //}
            //else
            //{
            //    exception = db.error;
            //    retorno = false;
            //}
            //return retorno;
            return false;
        }
        public List<Account> CarregaUsuario()
        {
            // Modeling db = new Modeling(CREDUSER);
            // List<Account> retorno = new List<Account>();
            // string sql = "select GOIDGRUP, USIDUSUA,USLANGUE,USNMPRUS,USNMNIUS,USEMAILU,USNMSNUS,USNUMCEL,TUDATECA,PAIDPAIS,USIMGB64,USSMTPAC from TUSUSUARI where USIDUSUA='" + USIDUSUA + "'";
            // var result = db.Select(sql, 12);
            // try
            // {
            //     retorno.Add(new Account()
            //     {
            //         GOIDGRUP = string.IsNullOrEmpty(result[0]) ? 0 : Convert.ToInt32(result[0]),
            //         USIDUSUA = result[1],
            //         USLANGUE = result[2],
            //         USNMPRUS = result[3],
            //         USNMNIUS = result[4],
            //         USEMAILU = result[5],
            //         USNMSNUS = result[6],
            //         USNUMCEL = result[7],
            //         TUDATECA = Convert.ToDateTime(result[8]),
            //         PAIDPAIS = string.IsNullOrEmpty(result[9]) ? 0 : Convert.ToInt32(result[9]),
            //         USIMGB64 = result[10],
            //         USSMTPAC = Convert.ToInt32(result[11]),
            //         NOTIFY = ListarNotificaoesRecebidos().Where(m => m.WFDTDATA == null).Count()
            //     });
            // }
            // catch (Exception ex)
            // {
            //     throw ex;
            // }
            // return retorno;
            return null;
        }
        public string CarregaUsuarioFromEmail()
        {
            //Modeling db = new Modeling(CREDUSER);
            //string retorno = string.Empty;
            //string sql = "select GOIDGRUP, USIDUSUA,USLANGUE,USNMPRUS,USNMNIUS,USEMAILU,USNMSNUS,USNUMCEL,TUDATECA,PAIDPAIS from TUSUSUARI where USEMAILU='" + USEMAILU + "'";
            //var result = db.Select(sql, 10);
            //try
            //{
            //    retorno = result[1];
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //return retorno;
            return String.Empty;
        }
        public bool AlterarUsuario(string currentUser)
        {
            //bool retorno = false;
            //Modeling db = new Modeling(CREDUSER);
            //string sqlUpd = "UPDATE TUSUSUARI SET USNUMCEL='" + USNUMCEL.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "") + "',USLANGUE='" + USLANGUE + "',PAIDPAIS=" + PAIDPAIS + ",USEMAILU='" + USEMAILU + "', USNMPRUS='" + USNMPRUS + "', USNMNIUS='" + USNMNIUS + "' where USIDUSUA='" + USIDUSUA + "'";
            //db._alteracao = sqlUpd;
            //db._userName = currentUser;
            //db._modulo = "Perfil de Usuário";
            //db._resumo = string.Format("Usuário {0} alterado com sucesso", USIDUSUA);
            //db._acao = sqlUpd;
            //if (db.Update(sqlUpd))
            //{
            //    retorno = true;
            //}
            //else
            //{
            //    exception = db.error;
            //    retorno = false;
            //}
            //return retorno;
            return false;
        }
        public bool InserirUsuario(string currentUser)
        {
            //bool retorno = false;
            //Modeling db = new Modeling(CREDUSER);
            //USIDUSUA = USNMPRUS[0] + USNMSNUS;
            //bool existe = Convert.ToInt32(db.Select("select count(*) from TUSUSUARI where USIDUSUA='" + USIDUSUA + "'", 1)[0]) > 0;
            //if (existe)
            //{
            //    USIDUSUA = USNMPRUS + USNMSNUS[0];
            //    existe = Convert.ToInt32(db.Select("select count(*) from TUSUSUARI where USIDUSUA='" + USIDUSUA + "'", 1)[0]) > 0;
            //    if (existe)
            //    {
            //        USIDUSUA = USNMPRUS + USNMSNUS;
            //        existe = Convert.ToInt32(db.Select("select count(*) from TUSUSUARI where USIDUSUA='" + USIDUSUA + "'", 1)[0]) > 0;
            //        if (existe)
            //        {
            //            USIDUSUA = USEMAILU;
            //        }
            //    }
            //}
            //
            //USNUMCEL = USNUMCEL.Replace("(", "").Replace(")", "").Replace("-", "");
            //string sql = "INSERT INTO TUSUSUARI (GOIDGRUP, USLANGUE, USNMPRUS, USEMAILU, USNMSNUS, USNUMCEL, USIDUSUA, TVIDESTR,TUDATECA,USTPIDTP,USFLCONC,USCDSEUS) " +
            //            "VALUES(@GOIDGRUP, '@USLANGUE', '@USNMPRUS', '@USEMAILU', '@USNMSNUS', '@USNUMCEL', '@USIDUSUA', 1, CONVERT(DATE, GETDATE()), 1, 0,'@USCDSEUS')";
            //string USCDSEUS = db.Select("SELECT dbo.nesta_fn_Criptografa ('12345678a!')", 1)[0];
            //sql = sql.Replace("@GOIDGRUP", GOIDGRUP.ToString());
            //sql = sql.Replace("@USLANGUE", USLANGUE);
            //sql = sql.Replace("@USNMPRUS", USNMPRUS);
            //sql = sql.Replace("@USEMAILU", USEMAILU);
            //sql = sql.Replace("@USNMSNUS", USNMSNUS);
            //sql = sql.Replace("@USNUMCEL", USNUMCEL);
            //sql = sql.Replace("@USCDSEUS", USCDSEUS);
            //sql = sql.Replace("@USIDUSUA", USIDUSUA);
            //db._alteracao = sql;
            //db._userName = currentUser;
            //db._modulo = "Perfil de Usuário";
            //db._resumo = string.Format("Usuário {0} criado com sucesso", USIDUSUA);
            //db._acao = sql;
            //if (db.Insert(sql))
            //{
            //    sql = "INSERT INTO UTUTISEN (USIDUSUA ,USCDSEUS ,UTDTCASE ,UTHOCASE ,USFLFLAG ,UTDTINIC ,UTIDUTSE) " +
            //            "VALUES ('@USIDUSUA' ,'@USCDSEUS' ,convert(date,dateadd(month,12,getDate())) ,'00:00:00' ,1 ,convert(date,getDate()) ,1)";
            //    sql = sql.Replace("@USIDUSUA", USIDUSUA);
            //    sql = sql.Replace("@USCDSEUS", USCDSEUS);
            //    if (db.Insert(sql))
            //    {
            //        retorno = true;
            //    }
            //    else
            //    {
            //        exception = db.error;
            //        retorno = false;
            //    }
            //}
            //else
            //{
            //    exception = db.error;
            //    retorno = false;
            //}
            //return retorno;
            return false;
        }
        public bool addFoto(string currentUser, string base64Image)
        {
            //  bool retorno = false;
            //  Modeling db = new Modeling(CREDUSER);
            //  string sql = "update TUSUSUARI set USIMGB64='data:image/png;base64,@USIMGB64' where USIDUSUA='@USIDUSUA'";
            //  string USCDSEUS = db.Select("SELECT dbo.nesta_fn_Criptografa ('12345678a!')", 1)[0];
            //  sql = sql.Replace("@USIMGB64", base64Image);
            //  sql = sql.Replace("@USIDUSUA", currentUser);
            //  db._alteracao = sql;
            //  db._userName = currentUser;
            //  db._modulo = "Perfil de Usuário";
            //  db._resumo = string.Format("Foto adicionada ao usuário {0} com sucesso", USIDUSUA);
            //  db._acao = sql;
            //  if (db.Insert(sql))
            //  {
            //      retorno = true;
            //  }
            //  else
            //  {
            //      exception = db.error;
            //      retorno = false;
            //  }
            //  return retorno;
            return false;
        }
        public bool DesativarUsuario(string currentUser)
        {
            bool retorno = false;
          // Modeling db = new Modeling(CREDUSER);
          // string sqlUpdate = "UPDATE TUSUSUARI SET USTPIDTP=0  WHERE USIDUSUA = '@USIDUSUA'";
          // string sqlUpdate2 = "UPDATE UTUTISEN SET USFLFLAG=0  WHERE USIDUSUA = '@USIDUSUA'";
          // sqlUpdate = sqlUpdate.Replace("@USIDUSUA", USIDUSUA);
          // sqlUpdate2 = sqlUpdate2.Replace("@USIDUSUA", USIDUSUA);
          // db._alteracao = sqlUpdate;
          // db._userName = currentUser;
          // db._modulo = "Perfil de Usuário";
          // db._resumo = string.Format("Usuário {0} desativado com sucesso", USIDUSUA);
          // db._acao = sqlUpdate;
          // if (db.Update(sqlUpdate))
          // {
          //     if (db.Update(sqlUpdate2))
          //     {
          //         retorno = true;
          //     }
          //     else
          //     {
          //         exception = db.error;
          //         retorno = false;
          //     }
          // }
          // else
          // {
          //     exception = db.error;
          //     retorno = false;
          // }
            return retorno;
        }
        public bool ReativarUsuario(string currentUser)
        {
            bool retorno = false;
           // Modeling db = new Modeling(CREDUSER);
           // string sqlUpdate = "UPDATE TUSUSUARI SET USTPIDTP=1  WHERE USIDUSUA = '@USIDUSUA'";
           // string sqlUpdate2 = "UPDATE UTUTISEN SET USFLFLAG=1  WHERE USIDUSUA = '@USIDUSUA'";
           // sqlUpdate = sqlUpdate.Replace("@USIDUSUA", USIDUSUA);
           // sqlUpdate2 = sqlUpdate2.Replace("@USIDUSUA", USIDUSUA);
           // db._alteracao = sqlUpdate;
           // db._userName = currentUser;
           // db._modulo = "Perfil de Usuário";
           // db._resumo = string.Format("Usuário {0} reativado com sucesso", USIDUSUA);
           // db._acao = sqlUpdate;
           // if (db.Update(sqlUpdate))
           // {
           //     if (db.Update(sqlUpdate2))
           //     {
           //         retorno = true;
           //     }
           //     else
           //     {
           //         exception = db.error;
           //         retorno = false;
           //     }
           // }
           // else
           // {
           //     exception = db.error;
           //     retorno = false;
           // }
            return retorno;
        }
        public bool MarcarLido(string currentUser, string WFIDCHAT)
        {

            // Modeling db = new Modeling(CREDUSER);
            //
            // string sqlUpd = "update WFWFCHAT set WFDTDATA=GetDate() WHERE WFIDCHAT=" + WFIDCHAT + "";
            // db._alteracao = sqlUpd;
            // db._userName = currentUser;
            // db._modulo = "Perfil de Usuário";
            // db._resumo = string.Format("Notificação {0} marcada como lida", WFIDCHAT);
            // db._acao = sqlUpd;
            // if (db.Update(sqlUpd))
            // {
            //     return true;
            // }
            // else
            // {
            //     exception = db.error;
            //     return false;
            // }

            return false;
        }
     //  public List<Notificacoes> ListarNotificaoesRecebidos()
     //  {
     //      Modeling db = new Modeling(CREDUSER);
     //      List<Notificacoes> metodos = new List<Notificacoes>();
     //      string sqlSelect = "select WFIDCHAT,convert(datetime,WFDTCHAT) as WFDTCHAT,W.USIDUSUA1,WFBBCHAT,convert(datetime,WFDTDATA) as WFDTDATA  " +
     //                          "from WFWFCHAT W " +
     //                          "INNER JOIN TUSUSUARI T on T.USIDUSUA = W.USIDUSUA1 " +
     //                          "WHERE USIDUSUA2 = '" + USIDUSUA + "' " +
     //                          "order by 2 desc";
     //      DataTable dt = db.Select(sqlSelect);
     //      foreach (DataRow row in dt.Rows)
     //      {
     //          metodos.Add(new Notificacoes()
     //          {
     //              WFIDCHAT = string.IsNullOrEmpty(row["WFIDCHAT"].ToString()) ? 0 : Convert.ToInt32(row["WFIDCHAT"].ToString()),
     //              WFDTCHAT = Convert.ToDateTime(row["WFDTCHAT"].ToString()),
     //              USIDUSUA1 = row["USIDUSUA1"].ToString(),
     //              WFBBCHAT = row["WFBBCHAT"].ToString(),
     //              WFDTDATA = string.IsNullOrEmpty(row["WFDTDATA"].ToString()) ? (DateTime?)null : Convert.ToDateTime(row["WFDTDATA"].ToString())
     //          });
     //      }
     //      return metodos;
     //  }
     //  public List<Notificacoes> ListarNotificaoesEnviados()
     //  {
     //      Modeling db = new Modeling(CREDUSER);
     //      List<Notificacoes> metodos = new List<Notificacoes>();
     //      string sqlSelect = "select WFIDCHAT,convert(datetime,WFDTCHAT) as WFDTCHAT,W.USIDUSUA2,WFBBCHAT,convert(datetime,WFDTDATA) as WFDTDATA  " +
     //                          "from WFWFCHAT W " +
     //                          "INNER JOIN TUSUSUARI T on T.USIDUSUA = W.USIDUSUA2 " +
     //                          "WHERE USIDUSUA1 = '" + USIDUSUA + "' " +
     //                          "order by 2 desc";
     //      DataTable dt = db.Select(sqlSelect);
     //      foreach (DataRow row in dt.Rows)
     //      {
     //          metodos.Add(new Notificacoes()
     //          {
     //              WFIDCHAT = string.IsNullOrEmpty(row["WFIDCHAT"].ToString()) ? 0 : Convert.ToInt32(row["WFIDCHAT"].ToString()),
     //              WFDTCHAT = Convert.ToDateTime(row["WFDTCHAT"].ToString()),
     //              USIDUSUA2 = row["USIDUSUA2"].ToString(),
     //              WFBBCHAT = row["WFBBCHAT"].ToString(),
     //              WFDTDATA = string.IsNullOrEmpty(row["WFDTDATA"].ToString()) ? (DateTime?)null : Convert.ToDateTime(row["WFDTDATA"].ToString())
     //          });
     //      }
     //      return metodos;
     //  }
     //  public List<LogSys> ListarLogs(string currentUser)
     //  {
     //      List<LogSys> list = new List<LogSys>();
     //      Modeling db = new Modeling(CREDUSER);
     //      string sqlSelect;
     //      bool admin = Convert.ToInt32(db.Select("select GOIDGRUP from TUSUSUARI where USIDUSUA='" + currentUser + "'", 1)[0]) == 9;
     //      if (admin)
     //      {
     //          sqlSelect = "SELECT * FROM LOGUSSYS WHERE USIDUSUA != '' order by LOGDTSYS desc";
     //      }
     //      else
     //      {
     //          sqlSelect = "SELECT * FROM LOGUSSYS where USIDUSUA='" + currentUser + "' order by LOGDTSYS desc";
     //      }
     //      DataTable dt = db.Select(sqlSelect);
     //      foreach (DataRow row in dt.Rows)
     //      {
     //          list.Add(new LogSys()
     //          {
     //              LOGIDSYS = Convert.ToInt32(row["LOGIDSYS"].ToString()),
     //              LOGTLSYS = row["LOGTLSYS"].ToString(),
     //              LOGTXSYS = row["LOGTXSYS"].ToString(),
     //              LOGDTSYS = Convert.ToDateTime(row["LOGDTSYS"].ToString()),
     //              USIDUSUA = row["USIDUSUA"].ToString(),
     //              LOGACSYS = row["LOGACSYS"].ToString(),
     //              LOGRESUM = row["LOGRESUM"].ToString()
     //          });
     //      }
     //      return list;
     //  }

    }
}
