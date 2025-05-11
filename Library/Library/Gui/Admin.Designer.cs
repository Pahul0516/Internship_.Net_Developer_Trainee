namespace Library.Gui
{
    partial class Admin
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
            label1 = new Label();
            label2 = new Label();
            textBoxName = new TextBox();
            textBoxAuthor = new TextBox();
            dataGridViewSearched = new DataGridView();
            btnAddBook = new Button();
            textBoxSearchBar = new TextBox();
            comboBoxCriteria = new ComboBox();
            numericUpDownQuantity = new NumericUpDown();
            btnDeleteBook = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSearched).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21F);
            label1.Location = new Point(275, 45);
            label1.Name = "label1";
            label1.Size = new Size(344, 74);
            label1.TabIndex = 0;
            label1.Text = "Hello, admin";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(374, 556);
            label2.Name = "label2";
            label2.Size = new Size(118, 32);
            label2.TabIndex = 1;
            label2.Text = "Add book";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(338, 605);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(200, 39);
            textBoxName.TabIndex = 2;
            // 
            // textBoxAuthor
            // 
            textBoxAuthor.Location = new Point(338, 670);
            textBoxAuthor.Name = "textBoxAuthor";
            textBoxAuthor.Size = new Size(200, 39);
            textBoxAuthor.TabIndex = 4;
            // 
            // dataGridViewSearched
            // 
            dataGridViewSearched.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSearched.Location = new Point(136, 220);
            dataGridViewSearched.Name = "dataGridViewSearched";
            dataGridViewSearched.RowHeadersWidth = 82;
            dataGridViewSearched.Size = new Size(634, 300);
            dataGridViewSearched.TabIndex = 5;
            dataGridViewSearched.CellValueChanged += dataGridViewSearched_CellValueChanged;
            // 
            // btnAddBook
            // 
            btnAddBook.Location = new Point(356, 798);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(150, 46);
            btnAddBook.TabIndex = 6;
            btnAddBook.Text = "Add";
            btnAddBook.UseVisualStyleBackColor = true;
            btnAddBook.Click += btnAddBook_Click;
            // 
            // textBoxSearchBar
            // 
            textBoxSearchBar.Location = new Point(338, 142);
            textBoxSearchBar.Name = "textBoxSearchBar";
            textBoxSearchBar.Size = new Size(200, 39);
            textBoxSearchBar.TabIndex = 7;
            textBoxSearchBar.TextChanged += textBoxSearchBar_TextChanged;
            // 
            // comboBoxCriteria
            // 
            comboBoxCriteria.FormattingEnabled = true;
            comboBoxCriteria.Location = new Point(136, 141);
            comboBoxCriteria.Name = "comboBoxCriteria";
            comboBoxCriteria.Size = new Size(149, 40);
            comboBoxCriteria.TabIndex = 8;
            // 
            // numericUpDownQuantity
            // 
            numericUpDownQuantity.Location = new Point(338, 740);
            numericUpDownQuantity.Name = "numericUpDownQuantity";
            numericUpDownQuantity.Size = new Size(200, 39);
            numericUpDownQuantity.TabIndex = 9;
            // 
            // btnDeleteBook
            // 
            btnDeleteBook.Location = new Point(603, 141);
            btnDeleteBook.Name = "btnDeleteBook";
            btnDeleteBook.Size = new Size(167, 46);
            btnDeleteBook.TabIndex = 10;
            btnDeleteBook.Text = "Delete Book";
            btnDeleteBook.UseVisualStyleBackColor = true;
            btnDeleteBook.Click += btnDeleteBook_Click;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(895, 878);
            Controls.Add(btnDeleteBook);
            Controls.Add(numericUpDownQuantity);
            Controls.Add(comboBoxCriteria);
            Controls.Add(textBoxSearchBar);
            Controls.Add(btnAddBook);
            Controls.Add(dataGridViewSearched);
            Controls.Add(textBoxAuthor);
            Controls.Add(textBoxName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Admin";
            Text = "Admin";
            Load += Admin_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewSearched).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBoxName;
        private TextBox textBoxAuthor;
        private DataGridView dataGridViewSearched;
        private Button btnAddBook;
        private TextBox textBoxSearchBar;
        private ComboBox comboBoxCriteria;
        private NumericUpDown numericUpDownQuantity;
        private Button btnDeleteBook;
    }
}