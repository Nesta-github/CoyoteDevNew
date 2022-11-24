using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using WebNesta.Coyote.Core.Data;
using WebNesta.Coyote.Geral.Domain;

namespace WebNesta.Coyote.Geral.Data
{
    public class ModuloRepository : IModuloRepository<Modulo, Tutorial>
    {
        private string ConnectionString;
        public ModuloRepository()
        {
            ConnectionString = "Data Source=177.153.236.228;Initial Catalog=COYOTE_DEV;User id=COYOTE_DEV;Password=%c0y0t3_DEV#";
        }
        public List<Modulo> ListarTuto(string lang)
        {
            try
            {
                List<Modulo> list = null;
                Modulo modulo = null;
                using (var connection = new SqlConnection(this.ConnectionString))
                {
                    var query = @"select FSIDFUSI,FSPIFUSI,FSDSFUSI,FSVEFUSI,FSLANGFS,FSCAFUSI from TFSFUNSIS where fslangfs=@LANG order by 1";

                    connection.Open();

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("LANG", lang);

                        using (SqlDataReader rdr = command.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                if (list == null)
                                {
                                    list = new List<Modulo>();
                                }
                                modulo = new Modulo();

                                modulo.FSIDFUSI = !rdr.IsDBNull(0) ? rdr.GetInt64(0) : Int64.MinValue;
                                modulo.FSPIFUSI = !rdr.IsDBNull(1) ? rdr.GetInt64(1) : Int64.MinValue;
                                modulo.FSDSFUSI = !rdr.IsDBNull(2) ? rdr.GetString(2) : null;
                                modulo.FSVEFUSI = !rdr.IsDBNull(3) ? rdr.GetString(3) : null;
                                modulo.FSCAFUSI = !rdr.IsDBNull(4) ? rdr.GetString(4) : null;
                                modulo.FSLANGFS = !rdr.IsDBNull(5) ? rdr.GetString(5) : null;

                                list.Add(modulo);
                            }
                        }
                    }
                    connection.Close();
                }

                return list;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw;
            }
        }

        public Tutorial GetTutorial(long moduloId, int TUTOORDE)
        {
            try
            {
                Tutorial tutorial = null;

                using (var connection = new SqlConnection(this.ConnectionString))
                {
                    var queryTutoUser = @"select TUTOIDUS,TUTODTUS,USIDUSUA,FSIDFUSI,TUTODSUS,TUTOORDE 
                FROM TUTOUSER WHERE FSIDFUSI=@moduloId and TUTOORDE=@TUTOORDE";

                    connection.Open();

                    //1 - Obtem os usuários to tutorial
                    using (var command = new SqlCommand(queryTutoUser, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("moduloId", moduloId);
                        command.Parameters.AddWithValue("TUTOORDE", TUTOORDE);

                        using (SqlDataReader rdr = command.ExecuteReader())
                        {
                            if (tutorial == null) tutorial = new Tutorial();

                            while (rdr.Read())
                            {
                                tutorial.TUTOIDUS = !rdr.IsDBNull(0) ? rdr.GetInt32(0) : 0;
                                tutorial.TUTODTUS = !rdr.IsDBNull(1) ? rdr.GetDateTime(1) : DateTime.MinValue;
                                tutorial.USIDUSUA = !rdr.IsDBNull(2) ? rdr.GetString(2) : null;
                                tutorial.FSIDFUSI = !rdr.IsDBNull(0) ? rdr.GetInt32(0) : 0;
                                tutorial.TUTODSUS = !rdr.IsDBNull(4) ? rdr.GetString(4) : null;
                                tutorial.TUTOORDE = !rdr.IsDBNull(0) ? rdr.GetInt32(0) : 0;
                                tutorial.GuiaRapido = tutorial.TUTOORDE == 0;
                            }
                        }
                    }

                    //2 - Obtem os passos do tutorial
                    var queryTutoSteps =
                            @"SELECT
                            T.TUTOIDST, 
                            T.TUTOIDUS,	
                            T.TUTOTTST,	
                            T.TUTODSST,	
                            T.TUTOVIDE,	
                            T.TUTOSTEP, 
                            T.TUTOIIMG	
                        FROM TUTOSTEP T, TUTOUSER U 
                        WHERE T.TUTOIDUS=U.TUTOIDUS and U.TUTOIDUS=@TUTOIDUS";
                    TutorialSteps tutorialStep = null;
                    using (var command = new SqlCommand(queryTutoSteps, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("TUTOIDUS", tutorial.TUTOIDUS);
                      
                        using (SqlDataReader rdr = command.ExecuteReader())
                        {
                            if (tutorial.TUTOSTEP == null) tutorial.TUTOSTEP = new List<TutorialSteps>();

                            while (rdr.Read())
                            {
                                tutorialStep = new TutorialSteps();
                                tutorialStep.TUTOIDST = !rdr.IsDBNull(0) ? rdr.GetInt32(0) : 0;
                                tutorialStep.TUTOIDUS = !rdr.IsDBNull(1) ? rdr.GetInt32(1) : 0;
                                tutorialStep.TUTOTTST = !rdr.IsDBNull(2) ? rdr.GetString(2) : string.Empty;
                                tutorialStep.TUTODSST = !rdr.IsDBNull(3) ? rdr.GetString(3) : string.Empty;
                                tutorialStep.TUTOVIDE = !rdr.IsDBNull(4) ? rdr.GetString(4) : null;
                                tutorialStep.TUTOSTEP = !rdr.IsDBNull(5) ? rdr.GetInt32(5) : (int?)null;
                                tutorialStep.TUTOIIMG = !rdr.IsDBNull(6) ? rdr.GetString(6) : null;
                                tutorial.TUTOSTEP.Add(tutorialStep);
                            }
                            if (tutorial.TUTOSTEP != null && tutorial.TUTOSTEP.Count > 0)
                            {
                                for (int i = 0; i < 10; i++)
                                {
                                    if (tutorial.TUTOSTEP.ElementAtOrDefault(i) == null)
                                    {
                                        tutorial.TUTOSTEP.Add(new TutorialSteps());
                                    }
                                }
                            }
                        }
                    }

                    connection.Close();
                }

                return tutorial;

            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw;
            }
        }
    }
}
