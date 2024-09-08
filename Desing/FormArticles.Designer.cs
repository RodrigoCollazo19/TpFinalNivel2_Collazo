namespace Desing
{
    partial class FormArticles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormArticles));
            this.dgvArticles = new System.Windows.Forms.DataGridView();
            this.btnAdd2 = new System.Windows.Forms.Button();
            this.btnDelete2 = new System.Windows.Forms.Button();
            this.btnModify2 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArticles
            // 
            this.dgvArticles.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.dgvArticles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvArticles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticles.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvArticles.Location = new System.Drawing.Point(86, 89);
            this.dgvArticles.Name = "dgvArticles";
            this.dgvArticles.Size = new System.Drawing.Size(620, 270);
            this.dgvArticles.TabIndex = 0;
            // 
            // btnAdd2
            // 
            this.btnAdd2.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd2.Image")));
            this.btnAdd2.Location = new System.Drawing.Point(86, 376);
            this.btnAdd2.Name = "btnAdd2";
            this.btnAdd2.Size = new System.Drawing.Size(37, 33);
            this.btnAdd2.TabIndex = 1;
            this.btnAdd2.UseVisualStyleBackColor = true;
            // 
            // btnDelete2
            // 
            this.btnDelete2.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete2.Image")));
            this.btnDelete2.Location = new System.Drawing.Point(200, 376);
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.Size = new System.Drawing.Size(37, 33);
            this.btnDelete2.TabIndex = 3;
            this.btnDelete2.UseVisualStyleBackColor = true;
            // 
            // btnModify2
            // 
            this.btnModify2.Image = ((System.Drawing.Image)(resources.GetObject("btnModify2.Image")));
            this.btnModify2.Location = new System.Drawing.Point(144, 376);
            this.btnModify2.Name = "btnModify2";
            this.btnModify2.Size = new System.Drawing.Size(37, 33);
            this.btnModify2.TabIndex = 2;
            this.btnModify2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModify2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnModify2.UseVisualStyleBackColor = true;
            this.btnModify2.Click += new System.EventHandler(this.btnModify2_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FormArticles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDelete2);
            this.Controls.Add(this.btnModify2);
            this.Controls.Add(this.btnAdd2);
            this.Controls.Add(this.dgvArticles);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormArticles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Articles";
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticles;
        private System.Windows.Forms.Button btnAdd2;
        private System.Windows.Forms.Button btnModify2;
        private System.Windows.Forms.Button btnDelete2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}