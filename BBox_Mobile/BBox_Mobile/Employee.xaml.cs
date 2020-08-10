using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BBox_Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Employee : ContentPage
    {
        List<string> OrderList = new List<string>();
        List<int> OrderQuantity = new List<int>();
        int Item_Amount=0;
        string Username;
        

        public Employee(string Username2)
        {
            string bn;
            string Item_Stock;
            int x=0;
            ServiceReference1.WebServiceSoapClient help = new ServiceReference1.WebServiceSoapClient(ServiceReference1.WebServiceSoapClient.EndpointConfiguration.WebServiceSoap);
            List<int> ItemSt = new List<int>();
            List<string> ItemList = new List<string>();
            List<string> BranchNames = new List<string>();
            InitializeComponent();
           
            
            Username = Username2;
            foreach (string i in ItemList)
            {
                help.GetItem(i,out bn,out Item_Stock);

                ItemSt.Add(int.Parse(Item_Stock));



            }

            foreach (int i in ItemSt)
            {
                if (i == 0)
                {
                    ItemList.RemoveAt(x);
                    x++; 
                }

            }

           
            Order_Picker.ItemsSource = help.GetItemName();
            Picker_Branch.ItemsSource = help.GetBranchName();

        }

        private void Add_Item_Clicked(object sender, EventArgs e)
        {
            string ItemName;
            int ItemQ;
            float ItemQuant,ItemPr,CurrentTotal;
           
            OrderList.Add(Order_Picker.SelectedItem.ToString());
            OrderQuantity.Add(int.Parse(Order_Quantity.Text.ToString()));
            ItemName = Order_Picker.SelectedItem.ToString();
            ItemQ = int.Parse(Order_Quantity.Text.ToString());
            Item_Amount = Item_Amount + ItemQ;
            ItemPr = float.Parse(Order_Price.Text.ToString());
            ItemQuant = float.Parse(ItemQ.ToString());
            CurrentTotal = float.Parse(Total_Price.Text.ToString());
            CurrentTotal = CurrentTotal + (ItemPr*ItemQuant);
            Order_Editor.Text = Order_Editor.Text + ItemName + " x " + ItemQ.ToString() + Environment.NewLine;
            Total_Price.Text = CurrentTotal.ToString();
            Order_Picker.SelectedIndex = -1;
            Order_Quantity.Text = "";
            Order_Price.Text = "";

          


        }


        private void Reset_Transaction_Clicked(object sender, EventArgs e)
        {
            Order_Picker.SelectedIndex = -1;
            Order_Quantity.Text = "";
            Order_Price.Text = "";
            Order_Editor.Text = "";
            Total_Price.Text = "0.00";
            OrderList.Clear();
           OrderQuantity.Clear();
        }

        private async void GotoStatistics_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TransactionDetails());
        }

        private void CheckOut_Clicked(object sender, EventArgs e)
        {
           
           
            string Itemn;
            string bn;
            string Date, Time;
            int x=0;
            Date = DateTime.Now.ToString("M / d / yyyy");
            Time = DateTime.Now.ToString("hh:mm:ss");
            ServiceReference1.WebServiceSoapClient help = new ServiceReference1.WebServiceSoapClient(ServiceReference1.WebServiceSoapClient.EndpointConfiguration.WebServiceSoap);
            
            int Change;
            Change = int.Parse(Amount_Received.Text) - int.Parse(Total_Price.Text);
            help.InsertReceipt(Date, Time, Item_Amount, int.Parse(Total_Price.Text), Username, Change);
            string FinalAlert = Order_Editor.Text + Environment.NewLine + "Transaction Total: " + Total_Price.Text + Environment.NewLine + "Change:" + Change.ToString() ;
            foreach (string i in OrderList)
            {
               
                help.GetItem(i, out bn, out Itemn);
                help.InsertRecord(OrderQuantity[x], Picker_Branch.SelectedItem.ToString(), Date, Time, i);
                help.UpdateItem(i,  int.Parse(Itemn) - OrderQuantity[x], Picker_Branch.SelectedItem.ToString(), i);
                x++;
            }

            Amount_Received.Text = "";
            OrderQuantity.Clear();
            OrderList.Clear();
            string bn2;
            string Item_Stock;
            int x2 = 0;
            List<int> ItemSt = new List<int>();
            List<string> ItemList = new List<string>();
            List<string> BranchNames = new List<string>();
           
              foreach (string i in ItemList)
            {
                help.GetItem(i, out bn2, out Item_Stock);

                ItemSt.Add(int.Parse(Item_Stock));



            }

            foreach (int i in ItemSt)
            {
                if (i == 0)
                {
                    ItemList.RemoveAt(x2);
                    x2++;
                }

            }
            Order_Picker.ItemsSource = help.GetItemName();
            Picker_Branch.ItemsSource = help.GetBranchName();


            DisplayAlert("Transaction Details", FinalAlert, "Okay");




        }

       
    }
}