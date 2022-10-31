using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Web;

namespace WebNesta.Coyote.WebApp.Models
{
    public class Login
    {
        public int _notify { get; set; }
        public int _perfil { get; set; }
        public DateTime _clienteDesde { get; set; }
        public int _TVIDESTR { get; set; }
        public string _TVDSESTR { get; set; }
        public string USIDUSUA { get; set; }
        public string PASSCODE { get; set; }
        public int TVIDESTR { get; set; }
        public string TVDSESTR { get; set; }
        public int GOIDGRUP { get; set; }
        public int USSMTPAC { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Account), ErrorMessageResourceName = "col1_linha1_label2_error")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[A-Z])(?=.*[!@#$&*])(?=.*[0-9])(?=.*[a-z]).{8,}$", ErrorMessageResourceType = typeof(Resources.Account), ErrorMessageResourceName = "col1_linha1_label2_error2")]
        public string PASS1 { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Account), ErrorMessageResourceName = "col1_linha1_label3_error")]
        [DataType(DataType.Password)]
        [Compare("PASS1", ErrorMessageResourceType = typeof(Resources.Account), ErrorMessageResourceName = "col1_linha1_label3_error2")]
        public string PASS2 { get; set; }
        public List<Versao> versoes { get; set; }
        public Licencas licencaAtiva { get; set; }
        public DateTime ClienteDesde { get; set; }
        //public void CarregaBase(string str_conn)
        //{            
        //    string sql = "SELECT TVIDESTR, TVDSESTR FROM TVESTRUT WHERE TVIDESTR IN ";
        //    sql += "(SELECT min(B.TVIDESTR) FROM TVESTRUT B, FOFORNEC A ";
        //    sql += "WHERE B.TVIDESTR = A.TVIDESTR ";
        //    sql += "AND A.FOTPIDTP = 6 ";
        //    sql += "AND A.FOCDLICE IS NOT NULL ";
        //    sql += "AND B.TVNVESTR IN(1, 0) ";
        //    sql += "AND(B.TVIDESTR IN(SELECT DISTINCT TVIDESTR FROM TUSUSUARI WHERE USIDUSUA = '" + USIDUSUA + "') or ";
        //    sql += "B.TVIDESTR IN(SELECT TV2.TVCDPAIE FROM TVESTRUT TV2 WHERE TV2.TVIDESTR IN(SELECT DISTINCT TVIDESTR ";
        //    sql += "FROM TUSUSUARI WHERE USIDUSUA = '" + USIDUSUA + "')))) ";
        //    TVDSESTR = DataBase.Consulta(str_conn, sql, 2)[1];
        //    string sql2 = "SELECT TVIDESTR, TVDSESTR,TVIDPAIS FROM TVESTRUT WHERE TVIDESTR IN ";
        //    sql2 += "(SELECT max(B.TVIDESTR) FROM TVESTRUT B, FOFORNEC A ";
        //    sql2 += "WHERE B.TVIDESTR = A.TVIDESTR ";
        //    sql2 += "AND A.FOTPIDTP = 6 ";
        //    sql2 += "AND A.FOCDLICE IS NOT NULL ";
        //    sql2 += "AND B.TVNVESTR IN(1, 0) ";
        //    sql2 += "AND(B.TVIDESTR IN(SELECT DISTINCT TVIDESTR FROM TUSUSUARI WHERE USIDUSUA = '" + USIDUSUA + "') or ";
        //    sql2 += "B.TVIDESTR IN(SELECT TV2.TVCDPAIE FROM TVESTRUT TV2 WHERE TV2.TVIDESTR IN(SELECT DISTINCT TVIDESTR ";
        //    sql2 += "FROM TUSUSUARI WHERE USIDUSUA = '" + USIDUSUA + "')))) ";
        //    TVIDESTR = Convert.ToInt32(DataBase.Consulta(str_conn, sql2, 3)[0]);
        //    string sql3 = "select min(utdtinic) from UTUTISEN where USIDUSUA = '" + USIDUSUA + "' ";
        //    string dtDesde = DataBase.Consulta(str_conn, sql3, 1)[0];
        //    ClienteDesde = dtDesde == string.Empty ? DateTime.Now : Convert.ToDateTime(dtDesde);
        //    string sql4 = "select GOIDGRUP from TUSUSUARI where USIDUSUA='"+USIDUSUA+"'";
        //    GOIDGRUP = Convert.ToInt32(DataBase.Consulta(str_conn, sql4, 1)[0]);
        //}
    }
    public class Versao
    {
        public DateTime VERDTVER { get; set; }
        public string VERCDVER { get; set; }
        public string VERDSVER { get; set; }
    }
    public class GoogleLoginViewModel
    {
        public string emailaddress { get; set; }
        public string name { get; set; }
        public string givenname { get; set; }
        public string surname { get; set; }
        public string nameidentifier { get; set; }

        internal static GoogleLoginViewModel GetLoginInfo(ClaimsIdentity identity)
        {
            if (identity.Claims.Count() == 0 || identity.Claims.FirstOrDefault
            (x => x.Type == ClaimTypes.Email) == null)
            {
                return null;
            }
            return new GoogleLoginViewModel
            {
                emailaddress = identity.Claims.FirstOrDefault
              (x => x.Type == ClaimTypes.Email).Value,
                name = identity.Claims.FirstOrDefault
              (x => x.Type == ClaimTypes.Email).Value,
                givenname = identity.Claims.FirstOrDefault
              (x => x.Type == ClaimTypes.GivenName).Value,
                surname = identity.Claims.FirstOrDefault
              (x => x.Type == ClaimTypes.Surname).Value,
                nameidentifier = identity.Claims.FirstOrDefault
              (x => x.Type == ClaimTypes.NameIdentifier).Value,
            };
        }
        
    }
    
    public class Licencas
    {
        public string srnumser { get; set; }
        public int tvidestr { get; set; }
        public int sridlogg { get; set; }
        public DateTime srdatser { get; set; }
        public string srhorser { get; set; }
        public int sttipser { get; set; }
        public int srstatus { get; set; }
        public string usidusua { get; set; }
    }

    public class TraducaoLogin
    {
       //public string Login_Label_1 { get { Resource.Login.label_1; } }
      // public string Login_Label_2 Login.label_2
      // public string Tipologia_Field_2 Tipologia.field_2
      // public string Login_Label_4 Login.label_4
      // public string Login_Label_5 Login.label_5
      // public string Login_Label_6 Login.label_6
      // public string Login_Label_Google_1 Login.label_google_1
      // public string Login_Label_google_2 Login.label_google_2
      // public string Login_Label_google_3 Login.label_google_3
      // public string Login_Label_google_4 Login.label_google_4
      // public string Login_Label_7 Login.label_7
    }
}
