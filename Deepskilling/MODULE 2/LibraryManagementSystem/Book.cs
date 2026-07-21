namespace LibraryManagementSystem
{
    public class Book
    {
        private int _bookId;
        private string _title;
        private string _author;

        public Book(int bookId, string title, string author)
        {
            _bookId = bookId;
            _title = title;
            _author = author;
        }

        public int BookId
        {
            get { return _bookId; }
            set { _bookId = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public string GetBookDetails()
        {
            return $"ID: {_bookId}, Title: {_title}, Author: {_author}";
        }
    }
}