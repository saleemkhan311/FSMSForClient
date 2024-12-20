﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using MySql.Data.MySqlClient;


namespace Filling_Station_Management_System
{
    public partial class SaleLedger : KryptonForm
    {
        public SaleLedger()
        {
            InitializeComponent();

            ViewRecordsPanel.Hide();
            this.KeyPreview = true;

            //SetTabStopTrue();
        }

        string Username;

        double recovery, deposit, discount, udhar;
        double balance;
        private Double _openReading, _closeReading, _rate, _test, _price, _quantity, _netQuantity, _readCount;
        Double DirectQuantity, DirectUnitPrice, DirectAmount;

        //Double newPrice, newBalance, newQuantity, newNetQuantity;

        readonly string[] PetrolUnits = { "Unit1_Sales_Data", "Unit2_Sales_Data", "Unit3_Sales_Data", "Direct_Sale_Petrol",  };
        readonly string[] DieselUnits = { "Unit1_Sales_Data", "Unit2_Sales_Data", "Unit3_Sales_Data", "Unit4_Sales_Data", "Unit5_Sales_Data", "Direct_Sale_Diesel" };
        private void DirectSaleQuery()
        {
            string unit = TableMenu.SelectedItem.ToString().ToLower();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(AppSettings.ConString()))
                {
                    conn.Open();
                    string directQuery = $"UPDATE {unit} SET Ref_No = @Ref_No,Date=@Date,Fuel_Type=@Fuel_Type,Customer=@Customer,Quantity=@Quantity,Unit_Price=@Unit_Price,Amount=@Amount WHERE Ref_No=@Ref_No";
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

        string sql;
        private void Query()
        {
            string table = TableMenu.SelectedItem.ToString().ToLower();
            try
            {

                using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
                {
                    connection.Open();

                    sql = $"UPDATE {table} SET Ref_No = @Ref_No,Date=@Date,Fuel_Type=@Fuel_Type,Helper=@Helper,Closing_Reading=@Closing_Reading,Quantity=@Quantity,Test=@Test,netQuantity=@netQuantity,Unit_Price=@Unit_Price,Amount=@Amount,Recovery=@Recovery,Deposited=@Deposited,Udhar=@Udhar,Discount=@Discount,Balance=@Balance WHERE Ref_No=@Ref_No";

                    MySqlCommand cmd = new MySqlCommand(sql, connection);

                    cmd.Parameters.AddWithValue("@Ref_No", RefTextBox.Text);
                    cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@Fuel_Type", FuelTypeBox.Text);
                    cmd.Parameters.AddWithValue("@Helper", HelperTextBox.Text);


                    cmd.Parameters.AddWithValue("@Opening_Reading", _openReading);
                    cmd.Parameters.AddWithValue("@Closing_Reading", _closeReading);
                    cmd.Parameters.AddWithValue("@Quantity", _quantity);
                    cmd.Parameters.AddWithValue("@Test", _test);
                    cmd.Parameters.AddWithValue("@netQuantity", _netQuantity);
                    cmd.Parameters.AddWithValue("@Unit_Price", _rate);


                    cmd.Parameters.AddWithValue("@Amount", _price);
                    cmd.Parameters.AddWithValue("@Recovery", recovery);
                    cmd.Parameters.AddWithValue("@Deposited", deposit);
                    cmd.Parameters.AddWithValue("@Udhar", udhar);
                    cmd.Parameters.AddWithValue("@Discount", discount);
                    cmd.Parameters.AddWithValue("@Balance", balance);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Records Updated Successfully");
                    UnitBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void SaleLedger_Load(object sender, EventArgs e)
        {
            FuelType.SelectedIndex = 0;
            TableMenu.SelectedIndex = 0;

        }

        private void LoadData()
        {
            int unit = TableMenu.SelectedIndex + 1;
            string table = "";

            using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
            {
                string sql = "";
                connection.Open();
                
                    table = TableMenu.Items[TableMenu.SelectedIndex].ToString().ToLower();
                    
                    if(FuelType.SelectedIndex == 1)
                    {
                        string[] DieselUnits = { "Unit4_Sales_Data", "Unit5_Sales_Data", "Unit6_Sales_Data", "Unit7_Sales_Data", "Unit8_Sales_Data", "Direct_Sale_Diesel" };
                        
                        table = DieselUnits[unit-1];

                    }
                    
                    sql = $"SELECT\r\n    Ref_No,\r\n    Date,\r\n    Fuel_Type,\r\n    Helper,\r\n    ROUND(Opening_Reading,3) AS Opening_Reading,\r\n    Round(Closing_Reading,3) AS Closing_Reading,\r\n    Quantity,\r\n    Test,\r\n    netQuantity,\r\n    FORMAT(Unit_Price, 'C', 'en-PK') AS Unit_Price,\r\n    FORMAT(Amount, 'C', 'en-PK') AS Amount,\r\n    FORMAT(Recovery, 'C', 'en-PK') AS Recovery,\r\n    FORMAT(Deposited, 'C', 'en-PK') AS Deposited,\r\n    FORMAT(Udhar, 'C', 'en-PK') AS Udhar,\r\n    FORMAT(Discount, 'C', 'en-PK') AS Discount,\r\n    FORMAT(Balance, 'C', 'en-PK') AS Balance\r\nFROM {table};\r\n"; // Add your WHERE clause
                
                if (TableMenu.SelectedIndex == TableMenu.Items.Count-1)
                {
                    
                    table = TableMenu.SelectedItem.ToString().ToLower();
                    sql = $"SELECT\r\n    Ref_No,\r\n    Date,\r\n    Fuel_Type,\r\n   Customer,\r\n Quantity,\r\n    FORMAT(Unit_Price, 'C', 'en-PK') AS Unit_Price,\r\n    FORMAT(Amount, 'C', 'en-PK') AS Amount\r\nFROM {table};";
                }

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                int currentRowIndex = Unit1DataGrid.FirstDisplayedScrollingRowIndex; // Gets the row at the top of the view
                int selectedRowIndex = Unit1DataGrid.CurrentCell != null ? Unit1DataGrid.CurrentCell.RowIndex : -1;

                Unit1DataGrid.DataSource = dataTable;

                if (currentRowIndex >= 0 && currentRowIndex < Unit1DataGrid.Rows.Count)
                {
                    Unit1DataGrid.FirstDisplayedScrollingRowIndex = currentRowIndex; // Set scroll position
                }

                if (selectedRowIndex >= 0 && selectedRowIndex < Unit1DataGrid.Rows.Count)
                {
                    Unit1DataGrid.Rows[selectedRowIndex].Selected = true; // Re-select the row
                    Unit1DataGrid.CurrentCell = Unit1DataGrid.Rows[selectedRowIndex].Cells[0]; // Optionally focus the first cell
                }

            }

        }





        private void UdharTextBox_TextChanged(object sender, EventArgs e)
        {

            Calculations();

        }


        private void RecoveryTextBox_TextChanged_1(object sender, EventArgs e)
        {

            Calculations();
        }

        private void DiscountTextBox_TextChanged(object sender, EventArgs e)
        {

            Calculations();
        }

        private void UpdateData_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            Username = main.UsernameLabel.Text;

            main.Dispose();

            if (TableMenu.SelectedIndex < 4)
            {
                Query();
            }
            else if (TableMenu.SelectedIndex > 3)
            {
                DirectSaleQuery();
            }



        }



        //---------------------------------------------------------------------------------------
        private void EditTableData(object sender, EventArgs e)
        {

        }

        private void SaleEntery_Click(object sender, EventArgs e)
        {

        }


        private void TabChange(object sender, EventArgs e)
        {
            LoadData();

        }

        private void SearchControl()
        {
            try
            {
                string table = TableMenu.SelectedItem.ToString();

                using (MySqlConnection con = new MySqlConnection(AppSettings.ConString()))
                {
                    con.Open();

                    MySqlCommand cmd;
                    cmd = con.CreateCommand();

                    if (SearchByNameRadio.Checked)
                    {

                        cmd.CommandText = $"SELECT * FROM {table} WHERE Helper LIKE" + "'" + AppSettings.ValidateTextBoxForNumbers(SearchTextBox) + "%'";
                        cmd.Parameters.AddWithValue("@Helper", AppSettings.ValidateTextBoxForNumbers(SearchTextBox));

                    }
                    else if (SearchByRefRadio.Checked)
                    {

                        cmd.CommandText = $"SELECT * FROM {table} WHERE Ref_No LIKE" + "'" + AppSettings.ValidateTextBoxForAlphabets(SearchTextBox) + "%'";
                        cmd.Parameters.AddWithValue("@Ref_No", AppSettings.ValidateTextBoxForAlphabets(SearchTextBox));
                    }
                    else
                    {
                        MessageBox.Show("Please Select 'Search by Name' Or 'Search by ID' Option ");
                        return;
                    }

                    MySqlDataReader reader = cmd.ExecuteReader();
                    DataTable records = new DataTable();
                    records.Load(reader);


                    if (records.Rows.Count >= 1)
                    {
                        Unit1DataGrid.DataSource = records;
                    }
                    else
                    {
                        MessageBox.Show("No Records Found");
                        LoadData();
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Invalid Entry / " + ex.Message, "Invalid Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }









        private void RemoveButton_Click(object sender, EventArgs e)
        {
            PasswordCheckPanel passCheck = new PasswordCheckPanel();
            passCheck.ShowDialog();
            if (passCheck.DialogResult != DialogResult.OK)
                return;


            string table = TableMenu.SelectedItem.ToString().ToLower();
            if(FuelType.SelectedIndex == 1)
            {
                string[] DieselUnits = { "Unit4_Sales_Data", "Unit5_Sales_Data", "Unit6_Sales_Data", "Unit7_Sales_Data", "Unit8_Sales_Data", "Direct_Sale_Diesel" };
                table = DieselUnits[TableMenu.SelectedIndex].ToString().ToLower();
            }
            int ref_No = int.Parse(Unit1DataGrid.SelectedRows[0].Cells[0].Value.ToString());

            int selectedIndex = Unit1DataGrid.SelectedRows[0].Index;
            int lastIndex = Unit1DataGrid.Rows.Count - 1;
            try
            {
                if (selectedIndex != 0)
                {
                    using (MySqlConnection con = new MySqlConnection(AppSettings.ConString()))
                    {
                        con.Open();
                        MySqlCommand cmd;

                        cmd = con.CreateCommand();

                        cmd.CommandText = $"DELETE FROM {table} WHERE Ref_No=@Ref_No;";
                        cmd.Parameters.AddWithValue("@Ref_No", ref_No);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("Cannot Remove Last Entry");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ResetButton_Click_1(object sender, EventArgs e)
        {
            ClearBox();
        }

        private void DataGrid1DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                object date = null;

                if (TableMenu.SelectedIndex != TableMenu.Items.Count - 1)
                {

                    RefTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[0].Value.ToString();
                    date = Unit1DataGrid.SelectedRows[0].Cells[1].Value;
                    FuelTypeBox.Text = Unit1DataGrid.SelectedRows[0].Cells[2].Value.ToString();
                    HelperTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[3].Value.ToString();
                    OpenReadingTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[4].Value.ToString();
                    CloseReadingTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[5].Value.ToString();
                    QuantityTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[6].Value.ToString();
                    CheckTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[7].Value.ToString();
                    NetQuantityTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[8].Value.ToString();
                    RateTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[9].Value.ToString();
                    AmountTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[10].Value.ToString();
                    RecoveryTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[11].Value.ToString();
                    DepositTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[12].Value.ToString();
                    UdharTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[13].Value.ToString();
                    DiscountTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[14].Value.ToString();

                    BalanceTB.Text = Unit1DataGrid.SelectedRows[0].Cells[15].Value.ToString();



                }
                else if (TableMenu.SelectedIndex == TableMenu.Items.Count - 1)
                {
                    RefTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[0].Value.ToString();
                    date = Unit1DataGrid.SelectedRows[0].Cells[1].Value;
                    FuelTypeBox.Text = Unit1DataGrid.SelectedRows[0].Cells[2].Value.ToString();
                    HelperTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[3].Value.ToString();
                    DirectQuantityBox.Text = Unit1DataGrid.SelectedRows[0].Cells[4].Value.ToString();
                    DirectUnitPBox.Text = Unit1DataGrid.SelectedRows[0].Cells[5].Value.ToString();
                    DirectAmountBox.Text = Unit1DataGrid.SelectedRows[0].Cells[6].Value.ToString();
                }
                //if (TableMenu.SelectedIndex == TableMenu.Items.Count - 1)
                    AutoSuggestions();

                DateTime newDate;
                if (DateTime.TryParse(date.ToString(), out newDate))
                {
                    dateTimePicker1.Value = newDate;
                }


                PasswordCheckPanel passCheck = new PasswordCheckPanel();
                passCheck.ShowDialog();
                if (passCheck.DialogResult == DialogResult.OK)
                {
                    ViewRecordsPanel.Show();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "Initialization", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void CloseReadingTextBox_TextChanged(object sender, EventArgs e)
        {
            Calculations();
        }

        private void HelperTextBox_TextChanged(object sender, EventArgs e)
        {



        }
        List<string> helperNames = new List<string>();
        private void AutoSuggestions()
        {
            try
            {



                int unit = UnitBox.SelectedIndex + 1;
                string unitTable = TableMenu.Items[TableMenu.SelectedIndex].ToString();
                string fuel = FuelTypeBox.Items[FuelTypeBox.SelectedIndex].ToString().ToLower();
                string query;
                string type;
                string table;

                using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
                {
                    connection.Open();

                    if (TableMenu.SelectedIndex == TableMenu.Items.Count-1)
                    {
                        type = "Customer";
                        table = $"direct_sale_{fuel}";
                    }
                    else
                    {
                        type = "Helper";
                        table = $"{TableMenu.Items[TableMenu.SelectedIndex]}";
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


        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (SearchTextBox.Text == string.Empty)
            {
                LoadData();
            }
        }

        private void CheckTextBox_TextChanged(object sender, EventArgs e)
        {
            Calculations();

        }

        private void SaveExcelButton_Click(object sender, EventArgs e)
        {
            SaveLedger.SaveDataGridToExcel(Unit1DataGrid, $"Sale Ledger {TableMenu.SelectedItem.ToString()}");
        }

        private void SearchTextBox_OnIconRightClick(object sender, EventArgs e)
        {
            SearchControl();


        }

        private void Unit1DataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == Unit1DataGrid.Rows.Count - 1)
            {
                e.CellStyle.BackColor = Color.Tomato;
            }
        }




        private void Modification(bool check)
        {
            if (check)
            {
                DirectSalePanel.Visible = true;
                DirectSalePanel.BringToFront();
                BalancePanel.Enabled = false;
                BalancePanel.Visible = false;
                /* FuelTypeBox.Enabled = true;*/

                /* UnitBox.Enabled = false;*/

                HelperLabel.Text = "Customer:";
            }
            else if (!check)
            {
                DirectSalePanel.Visible = false;
                SalePanel.Visible = true;
                SalePanel.BringToFront();
                /*FuelTypeBox.Enabled = false;*/

                BalancePanel.Enabled = true;
                BalancePanel.Visible = true;
                /*UnitBox.Enabled = true;*/

                HelperLabel.Text = "Helper:";
            }


        }


        private void DirectQuantityBox_TextChanged(object sender, EventArgs e)
        {
            DirectSaleCal();
        }

        private void FuelTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TableMenu.SelectedIndex != TableMenu.Items.Count - 1)
            {
                Modification(false);

            }
            else if(TableMenu.SelectedIndex == TableMenu.Items.Count - 1)
            {
                Modification(true);

            }

            FuelTypeLabel.Text = $"Direct Sale {FuelTypeBox.SelectedItem}";


            if (TableMenu.SelectedIndex > 4)
            { DirectSalePanel.PanelColor = Color.FromArgb(184, 204, 228); }
            else { DirectSalePanel.PanelColor = Color.FromArgb(240, 147, 124); }
        }

        private void FuelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FuelType.SelectedIndex == 0)
            {
                TableMenu.Items.Clear();
                for (int i = 0; i < PetrolUnits.Length; i++)
                {
                    TableMenu.Items.Add(PetrolUnits[i].ToString());
                    
                }

            }
            else if (FuelType.SelectedIndex == 1)
            {
                TableMenu.Items.Clear();
                for (int i = 0; i < DieselUnits.Length; i++)
                {
                    TableMenu.Items.Add(DieselUnits[i].ToString());
                   
                }
            }
            TableMenu.SelectedIndex = 1;
            TableMenu.SelectedIndex = 0;
           
        }

        private void DirectUnitPBox_TextChanged(object sender, EventArgs e)
        {
            DirectSaleCal();
        }

        private void TableMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            if (TableMenu.SelectedIndex != TableMenu.Items.Count - 1)
            {
                Modification(false);
                SearchByNameRadio.Checked = true;
                SearchByNameRadio.Enabled = true;
            }
            else if(TableMenu.SelectedIndex == TableMenu.Items.Count - 1)
            {
                Modification(true);
                SearchByNameRadio.Checked = false;
                SearchByNameRadio.Enabled = false;
                SearchByRefRadio.Checked = true;
            }
            LoadData();
        }

        private void UpdateData_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void DesKeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Suppress the Enter key
            }
        }

        private void DepositTextBox_TextChanged(object sender, EventArgs e)
        {
            Calculations();
        }

        private void RateTextBox_TextChanged(object sender, EventArgs e)
        {

            Calculations();

        }

        private void UnitBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }





        private void SaleLedger_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void ClearBox()
        {

            CloseReadingTextBox.Text = "0";
            _closeReading = 0;
            CheckTextBox.Text = "0";
            _test = 0;
            AmountTextBox.Text = "0";
            _price = 0;
            RateTextBox.Text = "0";
            _rate = 0;
            NetQuantityTextBox.Text = "0";
            _netQuantity = 0;
            QuantityTextBox.Text = "0";
            _quantity = 0;


            RecoveryTextBox.Text = "0";
            recovery = 0;
            UdharTextBox.Text = "0";
            udhar = 0;
            DepositTextBox.Text = "0";
            deposit = 0;
            DiscountTextBox.Text = "0";
            discount = 0;
            BalanceTB.Text = "0";
            balance = 0;



            dateTimePicker1.Value = DateTime.Now;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            ViewRecordsPanel.Hide();
            ClearBox();
            LoadData();
        }


        private void DirectSaleCal()
        {
            DirectQuantity = AppSettings.convertToDouble(DirectQuantityBox.Text);
            DirectUnitPrice = AppSettings.convertToDouble(DirectUnitPBox.Text);
            DirectAmount = DirectQuantity * DirectUnitPrice;

            DirectAmountBox.Text = AppSettings.RoundToString(DirectAmount, true);
        }

        private void Calculations()
        {



            // Calculations 2 ***************************

            try
            {
                _openReading = AppSettings.convertToDouble(OpenReadingTextBox.Text);
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





            OpenReadingTextBox.Text = AppSettings.RoundToString(_openReading, false);
            QuantityTextBox.Text = AppSettings.RoundToString(_quantity, false);
            NetQuantityTextBox.Text = AppSettings.RoundToString(_netQuantity, false);
            AmountTextBox.Text = AppSettings.RoundToString(_price, true);

            //----------------------------------------------

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




    }
}
