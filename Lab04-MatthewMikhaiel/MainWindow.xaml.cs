using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab04_MatthewMikhaiel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> list = new List<string>();
        List<CustomerContainer>CustomerList = new List<CustomerContainer>();
        public List<Customer> CustoList { get; set; }
        public MainWindow()
        {
            InitializeComponent();
           


        }

        private void btn_gen_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CustomerContainer())
            {
                ////CustomerList = (from c in db.Customers
                ////                select c).ToList<CustomerList>();
                //var CustomerList = from d in db.Customers
                //                   select d;

                //var query = (from c in db.Customers
                //             select c).ToList<Customer>();

                //foreach (var item in query)
                //{
                //    //list.Add(item.CustomerId.ToString());
                //    //list.Add(item.Title);
                //    //list.Add(item.FirstName);
                //    //txtbox.Text = $"{item.CustomerId.ToString()}\n {item.FirstName}\n{item.Title} ";

                //    CustomerList.Add(item);

                //}

                CustoList = db.Customers.ToList();

            }


            datagrid_Main.ItemsSource = CustoList;


            //DateTime value = DateTime.Parse(DateTime.Now.ToString("o"));
            //custAdd.ModifiedDate = value;
        }

        private void btn_toAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAdd win2 = new WindowAdd();
            win2.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int inputvalue = Convert.ToInt32( txt_findValue.Text);
            using(var db = new CustomerContainer())
            {
                var findQuery = from c in db.Customers
                                where c.CustomerID == inputvalue
                                select c;

                CustoList = findQuery.ToList();

                DG_find.ItemsSource = CustoList;
            }
        }

        private void btn_Sort_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CustomerContainer())
            {
                var findQuery = from c in db.Customers
                                orderby c.FirstName
                                select c;
                                

                CustoList = findQuery.ToList();

                datagrid_Main.ItemsSource = CustoList;
            }
        }

        private void btn_Sort2_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CustomerContainer())
            {
                var findQuery = from c in db.Customers
                                orderby c.CompanyName
                                select c;


                CustoList = findQuery.ToList();

                datagrid_Main.ItemsSource = CustoList;
            }
        }

        private void btn_getList_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CustomerContainer())
            {
                var findQuery = from c in db.Customers
                                join ca in db.CustomerAddresses on c.CustomerID equals ca.CustomerID
                                join a in db.Addresses on ca.AddressID equals a.AddressID
                                where a.CountryRegion == "CANADA"
                                select c;


                CustoList = findQuery.ToList();

                datagrid_Main.ItemsSource = CustoList;
            }
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            int deleteId = int.Parse(txt_Delete.Text);
            using (var db = new CustomerContainer())
            {
                //var deleteQuery = (from c in db.Customers
                //                  where c.CustomerID == deleteId
                //                  select c).First();


                //db.Customers.Remove(deleteQuery);
                //db.SaveChanges();
                //CustoList = db.Customers.ToList();

                //datagrid_Main.ItemsSource = CustoList;
                var delQuery3 = from a in db.Addresses
                                join ca in db.CustomerAddresses on a.AddressID equals ca.AddressID
                                join c in db.Customers on ca.CustomerID equals c.CustomerID
                                where c.CustomerID == deleteId
                                select a;

                foreach (var de in delQuery3)
                {
                    db.Addresses.Remove(de);

                }
                db.SaveChanges();

                var delQuery2 = from ca in db.CustomerAddresses
                                join c in db.Customers on ca.CustomerID equals c.CustomerID
                                join a in db.Addresses on ca.AddressID equals a.AddressID
                                where c.CustomerID == deleteId
                                select ca;

               
                foreach (var del in delQuery2)
                {
                    db.CustomerAddresses.Remove(del);
                }
                db.SaveChanges();

                var delQuery = from c in db.Customers
                            join ca in db.CustomerAddresses on c.CustomerID equals ca.CustomerID
                            join a in db.Addresses on ca.AddressID equals a.AddressID
                            where c.CustomerID == deleteId
                            select c;

                foreach (var del in delQuery)
                {
                    db.Customers.Remove(del);
                }
                db.SaveChanges();

            

             
            }
        }

        private void btn_toEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowEdit win3 = new WindowEdit();
            win3.Show();
        }
    }
}
