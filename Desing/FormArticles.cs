using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using DataAccess;
using Domain;

namespace Desing
{
    public partial class FormArticles : Form
    {
        List<Article> listA;
        public FormArticles()
        {
            InitializeComponent();
        }

        private void btnModify2_Click(object sender, EventArgs e)
        {

        }

        private void FormArticles_Load(object sender, EventArgs e)
        {
            loader();
        }

        private void dgvArticles_SelectionChanged(object sender, EventArgs e)
        {
            Article selected = (Article)dgvArticles.CurrentRow.DataBoundItem;
            loadImage(selected.Image);
        }
        
        
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
        private void loader()
        {
            ArticleBusiness articleBusiness = new ArticleBusiness();
            try
            {
                listA = articleBusiness.listArticles();
                dgvArticles.DataSource = listA;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            FormAdd formAdd = new FormAdd();
            formAdd.ShowDialog();
            //Agregar loader para actualizar en el DGV
            loader();
        }
    }
}
