namespace Library.Gui
{
    partial class Home
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
            helloLabel = new Label();
            availableBooksTableView = new DataGridView();
            borrowedBooksTableView = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            btnRemove = new Button();
            btnBorrow = new Button();
            labelBorrowers = new Label();
            ((System.ComponentModel.ISupportInitialize)availableBooksTableView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)borrowedBooksTableView).BeginInit();
            SuspendLayout();
            // 
            // helloLabel
            // 
            helloLabel.AutoSize = true;
            helloLabel.Font = new Font("Segoe UI", 21F);
            helloLabel.Location = new Point(1103, 9);
            helloLabel.Name = "helloLabel";
            helloLabel.Size = new Size(189, 74);
            helloLabel.TabIndex = 0;
            helloLabel.Text = "Hello, ";
            // 
            // availableBooksTableView
            // 
            availableBooksTableView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            availableBooksTableView.Location = new Point(63, 180);
            availableBooksTableView.Name = "availableBooksTableView";
            availableBooksTableView.RowHeadersWidth = 82;
            availableBooksTableView.Size = new Size(977, 519);
            availableBooksTableView.TabIndex = 1;
            availableBooksTableView.SelectionChanged += availableBooksTableView_SelectionChanged;
            // 
            // borrowedBooksTableView
            // 
            borrowedBooksTableView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            borrowedBooksTableView.Location = new Point(1325, 180);
            borrowedBooksTableView.Name = "borrowedBooksTableView";
            borrowedBooksTableView.RowHeadersWidth = 82;
            borrowedBooksTableView.Size = new Size(914, 519);
            borrowedBooksTableView.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(444, 118);
            label2.Name = "label2";
            label2.Size = new Size(78, 32);
            label2.TabIndex = 3;
            label2.Text = "Books";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1740, 130);
            label3.Name = "label3";
            label3.Size = new Size(116, 32);
            label3.TabIndex = 4;
            label3.Text = "Borrowed";
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(1756, 731);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(150, 46);
            btnRemove.TabIndex = 5;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnBorrow
            // 
            btnBorrow.Location = new Point(444, 722);
            btnBorrow.Name = "btnBorrow";
            btnBorrow.Size = new Size(150, 46);
            btnBorrow.TabIndex = 6;
            btnBorrow.Text = "Borrow";
            btnBorrow.UseVisualStyleBackColor = true;
            btnBorrow.Click += btnBorrow_Click;
            // 
            // labelBorrowers
            // 
            labelBorrowers.AutoSize = true;
            labelBorrowers.Location = new Point(958, 835);
            labelBorrowers.Name = "labelBorrowers";
            labelBorrowers.Size = new Size(431, 32);
            labelBorrowers.TabIndex = 7;
            labelBorrowers.Text = "x users are looking to borrow this book";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2300, 973);
            Controls.Add(labelBorrowers);
            Controls.Add(btnBorrow);
            Controls.Add(btnRemove);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(borrowedBooksTableView);
            Controls.Add(availableBooksTableView);
            Controls.Add(helloLabel);
            Name = "Home";
            Text = "Home";
            Load += Home_Load;
            ((System.ComponentModel.ISupportInitialize)availableBooksTableView).EndInit();
            ((System.ComponentModel.ISupportInitialize)borrowedBooksTableView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label helloLabel;
        private DataGridView availableBooksTableView;
        private DataGridView borrowedBooksTableView;
        private Label label2;
        private Label label3;
        private Button btnRemove;
        private Button btnBorrow;
        private Label labelBorrowers;
    }
}