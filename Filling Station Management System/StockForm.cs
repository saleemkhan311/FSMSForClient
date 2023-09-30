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
using ComponentFactory.Krypton.Toolkit;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Filling_Station_Management_System
{
    public partial class StockForm : KryptonForm
    {
        public StockForm()
        {
            InitializeComponent();
        }

        //Diesel----------------------------------
        private double availableStockD, AvailableStockAmountD, AvailableUnitPriceD;
        private double newStockD, newStockAmountD, newUnitPriceD;
        private double lastStockD, lastStockAmountD, lastUnitPriceD;
        //-----------------------------------------------



        //Petrol------------------------------------
        private double availableStockPtrl, AvailableStockAmountPtrl, AvailableUnitPricePtrl;
        private double newStockP, newStockAmountP, newUnitPriceP;
        private double lastStockP, lastStockAmountP, lastUnitPriceP;
        private bool tempD = false;
        private bool tempP = false;

        //-------------------------------------------------

        //*****************************************************************************


        //Diesel-Start---------------------
        #region Diesel

        private float GetTotalSaleDiesel()
        {
            float lastClosingReading = 0;


            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                string sqlCom = $"SELECT \r\n    (SELECT Round(SUM(netQuantity),2) FROM unit2_sales_data) +\r\n    (SELECT Round(SUM(netQuantity),2) FROM unit3_sales_data) +\r\n    (SELECT Round(SUM(netQuantity),2) FROM unit4_sales_data) AS TotalSumQuantity;";





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

        private float GetTotalPurchaseDiesel()
        {
            float totalSaleDiesel = 0;


            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                string sqlCom = "SELECT \r\n    (SELECT Round(SUM(Saafi_Miqdar),2) FROM purchase_data_diesel) AS TotalSumQuantity;";

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

        private void AvailableStockBoxD_TextChanged(object sender, EventArgs e)
        {

        }

        private void AvailableRateBoxD_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddNewStockButtonD_Click(object sender, EventArgs e)
        {

            if (tempD)
            {

                if (Validation(AvailableStockBoxD.Text))
                {
                    Calculations();
                    /*LastStockBoxD.Text = RoundToString(availableStockD);
                    LastAmountBoxD.Text = RoundToString(AvailableStockAmountD);
                    LastRateBoxD.Text = RoundToString(AvailableUnitPriceD);
                    Calculations();*/


                    if (lastStockD > 0 || availableStockD == 0)
                    {

                        availableStockD = lastStockD + newStockD - (GetTotalSaleDiesel());

                        if (lastStockD == 0)
                        {
                            AvailableUnitPriceD = newUnitPriceD;
                        }
                        else { AvailableUnitPriceD = (lastStockAmountD + newStockAmountD) / (availableStockD); }

                        AvailableStockAmountD = availableStockD * AvailableUnitPriceD;
                        //AvailableUnitPriceD = (lastStockAmountD + newStockAmountD) / (availableStockD);


                        AvailableStockBoxD.Text = RoundToString(availableStockD);
                        AvailableAmountBoxD.Text = RoundToString(AvailableStockAmountD);
                        AvailableRateBoxD.Text = RoundToString(AvailableUnitPriceD);

                        LastStockBoxD.Text = "0";
                        LastAmountBoxD.Text = "0";
                        LastRateBoxD.Text = "0";

                        NewAmountBoxD.Text = "0";
                        NewStockBoxD.Text = "0";
                        NewRateBoxD.Text = "0"; tempD = false;

                    }
                    else { MessageBox.Show("Please fill the Last Stock Row to procced"); }

                }

            }
            else
            {
                MessageBox.Show("Add New Stock to Procced", "Stock Renewal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                /* if (MessageBox.Show("Add New Stock to Procced", "Stock Renewal", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                 {
                     temp = true;
                 }*/

            }

        }




        private void Calculations()
        {
            AvailableUnitPriceD = ConvertDouble(AvailableRateBoxD.Text);
            availableStockD = ConvertDouble(AvailableStockBoxD.Text);
            AvailableStockAmountD = availableStockD * AvailableUnitPriceD;

            lastStockAmountD = ConvertDouble(LastAmountBoxD.Text);
            lastStockD = ConvertDouble(LastStockBoxD.Text);
            lastUnitPriceD = ConvertDouble(LastRateBoxD.Text);

            newStockD = ConvertDouble(NewStockBoxD.Text);
            newStockAmountD = ConvertDouble(NewAmountBoxD.Text);
            newUnitPriceD = ConvertDouble(NewRateBoxD.Text);
        }




        private static double ConvertDouble(string value)
        {
            value = string.IsNullOrEmpty(value) ? "0" : value;

            if (double.TryParse(value, out double doubleValue))
            {

                return doubleValue;
            }
            else
            {
                throw new ArgumentException("Invalid Input: Not a Valid Entry");
            }

        }

        private void AvailableStockBoxD_Leave(object sender, EventArgs e)
        {

        }

        private void AvailableRateBoxD_Leave(object sender, EventArgs e)
        {

        }

        private void InsertData_Click(object sender, EventArgs e)
        {
            if (AvailableStockBoxD.Text != "0" || AvailableStockBoxD.Text != string.Empty)
            { Query(); }
            else { MessageBox.Show("Fill out the Available Stock to insert Data", "Diesel Stock", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void TurnDownButtonD_Click(object sender, EventArgs e)
        {
            Calculations();

            LastStockBoxD.Text = RoundToString(availableStockD);
            LastAmountBoxD.Text = RoundToString(AvailableStockAmountD);
            LastRateBoxD.Text = RoundToString(AvailableUnitPriceD);

            AvailableStockBoxD.Text = "0";
            AvailableAmountBoxD.Text = "0";
            AvailableRateBoxD.Text = "0";

            Calculations();




        }

        private void GetNewStockButtonD_Click(object sender, EventArgs e)
        {
            NewStockCalDiesel();
            tempD = true;
        }

        private void NewStockClearButtonD_Click(object sender, EventArgs e)
        {
            NewStockBoxD.Text = string.Empty;
            NewAmountBoxD.Text = string.Empty;
            NewRateBoxD.Text = string.Empty;

            newStockD = 0;
            newStockAmountD = 0;
            newUnitPriceD = 0;
            tempD = false;


        }



        private void StockForm_Load(object sender, EventArgs e)
        {
            // NewStockCal();
            GetStockDiesel();
            GetStockPetrol();
        }

        private void TotalSaleTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private double GetLastSaafiMiqdarDiesel()
        {
            double lastSaafiMiqdar = 0;
            /*try
            {*/

            MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
            connection.Open();

            string sqlCom = $"SELECT Round(Saafi_Miqdar,2) FROM purchase_data_diesel ORDER BY Ref_No DESC LIMIT 1";

            MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
            object result = cmd.ExecuteScalar();

            if (result != null && result != DBNull.Value)
            {
                lastSaafiMiqdar = float.Parse(result.ToString());
            }
            /* }
             catch (Exception ex)
             {

                 MessageBox.Show("Error: " + ex.Message,"Saafi Miqdar");
             }*/
            return lastSaafiMiqdar;
        }



        private double GetLastRateDiesel()
        {
            double lastRate = 0;
            /*try
            {*/

            MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
            connection.Open();

            string sqlCom = $"SELECT Round(Rate_per_Liter,2) FROM purchase_data_diesel ORDER BY Ref_No DESC LIMIT 1;";

            MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
            object result = cmd.ExecuteScalar();

            if (result != null && result != DBNull.Value)
            {
                lastRate = float.Parse(result.ToString());
            }
            /* }
             catch (Exception ex)
             {

                 MessageBox.Show("Error: " + ex.Message);
             }*/
            return lastRate;
        }




        void NewStockCalDiesel()
        {
            TotalSaleTextBoxD.Text = GetTotalSaleDiesel().ToString();
            TotalPurchaseBoxD.Text = GetTotalPurchaseDiesel().ToString();

            newStockD = GetLastSaafiMiqdarDiesel();
            newUnitPriceD = GetLastRateDiesel();
            newStockAmountD = GetLastSaafiMiqdarDiesel() * GetLastRateDiesel();

            NewStockBoxD.Text = RoundToString(newStockD);
            NewAmountBoxD.Text = RoundToString(newStockAmountD);
            NewRateBoxD.Text = RoundToString(newUnitPriceD);
        }



        void GetStockDiesel()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();
                string query = "SELECT * FROM diesel_stock ORDER BY Ref_No DESC LIMIT 1"; // Assuming 'id' is the primary key.
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Assuming column names are "column1", "column2", ..., "column6"

                    availableStockD = Convert.ToDouble(reader["Available_Stock"].ToString());
                    AvailableStockAmountD = Convert.ToDouble(reader["Available_Stock_Amount"].ToString());
                    AvailableUnitPriceD = Convert.ToDouble(reader["Available_Stock_Unit_Price"].ToString());

                    AvailableStockBoxD.Text = RoundToString(availableStockD);
                    AvailableRateBoxD.Text = RoundToString(AvailableUnitPriceD);
                    AvailableAmountBoxD.Text = RoundToString(AvailableStockAmountD);


                    /* lastStockD = Convert.ToDouble(reader["Last_Stock"].ToString());
                     lastStockAmountD = Convert.ToDouble(reader["Last_Stock_Amount"].ToString());
                     lastUnitPriceD = Convert.ToDouble(reader["Last_Stock_Unit_Price"].ToString());
 */



                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void Query()
        {

            /* try
             {*/

            MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
            connection.Open();
            string sql = $"INSERT INTO diesel_stock (Ref_No, Date, Total_Sale, Total_Purchase, Available_Stock, Available_Stock_Amount, Available_Stock_Unit_Price, Last_Stock, Last_Stock_Amount, Last_Stock_Unit_Price, New_Stock, New_Stock_Amount, New_Stock_Unit_Price) VALUES " +
                                                    "(@Ref_No, @Date, @Total_Sale, @Total_Purchase, @Available_Stock, @Available_Stock_Amount, @Available_Stock_Unit_Price, @Last_Stock, @Last_Stock_Amount, @Last_Stock_Unit_Price, @New_Stock, @New_Stock_Amount, @New_Stock_Unit_Price)";




            MySqlCommand cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@Ref_No", GetLastRefDiesel() + 1);
            cmd.Parameters.AddWithValue("@Date", DatePicker.Value);
            cmd.Parameters.AddWithValue("@Total_Sale", TotalSaleTextBoxD.Text);
            cmd.Parameters.AddWithValue("@Total_Purchase", TotalPurchaseBoxD.Text);


            cmd.Parameters.AddWithValue("@Available_Stock", AvailableStockBoxD.Text);
            cmd.Parameters.AddWithValue("@Available_Stock_Amount", AvailableAmountBoxD.Text);
            cmd.Parameters.AddWithValue("@Available_Stock_Unit_Price", AvailableRateBoxD.Text);

            cmd.Parameters.AddWithValue("@Last_Stock", LastStockBoxD.Text);
            cmd.Parameters.AddWithValue("@Last_Stock_Amount", LastAmountBoxD.Text);
            cmd.Parameters.AddWithValue("@Last_Stock_Unit_Price", LastRateBoxD.Text);

            cmd.Parameters.AddWithValue("@New_Stock", NewStockBoxD.Text);
            cmd.Parameters.AddWithValue("@New_Stock_Amount", NewAmountBoxD.Text);
            cmd.Parameters.AddWithValue("@New_Stock_Unit_Price", NewRateBoxD.Text);



            cmd.ExecuteNonQuery();

            MessageBox.Show("Records Inserted Successfully");
            /* }
             catch (Exception ex)
             {
                 MessageBox.Show("Error: " + ex.Message);
             }*/
        }
        #endregion
        //Diesel-End--------------------------------------


        //***********************************************

        //Petrol-Open-------------------------------------
        #region Petrol


        private void GetNewStockButtonP_Click(object sender, EventArgs e)
        {
            NewStockCalPetrol();
            tempP = true;
        }
        private void QueryPetrol()
        {

            /* try
             {*/

            MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
            connection.Open();
            string sql = $"INSERT INTO petrol_stock (Ref_No, Date, Total_Sale, Total_Purchase, Available_Stock, Available_Stock_Amount, Available_Stock_Unit_Price) VALUES " +
                                                    "(@Ref_No, @Date, @Total_Sale, @Total_Purchase, @Available_Stock, @Available_Stock_Amount, @Available_Stock_Unit_Price)";




            MySqlCommand cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@Ref_No", GetLastRefPetrol() + 1);
            cmd.Parameters.AddWithValue("@Date", DatePicker.Value);
            cmd.Parameters.AddWithValue("@Total_Sale", TotalSaleTextBoxP.Text);
            cmd.Parameters.AddWithValue("@Total_Purchase", TotalPurchaseBoxP.Text);


            cmd.Parameters.AddWithValue("@Available_Stock", AvailableStockBoxPetrol.Text);
            cmd.Parameters.AddWithValue("@Available_Stock_Amount", AvailableAmountBoxPetrol.Text);
            cmd.Parameters.AddWithValue("@Available_Stock_Unit_Price", AvailableRateBoxPetrol.Text);




            cmd.ExecuteNonQuery();

            MessageBox.Show("Records Inserted Successfully");
            /* }
             catch (Exception ex)
             {
                 MessageBox.Show("Error: " + ex.Message);
             }*/
        }

        private void TurnDownButtonP_Click(object sender, EventArgs e)
        {
            CalculationsPetrol();

            LastStockBoxP.Text = RoundToString(availableStockPtrl);
            LastAmountBoxP.Text = RoundToString(AvailableStockAmountPtrl);
            LastRateBoxP.Text = RoundToString(AvailableUnitPricePtrl);

            AvailableStockBoxPetrol.Text = "0";
            AvailableAmountBoxPetrol.Text = "0";
            AvailableRateBoxPetrol.Text = "0";

            CalculationsPetrol();
        }

        private void InsertDataPetrol_Click(object sender, EventArgs e)
        {
            if (AvailableStockBoxPetrol.Text != "0" || AvailableStockBoxPetrol.Text != string.Empty)
            { QueryPetrol(); }
            else { MessageBox.Show("Fill Out Available Stock to Insert Data", "Petrol Stock", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        void NewStockCalPetrol()
        {
            TotalSaleTextBoxP.Text = GetTotalSalePetrol().ToString();
            TotalPurchaseBoxP.Text = GetTotalPurchasePetrol().ToString();

            newStockP = GetLastSaafiMiqdarPetrol();
            newUnitPriceP = GetLastRatePetrol();
            newStockAmountP = GetLastSaafiMiqdarPetrol() * GetLastRatePetrol();

            NewStockBoxP.Text = RoundToString(newStockP);
            NewAmountBoxP.Text = RoundToString(newStockAmountP);
            NewRateBoxP.Text = RoundToString(newUnitPriceP);
        }

        private void AddNewStockButtonP_Click(object sender, EventArgs e)
        {
            if (tempP)
            {

                if (Validation(AvailableStockBoxPetrol.Text))
                {
                    CalculationsPetrol();
                    /*LastStockBoxD.Text = RoundToString(availableStockD);
                    LastAmountBoxD.Text = RoundToString(AvailableStockAmountD);
                    LastRateBoxD.Text = RoundToString(AvailableUnitPriceD);
                    Calculations();*/



                    if (lastStockP > 0 || availableStockPtrl == 0)
                    {

                        availableStockPtrl = lastStockP + newStockP - (GetTotalSalePetrol());

                        if (lastStockP == 0)
                        {
                            AvailableUnitPricePtrl = newUnitPriceP;
                        }
                        else { AvailableUnitPricePtrl = (lastStockAmountP + newStockAmountP) / (availableStockPtrl); }

                        AvailableStockAmountPtrl = availableStockPtrl * AvailableUnitPricePtrl;



                        AvailableStockBoxPetrol.Text = RoundToString(availableStockPtrl);
                        AvailableAmountBoxPetrol.Text = RoundToString(AvailableStockAmountPtrl);
                        AvailableRateBoxPetrol.Text = RoundToString(AvailableUnitPricePtrl);

                        LastStockBoxP.Text = "0";
                        LastAmountBoxP.Text = "0";
                        LastRateBoxP.Text = "0";

                        NewAmountBoxP.Text = "0";
                        NewStockBoxP.Text = "0";
                        NewRateBoxP.Text = "0";
                        tempP = false;

                    }
                    else { MessageBox.Show("Please fill the Last Stock Row to procced"); }

                }

            }
            else
            {
                MessageBox.Show("Add New Stock to Procced", "Stock Renewal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        void GetStockPetrol()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();
                string query = "SELECT * FROM petrol_stock ORDER BY Ref_No DESC LIMIT 1"; // Assuming 'id' is the primary key.
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    availableStockPtrl = Convert.ToDouble(reader["Available_Stock"].ToString());
                    AvailableStockAmountPtrl = Convert.ToDouble(reader["Available_Stock_Amount"].ToString());
                    AvailableUnitPricePtrl = Convert.ToDouble(reader["Available_Stock_Unit_Price"].ToString());

                    AvailableStockBoxPetrol.Text = RoundToString(availableStockPtrl);
                    AvailableRateBoxPetrol.Text = RoundToString(AvailableUnitPricePtrl);
                    AvailableAmountBoxPetrol.Text = RoundToString(AvailableStockAmountPtrl);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void CalculationsPetrol()
        {
            AvailableUnitPricePtrl = ConvertDouble(AvailableRateBoxPetrol.Text);
            availableStockPtrl = ConvertDouble(AvailableStockBoxPetrol.Text);
            AvailableStockAmountPtrl = availableStockPtrl * AvailableUnitPricePtrl;

            lastStockAmountP = ConvertDouble(LastAmountBoxP.Text);
            lastStockP = ConvertDouble(LastStockBoxP.Text);
            lastUnitPriceP = ConvertDouble(LastRateBoxP.Text);

            newStockP = ConvertDouble(NewStockBoxP.Text);
            newStockAmountP = ConvertDouble(NewAmountBoxP.Text);
            newUnitPriceP = ConvertDouble(NewRateBoxP.Text);
        }


        private double GetLastSaafiMiqdarPetrol()
        {
            double lastSaafiMiqdar = 0;
            /*try
            {*/

            MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
            connection.Open();

            string sqlCom = $"SELECT Round(Saafi_Miqdar,2) FROM purchase_data_petrol ORDER BY Ref_No DESC LIMIT 1";

            MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
            object result = cmd.ExecuteScalar();

            if (result != null && result != DBNull.Value)
            {
                lastSaafiMiqdar = float.Parse(result.ToString());
            }
            /* }
             catch (Exception ex)
             {

                 MessageBox.Show("Error: " + ex.Message,"Saafi Miqdar");
             }*/
            return lastSaafiMiqdar;
        }


        private double GetLastRatePetrol()
        {
            double lastRate = 0;
            /*try
            {*/

            MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
            connection.Open();

            string sqlCom = $"SELECT Round(Rate_per_Liter,2) FROM purchase_data_petrol ORDER BY Ref_No DESC LIMIT 1;";

            MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
            object result = cmd.ExecuteScalar();

            if (result != null && result != DBNull.Value)
            {
                lastRate = float.Parse(result.ToString());
            }
            /* }
             catch (Exception ex)
             {

                 MessageBox.Show("Error: " + ex.Message);
             }*/
            return lastRate;
        }

        private float GetTotalPurchasePetrol()
        {
            float totalSalePetrol = 0;


            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                string sqlCom = "SELECT \r\n    (SELECT Round(SUM(Saafi_Miqdar),2) FROM purchase_data_petrol) AS TotalSumQuantity;";

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

                string sqlCom = $"SELECT Round(SUM(netQuantity),2) FROM unit1_sales_data";





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
        #endregion

        private int GetLastRefPetrol()
        {

            int lastRef = 0;

            /*try
            {*/

            MySqlConnection connection = new MySqlConnection(AppSettings.UserConString());
            connection.Open();

            string Idsql = $"SELECT Ref_No FROM petrol_stock ORDER BY Ref_No DESC LIMIT 1";


            MySqlCommand cmd = new MySqlCommand(Idsql, connection);
            object result = cmd.ExecuteScalar();

            if (result != null && result != DBNull.Value)
            {
                lastRef = Convert.ToInt16(result);
            }
            /* }
             catch (Exception ex)
             {

                 MessageBox.Show("Error: " + ex.Message);
             }
 */
            return lastRef;
        }

        //Petrol-End-------------------------------------------
        private int GetLastRefDiesel()
        {

            int lastRef = 0;

            /*try
            {*/

            MySqlConnection connection = new MySqlConnection(AppSettings.UserConString());
            connection.Open();

            string Idsql = $"SELECT Ref_No FROM diesel_stock ORDER BY Ref_No DESC LIMIT 1";


            MySqlCommand cmd = new MySqlCommand(Idsql, connection);
            object result = cmd.ExecuteScalar();

            if (result != null && result != DBNull.Value)
            {
                lastRef = Convert.ToInt16(result);
            }
            /* }
             catch (Exception ex)
             {

                 MessageBox.Show("Error: " + ex.Message);
             }
 */
            return lastRef;
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
                    MessageBox.Show("Invalid Entry: Enter Data in Numbers Only", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                isValid = false;
                MessageBox.Show("Invalid Entry: Empty Input", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            return isValid;
        }

        string RoundToString(double value)
        {
            return Math.Round(value, 2).ToString();
        }
    }
}
