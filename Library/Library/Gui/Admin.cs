using Library.Utils;
using Library.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.Gui
{
    public partial class Admin : Form, IObserver
    {

        Controller _controller;
        public Admin(Controller controller)
        {
            _controller = controller;
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            comboBoxCriteria.Items.AddRange(new[] { "All", "Title", "Author" });
            comboBoxCriteria.SelectedIndex = 0;
            SetPlaceholder(textBoxSearchBar, "Search");
            SetPlaceholder(textBoxName, "Name");
            SetPlaceholder(textBoxAuthor, "Author");

            dataGridViewSearched.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridViewSearched.MultiSelect = false;
            dataGridViewSearched.ReadOnly = false;
        }

        private void textBoxSearchBar_TextChanged(object sender, EventArgs e)
        {
            ApplyBookSearch();
        }

        private void ApplyBookSearch()
        {
            string searchText = textBoxSearchBar.Text.Trim().ToLower();
            string criteria = comboBoxCriteria.SelectedItem.ToString();

            var books = _controller.GetAllBooks();

            var filtered = books
                .Where(b =>
                    criteria == "All" &&
                    (b.Title.ToLower().Contains(searchText) || b.Author.ToLower().Contains(searchText)) ||
                    criteria == "Title" && b.Title.ToLower().Contains(searchText) ||
                    criteria == "Author" && b.Author.ToLower().Contains(searchText)
                )
                .OrderByDescending(b =>
                    criteria == "All" ?
                        (b.Title.ToLower().StartsWith(searchText) || b.Author.ToLower().StartsWith(searchText)) :
                    criteria == "Title" ?
                        b.Title.ToLower().StartsWith(searchText) :
                        b.Author.ToLower().StartsWith(searchText)
                )
                .ToList();

            dataGridViewSearched.DataSource = null;
            dataGridViewSearched.DataSource = filtered;
            dataGridViewSearched.Columns["Id"].Visible = false;
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;

            textBox.GotFocus += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private void dataGridViewSearched_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewSearched.Rows[e.RowIndex];
                Book book = (Book)row.DataBoundItem;
                _controller.modifiedBook(book);
                _controller.NotifyObservers();
            }
        }

        public void UpdateObserver()
        {
            ApplyBookSearch();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            String name = textBoxName.Text;
            String author = textBoxAuthor.Text;
            int quantity = (int)numericUpDownQuantity.Value;
            try
            {
                ValidationContext validator = new ValidationContext(new NameBookValidationStrategy(_controller.getBookRepo()));
                validator.ExecuteValidation(name);
                validator.SetStrategy(new QuantityValidationStrategy());
                validator.ExecuteValidation(quantity.ToString());
                _controller.addBook(name, author, quantity);
                _controller.NotifyObservers();

            }catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewSearched.CurrentCell != null)
            {
                int rowIndex = dataGridViewSearched.CurrentCell.RowIndex;
                DataGridViewRow selectedRow = dataGridViewSearched.Rows[rowIndex];

                int id = Convert.ToInt32(selectedRow.Cells["Id"].Value);
                _controller.DeleteBook(id);
                _controller.NotifyObservers();
            }
            else
            {
                MessageBox.Show("Please select a cell.");
            }
        }

        public Book WhatBook()
        {
            return null;
        }
    }
}