namespace QuanLyKhachHang.UserControls
{
    partial class UC_KhuyenMai
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_KhuyenMai));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties9 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties stateProperties10 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox.StateProperties();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bunifuButton7 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuButton6 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnAddKH = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuTextBox1 = new Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Open Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(188)))));
            this.label1.Location = new System.Drawing.Point(239, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "Danh sách các khuyến mại";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(103, 108);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(581, 377);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã KM";
            this.columnHeader1.Width = 101;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ngày KM";
            this.columnHeader2.Width = 123;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ngày kết thúc";
            this.columnHeader3.Width = 151;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Phần trăm khuyến mại";
            this.columnHeader4.Width = 194;
            // 
            // bunifuButton7
            // 
            this.bunifuButton7.AllowToggling = true;
            this.bunifuButton7.AnimationSpeed = 200;
            this.bunifuButton7.AutoGenerateColors = false;
            this.bunifuButton7.AutoSize = true;
            this.bunifuButton7.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton7.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(81)))), ((int)(((byte)(84)))));
            this.bunifuButton7.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton7.BackgroundImage")));
            this.bunifuButton7.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton7.ButtonText = "Xoá";
            this.bunifuButton7.ButtonTextMarginLeft = 0;
            this.bunifuButton7.ColorContrastOnClick = 45;
            this.bunifuButton7.ColorContrastOnHover = 45;
            this.bunifuButton7.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.bunifuButton7.CustomizableEdges = borderEdges1;
            this.bunifuButton7.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuButton7.DisabledBorderColor = System.Drawing.Color.Empty;
            this.bunifuButton7.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuButton7.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuButton7.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuButton7.Font = new System.Drawing.Font("K2D", 14.25F, System.Drawing.FontStyle.Bold);
            this.bunifuButton7.ForeColor = System.Drawing.Color.White;
            this.bunifuButton7.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton7.IconMarginLeft = 11;
            this.bunifuButton7.IconPadding = 10;
            this.bunifuButton7.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton7.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.bunifuButton7.IdleBorderRadius = 5;
            this.bunifuButton7.IdleBorderThickness = 1;
            this.bunifuButton7.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(81)))), ((int)(((byte)(84)))));
            this.bunifuButton7.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton7.IdleIconLeftImage")));
            this.bunifuButton7.IdleIconRightImage = null;
            this.bunifuButton7.IndicateFocus = true;
            this.bunifuButton7.Location = new System.Drawing.Point(785, 358);
            this.bunifuButton7.Name = "bunifuButton7";
            stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties1.BorderRadius = 5;
            stateProperties1.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties1.BorderThickness = 1;
            stateProperties1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties1.ForeColor = System.Drawing.Color.White;
            stateProperties1.IconLeftImage = null;
            stateProperties1.IconRightImage = null;
            this.bunifuButton7.onHoverState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties2.BorderRadius = 5;
            stateProperties2.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties2.BorderThickness = 1;
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties2.ForeColor = System.Drawing.Color.White;
            stateProperties2.IconLeftImage = null;
            stateProperties2.IconRightImage = null;
            this.bunifuButton7.OnPressedState = stateProperties2;
            this.bunifuButton7.Size = new System.Drawing.Size(102, 44);
            this.bunifuButton7.TabIndex = 22;
            this.bunifuButton7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuButton7.TextMarginLeft = 0;
            this.bunifuButton7.UseDefaultRadiusAndThickness = true;
            // 
            // bunifuButton6
            // 
            this.bunifuButton6.AllowToggling = true;
            this.bunifuButton6.AnimationSpeed = 200;
            this.bunifuButton6.AutoGenerateColors = false;
            this.bunifuButton6.AutoSize = true;
            this.bunifuButton6.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton6.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(173)))), ((int)(((byte)(15)))));
            this.bunifuButton6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton6.BackgroundImage")));
            this.bunifuButton6.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton6.ButtonText = "Sửa";
            this.bunifuButton6.ButtonTextMarginLeft = 0;
            this.bunifuButton6.ColorContrastOnClick = 45;
            this.bunifuButton6.ColorContrastOnHover = 45;
            this.bunifuButton6.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.bunifuButton6.CustomizableEdges = borderEdges2;
            this.bunifuButton6.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuButton6.DisabledBorderColor = System.Drawing.Color.Empty;
            this.bunifuButton6.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuButton6.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuButton6.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuButton6.Font = new System.Drawing.Font("K2D", 14.25F, System.Drawing.FontStyle.Bold);
            this.bunifuButton6.ForeColor = System.Drawing.Color.White;
            this.bunifuButton6.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton6.IconMarginLeft = 11;
            this.bunifuButton6.IconPadding = 10;
            this.bunifuButton6.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuButton6.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.bunifuButton6.IdleBorderRadius = 5;
            this.bunifuButton6.IdleBorderThickness = 1;
            this.bunifuButton6.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(173)))), ((int)(((byte)(15)))));
            this.bunifuButton6.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton6.IdleIconLeftImage")));
            this.bunifuButton6.IdleIconRightImage = null;
            this.bunifuButton6.IndicateFocus = true;
            this.bunifuButton6.Location = new System.Drawing.Point(784, 278);
            this.bunifuButton6.Name = "bunifuButton6";
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.BorderRadius = 5;
            stateProperties3.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties3.BorderThickness = 1;
            stateProperties3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.ForeColor = System.Drawing.Color.White;
            stateProperties3.IconLeftImage = null;
            stateProperties3.IconRightImage = null;
            this.bunifuButton6.onHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties4.BorderRadius = 5;
            stateProperties4.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties4.BorderThickness = 1;
            stateProperties4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties4.ForeColor = System.Drawing.Color.White;
            stateProperties4.IconLeftImage = null;
            stateProperties4.IconRightImage = null;
            this.bunifuButton6.OnPressedState = stateProperties4;
            this.bunifuButton6.Size = new System.Drawing.Size(105, 44);
            this.bunifuButton6.TabIndex = 23;
            this.bunifuButton6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuButton6.TextMarginLeft = 0;
            this.bunifuButton6.UseDefaultRadiusAndThickness = true;
            // 
            // btnAddKH
            // 
            this.btnAddKH.AllowToggling = true;
            this.btnAddKH.AnimationSpeed = 200;
            this.btnAddKH.AutoGenerateColors = false;
            this.btnAddKH.AutoSize = true;
            this.btnAddKH.BackColor = System.Drawing.Color.Transparent;
            this.btnAddKH.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(183)))), ((int)(((byte)(240)))));
            this.btnAddKH.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddKH.BackgroundImage")));
            this.btnAddKH.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnAddKH.ButtonText = "Thêm";
            this.btnAddKH.ButtonTextMarginLeft = 0;
            this.btnAddKH.ColorContrastOnClick = 45;
            this.btnAddKH.ColorContrastOnHover = 45;
            this.btnAddKH.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.btnAddKH.CustomizableEdges = borderEdges3;
            this.btnAddKH.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddKH.DisabledBorderColor = System.Drawing.Color.Empty;
            this.btnAddKH.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddKH.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnAddKH.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnAddKH.Font = new System.Drawing.Font("K2D", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnAddKH.ForeColor = System.Drawing.Color.White;
            this.btnAddKH.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddKH.IconMarginLeft = 11;
            this.btnAddKH.IconPadding = 10;
            this.btnAddKH.IconRightCursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddKH.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btnAddKH.IdleBorderRadius = 5;
            this.btnAddKH.IdleBorderThickness = 1;
            this.btnAddKH.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(183)))), ((int)(((byte)(240)))));
            this.btnAddKH.IdleIconLeftImage = ((System.Drawing.Image)(resources.GetObject("btnAddKH.IdleIconLeftImage")));
            this.btnAddKH.IdleIconRightImage = null;
            this.btnAddKH.IndicateFocus = true;
            this.btnAddKH.Location = new System.Drawing.Point(777, 198);
            this.btnAddKH.Name = "btnAddKH";
            stateProperties5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties5.BorderRadius = 5;
            stateProperties5.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties5.BorderThickness = 1;
            stateProperties5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties5.ForeColor = System.Drawing.Color.White;
            stateProperties5.IconLeftImage = null;
            stateProperties5.IconRightImage = null;
            this.btnAddKH.onHoverState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties6.BorderRadius = 5;
            stateProperties6.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            stateProperties6.BorderThickness = 1;
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            stateProperties6.ForeColor = System.Drawing.Color.White;
            stateProperties6.IconLeftImage = null;
            stateProperties6.IconRightImage = null;
            this.btnAddKH.OnPressedState = stateProperties6;
            this.btnAddKH.Size = new System.Drawing.Size(119, 44);
            this.btnAddKH.TabIndex = 24;
            this.btnAddKH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAddKH.TextMarginLeft = 0;
            this.btnAddKH.UseDefaultRadiusAndThickness = true;
            // 
            // bunifuTextBox1
            // 
            this.bunifuTextBox1.AcceptsReturn = false;
            this.bunifuTextBox1.AcceptsTab = false;
            this.bunifuTextBox1.AnimationSpeed = 200;
            this.bunifuTextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.bunifuTextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.bunifuTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTextBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuTextBox1.BackgroundImage")));
            this.bunifuTextBox1.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.bunifuTextBox1.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(161)))), ((int)(((byte)(161)))), ((int)(((byte)(161)))));
            this.bunifuTextBox1.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuTextBox1.BorderColorIdle = System.Drawing.Color.Gray;
            this.bunifuTextBox1.BorderRadius = 35;
            this.bunifuTextBox1.BorderThickness = 1;
            this.bunifuTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.bunifuTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTextBox1.DefaultFont = new System.Drawing.Font("Open Sans", 12F);
            this.bunifuTextBox1.DefaultText = "";
            this.bunifuTextBox1.FillColor = System.Drawing.Color.LightGray;
            this.bunifuTextBox1.HideSelection = true;
            this.bunifuTextBox1.IconLeft = null;
            this.bunifuTextBox1.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTextBox1.IconPadding = 10;
            this.bunifuTextBox1.IconRight = ((System.Drawing.Image)(resources.GetObject("bunifuTextBox1.IconRight")));
            this.bunifuTextBox1.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTextBox1.Lines = new string[0];
            this.bunifuTextBox1.Location = new System.Drawing.Point(723, 108);
            this.bunifuTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.bunifuTextBox1.MaxLength = 32767;
            this.bunifuTextBox1.MinimumSize = new System.Drawing.Size(75, 28);
            this.bunifuTextBox1.Modified = false;
            this.bunifuTextBox1.Multiline = false;
            this.bunifuTextBox1.Name = "bunifuTextBox1";
            stateProperties7.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.bunifuTextBox1.OnActiveState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Empty;
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.bunifuTextBox1.OnDisabledState = stateProperties8;
            stateProperties9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties9.FillColor = System.Drawing.Color.Empty;
            stateProperties9.ForeColor = System.Drawing.Color.Empty;
            stateProperties9.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.bunifuTextBox1.OnHoverState = stateProperties9;
            stateProperties10.BorderColor = System.Drawing.Color.Gray;
            stateProperties10.FillColor = System.Drawing.Color.LightGray;
            stateProperties10.ForeColor = System.Drawing.Color.Empty;
            stateProperties10.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.bunifuTextBox1.OnIdleState = stateProperties10;
            this.bunifuTextBox1.PasswordChar = '\0';
            this.bunifuTextBox1.PlaceholderForeColor = System.Drawing.Color.White;
            this.bunifuTextBox1.PlaceholderText = "Tìm khuyến mại";
            this.bunifuTextBox1.ReadOnly = false;
            this.bunifuTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.bunifuTextBox1.SelectedText = "";
            this.bunifuTextBox1.SelectionLength = 0;
            this.bunifuTextBox1.SelectionStart = 0;
            this.bunifuTextBox1.ShortcutsEnabled = true;
            this.bunifuTextBox1.Size = new System.Drawing.Size(231, 33);
            this.bunifuTextBox1.Style = Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox._Style.Bunifu;
            this.bunifuTextBox1.TabIndex = 25;
            this.bunifuTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuTextBox1.TextMarginBottom = 0;
            this.bunifuTextBox1.TextMarginLeft = 5;
            this.bunifuTextBox1.TextMarginTop = 0;
            this.bunifuTextBox1.TextPlaceholder = "Tìm khuyến mại";
            this.bunifuTextBox1.UseSystemPasswordChar = false;
            this.bunifuTextBox1.WordWrap = true;
            // 
            // UC_KhuyenMai
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.bunifuTextBox1);
            this.Controls.Add(this.bunifuButton7);
            this.Controls.Add(this.bunifuButton6);
            this.Controls.Add(this.btnAddKH);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UC_KhuyenMai";
            this.Size = new System.Drawing.Size(985, 580);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton7;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton6;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnAddKH;
        private Bunifu.UI.WinForms.BunifuTextbox.BunifuTextBox bunifuTextBox1;
    }
}
