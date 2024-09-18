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
        List<Article> filterList;
        string filterName;
        string filterBrand;
        string filterCategory;
        public FormArticles()
        {
            InitializeComponent();
        }

        private void FormArticles_Load(object sender, EventArgs e)
        {
            cbFilterBrand.Items.Add("");
            cbFilterBrand.Items.Add("Samsung");
            cbFilterBrand.Items.Add("Apple");
            cbFilterBrand.Items.Add("Sony");
            cbFilterBrand.Items.Add("Huawei");
            cbFilterBrand.Items.Add("Motorola");
            cbFilterCategory.Items.Add("");
            cbFilterCategory.Items.Add("Celulares");
            cbFilterCategory.Items.Add("Televisores");
            cbFilterCategory.Items.Add("Media");
            cbFilterCategory.Items.Add("Audio");
            loader();
        }

        private void dgvArticles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticles.CurrentRow != null)
            {
                Article selected = (Article)dgvArticles.CurrentRow.DataBoundItem;
                loadImage(selected.Image);
            }
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
                hideColumns();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        private void hideColumns()
        {
            dgvArticles.Columns["Image"].Visible = false;
            dgvArticles.Columns["Id"].Visible = false;
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            FormAdd formAdd = new FormAdd();
            formAdd.ShowDialog();
            loader();
        }

        //Configuracion btn modificar
        private void btnModify2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvArticles.CurrentRow != null)
                {
                    Article selected;
                    selected = (Article)dgvArticles.CurrentRow.DataBoundItem;

                    FormAdd formModify = new FormAdd(selected);
                    formModify.ShowDialog();
                    loader();
                }
                else
                {
                    MessageBox.Show("Please, select article");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        //Darle inteligencia al boton delete
        private void btnDelete2_Click(object sender, EventArgs e)
        {
            ArticleBusiness articleBusiness = new ArticleBusiness();
            Article selected;
            try
            {
                if (dgvArticles.CurrentRow == null)
                {
                    MessageBox.Show("Please, select article");
                }
                else
                {
                    DialogResult answer = MessageBox.Show("Are you sure to delete this article?", "Removing", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (answer == DialogResult.Yes && !(dgvArticles.CurrentRow.DataBoundItem == null))
                    {
                        selected = (Article)dgvArticles.CurrentRow.DataBoundItem;
                        articleBusiness.DeleteArticle(selected.Id);
                        loader();
                    }
                }
                //"Mensaje modal" para asegurar la eliminacion del articulo
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Esta función unificada se llamará cuando cambie el filtro de texto, marca o categoría.
        private void ApplyFilters()
        {
            // Inicializa la lista con todos los artículos
            filterList = listA;

            // Aplica el filtro de nombre si no está vacío
            if (!string.IsNullOrEmpty(filterName))
            {
                filterList = filterList.FindAll(x => x.Name.ToLower().Contains(filterName.ToLower()));
            }

            // Aplica el filtro de marca si no está vacío
            if (!string.IsNullOrEmpty(filterBrand))
            {
                filterList = filterList.FindAll(x => x.Brand.Description.ToString().Contains(filterBrand));
            }

            // Aplica el filtro de categoría si no está vacío
            if (!string.IsNullOrEmpty(filterCategory))
            {
                filterList = filterList.FindAll(x => x.Categories.Description.ToString().Contains(filterCategory));
            }

            // Actualiza la tabla
            dgvArticles.DataSource = null;
            dgvArticles.DataSource = filterList;
            hideColumns();
        }

        // Evento cuando cambia el texto del filtro de nombre
        public void txtfilterName_TextChanged(object sender, EventArgs e)
        {
            filterName = txtfilterName.Text;
            ApplyFilters();
            lblx1.Visible = false;
            if (txtfilterName.Text == "")
                lblx1.Visible = true;
        }

        // Evento cuando se selecciona una nueva marca
        private void cbFilterBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterBrand = cbFilterBrand.SelectedItem.ToString();
            ApplyFilters();
        }

        // Evento cuando se selecciona una nueva categoría
        private void cbFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterCategory = cbFilterCategory.SelectedItem.ToString();
            ApplyFilters();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
