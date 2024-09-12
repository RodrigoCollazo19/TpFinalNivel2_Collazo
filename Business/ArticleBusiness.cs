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
                dates.setQuery("SELECT A.Id, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio, A.IdMarca, A.IdCategoria FROM ARTICULOS A, CATEGORIAS C, MARCAS M WHERE M.Id = A.IdMarca AND C.Id = A.IdCategoria");
                dates.executeReader();

                while (dates.Reader.Read())
                {
                    Article aux = new Article();
                    aux.Id = (int)dates.Reader["Id"];
                    aux.codArticle = (string)dates.Reader["Codigo"];
                    aux.Name = (string)dates.Reader["Nombre"];
                    aux.Description = (string)dates.Reader["Descripcion"];
                    aux.Brand = new Brand();
                    aux.Brand.Description = (string)dates.Reader["Marca"];
                    aux.Categories = new Categories();
                    aux.Categories.Description = (string)dates.Reader["Categoria"];
                    //Validacion para valor nullable
                    if (!(dates.Reader["ImagenUrl"] is DBNull))
                        aux.Image = (string)dates.Reader["ImagenUrl"];
                    
                    
                    aux.Price = (decimal)dates.Reader["Precio"];
                    aux.Brand.Id = (int)dates.Reader["IdMarca"];
                    aux.Categories.Id = (int)dates.Reader["IdCategoria"];
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

        public void AddArticle(Article article)
        {
            AccessData dates = new AccessData();
            try
            {
                //Insert por parametro
                dates.setQuery("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)");
                dates.setParameter("@Codigo", article.codArticle);
                dates.setParameter("@Nombre", article.Name);
                dates.setParameter("@Descripcion", article.Description);
                dates.setParameter("@IdMarca", article.Brand.Id);
                dates.setParameter("@IdCategoria", article.Categories.Id);
                dates.setParameter("@ImagenUrl", article.Image);
                dates.setParameter("@Precio", article.Price);
                dates.executeAction();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                dates.closeConnection();
            }
        }
        
        public void ModifyArticle(Article article)
        {
            AccessData dates = new AccessData();
            try
            {
                dates.setQuery("Update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio Where Id = @Id");
                dates.setParameter("@Codigo", article.codArticle);
                dates.setParameter("@Nombre", article.Name);
                dates.setParameter("@Descripcion", article.Description);
                dates.setParameter("@IdMarca", article.Brand.Id);
                dates.setParameter("@IdCategoria", article.Categories.Id);
                dates.setParameter("@ImagenUrl", article.Image);
                dates.setParameter("@Precio", article.Price);
                dates.setParameter("@Id", article.Id);



                dates.executeAction();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                dates.closeConnection();
            }
        }
    }
}
