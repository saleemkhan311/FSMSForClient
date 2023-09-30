using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using MySql.Data.MySqlClient;
using System.Text.Json;
using System.Text.RegularExpressions;


namespace Filling_Station_Management_System
{
    public partial class SaleLedger : KryptonForm
    {
        public SaleLedger()
        {
            InitializeComponent();
            LoadData();
            ViewRecordsPanel.Hide();
            this.KeyPreview = true;
            //SetTabStopTrue();
        }

        string Username;

        float recovery, deposit, discount, udhar;
        float balance;
        private float _openReading, _closeReading, _rate, _test, _price, _quantity, _netQuantity, _readCount;
        Double newPrice, newBalance, newQuantity, newNetQuantity;

        string sql;
        private void Query()
        {
            int unit = TabControl.SelectedIndex + 1;
            /* try
             {
 */
            MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
            connection.Open();

            sql = $"UPDATE unit{unit}_sales_data SET Ref_No = @Ref_No,Date=@Date,Fuel_Type=@Fuel_Type,Helper=@Helper,Closing_Reading=@Closing_Reading,Quantity=@Quantity,Test=@Test,netQuantity=@netQuantity,Unit_Price=@Unit_Price,Amount=@Amount,Recovery=@Recovery,Deposited=@Deposited,Udhar=@Udhar,Discount=@Discount,Balance=@Balance WHERE Ref_No=@Ref_No";

            MySqlCommand cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@Ref_No", ConvertFloat(RefTextBox.Text));
            cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Fuel_Type", FuelTypeBox.Text);
            cmd.Parameters.AddWithValue("@Helper", HelperTextBox.Text);


            //cmd.Parameters.AddWithValue("@Opening_Reading", ConvertFloat(OpenReadingTextBox.Text));
            cmd.Parameters.AddWithValue("@Closing_Reading", ConvertFloat(CloseReadingTextBox.Text));
            cmd.Parameters.AddWithValue("@Quantity", newQuantity);
            cmd.Parameters.AddWithValue("@Test", ConvertFloat(CheckTextBox.Text));
            cmd.Parameters.AddWithValue("@netQuantity", newNetQuantity);
            cmd.Parameters.AddWithValue("@Unit_Price", ConvertFloat(RateTextBox.Text));


            cmd.Parameters.AddWithValue("@Amount", newPrice);
            cmd.Parameters.AddWithValue("@Recovery", ConvertFloat(RecoveryTextBox.Text));
            cmd.Parameters.AddWithValue("@Deposited", ConvertFloat(DepositTextBox.Text));
            cmd.Parameters.AddWithValue("@Udhar", ConvertFloat(UdharTextBox.Text));
            cmd.Parameters.AddWithValue("@Discount", ConvertFloat(DepositTextBox.Text));
            cmd.Parameters.AddWithValue("@Balance", newPrice);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Records Updated Successfully");
            UnitBox.SelectedIndex = 0;
            /* }
             catch (Exception ex)
             {
                 MessageBox.Show("Error: " + ex.Message);
             }*/
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SaleLedger_Load(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            int unit = TabControl.SelectedIndex + 1;
            MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
            connection.Open();

            string sql = $"SELECT * FROM unit{unit}_sales_data"; // Add your WHERE clause

            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            Unit1DataGrid.DataSource = dataTable;
            DataGrid2.DataSource = dataTable;
            DataGrid3.DataSource = dataTable;
            DataGrid4.DataSource = dataTable;

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


        private void RecoveryTextBox_TextChanged_1(object sender, EventArgs e)
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

        private void UpdateData_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            Username = main.UsernameLabel.Text;

            if (isFilled() && isFilled2() && isFilledMandatory())
            {

                Query();

            }
            else
            {
                MessageBox.Show("Error: Please Fill All the Fields To Procced");
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

        private string NoNumbers(string value)
        {
            bool isValid = false;

            if (value != string.Empty)
            {

                if (Regex.IsMatch(value, @"^[0-9]*(?:\.[0-9]*)?$"))
                {
                    MessageBox.Show("Invalid Entry");
                    value = "";
                }
                else
                {


                }
            }

            return value;
        }

        string NoAlpha(string value)
        {
            if (value.Any(char.IsLetter))
            {
                MessageBox.Show("Please Enter in Numbers or Select Search by Name");
                return "0";

            }
            else { return value; }
        }

        private void SearchControl()
        {
            try
            {
                string index = (TabControl.SelectedIndex + 1).ToString();

                MySqlConnection con = new MySqlConnection(AppSettings.ConString());
                con.Open();

                MySqlCommand cmd;
                cmd = con.CreateCommand();

                if (SearchByNameRadio.Checked)
                {

                    cmd.CommandText = $"SELECT * FROM unit{index}_sales_data WHERE Helper LIKE" + "'" + NoNumbers(SearchTextBox.Text) + "%'";
                    cmd.Parameters.AddWithValue("@Helper", NoNumbers(SearchTextBox.Text));

                }
                else if (SearchByRefRadio.Checked)
                {

                    cmd.CommandText = $"SELECT * FROM FROM unit{index}_sales_data WHERE Ref_No=@Ref_No";
                    cmd.Parameters.AddWithValue("@Ref_No", NoAlpha(SearchTextBox.Text));
                }
                else
                {
                    MessageBox.Show("Please Select 'Search by Name' Or 'Search by ID' Option ");
                    return;
                }

                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable records = new DataTable();
                records.Load(reader);

                if (TabControl.SelectedIndex == 0)
                {
                    if (records.Rows.Count >= 1)
                    {
                        Unit1DataGrid.DataSource = records;
                    }
                    else
                    {
                        MessageBox.Show("No Records Found");
                        LoadData();
                    }
                }
                else if (TabControl.SelectedIndex == 1)
                {
                    if (records.Rows.Count >= 1)
                    {
                        DataGrid2.DataSource = records;
                    }
                    else
                    {
                        MessageBox.Show("No Records Found");
                        LoadData();
                    }
                }
                else if (TabControl.SelectedIndex == 2)
                {
                    if (records.Rows.Count >= 1)
                    {
                        DataGrid3.DataSource = records;
                    }
                    else
                    {
                        MessageBox.Show("No Records Found");
                        LoadData();
                    }
                }
                else if (TabControl.SelectedIndex == 3)
                {
                    if (records.Rows.Count >= 1)
                    {
                        DataGrid4.DataSource = records;
                    }
                    else
                    {
                        MessageBox.Show("No Records Found");
                        LoadData();
                    }

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Invalid Entry / " + ex.Message, "Invalid Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void DataGrid2DoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            RefTextBox.Text = DataGrid2.SelectedRows[0].Cells[0].Value.ToString();
            object date = DataGrid2.SelectedRows[0].Cells[1].Value;
            FuelTypeBox.Text = DataGrid2.SelectedRows[0].Cells[2].Value.ToString();
            HelperTextBox.Text = DataGrid2.SelectedRows[0].Cells[3].Value.ToString();
            OpenReadingTextBox.Text = DataGrid2.SelectedRows[0].Cells[4].Value.ToString();
            CloseReadingTextBox.Text = DataGrid2.SelectedRows[0].Cells[5].Value.ToString();
            QuantityTextBox.Text = DataGrid2.SelectedRows[0].Cells[6].Value.ToString();
            CheckTextBox.Text = DataGrid2.SelectedRows[0].Cells[7].Value.ToString();
            NetQuantityTextBox.Text = DataGrid2.SelectedRows[0].Cells[8].Value.ToString();
            RateTextBox.Text = DataGrid2.SelectedRows[0].Cells[9].Value.ToString();
            PriceTextBox.Text = DataGrid2.SelectedRows[0].Cells[10].Value.ToString();
            RecoveryTextBox.Text = DataGrid2.SelectedRows[0].Cells[11].Value.ToString();
            DepositTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[12].Value.ToString();
            UdharTextBox.Text = DataGrid2.SelectedRows[0].Cells[13].Value.ToString();
            DiscountTextBox.Text = DataGrid2.SelectedRows[0].Cells[14].Value.ToString();

            BalanceTB.Text = DataGrid2.SelectedRows[0].Cells[15].Value.ToString();

            UnitBox.SelectedIndex = TabControl.SelectedIndex;




            DateTime newDate;
            if (DateTime.TryParse(date.ToString(), out newDate))
            {
                dateTimePicker1.Value = newDate;
            }

            PasswordCheckPanel passCheck = new PasswordCheckPanel();
            passCheck.ShowDialog();
            if (passCheck.DialogResult == DialogResult.OK)
                ViewRecordsPanel.Show();
        }

        private void DataGrid3DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            RefTextBox.Text = DataGrid3.SelectedRows[0].Cells[0].Value.ToString();
            object date = DataGrid3.SelectedRows[0].Cells[1].Value;
            FuelTypeBox.Text = DataGrid3.SelectedRows[0].Cells[2].Value.ToString();
            HelperTextBox.Text = DataGrid3.SelectedRows[0].Cells[3].Value.ToString();
            OpenReadingTextBox.Text = DataGrid3.SelectedRows[0].Cells[4].Value.ToString();
            CloseReadingTextBox.Text = DataGrid3.SelectedRows[0].Cells[5].Value.ToString();
            QuantityTextBox.Text = DataGrid3.SelectedRows[0].Cells[6].Value.ToString();
            CheckTextBox.Text = DataGrid3.SelectedRows[0].Cells[7].Value.ToString();
            NetQuantityTextBox.Text = DataGrid3.SelectedRows[0].Cells[8].Value.ToString();
            RateTextBox.Text = DataGrid3.SelectedRows[0].Cells[9].Value.ToString();
            PriceTextBox.Text = DataGrid3.SelectedRows[0].Cells[10].Value.ToString();
            RecoveryTextBox.Text = DataGrid3.SelectedRows[0].Cells[11].Value.ToString();
            DepositTextBox.Text = DataGrid3.SelectedRows[0].Cells[12].Value.ToString();
            UdharTextBox.Text = DataGrid3.SelectedRows[0].Cells[13].Value.ToString();
            DiscountTextBox.Text = DataGrid3.SelectedRows[0].Cells[14].Value.ToString();

            BalanceTB.Text = DataGrid3.SelectedRows[0].Cells[15].Value.ToString();

            UnitBox.SelectedIndex = TabControl.SelectedIndex;




            DateTime newDate;
            if (DateTime.TryParse(date.ToString(), out newDate))
            {
                dateTimePicker1.Value = newDate;
            }
            PasswordCheckPanel passCheck = new PasswordCheckPanel();
            passCheck.ShowDialog();
            if (passCheck.DialogResult == DialogResult.OK)
                ViewRecordsPanel.Show();
        }



        private void RemoveButton_Click(object sender, EventArgs e)
        {

            int unit = (TabControl.SelectedIndex + 1);
            int ref_No = 0;
            if (unit == 1)
            {
                ref_No = int.Parse(Unit1DataGrid.SelectedRows[0].Cells[0].Value.ToString());
            }
            else if (unit == 2)
            {
                ref_No = int.Parse(DataGrid2.SelectedRows[0].Cells[0].Value.ToString());
            }
            else if (unit == 3)
            {
                ref_No = int.Parse(DataGrid3.SelectedRows[0].Cells[0].Value.ToString());
            }

            try
            {
                if (ref_No >= 1001)
                {
                    MySqlConnection con = new MySqlConnection(AppSettings.ConString());
                    con.Open();
                    MySqlCommand cmd;

                    cmd = con.CreateCommand();

                    cmd.CommandText = $"DELETE FROM unit{unit}_sales_data WHERE Ref_No=@Ref_No;";
                    cmd.Parameters.AddWithValue("@Ref_No", ref_No);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    LoadData();
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
            //MessageBox.Show($"{Unit1DataGrid.SelectedRows[0].Cells[5].Value}");

            RefTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[0].Value.ToString();
            object date = Unit1DataGrid.SelectedRows[0].Cells[1].Value;
            FuelTypeBox.Text = Unit1DataGrid.SelectedRows[0].Cells[2].Value.ToString();
            HelperTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[3].Value.ToString();
            OpenReadingTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[4].Value.ToString();
            CloseReadingTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[5].Value.ToString();
            QuantityTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[6].Value.ToString();
            CheckTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[7].Value.ToString();
            NetQuantityTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[8].Value.ToString();
            RateTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[9].Value.ToString();
            PriceTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[10].Value.ToString();
            RecoveryTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[11].Value.ToString();
            DepositTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[12].Value.ToString();
            UdharTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[13].Value.ToString();
            DiscountTextBox.Text = Unit1DataGrid.SelectedRows[0].Cells[14].Value.ToString();

            BalanceTB.Text = Unit1DataGrid.SelectedRows[0].Cells[15].Value.ToString();

            UnitBox.SelectedIndex = TabControl.SelectedIndex;




            DateTime newDate;
            if (DateTime.TryParse(date.ToString(), out newDate))
            {
                dateTimePicker1.Value = newDate;
            }
            PasswordCheckPanel passCheck = new PasswordCheckPanel();
            passCheck.ShowDialog();
            if (passCheck.DialogResult == DialogResult.OK)
                ViewRecordsPanel.Show();
        }

        void PopulateList()
        {

        }
        private void EditRecords(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CloseReadingTextBox_TextChanged(object sender, EventArgs e)
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
                //CloseReadingTextBox.Text = "0";
            }
        }

        private void HelperTextBox_TextChanged(object sender, EventArgs e)
        {
            AutoSuggestions();
        }
        List<string> helperNames = new List<string>();
        private void AutoSuggestions()
        {
            int unit = TabControl.SelectedIndex + 1;


            using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
            {
                connection.Open();

                // SQL query to retrieve "Helper Name" values
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

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            SearchControl();
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchControl();
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
                //CheckTextBox.Text = "0";
            }
        }

        private void SaveExcelButton_Click(object sender, EventArgs e)
        {
            if (TabControl.SelectedIndex == 0) { SaveLedger.SaveDataGridToExcel(Unit1DataGrid); }
            else if (TabControl.SelectedIndex == 1) { SaveLedger.SaveDataGridToExcel(DataGrid2); }
            else if (TabControl.SelectedIndex == 2) { SaveLedger.SaveDataGridToExcel(DataGrid3); }
            else if (TabControl.SelectedIndex == 3) { SaveLedger.SaveDataGridToExcel(DataGrid4); }
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
                // RateTextBox.Text = "0";
            }
        }

        private void UnitBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DataGrid4DoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            RefTextBox.Text = DataGrid4.SelectedRows[0].Cells[0].Value.ToString();
            object date = DataGrid4.SelectedRows[0].Cells[1].Value;
            FuelTypeBox.Text = DataGrid4.SelectedRows[0].Cells[2].Value.ToString();
            HelperTextBox.Text = DataGrid4.SelectedRows[0].Cells[3].Value.ToString();
            OpenReadingTextBox.Text = DataGrid4.SelectedRows[0].Cells[4].Value.ToString();
            CloseReadingTextBox.Text = DataGrid4.SelectedRows[0].Cells[5].Value.ToString();
            QuantityTextBox.Text = DataGrid4.SelectedRows[0].Cells[6].Value.ToString();
            CheckTextBox.Text = DataGrid4.SelectedRows[0].Cells[7].Value.ToString();
            NetQuantityTextBox.Text = DataGrid4.SelectedRows[0].Cells[8].Value.ToString();
            RateTextBox.Text = DataGrid4.SelectedRows[0].Cells[9].Value.ToString();
            PriceTextBox.Text = DataGrid4.SelectedRows[0].Cells[10].Value.ToString();
            RecoveryTextBox.Text = DataGrid4.SelectedRows[0].Cells[11].Value.ToString();
            DepositTextBox.Text = DataGrid4.SelectedRows[0].Cells[12].Value.ToString();
            UdharTextBox.Text = DataGrid4.SelectedRows[0].Cells[13].Value.ToString();
            DiscountTextBox.Text = DataGrid4.SelectedRows[0].Cells[14].Value.ToString();

            BalanceTB.Text = DataGrid4.SelectedRows[0].Cells[15].Value.ToString();

            UnitBox.SelectedIndex = TabControl.SelectedIndex;



            DateTime newDate;
            if (DateTime.TryParse(date.ToString(), out newDate))
            {
                dateTimePicker1.Value = newDate;
            }

            PasswordCheckPanel passCheck = new PasswordCheckPanel();
            passCheck.ShowDialog();
            if (passCheck.DialogResult == DialogResult.OK)
                ViewRecordsPanel.Show();
        }



        private void SaleLedger_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                SendKeys.Send("{TAB}");
                e.Handled = false;
            }
        }

        private void ClearBox()
        {

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



            dateTimePicker1.Value = DateTime.Now;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            ViewRecordsPanel.Hide();
            ClearBox();
        }

        private bool isFilled()
        {
            return RecoveryTextBox.Text != string.Empty && DepositTextBox.Text != string.Empty && UdharTextBox.Text != string.Empty && DiscountTextBox.Text != string.Empty;
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
                MessageBox.Show("Error: " + ex.Message);
            }

            _openReading = ConvertFloat(OpenReadingTextBox.Text);
            _quantity = _closeReading - _openReading;
            _netQuantity = _quantity - _test;
            _price = _netQuantity * _rate;


            newPrice = Math.Round(_price, 0);
            newQuantity = Math.Round(_quantity, 2);
            newNetQuantity = Math.Round(_netQuantity, 2);

            // OpenReadingTextBox.Text = _openReading.ToString();
            QuantityTextBox.Text = newQuantity.ToString();
            NetQuantityTextBox.Text = newNetQuantity.ToString();
            PriceTextBox.Text = newPrice.ToString();


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
                    MessageBox.Show("Error: " + ex.Message);
                }


                balance = _price + recovery - deposit - udhar - discount;
                newBalance = Math.Round(balance, 0);
                BalanceTB.Text = newBalance.ToString();
            }
        }

        private bool isFilledMandatory()
        {
            return RefTextBox.Text != string.Empty && HelperTextBox.Text != string.Empty;
        }
        private static float ConvertFloat(string value)
        {
            if (float.TryParse(value, out float floatValue))
            {
                return floatValue;
            }
            else
            {
                throw new ArgumentException("Invalid Input: Not a Valid Entry");
            }


        }

        public static string FloatToString(float value, int decimalPlaces)
        {
            return value.ToString($"F{decimalPlaces}");
        }

    }
}
