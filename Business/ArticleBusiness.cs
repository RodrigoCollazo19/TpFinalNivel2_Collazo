using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.SqlServer.Server;
using DataAccess;
using System.Data.SqlClient;

namespace Business
{
    public class ArticleBusiness
    {
        public List<Article> listArticles()
        {
            List<Article> list = new List<Article>();
            AccessData dates = new AccessData(); 
            try
            {
                dates.setQuery("SELECT Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio FROM ARTICULOS A, CATEGORIAS C, MARCAS M WHERE M.Id = A.IdMarca AND C.Id = A.IdCategoria");
                dates.executeReader();

                while (dates.Reader.Read())
                {
                    Article aux = new Article();
                    aux.codArticle = (string)dates.Reader["Codigo"];
                    aux.Name = (string)dates.Reader["Nombre"];
                    aux.Description = (string)dates.Reader["Descripcion"];
                    aux.Brand = new Brand();
                    aux.Brand.Description = (string)dates.Reader["Marca"];
                    aux.Categories = new Categories();
                    aux.Categories.Description = (string)dates.Reader["Categoria"];
                    aux.Image = (string)dates.Reader["ImagenUrl"];
                    aux.Price = (decimal)dates.Reader["Precio"];
                    list.Add(aux);
                }
            }
            catch (Exception)
            {

                throw;
            }
            dates.closeConnection();
            return list;
        }
    }
}
