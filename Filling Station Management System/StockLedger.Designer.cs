namespace Filling_Station_Management_System
{
    partial class StockLedger
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockLedger));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges10 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges11 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges12 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PetrolStockDataGrid = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DieselStockDataGrid = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.SaveExcelButton = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.RefreshButton = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.RemoveButton = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.TabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PetrolStockDataGrid)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DieselStockDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Controls.Add(this.tabPage2);
            this.TabControl.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl.Location = new System.Drawing.Point(14, 81);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(817, 552);
            this.TabControl.TabIndex = 208;
            this.TabControl.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PetrolStockDataGrid);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(809, 518);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Petrol";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PetrolStockDataGrid
            // 
            this.PetrolStockDataGrid.AllowCustomTheming = false;
            this.PetrolStockDataGrid.AllowDrop = true;
            this.PetrolStockDataGrid.AllowUserToAddRows = false;
            this.PetrolStockDataGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black;
            this.PetrolStockDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.PetrolStockDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.PetrolStockDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PetrolStockDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.PetrolStockDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PetrolStockDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.PetrolStockDataGrid.ColumnHeadersHeight = 40;
            this.PetrolStockDataGrid.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.PetrolStockDataGrid.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.PetrolStockDataGrid.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.PetrolStockDataGrid.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.PetrolStockDataGrid.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.PetrolStockDataGrid.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.PetrolStockDataGrid.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.PetrolStockDataGrid.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.PetrolStockDataGrid.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.PetrolStockDataGrid.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.PetrolStockDataGrid.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.PetrolStockDataGrid.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.PetrolStockDataGrid.CurrentTheme.Name = null;
            this.PetrolStockDataGrid.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.PetrolStockDataGrid.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.PetrolStockDataGrid.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.PetrolStockDataGrid.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.PetrolStockDataGrid.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PetrolStockDataGrid.DefaultCellStyle = dataGridViewCellStyle21;
            this.PetrolStockDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PetrolStockDataGrid.EnableHeadersVisualStyles = false;
            this.PetrolStockDataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.PetrolStockDataGrid.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.PetrolStockDataGrid.HeaderBgColor = System.Drawing.Color.Empty;
            this.PetrolStockDataGrid.HeaderForeColor = System.Drawing.Color.White;
            this.PetrolStockDataGrid.Location = new System.Drawing.Point(3, 3);
            this.PetrolStockDataGrid.Name = "PetrolStockDataGrid";
            this.PetrolStockDataGrid.ReadOnly = true;
            this.PetrolStockDataGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PetrolStockDataGrid.RowHeadersVisible = false;
            this.PetrolStockDataGrid.RowTemplate.Height = 40;
            this.PetrolStockDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PetrolStockDataGrid.Size = new System.Drawing.Size(803, 512);
            this.PetrolStockDataGrid.TabIndex = 0;
            this.PetrolStockDataGrid.TabStop = false;
            this.PetrolStockDataGrid.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DieselStockDataGrid);
            this.tabPage2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(603, 391);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Diesel";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DieselStockDataGrid
            // 
            this.DieselStockDataGrid.AllowCustomTheming = false;
            this.DieselStockDataGrid.AllowDrop = true;
            this.DieselStockDataGrid.AllowUserToAddRows = false;
            this.DieselStockDataGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black;
            this.DieselStockDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle22;
            this.DieselStockDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DieselStockDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DieselStockDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DieselStockDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DieselStockDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.DieselStockDataGrid.ColumnHeadersHeight = 40;
            this.DieselStockDataGrid.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.DieselStockDataGrid.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.DieselStockDataGrid.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DieselStockDataGrid.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.DieselStockDataGrid.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.DieselStockDataGrid.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.DieselStockDataGrid.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.DieselStockDataGrid.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.DodgerBlue;
            this.DieselStockDataGrid.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.DieselStockDataGrid.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DieselStockDataGrid.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.DieselStockDataGrid.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DieselStockDataGrid.CurrentTheme.Name = null;
            this.DieselStockDataGrid.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DieselStockDataGrid.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.DieselStockDataGrid.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DieselStockDataGrid.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.DieselStockDataGrid.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DieselStockDataGrid.DefaultCellStyle = dataGridViewCellStyle24;
            this.DieselStockDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DieselStockDataGrid.EnableHeadersVisualStyles = false;
            this.DieselStockDataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.DieselStockDataGrid.HeaderBackColor = System.Drawing.Color.DodgerBlue;
            this.DieselStockDataGrid.HeaderBgColor = System.Drawing.Color.Empty;
            this.DieselStockDataGrid.HeaderForeColor = System.Drawing.Color.White;
            this.DieselStockDataGrid.Location = new System.Drawing.Point(3, 3);
            this.DieselStockDataGrid.Name = "DieselStockDataGrid";
            this.DieselStockDataGrid.ReadOnly = true;
            this.DieselStockDataGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.DieselStockDataGrid.RowHeadersVisible = false;
            this.DieselStockDataGrid.RowTemplate.Height = 40;
            this.DieselStockDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DieselStockDataGrid.Size = new System.Drawing.Size(597, 385);
            this.DieselStockDataGrid.TabIndex = 100;
            this.DieselStockDataGrid.TabStop = false;
            this.DieselStockDataGrid.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
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
            borderEdges10.BottomLeft = true;
            borderEdges10.BottomRight = true;
            borderEdges10.TopLeft = true;
            borderEdges10.TopRight = true;
            this.SaveExcelButton.CustomizableEdges = borderEdges10;
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
            this.SaveExcelButton.Location = new System.Drawing.Point(170, 69);
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
            this.SaveExcelButton.TabIndex = 211;
            this.SaveExcelButton.TabStop = false;
            this.SaveExcelButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SaveExcelButton.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.SaveExcelButton.TextMarginLeft = 0;
            this.SaveExcelButton.TextPadding = new System.Windows.Forms.Padding(0);
            this.SaveExcelButton.UseDefaultRadiusAndThickness = true;
            this.SaveExcelButton.Click += new System.EventHandler(this.SaveExcelButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.AllowAnimations = true;
            this.RefreshButton.AllowMouseEffects = true;
            this.RefreshButton.AllowToggling = false;
            this.RefreshButton.AnimationSpeed = 200;
            this.RefreshButton.AutoGenerateColors = false;
            this.RefreshButton.AutoRoundBorders = false;
            this.RefreshButton.AutoSizeLeftIcon = true;
            this.RefreshButton.AutoSizeRightIcon = true;
            this.RefreshButton.BackColor = System.Drawing.Color.Transparent;
            this.RefreshButton.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.RefreshButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RefreshButton.BackgroundImage")));
            this.RefreshButton.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.RefreshButton.ButtonText = "Refresh";
            this.RefreshButton.ButtonTextMarginLeft = 0;
            this.RefreshButton.ColorContrastOnClick = 45;
            this.RefreshButton.ColorContrastOnHover = 45;
            this.RefreshButton.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges11.BottomLeft = true;
            borderEdges11.BottomRight = true;
            borderEdges11.TopLeft = true;
            borderEdges11.TopRight = true;
            this.RefreshButton.CustomizableEdges = borderEdges11;
            this.RefreshButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.RefreshButton.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.RefreshButton.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.RefreshButton.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.RefreshButton.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.RefreshButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshButton.ForeColor = System.Drawing.Color.White;
            this.RefreshButton.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RefreshButton.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.RefreshButton.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.RefreshButton.IconMarginLeft = 11;
            this.RefreshButton.IconPadding = 10;
            this.RefreshButton.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RefreshButton.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.RefreshButton.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.RefreshButton.IconSize = 25;
            this.RefreshButton.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.RefreshButton.IdleBorderRadius = 15;
            this.RefreshButton.IdleBorderThickness = 1;
            this.RefreshButton.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.RefreshButton.IdleIconLeftImage = null;
            this.RefreshButton.IdleIconRightImage = null;
            this.RefreshButton.IndicateFocus = false;
            this.RefreshButton.Location = new System.Drawing.Point(307, 69);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.RefreshButton.OnDisabledState.BorderRadius = 15;
            this.RefreshButton.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.RefreshButton.OnDisabledState.BorderThickness = 1;
            this.RefreshButton.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.RefreshButton.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.RefreshButton.OnDisabledState.IconLeftImage = null;
            this.RefreshButton.OnDisabledState.IconRightImage = null;
            this.RefreshButton.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.RefreshButton.onHoverState.BorderRadius = 15;
            this.RefreshButton.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.RefreshButton.onHoverState.BorderThickness = 1;
            this.RefreshButton.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.RefreshButton.onHoverState.ForeColor = System.Drawing.Color.White;
            this.RefreshButton.onHoverState.IconLeftImage = null;
            this.RefreshButton.onHoverState.IconRightImage = null;
            this.RefreshButton.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.RefreshButton.OnIdleState.BorderRadius = 15;
            this.RefreshButton.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.RefreshButton.OnIdleState.BorderThickness = 1;
            this.RefreshButton.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.RefreshButton.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.RefreshButton.OnIdleState.IconLeftImage = null;
            this.RefreshButton.OnIdleState.IconRightImage = null;
            this.RefreshButton.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.RefreshButton.OnPressedState.BorderRadius = 15;
            this.RefreshButton.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.RefreshButton.OnPressedState.BorderThickness = 1;
            this.RefreshButton.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.RefreshButton.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.RefreshButton.OnPressedState.IconLeftImage = null;
            this.RefreshButton.OnPressedState.IconRightImage = null;
            this.RefreshButton.Size = new System.Drawing.Size(114, 35);
            this.RefreshButton.TabIndex = 213;
            this.RefreshButton.TabStop = false;
            this.RefreshButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RefreshButton.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.RefreshButton.TextMarginLeft = 0;
            this.RefreshButton.TextPadding = new System.Windows.Forms.Padding(0);
            this.RefreshButton.UseDefaultRadiusAndThickness = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.AllowAnimations = true;
            this.RemoveButton.AllowMouseEffects = true;
            this.RemoveButton.AllowToggling = false;
            this.RemoveButton.AnimationSpeed = 200;
            this.RemoveButton.AutoGenerateColors = false;
            this.RemoveButton.AutoRoundBorders = false;
            this.RemoveButton.AutoSizeLeftIcon = true;
            this.RemoveButton.AutoSizeRightIcon = true;
            this.RemoveButton.BackColor = System.Drawing.Color.Transparent;
            this.RemoveButton.BackColor1 = System.Drawing.Color.OrangeRed;
            this.RemoveButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RemoveButton.BackgroundImage")));
            this.RemoveButton.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.RemoveButton.ButtonText = "Remove Entry";
            this.RemoveButton.ButtonTextMarginLeft = 0;
            this.RemoveButton.ColorContrastOnClick = 45;
            this.RemoveButton.ColorContrastOnHover = 45;
            this.RemoveButton.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges12.BottomLeft = true;
            borderEdges12.BottomRight = true;
            borderEdges12.TopLeft = true;
            borderEdges12.TopRight = true;
            this.RemoveButton.CustomizableEdges = borderEdges12;
            this.RemoveButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.RemoveButton.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.RemoveButton.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.RemoveButton.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.RemoveButton.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.RemoveButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveButton.ForeColor = System.Drawing.Color.White;
            this.RemoveButton.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RemoveButton.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.RemoveButton.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.RemoveButton.IconMarginLeft = 11;
            this.RemoveButton.IconPadding = 10;
            this.RemoveButton.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RemoveButton.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.RemoveButton.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.RemoveButton.IconSize = 25;
            this.RemoveButton.IdleBorderColor = System.Drawing.Color.OrangeRed;
            this.RemoveButton.IdleBorderRadius = 15;
            this.RemoveButton.IdleBorderThickness = 1;
            this.RemoveButton.IdleFillColor = System.Drawing.Color.OrangeRed;
            this.RemoveButton.IdleIconLeftImage = null;
            this.RemoveButton.IdleIconRightImage = null;
            this.RemoveButton.IndicateFocus = false;
            this.RemoveButton.Location = new System.Drawing.Point(443, 69);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.RemoveButton.OnDisabledState.BorderRadius = 15;
            this.RemoveButton.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.RemoveButton.OnDisabledState.BorderThickness = 1;
            this.RemoveButton.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.RemoveButton.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.RemoveButton.OnDisabledState.IconLeftImage = null;
            this.RemoveButton.OnDisabledState.IconRightImage = null;
            this.RemoveButton.onHoverState.BorderColor = System.Drawing.Color.Salmon;
            this.RemoveButton.onHoverState.BorderRadius = 15;
            this.RemoveButton.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.RemoveButton.onHoverState.BorderThickness = 1;
            this.RemoveButton.onHoverState.FillColor = System.Drawing.Color.Salmon;
            this.RemoveButton.onHoverState.ForeColor = System.Drawing.Color.White;
            this.RemoveButton.onHoverState.IconLeftImage = null;
            this.RemoveButton.onHoverState.IconRightImage = null;
            this.RemoveButton.OnIdleState.BorderColor = System.Drawing.Color.OrangeRed;
            this.RemoveButton.OnIdleState.BorderRadius = 15;
            this.RemoveButton.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.RemoveButton.OnIdleState.BorderThickness = 1;
            this.RemoveButton.OnIdleState.FillColor = System.Drawing.Color.OrangeRed;
            this.RemoveButton.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.RemoveButton.OnIdleState.IconLeftImage = null;
            this.RemoveButton.OnIdleState.IconRightImage = null;
            this.RemoveButton.OnPressedState.BorderColor = System.Drawing.Color.Red;
            this.RemoveButton.OnPressedState.BorderRadius = 15;
            this.RemoveButton.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.RemoveButton.OnPressedState.BorderThickness = 1;
            this.RemoveButton.OnPressedState.FillColor = System.Drawing.Color.Red;
            this.RemoveButton.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.RemoveButton.OnPressedState.IconLeftImage = null;
            this.RemoveButton.OnPressedState.IconRightImage = null;
            this.RemoveButton.Size = new System.Drawing.Size(114, 35);
            this.RemoveButton.TabIndex = 212;
            this.RemoveButton.TabStop = false;
            this.RemoveButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RemoveButton.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.RemoveButton.TextMarginLeft = 0;
            this.RemoveButton.TextPadding = new System.Windows.Forms.Padding(0);
            this.RemoveButton.UseDefaultRadiusAndThickness = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // StockLedger
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(850, 645);
            this.Controls.Add(this.SaveExcelButton);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StockLedger";
            this.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateActive.Border.Rounding = 20;
            this.Text = "StockLedger";
            this.Load += new System.EventHandler(this.StockLedger_Load);
            this.TabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PetrolStockDataGrid)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DieselStockDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private Bunifu.UI.WinForms.BunifuDataGridView PetrolStockDataGrid;
        private System.Windows.Forms.TabPage tabPage2;
        private Bunifu.UI.WinForms.BunifuDataGridView DieselStockDataGrid;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton SaveExcelButton;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton RefreshButton;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton RemoveButton;
    }
}