using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using MySql.Data.MySqlClient;

namespace Filling_Station_Management_System
{
    public partial class MainForm : KryptonForm
    {
        public MainForm()
        {
            InitializeComponent();

        }

        public string username;
        public void loadForm(object Form)
        {
            if (this.MainPanel.Controls.Count > 0)
            {
                this.MainPanel.Controls.RemoveAt(0);

            }
            KryptonForm f = Form as KryptonForm;

            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.MainPanel.Controls.Add(f);
            this.MainPanel.Tag = f;
            f.Show();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            DashboardButton.Select();
            loadForm(new Dashboard());
            PanelNameLabel.Text = "Dashboard";

            UsernameLabel.Text = LoginForm.username;
            AdminCheck();
            PumpNameLabel.Text = $"Pump {AppSettings.PumpSelect + 1}";
        }


        private void bunifuLabel7_Click(object sender, EventArgs e)
        {

        }
        private void SaleLedgerButton_Click(object sender, EventArgs e)
        {

            loadForm(new SaleLedger());
            PanelNameLabel.Text = "Daily Sale Ledger";
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            loadForm(new Dashboard());
            PanelNameLabel.Text = "Dashboard";
        }

        private void SaleButton_Click(object sender, EventArgs e)
        {
            loadForm(new EnterySale());
            PanelNameLabel.Text = "Entery Sale";
        }

        private void PurchaseButton_Click(object sender, EventArgs e)
        {
            loadForm(new EnteryPurchase());
            PanelNameLabel.Text = "Entery Purchase";
        }

        private void bunifuLabel22_Click(object sender, EventArgs e)
        {

        }

        private void PurchaseLedgerButton_Click(object sender, EventArgs e)
        {
            loadForm(new PurchaseLedger());
            PanelNameLabel.Text = "Daily Purchase Ledger";
        }

        private void SummeryButton_Click(object sender, EventArgs e)
        {
            loadForm(new Summary());
            PanelNameLabel.Text = "Summery Panel";
        }

        private void UserSettingsButton_Click(object sender, EventArgs e)
        {
            loadForm(new UserSettings());
            PanelNameLabel.Text = "User Settings";
        }

        private void CloseAppBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void AdminCheck()
        {
            try
            {

                MySqlConnection con = new MySqlConnection(AppSettings.ConString());

                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE Username=@Username", con);
                cmd.Parameters.AddWithValue("@Username", username);


                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    MessageBox.Show("Invalid Username");
                }
                else
                {
                    reader.Read();
                    string UserTypeFromDatabase = reader.GetString("User_Type");

                    if (UserTypeFromDatabase == "Admin")
                    {
                        bunifuButton1.Enabled = true;
                    }
                    else
                    {
                        bunifuButton1.Enabled = false;

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Run Xampp Services or " + ex.Message);
            }
        }

        private void StockButton_Click(object sender, EventArgs e)
        {
            loadForm(new StockForm());
            PanelNameLabel.Text = "Stock";
        }

        private void SrockLedgerButton_Click(object sender, EventArgs e)
        {
            loadForm(new StockLedger());

            PanelNameLabel.Text = "Stock Ledger";
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
    }
}
