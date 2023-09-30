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

        Double kantaWazan, sharah, miqdar, Khoraki, saafiMiqdar, ratePerLiter, totalAmount, labour, saafiRaqam, sabqaBaqaya, Amount, Remainings;

        Double[] sharahPetrol = { 0.725, 0.726, 0.727, 0.728, 0.729, 0.730 };
        Double[] sharahDiesel = { 0.800, 0.801, 0.802, 0.803, 0.804, 0.805, 0.806, 0.807, 0.808, 0.809, 0.810 };
        private void KhorakiBox_TextChanged(object sender, EventArgs e)
        {
            if (Validation(KhorakiBox.Text) && Validation(WeightBox.Text))
            {
                Khoraki = Double.Parse(KhorakiBox.Text);
                saafiMiqdar = miqdar - Khoraki;
                NetQuantityBox.Text = RoundToString(saafiMiqdar);
            }


        }

        string RoundToString(Double value)
        {
            return Math.Round(value, 0).ToString();
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

        private void RemainingAmountBox_TextChanged(object sender, EventArgs e)
        {

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

            // Loop through the first five TextBoxes and add their values if they are valisd numbers
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

        private void GenerateReceipt_Click(object sender, EventArgs e)
        {
            if (isFilledAll())
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
            else { MessageBox.Show("Please Fill The Necessory Boxes to Continue", "Generate Reciept", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        //Bunifu.UI.WinForms.BunifuTextBox[] textBoxes = new BunifuTextBox[] { RefTextBox, WeightBox, NameTextBox, QuantityBox, KhorakiBox, NetQuantityBox, RateBox, TotalRaqamBox, AmountBox, LabourBox, NetQuantityBox, NetPriceBox, SabqaRaqamBox, RecoveryAmountBox1, RecoveryDescriptionBox2, RecoveryAmountBox2, RecoveryAmountBox3, RecoveryDescriptionBox3, RecoveryAmountBox4, RecoveryDescriptionBox4, RecoveryAmountBox5, RecoveryDescriptionBox5, RecoveryDescriptionBox1, RemainingAmountBox };
        /*private bool isNotEmpty()
        {
            foreach (Bunifu.UI.WinForms.BunifuTextBox textBox in new[] { })
            {
                if(textBox.Text!=string.Empty)
                    return true;
                else return false;
            }
            return true;

        }*/

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            AutoSuggestions();
        }

        List<string> NameSuggestions = new List<string>();
        private void AutoSuggestions()
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

        private void LabourBox_Enter(object sender, EventArgs e)
        {
            autoScroll(LabourBox);
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



        private void RecoveryAmountBox3_Enter(object sender, EventArgs e)
        {

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

            foreach (Bunifu.UI.WinForms.BunifuTextBox textBox in new[] { RefTextBox, WeightBox, NameTextBox, QuantityBox, KhorakiBox, NetQuantityBox, RateBox, AmountBox, LabourBox, NetQuantityBox, NetPriceBox, SabqaRaqamBox, RecoveryAmountBox1 })
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


            if (isFilledAll())
            {
                Query();
                ClearBox();
            }
            else
            {
                MessageBox.Show("Please Fill All The Fields To Procced");
            }

        }

        private void PreviousAmountBox_TextChanged(object sender, EventArgs e)
        {
            if (Validation(SabqaRaqamBox.Text) && Validation(NetPriceBox.Text))
            {
                sabqaBaqaya = Math.Round(Convert.ToDouble(SabqaRaqamBox.Text), 2);

                totalAmount = saafiRaqam + sabqaBaqaya;
                TotalRaqamBox.Text = RoundToString(totalAmount);
            }
        }

        private void TotalPriceBox_TextChanged(object sender, EventArgs e)
        {

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

        private void RateBox_TextChanged(object sender, EventArgs e)
        {
            if (Validation(RateBox.Text) && Validation(NetQuantityBox.Text))
            {
                ratePerLiter = Math.Round(Convert.ToDouble(RateBox.Text), 2);

                Amount = saafiMiqdar * ratePerLiter;
                AmountBox.Text = RoundToString(Amount);
            }
        }


        public EnteryPurchase()
        {
            InitializeComponent();
            FuelTypeBox.SelectedIndex = 0;
        }


        private void SharahListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Validation(WeightBox.Text))
            {
                kantaWazan = Math.Round(double.Parse(WeightBox.Text), 2);
                sharah = Math.Round(double.Parse(SharahListBox.Items[SharahListBox.SelectedIndex].ToString()), 2);
                miqdar = kantaWazan / sharah;

                QuantityBox.Text = RoundToString(miqdar);

            }
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void WeightBox_TextChanged(object sender, EventArgs e)
        {


            if (Validation(WeightBox.Text))
            {
                kantaWazan = Math.Round(Convert.ToDouble(WeightBox.Text), 2);
                sharah = Math.Round(Double.Parse(SharahListBox.Items[SharahListBox.SelectedIndex].ToString()), 2);
                miqdar = kantaWazan / sharah;

                QuantityBox.Text = RoundToString(miqdar);

            }
        }

        private void FuelTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
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
        }

        private void EnteryPurchase_Load(object sender, EventArgs e)
        {
            RefTextBox.Text = (GetLastRefNo() + 1).ToString();
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

        private void Query()
        {

            /* try
             {
            
 */
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


            cmd.Parameters.AddWithValue("@Kanta_Wazan", WeightBox.Text);
            cmd.Parameters.AddWithValue("@Miqdar", QuantityBox.Text);
            cmd.Parameters.AddWithValue("@Khoraki", KhorakiBox.Text);
            cmd.Parameters.AddWithValue("@Saafi_Miqdar", NetQuantityBox.Text);
            cmd.Parameters.AddWithValue("@Rate_per_Liter", RateBox.Text);


            cmd.Parameters.AddWithValue("@Amount", AmountBox.Text);
            cmd.Parameters.AddWithValue("@Kharcha_Mazdoori", LabourBox);
            cmd.Parameters.AddWithValue("@Saafi_Raqam", NetPriceBox.Text);
            cmd.Parameters.AddWithValue("@Sabqa_Baqaya", SabqaRaqamBox.Text);
            cmd.Parameters.AddWithValue("@Total_Amount", TotalRaqamBox.Text);
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

            MessageBox.Show("Records Inserted Successfully");
            /*} catch(Exception ex)
            {
                MessageBox.Show("Error: "+ex.Message);
            }*/

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

            foreach (Bunifu.UI.WinForms.BunifuTextBox textBox in new[] { RefTextBox, WeightBox, NameTextBox, QuantityBox, KhorakiBox, NetQuantityBox, RateBox, TotalRaqamBox, AmountBox, LabourBox, NetQuantityBox, NetPriceBox, SabqaRaqamBox, RecoveryAmountBox1, RecoveryDescriptionBox2, RecoveryAmountBox2, RecoveryAmountBox3, RecoveryDescriptionBox3, RecoveryAmountBox4, RecoveryDescriptionBox4, RecoveryAmountBox5, RecoveryDescriptionBox5, RecoveryDescriptionBox1, RemainingAmountBox })
            {
                textBox.Clear();
            }

            FuelTypeBox.SelectedIndex = 0;
            RefTextBox.Text = (GetLastRefNo() + 1).ToString();
            dateTimePicker1.Value = DateTime.Now;

        }
        private bool scrolling = false;
        private void autoScroll(object sender)
        {
            if (sender is Bunifu.UI.WinForms.BunifuTextBox textBox)
            {
                // Calculate the position of the TextBox relative to the FlowLayoutControl
                Point textBoxLocation = textBox.Parent.PointToScreen(textBox.Location);
                Point flowLayoutLocation = flowLayoutPanel1.PointToScreen(Point.Empty);
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

    }
}
