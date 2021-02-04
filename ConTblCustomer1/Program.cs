using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConTblCustomer1
{
    class TableCustomer
    {
        public int Cid { get; set; }
        public string CName { get; set; }
        public DateTime DOB { get; set; }
        public string City { get; set; }
		public void ShowDetails()
		{
			SqlConnection cn = null;
			SqlCommand cm = null;
			SqlDataReader dr = null;
			List<TableCustomer> list;
			try
			{
				list = new List<TableCustomer>();
				using (cn = new SqlConnection(ConfigurationManager.ConnectionStrings[1].ToString()))
				{
					using (cm = new SqlCommand("Select * from tblCustomer1", cn))
					{
						cn.Open();
						using (dr = cm.ExecuteReader(CommandBehavior.CloseConnection))
						{
							while (dr.Read())
							{
								list.Add(new TableCustomer
								{
									Cid = dr.GetFieldValue<int>(dr.GetOrdinal("Cid")),
									CName = dr.GetFieldValue<string>(dr.GetOrdinal("CName")),
									DOB = dr.GetFieldValue<DateTime>(dr.GetOrdinal("DOB")),
									City = dr.GetFieldValue<string>(dr.GetOrdinal("City"))
								});
							}
						}
					}
				}
				var a = list.GetEnumerator();
				while (a.MoveNext())
				{
					
					Console.WriteLine($"{a.Current.Cid}\t{a.Current.CName}\t\t {a.Current.DOB}\t\t\t {a.Current.City}\t");

				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
    class Program
    {
        static void Main(string[] args)
        {
			TableCustomer t = new TableCustomer();
			t.ShowDetails();
            Console.ReadLine();
        }
    }
}
