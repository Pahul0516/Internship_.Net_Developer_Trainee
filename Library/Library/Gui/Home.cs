using Library.Utils;
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
    public partial class Home : Form, IObserver
    {
        Controller _controller;
        User _user;
        public Home(Controller controller, User user)
        {
            _controller = controller;
            _user = user;
            InitializeComponent();

        }

        private void Home_Load(object sender, EventArgs e)
        {
            helloLabel.Text = "Hello, " + _user.Name;

            setup_books();
            setup_borrowedBooks();

            load_books();
            load_BorrowedPbooks();

        }

        private void setup_books()
        {
            availableBooksTableView.ReadOnly = true;
            availableBooksTableView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            availableBooksTableView.MultiSelect = false;
            availableBooksTableView.AllowUserToAddRows = false;
            availableBooksTableView.AllowUserToDeleteRows = false;
            availableBooksTableView.AllowUserToResizeRows = false;
        }

        private void setup_borrowedBooks()
        {
            borrowedBooksTableView.ReadOnly = true;
            borrowedBooksTableView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            borrowedBooksTableView.MultiSelect = false;
            borrowedBooksTableView.AllowUserToAddRows = false;
            borrowedBooksTableView.AllowUserToDeleteRows = false;
            borrowedBooksTableView.AllowUserToResizeRows = false;
        }

        private void load_books()
        {
            List<Book> books = _controller.GetAllBooks();
            availableBooksTableView.DataSource = books;
            availableBooksTableView.Columns["Id"].Visible = false;
        }

        private void load_BorrowedPbooks()
        {
            List<DTOBook> books = _controller.GetAllBorrowedBooks(_user);
            borrowedBooksTableView.DataSource = books;
            borrowedBooksTableView.Columns["Id"].Visible = false;
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (availableBooksTableView.SelectedRows.Count > 0)
            {
                var selectedRow = availableBooksTableView.SelectedRows[0];
                Book book = (Book)selectedRow.DataBoundItem;
                try
                {
                    _controller.BorrowBook(_user, book);
                    _controller.NotifyObservers();
                    MessageBox.Show("Book borrowed successfully.");
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("No available copies of the book to borrow.");
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (availableBooksTableView.SelectedRows.Count > 0)
            {
                var selectedRow = borrowedBooksTableView.SelectedRows[0];
                DTOBook dTOBook = (DTOBook)selectedRow.DataBoundItem;
                _controller.removeBorrowBook(_user, dTOBook);
            }
            _controller.NotifyObservers();
            MessageBox.Show("Book returned successfully.");

        }

        public void UpdateObserver()
        {
            load_books();
            load_BorrowedPbooks();
        }

        public Book WhatBook()
        {
            if (availableBooksTableView.SelectedRows.Count > 0)
            {
                var selectedRow = availableBooksTableView.SelectedRows[0];
                Book book = (Book)selectedRow.DataBoundItem;
                return book;
            }
            return null;
        }

        private void availableBooksTableView_SelectionChanged(object sender, EventArgs e)
        {
            if (availableBooksTableView.SelectedRows.Count > 0)
            {
                var selectedRow = availableBooksTableView.SelectedRows[0];
                Book book = (Book)selectedRow.DataBoundItem;
                labelBorrowers.Text = _controller.HowManyBooksAreSelected(book).ToString() + " users are looking to borrow this book";
            }
        }
    }
}
