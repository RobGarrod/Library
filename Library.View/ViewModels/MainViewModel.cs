using Library.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View.ViewModels
{
    public interface IMainViewModel
    {
        IList<ICustomerViewModel> Customers { get; }
        IList<IBookViewModel> Books { get; }
    }

    public interface ICustomerViewModel
    {
        string Name { get; set; }
        int Age { get; set; }
    }

    public interface IBookViewModel
    {
        string Title { get; set; }
        string Author { get; set; }
    }

    public class CustomerViewModel : ICustomerViewModel
    {
        private int _age;
        private string _name;

        public int Age
        {
            get
            {
                return _age;
            }

            set
            {
                _age = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }
    }

    public class BookViewModel : IBookViewModel
    {
        private string _author;
        private string _title;

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
    }

    public class MainViewModel : IMainViewModel
    {
        private IList<ICustomerViewModel> _customers { get; set; }
        private IList<IBookViewModel> _books { get; set; }

        public IList<ICustomerViewModel> Customers
        {
            get
            {
                return _customers;
            }
        }

        public IList<IBookViewModel> Books
        {
            get
            {
                return _books;
            }
        }

        public MainViewModel()
        {
        }

        public MainViewModel(IList<ICustomer> customers, IList<IBook> books)
        {
            _customers = new List<ICustomerViewModel>(customers.Select(x =>
            {
                ICustomerViewModel customerVM = new CustomerViewModel()
                {
                    Age = x.Age,
                    Name = x.Name
                };
                return customerVM;
            }));

            _books = new List<IBookViewModel>(books.Select(x =>
            {
                IBookViewModel bookVM = new BookViewModel()
                {
                    Author = x.Author,
                    Title = x.Title
                };

                return bookVM;
            }));
        }
    }
}