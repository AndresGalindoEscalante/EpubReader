namespace EpubReader
{
    partial class MainPage
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            AddBook = new Button();
            BookPanel = new Panel();
            BooksBinding = new DataGridView();
            bookControllerBindingSource = new BindingSource(components);
            BookPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BooksBinding).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bookControllerBindingSource).BeginInit();
            SuspendLayout();
            // 
            // AddBook
            // 
            AddBook.Font = new Font("Microsoft Sans Serif", 7.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddBook.Location = new Point(-2, 13);
            AddBook.Margin = new Padding(3, 4, 3, 4);
            AddBook.Name = "AddBook";
            AddBook.Size = new Size(291, 161);
            AddBook.TabIndex = 0;
            AddBook.Text = "Add books";
            AddBook.UseVisualStyleBackColor = true;
            AddBook.Click += AddBookButton;
            // 
            // BookPanel
            // 
            BookPanel.Anchor = AnchorStyles.None;
            BookPanel.AutoScroll = true;
            BookPanel.AutoSize = true;
            BookPanel.BackColor = SystemColors.Control;
            BookPanel.Controls.Add(BooksBinding);
            BookPanel.Location = new Point(875, 13);
            BookPanel.Margin = new Padding(3, 4, 3, 4);
            BookPanel.Name = "BookPanel";
            BookPanel.Size = new Size(3000, 1000);
            BookPanel.TabIndex = 3;
            // 
            // BooksBinding
            // 
            BooksBinding.BackgroundColor = SystemColors.Control;
            BooksBinding.BorderStyle = BorderStyle.None;
            BooksBinding.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            BooksBinding.Dock = DockStyle.Fill;
            BooksBinding.Location = new Point(0, 0);
            BooksBinding.Name = "BooksBinding";
            BooksBinding.RowHeadersWidth = 82;
            dataGridViewCellStyle1.BackColor = Color.White;
            BooksBinding.RowsDefaultCellStyle = dataGridViewCellStyle1;
            BooksBinding.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            BooksBinding.Size = new Size(3000, 1000);
            BooksBinding.TabIndex = 4;
            // 
            // bookControllerBindingSource
            // 
            bookControllerBindingSource.DataSource = typeof(Controller.BookController);
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(3149, 1481);
            Controls.Add(BookPanel);
            Controls.Add(AddBook);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainPage";
            Text = "Form1";
            Load += Form1_Load;
            BookPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)BooksBinding).EndInit();
            ((System.ComponentModel.ISupportInitialize)bookControllerBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddBook;
        private System.Windows.Forms.Panel BookPanel;
        private BindingSource bookControllerBindingSource;
        private DataGridView BooksBinding;
    }
}

