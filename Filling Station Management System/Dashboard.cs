using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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

        double totalStockPetrol, availableStockPetrol;
        double totalStockDiesel, availableStockDiesel;
        private float GetTotalSalePetrol()
        {
            float totalSaleDiesel = 0;


            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                string sqlCom = $"SELECT Round(SUM(netQuantity),2) FROM unit1_sales_data;";


                MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    totalSaleDiesel = float.Parse(result.ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Total Sale Petrol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return totalSaleDiesel;
        }

        private float GetTotalSaleDiesel()
        {
            float totalSalePetrol = 0;


            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                string sqlCom = $"SELECT \r\n    (SELECT Round(SUM(netQuantity),2) FROM unit2_sales_data) +\r\n    (SELECT Round(SUM(netQuantity),2) FROM unit3_sales_data) +\r\n    (SELECT Round(SUM(netQuantity),2) FROM unit4_sales_data) AS TotalSumQuantity;";


                MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    totalSalePetrol = float.Parse(result.ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Total Sale Diesel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return totalSalePetrol;
        }


        private float GetTotalPurchaseDiesel()
        {
            float totalSalePetrol = 0;


            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                string sqlCom = "SELECT \r\n    (SELECT Round(SUM(Saafi_Miqdar),2) FROM purchase_data_diesel) AS TotalSumQuantity;";

                MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    totalSalePetrol = float.Parse(result.ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Total Purchase Diesel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return totalSalePetrol;
        }

        private float GetTotalPurchasePetrol()
        {
            float totalPurchasePetrol = 0;


            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                string sqlCom = "SELECT \r\n    (SELECT Round(SUM(Saafi_Miqdar),2) FROM purchase_data_petrol) AS TotalSumQuantity;";

                MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    totalPurchasePetrol = float.Parse(result.ToString());
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

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                string sqlCom = $"SELECT Round(Rate_per_Liter,2) FROM purchase_data_petrol ORDER BY Ref_No DESC LIMIT 1;";

                MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    lastRate = float.Parse(result.ToString());
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

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                string sqlCom = $"SELECT Round(Rate_per_Liter,2) FROM purchase_data_diesel ORDER BY Ref_No DESC LIMIT 1;";

                MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    lastRate = float.Parse(result.ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Diesel Rate", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lastRate;
        }


        private double GetLastAvailableStockPetrol()
        {
            double lastPetrolStock = 0;
            float availableStock = 0;
            float totalSale = 0;
            try
            {
                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                string sqlCom = "SELECT Round(Available_Stock, 2), Round(Total_Sale, 2) FROM petrol_stock ORDER BY Ref_No DESC LIMIT 1;";

                MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Read the values of the two columns
                    availableStock = reader.GetFloat(0);
                    totalSale = reader.GetFloat(1);

                    // Now you have the values in the variables availableStock and totalSale
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Available Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return availableStock + totalSale;
        }

        private double GetLastAvailableStockDiesel()
        {
            double lastDieselStock = 0;
            try
            {

                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                string sqlCom = $"SELECT Round(Available_Stock,2) FROM Diesel_stock ORDER BY Ref_No DESC LIMIT 1;";

                MySqlCommand cmd = new MySqlCommand(sqlCom, connection);
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    lastDieselStock = float.Parse(result.ToString());
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message, "Availalbe Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lastDieselStock;
        }


        private void Dashboard_Load(object sender, EventArgs e)
        {
            TotalSaleDieselLabel.Text = GetTotalSaleDiesel().ToString();
            TotalSalePetrolLabel.Text = GetTotalSalePetrol().ToString();
            TotalPurchaseDiesel.Text = GetTotalPurchaseDiesel().ToString();
            TotalPurchasePetrol.Text = GetTotalPurchasePetrol().ToString();
            UnitPriceLabelDiesel.Text = GetLastRateDiesel().ToString();
            UnitPriceLabelPetrol.Text = GetLastRatePetrol().ToString();
            PetrolPercent();
            DeiselPercent();
            DieselChartSetup();
        }


        void PetrolPercent()
        {

            totalStockPetrol = GetTotalPurchasePetrol();
            availableStockPetrol = GetTotalPurchasePetrol() - GetTotalSalePetrol();
            PetrolStockLable.Text = (availableStockPetrol).ToString();
            if (availableStockPetrol > 0)
            {
                var value = (Convert.ToInt16((availableStockPetrol / totalStockPetrol) * 100));
                PetrolStockGuage.Value = value;

                PetrolStockGuage.TransitionValue(value, 1500);


            }
            else
            { PetrolStockGuage.TransitionValue(0, 1500); }


        }



        void DeiselPercent()
        {
            totalStockDiesel = GetTotalPurchaseDiesel();
            availableStockDiesel = GetTotalPurchaseDiesel() - GetTotalSaleDiesel();
            DieselStockLable.Text = (availableStockDiesel).ToString();
            if (availableStockDiesel > 0)
            {
                var value = (Convert.ToInt16((availableStockDiesel / totalStockDiesel) * 100));
                DieselStockGuage.Value = value;
                DieselStockGuage.TransitionValue(value, 1500);

            }
            else
            {
                DieselStockGuage.TransitionValue(0, 1500);
            }
        }

        void DieselChartSetup()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(AppSettings.ConString());
                connection.Open();

                // Retrieve data for unit1_sales_data for the last 7 days
                string unit1Query = "SELECT Date,  netQuantity FROM unit1_sales_data WHERE Date >= DATE(NOW()) - INTERVAL 7 DAY";


                string unit2Query = "SELECT  netQuantity FROM unit2_sales_data WHERE Date >= DATE(NOW()) - INTERVAL 7 DAY";
                string unit3Query = "SELECT  netQuantity FROM unit3_sales_data WHERE Date >= DATE(NOW()) - INTERVAL 7 DAY";
                string unit4Query = "SELECT  netQuantity FROM unit4_sales_data WHERE Date >= DATE(NOW()) - INTERVAL 7 DAY";

                MySqlCommand unit1Cmd = new MySqlCommand(unit1Query, connection);
                MySqlCommand unit2Cmd = new MySqlCommand(unit2Query, connection);
                MySqlCommand unit3Cmd = new MySqlCommand(unit3Query, connection);
                MySqlCommand unit4Cmd = new MySqlCommand(unit4Query, connection);

                MySqlDataAdapter unit1Adapter = new MySqlDataAdapter(unit1Cmd);
                MySqlDataAdapter unit2Adapter = new MySqlDataAdapter(unit2Cmd);
                MySqlDataAdapter unit3Adapter = new MySqlDataAdapter(unit3Cmd);
                MySqlDataAdapter unit4Adapter = new MySqlDataAdapter(unit4Cmd);

                DataTable unit1Table = new DataTable();
                DataTable unit2Table = new DataTable();
                DataTable unit3Table = new DataTable();
                DataTable unit4Table = new DataTable();

                unit1Adapter.Fill(unit1Table);
                unit2Adapter.Fill(unit2Table);
                unit3Adapter.Fill(unit3Table);
                unit4Adapter.Fill(unit4Table);

                // Now you have the data for the last 7 days from both tables in unit1Table and unit2Table.

                // Assuming you have a chart control named "chart1"
                SalesChart.Series.Clear();

                // Create series for unit1_sales_data
                Series series1 = new Series("Unit 1 Sales");
                series1.ChartType = SeriesChartType.Column;
                int i = 0;
                foreach (DataRow row in unit1Table.Rows)
                {

                    double netQuantity = Convert.ToDouble(row["netQuantity"]);
                    series1.Points.AddXY($"Day {i++}", netQuantity);
                    series1.Label = netQuantity.ToString(); // Assign the netQuantity as the label


                }


                int j = 1;
                // Create series for unit2_sales_data
                Series series2 = new Series("Unit 2 Sales");
                series2.ChartType = SeriesChartType.Column;

                foreach (DataRow row in unit2Table.Rows)
                {

                    double netQuantity = Convert.ToDouble(row["netQuantity"]);
                    series2.Points.AddXY($"Day {j++}", netQuantity);
                    series2.Label = netQuantity.ToString();
                }


                int k = 0;
                // Create series for unit1_sales_data
                Series series3 = new Series("Unit 3 Sales");
                series3.ChartType = SeriesChartType.Column;

                foreach (DataRow row in unit3Table.Rows)
                {

                    double netQuantity = Convert.ToDouble(row["netQuantity"]);
                    series3.Points.AddXY($"Day {k + 1}", netQuantity);
                    series3.Label = netQuantity.ToString();
                }
                int l = 0;
                // Create series for unit2_sales_data
                Series series4 = new Series("Unit 4 Sales");
                series4.ChartType = SeriesChartType.Column;

                foreach (DataRow row in unit4Table.Rows)
                {

                    double netQuantity = Convert.ToDouble(row["netQuantity"]);
                    series4.Points.AddXY($"Day {l + 1}", netQuantity);
                    series4.Label = netQuantity.ToString();
                }

                // Add the series to the chart
                SalesChart.Series.Add(series1);
                SalesChart.Series.Add(series2);
                SalesChart.Series.Add(series3);
                SalesChart.Series.Add(series4);
                // Customize chart appearance as needed


                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Data Retrieval Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        private void bunifuRadialGauge2_ValueChanged(object sender, Bunifu.UI.WinForms.BunifuRadialGauge.ValueChangedEventArgs e)
        {

        }
    }
}
