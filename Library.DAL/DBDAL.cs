using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public interface IDAL
    {
        DataTable SelectAllCustomers();

        DataTable SelectAllBooks();

        DataTable SelectAllCustomerBooks(int customerID);
    }

    public class DBDAL : IDAL
    {
        private static DBDAL _current;

        public static DBDAL Current
        {
            get
            {
                if (_current == null)
                    _current = new DBDAL();

                return _current;
            }
        }

        private const string CONNECTION_STRING = "Server=UKGARRODR;Database=Library;Trusted_Connection=True";

        public DataTable SelectAllBooks()
        {
            DataTable dtResult = new DataTable();

            using (SqlConnection SqlConn = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand sqlComm = new SqlCommand("Select_AllBooks", SqlConn))
                {
                    sqlComm.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlComm))
                    {
                        sqlAdapter.Fill(dtResult);
                    }
                }
            }

            return dtResult;
        }

        public DataTable SelectAllCustomers()
        {
            DataTable dtResult = new DataTable();

            using (SqlConnection SqlConn = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand sqlComm = new SqlCommand("Select_AllCustomers", SqlConn))
                {
                    sqlComm.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlComm))
                    {
                        sqlAdapter.Fill(dtResult);
                    }
                }
            }

            return dtResult;
        }

        public DataTable SelectAllCustomerBooks(int customerID)
        {
            DataTable dtResult = new DataTable();

            using (SqlConnection SqlConn = new SqlConnection(CONNECTION_STRING))
            {
                using (SqlCommand sqlComm = new SqlCommand("Select_AllCustomerBooks", SqlConn))
                {
                    sqlComm.Parameters.Add("@CustomerID", SqlDbType.Int);
                    sqlComm.Parameters["@CustomerID"].Value = customerID;

                    sqlComm.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlComm))
                    {
                        sqlAdapter.Fill(dtResult);
                    }
                }
            }

            return dtResult;
        }
    }
}