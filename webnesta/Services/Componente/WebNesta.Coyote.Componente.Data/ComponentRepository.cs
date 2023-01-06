using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using WebNesta.Coyote.Componente.Domain;
using WebNesta.Coyote.Core.Data;
using WebNesta.Coyote.Componente.Domain.ViewModel;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using System.Collections;

namespace WebNesta.Coyote.Componente.Data
{
    public class ComponentRepository : IRepository, IComponentRepository<CHCOMPOT, ValidateViewModel, ComponentViewModel>
    {
        private IConfiguration _config;

        private string ConnectionString;
        public ComponentRepository(IConfiguration config)
        {
            _config = config;
            ConnectionString = _config.GetValue<string>("Data:DefaultConnection:ConnectionString");
        }

        public ICollection<CHCOMPOT> GetComponentSearch(string term)
        {
            try
            {
                List<CHCOMPOT> properties = null;
                CHCOMPOT property = null;

                using (var connection = new SqlConnection(this.ConnectionString))
                {
                    var query = @"SELECT
                                    chidcodi, chdsdecr, chdsobsr, cmidcodi,
                                    chflsimp, tiidtipo, crnumcap, lhidprod,
                                    cjdsmodu 
                                FROM  CHCOMPOT WHERE 1=1 ";

                    var idSearch = 0;

                    connection.Open();

                    using (var command = new SqlCommand(query, connection))
                    {


                        if (Int32.TryParse(term, out idSearch))
                        {
                            command.CommandText += "AND chidcodi = @CHIDCODI";
                            command.Parameters.AddWithValue("CHIDCODI", idSearch);
                        }
                        else
                        {
                            command.CommandText += "AND (chdsdecr LIKE @chdsdecr OR chdsobsr LIKE @chdsobsr)";
                            command.Parameters.AddWithValue("@chdsdecr", "%" + term + "%");
                            command.Parameters.AddWithValue("@chdsobsr", "%" + term + "%");
                        }

                        using (SqlDataReader rdr = command.ExecuteReader())
                        {

                            while (rdr.Read())
                            {
                                if (properties == null) { properties = new List<CHCOMPOT>(); }
                                property = new CHCOMPOT();

                                property.chidcodi = !rdr.IsDBNull(0) ? rdr.GetInt32(0) : 0;
                                property.chdsdecr = !rdr.IsDBNull(1) ? rdr.GetString(1) : null;
                                property.chdsobsr = !rdr.IsDBNull(2) ? rdr.GetString(2) : null;
                                property.cmidcodi = !rdr.IsDBNull(3) ? rdr.GetInt64(3) : (Int64?)null;
                                property.chflsimp = !rdr.IsDBNull(4) ? rdr.GetInt64(4) : (Int64?)null;
                                property.tiidtipo = !rdr.IsDBNull(5) ? rdr.GetInt64(5) : (Int64?)null;
                                property.crnumcap = !rdr.IsDBNull(6) ? rdr.GetInt64(6) : (Int64?)null;
                                property.lhidprod = !rdr.IsDBNull(7) ? rdr.GetInt64(7) : (Int64?)null;
                                property.cjdsmodu = !rdr.IsDBNull(8) ? rdr.GetString(8) : null;

                                properties.Add(property);
                            }
                        }
                    }

                    connection.Close();
                }
                return properties;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw;
            }

        }

        public ValidateViewModel InsertComponent(ComponentViewModel model)
        {
            ValidateViewModel validate = null;
            var querySearchLastId = @"SELECT
                                   MAX(chidcodi)
                                FROM  CHCOMPOT";
            var idSearch = 0;

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                using (var command = new SqlCommand(querySearchLastId, connection))
                {
                    connection.Open();
                    /* **********  ID *************** */
                    command.CommandType = CommandType.Text;

                    using (SqlDataReader rdr = command.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            idSearch = !rdr.IsDBNull(0) ? rdr.GetInt32(0) + 1 : 0;
                        }
                    }


                    /* **********  INSERT *************** */
                    command.CommandText = @"
INSERT INTO 
CHCOMPOT(chidcodi, chdsdecr,chdsobsr,cmidcodi, chflsimp) 
VALUES 
(@chidcodi, @chdsdecr, @chdsobsr, @cmidcodi, @chflsimp)";

                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("chidcodi", idSearch);
                    command.Parameters.AddWithValue("chdsdecr", model.Descricao);
                    command.Parameters.AddWithValue("chdsobsr", model.Descricao);
                    command.Parameters.AddWithValue("cmidcodi", model.Classe); //--classe
                    command.Parameters.AddWithValue("chflsimp", model.Modelo); //--modelo

                    int rowsAffected = command.ExecuteNonQuery();
                    validate = new ValidateViewModel(true, "Componente inserido com sucesso.");
                }
            }

