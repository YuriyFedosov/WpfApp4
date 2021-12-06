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
using System.Xml.Linq;
using System.Net;


namespace WpfApp4
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string dollar=Currensy_doll();
            double rateDollar = Convert.ToDouble(dollar);
            double sumDollar = Convert.ToDouble(SumDollar.Text);
            double resDollar = rateDollar * sumDollar;
            RateDollar.Text = dollar.ToString();
            ResDollar.Text = resDollar.ToString();
       
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string Euro = Currensy_eur();
            double rateEuro = Convert.ToDouble(Euro);
            double sumEuro = Convert.ToDouble(SumEuro.Text);
            double resEuro = rateEuro * sumEuro;
            RateEuro.Text = Euro.ToString();
            ResEuro.Text = resEuro.ToString();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string Grvn = Currensy_grvn();
            double rateUah = Convert.ToDouble(Grvn);
            double sumUah = Convert.ToDouble(SumUah.Text);
            double resUah = rateUah * sumUah;
            RateUah.Text = Grvn.ToString();
            ResUah.Text = resUah.ToString();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string Drm = Currensy_drm();
            double rateAmd = Convert.ToDouble(Drm);
            double sumAmd = Convert.ToDouble(SumAmd.Text);
            double resAmd = rateAmd * sumAmd;
            RateAmd.Text = Drm.ToString();
            ResAmd.Text = resAmd.ToString();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            double foot = Convert.ToDouble(Foot.Text);
            double resultFoot = foot * 0.31;
            ResFoot.Text = resultFoot.ToString();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            double inch = Convert.ToDouble(Inch.Text);
            double resultIn = inch * 0.025;
            ResIn.Text = resultIn.ToString();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            double mi = Convert.ToDouble(Mi.Text);
            double resultMi = mi * 1609;
            ResMi.Text = resultMi.ToString();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            double vrst = Convert.ToDouble(Verst.Text);
            double resultNm = vrst * 1066;
            ResVerst.Text = resultNm.ToString();
        }

       
        /// Процедуры для вытягивания курса с сайта ЦБ РФ
 
        public string Currensy_doll()
        {
        WebClient client = new WebClient();
        var xml = client.DownloadString("https://www.cbr-xml-daily.ru/daily.xml");
        XDocument xdoc = XDocument.Parse(xml);
        var el = xdoc.Element("ValCurs").Elements("Valute");
        string dollar = el.Where(x => x.Attribute("ID").Value == "R01235").Select(x => x.Element("Value").Value).FirstOrDefault();
        return dollar;
        }
        public string Currensy_eur()
        {
            WebClient client = new WebClient();
            var xml = client.DownloadString("https://www.cbr-xml-daily.ru/daily.xml");
            XDocument xdoc = XDocument.Parse(xml);
            var el = xdoc.Element("ValCurs").Elements("Valute");
            string vEuro = el.Where(x => x.Attribute("ID").Value == "R01239").Select(x => x.Element("Value").Value).FirstOrDefault();
            return vEuro;
        }
        public string Currensy_grvn()
        {
            WebClient client = new WebClient();
            var xml = client.DownloadString("https://www.cbr-xml-daily.ru/daily.xml");
            XDocument xdoc = XDocument.Parse(xml);
            var el = xdoc.Element("ValCurs").Elements("Valute");
            string xGrvn = el.Where(x => x.Attribute("ID").Value == "R01720").Select(x => x.Element("Value").Value).FirstOrDefault();
            return xGrvn;
        }
        public string Currensy_drm()
        {
            WebClient client = new WebClient();
            var xml = client.DownloadString("https://www.cbr-xml-daily.ru/daily.xml");
            XDocument xdoc = XDocument.Parse(xml);
            var el = xdoc.Element("ValCurs").Elements("Valute");
            string xDrm = el.Where(x => x.Attribute("ID").Value == "R01060").Select(x => x.Element("Value").Value).FirstOrDefault();
            return xDrm;
        }

    }
}
