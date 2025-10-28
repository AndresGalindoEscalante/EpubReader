namespace EpubReader
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.AddBook = new System.Windows.Forms.Button();
            this.booksTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddBook
            // 
            this.AddBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBook.Location = new System.Drawing.Point(12, 28);
            this.AddBook.Name = "AddBook";
            this.AddBook.Size = new System.Drawing.Size(269, 126);
            this.AddBook.TabIndex = 0;
            this.AddBook.Text = "Add books";
            this.AddBook.UseVisualStyleBackColor = true;
            this.AddBook.Click += new System.EventHandler(this.AddBookButton);
            // 
            // booksTablePanel
            // 
            this.booksTablePanel.AutoScroll = true;
            this.booksTablePanel.AutoSize = true;
            this.booksTablePanel.ColumnCount = 4;
            this.booksTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.booksTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.booksTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.booksTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.booksTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.booksTablePanel.Location = new System.Drawing.Point(0, 0);
            this.booksTablePanel.Name = "booksTablePanel";
            this.booksTablePanel.RowCount = 1;
            this.booksTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.booksTablePanel.Size = new System.Drawing.Size(1406, 587);
            this.booksTablePanel.TabIndex = 2;
            this.booksTablePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.BooksTablePanelPaint);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.booksTablePanel);
            this.panel1.Location = new System.Drawing.Point(706, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1406, 587);
            this.panel1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2907, 1157);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.AddBook);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddBook;
        private System.Windows.Forms.TableLayoutPanel booksTablePanel;
        private System.Windows.Forms.Panel panel1;
    }
}

