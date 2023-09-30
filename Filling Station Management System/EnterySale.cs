using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using MySql.Data.MySqlClient;

namespace Filling_Station_Management_System
{
    public partial class EnterySale : KryptonForm
    {
        public EnterySale()
        {
            InitializeComponent();
            UnitBox.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Now;
            AutoIncrement();
            this.KeyPreview = true;


        }



        float recovery, deposit, discount, udhar;
        float balance;
        private float _openReading, _closeReading, _rate, _test, _price, _quantity, _netQuantity;
        Double newPrice, newBalance, newOpenReading, newQuantity, newNetQuantity;

        // Reading Entry -------------------------------------------------------------------------------------------


        private void CloseReadingTextBox_TextChanged_1(object sender, EventArgs e)
        {
            if (isFilled2())
            {
                if (Regex.IsMatch(CloseReadingTextBox.Text, @"^[0-9]*(?:\.[0-9]*)?$"))
                {

                    Calculations2();
                    Calculations();
                }
                else
                {
                    MessageBox.Show("Enter Data in Numbers");
                }
            }
            else
            {

            }
        }

        private void RateTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isFilled2())
            {
                if (Regex.IsMatch(RateTextBox.Text, @"^[0-9]*(?:\.[0-9]*)?$"))
                {
                    Calculations2();
                    Calculations();

                }
                else
                {
                    MessageBox.Show("Enter Data in Numbers");
                }
            }
            else
            {

            }
        }

        private void FuelTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UnitBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _openReading = GetLastClosingReading();
            //newOpenReading = Math.Round(GetLastClosingReading(), 2);
            AutoIncrement();
            OpenReadingTextBox.Text = _openReading.ToString();
            if (UnitBox.SelectedIndex == 0)
            {
                FuelTypeBox.SelectedIndex = 0;
            }
            else
            {
                FuelTypeBox.SelectedIndex = 1;
            }
        }

        private void CheckTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isFilled2())
            {
                if (Regex.IsMatch(CheckTextBox.Text, @"^[0-9]*(?:\.[0-9]*)?$"))
                {
                    Calculations2();
                    Calculations();
                }
                else
                {
                    MessageBox.Show("Enter Data in Numbers");
                }
            }
            else
            {

            }
        }



        public bool isFilled2()
        {
            return RateTextBox.Text != string.Empty && CloseReadingTextBox.Text != string.Empty && CheckTextBox.Text != string.Empty;
        }

        public void Calculations2()
        {
            try
            {
                _closeReading = ConvertFloat(CloseReadingTextBox.Text);
                _rate = ConvertFloat(RateTextBox.Text);
                _test = ConvertFloat(CheckTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Calculations2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            _quantity = _closeReading - _openReading;
            _netQuantity = _quantity - _test;
            _price = (_netQuantity * _rate);



            newPrice = Math.Round(_price, 0);
            newQuantity = Math.Round(_quantity, 2);
            newNetQuantity = Math.Round(_netQuantity, 2);


            OpenReadingTextBox.Text = _openReading.ToString();
            QuantityTextBox.Text = newQuantity.ToString();
            NetQuantityTextBox.Text = newNetQuantity.ToString();
            PriceTextBox.Text = newPrice.ToString();







        }

        private void InsertData_Click(object sender, EventArgs e)
        {


            if (isFilled() && isFilled2() && isFilledMandatory())
            {
                Query();
                ClearBox();
                AutoIncrement();
            }
            else
            {
                MessageBox.Show("Error: Please Fill All the Fields To Procced");
            }
        }

        // Total Enrty ----------------------------------------------------------------------------------------


        private void bunifuTextBox25_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(DepositTextBox.Text, @"^[0-9]*(?:\.[0-9]*)?$"))
            {
                Calculations();

                Calculations2();

            }
            else
            {
                MessageBox.Show("Enter Data in Numbers");
                DepositTextBox.Text = string.Empty;
            }
        }


        private void HelperTextBox_TextChanged(object sender, EventArgs e)
        {
            AutoSuggestions();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            ClearBox();
        }

        private void ClearBox()
        {


            OpenReadingTextBox.Text = GetLastClosingReading().ToString();
            _openReading = 0;
            CloseReadingTextBox.Clear();
            _closeReading = 0;
            CheckTextBox.Clear();
            _test = 0;
            PriceTextBox.Clear();
            _price = 0;
            RateTextBox.Clear();
            _rate = 0;
            NetQuantityTextBox.Clear();
            _netQuantity = 0;
            QuantityTextBox.Clear();
            _quantity = 0;


            RecoveryTextBox.Clear();
            recovery = 0;
            UdharTextBox.Clear();
            udhar = 0;
            DepositTextBox.Clear();
            deposit = 0;
            DiscountTextBox.Clear();
            discount = 0;
            BalanceTB.Clear();
            balance = 0;

            UnitBox.SelectedIndex = 0;


            dateTimePicker1.Value = DateTime.Now;
        }

        private void RecoveryTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isFilled())
            {
                if (Regex.IsMatch(RecoveryTextBox.Text, @"^[0-9]*(?:\.[0-9]*)?$"))
                {
                    Calculations();

                    Calculations2();
                }
                else
                {
                    MessageBox.Show("Enter Data in Numbers");
                    RecoveryTextBox.Text = string.Empty;
                }
            }
            else
            {

            }
        }
        private void UdharTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isFilled())
            {
                if (Regex.IsMatch(DiscountTextBox.Text, @"^[0-9]*(?:\.[0-9]*)?$"))
                {
                    Calculations();
                    Calculations2();

                }
                else
                {
                    MessageBox.Show("Enter Data in Numbers");
                    UdharTextBox.Text = string.Empty;
                }
            }
            else
            {

            }
        }

        private void DiscountTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isFilled())
            {
                if (Regex.IsMatch(DiscountTextBox.Text, @"^[0-9]*(?:\.[0-9]*)?$"))
                {
                    Calculations();
                    Calculations2();

                }
                else
                {
                    MessageBox.Show("Enter Data in Numbers");
                    DiscountTextBox.Text = string.Empty;
                }
            }
            else
            {

            }


        }






        private void Calculations()
        {
            if (isFilled())
            {
                try
                {

                    deposit = ConvertFloat(DepositTextBox.Text);
                    udhar = ConvertFloat(UdharTextBox.Text.ToString());
                    recovery = ConvertFloat(RecoveryTextBox.Text);
                    discount = ConvertFloat(DiscountTextBox.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Calculations", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                balance = _price + recovery - deposit - udhar - discount;
                newBalance = Math.Round(balance, 0);
                BalanceTB.Text = newBalance.ToString();
            }
        }



        private bool isFilled()
        {
            return RecoveryTextBox.Text != string.Empty && DepositTextBox.Text != string.Empty && UdharTextBox.Text != string.Empty && DiscountTextBox.Text != string.Empty;
        }



        string sql;

        private void SaleEntery_Click(object sender, EventArgs e)
        {

        }

        private void OpenReadingTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void EnterySale_KeyDown(object sender, KeyEventArgs e)
        {
            InsertData1.TabStop = true;
            InsertData1.TabIndex = 8;
            if (Keys.Enter == e.KeyCode)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void Query()
        {
            int unit = UnitBox.SelectedIndex + 1;
            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();
                sql = $"INSERT INTO unit{unit}_sales_data (Ref_No,Date,Fuel_Type,Helper,Opening_Reading,Closing_Reading,Quantity,Test,netQuantity,Unit_Price,Amount,Recovery,Deposited,Udhar,Discount,Balance) VALUES " +
                                                         "(@Ref_No,@Date,@Fuel_Type,@Helper,@Opening_Reading,@Closing_Reading,@Quantity,@Test,@netQuantity,@Unit_Price,@Amount,@Recovery,@Deposited,@Udhar,@Discount,@Balance)";




                MySqlCommand cmd = new MySqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@Ref_No", Convert.ToInt16(RefTextBox.Text));
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Fuel_Type", FuelTypeBox.Text);
                cmd.Parameters.AddWithValue("@Helper", HelperTextBox.Text);


                cmd.Parameters.AddWithValue("@Opening_Reading", newOpenReading);
                cmd.Parameters.AddWithValue("@Closing_Reading", _closeReading);
                cmd.Parameters.AddWithValue("@Quantity", newQuantity);
                cmd.Parameters.AddWithValue("@Test", _test);
                cmd.Parameters.AddWithValue("@netQuantity", newNetQuantity);
                cmd.Parameters.AddWithValue("@Unit_Price", _rate);


                cmd.Parameters.AddWithValue("@Amount", newPrice);
                cmd.Parameters.AddWithValue("@Recovery", recovery);
                cmd.Parameters.AddWithValue("@Deposited", deposit);
                cmd.Parameters.AddWithValue("@Udhar", udhar);
                cmd.Parameters.AddWithValue("@Discount", discount);
                cmd.Parameters.AddWithValue("@Balance", newBalance);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Records Inserted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: ", "Query" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HelperTextBox_TextChanged_1(object sender, EventArgs e)
        {
            AutoSuggestions();
        }

        string sqlCom;
        private float GetLastClosingReading()
        {
            float lastClosingReading = 0;

            int unit = UnitBox.SelectedIndex + 1;
            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                sqlCom = $"SELECT Closing_Reading FROM unit{unit}_sales_data ORDER BY Ref_No DESC LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    lastClosingReading = ConvertFloat(result.ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: ", "Get Last Closing Reading" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return lastClosingReading;
        }

        string Refsql;

        private float GetLastRefNo()
        {
            int lastRefNo = 0;
            int unit = UnitBox.SelectedIndex + 1;
            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                Refsql = $"SELECT Ref_No FROM unit{unit}_sales_data ORDER BY Ref_No DESC LIMIT 1";


                MySqlCommand cmd = new MySqlCommand(Refsql, connection);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    lastRefNo = Convert.ToInt16(result);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: ", "Get Last Ref" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return lastRefNo;
        }

        private bool isFilledMandatory()
        {
            return RefTextBox.Text != string.Empty && HelperTextBox.Text != string.Empty;
        }

        private void AutoIncrement()
        {
            RefTextBox.Text = (GetLastRefNo() + 1).ToString();
            OpenReadingTextBox.Text = _openReading.ToString();
        }
        List<string> helperNames = new List<string>();
        private void AutoSuggestions()
        {
            int unit = UnitBox.SelectedIndex + 1;

            using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
            {
                connection.Open();


                string query = $"SELECT `Helper` FROM unit{unit}_sales_data";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string helperName = reader["Helper"].ToString();
                            helperNames.Add(helperName);
                        }
                    }
                }
            }

            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
            autoCompleteCollection.AddRange(helperNames.ToArray());

            HelperTextBox.AutoCompleteCustomSource = autoCompleteCollection;
        }

        private static float ConvertFloat(string value)
        {
            value = string.IsNullOrEmpty(value) ? "0" : value;

            if (float.TryParse(value, out float floatValue))
            {

                return floatValue;
            }
            else
            {
                throw new ArgumentException("Invalid Input: Not a Valid Entry");
            }

        }
    }
}
