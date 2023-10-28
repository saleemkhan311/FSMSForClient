using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using ComponentFactory.Krypton.Toolkit;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Filling_Station_Management_System
{
    public partial class EnteryPurchase : KryptonForm
    {

        Double kantaWazan, sharah, miqdar, Khoraki, saafiMiqdar, ratePerLiter, totalAmount, saafiRaqam, sabqaBaqaya, Amount, Remainings, labour;

        Double[] sharahPetrol = { 0.725, 0.726, 0.727, 0.728, 0.729, 0.730 };
        Double[] sharahDiesel = { 0.800, 0.801, 0.802, 0.803, 0.804, 0.805, 0.806, 0.807, 0.808, 0.809, 0.810 };
        private bool StockAdded = false;

        //----------------------------------
        private double availableStock, availableAmount, availableUnitPrice;
        private double newStock, newStockAmount, newUnitPrice;
        private double lastStock, lastStockAmount, lastUnitPrice;
        //-----------------------------------------------





        public EnteryPurchase()
        {
            InitializeComponent();
            FuelTypeBox.SelectedIndex = 0;
        }

        #region RecveryAmountBox

        private void RecoveryAmountBox1_TextChanged(object sender, EventArgs e)
        {
            Calculate();

        }

        private void RemainingAmountBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void RecoveryAmountBox2_TextChanged(object sender, EventArgs e)
        {
            Calculate();

        }

        private void RecoveryAmountBox3_TextChanged(object sender, EventArgs e)
        {
            Calculate();

        }

        private void RecoveryAmountBox4_TextChanged(object sender, EventArgs e)
        {
            Calculate();


        }

        private void RecoveryAmountBox5_TextChanged(object sender, EventArgs e)
        {
            Calculate();

        }
        #endregion
        private void GenerateReceipt_Click(object sender, EventArgs e)
        {
            if (isFilledAll())
            {
                ReceiptPanel receipt = new ReceiptPanel();

                receipt.ref_no = RefTextBox.Text;

                receipt.DateTimeValue = dateTimePicker1.Value.ToString("d");

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
            else { MessageBox.Show("Please Fill The Necessory Boxes to Continue", "Generate Reciept", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }



        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {


        }

        List<string> NameSuggestions = new List<string>();
        private void AutoSuggestions()
        {
            try
            {
                string index = FuelTypeBox.Items[FuelTypeBox.SelectedIndex].ToString();
                index.ToLower();

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
                AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
                autoCompleteCollection.AddRange(NameSuggestions.ToArray());

                NameTextBox.AutoCompleteCustomSource = autoCompleteCollection;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Helper Fetch Purchase", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LabourBox_Enter(object sender, EventArgs e)
        {
            autoScroll(LabourBox);
        }



        private void RecoveryAmountBox2_Enter(object sender, EventArgs e)
        {
            autoScroll(RecoveryAmountBox2);
        }

        private void RecoveryAmountBox5_Enter(object sender, EventArgs e)
        {
            autoScroll(RecoveryAmountBox5);
        }

        private void EnteryPurchase_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
            }
        }

        private void RecoveryAmountBox4_Enter(object sender, EventArgs e)
        {
            autoScroll(RecoveryAmountBox4);
        }

        private void TotalAmountBox_TextChanged(object sender, EventArgs e)
        {

        }

        bool isFilled;
        bool isFilledAll()
        {

            if (KhorakiBox.Text == string.Empty)
            {
                KhorakiBox.Text = "";
            }
            else if (LabourBox.Text == string.Empty) { LabourBox.Text = "0"; }
            foreach (Bunifu.UI.WinForms.BunifuTextBox textBox in new[] { RefTextBox, WeightBox, NameTextBox, QuantityBox, NetQuantityBox, RateBox, AmountBox, NetQuantityBox, NetPriceBox, SabqaRaqamBox, RecoveryAmountBox1 })
            {
                if (textBox.Text != string.Empty)
                {
                    isFilled = true;
                }
                else
                {

                    isFilled = false;

                }
            }
            return isFilled;
        }

        private void InsertData_Click(object sender, EventArgs e)
        {

            if (StockAdded)
            {
                Query();
                ClearBox();
                StockAdded = false;
                FuelTypeBox.Enabled = true;
            }

            else { MessageBox.Show("Please Add the Stock to Continue"); }

            /* if (FuelTypeBox.SelectedIndex == 0)
             {
                 StockForm stock = new StockForm();

                 stock.RemoteQureyPetrol();
                 stock.Dispose();
             }
             else if (FuelTypeBox.SelectedIndex == 1)
             {
                 StockForm stock = new StockForm();

                 stock.RemoteQuerryDiesel();
                 stock.Dispose();
             }*/
            // ClearBox();

        }

        private void KhorakiBox_TextChanged(object sender, EventArgs e)
        {


            /*Khoraki = AppSettings.convertToDouble(KhorakiBox.Text);
            saafiMiqdar = miqdar - Khoraki;
            NetQuantityBox.Text = AppSettings.RoundToString(saafiMiqdar, 2);*/
            Calculate();

        }

        private void Calculate()
        {

            kantaWazan = AppSettings.convertToDouble(WeightBox.Text);
            sharah = AppSettings.convertToDouble(SharahListBox.Items[SharahListBox.SelectedIndex].ToString());
            miqdar = kantaWazan == 0 ? 0 : kantaWazan / sharah;

            QuantityBox.Text = AppSettings.RoundToString(miqdar, false);





            Khoraki = AppSettings.convertToDouble(KhorakiBox.Text);


            saafiMiqdar = miqdar - Khoraki;
            NetQuantityBox.Text = AppSettings.RoundToString(saafiMiqdar, false);

            NewStockBoxD.Text = saafiMiqdar == 0 ? "" : AppSettings.RoundToString(saafiMiqdar, false);


            ratePerLiter = AppSettings.convertToDouble(RateBox.Text);

            NewRateBoxD.Text = ratePerLiter == 0 ? "" : AppSettings.RoundToString(ratePerLiter, true);

            Amount = saafiMiqdar * ratePerLiter;
            AmountBox.Text = AppSettings.RoundToString(Amount, true);
            NewAmountBoxD.Text = Amount == 0 ? "" : AppSettings.RoundToString(Amount, true);


            labour = AppSettings.convertToDouble(LabourBox.Text);




            saafiRaqam = Amount - labour;
            NetPriceBox.Text = saafiRaqam == 0 ? "" : AppSettings.RoundToString(saafiRaqam, true);






            sabqaBaqaya = AppSettings.convertToDouble(SabqaRaqamBox.Text);

            totalAmount = saafiRaqam + sabqaBaqaya;
            TotalRaqamBox.Text = AppSettings.RoundToString(totalAmount, true);

            totalAmount = saafiRaqam + sabqaBaqaya;
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
            Remainings = totalAmount - sum;

            RemainingAmountBox.Text = AppSettings.RoundToString(Remainings, true);

        }

        private void PreviousAmountBox_TextChanged(object sender, EventArgs e)
        {
            Calculate();
            /*if (Validation(SabqaRaqamBox.Text) && Validation(NetPriceBox.Text))
            {
                sabqaBaqaya = Math.Round(Convert.ToDouble(SabqaRaqamBox.Text), 2);

                totalAmount = saafiRaqam + sabqaBaqaya;
                TotalRaqamBox.Text = AppSettings.RoundToString(totalAmount, 0, true);
            }*/
        }

        private void TotalPriceBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LabourBox_TextChanged(object sender, EventArgs e)
        {
            Calculate();
            /*if (Validation(LabourBox.Text) && Validation(AmountBox.Text))
            {
                labour = Math.Round(Convert.ToDouble(LabourBox.Text), 2);

                saafiRaqam = Amount - labour;
                NetPriceBox.Text = AppSettings.RoundToString(saafiRaqam, 0, true);
            }*/
        }

        private void RateBox_TextChanged(object sender, EventArgs e)
        {
            Calculate();
            /*if (Validation(RateBox.Text) && Validation(NetQuantityBox.Text))
            {
                ratePerLiter = Math.Round(Convert.ToDouble(RateBox.Text), 2);

                Amount = saafiMiqdar * ratePerLiter;
                AmountBox.Text = AppSettings.RoundToString(Amount, 0);
            }*/
        }

        private void QuantityBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void InsertData_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void NameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TurnDownButton_Click(object sender, EventArgs e)
        {
            lastStock = AppSettings.convertToDouble(AvailableStockBoxD.Text.Replace("Rs", ""));
            lastUnitPrice = AppSettings.convertToDouble(AvailableRateBoxD.Text.Replace("Rs", ""));
            lastStockAmount = AppSettings.convertToDouble(AvailableAmountBoxD.Text.Replace("Rs", ""));

            AvailableStockBoxD.Clear();
            AvailableRateBoxD.Clear();
            AvailableAmountBoxD.Clear();

            LastStockBoxD.Text = lastStock == 0 ? "" : AppSettings.RoundToString(lastStock, false);
            LastRateBoxD.Text = lastStock == 0 ? "" : AppSettings.RoundToString(lastUnitPrice, true);
            LastAmountBoxD.Text = lastStock == 0 ? "" : AppSettings.RoundToString(lastStockAmount, true);

            EntryList.Enabled = true;
            FuelTypeBox.Enabled = false;
        }

        private void DesKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Suppress the Enter key
            }
        }

        private void AddStockButton_Click(object sender, EventArgs e)
        {
            lastStock = AppSettings.convertToDouble(LastStockBoxD.Text.Replace("Rs", ""));
            lastStockAmount = AppSettings.convertToDouble(LastAmountBoxD.Text.Replace("Rs", ""));

            newStock = AppSettings.convertToDouble(NewStockBoxD.Text.Replace("Rs", ""));
            newStockAmount = AppSettings.convertToDouble(NewAmountBoxD.Text.Replace("Rs", ""));

            /*lastStock = Convert.ToDouble(LastStockBoxD.Text);
            lastStockAmount = Convert.ToDouble(LastAmountBoxD.Text);

            newStock = Convert.ToDouble(NewStockBoxD.Text);
            newStockAmount = Convert.ToDouble(NewAmountBoxD.Text);*/


            double sumAmnt = lastStockAmount + newStockAmount;
            availableStock = lastStock + newStock;
            availableUnitPrice = (lastStockAmount + newStockAmount) / (lastStock + newStock);
            availableAmount = availableUnitPrice * availableStock;

            //MessageBox.Show($"last stock {lastStock} new stock {newStock}  last Amount {lastStockAmount} new stock {newStockAmount}");


            AvailableStockBoxD.Text = AppSettings.RoundToString(availableStock, false);
            AvailableAmountBoxD.Text = AppSettings.RoundToString(availableAmount, true);
            AvailableRateBoxD.Text = AppSettings.RoundToString(availableUnitPrice, true);

            LastStockBoxD.Clear();
            lastStock = 0;
            LastAmountBoxD.Clear();
            lastStockAmount = 0;
            LastRateBoxD.Clear();
            lastUnitPrice = 0;

            NewStockBoxD.Clear();
            newStock = 0;
            newStockAmount = 0;
            NewAmountBoxD.Clear();
            NewRateBoxD.Clear();
            newUnitPrice = 0;
            StockAdded = true;



        }

        private void InsertStockButton_Click(object sender, EventArgs e)
        {

        }

        private void SharahListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();

        }


        private void WeightBox_TextChanged(object sender, EventArgs e)
        {
            Calculate();


        }

        private void FuelTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FuelTypeBox.SelectedIndex == 1) { StockPanel.PanelColor = Color.FromArgb(184, 204, 228); } else { StockPanel.PanelColor = Color.FromArgb(240, 147, 124); }
            StockLabel.Text = $"{FuelTypeBox.Items[FuelTypeBox.SelectedIndex]} Stock";

            SetAvailableStock();
            AutoSuggestions();
            RefTextBox.Text = (GetLastRefNo() + 1).ToString();
            SharahListBox.Items.Clear();
            if (FuelTypeBox.SelectedIndex == 0)
            {
                for (int i = 0; i < sharahPetrol.Length; i++)
                {
                    SharahListBox.Items.Add(sharahPetrol[i].ToString());
                    //SharahListBox.SelectedIndex = 0;
                }
            }
            else if (FuelTypeBox.SelectedIndex == 1)
            {
                for (int i = 0; i < sharahDiesel.Length; i++)
                {
                    SharahListBox.Items.Add(sharahDiesel[i].ToString());
                }
            }
            SharahListBox.SelectedIndex = 0;

            Calculate();
        }


        private void QuerryStock()
        {
            string index = FuelTypeBox.Items[FuelTypeBox.SelectedIndex].ToString();

            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();
                string sql = $"INSERT INTO {index}_stock (Ref_No, Date, Total_Sale, Total_Purchase,  Available_Stock, Available_Stock_Amount, Available_Stock_Unit_Price) VALUES " +
                                                       "(@Ref_No, @Date, @Total_Sale, @Total_Purchase, @Available_Stock, @Available_Stock_Amount, @Available_Stock_Unit_Price)";


                MySqlCommand cmd = new MySqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@Ref_No", GetLastRefNoStock() + 1);
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);




                if (FuelTypeBox.SelectedIndex == 0)
                {
                    cmd.Parameters.AddWithValue("@Total_Sale", GetTotalPurchasePetrol());
                    cmd.Parameters.AddWithValue("@Total_Purchase", GetTotalPurchasePetrol());
                }
                else if (FuelTypeBox.SelectedIndex == 1)
                {
                    cmd.Parameters.AddWithValue("@Total_Purchase", GetTotalPurchaseDiesel());
                    cmd.Parameters.AddWithValue("@Total_Sale", GetTotalSaleDiesel());
                }

                cmd.Parameters.AddWithValue("@Available_Stock", availableStock);
                cmd.Parameters.AddWithValue("@Available_Stock_Amount", availableAmount);
                cmd.Parameters.AddWithValue("@Available_Stock_Unit_Price", availableUnitPrice);
                cmd.ExecuteNonQuery();

                MessageBox.Show($"{index} Stock Inserted Successfully", $"{index} Stock Querry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, $"{index} Stock Querry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        string RefStocksql;
        private float GetLastRefNoStock()
        {
            int lastRefNo = 0;  // Default value if no data is found
            string index = FuelTypeBox.Items[FuelTypeBox.SelectedIndex].ToString();
            index.ToLower();
            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                RefStocksql = $"SELECT Ref_No FROM {index}_stock ORDER BY Ref_No DESC LIMIT 1";


                MySqlCommand cmd = new MySqlCommand(RefStocksql, connection);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    lastRefNo = Convert.ToInt16(result);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during database access
                MessageBox.Show("Error: " + ex.Message);
            }

            return lastRefNo;
        }


        private void EnteryPurchase_Load(object sender, EventArgs e)
        {
            RefTextBox.Text = (GetLastRefNo() + 1).ToString();
            KeyPreview = true;
            AutoSuggestions();

        }




        private bool Validation(string value)
        {
            bool isValid = false;
            if (value == "0")
                return isValid;
            if (value == string.Empty)
                return isValid;


            if (Regex.IsMatch(value, @"^[0-9]*(?:\.[0-9]*)?$"))
            {
                isValid = true;
            }
            else
            {
                isValid = false;
                MessageBox.Show("Invalid Entry");
            }


            return isValid;
        }

        private void Query()
        {

            try
            {


                string index = FuelTypeBox.Items[FuelTypeBox.SelectedIndex].ToString();
                index.ToLower();

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();
                string sql = $"INSERT INTO purchase_data_{index} (Ref_No,Date,Fuel_Type,Sharah,Malik_Name,Kanta_Wazan,Miqdar,Khoraki,Saafi_Miqdar,Rate_per_Liter,Amount,Kharcha_Mazdoori,Saafi_Raqam,Sabqa_Baqaya,Total_Amount,Amount_Paid_1,Description_Details_1,Amount_Paid_2,Description_Details_2,Amount_Paid_3,Description_Details_3,Amount_Paid_4,Description_Details_4,Amount_Paid_5,Description_Details_5,Baqaya) VALUES " +
                                                          "(@Ref_No,@Date,@Fuel_Type,@Sharah,@Malik_Name,@Kanta_Wazan,@Miqdar,@Khoraki,@Saafi_Miqdar,@Rate_per_Liter,@Amount,@Kharcha_Mazdoori,@Saafi_Raqam,@Sabqa_Baqaya,@Total_Amount,@Amount_Paid_1,@Description_Details_1,@Amount_Paid_2,@Description_Details_2,@Amount_Paid_3,@Description_Details_3,@Amount_Paid_4,@Description_Details_4,@Amount_Paid_5,@Description_Details_5,@Baqaya)";




                MySqlCommand cmd = new MySqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@Ref_No", Convert.ToInt16(RefTextBox.Text));
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Fuel_Type", FuelTypeBox.Text);
                cmd.Parameters.AddWithValue("@Sharah", SharahListBox.Items[SharahListBox.SelectedIndex]);
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
                cmd.Parameters.AddWithValue("@Amount_Paid_1", RecoveryAmountBox1.Text.Replace("Rs", ""));
                cmd.Parameters.AddWithValue("@Description_Details_1", RecoveryDescriptionBox1.Text);

                cmd.Parameters.AddWithValue("@Amount_Paid_2", RecoveryAmountBox2.Text.Replace("Rs", ""));
                cmd.Parameters.AddWithValue("@Description_Details_2", RecoveryDescriptionBox2.Text);

                cmd.Parameters.AddWithValue("@Amount_Paid_3", RecoveryAmountBox3.Text.Replace("Rs", ""));
                cmd.Parameters.AddWithValue("@Description_Details_3", RecoveryDescriptionBox3.Text);

                cmd.Parameters.AddWithValue("@Amount_Paid_4", RecoveryAmountBox4.Text.Replace("Rs", ""));
                cmd.Parameters.AddWithValue("@Description_Details_4", RecoveryDescriptionBox4.Text);

                cmd.Parameters.AddWithValue("@Amount_Paid_5", RecoveryAmountBox5.Text.Replace("Rs", ""));
                cmd.Parameters.AddWithValue("@Description_Details_5", RecoveryDescriptionBox5.Text);

                cmd.Parameters.AddWithValue("@Baqaya", Remainings);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Purchase Records Inserted Successfully");
                QuerryStock();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }






        string Refsql;
        private float GetLastRefNo()
        {
            int lastRefNo = 0;  // Default value if no data is found
            string index = FuelTypeBox.Items[FuelTypeBox.SelectedIndex].ToString();
            index.ToLower();
            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                Refsql = $"SELECT Ref_No FROM purchase_data_{index} ORDER BY Ref_No DESC LIMIT 1";


                MySqlCommand cmd = new MySqlCommand(Refsql, connection);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    lastRefNo = Convert.ToInt16(result);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during database access
                MessageBox.Show("Error: " + ex.Message);
            }

            return lastRefNo;
        }

        private void ClearBox()
        {

            foreach (Bunifu.UI.WinForms.BunifuTextBox textBox in new[] { RefTextBox, NameTextBox, WeightBox, QuantityBox, KhorakiBox, NetQuantityBox, RateBox, TotalRaqamBox, AmountBox, LabourBox, NetQuantityBox, NetPriceBox, SabqaRaqamBox, RecoveryAmountBox1, RecoveryDescriptionBox2, RecoveryAmountBox2, RecoveryAmountBox3, RecoveryDescriptionBox3, RecoveryAmountBox4, RecoveryDescriptionBox4, RecoveryAmountBox5, RecoveryDescriptionBox5, RecoveryDescriptionBox1, RemainingAmountBox })
            {
                textBox.Clear();
            }

            FuelTypeBox.SelectedIndex = 0;
            RefTextBox.Text = (GetLastRefNo() + 1).ToString();
            dateTimePicker1.Value = DateTime.Now;
            EntryList.AutoScrollPosition = new Point(Top);
            EntryList.Enabled = false;


        }
        private bool scrolling = false;
        private void autoScroll(object sender)
        {
            if (sender is Bunifu.UI.WinForms.BunifuTextBox textBox)
            {
                // Calculate the position of the TextBox relative to the FlowLayoutControl
                Point textBoxLocation = textBox.Parent.PointToScreen(textBox.Location);
                Point flowLayoutLocation = EntryList.PointToScreen(Point.Empty);
                int verticalScrollAmount = textBoxLocation.Y - flowLayoutLocation.Y;

                // Scroll the FlowLayoutControl gradually if the TextBox is not fully visible
                if (verticalScrollAmount < 0 || verticalScrollAmount + textBox.Height > EntryList.ClientRectangle.Height)
                {
                    scrolling = true; // Set scrolling flag to prevent reentrancy
                    int currentScrollPosition = EntryList.VerticalScroll.Value;
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
                            EntryList.VerticalScroll.Value = currentScrollPosition;
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
                            EntryList.VerticalScroll.Value = currentScrollPosition;
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

        //------------Stock------------

        private void SetAvailableStock()
        {
            if (FuelTypeBox.SelectedIndex == 0)
            {
                availableStock = GetTotalPurchasePetrol() - GetTotalSalePetrol();


            }
            else if (FuelTypeBox.SelectedIndex == 1)
            {
                availableStock = GetTotalPurchaseDiesel() - GetTotalSaleDiesel();


            }

            AvailableStockBoxD.Text = AppSettings.RoundToString(availableStock, false);
            availableUnitPrice = GetLastUnitPrice();
            AvailableAmountBoxD.Text = AppSettings.RoundToString(availableStock * availableUnitPrice, true);
            AvailableRateBoxD.Text = AppSettings.RoundToString(GetLastUnitPrice(), true);
        }


        private double GetLastUnitPrice()
        {
            string index = FuelTypeBox.Items[FuelTypeBox.SelectedIndex].ToString().ToLower();
            double lastUnitPrice = 0;

            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                string Idsql = $"SELECT Available_Stock_Unit_Price FROM {index}_stock ORDER BY Ref_No DESC LIMIT 1";


                MySqlCommand cmd = new MySqlCommand(Idsql, connection);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    lastUnitPrice = Convert.ToDouble(result);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Last Unit Price");
            }

            return lastUnitPrice;
        }

        //------------

        private float GetTotalPurchaseDiesel()
        {
            float totalSaleDiesel = 0;

            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                string sqlCom = "SELECT \r\n    (SELECT Round(SUM(Saafi_Miqdar),4) FROM purchase_data_diesel) AS TotalSumQuantity;";

                MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    totalSaleDiesel = float.Parse(result.ToString());
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

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                string sqlCom = $"SELECT \r\n    (SELECT Round(SUM(netQuantity),4) FROM unit2_sales_data) +\r\n    (SELECT Round(SUM(netQuantity),4) FROM unit3_sales_data) +\r\n    (SELECT Round(SUM(netQuantity),4) FROM unit4_sales_data) AS TotalSumQuantity;";





                MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    lastClosingReading = float.Parse(result.ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }

            return lastClosingReading;
        }

        //-------------------------
        private float GetTotalPurchasePetrol()
        {
            float totalSalePetrol = 0;

            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                string sqlCom = "SELECT \r\n    (SELECT Round(SUM(Saafi_Miqdar),4) FROM purchase_data_petrol) AS TotalSumQuantity;";

                MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    totalSalePetrol = float.Parse(result.ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }

            return totalSalePetrol;
        }


        private float GetTotalSalePetrol()
        {
            float lastClosingReading = 0;


            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                string sqlCom = $"SELECT Round(SUM(netQuantity),4) FROM unit1_sales_data";





                MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    lastClosingReading = float.Parse(result.ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }

            return lastClosingReading;
        }


    }


}
