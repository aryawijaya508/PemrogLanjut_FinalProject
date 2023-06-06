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
using RestSharp;
using Newtonsoft.Json;
using System.Net;
using Currency_Calculator_2.Model;

namespace Currency_Calculator_2.View
{
    /// <summary>
    /// Interaction logic for CurrencyView.xaml
    /// </summary>
    public partial class CurrencyView : UserControl
    {
        public string[] mata_uang { get; set; }
        private int amount;
        private string from;
        private string to;
        private string currIDR = "IDR";
        private string currUSD = "USD";
        private string currJPY = "JPY";
        private string currEUR = "EUR";
        private string currMYR = "MYR";
        private double rate1b;
        private double rate2b;
        private double rate3b;
        private double rate4b;

        public CurrencyView()
        {
            InitializeComponent();

            mata_uang = new string[] { "IDR","USD","JPY","MYR","EUR"};
            DataContext = this;
        }


        private void GetCurrencyConvInfo(int amount, string from, string to, string currInput, string curr1, string curr2, string curr3, string curr4)
        {
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var client = new RestClient($"https://api.apilayer.com/exchangerates_data/convert?to={to}&from={from}&amount={amount}");
                client.Timeout = -1;

                var request = new RestRequest(Method.GET);
                request.AddHeader("apikey", "IDDOmiDalgiaUARN9wIyQ9OvS1m9hGDM");

                IRestResponse response = client.Execute(request);
                var currencyconvInfo = JsonConvert.DeserializeObject<Currency_Calculator_2.Model.Currency_Conv_Info>(response.Content);
                textBoxOutput.Text = Convert.ToString(currencyconvInfo.result);
                GetLiveRateCurrency(currInput, curr1, curr2, curr3, curr4);
            }
            catch
            {
                MessageBox.Show("Please Connect to The Internet!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show("Failed to get currency exchange rates!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                rate1b = 0;
                rate2b = 0;
                rate3b = 0;
                rate4b = 0;
                //GetLiveRateCurrency(currInput, curr1, curr2, curr3, curr4);
            }
        }

        private void GetLiveRateCurrency(string currInput, string curr1, string curr2, string curr3,string curr4)
        {
            try
            {
                var client = new RestClient($"https://api.apilayer.com/exchangerates_data/latest?symbols={curr1}%2C{curr2}%2C{curr3}%2C{curr4}&base={currInput}");
                client.Timeout = -1;

                var request = new RestRequest(Method.GET);
                request.AddHeader("apikey", "IDDOmiDalgiaUARN9wIyQ9OvS1m9hGDM");

                IRestResponse response = client.Execute(request);
                var liverateinfo = JsonConvert.DeserializeObject<LiveCurrInfo>(response.Content);

                if (comboBox1.Text == "IDR")
                {
                    rate1b = liverateinfo.rates.USD;
                    rate2b = liverateinfo.rates.MYR;
                    rate3b = liverateinfo.rates.EUR;
                    rate4b = liverateinfo.rates.JPY;
                }
                else if (comboBox1.Text == "USD")
                {
                    rate1b = liverateinfo.rates.IDR;
                    rate2b = liverateinfo.rates.MYR;
                    rate3b = liverateinfo.rates.EUR;
                    rate4b = liverateinfo.rates.JPY;
                }
                else if (comboBox1.Text == "EUR")
                {
                    rate1b = liverateinfo.rates.IDR;
                    rate2b = liverateinfo.rates.MYR;
                    rate3b = liverateinfo.rates.USD;
                    rate4b = liverateinfo.rates.JPY;
                }
                else if (comboBox1.Text == "MYR")
                {
                    rate1b = liverateinfo.rates.IDR;
                    rate2b = liverateinfo.rates.EUR;
                    rate3b = liverateinfo.rates.USD;
                    rate4b = liverateinfo.rates.JPY;
                }
                else if (comboBox1.Text == "JPY")
                {
                    rate1b = liverateinfo.rates.IDR;
                    rate2b = liverateinfo.rates.EUR;
                    rate3b = liverateinfo.rates.USD;
                    rate4b = liverateinfo.rates.MYR;
                }
            }
            catch
            {
                //MessageBox.Show("Failed to get currency exchange rates!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                rate1b = 0;
                rate2b = 0;
                rate3b = 0;
                rate4b = 0;
            }
            
        }


