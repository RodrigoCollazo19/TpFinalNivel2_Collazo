using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Domain;
using DataAccess;

namespace Business
{
    public class CategoryBusiness
    {
        public List<Categories> Categories()
        {
            List<Categories> list = new List<Categories>();
            AccessData date = new AccessData();
            try
            {
                date.setQuery("Select Id, Descripcion From CATEGORIAS");
                date.executeReader();

                while (date.Reader.Read())
                {
                    Categories aux = new Categories();
                    aux.Id = (int)date.Reader["Id"];
                    aux.Description = (string)date.Reader["Descripcion"];
                    list.Add(aux);
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                date.closeConnection();
            }
        }
    }
}
