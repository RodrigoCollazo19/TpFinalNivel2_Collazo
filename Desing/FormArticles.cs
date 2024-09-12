﻿using System;
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
                dgvArticles.Columns["Image"].Visible = false;
                dgvArticles.Columns["Id"].Visible = false;
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
            loader();
        }

        //Configuracion btn modificar
        private void btnModify2_Click(object sender, EventArgs e)
        {
            Article selected;
            selected = (Article)dgvArticles.CurrentRow.DataBoundItem;

            FormAdd formModify = new FormAdd(selected);
            formModify.ShowDialog();
            loader();
        }

        //Darle inteligencia al boton delete
        private void btnDelete2_Click(object sender, EventArgs e)
        {
            ArticleBusiness articleBusiness = new ArticleBusiness();
            Article selected;
            try
            {
                //"Mensaje modal" para asegurar la eliminacion del articulo
                DialogResult answer = MessageBox.Show("Are you sure to delete this article?", "Removing", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (answer == DialogResult.Yes)
                {
                    selected = (Article)dgvArticles.CurrentRow.DataBoundItem;
                    articleBusiness.DeleteArticle(selected.Id);
                    loader();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