        //Method Converter
        private void CurrConverter()
        {
            //IDR Converter
            if (comboBox1.Text == "IDR" && comboBox2.Text == "USD")
            {
                from = comboBox1.Text;
                to = comboBox2.Text;
                amount = Convert.ToInt32(textBoxInput.Text);
                
                txtBlockCurrency.Text = currIDR;
                txtBlock1.Text = currUSD;
                txtBlock2.Text = currMYR;
                txtBlock3.Text = currEUR;
                txtBlock4.Text = currJPY;
                GetCurrencyConvInfo(amount, from, to, comboBox1.Text, currUSD, currMYR, currEUR, currJPY);
                //GetLiveRateCurrency(comboBox1.Text, currUSD, currMYR, currEUR, currJPY);
            }
            else if (comboBox1.Text == "IDR" && comboBox2.Text == "EUR")
            {
                from = comboBox1.Text;
                to = comboBox2.Text;
                amount = Convert.ToInt32(textBoxInput.Text);
                txtBlockCurrency.Text = currIDR;
                txtBlock1.Text = currUSD;
                txtBlock2.Text = currMYR;
                txtBlock3.Text = currEUR;
                txtBlock4.Text = currJPY;
                GetCurrencyConvInfo(amount, from, to, comboBox1.Text, currUSD, currMYR, currEUR, currJPY);
                //GetLiveRateCurrency(comboBox1.Text, currUSD, currMYR, currEUR, currJPY);
            }
            else if (comboBox1.Text == "IDR" && comboBox2.Text == "MYR")
            {
                from = comboBox1.Text;
                to = comboBox2.Text;
                amount = Convert.ToInt32(textBoxInput.Text);
                txtBlockCurrency.Text = currIDR;
                txtBlock1.Text = currUSD;
                txtBlock2.Text = currMYR;
                txtBlock3.Text = currEUR;
                txtBlock4.Text = currJPY;
                GetCurrencyConvInfo(amount, from, to, comboBox1.Text, currUSD, currMYR, currEUR, currJPY);
                //GetLiveRateCurrency(comboBox1.Text, currUSD, currMYR, currEUR, currJPY);
            }
            else if (comboBox1.Text == "IDR" && comboBox2.Text == "JPY")
            {
                from = comboBox1.Text;
                to = comboBox2.Text;
                amount = Convert.ToInt32(textBoxInput.Text);
                txtBlockCurrency.Text = currIDR;
                txtBlock1.Text = currUSD;
                txtBlock2.Text = currMYR;
                txtBlock3.Text = currEUR;
                txtBlock4.Text = currJPY;
                GetCurrencyConvInfo(amount, from, to, comboBox1.Text, currUSD, currMYR, currEUR, currJPY);
                //GetLiveRateCurrency(comboBox1.Text, currUSD, currMYR, currEUR, currJPY);
            }
            //USD Converter
            else if (comboBox1.Text == "USD" && comboBox2.Text == "IDR")
            {
                from = comboBox1.Text;
                to = comboBox2.Text;
                amount = Convert.ToInt32(textBoxInput.Text);
                txtBlockCurrency.Text = currUSD;
                txtBlock1.Text = currIDR;
                txtBlock2.Text = currMYR;
                txtBlock3.Text = currEUR;
                txtBlock4.Text = currJPY;
                GetCurrencyConvInfo(amount, from, to, comboBox1.Text, currIDR, currMYR, currEUR, currJPY);
                GetLiveRateCurrency(comboBox1.Text, currIDR, currMYR, currEUR, currJPY);
            }
            else if (comboBox1.Text == "USD" && comboBox2.Text == "EUR")
            {
                from = comboBox1.Text;
                to = comboBox2.Text;
                amount = Convert.ToInt32(textBoxInput.Text);
                txtBlockCurrency.Text = currUSD;
                txtBlock1.Text = currIDR;
                txtBlock2.Text = currMYR;
                txtBlock3.Text = currEUR;
                txtBlock4.Text = currJPY;
                GetCurrencyConvInfo(amount, from, to, comboBox1.Text, currIDR, currMYR, currEUR, currJPY);
                //GetLiveRateCurrency(comboBox1.Text, currIDR, currMYR, currEUR, currJPY);
            }
            else if (comboBox1.Text == "USD" && comboBox2.Text == "JPY")
            {
                from = comboBox1.Text;
                to = comboBox2.Text;
                amount = Convert.ToInt32(textBoxInput.Text);
                txtBlockCurrency.Text = currUSD;
                txtBlock1.Text = currIDR;
                txtBlock2.Text = currMYR;
                txtBlock3.Text = currEUR;
                txtBlock4.Text = currJPY;
                GetCurrencyConvInfo(amount, from, to, comboBox1.Text, currIDR, currMYR, currEUR, currJPY);
                //GetLiveRateCurrency(comboBox1.Text, currIDR, currMYR, currEUR, currJPY);
            }
            else if (comboBox1.Text == "USD" && comboBox2.Text == "MYR")
            {
                from = comboBox1.Text;
                to = comboBox2.Text;
                amount = Convert.ToInt32(textBoxInput.Text);
                txtBlockCurrency.Text = currUSD;
                txtBlock1.Text = currIDR;
                txtBlock2.Text = currMYR;
                txtBlock3.Text = currEUR;
                txtBlock4.Text = currJPY;
                GetCurrencyConvInfo(amount, from, to, comboBox1.Text, currIDR, currMYR, currEUR, currJPY);
                //GetLiveRateCurrency(comboBox1.Text, currIDR, currMYR, currEUR, currJPY); ;
            }
            //EUR Converter
            else if (comboBox1.Text == "EUR" && comboBox2.Text == "IDR")
            {
                from = comboBox1.Text;
                to = comboBox2.Text;
                amount = Convert.ToInt32(textBoxInput.Text);
                txtBlockCurrency.Text = currEUR;
                txtBlock1.Text = currIDR;
                txtBlock2.Text = currMYR;
                txtBlock3.Text = currUSD;
                txtBlock4.Text = currJPY;
                GetCurrencyConvInfo(amount, from, to, comboBox1.Text, currIDR, currMYR, currUSD, currJPY);
                //GetLiveRateCurrency(comboBox1.Text, currIDR, currMYR, currUSD, currJPY);
            }
            else if (comboBox1.Text == "EUR" && comboBox2.Text == "USD")
            {
                from = comboBox1.Text;
                to = comboBox2.Text;
                amount = Convert.ToInt32(textBoxInput.Text);
                txtBlockCurrency.Text = currEUR;
                txtBlock1.Text = currIDR;
                txtBlock2.Text = currMYR;
                txtBlock3.Text = currUSD;
                txtBlock4.Text = currJPY;
                GetCurrencyConvInfo(amount, from, to, comboBox1.Text, currIDR, currMYR, currUSD, currJPY);
                //GetLiveRateCurrency(comboBox1.Text, currIDR, currMYR, currUSD, currJPY);
            }
            else if (comboBox1.Text == "EUR" && comboBox2.Text == "MYR")
            {
                from = comboBox1.Text;
                to = comboBox2.Text;
                amount = Convert.ToInt32(textBoxInput.Text);
                txtBlockCurrency.Text = currEUR;
                txtBlock1.Text = currIDR;
                txtBlock2.Text = currMYR;
                txtBlock3.Text = currUSD;
                txtBlock4.Text = currJPY;
                GetCurrencyConvInfo(amount, from, to, comboBox1.Text, currIDR, currMYR, currUSD, currJPY);
                //GetLiveRateCurrency(comboBox1.Text, currIDR, currMYR, currUSD, currJPY);
            }
            else if (comboBox1.Text == "EUR" && comboBox2.Text == "JPY")
            {
                from = comboBox1.Text;
                to = comboBox2.Text;
                amount = Convert.ToInt32(textBoxInput.Text);
                txtBlockCurrency.Text = currEUR;
                txtBlock1.Text = currIDR;
                txtBlock2.Text = currMYR;
                txtBlock3.Text = currUSD;
                txtBlock4.Text = currJPY;
                GetCurrencyConvInfo(amount, from, to, comboBox1.Text, currIDR, currMYR, currUSD, currJPY);
                GetLiveRateCurrency(comboBox1.Text, currIDR, currMYR, currUSD, currJPY);
            }
            //MYR Converter
            else if (comboBox1.Text == "MYR" && comboBox2.Text == "IDR")
            {
                from = comboBox1.Text;
                to = comboBox2.Text;
                amount = Convert.ToInt32(textBoxInput.Text);
                txtBlockCurrency.Text = currMYR;
                txtBlock1.Text = currIDR;
                txtBlock2.Text = currEUR;
                txtBlock3.Text = currUSD;
                txtBlock4.Text = currJPY;
                GetCurrencyConvInfo(amount, from, to, comboBox1.Text, currIDR, currEUR, currUSD, currJPY);
                //GetLiveRateCurrency(comboBox1.Text, currIDR, currEUR, currUSD, currJPY);
            }
            else if (comboBox1.Text == "MYR" && comboBox2.Text == "USD")
            {
                from = comboBox1.Text;
                to = comboBox2.Text;
                amount = Convert.ToInt32(textBoxInput.Text);
                txtBlockCurrency.Text = currMYR;
                txtBlock1.Text = currIDR;
                txtBlock2.Text = currEUR;
                txtBlock3.Text = currUSD;
                txtBlock4.Text = currJPY;
                GetCurrencyConvInfo(amount, from, to, comboBox1.Text, currIDR, currEUR, currUSD, currJPY);
                //GetLiveRateCurrency(comboBox1.Text, currIDR, currEUR, currUSD, currJPY);
            }
            else if (comboBox1.Text == "MYR" && comboBox2.Text == "EUR")
            {
                from = comboBox1.Text;
                to = comboBox2.Text;
                amount = Convert.ToInt32(textBoxInput.Text);
                txtBlockCurrency.Text = currMYR;
                txtBlock1.Text = currIDR;
                txtBlock2.Text = currEUR;
                txtBlock3.Text = currUSD;
                txtBlock4.Text = currJPY;
                GetCurrencyConvInfo(amount, from, to, comboBox1.Text, currIDR, currEUR, currUSD, currJPY);
                //GetLiveRateCurrency(comboBox1.Text, currIDR, currEUR, currUSD, currJPY);
            }
            else if (comboBox1.Text == "MYR" && comboBox2.Text == "JPY")
            {
                from = comboBox1.Text;
                to = comboBox2.Text;
                amount = Convert.ToInt32(textBoxInput.Text);
                txtBlockCurrency.Text = currMYR;
                txtBlock1.Text = currIDR;
                txtBlock2.Text = currEUR;
                txtBlock3.Text = currUSD;
                txtBlock4.Text = currJPY;
                GetCurrencyConvInfo(amount, from, to, comboBox1.Text, currIDR, currEUR, currUSD, currJPY);
                //GetLiveRateCurrency(comboBox1.Text, currIDR, currEUR, currUSD, currJPY);
            }
            //JPY Converter
            else if (comboBox1.Text == "JPY" && comboBox2.Text == "IDR")
            {
                from = comboBox1.Text;
                to = comboBox2.Text;
                amount = Convert.ToInt32(textBoxInput.Text);
                txtBlockCurrency.Text = currJPY;
                txtBlock1.Text = currIDR;
                txtBlock2.Text = currEUR;
                txtBlock3.Text = currUSD;
                txtBlock4.Text = currMYR;
                GetCurrencyConvInfo(amount, from, to, comboBox1.Text, currIDR, currEUR, currUSD, currMYR);
                GetLiveRateCurrency(comboBox1.Text, currIDR, currEUR, currUSD, currMYR);
            }
            else if (comboBox1.Text == "JPY" && comboBox2.Text == "USD")
            {
                from = comboBox1.Text;
                to = comboBox2.Text;
                amount = Convert.ToInt32(textBoxInput.Text);
                txtBlockCurrency.Text = currJPY;
                txtBlock1.Text = currIDR;
                txtBlock2.Text = currEUR;
                txtBlock3.Text = currUSD;
                txtBlock4.Text = currMYR;
                GetCurrencyConvInfo(amount, from, to, comboBox1.Text, currIDR, currEUR, currUSD, currMYR);
                //GetLiveRateCurrency(comboBox1.Text, currIDR, currEUR, currUSD, currMYR);
            }
            else if (comboBox1.Text == "JPY" && comboBox2.Text == "EUR")
            {
                from = comboBox1.Text;
                to = comboBox2.Text;
                amount = Convert.ToInt32(textBoxInput.Text);
                txtBlockCurrency.Text = currJPY;
                txtBlock1.Text = currIDR;
                txtBlock2.Text = currEUR;
                txtBlock3.Text = currUSD;
                txtBlock4.Text = currMYR;
                GetCurrencyConvInfo(amount, from, to, comboBox1.Text, currIDR, currEUR, currUSD, currMYR);
                //GetLiveRateCurrency(comboBox1.Text, currIDR, currEUR, currUSD, currMYR);
            }
            else if (comboBox1.Text == "JPY" && comboBox2.Text == "MYR")
            {
                from = comboBox1.Text;
                to = comboBox2.Text;
                amount = Convert.ToInt32(textBoxInput.Text);
                txtBlockCurrency.Text = currJPY;
                txtBlock1.Text = currIDR;
                txtBlock2.Text = currEUR;
                txtBlock3.Text = currUSD;
                txtBlock4.Text = currMYR;
                GetCurrencyConvInfo(amount, from, to, comboBox1.Text, currIDR, currEUR, currUSD, currMYR);
                //GetLiveRateCurrency(comboBox1.Text, currIDR, currEUR, currUSD, currMYR);
            }
        }

