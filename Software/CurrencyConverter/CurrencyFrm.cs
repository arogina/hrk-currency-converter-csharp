using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CurrencyConverter
{
    public partial class CurrencyForm : Form
    {
        Currency currency = new Currency();
        double result = 0;
        public CurrencyForm()
        {
            InitializeComponent();
            try
            {
                currency.GetCurrencies();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cbCurrency.DataSource = currency.Currencies;
            cbCurrency.DisplayMember = "Index";
            rbFrom.Checked = true;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (rbFrom.Checked)
            {
                result = Logic.ConvertFromHRK(Convert.ToDouble(tbAmount.Text), currency.Currencies[cbCurrency.SelectedIndex].Rate);
                tbResult.Text = result.ToString("N2") + " " + currency.Currencies[cbCurrency.SelectedIndex].Index;
            } else
            {
                result = Logic.ConvertToHRK(Convert.ToDouble(tbAmount.Text), currency.Currencies[cbCurrency.SelectedIndex].Rate);
                tbResult.Text = result.ToString("N2") + " HRK";
            }

            lbInfo.Text = "Rate: 1 HRK = " + currency.Currencies[cbCurrency.SelectedIndex].Rate + " " + currency.Currencies[cbCurrency.SelectedIndex].Index;
        }
    }
}
