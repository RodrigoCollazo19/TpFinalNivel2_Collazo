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
        private object lblBrandError;

        public FormAdd()
        {
            InitializeComponent();
        }

        //Sobrecargar el constructor para recibir un articulo para modificar
        public FormAdd(Article article)
        {
            InitializeComponent();
            this.article = article;
            Text = "Modify";
        }

        private void FormAdd_Load(object sender, EventArgs e)
        {
            BrandBusiness brandBusiness = new BrandBusiness();
            CategoryBusiness categoryBusiness = new CategoryBusiness();
            try
            {
                //Modificacion para poder obtener por parametro los desplegables 
                comboboxBrand.DataSource = brandBusiness.Brands();
                comboboxBrand.ValueMember = "Id";
                comboboxBrand.DisplayMember = "Description";
                comboboxBrand.SelectedIndex = -1;

                comboboxCategory.DataSource = categoryBusiness.Categories();
                comboboxCategory.ValueMember = "Id";
                comboboxCategory.DisplayMember = "Description";
                comboboxCategory.SelectedIndex = -1;

                //Agregar predeterminados para modificar
                if (article != null)
                {
                    txtboxCode.Text = article.codArticle;
                    txtboxName.Text = article.Name;
                    txtboxDescription.Text = article.Description;
                    txtboxImage.Text = article.Image;
                    txtboxPrice.Text = article.Price.ToString();
                    comboboxBrand.SelectedValue = article.Brand.Id;
                    comboboxCategory.SelectedValue = article.Categories.Id;
                    loadImage(article.Image);
                }
            }
            catch (Exception ex)
            {

                throw ex;
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
                if (validateFields() == true)
                {
                    return;
                }
                else
                {
                    if (article == null)
                        article = new Article();

                    article.codArticle = txtboxCode.Text;
                    article.Name = txtboxName.Text;
                    article.Description = txtboxDescription.Text;
                    article.Price = decimal.Parse(txtboxPrice.Text);
                    article.Image = txtboxImage.Text;
                    article.Brand = (Brand)comboboxBrand.SelectedItem;
                    article.Categories = (Categories)comboboxCategory.SelectedItem;


                    //Validacion para agregar o modificar
                    if (article.Id != 0)
                    {
                        articleBusiness.ModifyArticle(article);
                        MessageBox.Show("Successfully modified");
                    }
                    else
                    {
                        articleBusiness.AddArticle(article);
                        MessageBox.Show("Successfully added");
                    }
                }
                //Condicion para acceder al btn agregar
                

               
            }
            catch (Exception)
            {

                throw;
            }
            Close();
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
        //Metodo para validar campos
        private bool validateFields()
        {
            bool hasError = false;

            if (comboboxBrand.SelectedIndex < 0)
            {
                lblBrand.ForeColor = Color.Red;
                lblBradnError.Visible = true;
                hasError = true;  // Indicar que hay un error
            }

            if (comboboxCategory.SelectedIndex < 0)
            {
                lblCategory.ForeColor = Color.Red;
                lblCategoryError.Visible = true;
                hasError = true;  // Indicar que hay un error
            }
            if (txtboxCode.Text == "")
            {
                lblCode.ForeColor = Color.Red;
                lblCodeError.Visible = true;
                hasError = true;
            }
            if (txtboxName.Text == "")
            {
                lblName.ForeColor = Color.Red;
                lblNameError.Visible = true;
                hasError = true;
            }
            if (txtboxDescription.Text == "")
            {
                lblDescription.ForeColor = Color.Red;
                lblDescError.Visible = true;
                hasError= true;
            }
            if (txtboxPrice.Text.ToString() == "")
            {
                lblPrice.ForeColor = Color.Red;
                lblPriceReq.Visible = true;
                
                
                hasError = true;
            }
            return hasError;
        }
        //Metodo para solo numeros
        private void txtboxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 58) && e.KeyChar != 8)
            {
                lblPrice.ForeColor = Color.Red;
                lblPriceError.Visible = true;
                e.Handled = true;
            }
        }

        private void txtboxCode_Leave(object sender, EventArgs e)
        {
            if (lblCode.ForeColor == Color.Red && !(txtboxCode.Text == ""))
            {
                lblCode.ForeColor = System.Drawing.SystemColors.Control;
                lblCodeError.Visible = false;
            }
        }

        private void txtboxName_Leave(object sender, EventArgs e)
        {
            if (lblName.ForeColor == Color.Red && !(txtboxName.Text == ""))
            {
                lblName.ForeColor = System.Drawing.SystemColors.Control;
                lblNameError.Visible = false;
            }
        }

        private void txtboxDescription_Leave(object sender, EventArgs e)
        {
            if (lblDescription.ForeColor == Color.Red && !(txtboxDescription.Text == ""))
            {
                lblDescription.ForeColor = System.Drawing.SystemColors.Control;
                lblDescError.Visible = false; 
            }
        }

        private void comboboxBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblBrand.ForeColor == Color.Red && !(comboboxBrand.SelectedIndex < 0))
            {
                lblBrand.ForeColor = System.Drawing.SystemColors.Control;
                lblBradnError.Visible = false;
            }
        }

        private void comboboxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblCategory.ForeColor == Color.Red && !(comboboxCategory.SelectedIndex < 0))
            {
                lblCategory.ForeColor = System.Drawing.SystemColors.Control;
                lblCategoryError.Visible = false;
            }
        }

        private void txtboxPrice_TextChanged(object sender, EventArgs e)
        {
            if (lblPrice.ForeColor == Color.Red && !(txtboxPrice.Text == ""))
            {
                lblPrice.ForeColor = System.Drawing.SystemColors.Control;
                lblPriceError.Visible = false;
                lblPriceReq.Visible = false;
            }
        }
    }
}
