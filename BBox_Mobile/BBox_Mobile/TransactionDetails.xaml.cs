using Microcharts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.ChartEntry;


namespace BBox_Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionDetails : ContentPage
    {
        public TransactionDetails()
        {
            

            InitializeComponent();
            ServiceReference1.WebServiceSoapClient help = new ServiceReference1.WebServiceSoapClient(ServiceReference1.WebServiceSoapClient.EndpointConfiguration.WebServiceSoap);
            List<string> Username = new List<string>();
            List<DateTime> Date = new List<DateTime>();
            TimeSpan[] Time = new TimeSpan[1000];
            List<int> AmtItems = new List<int>();
            List<int> TransactionTotal = new List<int>();
            List<int> Change = new List<int>();

            List<string> IName = new List<string>();
            List<string> BName = new List<string>();
            List<int> Amount_Purchased = new List<int>();

            ServiceReference1.ArrayOfDateTime DTE = new ServiceReference1.ArrayOfDateTime();
            ServiceReference1.TimeSpan[] TE = new ServiceReference1.TimeSpan[1000];

            ServiceReference1.ArrayOfInt ATE = new ServiceReference1.ArrayOfInt();
            ServiceReference1.ArrayOfInt TT = new ServiceReference1.ArrayOfInt();
            ServiceReference1.ArrayOfInt CHE = new ServiceReference1.ArrayOfInt();
            ServiceReference1.ArrayOfString USN = new ServiceReference1.ArrayOfString();


            ServiceReference1.ArrayOfString ItName = new ServiceReference1.ArrayOfString();
            ServiceReference1.ArrayOfString BrName = new ServiceReference1.ArrayOfString();
            ServiceReference1.ArrayOfInt AmtP = new ServiceReference1.ArrayOfInt();

            ItName = help.GetGraphRecords(out BrName, out AmtP);


            USN = help.GetReceipt(out DTE, out TE, out ATE, out TT, out CHE);
            Username = USN.ToList();
            Date = DTE.ToList();
            AmtItems = ATE.ToList();
            TransactionTotal = TT.ToList();
            Change = CHE.ToList();
            int x = 0;




            foreach (string i in USN)
            {
                Receipt_Editor.Text = Receipt_Editor.Text + Environment.NewLine + "Username:" + i + Environment.NewLine + "Date:" + Date[x].ToString("MM/dd/yyyy") + Environment.NewLine + "Amount of Items:" + AmtItems[x] + Environment.NewLine + "Transaction Totals:" + TransactionTotal[x] + Environment.NewLine + "Change:" + Change[x] + Environment.NewLine + "==============================";
                x++;
            }

            x = 0;
            Random rnd = new Random();
            IName = ItName.ToList();
            BName = BrName.ToList();
            Amount_Purchased = AmtP.ToList();
            string[] colors = { "#CCCC00", "#660000", "#1cc5ef", "#006600", "#0066FF", " #f5b9ac ", "#330099", "#993399", "#009999", "#FF0000" };
           
            List<Entry> Tr = new List<Entry>();

            foreach (string i in IName)
            {
               Entry asx = new Entry(Amount_Purchased[x])
                {
                    Label = i,
                    ValueLabel = Amount_Purchased[x].ToString(),
                    Color = SkiaSharp.SKColor.Parse(colors[rnd.Next(0, colors.Length)])
                    
               };
               Tr.Add(asx); 
                x++;
            }
            var Chart = new DonutChart() { Entries = Tr, LabelTextSize=30f,BackgroundColor=SkiaSharp.SKColor.Parse(" #add8e6 ") };
            MyChart.Chart = Chart;
            

            x++;
        }

        private void Refresh_Button_Clicked(object sender, EventArgs e)
        {
            ServiceReference1.WebServiceSoapClient help = new ServiceReference1.WebServiceSoapClient(ServiceReference1.WebServiceSoapClient.EndpointConfiguration.WebServiceSoap);
            List<string> Username = new List<string>();
            List<DateTime> Date = new List<DateTime>();
            TimeSpan[] Time = new TimeSpan[1000];
            List<int> AmtItems = new List<int>();
            List<int> TransactionTotal = new List<int>();
            List<int> Change = new List<int>();



            ServiceReference1.ArrayOfDateTime DTE = new ServiceReference1.ArrayOfDateTime();
            ServiceReference1.TimeSpan[] TE = new ServiceReference1.TimeSpan[1000];

            ServiceReference1.ArrayOfInt ATE = new ServiceReference1.ArrayOfInt();
            ServiceReference1.ArrayOfInt TT = new ServiceReference1.ArrayOfInt();
            ServiceReference1.ArrayOfInt CHE = new ServiceReference1.ArrayOfInt();
            ServiceReference1.ArrayOfString USN = new ServiceReference1.ArrayOfString();

            USN = help.GetReceipt(out DTE, out TE, out ATE, out TT, out CHE);
            Username = USN.ToList();
            Date = DTE.ToList();
            AmtItems = ATE.ToList();
            TransactionTotal = TT.ToList();
            Change = CHE.ToList();
            int x = 0;

            foreach (string i in USN)
            {
                Receipt_Editor.Text = Receipt_Editor.Text + Environment.NewLine + "Username:" + i + Environment.NewLine + "Date:" + Date[x].ToString("MM/dd/yyyy") + Environment.NewLine + "Amount of Items:" + AmtItems[x] + Environment.NewLine + "Transaction Totals:" + TransactionTotal[x] + Environment.NewLine + "Change:" + Change[x] + Environment.NewLine + "==============================";
                x++;



            }
        }
    }
}