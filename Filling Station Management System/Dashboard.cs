using System;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using MySql.Data.MySqlClient;
using static System.ComponentModel.Design.ObjectSelectorEditor;


namespace Filling_Station_Management_System
{
    public partial class Dashboard : KryptonForm
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        // string[] unitData = { "Unit 1", "Unit 2", "Unit 3", "Unit 4" };

        double totalStockPetrol, availableStockPetrol;
        double totalStockDiesel, availableStockDiesel;
        private double GetTotalSalePetrol()
        {
            double totalSaleDiesel = 0;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
                {
                    connection.Open();

                    string sqlCom = @"SELECT ROUND(SUM(netQuantity), 2) AS total_quantity
                                        FROM(
                                            SELECT netQuantity FROM unit1_sales_data
                                            UNION ALL
                                            SELECT netQuantity FROM unit2_sales_data
                                            UNION ALL
                                            SELECT netQuantity FROM unit3_sales_data
                                            UNION ALL
                                            SELECT Quantity FROM direct_sale_petrol
                                        ) AS combined_sales_data;";
                    MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        totalSaleDiesel = Convert.ToDouble(result.ToString());
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Total Sale Petrol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return totalSaleDiesel;
        }

        private double GetTotalSaleDiesel()
        {
            double totalSalePetrol = 0;

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
                        totalSalePetrol = Convert.ToDouble(result.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Total Sale Diesel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return totalSalePetrol;
        }


        private double GetTotalPurchaseDiesel()
        {
            double totalSalePetrol = 0;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
                {
                    connection.Open();

                    string sqlCom = "SELECT \r\n    (SELECT Round(SUM(Saafi_Miqdar),2) FROM purchase_data_diesel) AS TotalSumQuantity;";

                    MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        totalSalePetrol = Convert.ToDouble(result.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Total Purchase Diesel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return totalSalePetrol;
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
        private double GetLastRatePetrol()
        {
            double lastRate = 0;
            try
            {

                using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
                {
                    connection.Open();

                    string sqlCom = $"SELECT Available_Stock_Unit_Price FROM petrol_stock ORDER BY Ref_No DESC LIMIT 1;";

                    MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        lastRate = Convert.ToDouble(result);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Petrol Rate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lastRate;
        }
        private double GetLastRateDiesel()
        {
            double lastRate = 0;
            try
            {

                using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))

                {
                    connection.Open();

                    string sqlCom = $"SELECT Round(Available_Stock_Unit_Price,2) FROM diesel_stock ORDER BY Ref_No DESC LIMIT 1;";

                    MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        lastRate = Convert.ToDouble(result.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Diesel Rate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lastRate;
        }


        private void Dashboard_Load(object sender, EventArgs e)
        {
           LoadDash();

        }

        void LoadDash()
        {
            TotalSaleDieselLabel.Text = AppSettings.RoundToString(GetTotalSaleDiesel(), false);
            TotalSalePetrolLabel.Text = AppSettings.RoundToString(GetTotalSalePetrol(), false);
            TotalPurchaseDiesel.Text = AppSettings.RoundToString(GetTotalPurchaseDiesel(), false);
            TotalPurchasePetrol.Text = AppSettings.RoundToString(GetTotalPurchasePetrol(), false);
            UnitPriceLabelDiesel.Text = GetLastRateDiesel().ToString("C4");
            UnitPriceLabelPetrol.Text = GetLastRatePetrol().ToString("C4");
            PetrolPercent();
            DeiselPercent();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            PasswordCheckPanel passCheck = new PasswordCheckPanel();
            passCheck.ShowDialog();
            if (passCheck.DialogResult == DialogResult.OK)
            { 
                ResetTables();
                LoadDash(); 


            }
        }


        void ResetTables()
        {
            using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand("CALL DeleteAllExceptFirstRow()", connection);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Database Reseted successfully ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ExportTables();
        }


        private void ExportTables()
        {

            /* using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
             {
                 if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                 {
                     outputDirectory = folderBrowserDialog.SelectedPath;
                     MessageBox.Show($"Selected Output Path: {outputDirectory}", "Path Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
             }*/

            //ModifyStoredProcedure(outputDirectory);

            using (MySqlConnection connection = new MySqlConnection(AppSettings.ConString()))
            {
                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand("CALL ExportAllTablesToCSV()", connection);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Tables exported successfully to CSV files!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void PetrolPercent()
        {

            totalStockPetrol = Convert.ToInt32(GetTotalPurchasePetrol());
            availableStockPetrol = Convert.ToInt32(GetTotalPurchasePetrol() - GetTotalSalePetrol());
            //PetrolStockLable.Text = ((int)availableStockPetrol).ToString();
            PetrolStockLable.Text = AppSettings.RoundToString(availableStockPetrol,false);
            if (availableStockPetrol > 0)
            {
                var value = ((availableStockPetrol / totalStockPetrol) * 100);

                PetrolStockGuage.Value = (int)value;

                PetrolStockGuage.TransitionValue((int)value, 1500);


            }
            else
            { PetrolStockGuage.TransitionValue(0, 1500); }


        }



        void DeiselPercent()
        {
            totalStockDiesel = Convert.ToInt32(GetTotalPurchaseDiesel());
            availableStockDiesel = Convert.ToInt32(GetTotalPurchaseDiesel() - GetTotalSaleDiesel());
            //DieselStockLable.Text = ((int)availableStockDiesel).ToString();
            DieselStockLable.Text = AppSettings.RoundToString(availableStockDiesel,false);
            if (availableStockDiesel > 0)
            {
                var value = ((availableStockDiesel / totalStockDiesel) * 100);
                DieselStockGuage.Value = (int)value;
                DieselStockGuage.TransitionValue((int)value, 1500);

            }
            else
            {
                DieselStockGuage.TransitionValue(0, 1500);
            }
        }


    }
}
