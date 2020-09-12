using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Win32.SafeHandles;

namespace WhatAmIDoing
{
    class Program
    {
        static SqlConnection conn = new SqlConnection
        {
            ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Library; Integrated Security = SSPI;"
        };
        static void Main(string[] args)
        {
            try
            {
                conn.Open();

                string insert = "insert into Books (AuthorId, Title, PRICE, PAGES, ExtraInfo) values ('5', 'The Master and Margarita', '', '310', 'Is good, except for the flashback parts')";
                SqlCommand sqlCommand = new SqlCommand
                {
                    CommandText = insert,
                    Connection = conn
                };
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                Console.WriteLine("Oh shit, here we go again.");
                Console.WriteLine(exp);
            }
            finally
            {
                conn.Close();
            }



        }
    }
}
