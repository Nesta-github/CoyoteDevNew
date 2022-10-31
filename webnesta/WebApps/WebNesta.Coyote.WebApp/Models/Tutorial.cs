using System.Collections.Generic;
using System.Data;
using System.IO;
using System;

namespace WebNesta.Coyote.WebApp.Models
{
    public class Tutorial
    {
        public int TUTOIDUS { get; set; }
        public DateTime TUTODTUS { get; set; }
        public string USIDUSUA { get; set; }
        public int FSIDFUSI { get; set; }
        public int FSIDFUSI2 { get; set; }
        public int TUTOORDE { get; set; }
        public int qtd { get; set; }
        public bool GuiaRapido { get; set; }
        public string TUTODSUS { get; set; }
        //  public IList<TutorialSteps> TUTOSTEP { get; set; }
        // public TutorialSteps tutorialSteps { get; set; }
        public Exception exception { get; set; }
        public List<Tutorial> Listar()
        {
            List<Tutorial> list = new List<Tutorial>();
            //Modeling db = new Modeling();
            //string sqlSelect = "select * from TUTOUSER order by TUTOORDE ";
            //DataTable dt = db.Select(sqlSelect);
            //foreach (DataRow row in dt.Rows)
            //{
            //    sqlSelect = "select t.* from TUTOSTEP T, TUTOUSER U where t.TUTOIDUS=u.TUTOIDUS and u.TUTOIDUS=" + Convert.ToInt32(row["TUTOIDUS"].ToString()) + " order by U.TUTOORDE";
            //    DataTable dt2 = db.Select(sqlSelect);
            //    IList<TutorialSteps> tutorialSteps = new List<TutorialSteps>();
            //    foreach (DataRow row2 in dt2.Rows)
            //    {
            //        tutorialSteps.Add(new TutorialSteps()
            //        {
            //            TUTOIDST = Convert.ToInt32(row2["TUTOIDST"].ToString()),
            //            TUTOIDUS = Convert.ToInt32(row2["TUTOIDUS"].ToString()),
            //            TUTOTTST = row2["TUTOTTST"].ToString(),
            //            TUTODSST = row2["TUTODSST"].ToString(),
            //            TUTOIIMG = row2["TUTOIIMG"].ToString(),
            //            TUTOSTEP = Convert.ToInt32(row2["TUTOSTEP"].ToString()),
            //            TUTOVIDE = row2["TUTOVIDE"].ToString()
            //        });
            //
            //    }
            //    list.Add(new Tutorial()
            //    {
            //        TUTOIDUS = Convert.ToInt32(row["TUTOIDUS"].ToString()),
            //        TUTODTUS = Convert.ToDateTime(row["TUTODTUS"].ToString()),
            //        USIDUSUA = row["USIDUSUA"].ToString(),
            //        FSIDFUSI = Convert.ToInt32(row["FSIDFUSI"].ToString()),
            //        TUTOORDE = Convert.ToInt32(row["TUTOORDE"].ToString()),
            //        TUTODSUS = row["TUTODSUS"].ToString(),
            //        TUTOSTEP = tutorialSteps,
            //        qtd = tutorialSteps.Count()
            //    });
            //}
            return list;
        }
        public void Carregar()
        {
            //  Modeling db = new Modeling();
            //  string sqlSelect = "select * from TUTOUSER where FSIDFUSI=" + FSIDFUSI + " and TUTOORDE=" + TUTOORDE + " ";
            //  DataTable dt = db.Select(sqlSelect);
            //  IList<TutorialSteps> tutorialSteps = new List<TutorialSteps>();
            //  foreach (DataRow row in dt.Rows)
            //  {
            //      sqlSelect = "select t.* from TUTOSTEP T, TUTOUSER U where t.TUTOIDUS=u.TUTOIDUS and u.TUTOIDUS=" + row["TUTOIDUS"].ToString() + "";
            //      DataTable dt2 = db.Select(sqlSelect);
            //
            //      foreach (DataRow row2 in dt2.Rows)
            //      {
            //          tutorialSteps.Add(new TutorialSteps()
            //          {
            //              TUTOIDST = Convert.ToInt32(row2["TUTOIDST"].ToString()),
            //              TUTOIDUS = Convert.ToInt32(row2["TUTOIDUS"].ToString()),
            //              TUTOTTST = row2["TUTOTTST"].ToString(),
            //              TUTODSST = row2["TUTODSST"].ToString(),
            //              TUTOIIMG = row2["TUTOIIMG"].ToString(),
            //              TUTOSTEP = Convert.ToInt32(row2["TUTOSTEP"].ToString()),
            //              TUTOVIDE = row2["TUTOVIDE"].ToString()
            //          });
            //
            //      }
            //      TUTOIDUS = Convert.ToInt32(row["TUTOIDUS"].ToString());
            //      TUTODTUS = Convert.ToDateTime(row["TUTODTUS"].ToString());
            //      USIDUSUA = row["USIDUSUA"].ToString();
            //      FSIDFUSI = Convert.ToInt32(row["FSIDFUSI"].ToString());
            //      TUTOORDE = Convert.ToInt32(row["TUTOORDE"].ToString());
            //      TUTODSUS = row["TUTODSUS"].ToString();
            //  }
            //  for (int i = 0; i < 10; i++)
            //  {
            //      if (tutorialSteps.ElementAtOrDefault(i) == null)
            //      {
            //          tutorialSteps.Add(new TutorialSteps());
            //      }
            //
            //  }
            //  TUTOSTEP = tutorialSteps;
        }
        //   public List<Modulos> _Modulos { get; set; }
        //   public List<Modulos> ListarModulos()
        //   {
        //     Modeling db = new Modeling();
        //     string sqlSelect = "select * from TFSFUNSIS order by fsdsfusi ";
        //     DataTable dt = db.Select(sqlSelect);
        //     List<Modulos> list = new List<Modulos>();
        //     foreach (DataRow row in dt.Rows)
        //     {
        //
        //         list.Add(new Modulos()
        //         {
        //             fsidfusi = Convert.ToInt32(row["fsidfusi"].ToString()),
        //             fsdsfusi = row["fsdsfusi"].ToString()
        //         });
        //     }
        //     return list;
        // }
        public bool Inserir()
        {
            bool retorno = false;
            //  Modeling db = new Modeling();
            //  USIDUSUA = USIDUSUA.ToUpper();
            //  string tela = db.Select("select fsdsfusi from TFSFUNSIS where fsidfusi=" + FSIDFUSI, 1)[0];
            //  TUTOORDE = Convert.ToInt32(db.Select("select CASE WHEN MAX(TUTOORDE) IS NULL THEN 0 ELSE MAX(TUTOORDE)+1 END from TUTOUSER where FSIDFUSI=" + FSIDFUSI, 1)[0]);
            //  string sqlInsert = "INSERT INTO TUTOUSER (USIDUSUA,FSIDFUSI,TUTODSUS,TUTOORDE) VALUES('" + USIDUSUA + "', " + FSIDFUSI + ", '" + TUTODSUS + "', " + TUTOORDE + ")";
            //  db._alteracao = sqlInsert;
            //  db._modulo = "Tutorial";
            //  db._resumo = "Tutorial " + tela + " inserido com sucesso.";
            //  db._acao = "Tutorial Inserido";
            //  if (db.Insert(sqlInsert))
            //  {
            //      TUTOIDUS = Convert.ToInt32(db.Select("select  MAX(TUTOIDUS) from TUTOUSER where FSIDFUSI=" + FSIDFUSI, 1)[0]);
            //      foreach (var item in TUTOSTEP)
            //      {
            //          if (string.IsNullOrEmpty(item.TUTOTTST))
            //              continue;
            //          item.TUTOSTEP = Convert.ToInt32(db.Select("select CASE WHEN MAX(TUTOSTEP) IS NULL THEN 1 ELSE MAX(TUTOSTEP)+1 END from TUTOSTEP where TUTOIDUS=" + TUTOIDUS, 1)[0]);
            //          string sqlInsert2 = "INSERT INTO TUTOSTEP(TUTOIDUS,TUTOTTST,TUTODSST,TUTOIIMG,TUTOVIDE,TUTOSTEP) " +
            //                              "VALUES(" + TUTOIDUS + ", '" + item.TUTOTTST + "', '" + item.TUTODSST + "', '" + item.TUTOIIMG + "', '" + item.TUTOVIDE + "', " + item.TUTOSTEP + ")";
            //          if (db.Insert(sqlInsert2))
            //          {
            //              retorno = true;
            //          }
            //          else
            //          {
            //              exception = db.error;
            //          }
            //      }
            //  }
            //  else
            //  {
            //      exception = db.error;
            //  }
            return retorno;
        }
        public bool Editar()
        {
            bool retorno = false;
            // Modeling db = new Modeling();
            // string tela = db.Select("select fsdsfusi from TFSFUNSIS where fsidfusi=" + FSIDFUSI, 1)[0];
            // if (Excluir())
            // {
            //     USIDUSUA = USIDUSUA.ToUpper();
            //     TUTOORDE = Convert.ToInt32(db.Select("select CASE WHEN MAX(TUTOORDE) IS NULL THEN 0 ELSE MAX(TUTOORDE)+1 END from TUTOUSER where FSIDFUSI=" + FSIDFUSI, 1)[0]);
            //     string sqlInsert = "INSERT INTO TUTOUSER (USIDUSUA,FSIDFUSI,TUTODSUS,TUTOORDE) VALUES('" + USIDUSUA + "', " + FSIDFUSI + ", '" + TUTODSUS + "', " + TUTOORDE + ")";
            //     db._alteracao = sqlInsert;
            //     db._modulo = "Tutorial";
            //     db._resumo = "Tutorial " + tela + " inserido com sucesso.";
            //     db._acao = "Tutorial Inserido";
            //     if (db.Insert(sqlInsert))
            //     {
            //         TUTOIDUS = Convert.ToInt32(db.Select("select  MAX(TUTOIDUS) from TUTOUSER where FSIDFUSI=" + FSIDFUSI, 1)[0]);
            //         foreach (var item in TUTOSTEP)
            //         {
            //             if (string.IsNullOrEmpty(item.TUTOTTST))
            //                 continue;
            //             item.TUTOSTEP = Convert.ToInt32(db.Select("select CASE WHEN MAX(TUTOSTEP) IS NULL THEN 1 ELSE MAX(TUTOSTEP)+1 END from TUTOSTEP where TUTOIDUS=" + TUTOIDUS, 1)[0]);
            //             string sqlInsert2 = "INSERT INTO TUTOSTEP(TUTOIDUS,TUTOTTST,TUTODSST,TUTOIIMG,TUTOVIDE,TUTOSTEP) " +
            //                                 "VALUES(" + TUTOIDUS + ", '" + item.TUTOTTST + "', '" + item.TUTODSST + "', '" + item.TUTOIIMG + "', '" + item.TUTOVIDE + "', " + item.TUTOSTEP + ")";
            //             if (db.Insert(sqlInsert2))
            //             {
            //                 retorno = true;
            //             }
            //             else
            //             {
            //                 exception = db.error;
            //             }
            //         }
            //     }
            //     else
            //     {
            //         exception = db.error;
            //     }
            // }
            return retorno;
        }
        public bool Excluir()
        {
            bool retorno = false;
            // Modeling db = new Modeling();
            // string tela = db.Select("select fsdsfusi from TFSFUNSIS where fsidfusi=" + FSIDFUSI, 1)[0];
            // db._alteracao = "Alteração";
            // db._modulo = "Tutorial";
            // db._resumo = "Tutorial " + tela + " excluído com sucesso.";
            // db._acao = "Tutorial excluído";
            //
            // if (db.Delete("delete from TUTOSTEP where TUTOIDUS in (select TUTOIDUS from TUTOUSER where FSIDFUSI=" + FSIDFUSI + " and TUTOORDE=" + TUTOORDE + " )"))
            // {
            //     if (db.Delete("delete from TUTOUSER where FSIDFUSI=" + FSIDFUSI + " and TUTOORDE=" + TUTOORDE + ""))
            //     {
            //         retorno = true;
            //     }
            //     else
            //     {
            //         exception = db.error;
            //     }
            // }
            // else
            // {
            //     exception = db.error;
            // }
            return retorno;
        }

        //Convert Image to base64
        public string Image2Base64(string imagepath)
        {
            using (System.Drawing.Image image = System.Drawing.Image.FromFile(imagepath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    string base64String;
                    image.Save(ms, image.RawFormat);
                    byte[] imageBytes = ms.ToArray();
                    base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }
    }
}
