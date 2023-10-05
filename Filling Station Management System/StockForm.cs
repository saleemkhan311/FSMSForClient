using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

            /* if (tempD)
             {

                 if (Validation(AvailableStockBoxD.Text))
                 {
                     Calculations();
                     *//*LastStockBoxD.Text = RoundToString(availableStockD);
                     LastAmountBoxD.Text = RoundToString(AvailableStockAmountD);
                     LastRateBoxD.Text = RoundToString(AvailableUnitPriceD);
                     Calculations();*//*


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

                 *//* if (MessageBox.Show("Add New Stock to Procced", "Stock Renewal", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                  {
                      temp = true;
                  }*//*

             }*/

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
            { QuerryDiesel(); }
            else { MessageBox.Show("Fill out the Available Stock to insert Data", "Diesel Stock", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }



        private void StockForm_Load(object sender, EventArgs e)
        {

            SetStockPetrol();
            GetLastStockPetrol();
            NewStockCalPetrol();

            SetDieselStock();
            GetLastStockDiesel();
            NewStockCalDiesel();
            DatePicker.Value = DateTime.Now;
        }

        private void TotalSaleTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private double GetLastSaafiMiqdarDiesel()
        {
            double lastSaafiMiqdar = 0;
            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                string sqlCom = $"SELECT Round(Saafi_Miqdar,2) FROM purchase_data_diesel ORDER BY Ref_No DESC LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    lastSaafiMiqdar = float.Parse(result.ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Saafi Miqdar");
            }
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



        void GetLastStockDiesel()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();
                string query = "SELECT * FROM diesel_stock ORDER BY Ref_No DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {


                    lastStockD = Convert.ToDouble(reader["Available_Stock"].ToString());
                    lastStockAmountD = Convert.ToDouble(reader["Available_Stock_Amount"].ToString());
                    lastUnitPriceD = Convert.ToDouble(reader["Available_Stock_Unit_Price"].ToString());


                    LastStockBoxD.Text = RoundToString(lastStockD);
                    LastRateBoxD.Text = RoundToString(lastStockAmountD);
                    LastAmountBoxD.Text = RoundToString(lastUnitPriceD);

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void QuerryDiesel()
        {

            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();
                string sql = $"INSERT INTO diesel_stock (Ref_No, Date, Total_Sale, Total_Purchase, Available_Stock, Available_Stock_Amount, Available_Stock_Unit_Price) VALUES " +
                                                       "(@Ref_No, @Date, @Total_Sale, @Total_Purchase, @Available_Stock, @Available_Stock_Amount, @Available_Stock_Unit_Price)";


                MySqlCommand cmd = new MySqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@Ref_No", GetLastRefDiesel() + 1);
                cmd.Parameters.AddWithValue("@Date", DatePicker.Value);
                cmd.Parameters.AddWithValue("@Total_Sale", TotalSaleTextBoxD.Text);
                cmd.Parameters.AddWithValue("@Total_Purchase", TotalPurchaseBoxD.Text);


                cmd.Parameters.AddWithValue("@Available_Stock", AvailableStockBoxD.Text);
                cmd.Parameters.AddWithValue("@Available_Stock_Amount", AvailableAmountBoxD.Text);
                cmd.Parameters.AddWithValue("@Available_Stock_Unit_Price", AvailableRateBoxD.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Diesel Stock Inserted Successfully", "Diesel Stock Querry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Diesel Stock Querry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        //Diesel-End--------------------------------------


        //***********************************************

        //Petrol-Open-------------------------------------
        #region Petrol



        private void QuerryPetrol()
        {
            int ref_no = GetLastRefPetrol() + 1;

            try
            {
                DatePicker.Value = DateTime.Now;
                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();
                string sql = $"INSERT INTO petrol_stock (Ref_No, Date, Total_Sale, Total_Purchase, Available_Stock, Available_Stock_Amount, Available_Stock_Unit_Price) VALUES " +
                                                        "(@Ref_No, @Date, @Total_Sale, @Total_Purchase, @Available_Stock, @Available_Stock_Amount, @Available_Stock_Unit_Price)";




                MySqlCommand cmd = new MySqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@Ref_No", ref_no);
                cmd.Parameters.AddWithValue("@Date", DatePicker.Value);
                cmd.Parameters.AddWithValue("@Total_Sale", TotalSaleTextBoxP.Text);
                cmd.Parameters.AddWithValue("@Total_Purchase", TotalPurchaseBoxP.Text);


                cmd.Parameters.AddWithValue("@Available_Stock", AvailableStockBoxPetrol.Text);
                cmd.Parameters.AddWithValue("@Available_Stock_Amount", AvailableAmountBoxPetrol.Text);
                cmd.Parameters.AddWithValue("@Available_Stock_Unit_Price", AvailableRateBoxPetrol.Text);




                cmd.ExecuteNonQuery();

                MessageBox.Show("Petrol Stock Inserted Successfully", "Petrol Stock Querry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Petrol Stock Querry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void InsertDataPetrol_Click(object sender, EventArgs e)
        {
            if (AvailableStockBoxPetrol.Text != "0" || AvailableStockBoxPetrol.Text != string.Empty)
            { QuerryPetrol(); }
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

        void GetLastStockPetrol()
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
                    lastStockP = Convert.ToDouble(reader["Available_Stock"].ToString());
                    lastStockAmountP = Convert.ToDouble(reader["Available_Stock_Amount"].ToString());
                    lastUnitPriceP = Convert.ToDouble(reader["Available_Stock_Unit_Price"].ToString());


                    LastStockBoxP.Text = RoundToString(lastStockP);
                    LastRateBoxP.Text = RoundToString(lastUnitPriceP);
                    LastAmountBoxP.Text = RoundToString(lastStockAmountP);

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

            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                string Idsql = $"SELECT Ref_No FROM petrol_stock ORDER BY Ref_No DESC LIMIT 1";


                MySqlCommand cmd = new MySqlCommand(Idsql, connection);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    lastRef = Convert.ToInt16(result);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }

            return lastRef;
        }

        //Petrol-End-------------------------------------------
        private int GetLastRefDiesel()
        {

            int lastRef = 0;

            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                string Idsql = $"SELECT Ref_No FROM diesel_stock ORDER BY Ref_No DESC LIMIT 1";


                MySqlCommand cmd = new MySqlCommand(Idsql, connection);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    lastRef = Convert.ToInt16(result);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Ref_No Diesel");
            }

            return lastRef;
        }


        void SetDieselStock()
        {
            decimal lastStockQuatity = 0;
            decimal lastStockAmount = 0;
            decimal newPurchaseQunatity = 0;
            decimal newPurchaseAmount = 0;
            decimal SumSafiMiqdar = 0;
            decimal SumAmount = 0;
            decimal SumSale = 0;


            using (MySqlConnection conn = new MySqlConnection(AppSettings.ConString()))
            {
                conn.Open();
                string sqlQuerryLast = @"SELECT
                                          ps.Available_Stock,
                                          ps.Available_Stock_Amount,
                                          pdp.Saafi_Miqdar,
                                          pdp.Amount
                                        FROM
                                          petrol_stock ps
                                        JOIN
                                          purchase_data_diesel pdp
                                        ON
                                          1=1
                                        ORDER BY
                                          ps.Ref_No DESC,
                                          pdp.Ref_No DESC
                                        LIMIT 1;";

                using (MySqlCommand cmd = new MySqlCommand(sqlQuerryLast, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lastStockQuatity = reader.GetDecimal(0);
                            lastStockAmount = reader.GetDecimal(1);
                            newPurchaseQunatity = reader.GetDecimal(2);
                            newPurchaseAmount = reader.GetDecimal(3);


                        }
                    }
                }
            }


            using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
            {
                connection.Open();

                string sqlQuery = @"
                                    SELECT
                                      ROUND(SUM(Saafi_Miqdar), 3) AS TotalSumQuantity,
                                      ROUND(SUM(Amount), 3) AS TotalSumAmount
                                    FROM purchase_data_Diesel;";

                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Retrieve the values from the query result
                            SumSafiMiqdar = reader.GetDecimal(0);
                            SumAmount = reader.GetDecimal(1);
                            SumSale = Convert.ToDecimal(GetTotalSaleDiesel());




                        }
                    }
                }
            }


            //decimal unitPrice = SumSafiMiqdar == 0 ? 0 : SumAmount / SumSafiMiqdar;

            decimal availableStock = SumSafiMiqdar - SumSale;
            decimal unitPrice = SumSafiMiqdar == 0 ? 0 : (lastStockAmount + newPurchaseAmount) / (lastStockQuatity + newPurchaseQunatity);
            decimal availableAmount = unitPrice * availableStock;


            AvailableStockBoxD.Text = Math.Round(availableStock, 3).ToString();
            AvailableRateBoxD.Text = Math.Round(unitPrice, 3).ToString();
            AvailableAmountBoxD.Text = Math.Round(availableAmount, 3).ToString();

        }

        public void RemoteQuerryDiesel()
        {
            TotalPurchaseBoxD.Text = GetTotalPurchaseDiesel().ToString();
            TotalSaleTextBoxD.Text = GetTotalSaleDiesel().ToString();
            SetDieselStock();
            QuerryDiesel();
        }



        public void RemoteQureyPetrol()
        {
            TotalSaleTextBoxP.Text = GetTotalSalePetrol().ToString();
            TotalPurchaseBoxP.Text = GetTotalPurchasePetrol().ToString();
            SetStockPetrol();
            QuerryPetrol();
        }


        void SetStockPetrol()
        {
            decimal lastStockQuatity = 0;
            decimal lastStockAmount = 0;
            decimal lastStockPurchase = 0;
            decimal lastStockUnitPrice = 0;
            decimal newPurchaseQunatity = 0;
            decimal newPurchaseAmount = 0;
            decimal SumSafiMiqdar = 0;
            decimal SumAmount = 0;
            decimal SumSale = 0;


            decimal availableStock = 0;
            decimal unitPrice = 0;
            decimal availableAmount = 0;


            using (MySqlConnection conn = new MySqlConnection(AppSettings.ConString()))
            {
                conn.Open();
                string sqlQuerryLast = @"SELECT
                                          ps.Available_Stock,
                                          ps.Available_Stock_Amount,
                                          ps.Total_Purchase,
                                          ps.Available_Stock_Unit_Price,
                                          pdp.Saafi_Miqdar,
                                          pdp.Amount
                                        FROM
                                          petrol_stock ps
                                        JOIN
                                          purchase_data_petrol pdp
                                        ON
                                          1=1
                                        ORDER BY
                                          ps.Ref_No DESC,
                                          pdp.Ref_No DESC
                                        LIMIT 1;";

                using (MySqlCommand cmd = new MySqlCommand(sqlQuerryLast, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lastStockQuatity = reader.GetDecimal(0);
                            lastStockAmount = reader.GetDecimal(1);
                            lastStockPurchase = reader.GetDecimal(2);
                            lastStockUnitPrice = reader.GetDecimal(3);
                            newPurchaseQunatity = reader.GetDecimal(4);
                            newPurchaseAmount = reader.GetDecimal(5);
                        }
                    }
                }
            }


            using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
            {
                connection.Open();

                string sqlQuery = @"
                                    SELECT
                                      ROUND(SUM(Saafi_Miqdar), 3) AS TotalSumQuantity,
                                      ROUND(SUM(Amount), 3) AS TotalSumAmount
                                    FROM purchase_data_petrol;";

                using (MySqlCommand command = new MySqlCommand(sqlQuery, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Retrieve the values from the query result
                            SumSafiMiqdar = reader.GetDecimal(0);
                            SumAmount = reader.GetDecimal(1);
                            SumSale = Convert.ToDecimal(GetTotalSalePetrol());

                            /* decimal availableStock = reader.GetDecimal(3);
                             decimal unitPrice = reader.GetDecimal(4);
                             decimal availableAmount = reader.GetDecimal(5);*/


                        }
                    }
                }
            }


            //decimal unitPrice = SumSafiMiqdar == 0 ? 0 : SumAmount / SumSafiMiqdar;

            if (lastStockPurchase != SumSafiMiqdar)
            {
                availableStock = SumSafiMiqdar - SumSale;
                unitPrice = SumSafiMiqdar == 0 ? 0 : (lastStockAmount + newPurchaseAmount) / (lastStockQuatity + newPurchaseQunatity);
                availableAmount = unitPrice * availableStock;
            }
            else
            {
                availableStock = SumSafiMiqdar - SumSale;
                unitPrice = lastStockUnitPrice;
                availableAmount = unitPrice * availableStock;
            }

            AvailableStockBoxPetrol.Text = Math.Round(availableStock, 3).ToString();
            AvailableRateBoxPetrol.Text = Math.Round(unitPrice, 3).ToString();
            AvailableAmountBoxPetrol.Text = Math.Round(availableAmount, 3).ToString();
        }

        string RoundToString(double value)
        {
            return Math.Round(value, 2).ToString();
        }
    }
}
