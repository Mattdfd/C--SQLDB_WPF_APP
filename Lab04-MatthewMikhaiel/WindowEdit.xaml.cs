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
using System.Windows.Shapes;

namespace Lab04_MatthewMikhaiel
{
    /// <summary>
    /// Interaction logic for WindowEdit.xaml
    /// </summary>
    public partial class WindowEdit : Window
    {
        List<Customer> CustomerList = new List<Customer>();
        public WindowEdit()
        {
            InitializeComponent();
        }

        private void btn_find_Cust_Click(object sender, RoutedEventArgs e)
        {
            
           int idValue = int.Parse(txt_ide.Text);
            using (var db = new CustomerContainer())
            {
                var query = from c in db.Customers
                            join ca in db.CustomerAddresses on c.CustomerID equals ca.CustomerID
                            join a in db.Addresses on ca.AddressID equals a.AddressID
                            where c.CustomerID == idValue
                            select new
                            {
                                CustomerId = c.CustomerID,
                                NameStyle = c.NameStyle,
                                Title = c.Title,
                                FirstName = c.FirstName,
                                MiddleName = c.MiddleName,
                                LastName = c.LastName,
                                CompanyName = c.CompanyName,
                                SalesPerson = c.SalesPerson,
                                EmailAddress = c.EmailAddress,
                                Phone = c.Phone,
                                Password = c.Password,
                                

                                AddressId = a.AddressID,
                                AddressLine1 = a.AddressLine1,
                                AddressLine2 = a.AddressLine2,
                                City = a.City,
                                StateProvince = a.StateProvince,
                                CountryRegion = a.CountryRegion,
                                PostalCode = a.PostalCode,
                                AddressType = ca.AddressType

                            };

                foreach (var c in query)
                {
                    txt_titlee.Text = c.Title;
                    txt_FNe.Text = c.FirstName;
                    txt_MNe.Text = c.MiddleName;
                    txt_LNe.Text = c.LastName;
                    txt_CNe.Text = c.CompanyName;
                    txt_salese.Text = c.SalesPerson;
                    txt_Emaile.Text = c.EmailAddress;
                    txt_phoneNe.Text = c.Phone;
                    txt_passe.Text = c.Password;
                    txt_NameStylee.Text = c.NameStyle;

                    txt_addy1e.Text = c.AddressLine1;
                    txt_addy2e.Text = c.AddressLine2;
                    txt_citye.Text = c.City;
                    txt_prove.Text = c.City;
                    txt_postCodee.Text = c.PostalCode;
                    txt_addytypeE.Text = c.AddressType;
                }
                

            }
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {

            int idValue = int.Parse(txt_ide.Text);
            
            using (var db = new CustomerContainer())
            {
                var query = from c in db.Customers
                            join ca in db.CustomerAddresses on c.CustomerID equals ca.CustomerID
                            join a in db.Addresses on ca.AddressID equals a.AddressID
                            where c.CustomerID == idValue
                            select c;

                    foreach(var c in query)
                {
                    c.Title = txt_titlee.Text;
                    c.FirstName = txt_FNe.Text;
                    c.MiddleName = txt_MNe.Text;
                    c.LastName = txt_LNe.Text;
                    c.CompanyName= txt_CNe.Text;
                    c.SalesPerson = txt_salese.Text;
                    c.EmailAddress= txt_Emaile.Text;
                    c.Phone = txt_phoneNe.Text;
                    c.Password = txt_passe.Text;

                
                }

                var query2 = from ca in db.CustomerAddresses
                             join c in db.Customers on ca.CustomerID equals c.CustomerID
                            join a in db.Addresses on ca.AddressID equals a.AddressID
                            where c.CustomerID == idValue
                            select ca;

                foreach(var c in query2)
                {
                    c.AddressType = txt_addytypeE.Text;

                }

                var query3 = from a in db.Addresses
                             join ca in db.CustomerAddresses on a.AddressID equals ca.AddressID
                             join c in db.Customers on ca.CustomerID equals c.CustomerID
                             where c.CustomerID == idValue
                             select a;

                foreach (var c in query3)
                {
                    c.AddressLine1 = txt_addy1e.Text;
                    c.AddressLine2 = txt_addy2e.Text;
                    c.City = txt_citye.Text;
                    c.StateProvince = txt_prove.Text;
                    c.PostalCode = txt_postCodee.Text;



                }
                db.SaveChanges();


            }
            this.Close();
        }
    }
}
