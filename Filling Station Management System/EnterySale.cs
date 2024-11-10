using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Bunifu.UI.WinForms.BunifuButton;
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

        string[] PetrolUnits = { "Unit 1", "Unit 2", "Unit 3" };
        string[] DieselUnits = { "Unit 1", "Unit 2", "Unit 3", "Unit 4", "Unit 5", };

        //BunifuButton[] PetrolUnitsB = { PetrolUnit1, };

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
            
            if(FuelTypeBox.SelectedIndex == 0)
            {
                UnitBox.Items.Clear();
                for (int i = 0; i < PetrolUnits.Length; i++)
                {
                    UnitBox.Items.Add(PetrolUnits[i].ToString());
                    //SharahListBox.SelectedIndex = 0;
                }
                
            }else if(FuelTypeBox.SelectedIndex == 1)
            {
                UnitBox.Items.Clear();
                for (int i = 0; i < DieselUnits.Length; i++)
                {
                    UnitBox.Items.Add(DieselUnits[i].ToString());
                    //SharahListBox.SelectedIndex = 0;
                }
            }
            UnitBox.SelectedIndex = 0;


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
                RefTextBox.Text = (GetLastRefNo() + 1).ToString();
                AutoIncrement();
                OpenReadingTextBox.Text = _openReading.ToString();
                /*if (UnitBox.SelectedIndex == 0)
                {
                    FuelTypeBox.SelectedIndex = 0;
                }
                else
                {
                    FuelTypeBox.SelectedIndex = 1;
                }*/

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


            OpenReadingTextBox.Text = _openReading.ToString("0.000");
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


            //UnitBox.SelectedIndex = 0;
            FuelTypeBox.Enabled = true;
            FuelTypeBox.SelectedIndex = 0;
            ToggleSwitch.Checked = false;
            dateTimePicker1.Value = DateTime.Now;
            AutoIncrement();
            this.KeyPreview = true;
            LoadStock();
            

        }

        private double GetLastUnitPrice()
        {
            string index = FuelTypeBox.Items[FuelTypeBox.SelectedIndex].ToString().ToLower();
            double lastUnitPrice = 0;

            try
            {

                using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
                {
                    connection.Open();

                    string Idsql = $"SELECT Available_Stock_Unit_Price FROM {index}_stock ORDER BY Ref_No DESC LIMIT 1";


                    MySqlCommand cmd = new MySqlCommand(Idsql, connection);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        lastUnitPrice = Convert.ToDouble(result);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Last Unit Price");
            }

            return lastUnitPrice;
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
                //FuelTypeBox.Enabled = false;

                BalancePanel.Enabled = true;
                BalancePanel.Visible = true;
                UnitBox.Enabled = true;

                HelperLabel.Text = "Helper:";
            }

            RefTextBox.Text = (GetLastRefNo() + 1).ToString();
            AutoSuggestions();
        }

        private void SaleEntery_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {

        }


        private void PetrolPanel_Click(object sender, EventArgs e)
        {
           

        }

        private void PetrolBtn_Click(object sender, EventArgs e)
        {
            foreach (BunifuButton b in new[] { DieselUnit1, DieselUnit2, DieselUnit3, DieselUnit4, DieselUnit5 })
            {
                b.Enabled = false;
            }

            foreach (BunifuButton b in new[] { PetrolUnit1, PetrolUnit2, PetrolUnit3 })
            {
                b.Enabled = true;
            }

            FuelTypeBox.SelectedIndex = 0;
            PetrolUnit1.PerformClick();
            LoadStock();
        }

        private void LoadStock()
        {
            availableStock = GetTotalPurchasePetrol() - GetTotalSalePetrol();
            StockLabel.Text = AppSettings.RoundToString(availableStock, false);
            StockPriceLabel.Text = GetLastUnitPrice().ToString("C2");
            StockAmountLabel.Text = AppSettings.RoundToString(availableStock * GetLastUnitPrice(), true);
            StockName.Text = "Petrol Stock";

            StockPill1.PanelColor = Color.FromArgb(240, 147, 124);
            StockPill2.PanelColor = Color.FromArgb(240, 147, 124);
            StockPill3.PanelColor = Color.FromArgb(240, 147, 124);
        }


        private float GetTotalPurchaseDiesel()
        {
            float totalSaleDiesel = 0;

            try
            {

                using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
                {
                    connection.Open();

                    string sqlCom = "SELECT \r\n    (SELECT Round(SUM(Saafi_Miqdar),4) FROM purchase_data_diesel) AS TotalSumQuantity;";

                    MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        totalSaleDiesel = float.Parse(result.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }

            return totalSaleDiesel;
        }

        private float GetTotalSaleDiesel()
        {
            float lastClosingReading = 0;


            try
            {

                using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
                {
                    connection.Open();

                    string sqlCom = @"SELECT 
                                            ROUND(
                                                (SELECT SUM(netQuantity) FROM unit4_sales_data) +
                                                (SELECT SUM(netQuantity) FROM unit5_sales_data) +
                                                (SELECT SUM(netQuantity) FROM unit6_sales_data) +
                                                (SELECT SUM(netQuantity) FROM unit7_sales_data) +
                                                (SELECT SUM(netQuantity) FROM unit8_sales_data) +
                                                (SELECT SUM(Quantity) FROM direct_sale_diesel), 
                                            2) AS TotalSumQuantity;
                                        ";





                    MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        lastClosingReading = float.Parse(result.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }

            return lastClosingReading;
        }



        private double GetTotalPurchasePetrol()
        {
            double totalPurchasePetrol = 0;


            try
            {

                using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
                {
                    connection.Open();

                    string sqlCom = "SELECT \r\n    (SELECT Round(SUM(Saafi_Miqdar),2) FROM purchase_data_petrol) AS TotalSumQuantity;";

                    MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        totalPurchasePetrol = Convert.ToDouble(result.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Total Purchase Petrol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return totalPurchasePetrol;
        }


        private float GetTotalSalePetrol()
        {
            float lastClosingReading = 0;


            try
            {

                using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
                {
                    connection.Open();

                    string sqlCom = @"SELECT ROUND(SUM(netQuantity), 2) AS total_quantity
                                        FROM (
                                            SELECT netQuantity FROM unit1_sales_data
                                            UNION ALL
                                            SELECT netQuantity FROM unit2_sales_data
                                            UNION ALL
                                            SELECT netQuantity FROM unit3_sales_data
                                            UNION ALL
                                            SELECT Quantity FROM direct_sale_petrol
                                        ) AS combined_sales_data;
                                        ";


                    MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        lastClosingReading = float.Parse(result.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }

            return lastClosingReading;
        }


        private void PetrolPanel_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void DieselBtn_Click(object sender, EventArgs e)
        {
            foreach (BunifuButton b in new[] { DieselUnit1, DieselUnit2, DieselUnit3, DieselUnit4, DieselUnit5 })
            {
                b.Enabled = true;
            }

            foreach (BunifuButton b in new[] { PetrolUnit1, PetrolUnit2, PetrolUnit3 })
            {
                b.Enabled = false;
            }

            FuelTypeBox.SelectedIndex = 1;
            DieselUnit1.PerformClick();

            availableStock = GetTotalPurchaseDiesel() - GetTotalSaleDiesel();
            StockLabel.Text = AppSettings.RoundToString(availableStock, false);
            StockPriceLabel.Text = GetLastUnitPrice().ToString("C2");
            StockAmountLabel.Text = AppSettings.RoundToString(availableStock * GetLastUnitPrice(), true);
            StockName.Text = "Diesel Stock";

            StockPill1.PanelColor = Color.FromArgb(184, 204, 228);
            StockPill2.PanelColor = Color.FromArgb(184, 204, 228);
            StockPill3.PanelColor = Color.FromArgb(184, 204, 228);
        }

        private void PetrolUnit1_Click(object sender, EventArgs e)
        {
            FuelTypeBox.SelectedIndex = 0;
            UnitBox.SelectedIndex = 0;
        }

        private void PetrolUnit2_Click(object sender, EventArgs e)
        {
            FuelTypeBox.SelectedIndex = 0;
            UnitBox.SelectedIndex = 1;
        }

        private void PetrolUnit3_Click(object sender, EventArgs e)
        {
            FuelTypeBox.SelectedIndex = 0;
            UnitBox.SelectedIndex= 2;
        }

        private void DieselUnit1_Click(object sender, EventArgs e)
        {
            FuelTypeBox.SelectedIndex= 1;
            UnitBox.SelectedIndex = 0;
        }

        private void DieselUnit2_Click(object sender, EventArgs e)
        {
            FuelTypeBox.SelectedIndex = 1;
            UnitBox.SelectedIndex = 1;
        }

        private void DieselUnit3_Click(object sender, EventArgs e)
        {
            FuelTypeBox.SelectedIndex = 1;
            UnitBox.SelectedIndex = 2;
        }

        private void DieselUnit4_Click(object sender, EventArgs e)
        {
            FuelTypeBox.SelectedIndex = 1;
            UnitBox.SelectedIndex = 3;
        }

        private void DieselUnit5_Click(object sender, EventArgs e)
        {

            FuelTypeBox.SelectedIndex = 1;
            UnitBox.SelectedIndex = 4;
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuShadowPanel1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
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
            int unit = 0;
            if (FuelTypeBox.SelectedIndex == 0) { unit = UnitBox.SelectedIndex + 1; }
            else if (FuelTypeBox.SelectedIndex == 1) {unit = UnitBox.SelectedIndex + 4; }    
            
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

            int unit = 0;
            if (FuelTypeBox.SelectedIndex == 0) { unit = UnitBox.SelectedIndex + 1; }
            else if (FuelTypeBox.SelectedIndex == 1) { unit = UnitBox.SelectedIndex + 4; }
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
            int index = 0;
            if (FuelTypeBox.SelectedIndex == 0) { index = UnitBox.SelectedIndex + 1; }
            else if(FuelTypeBox.SelectedIndex == 1) {  index = UnitBox.SelectedIndex + 4;}
            
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
        private double availableStock;

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
