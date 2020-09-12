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
            SqlDataReader rdr = null;
            try
            {
                //conn.Open();

                //string insert = "insert into Books (AuthorId, Title, PRICE, PAGES, ExtraInfo) values ('5', 'The Master and Margarita', '', '310', 'Is good, except for the flashback parts')";
                //SqlCommand sqlCommand = new SqlCommand
                //{
                //    CommandText = insert,
                //    Connection = conn
                //};
                //sqlCommand.ExecuteNonQuery();

                conn.Open();
                SqlCommand cmd = new SqlCommand("select *from Authors; select *from Books", conn);
                rdr = cmd.ExecuteReader();

                int line = 0;
                int table = 0;
                do
                {
                    while (rdr.Read())
                    {
                        if (line == 0)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                Console.Write(rdr.GetName(i).ToString() + "\t");
                            }
                            Console.WriteLine();
                        }
                        line++;
                        if(table == 1)
                        {
                             Console.WriteLine(rdr[0] + "\t" + rdr[1] + "\t\t" + rdr[2]);
                        }
                        else Console.WriteLine(rdr[0] + "\t" + rdr[1] + "      \t" + rdr[2]);
                    }
                    Console.WriteLine();
                    line = 0;
                    table += 1;
                }
                while (rdr.NextResult());
            }
            catch (Exception exp)
            {
                Console.WriteLine("Oh shit, here we go again.");
                Console.WriteLine(exp);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
