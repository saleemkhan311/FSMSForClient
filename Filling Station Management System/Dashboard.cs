using System;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using MySql.Data.MySqlClient;


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

                    string sqlCom = $"SELECT Round(SUM(netQuantity),2) FROM unit1_sales_data;";

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

                    string sqlCom = $"SELECT \r\n    (SELECT Round(SUM(netQuantity),2) FROM unit2_sales_data) +\r\n    (SELECT Round(SUM(netQuantity),2) FROM unit3_sales_data) +\r\n    (SELECT Round(SUM(netQuantity),2) FROM unit4_sales_data) AS TotalSumQuantity;";


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
            TotalSaleDieselLabel.Text = AppSettings.RoundToString(GetTotalSaleDiesel(), false);
            TotalSalePetrolLabel.Text = AppSettings.RoundToString(GetTotalSalePetrol(), false);
            TotalPurchaseDiesel.Text = AppSettings.RoundToString(GetTotalPurchaseDiesel(), false);
            TotalPurchasePetrol.Text = AppSettings.RoundToString(GetTotalPurchasePetrol(), false);
            UnitPriceLabelDiesel.Text = GetLastRateDiesel().ToString("C4");
            UnitPriceLabelPetrol.Text = GetLastRatePetrol().ToString("C4");
            PetrolPercent();
            DeiselPercent();

        }


        void PetrolPercent()
        {

            totalStockPetrol = Convert.ToInt32(GetTotalPurchasePetrol());
            availableStockPetrol = Convert.ToInt32(GetTotalPurchasePetrol() - GetTotalSalePetrol());
            PetrolStockLable.Text = ((int)availableStockPetrol).ToString();
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
            DieselStockLable.Text = ((int)availableStockDiesel).ToString();
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
