using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;


namespace BBox_Mobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public static EndpointAddress EPA = new EndpointAddress("http://localhost:57037/WebService.asmx");
        BasicHttpBinding binding = new BasicHttpBinding();
        public MainPage()
        {
            InitializeComponent();
        
           
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
           
            string Password, LoginUser, LoginPass, Atype;
            LoginUser = EntryUsername.Text;
            LoginPass = EntryPassword.Text;

            ServiceReference1.WebServiceSoapClient help = new ServiceReference1.WebServiceSoapClient(ServiceReference1.WebServiceSoapClient.EndpointConfiguration.WebServiceSoap);


             
            help.GetLogin(LoginUser, out Password, out Atype);

            if (LoginPass == Password)
            {
               
                if(Atype == "Employee")
                await Navigation.PushAsync(new Employee(LoginUser));
                else
                    await Navigation.PushAsync(new TransactionDetails());


            }
            else
                await DisplayAlert("Login", "Incorrect Username or Password", "Okay");









        }
    }
}