        private void btn_Convert_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxInput.Text == "")
            {
                MessageBox.Show("Please input some number!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                txtBlockResult1.Text = "";
                txtBlockResult2.Text = "";
                txtBlockResult3.Text = "";
                txtBlockResult4.Text = "";
                CurrConverter();
                txtBlockResult1.Text = Convert.ToString(rate1b);
                txtBlockResult2.Text = Convert.ToString(rate2b);
                txtBlockResult3.Text = Convert.ToString(rate3b);
                txtBlockResult4.Text = Convert.ToString(rate4b);
            }
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if ((comboBox1.Text == "" && comboBox2.Text == "") || (comboBox1.Text != "" && comboBox2.Text == "") || (comboBox1.Text == "" && comboBox2.Text != ""))
            {
                MessageBox.Show("Please Select One of the available Currency!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                textBoxInput.Text = textBoxInput.Text + "1";
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if ((comboBox1.Text == "" && comboBox2.Text == "") || (comboBox1.Text != "" && comboBox2.Text == "") || (comboBox1.Text == "" && comboBox2.Text != ""))
            {
                MessageBox.Show("Please Select One of the available Currency!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                textBoxInput.Text = textBoxInput.Text + "2";
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if ((comboBox1.Text == "" && comboBox2.Text == "") || (comboBox1.Text != "" && comboBox2.Text == "") || (comboBox1.Text == "" && comboBox2.Text != ""))
            {
                MessageBox.Show("Please Select One of the available Currency!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                textBoxInput.Text = textBoxInput.Text + "3";
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if ((comboBox1.Text == "" && comboBox2.Text == "") || (comboBox1.Text != "" && comboBox2.Text == "") || (comboBox1.Text == "" && comboBox2.Text != ""))
            {
                MessageBox.Show("Please Select One of the available Currency!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                textBoxInput.Text = textBoxInput.Text + "4";
            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            if ((comboBox1.Text == "" && comboBox2.Text == "") || (comboBox1.Text != "" && comboBox2.Text == "") || (comboBox1.Text == "" && comboBox2.Text != ""))
            {
                MessageBox.Show("Please Select One of the available Currency!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                textBoxInput.Text = textBoxInput.Text + "5";
            }
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            if((comboBox1.Text == "" && comboBox2.Text == "") || (comboBox1.Text != "" && comboBox2.Text == "") || (comboBox1.Text == "" && comboBox2.Text != ""))
            {
                MessageBox.Show("Please Select One of the available Currency!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                textBoxInput.Text = textBoxInput.Text + "6";
            }
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            if ((comboBox1.Text == "" && comboBox2.Text == "") || (comboBox1.Text != "" && comboBox2.Text == "") || (comboBox1.Text == "" && comboBox2.Text != ""))
            {
                MessageBox.Show("Please Select One of the available Currency!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                textBoxInput.Text = textBoxInput.Text + "7";
            }
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            if ((comboBox1.Text == "" && comboBox2.Text == "") || (comboBox1.Text != "" && comboBox2.Text == "") || (comboBox1.Text == "" && comboBox2.Text != ""))
            {
                MessageBox.Show("Please Select One of the available Currency!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                textBoxInput.Text = textBoxInput.Text + "8";
            }
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            if ((comboBox1.Text == "" && comboBox2.Text == "") || (comboBox1.Text != "" && comboBox2.Text == "") || (comboBox1.Text == "" && comboBox2.Text != ""))
            {
                MessageBox.Show("Please Select One of the available Currency!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                textBoxInput.Text = textBoxInput.Text + "9";
            }
        }

        private void button0_Click(object sender, RoutedEventArgs e)
        {
            if ((comboBox1.Text == "" && comboBox2.Text == "") || (comboBox1.Text != "" && comboBox2.Text == "") || (comboBox1.Text == "" && comboBox2.Text != ""))
            {
                MessageBox.Show("Please Select One of the available Currency!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                textBoxInput.Text = textBoxInput.Text + "0";
            }
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            textBoxInput.Clear();
            textBoxOutput.Clear();
        }
    }
}
