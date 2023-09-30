using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using ComponentFactory.Krypton.Toolkit;
using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
using OfficeOpenXml;


namespace Filling_Station_Management_System
{
    public partial class PurchaseLedger : KryptonForm
    {
        Double kantaWazan, sharah, miqdar, Khoraki, saafiMiqdar, ratePerLiter, totalAmount, labour, saafiRaqam, sabqaBaqaya, Amount, Remainings;

        Double[] sharahPetrol = { 0.725, 0.726, 0.727, 0.728, 0.729, 0.730 };
        Double[] sharahDiesel = { 0.800, 0.801, 0.802, 0.803, 0.804, 0.805, 0.806, 0.807, 0.808, 0.809, 0.810 };
        public PurchaseLedger()
        {
            InitializeComponent();


        }



        private void DieselDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            viewDataDiesel();

        }

        private void PetrolDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            viewDataPetrol();
        }

        private void WeightBox_TextChanged(object sender, EventArgs e)
        {

            if (Validation(WeightBox.Text))
            {
                kantaWazan = Double.Parse(WeightBox.Text);
                sharah = Double.Parse(SharahBox.Text);
                miqdar = kantaWazan / sharah;

                QuantityBox.Text = RoundToString(miqdar);

            }
        }

        private void LoadData()
        {
            try
            {

                string index = TabControl.SelectedTab.Text;
                index.ToLower();


                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                string sql = $"SELECT * FROM purchase_data_{index}"; // Add your WHERE clause

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                System.Data.DataTable dataTable = new System.Data.DataTable();
                adapter.Fill(dataTable);
                if (TabControl.SelectedIndex == 1)
                {
                    DieselDataGrid.DataSource = dataTable;
                }
                else if (TabControl.SelectedIndex == 0)
                {
                    PetrolDataGrid.DataSource = dataTable;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: ", "Load Data Purchase Ledger" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SharahBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Validation(WeightBox.Text))
            {
                kantaWazan = Math.Round(Convert.ToDouble(WeightBox.Text), 0);
                sharah = Math.Round(Convert.ToDouble(SharahBox.Text), 0);
                miqdar = kantaWazan / sharah;

                QuantityBox.Text = RoundToString(miqdar);

            }
        }

        private void KhorakiBox_TextChanged(object sender, EventArgs e)
        {
            if (Validation(KhorakiBox.Text) && Validation(WeightBox.Text))
            {
                Khoraki = Math.Round(Convert.ToDouble(KhorakiBox.Text), 2);
                saafiMiqdar = miqdar - Khoraki;
                NetQuantityBox.Text = RoundToString(saafiMiqdar);
            }
        }

        private void RateBox_TextChanged(object sender, EventArgs e)
        {
            if (Validation(RateBox.Text) && Validation(NetQuantityBox.Text))
            {
                ratePerLiter = Math.Round(Convert.ToDouble(RateBox.Text), 2);

                Amount = saafiMiqdar * ratePerLiter;
                AmountBox.Text = RoundToString(Amount);
            }
        }

        private void LabourBox_TextChanged(object sender, EventArgs e)
        {
            if (Validation(LabourBox.Text) && Validation(AmountBox.Text))
            {
                labour = Math.Round(Convert.ToDouble(LabourBox.Text), 2);

                saafiRaqam = Amount - labour;
                NetPriceBox.Text = RoundToString(saafiRaqam);
            }
        }

        private void RecoveryAmountBox1_TextChanged(object sender, EventArgs e)
        {
            Double sum = 0;

            // Loop through the first five TextBoxes and add their values if they are valid numbers
            foreach (Bunifu.UI.WinForms.BunifuTextBox textBox in new[] { RecoveryAmountBox1, RecoveryAmountBox2, RecoveryAmountBox3, RecoveryAmountBox4, RecoveryAmountBox5 })
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text) && Double.TryParse(textBox.Text, out double value))
                {
                    sum += value;
                }
            }

            // Update the value of the sixth TextBox with the calculated sum
            RemainingAmountBox.Text = RoundToString(totalAmount - sum);
        }

        private void RecoveryAmountBox2_TextChanged(object sender, EventArgs e)
        {
            Double sum = 0;

            // Loop through the first five TextBoxes and add their values if they are valid numbers
            foreach (Bunifu.UI.WinForms.BunifuTextBox textBox in new[] { RecoveryAmountBox1, RecoveryAmountBox2, RecoveryAmountBox3, RecoveryAmountBox4, RecoveryAmountBox5 })
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text) && Double.TryParse(textBox.Text, out double value))
                {
                    sum += value;
                }
            }

            // Update the value of the sixth TextBox with the calculated sum
            RemainingAmountBox.Text = RoundToString(totalAmount - sum);
        }

        private void RecoveryAmountBox3_TextChanged(object sender, EventArgs e)
        {
            Double sum = 0;

            // Loop through the first five TextBoxes and add their values if they are valid numbers
            foreach (Bunifu.UI.WinForms.BunifuTextBox textBox in new[] { RecoveryAmountBox1, RecoveryAmountBox2, RecoveryAmountBox3, RecoveryAmountBox4, RecoveryAmountBox5 })
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text) && Double.TryParse(textBox.Text, out double value))
                {
                    sum += value;
                }
            }

            // Update the value of the sixth TextBox with the calculated sum
            RemainingAmountBox.Text = RoundToString(totalAmount - sum);
        }

        private void RecoveryAmountBox4_TextChanged(object sender, EventArgs e)
        {
            Double sum = 0;

            // Loop through the first five TextBoxes and add their values if they are valid numbers
            foreach (Bunifu.UI.WinForms.BunifuTextBox textBox in new[] { RecoveryAmountBox1, RecoveryAmountBox2, RecoveryAmountBox3, RecoveryAmountBox4, RecoveryAmountBox5 })
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text) && Double.TryParse(textBox.Text, out double value))
                {
                    sum += value;
                }
            }

            // Update the value of the sixth TextBox with the calculated sum
            RemainingAmountBox.Text = RoundToString(totalAmount - sum);
        }

        private void RecoveryAmountBox5_TextChanged(object sender, EventArgs e)
        {
            Double sum = 0;

            // Loop through the first five TextBoxes and add their values if they are valid numbers
            foreach (Bunifu.UI.WinForms.BunifuTextBox textBox in new[] { RecoveryAmountBox1, RecoveryAmountBox2, RecoveryAmountBox3, RecoveryAmountBox4, RecoveryAmountBox5 })
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text) && Double.TryParse(textBox.Text, out double value))
                {
                    sum += value;
                }
            }

            // Update the value of the sixth TextBox with the calculated sum
            RemainingAmountBox.Text = RoundToString(totalAmount - sum);
        }

        private void UpdateData_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void Query()
        {
            try
            {


                string index = FuelTypeBox.Items[FuelTypeBox.SelectedIndex].ToString();
                index.ToLower();

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();
                string sql = $"UPDATE purchase_data_{index} SET Ref_No=@Ref_No,Date=@Date,Fuel_Type=@Fuel_Type,Sharah=@Sharah,Malik_Name=@Malik_Name,Kanta_Wazan=@Kanta_Wazan,Miqdar=@Miqdar,Khoraki=@Khoraki,Saafi_Miqdar=@Saafi_Miqdar,Rate_per_Liter=@Rate_per_Liter,Amount=@Amount,Kharcha_Mazdoori=@Kharcha_Mazdoori,Saafi_Raqam=@Saafi_Raqam,Sabqa_Baqaya=@Sabqa_Baqaya,Total_Amount=@Total_Amount,Amount_Paid_1=@Amount_Paid_1,Description_Details_1=@Description_Details_1,Amount_Paid_2=@Amount_Paid_2,Description_Details_2=@Description_Details_2,Amount_Paid_3=@Amount_Paid_3,Description_Details_3=@Description_Details_3,Amount_Paid_4=@Amount_Paid_4,Description_Details_4=@Description_Details_4,Amount_Paid_5=@Amount_Paid_5,Description_Details_5=@Description_Details_5,Baqaya=@Baqaya WHERE Ref_No=@Ref_No";

                MySqlCommand cmd = new MySqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@Ref_No", Convert.ToInt16(RefTextBox.Text));
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Fuel_Type", FuelTypeBox.Text);
                cmd.Parameters.AddWithValue("@Sharah", SharahBox.Text);
                cmd.Parameters.AddWithValue("@Malik_Name", NameTextBox.Text);


                cmd.Parameters.AddWithValue("@Kanta_Wazan", kantaWazan);
                cmd.Parameters.AddWithValue("@Miqdar", miqdar);
                cmd.Parameters.AddWithValue("@Khoraki", Khoraki);
                cmd.Parameters.AddWithValue("@Saafi_Miqdar", saafiMiqdar);
                cmd.Parameters.AddWithValue("@Rate_per_Liter", ratePerLiter);


                cmd.Parameters.AddWithValue("@Amount", Amount);
                cmd.Parameters.AddWithValue("@Kharcha_Mazdoori", labour);
                cmd.Parameters.AddWithValue("@Saafi_Raqam", saafiRaqam);
                cmd.Parameters.AddWithValue("@Sabqa_Baqaya", sabqaBaqaya);
                cmd.Parameters.AddWithValue("@Total_Amount", totalAmount);
                cmd.Parameters.AddWithValue("@Amount_Paid_1", RecoveryAmountBox1.Text);
                cmd.Parameters.AddWithValue("@Description_Details_1", RecoveryDescriptionBox1.Text);

                cmd.Parameters.AddWithValue("@Amount_Paid_2", RecoveryAmountBox2.Text);
                cmd.Parameters.AddWithValue("@Description_Details_2", RecoveryDescriptionBox2.Text);

                cmd.Parameters.AddWithValue("@Amount_Paid_3", RecoveryAmountBox3.Text);
                cmd.Parameters.AddWithValue("@Description_Details_3", RecoveryDescriptionBox3.Text);

                cmd.Parameters.AddWithValue("@Amount_Paid_4", RecoveryAmountBox4.Text);
                cmd.Parameters.AddWithValue("@Description_Details_4", RecoveryDescriptionBox4.Text);

                cmd.Parameters.AddWithValue("@Amount_Paid_5", RecoveryAmountBox5.Text);
                cmd.Parameters.AddWithValue("@Description_Details_5", RecoveryDescriptionBox5.Text);

                cmd.Parameters.AddWithValue("@Baqaya", RemainingAmountBox.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Records Updated Successfully", "Query Purchase Ledger", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: ", "Quer Purchase Ledger" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (DieselDataGrid.Rows.Count > 1)
                AutoSuggestions();
        }

        List<string> NameSuggestions = new List<string>();
        private void AutoSuggestions()
        {
            string index = FuelTypeBox.Items[FuelTypeBox.SelectedIndex].ToString();
            index.ToLower();
            try
            {
                using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
                {
                    connection.Open();

                    // SQL query to retrieve "Helper Name" values
                    string query = $"SELECT `Malik_Name` FROM purchase_data_{index}";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string Names = reader["Malik_Name"].ToString();
                                NameSuggestions.Add(Names);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: ", "Auto Suggest Purchase Ledger" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
            autoCompleteCollection.AddRange(NameSuggestions.ToArray());

            NameTextBox.AutoCompleteCustomSource = autoCompleteCollection;
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            Search();
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


        private void Search()
        {

            try
            {
                string index = TabControl.SelectedTab.Text;

                MySqlConnection con = new MySqlConnection(AppSettings.ConString());
                con.Open();

                MySqlCommand cmd;
                cmd = con.CreateCommand();

                if (SearchByNameRadio.Checked)
                {
                    cmd.CommandText = $"SELECT * FROM purchase_data_{index} WHERE Malik_Name LIKE" + "'" + NoNumbers(SearchTextBox.Text) + "%'";
                    cmd.Parameters.AddWithValue("@Malik_Name", NoNumbers(SearchTextBox.Text));

                }
                else if (SearchByRefRadio.Checked)
                {
                    cmd.CommandText = $"SELECT * FROM FROM purchase_data_{index} WHERE Ref_No=@Ref_No";
                    cmd.Parameters.AddWithValue("@Ref_No", NoAlpha(SearchTextBox.Text));
                }
                else
                {
                    MessageBox.Show("Please Select 'Search by Name' Or 'Search by ID' Option ");
                }

                MySqlDataReader reader = cmd.ExecuteReader();
                System.Data.DataTable records = new System.Data.DataTable();
                records.Load(reader);

                if (TabControl.SelectedIndex == 0)
                {
                    if (records.Rows.Count >= 1)
                    {
                        PetrolDataGrid.DataSource = records;
                    }
                    else
                    {
                        MessageBox.Show("No Records Found");
                        LoadData();
                    }
                }
                else
                {
                    if (records.Rows.Count >= 1)
                    {
                        DieselDataGrid.DataSource = records;
                    }
                    else
                    {
                        MessageBox.Show("No Records Found");
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Invalid Entry / ", "Search Purchase Ledger" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            string name = TabControl.SelectedTab.Text.ToLower();
            int ref_No = 0;
            if (TabControl.SelectedIndex == 0)
            {
                ref_No = int.Parse(PetrolDataGrid.SelectedRows[0].Cells[0].Value.ToString());
            }
            else if (TabControl.SelectedIndex == 1)
            {
                ref_No = int.Parse(DieselDataGrid.SelectedRows[0].Cells[0].Value.ToString());
            }


            try
            {
                if (ref_No >= 1001)
                {
                    try
                    {
                        MySqlConnection con = new MySqlConnection(AppSettings.ConString());
                        con.Open();
                        MySqlCommand cmd;

                        cmd = con.CreateCommand();

                        cmd.CommandText = $"DELETE FROM purchase_data_{name} WHERE Ref_No=@Ref_No;";
                        cmd.Parameters.AddWithValue("@Ref_No", ref_No);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        LoadData();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error: ", "Remove Purhcase Ledger" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void GenerateReceipt_Click(object sender, EventArgs e)
        {
            ReceiptPanel receipt = new ReceiptPanel();

            receipt.ref_no = RefTextBox.Text;

            receipt.DateTime = dateTimePicker1.Value.ToString("d");

            receipt.malikName = NameTextBox.Text;
            receipt.wazan = WeightBox.Text;
            receipt.miqdar = QuantityBox.Text;
            receipt.khoraki = KhorakiBox.Text;
            receipt.safiMiqdar = NetQuantityBox.Text;
            receipt.rateFiLiter = RateBox.Text;
            receipt.kulRaqam = AmountBox.Text;
            receipt.mazdoori = LabourBox.Text;
            receipt.safiRaqam = NetPriceBox.Text;
            receipt.sabqaRaqam = SabqaRaqamBox.Text;
            receipt.totalRaqam = TotalRaqamBox.Text;

            receipt.raqamWasoolValue1 = RecoveryAmountBox1.Text;
            receipt.raqamWasoolTafseel1 = RecoveryDescriptionBox1.Text;

            receipt.raqamWasoolValue2 = RecoveryAmountBox2.Text;
            receipt.raqamWasoolTafseel2 = RecoveryDescriptionBox2.Text;

            receipt.raqamWasoolValue3 = RecoveryAmountBox3.Text;
            receipt.raqamWasoolTafseel3 = RecoveryDescriptionBox3.Text;

            receipt.raqamWasoolValue4 = RecoveryAmountBox4.Text;
            receipt.raqamWasoolTafseel4 = RecoveryDescriptionBox4.Text;

            receipt.raqamWasoolValue5 = RecoveryAmountBox5.Text;
            receipt.raqamWasoolTafseel5 = RecoveryDescriptionBox5.Text;


            receipt.baqaya = RemainingAmountBox.Text;


            receipt.ShowDialog();

        }



        private void PurchaseLedger_Enter(object sender, EventArgs e)
        {
            /* printPreviewDialog.Dispose(); // Close the existing dialog
             printPreviewDialog = new PrintPreviewDialog(); // Create a new dialog
             printPreviewDialog.Document = printDocument; // Set the document to the new dialog
             printPreviewDialog.ShowDialog(); // Show the new dialog*/
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadData();
        }

        private void PurchaseLedger_Load(object sender, EventArgs e)
        {
            LoadData();
            SearchByNameRadio.Checked = true;
            ViewRecordsPanel.Hide();

        }



        private void SaveExcelButton_Click(object sender, EventArgs e)
        {

            if (TabControl.SelectedIndex == 0)
            {
                SaveLedger.SaveDataGridToExcel(PetrolDataGrid);
            }
            else if (TabControl.SelectedIndex == 1) { SaveLedger.SaveDataGridToExcel(DieselDataGrid); }




        }





        private bool scrolling = false;

        private void autoScroll(object sender)
        {
            if (sender is Bunifu.UI.WinForms.BunifuTextBox textBox)
            {
                // Calculate the position of the TextBox relative to the FlowLayoutControl
                System.Drawing.Point textBoxLocation = textBox.Parent.PointToScreen(textBox.Location);
                System.Drawing.Point flowLayoutLocation = flowLayoutPanel1.PointToScreen(System.Drawing.Point.Empty);
                int verticalScrollAmount = textBoxLocation.Y - flowLayoutLocation.Y;

                // Scroll the FlowLayoutControl gradually if the TextBox is not fully visible
                if (verticalScrollAmount < 0 || verticalScrollAmount + textBox.Height > flowLayoutPanel1.ClientRectangle.Height)
                {
                    scrolling = true; // Set scrolling flag to prevent reentrancy
                    int currentScrollPosition = flowLayoutPanel1.VerticalScroll.Value;
                    int targetScrollPosition = currentScrollPosition + verticalScrollAmount;

                    // Adjust the scroll speed by changing the step size
                    int stepSize = 30; // Increase this value for faster scrolling

                    // Start a timer to animate the scrolling
                    Timer scrollTimer = new Timer();
                    scrollTimer.Interval = 1; // Keep a small interval for smoothness
                    scrollTimer.Tick += (senderTimer, eTimer) =>
                    {
                        if (currentScrollPosition < targetScrollPosition)
                        {
                            currentScrollPosition += stepSize;
                            if (currentScrollPosition >= targetScrollPosition)
                            {
                                currentScrollPosition = targetScrollPosition;
                                scrollTimer.Stop();
                                scrolling = false; // Reset scrolling flag
                            }
                            flowLayoutPanel1.VerticalScroll.Value = currentScrollPosition;
                        }
                        else if (currentScrollPosition > targetScrollPosition)
                        {
                            currentScrollPosition -= stepSize;
                            if (currentScrollPosition <= targetScrollPosition)
                            {
                                currentScrollPosition = targetScrollPosition;
                                scrollTimer.Stop();
                                scrolling = false; // Reset scrolling flag
                            }
                            flowLayoutPanel1.VerticalScroll.Value = currentScrollPosition;
                        }
                        else
                        {
                            scrollTimer.Stop();
                            scrolling = false; // Reset scrolling flag
                        }
                    };

                    scrollTimer.Start();
                }
            }
        }

        private void RateBox_Enter(object sender, EventArgs e)
        {

        }

        private void viewDataPetrol()
        {
            RefTextBox.Text = PetrolDataGrid.SelectedRows[0].Cells[0].Value.ToString();
            object date = PetrolDataGrid.SelectedRows[0].Cells[1].Value;
            FuelTypeBox.Text = PetrolDataGrid.SelectedRows[0].Cells[2].Value.ToString();
            SharahAssign();
            SharahBox.Text = PetrolDataGrid.SelectedRows[0].Cells[3].Value.ToString();

            NameTextBox.Text = PetrolDataGrid.SelectedRows[0].Cells[4].Value.ToString();
            WeightBox.Text = PetrolDataGrid.SelectedRows[0].Cells[5].Value.ToString();
            QuantityBox.Text = PetrolDataGrid.SelectedRows[0].Cells[6].Value.ToString();
            KhorakiBox.Text = PetrolDataGrid.SelectedRows[0].Cells[7].Value.ToString();
            NetQuantityBox.Text = PetrolDataGrid.SelectedRows[0].Cells[8].Value.ToString();
            RateBox.Text = PetrolDataGrid.SelectedRows[0].Cells[9].Value.ToString();
            AmountBox.Text = PetrolDataGrid.SelectedRows[0].Cells[10].Value.ToString();
            LabourBox.Text = PetrolDataGrid.SelectedRows[0].Cells[11].Value.ToString();

            NetPriceBox.Text = PetrolDataGrid.SelectedRows[0].Cells[12].Value.ToString();
            SabqaRaqamBox.Text = PetrolDataGrid.SelectedRows[0].Cells[13].Value.ToString();
            TotalRaqamBox.Text = PetrolDataGrid.SelectedRows[0].Cells[14].Value.ToString();

            RecoveryAmountBox1.Text = PetrolDataGrid.SelectedRows[0].Cells[15].Value.ToString();
            RecoveryDescriptionBox1.Text = PetrolDataGrid.SelectedRows[0].Cells[16].Value.ToString();

            RecoveryAmountBox2.Text = PetrolDataGrid.SelectedRows[0].Cells[17].Value.ToString();
            RecoveryDescriptionBox2.Text = PetrolDataGrid.SelectedRows[0].Cells[18].Value.ToString();

            RecoveryAmountBox3.Text = PetrolDataGrid.SelectedRows[0].Cells[19].Value.ToString();
            RecoveryDescriptionBox3.Text = PetrolDataGrid.SelectedRows[0].Cells[20].Value.ToString();

            RecoveryAmountBox4.Text = PetrolDataGrid.SelectedRows[0].Cells[21].Value.ToString();
            RecoveryDescriptionBox4.Text = PetrolDataGrid.SelectedRows[0].Cells[22].Value.ToString();

            RecoveryAmountBox5.Text = PetrolDataGrid.SelectedRows[0].Cells[23].Value.ToString();
            RecoveryDescriptionBox5.Text = PetrolDataGrid.SelectedRows[0].Cells[24].Value.ToString();

            RemainingAmountBox.Text = PetrolDataGrid.SelectedRows[0].Cells[25].Value.ToString();

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

        private void viewDataDiesel()
        {
            RefTextBox.Text = DieselDataGrid.SelectedRows[0].Cells[0].Value.ToString();
            object date = DieselDataGrid.SelectedRows[0].Cells[1].Value;
            FuelTypeBox.Text = DieselDataGrid.SelectedRows[0].Cells[2].Value.ToString();
            SharahAssign();
            SharahBox.Text = DieselDataGrid.SelectedRows[0].Cells[3].Value.ToString();
            NameTextBox.Text = DieselDataGrid.SelectedRows[0].Cells[4].Value.ToString();
            WeightBox.Text = DieselDataGrid.SelectedRows[0].Cells[5].Value.ToString();
            QuantityBox.Text = DieselDataGrid.SelectedRows[0].Cells[6].Value.ToString();
            KhorakiBox.Text = DieselDataGrid.SelectedRows[0].Cells[7].Value.ToString();
            NetQuantityBox.Text = DieselDataGrid.SelectedRows[0].Cells[8].Value.ToString();
            RateBox.Text = DieselDataGrid.SelectedRows[0].Cells[9].Value.ToString();
            AmountBox.Text = DieselDataGrid.SelectedRows[0].Cells[10].Value.ToString();
            LabourBox.Text = DieselDataGrid.SelectedRows[0].Cells[11].Value.ToString();

            NetPriceBox.Text = DieselDataGrid.SelectedRows[0].Cells[12].Value.ToString();
            SabqaRaqamBox.Text = DieselDataGrid.SelectedRows[0].Cells[13].Value.ToString();
            TotalRaqamBox.Text = DieselDataGrid.SelectedRows[0].Cells[14].Value.ToString();

            RecoveryAmountBox1.Text = DieselDataGrid.SelectedRows[0].Cells[15].Value.ToString();
            RecoveryDescriptionBox1.Text = DieselDataGrid.SelectedRows[0].Cells[16].Value.ToString();

            RecoveryAmountBox2.Text = DieselDataGrid.SelectedRows[0].Cells[17].Value.ToString();
            RecoveryDescriptionBox2.Text = DieselDataGrid.SelectedRows[0].Cells[18].Value.ToString();

            RecoveryAmountBox3.Text = DieselDataGrid.SelectedRows[0].Cells[19].Value.ToString();
            RecoveryDescriptionBox3.Text = DieselDataGrid.SelectedRows[0].Cells[20].Value.ToString();

            RecoveryAmountBox4.Text = DieselDataGrid.SelectedRows[0].Cells[21].Value.ToString();
            RecoveryDescriptionBox4.Text = DieselDataGrid.SelectedRows[0].Cells[22].Value.ToString();

            RecoveryAmountBox5.Text = DieselDataGrid.SelectedRows[0].Cells[23].Value.ToString();
            RecoveryDescriptionBox5.Text = DieselDataGrid.SelectedRows[0].Cells[24].Value.ToString();

            RemainingAmountBox.Text = DieselDataGrid.SelectedRows[0].Cells[25].Value.ToString();

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

        private void SabqaRaqamBox_TextChanged(object sender, EventArgs e)
        {
            if (Validation(SabqaRaqamBox.Text) && Validation(NetPriceBox.Text))
            {
                sabqaBaqaya = Math.Round(Convert.ToDouble(SabqaRaqamBox.Text), 2);

                totalAmount = saafiRaqam + sabqaBaqaya;
                TotalRaqamBox.Text = RoundToString(totalAmount);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            ViewRecordsPanel.Hide();
        }
        private void SharahAssign()
        {
            SharahBox.Items.Clear();
            if (FuelTypeBox.Text == "Petrol")
            {
                for (int i = 0; i < sharahPetrol.Length; i++)
                {
                    SharahBox.Items.Add(sharahPetrol[i]);
                }
            }
            else if (FuelTypeBox.Text == "Diesel")
            {
                for (int i = 0; i < sharahDiesel.Length; i++)
                {
                    SharahBox.Items.Add(sharahDiesel[i]);
                }
            }
        }

        string RoundToString(Double value)
        {
            return Math.Round(value, 0).ToString();
        }

        private bool Validation(string value)
        {
            bool isValid = false;

            if (value != string.Empty)
            {

                if (Regex.IsMatch(value, @"^[0-9]*(?:\.[0-9]*)?$"))
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                    MessageBox.Show("Invalid Entry");
                }
            }

            return isValid;
        }




        private float GetTextWidth(string text, System.Drawing.Font font)
        {
            using (Graphics g = Graphics.FromImage(new Bitmap(1, 1)))
            {
                return g.MeasureString(text, font).Width;
            }
        }


    }
}
