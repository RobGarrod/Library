using Library.Core.Factories;
using Library.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core
{
    public interface IModelManager
    {
        IList<IBook> Books { get; }
        IList<ICustomer> Customers { get; }
    }

    public class ModelManager : IModelManager
    {
        private static ModelManager _current;

        private IList<IBook> _books;
        private IList<ICustomer> _customers;

        public static ModelManager Current
        {
            get
            {
                if (_current == null)
                    _current = new ModelManager();

                return _current;
            }
        }

        public ModelManager()
        {
            _books = new List<IBook>();
            _customers = new List<ICustomer>();

            foreach (DataRow dr in DBDAL.Current.SelectAllBooks().Rows)
            {
                _books.Add(BookFactory.Current.CreateBook(dr));
            }

            foreach (DataRow dr in DBDAL.Current.SelectAllCustomers().Rows)
            {
                _customers.Add(CustomerFactory.Current.CreateCustomer(dr));
            }
        }

        public IList<IBook> Books
        {
            get
            {
                return _books;
            }
        }

        public IList<ICustomer> Customers
        {
            get
            {
                return _customers;
            }
        }
    }
}