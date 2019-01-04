using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core
{
    public interface IBook
    {
        int BookID { get; }
        string Title { get; set; }
        string Author { get; set; }
    }

    public class Book : IBook, Savable
    {
        private int _bookID;
        private string _author;
        private string _title;

        public int BookID
        {
            get
            {
                return _bookID;
            }
        }

        public string Author
        {
            get
            {
                return _author;
            }

            set
            {
                _author = value;
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
            }
        }

        public Book()
        {
            _bookID = -1;
        }

        public Book(int bookID, string title, string author)
        {
            _bookID = bookID;
            _title = title;
            _author = author;
        }

        public void Save()
        {
        }
    }
}