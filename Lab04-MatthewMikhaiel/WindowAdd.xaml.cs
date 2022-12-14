using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
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
    /// Interaction logic for WindowAdd.xaml
    /// </summary>
    public partial class WindowAdd : Window
    {
        public WindowAdd()
        {
            InitializeComponent();
        }

        public void addCustomer() {
             int custId = Convert.ToInt32(txt_ID.Text);
            //CustomerId = Convert.ToInt32(txt_ID.Text)
            using (var db = new CustomerContainer()) {


                    var aCustomer = new Customer {
                    
                    CustomerID = custId,
                    NameStyle = txt_NameStyle.Text,Title = txt_title.Text, 
                    FirstName = txt_FN.Text,MiddleName = txt_MN.Text,LastName = txt_LN.Text , 
                    CompanyName = txt_CN.Text, SalesPerson = txt_sales.Text,EmailAddress = txt_Email.Text,
                    Phone = txt_phoneN.Text,Password = txt_pass.Text};
                
               
                db.Customers.Add(aCustomer);
                db.SaveChanges();
                


                var aAddress = new Address {AddressID = Convert.ToInt32(txt_ID.Text),
                    AddressLine1 = txt_addy1.Text, AddressLine2 = txt_addy2.Text, 
                    City = txt_city.Text,CustomerAddresses = aCustomer.CustomerAddresses,
                    StateProvince = txt_prov.Text,CountryRegion = txt_country.Text.ToUpper(),PostalCode = txt_postCode.Text };

                db.Addresses.Add(aAddress);
                db.SaveChanges();

                DateTime value = DateTime.Now;

                var aCustAddress = new CustomerAddresses
                {
                    AddressType = "Res",
                    AddressID = Convert.ToInt32(txt_ID.Text),
                    CustomerID = Convert.ToInt32(txt_ID.Text),
                    ModifiedDate = value.ToString(),
                    CustomerCustomerId = Convert.ToInt32(txt_ID.Text),
                    AddressAddressId = Convert.ToInt32(txt_ID.Text),

                };
                db.CustomerAddresses.Add(aCustAddress);

                db.SaveChanges();
                

            }
            this.Close();

        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            int custId = Convert.ToInt32(txt_ID.Text);
            //CustomerId = Convert.ToInt32(txt_ID.Text);
            using (var db = new CustomerContainer()) {

              
                    
                    //addCustomer();
                    var aCustomer = new Customer
                    {

                        CustomerID = custId,
                        NameStyle = txt_NameStyle.Text,
                        Title = txt_title.Text,
                        FirstName = txt_FN.Text,
                        MiddleName = txt_MN.Text,
                        LastName = txt_LN.Text,
                        CompanyName = txt_CN.Text,
                        SalesPerson = txt_sales.Text,
                        EmailAddress = txt_Email.Text,
                        Phone = txt_phoneN.Text,
                        Password = txt_pass.Text
                    };


                    db.Customers.Add(aCustomer);
                    db.SaveChanges();



                    var aAddress = new Address
                    {
                        AddressID = Convert.ToInt32(txt_ID.Text),
                        AddressLine1 = txt_addy1.Text,
                        AddressLine2 = txt_addy2.Text,
                        City = txt_city.Text,
                        CustomerAddresses = aCustomer.CustomerAddresses,
                        StateProvince = txt_prov.Text,
                        CountryRegion = txt_country.Text.ToUpper(),
                        PostalCode = txt_postCode.Text
                    };

                    db.Addresses.Add(aAddress);
                    db.SaveChanges();

                    DateTime value = DateTime.Now;

                    var aCustAddress = new CustomerAddresses
                    {
                        AddressType = "Res",
                        AddressID = Convert.ToInt32(txt_ID.Text),
                        CustomerID = Convert.ToInt32(txt_ID.Text),
                        ModifiedDate = value.ToString(),
                        CustomerCustomerId = Convert.ToInt32(txt_ID.Text),
                        AddressAddressId = Convert.ToInt32(txt_ID.Text),



                    };
                    db.CustomerAddresses.Add(aCustAddress);

                    db.SaveChanges();
                MessageBox.Show("Added Customer");
            }

            
            this.Close();
        }
    }
}
