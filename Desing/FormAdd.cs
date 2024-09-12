using Business;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desing
{
    public partial class FormAdd : Form
    {
        private Article article = null;
        public FormAdd()
        {
            InitializeComponent();
        }

        public FormAdd(Article article)
        {
            InitializeComponent();
            this.article = article;
        }

        private void FormAdd_Load(object sender, EventArgs e)
        {
            BrandBusiness brandBusiness = new BrandBusiness();
            CategoryBusiness categoryBusiness = new CategoryBusiness();
            try
            {
                comboboxBrand.DataSource = brandBusiness.Brands();
                comboboxCategory.DataSource = categoryBusiness.Categories();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Logica para agregar articulos
        private void btnAcept_Click(object sender, EventArgs e)
        {
            ArticleBusiness articleBusiness = new ArticleBusiness();
            try
            {
                //Condicion para acceder al btn agregar
                if (article == null)
                    article = new Article();

                    article.codArticle = txtboxCode.Text;
                    article.Name = txtboxName.Text;
                    article.Description = txtboxDescription.Text;
                    article.Image = txtboxImage.Text;
                    article.Brand = (Brand)comboboxBrand.SelectedItem;
                    article.Categories = (Categories)comboboxCategory.SelectedItem;
                    article.Price = int.Parse(txtboxPrice.Text);
                    
                    if(article.Id != 0)
                    {
                        MessageBox.Show("Modificado exitosamente");
                    }
                    else
                    {
                        articleBusiness.AddArticle(article);
                        MessageBox.Show("Agregado exitosamente");
                    }
                
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Close();
            }
        }
        //Duplicacion del metodo load para previsualizar imagen antes de añadir el articulo
        public void loadImage(string image)
        {
            try
            {
                pboxArticle.Load(image);
            }
            catch (Exception)
            {
                pboxArticle.Load("https://archive.org/download/placeholder-image/placeholder-image.jpg");
            }
        }
        //Evento para previsualizar imagen
        private void txtboxImage_Leave(object sender, EventArgs e)
        {
            loadImage(txtboxImage.Text);
        }
    }
}
