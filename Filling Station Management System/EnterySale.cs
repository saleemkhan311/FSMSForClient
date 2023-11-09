using System;
using System.Collections.Generic;
using System.Drawing;
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

        }



        Double recovery, deposit, discount, udhar;
        Double balance;
        private Double _openReading, _closeReading, _rate, _test, _price, _quantity, _netQuantity;
        Double newPrice, newBalance, newOpenReading, newQuantity, newNetQuantity;
        Double DirectQuantity, DirectUnitPrice, DirectAmount;

        // Reading Entry -------------------------------------------------------------------------------------------


        private void CloseReadingTextBox_TextChanged_1(object sender, EventArgs e)
        {
            Calculations();
        }

        private void RateTextBox_TextChanged(object sender, EventArgs e)
        {
            Calculations();
        }

        private void FuelTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AutoSuggestions();
            RefTextBox.Text = (GetLastRefNo() + 1).ToString();

            if (!ToggleSwitch.Checked)
                return;

            FuelTypeLabel.Text = $"Direct Sale {FuelTypeBox.SelectedItem}";


            if (FuelTypeBox.SelectedIndex == 1)
            { DirectSalePanel.PanelColor = Color.FromArgb(184, 204, 228); }
            else { DirectSalePanel.PanelColor = Color.FromArgb(240, 147, 124); }
        }

        private void UnitBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                _openReading = GetLastClosingReading();

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
            catch { }

        }

        private void CheckTextBox_TextChanged(object sender, EventArgs e)
        {
            Calculations();
        }

        private void InsertData_Click(object sender, EventArgs e)
        {
            if (ToggleSwitch.Checked)
            {
                DirectSaleQuery();
            }
            else { Query(); }

            AutoIncrement();

            ClearBox();
        }

        // Total Enrty ----------------------------------------------------------------------------------------


        private void bunifuTextBox25_TextChanged(object sender, EventArgs e)
        {
            Calculations();
        }


        private void HelperTextBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void ClearBox()
        {
            try
            {
                _openReading = GetLastClosingReading();
                OpenReadingTextBox.Text = _openReading.ToString();

                CloseReadingTextBox.Clear();
                _closeReading = 0;
                CheckTextBox.Clear();
                _test = 0;
                AmountTextBox.Clear();
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
                DirectQuantityBox.Clear();
                DirectQuantity = 0;
                DirectUnitPBox.Clear();
                DirectUnitPrice = 0;
                DirectAmountBox.Clear();
                DirectAmount = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void RecoveryTextBox_TextChanged(object sender, EventArgs e)
        {

            Calculations();
        }
        private void UdharTextBox_TextChanged(object sender, EventArgs e)
        {
            Calculations();

        }

        private void DiscountTextBox_TextChanged(object sender, EventArgs e)
        {
            Calculations();

        }






        private void Calculations()
        {


            // Calculations 2 ***************************

            try
            {
                _closeReading = AppSettings.convertToDouble(CloseReadingTextBox.Text);
                _rate = AppSettings.convertToDouble(RateTextBox.Text);
                _test = AppSettings.convertToDouble(CheckTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Calculations II", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            _quantity = _closeReading - _openReading;
            _netQuantity = _quantity - _test;
            _price = (_netQuantity * _rate);



            /*newPrice = Math.Round(_price, 0);
            newQuantity = Math.Round(_quantity, 2);
            newNetQuantity = Math.Round(_netQuantity, 2);*/


            OpenReadingTextBox.Text = AppSettings.RoundToString(_openReading, false);
            QuantityTextBox.Text = AppSettings.RoundToString(_quantity, false);
            NetQuantityTextBox.Text = AppSettings.RoundToString(_netQuantity, false);
            AmountTextBox.Text = AppSettings.RoundToString(_price, true);

            //----------

            try
            {

                deposit = AppSettings.convertToDouble(DepositTextBox.Text);
                udhar = AppSettings.convertToDouble(UdharTextBox.Text);
                recovery = AppSettings.convertToDouble(RecoveryTextBox.Text);
                discount = AppSettings.convertToDouble(DiscountTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Calculations", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            balance = _price + recovery - deposit - udhar - discount;

            BalanceTB.Text = AppSettings.RoundToString(balance, true);

        }

        string sql;

        private void EnterySale_Load(object sender, EventArgs e)
        {


            UnitBox.SelectedIndex = 0;
            ToggleSwitch.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
            AutoIncrement();
            this.KeyPreview = true;

        }

        private void DirectQuantityBox_TextChanged(object sender, EventArgs e)
        {
            DirectSaleCal();
        }

        private void DirectUnitPBox_TextChanged(object sender, EventArgs e)
        {
            DirectSaleCal();
        }



        private void DirectSaleCal()
        {
            DirectQuantity = AppSettings.convertToDouble(DirectQuantityBox.Text);
            DirectUnitPrice = AppSettings.convertToDouble(DirectUnitPBox.Text);
            DirectAmount = DirectQuantity * DirectUnitPrice;

            DirectAmountBox.Text = AppSettings.RoundToString(DirectAmount, true);
        }
        private void ToggleSwitch_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {

            if (ToggleSwitch.Checked)
            {
                DirectSalePanel.Visible = true;
                DirectSalePanel.BringToFront();
                BalancePanel.Enabled = false;
                BalancePanel.Visible = false;
                FuelTypeBox.Enabled = true;

                UnitBox.Enabled = false;
                HelperLabel.Text = "Customer:";
            }
            else if (!ToggleSwitch.Checked)
            {
                DirectSalePanel.Visible = false;
                SalePanel.Visible = true;
                SalePanel.BringToFront();
                FuelTypeBox.Enabled = false;

                BalancePanel.Enabled = true;
                BalancePanel.Visible = true;
                UnitBox.Enabled = true;

                HelperLabel.Text = "Helper:";
            }

            RefTextBox.Text = (GetLastRefNo() + 1).ToString();
            AutoSuggestions();
        }

        private void InsertData_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void DesKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }
        private void OpenReadingTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void EnterySale_KeyDown(object sender, KeyEventArgs e)
        {

            if (Keys.Enter == e.KeyCode)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        string directQuery;
        private void DirectSaleQuery()
        {
            string unit = FuelTypeBox.SelectedItem.ToString();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(AppSettings.ConString()))
                {
                    conn.Open();
                    directQuery = $"INSERT INTO direct_sale_{unit} (Ref_No, Date, Fuel_Type, Customer, Quantity, Unit_Price,Amount) VALUES (@Ref_No, @Date, @Fuel_Type,@Customer, @Quantity, @Unit_Price,@Amount)";
                    MySqlCommand cmd = new MySqlCommand(directQuery, conn);


                    cmd.Parameters.AddWithValue("@Ref_No", RefTextBox.Text);
                    cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@Fuel_Type", FuelTypeBox.Text);
                    cmd.Parameters.AddWithValue("@Customer", HelperTextBox.Text);
                    cmd.Parameters.AddWithValue("@Quantity", DirectQuantityBox.Text);
                    cmd.Parameters.AddWithValue("@Unit_Price", DirectUnitPBox.Text);
                    cmd.Parameters.AddWithValue("@Amount", DirectAmount);

                    cmd.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Records Inserted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Direct Query", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Query()
        {
            int unit = UnitBox.SelectedIndex + 1;
            try
            {

                using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
                {
                    connection.Open();
                    sql = $"INSERT INTO unit{unit}_sales_data (Ref_No,Date,Fuel_Type,Helper,Opening_Reading,Closing_Reading,Quantity,Test,netQuantity,Unit_Price,Amount,Recovery,Deposited,Udhar,Discount,Balance) VALUES " +
                                                             "(@Ref_No,@Date,@Fuel_Type,@Helper,@Opening_Reading,@Closing_Reading,@Quantity,@Test,@netQuantity,@Unit_Price,@Amount,@Recovery,@Deposited,@Udhar,@Discount,@Balance)";


                    MySqlCommand cmd = new MySqlCommand(sql, connection);

                    cmd.Parameters.AddWithValue("@Ref_No", Convert.ToInt16(RefTextBox.Text));
                    cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@Fuel_Type", FuelTypeBox.Text);
                    cmd.Parameters.AddWithValue("@Helper", HelperTextBox.Text);


                    cmd.Parameters.AddWithValue("@Opening_Reading", OpenReadingTextBox.Text);
                    cmd.Parameters.AddWithValue("@Closing_Reading", CloseReadingTextBox.Text);
                    cmd.Parameters.AddWithValue("@Quantity", QuantityTextBox.Text);
                    cmd.Parameters.AddWithValue("@Test", CheckTextBox.Text);
                    cmd.Parameters.AddWithValue("@netQuantity", NetQuantityTextBox.Text);
                    cmd.Parameters.AddWithValue("@Unit_Price", RateTextBox.Text);


                    cmd.Parameters.AddWithValue("@Amount", _price);
                    cmd.Parameters.AddWithValue("@Recovery", RecoveryTextBox.Text);
                    cmd.Parameters.AddWithValue("@Deposited", DepositTextBox.Text);
                    cmd.Parameters.AddWithValue("@Udhar", UdharTextBox.Text);
                    cmd.Parameters.AddWithValue("@Discount", DiscountTextBox.Text);
                    cmd.Parameters.AddWithValue("@Balance", balance);

                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

                MessageBox.Show("Records Inserted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: ", "Query" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HelperTextBox_TextChanged_1(object sender, EventArgs e)
        {

        }

        string sqlCom;
        private Double GetLastClosingReading()
        {

            Double lastClosingReading = 0;

            int unit = UnitBox.SelectedIndex + 1;
            try
            {

                using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
                {
                    connection.Open();

                    sqlCom = $"SELECT Closing_Reading FROM unit{unit}_sales_data ORDER BY Ref_No DESC LIMIT 1";

                    MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        lastClosingReading = AppSettings.convertToDouble(result.ToString());
                    }
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
            int index = UnitBox.SelectedIndex + 1;
            //MessageBox.Show("Unit Box: " + UnitBox.SelectedIndex + " Index: " + index);

            try
            {

                using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
                {
                    connection.Open();
                    if (ToggleSwitch.Checked)
                    {
                        string fuel = FuelTypeBox.Items[FuelTypeBox.SelectedIndex].ToString();
                        Refsql = $"SELECT Ref_No FROM direct_sale_{fuel} ORDER BY Ref_No DESC LIMIT 1";
                    }
                    else if (!ToggleSwitch.Checked) { Refsql = $"SELECT Ref_No FROM unit{index}_sales_data ORDER BY Ref_No DESC LIMIT 1"; }




                    MySqlCommand cmd = new MySqlCommand(Refsql, connection);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        lastRefNo = Convert.ToInt16(result);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Get Last Ref", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return lastRefNo;
        }


        private void AutoIncrement()
        {
            RefTextBox.Text = (GetLastRefNo() + 1).ToString();
            OpenReadingTextBox.Text = _openReading.ToString("0.00");
        }
        List<string> helperNames = new List<string>();
        private void AutoSuggestions()
        {

            try
            {



                int unit = UnitBox.SelectedIndex + 1;

                string fuel = FuelTypeBox.Items[FuelTypeBox.SelectedIndex].ToString().ToLower();
                string query;
                string type;
                string table;

                using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
                {
                    connection.Open();

                    if (ToggleSwitch.Checked)
                    {
                        type = "Customer";
                        table = $"direct_sale_{fuel}";
                    }
                    else
                    {
                        type = "Helper";
                        table = $"unit{unit}_sales_data";
                    }

                    query = $"SELECT `{type}` FROM {table} LIMIT 50";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string helperName = reader[type].ToString();
                                helperNames.Add(helperName);
                            }
                        }
                    }
                }
                AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
                autoCompleteCollection.AddRange(helperNames.ToArray());

                HelperTextBox.AutoCompleteCustomSource = autoCompleteCollection;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error :" + ex.Message, "Name Fetch", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }


    }
}
