using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BiblioControl
{
    public partial class Form1 : Form
    {
        public LibrarySystem librarySystem;

        public Form1()
        {
            InitializeComponent();
            librarySystem = new LibrarySystem();
        }

        private void registeredButton_Click(object sender, EventArgs e)
        {
            if(nameTextBox.Text != "" && addressTextBox.Text != "" && phoneTextBox.Text != "")
            {
                string pattern = @"^\+380\d{9}$";
                if (!Regex.IsMatch(phoneTextBox.Text, pattern))
                {
                    MessageBox.Show("Phone number must be in the format +380XXXXXXXXX.");
                    return;
                }

                Reader reader = new Reader(nameTextBox.Text, addressTextBox.Text, phoneTextBox.Text);
                librarySystem.Readers.Add(reader);
                string concatReader = string.Concat(reader.Name, " ", reader.PhoneNumber, " ", reader.Address);
                readersListBox.Items.Add(concatReader);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (titleTextBox.Text != "" && authorTextBox.Text != "" && publishYearTextBox.Text != "")
            {
                if (publishYearTextBox.Text.Length < 1 || publishYearTextBox.Text.Length > 4)
                {
                    MessageBox.Show("Publication year must be between 1 and 4 digits.");
                    return;
                }

                // Попытка преобразовать текст в int
                if (!int.TryParse(publishYearTextBox.Text, out int publishYear))
                {
                    // Некорректный ввод
                    MessageBox.Show("Введите корректный год!");
                    return;
                }

                Book book = new Book(titleTextBox.Text, authorTextBox.Text, publishYear);
                librarySystem.Books.Add(book);
                string concatReader = string.Concat(book.Title, " ", book.Author, " ", book.PublicationYear);
                booksListBox.Items.Add(concatReader);
            }
        }
    }
}
