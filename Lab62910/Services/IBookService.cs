using Lab62910.Data;

namespace Lab62910.Services
{
    public interface IBookService
    {
      public  List<Book> GetBooks();
      public  void AddBook(Book book);
      public  void EditBook(Book book);
       public void DeleteBook(int bookId);

        Book GetBookByISBN(string isbn);
        void AddBooks(List<Book> books);
    }
}
