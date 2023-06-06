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

namespace Currency_Calculator_2.View
{
    /// <summary>
    /// Interaction logic for TemperatureView.xaml
    /// </summary>
    public partial class TemperatureView : UserControl
    {
        public string[] temperature { get; set; }
        private double Celcius;
        private double Fahrenheit;
        private double Kelvin;

        private double CelciustoFahrenheit
        {
            get { return (Celcius * 9 / 5) + 32; }
            set { Celcius = value; }
        }

        private double CelciustoKelvin
        {
            get { return (Celcius + 273.15); }
            set { Celcius = value; }
        }

        private double FahrenheittoCelcius
        {
            get { return (Fahrenheit - 32) * 5 / 9; }
            set { Fahrenheit = value; }
        }

        private double FahrenheittoKelvin
        {
            get { return (Fahrenheit - 32) * 5 / 9 + 273.15; }
            set { Fahrenheit = value; }
        }

        private double KelvintoCelcius
        {
            get { return Kelvin - 273.15; }
            set { Kelvin = value; }
        }

        private double KelvintoFahrenheit
        {
            get { return (Kelvin - 273.15) * 9 / 5 + 32; }
            set { Kelvin = value; }
        }

        private void TempConverter()
        {
            if (string.IsNullOrEmpty(textBoxInput.Text) || textBoxInput.Text == "-")
            {
                textBoxOutput.Text = "";
            }
            else if (comboBox1.Text == "Celcius" && comboBox2.Text == "Fahrenheit")
            {
                CelciustoFahrenheit = Convert.ToDouble(textBoxInput.Text);
                textBoxOutput.Text = CelciustoFahrenheit.ToString();
            }
            else if (comboBox1.Text == "Celcius" && comboBox2.Text == "Kelvin")
            {
                CelciustoKelvin = Convert.ToDouble(textBoxInput.Text);
                textBoxOutput.Text = CelciustoKelvin.ToString();
            }
            else if (comboBox1.Text == "Fahrenheit" && comboBox2.Text == "Celcius")
            {
                FahrenheittoCelcius = Convert.ToDouble(textBoxInput.Text);
                textBoxOutput.Text = FahrenheittoCelcius.ToString();
            }
            else if (comboBox1.Text == "Fahrenheit" && comboBox2.Text == "Kelvin")
            {
                FahrenheittoKelvin = Convert.ToDouble(textBoxInput.Text);
                textBoxOutput.Text = FahrenheittoKelvin.ToString();
            }
            else if (comboBox1.Text == "Kelvin" && comboBox2.Text == "Celcius")
            {
                KelvintoCelcius = Convert.ToDouble(textBoxInput.Text);
                textBoxOutput.Text = KelvintoCelcius.ToString();
            }
            else if (comboBox1.Text == "Kelvin" && comboBox2.Text == "Fahrenheit")
            {
                KelvintoFahrenheit = Convert.ToDouble(textBoxInput.Text);
                textBoxOutput.Text = KelvintoFahrenheit.ToString();
            }
        }

        public TemperatureView()
        {
            InitializeComponent();
            temperature = new string[] { "Celcius","Fahrenheit","Kelvin"};
            DataContext = this;
        }

        private void textBoxInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            TempConverter();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if ((comboBox1.Text == "" && comboBox2.Text == "") || (comboBox1.Text != "" && comboBox2.Text == "") || (comboBox1.Text == "" && comboBox2.Text != ""))
            {
                MessageBox.Show("Please Select One of the available temperatures!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Please Select One of the available temperatures!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Please Select One of the available temperatures!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Please Select One of the available temperatures!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Please Select One of the available temperatures!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                textBoxInput.Text = textBoxInput.Text + "5";
            }
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            if ((comboBox1.Text == "" && comboBox2.Text == "") || (comboBox1.Text != "" && comboBox2.Text == "") || (comboBox1.Text == "" && comboBox2.Text != ""))
            {
                MessageBox.Show("Please Select One of the available temperatures!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Please Select One of the available temperatures!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Please Select One of the available temperatures!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                MessageBox.Show("Please Select One of the available temperatures!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                textBoxInput.Text = textBoxInput.Text + "9";
            }
        }

        private void buttonNegatif_Click(object sender, RoutedEventArgs e)
        {
            if((comboBox1.Text == "" && comboBox2.Text == "")||(comboBox1.Text != "" && comboBox2.Text == "")||(comboBox1.Text == "" && comboBox2.Text != ""))
            {
                MessageBox.Show("Please Select One of the available temperatures!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (textBoxInput.Text == "")
                {
                    textBoxInput.Text = textBoxInput.Text + "-";
                }
                else if (textBoxInput.Text != "")
                {
                    MessageBox.Show("Invalid Input!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
        }

        private void button0_Click(object sender, RoutedEventArgs e)
        {
            if ((comboBox1.Text == "" && comboBox2.Text == "") || (comboBox1.Text != "" && comboBox2.Text == "") || (comboBox1.Text == "" && comboBox2.Text != ""))
            {
                MessageBox.Show("Please Select One of the available temperatures!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                textBoxInput.Text = textBoxInput.Text + "0";
            }
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            textBoxInput.Clear();
        }
    }
}
