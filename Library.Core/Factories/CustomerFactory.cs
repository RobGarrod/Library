using Library.Core;
using Library.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Factories
{
    public interface ICustomerFactory
    {
        ICustomer CreateCustomer();

        ICustomer CreateCustomer(DataRow dr);
    }

    public class CustomerFactory : ICustomerFactory
    {
        private static ICustomerFactory _current;

        public static ICustomerFactory Current
        {
            get
            {
                if (_current == null)
                    _current = new CustomerFactory();

                return _current;
            }
        }

        public ICustomer CreateCustomer()
        {
            return new Customer();
        }

        public ICustomer CreateCustomer(DataRow customerData)
        {
            ICustomer returnValue = new Customer(Convert.ToInt32(customerData["CustomerID"]), customerData["Name"].ToString(), Convert.ToInt32(customerData["Age"]));

            foreach (DataRow dr in DBDAL.Current.SelectAllCustomerBooks(returnValue.CustomerID).Rows)
            {
                returnValue.AssignedBooks.Add(ModelManager.Current.Books.First(x => x.BookID == Convert.ToInt32(dr["BookID"])));
            }

            return returnValue;
        }
    }
}