            return validate;
        }

        public ValidateViewModel UpdateComponent(ComponentViewModel model)
        {
            ValidateViewModel validate = null;
            var query = @"
UPDATE CHCOMPOT
SET
    chdsdecr = @chdsdecr,
    chdsobsr= @chdsobsr, 
    cmidcodi = @cmidcodi, 
    chflsimp = @chflsimp
WHERE chidcodi = @chidcodi";

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("chidcodi", model.Id);
                    command.Parameters.AddWithValue("chdsdecr", model.Descricao);
                    command.Parameters.AddWithValue("chdsobsr", model.Descricao);
                    command.Parameters.AddWithValue("cmidcodi", model.Classe); //--classe
                    command.Parameters.AddWithValue("chflsimp", model.Modelo); //--modelo

                    int rowsAffected = command.ExecuteNonQuery();
                    validate = new ValidateViewModel(true, "Componente atualizado com sucesso."); ;
                }
            }

            return validate;
        }

        public ICollection<CHCOMPOT> GetAllComponent()
        {

            List<CHCOMPOT> properties = null;
            CHCOMPOT property = null;

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var count =1000;
                var query = @$"SELECT top {count.ToString()}
chidcodi,
chdsdecr,
chdsobsr,
cmidcodi,
chflsimp,
tiidtipo,
crnumcap,
lhidprod,
cjdsmodu FROM CHCOMPOT"; //where chidcodi = @chidcodi
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    // command.Parameters.AddWithValue("CHIDCODI", 12);

                    using (SqlDataReader rdr = command.ExecuteReader())
                    {

                        while (rdr.Read())
                        {
                            if (properties == null) { properties = new List<CHCOMPOT>(); }
                            property = new CHCOMPOT();

                            property.chidcodi = !rdr.IsDBNull(0) ? rdr.GetInt32(0) : 0;
                            property.chdsdecr = !rdr.IsDBNull(1) ? rdr.GetString(1) : null;
                            property.chdsobsr = !rdr.IsDBNull(2) ? rdr.GetString(2) : null;
                            property.cmidcodi = !rdr.IsDBNull(3) ? rdr.GetInt64(3) : (Int64?)null;
                            property.chflsimp = !rdr.IsDBNull(4) ? rdr.GetInt64(4) : (Int64?)null;
                            property.tiidtipo = !rdr.IsDBNull(5) ? rdr.GetInt64(5) : (Int64?)null;
                            property.crnumcap = !rdr.IsDBNull(6) ? rdr.GetInt64(6) : (Int64?)null;
                            property.lhidprod = !rdr.IsDBNull(7) ? rdr.GetInt64(7) : (Int64?)null;
                            property.cjdsmodu = !rdr.IsDBNull(8) ? rdr.GetString(8) : null;

                            properties.Add(property);
                        }
                    }
                }

                connection.Close();
            }
            return properties;

        }

        ICollection<CHCOMPOT> IComponentRepository<CHCOMPOT, ValidateViewModel, ComponentViewModel>.GetComponent()
        {
            throw new NotImplementedException();
        }

        public ValidateViewModel DeleteComponent(int id)
        {
            ValidateViewModel validate = null;
            var query = @"DELETE CHCOMPOT WHERE chidcodi = @chidcodi";

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    command.CommandType = CommandType.Text;

                    command.Parameters.AddWithValue("chidcodi", id);
                    int rowsAffected = command.ExecuteNonQuery();
                    validate = new ValidateViewModel(true, "Componente excluido com sucesso."); ;
                }
            }

            return validate;
        }

        public Dictionary<decimal, string> GetModelosCombo(string lang)
        {
            try
            {
                var idioma = 0;

                if (!string.IsNullOrEmpty(lang))
                {
                    if (lang.ToLower() == "pt-br")
                    {
                        idioma = 1;
                    }

                    if (lang.ToLower() == "en-us")
                    {
                        idioma = 2;
                    }

                    if (lang.ToLower() == "es-es")
                    {
                        idioma = 3;
                    }
                }
                else idioma = 1;

                Dictionary<decimal, string> modelos = null;

                using (var connection = new SqlConnection(this.ConnectionString))
                {
                    var query = @"SELECT DISTINCT
CMTPIDCM,	--numeric
CMTPDSCM	--varchar
FROM CMTPCMCL where PAIDPAIS = @PAIDPAIS"; //where chidcodi = @chidcodi
                    connection.Open();

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddWithValue("PAIDPAIS", idioma);

                        using (SqlDataReader rdr = command.ExecuteReader())
                        {

                            while (rdr.Read())
                            {
                                if (modelos == null) { modelos = new Dictionary<decimal, string>(); }


                                var Id = !rdr.IsDBNull(0) ? rdr.GetDecimal(0) : 0;
                                var Descricao = !rdr.IsDBNull(1) ? rdr.GetString(1) : null;

                                modelos.Add(Id, Descricao);
                            }
                        }
                    }

                    connection.Close();
                }
                return modelos;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public Dictionary<decimal, string> GetClasseCombo()
        {
            try
            {


                /*select * from CMCLACOM
    select * from CMTPCMCL*/
                Dictionary<decimal, string> classes = null;

                using (var connection = new SqlConnection(this.ConnectionString))
                {
                    var query = @"SELECT DISTINCT
CMIDCODI,
CMDSCLAN
FROM CMCLACOM"; //where chidcodi = @chidcodi
                    connection.Open();

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.CommandType = CommandType.Text;
                        // command.Parameters.AddWithValue("CHIDCODI", 12);

                        using (SqlDataReader rdr = command.ExecuteReader())
                        {

                            while (rdr.Read())
                            {
                                if (classes == null) { classes = new Dictionary<decimal, string>(); }

                                var Id = !rdr.IsDBNull(0) ? rdr.GetDecimal(0) : 0;
                                var Descricao = !rdr.IsDBNull(1) ? rdr.GetString(1) : null;

                                classes.Add(Id, Descricao);
                            }
                        }
                    }

                    connection.Close();
                }
                return classes;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
