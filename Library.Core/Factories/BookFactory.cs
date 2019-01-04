using Library.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Factories
{
    public interface IBookFactory
    {
        IBook CreateBook();

        IBook CreateBook(DataRow dr);
    }

    public class BookFactory : IBookFactory
    {
        private static IBookFactory _current;

        public static IBookFactory Current
        {
            get
            {
                if (_current == null)
                    _current = new BookFactory();

                return _current;
            }
        }

        public IBook CreateBook()
        {
            return new Book();
        }

        public IBook CreateBook(DataRow dr)
        {
            return new Book(Convert.ToInt32(dr["BookID"]), dr["Title"].ToString(), dr["Author"].ToString());
        }
    }
}