using Library.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core
{
    public interface ICustomer
    {
        int CustomerID { get; }
        string Name { get; set; }
        int Age { get; set; }
        IList<IBook> AssignedBooks { get; set; }
    }

    public class Customer : ICustomer
    {
        private int _customerID;
        private string _name;
        private int _age;
        private IList<IBook> _assignedBooks;

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

        public IList<IBook> AssignedBooks
        {
            get
            {
                return _assignedBooks;
            }

            set
            {
                _assignedBooks = value;
            }
        }

        public int CustomerID
        {
            get
            {
                return _customerID;
            }
        }

        public Customer()
        {
            _customerID = -1;
        }

        public Customer(int customerID, string name, int age)
        {
            _customerID = customerID;
            _name = name;
            _age = age;
            _assignedBooks = new List<IBook>();
        }
    }
}