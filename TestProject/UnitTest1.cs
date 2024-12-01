using Lab62910.Data;
using Lab62910.Services;
using System.Collections.Generic;
using Xunit;

namespace TestProject
{
    public class UnitTest1
    {
        private readonly BookService _bookService;

        public UnitTest1()
        {
            // Initialize BookService for use in all tests
            _bookService = new BookService();
        }

        [Fact]
        public void AddBook_ShouldAddBookToList()
        {
            // Arrange
            var book = new Book { Title = "Test Book", Author = "Author A", ISBN = "1234567890" };

            // Act
            _bookService.AddBook(book);

            // Assert
            var books = _bookService.GetBooks();
            Assert.Single(books);
            Assert.Equal("Test Book", books[0].Title);
        }

        [Fact]
        public void EditBook_ShouldUpdateBookDetails()
        {
            // Arrange
            var book = new Book { Title = "Old Title", Author = "Author A", ISBN = "1234567890" };
            _bookService.AddBook(book);

            var updatedBook = new Book { Id = 1, Title = "New Title", Author = "Author B", ISBN = "0987654321" };

            // Act
            _bookService.EditBook(updatedBook);

            // Assert
            var editedBook = _bookService.GetBooks()[0];
            Assert.Equal("New Title", editedBook.Title);
            Assert.Equal("Author B", editedBook.Author);
            Assert.Equal("0987654321", editedBook.ISBN);
        }

        [Fact]
        public void DeleteBook_ShouldRemoveBookFromList()
        {
            // Arrange
            var book = new Book { Title = "Test Book", Author = "Author A", ISBN = "1234567890" };
            _bookService.AddBook(book);

            // Act
            _bookService.DeleteBook(1);

            // Assert
            Assert.Empty(_bookService.GetBooks());
        }

        [Fact]
        public void GetBookByISBN_ShouldReturnCorrectBook()
        {
            // Arrange
            var book = new Book { Title = "Test Book", Author = "Author A", ISBN = "1234567890" };
            _bookService.AddBook(book);

            // Act
            var retrievedBook = _bookService.GetBookByISBN("1234567890");

            // Assert
            Assert.NotNull(retrievedBook);
            Assert.Equal("Test Book", retrievedBook.Title);
        }

        [Fact]
        public void AddBooks_ShouldAddNonDuplicateBooks()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book { Title = "Book 1", Author = "Author 1", ISBN = "111" },
                new Book { Title = "Book 2", Author = "Author 2", ISBN = "222" },
                new Book { Title = "Book 1", Author = "Author 1", ISBN = "111" }
            };

            // Act
            _bookService.AddBooks(books);

            // Assert
            Assert.Equal(2, _bookService.GetBooks().Count);
        }
    }
}
