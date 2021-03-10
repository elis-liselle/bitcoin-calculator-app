using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitCoinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void currencyCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGetRates_Click(object sender, EventArgs e)
        {
            if (currencyCombo.SelectedItem.ToString() == "EUR")
            {
                resultLabel.Visible = true;
                resultTextBox.Visible = true;
                BitCoinRates bitCoin = GetRates();
                float result = Int32.Parse(amountOfCoinBox.Text) * bitCoin.bpi.EUR.rate_float;
                resultTextBox.Text = $"{result.ToString()} {bitCoin.bpi.EUR.code}";
            }
            else
            {
                resultLabel.Visible = true;
                resultTextBox.Visible = true;
                BitCoinRates bitCoin = GetRates();
                float result = Int32.Parse(amountOfCoinBox.Text) * bitCoin.bpi.USD.rate_float;
                resultTextBox.Text = $"{result.ToString()} {bitCoin.bpi.USD.code}";
            }
        }

        public static BitCoinRates GetRates()
        {
            string url = "https://api.coindesk.com/v1/bpi/currentprice.json";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            BitCoinRates bitcoin;
            using(var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                bitcoin = JsonConvert.DeserializeObject<BitCoinRates>(response);
            }

            return bitcoin;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
