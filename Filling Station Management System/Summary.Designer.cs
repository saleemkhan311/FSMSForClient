namespace Filling_Station_Management_System
{
    partial class Summary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Summary));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PetrolSummaryDataGrid = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DieselSummaryDataGrid = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.TotalSaleLabel = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SaveExcelButton = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.TabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PetrolSummaryDataGrid)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DieselSummaryDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Controls.Add(this.tabPage2);
            this.TabControl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl.Location = new System.Drawing.Point(11, 81);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(825, 547);
            this.TabControl.TabIndex = 202;
            this.TabControl.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PetrolSummaryDataGrid);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(817, 513);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Petrol";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PetrolSummaryDataGrid
            // 
            this.PetrolSummaryDataGrid.AllowCustomTheming = false;
            this.PetrolSummaryDataGrid.AllowDrop = true;
            this.PetrolSummaryDataGrid.AllowUserToAddRows = false;
            this.PetrolSummaryDataGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.PetrolSummaryDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.PetrolSummaryDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.PetrolSummaryDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PetrolSummaryDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.PetrolSummaryDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PetrolSummaryDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.PetrolSummaryDataGrid.ColumnHeadersHeight = 40;
            this.PetrolSummaryDataGrid.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.PetrolSummaryDataGrid.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.PetrolSummaryDataGrid.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.PetrolSummaryDataGrid.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.PetrolSummaryDataGrid.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.PetrolSummaryDataGrid.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.PetrolSummaryDataGrid.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.PetrolSummaryDataGrid.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.PetrolSummaryDataGrid.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.PetrolSummaryDataGrid.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.PetrolSummaryDataGrid.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.PetrolSummaryDataGrid.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.PetrolSummaryDataGrid.CurrentTheme.Name = null;
            this.PetrolSummaryDataGrid.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.PetrolSummaryDataGrid.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.PetrolSummaryDataGrid.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.PetrolSummaryDataGrid.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.PetrolSummaryDataGrid.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PetrolSummaryDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.PetrolSummaryDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PetrolSummaryDataGrid.EnableHeadersVisualStyles = false;
            this.PetrolSummaryDataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.PetrolSummaryDataGrid.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.PetrolSummaryDataGrid.HeaderBgColor = System.Drawing.Color.Empty;
            this.PetrolSummaryDataGrid.HeaderForeColor = System.Drawing.Color.White;
            this.PetrolSummaryDataGrid.Location = new System.Drawing.Point(3, 3);
            this.PetrolSummaryDataGrid.Name = "PetrolSummaryDataGrid";
            this.PetrolSummaryDataGrid.ReadOnly = true;
            this.PetrolSummaryDataGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PetrolSummaryDataGrid.RowHeadersVisible = false;
            this.PetrolSummaryDataGrid.RowTemplate.Height = 40;
            this.PetrolSummaryDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PetrolSummaryDataGrid.Size = new System.Drawing.Size(811, 507);
            this.PetrolSummaryDataGrid.TabIndex = 0;
            this.PetrolSummaryDataGrid.TabStop = false;
            this.PetrolSummaryDataGrid.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DieselSummaryDataGrid);
            this.tabPage2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(817, 513);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Diesel";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DieselSummaryDataGrid
            // 
            this.DieselSummaryDataGrid.AllowCustomTheming = false;
            this.DieselSummaryDataGrid.AllowDrop = true;
            this.DieselSummaryDataGrid.AllowUserToAddRows = false;
            this.DieselSummaryDataGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.DieselSummaryDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DieselSummaryDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DieselSummaryDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DieselSummaryDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DieselSummaryDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DieselSummaryDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DieselSummaryDataGrid.ColumnHeadersHeight = 40;
            this.DieselSummaryDataGrid.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.DieselSummaryDataGrid.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.DieselSummaryDataGrid.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DieselSummaryDataGrid.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.DieselSummaryDataGrid.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.DieselSummaryDataGrid.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.DieselSummaryDataGrid.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.DieselSummaryDataGrid.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.DieselSummaryDataGrid.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.DieselSummaryDataGrid.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DieselSummaryDataGrid.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.DieselSummaryDataGrid.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DieselSummaryDataGrid.CurrentTheme.Name = null;
            this.DieselSummaryDataGrid.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DieselSummaryDataGrid.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.DieselSummaryDataGrid.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DieselSummaryDataGrid.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.DieselSummaryDataGrid.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DieselSummaryDataGrid.DefaultCellStyle = dataGridViewCellStyle6;
            this.DieselSummaryDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DieselSummaryDataGrid.EnableHeadersVisualStyles = false;
            this.DieselSummaryDataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.DieselSummaryDataGrid.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.DieselSummaryDataGrid.HeaderBgColor = System.Drawing.Color.Empty;
            this.DieselSummaryDataGrid.HeaderForeColor = System.Drawing.Color.White;
            this.DieselSummaryDataGrid.Location = new System.Drawing.Point(3, 3);
            this.DieselSummaryDataGrid.Name = "DieselSummaryDataGrid";
            this.DieselSummaryDataGrid.ReadOnly = true;
            this.DieselSummaryDataGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DieselSummaryDataGrid.RowHeadersVisible = false;
            this.DieselSummaryDataGrid.RowTemplate.Height = 40;
            this.DieselSummaryDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DieselSummaryDataGrid.Size = new System.Drawing.Size(811, 507);
            this.DieselSummaryDataGrid.TabIndex = 100;
            this.DieselSummaryDataGrid.TabStop = false;
            this.DieselSummaryDataGrid.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // TotalSaleLabel
            // 
            this.TotalSaleLabel.AllowParentOverrides = false;
            this.TotalSaleLabel.AutoEllipsis = false;
            this.TotalSaleLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.TotalSaleLabel.CursorType = System.Windows.Forms.Cursors.Default;
            this.TotalSaleLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.TotalSaleLabel.Location = new System.Drawing.Point(15, 45);
            this.TotalSaleLabel.Name = "TotalSaleLabel";
            this.TotalSaleLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TotalSaleLabel.Size = new System.Drawing.Size(102, 30);
            this.TotalSaleLabel.TabIndex = 205;
            this.TotalSaleLabel.Text = "Total Sale: ";
            this.TotalSaleLabel.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.TotalSaleLabel.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel3
            // 
            this.bunifuLabel3.AllowParentOverrides = false;
            this.bunifuLabel3.AutoEllipsis = false;
            this.bunifuLabel3.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel3.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel3.Location = new System.Drawing.Point(600, 62);
            this.bunifuLabel3.Name = "bunifuLabel3";
            this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel3.Size = new System.Drawing.Size(108, 21);
            this.bunifuLabel3.TabIndex = 205;
            this.bunifuLabel3.Text = "Change Table:";
            this.bunifuLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Purchase",
            "Sale"});
            this.comboBox1.Location = new System.Drawing.Point(715, 61);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 27);
            this.comboBox1.TabIndex = 206;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // SaveExcelButton
            // 
            this.SaveExcelButton.AllowAnimations = true;
            this.SaveExcelButton.AllowMouseEffects = true;
            this.SaveExcelButton.AllowToggling = false;
            this.SaveExcelButton.AnimationSpeed = 200;
            this.SaveExcelButton.AutoGenerateColors = false;
            this.SaveExcelButton.AutoRoundBorders = false;
            this.SaveExcelButton.AutoSizeLeftIcon = true;
            this.SaveExcelButton.AutoSizeRightIcon = true;
            this.SaveExcelButton.BackColor = System.Drawing.Color.Transparent;
            this.SaveExcelButton.BackColor1 = System.Drawing.Color.CornflowerBlue;
            this.SaveExcelButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SaveExcelButton.BackgroundImage")));
            this.SaveExcelButton.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.SaveExcelButton.ButtonText = "Save To Excel";
            this.SaveExcelButton.ButtonTextMarginLeft = 0;
            this.SaveExcelButton.ColorContrastOnClick = 45;
            this.SaveExcelButton.ColorContrastOnHover = 45;
            this.SaveExcelButton.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.SaveExcelButton.CustomizableEdges = borderEdges1;
            this.SaveExcelButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.SaveExcelButton.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.SaveExcelButton.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.SaveExcelButton.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.SaveExcelButton.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.SaveExcelButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveExcelButton.ForeColor = System.Drawing.Color.White;
            this.SaveExcelButton.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveExcelButton.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.SaveExcelButton.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.SaveExcelButton.IconMarginLeft = 11;
            this.SaveExcelButton.IconPadding = 10;
            this.SaveExcelButton.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SaveExcelButton.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.SaveExcelButton.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.SaveExcelButton.IconSize = 25;
            this.SaveExcelButton.IdleBorderColor = System.Drawing.Color.CornflowerBlue;
            this.SaveExcelButton.IdleBorderRadius = 15;
            this.SaveExcelButton.IdleBorderThickness = 1;
            this.SaveExcelButton.IdleFillColor = System.Drawing.Color.CornflowerBlue;
            this.SaveExcelButton.IdleIconLeftImage = null;
            this.SaveExcelButton.IdleIconRightImage = null;
            this.SaveExcelButton.IndicateFocus = false;
            this.SaveExcelButton.Location = new System.Drawing.Point(716, 12);
            this.SaveExcelButton.Name = "SaveExcelButton";
            this.SaveExcelButton.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.SaveExcelButton.OnDisabledState.BorderRadius = 15;
            this.SaveExcelButton.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.SaveExcelButton.OnDisabledState.BorderThickness = 1;
            this.SaveExcelButton.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.SaveExcelButton.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.SaveExcelButton.OnDisabledState.IconLeftImage = null;
            this.SaveExcelButton.OnDisabledState.IconRightImage = null;
            this.SaveExcelButton.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.SaveExcelButton.onHoverState.BorderRadius = 15;
            this.SaveExcelButton.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.SaveExcelButton.onHoverState.BorderThickness = 1;
            this.SaveExcelButton.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.SaveExcelButton.onHoverState.ForeColor = System.Drawing.Color.White;
            this.SaveExcelButton.onHoverState.IconLeftImage = null;
            this.SaveExcelButton.onHoverState.IconRightImage = null;
            this.SaveExcelButton.OnIdleState.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.SaveExcelButton.OnIdleState.BorderRadius = 15;
            this.SaveExcelButton.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.SaveExcelButton.OnIdleState.BorderThickness = 1;
            this.SaveExcelButton.OnIdleState.FillColor = System.Drawing.Color.CornflowerBlue;
            this.SaveExcelButton.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.SaveExcelButton.OnIdleState.IconLeftImage = null;
            this.SaveExcelButton.OnIdleState.IconRightImage = null;
            this.SaveExcelButton.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.SaveExcelButton.OnPressedState.BorderRadius = 15;
            this.SaveExcelButton.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.SaveExcelButton.OnPressedState.BorderThickness = 1;
            this.SaveExcelButton.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.SaveExcelButton.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.SaveExcelButton.OnPressedState.IconLeftImage = null;
            this.SaveExcelButton.OnPressedState.IconRightImage = null;
            this.SaveExcelButton.Size = new System.Drawing.Size(116, 35);
            this.SaveExcelButton.TabIndex = 207;
            this.SaveExcelButton.TabStop = false;
            this.SaveExcelButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SaveExcelButton.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.SaveExcelButton.TextMarginLeft = 0;
            this.SaveExcelButton.TextPadding = new System.Windows.Forms.Padding(0);
            this.SaveExcelButton.UseDefaultRadiusAndThickness = true;
            this.SaveExcelButton.Click += new System.EventHandler(this.SaveExcelButton_Click);
            // 
            // Summary
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(845, 640);
            this.Controls.Add(this.SaveExcelButton);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.TotalSaleLabel);
            this.Controls.Add(this.bunifuLabel3);
            this.Controls.Add(this.TabControl);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Summary";
            this.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateActive.Border.Rounding = 15;
            this.Text = "Summery";
            this.Load += new System.EventHandler(this.Summery_Load);
            this.TabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PetrolSummaryDataGrid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DieselSummaryDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private Bunifu.UI.WinForms.BunifuDataGridView PetrolSummaryDataGrid;
        private System.Windows.Forms.TabPage tabPage2;
        private Bunifu.UI.WinForms.BunifuDataGridView DieselSummaryDataGrid;
        private Bunifu.UI.WinForms.BunifuLabel TotalSaleLabel;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel3;
        private System.Windows.Forms.ComboBox comboBox1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton SaveExcelButton;
    }
}