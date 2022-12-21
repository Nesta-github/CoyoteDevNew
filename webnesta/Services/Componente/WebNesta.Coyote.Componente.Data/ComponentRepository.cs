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

       
        public ICollection<CHCOMPOT> GetAllComponent()
        {
            List<CHCOMPOT> properties = null;
            CHCOMPOT property = null;

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var query = @"SELECT
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

        public ICollection<CHCOMPOT> GetComponent()
        {
            List<CHCOMPOT> properties = null;
            CHCOMPOT property = null;

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                var query = @"SELECT chidcodi,chdsdecr,chdsobsr,cmidcodi,chflsimp,tiidtipo,crnumcap,lhidprod,cjdsmodu FROM CHCOMPOT where chidcodi = @chidcodi";
                connection.Open();

                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("CHIDCODI", 12);

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
                            property.chflsimp = !rdr.IsDBNull(4) ? rdr.GetInt32(4) : (Int64?)null;
                            property.tiidtipo = !rdr.IsDBNull(5) ? rdr.GetInt32(5) : (Int64?)null;
                            property.crnumcap = !rdr.IsDBNull(6) ? rdr.GetInt32(6) : (Int64?)null;
                            property.lhidprod = !rdr.IsDBNull(7) ? rdr.GetInt32(7) : (Int64?)null;
                            property.cjdsmodu = !rdr.IsDBNull(8) ? rdr.GetString(8) : null;

                        }
                    }
                }

                connection.Close();
            }

            return properties;
        }

        public Task<ValidateViewModel> InsertComponent(ComponentViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ValidateViewModel> UpdateComponent(ComponentViewModel model)
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

            return null;
        }

        public Task<ICollection<CHCOMPOT>> IComponentRepository<CHCOMPOT, ValidateViewModel, ComponentViewModel>.GetAllComponent()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<CHCOMPOT>> IComponentRepository<CHCOMPOT, ValidateViewModel, ComponentViewModel>.GetComponent()
        {
            throw new NotImplementedException();
        }

        public Task<ValidateViewModel> DeleteComponent(int id)
        {
            throw new NotImplementedException();
        }

    }
}
