namespace Catshop
{
    partial class formCustomer
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.textPhoneC = new System.Windows.Forms.TextBox();
            this.textEmailC = new System.Windows.Forms.TextBox();
            this.textAddressFRC = new System.Windows.Forms.TextBox();
            this.textAddressC = new System.Windows.Forms.TextBox();
            this.dateDOBC = new System.Windows.Forms.DateTimePicker();
            this.comboGenderC = new System.Windows.Forms.ComboBox();
            this.textLNameC = new System.Windows.Forms.TextBox();
            this.textFNameC = new System.Windows.Forms.TextBox();
            this.textPasswordC = new System.Windows.Forms.TextBox();
            this.textUsernameC = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabShop = new System.Windows.Forms.TabPage();
            this.dataGridCart = new System.Windows.Forms.DataGridView();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboPayment = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelCustomerName = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.labelPriceAll = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupFind = new System.Windows.Forms.GroupBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textFind = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.catShopDataSet = new Catshop.CatShopDataSet();
            this.productTableAdapter = new Catshop.CatShopDataSetTableAdapters.ProductTableAdapter();
            this.tableAdapterManager = new Catshop.CatShopDataSetTableAdapters.TableAdapterManager();
            this.customerTableAdapter1 = new Catshop.CatShopDataSetTableAdapters.CustomerTableAdapter();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabShop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCart)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.catShopDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cat Shop | Main Form";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Salmon;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.buttonLogOut);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(833, 34);
            this.panel2.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Catshop.Properties.Resources.cat_104_293x300;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(74, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.BackColor = System.Drawing.Color.Aqua;
            this.buttonLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogOut.Location = new System.Drawing.Point(698, 3);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(132, 28);
            this.buttonLogOut.TabIndex = 1;
            this.buttonLogOut.Text = "Log Out";
            this.buttonLogOut.UseVisualStyleBackColor = false;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabProfile);
            this.tabControl1.Controls.Add(this.tabShop);
            this.tabControl1.Location = new System.Drawing.Point(1, 34);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(833, 698);
            this.tabControl1.TabIndex = 3;
            // 
            // tabProfile
            // 
            this.tabProfile.Controls.Add(this.textPhoneC);
            this.tabProfile.Controls.Add(this.textEmailC);
            this.tabProfile.Controls.Add(this.textAddressFRC);
            this.tabProfile.Controls.Add(this.textAddressC);
            this.tabProfile.Controls.Add(this.dateDOBC);
            this.tabProfile.Controls.Add(this.comboGenderC);
            this.tabProfile.Controls.Add(this.textLNameC);
            this.tabProfile.Controls.Add(this.textFNameC);
            this.tabProfile.Controls.Add(this.textPasswordC);
            this.tabProfile.Controls.Add(this.textUsernameC);
            this.tabProfile.Controls.Add(this.label11);
            this.tabProfile.Controls.Add(this.label10);
            this.tabProfile.Controls.Add(this.label9);
            this.tabProfile.Controls.Add(this.label8);
            this.tabProfile.Controls.Add(this.label7);
            this.tabProfile.Controls.Add(this.label6);
            this.tabProfile.Controls.Add(this.label5);
            this.tabProfile.Controls.Add(this.label4);
            this.tabProfile.Controls.Add(this.label3);
            this.tabProfile.Controls.Add(this.label2);
            this.tabProfile.Controls.Add(this.buttonCancel);
            this.tabProfile.Controls.Add(this.buttonSave);
            this.tabProfile.Controls.Add(this.buttonEdit);
            this.tabProfile.Controls.Add(this.pictureBox2);
            this.tabProfile.Location = new System.Drawing.Point(4, 29);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tabProfile.Size = new System.Drawing.Size(825, 665);
            this.tabProfile.TabIndex = 0;
            this.tabProfile.Text = "Profile";
            this.tabProfile.UseVisualStyleBackColor = true;
            // 
            // textPhoneC
            // 
            this.textPhoneC.Location = new System.Drawing.Point(527, 295);
            this.textPhoneC.Name = "textPhoneC";
            this.textPhoneC.Size = new System.Drawing.Size(278, 26);
            this.textPhoneC.TabIndex = 23;
            // 
            // textEmailC
            // 
            this.textEmailC.Location = new System.Drawing.Point(527, 245);
            this.textEmailC.Name = "textEmailC";
            this.textEmailC.Size = new System.Drawing.Size(278, 26);
            this.textEmailC.TabIndex = 22;
            // 
            // textAddressFRC
            // 
            this.textAddressFRC.Location = new System.Drawing.Point(527, 141);
            this.textAddressFRC.Multiline = true;
            this.textAddressFRC.Name = "textAddressFRC";
            this.textAddressFRC.Size = new System.Drawing.Size(278, 88);
            this.textAddressFRC.TabIndex = 21;
            // 
            // textAddressC
            // 
            this.textAddressC.Location = new System.Drawing.Point(527, 38);
            this.textAddressC.Multiline = true;
            this.textAddressC.Name = "textAddressC";
            this.textAddressC.Size = new System.Drawing.Size(278, 88);
            this.textAddressC.TabIndex = 20;
            // 
            // dateDOBC
            // 
            this.dateDOBC.Location = new System.Drawing.Point(148, 326);
            this.dateDOBC.Name = "dateDOBC";
            this.dateDOBC.Size = new System.Drawing.Size(213, 26);
            this.dateDOBC.TabIndex = 19;
            // 
            // comboGenderC
            // 
            this.comboGenderC.FormattingEnabled = true;
            this.comboGenderC.Items.AddRange(new object[] {
            "ชาย",
            "หญิง"});
            this.comboGenderC.Location = new System.Drawing.Point(148, 273);
            this.comboGenderC.Name = "comboGenderC";
            this.comboGenderC.Size = new System.Drawing.Size(183, 28);
            this.comboGenderC.TabIndex = 18;
            // 
            // textLNameC
            // 
            this.textLNameC.Location = new System.Drawing.Point(148, 221);
            this.textLNameC.Name = "textLNameC";
            this.textLNameC.Size = new System.Drawing.Size(213, 26);
            this.textLNameC.TabIndex = 17;
            // 
            // textFNameC
            // 
            this.textFNameC.Location = new System.Drawing.Point(148, 161);
            this.textFNameC.Name = "textFNameC";
            this.textFNameC.Size = new System.Drawing.Size(213, 26);
            this.textFNameC.TabIndex = 16;
            // 
            // textPasswordC
            // 
            this.textPasswordC.Location = new System.Drawing.Point(148, 98);
            this.textPasswordC.Name = "textPasswordC";
            this.textPasswordC.Size = new System.Drawing.Size(183, 26);
            this.textPasswordC.TabIndex = 15;
            // 
            // textUsernameC
            // 
            this.textUsernameC.Location = new System.Drawing.Point(148, 38);
            this.textUsernameC.Name = "textUsernameC";
            this.textUsernameC.Size = new System.Drawing.Size(183, 26);
            this.textUsernameC.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(441, 298);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 20);
            this.label11.TabIndex = 13;
            this.label11.Text = "Phone";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(450, 248);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 20);
            this.label10.TabIndex = 12;
            this.label10.Text = "Email";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(413, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 60);
            this.label9.TabIndex = 11;
            this.label9.Text = "Address for receipt";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(425, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "Address";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 331);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Date of Birth";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 281);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Gender";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Last Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "First Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Username";
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Coral;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonCancel.Location = new System.Drawing.Point(479, 443);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(136, 54);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.Coral;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSave.Location = new System.Drawing.Point(337, 443);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(136, 54);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.BackColor = System.Drawing.Color.Coral;
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEdit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonEdit.Location = new System.Drawing.Point(195, 443);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(136, 54);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = false;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Catshop.Properties.Resources.group_of_cute_cat_greeting_cartoon_png__1_;
            this.pictureBox2.Location = new System.Drawing.Point(0, 512);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(829, 166);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // tabShop
            // 
            this.tabShop.AutoScroll = true;
            this.tabShop.BackColor = System.Drawing.SystemColors.Control;
            this.tabShop.Controls.Add(this.dataGridCart);
            this.tabShop.Controls.Add(this.buttonConfirm);
            this.tabShop.Controls.Add(this.panel3);
            this.tabShop.Controls.Add(this.flowLayoutPanel1);
            this.tabShop.Controls.Add(this.panel1);
            this.tabShop.Controls.Add(this.groupFind);
            this.tabShop.Location = new System.Drawing.Point(4, 29);
            this.tabShop.Name = "tabShop";
            this.tabShop.Padding = new System.Windows.Forms.Padding(3);
            this.tabShop.Size = new System.Drawing.Size(825, 665);
            this.tabShop.TabIndex = 1;
            this.tabShop.Text = "Shop";
            // 
            // dataGridCart
            // 
            this.dataGridCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCart.Location = new System.Drawing.Point(332, 130);
            this.dataGridCart.Name = "dataGridCart";
            this.dataGridCart.RowHeadersVisible = false;
            this.dataGridCart.RowHeadersWidth = 51;
            this.dataGridCart.RowTemplate.Height = 24;
            this.dataGridCart.Size = new System.Drawing.Size(488, 425);
            this.dataGridCart.TabIndex = 10;
            this.dataGridCart.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridCart_CellClick);
            this.dataGridCart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridCart_CellContentClick);
            this.dataGridCart.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridCart_CellValueChanged);
            this.dataGridCart.SelectionChanged += new System.EventHandler(this.dataGridCart_SelectionChanged);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(523, 603);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(225, 48);
            this.buttonConfirm.TabIndex = 9;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.comboPayment);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Location = new System.Drawing.Point(355, 79);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(448, 40);
            this.panel3.TabIndex = 8;
            // 
            // comboPayment
            // 
            this.comboPayment.FormattingEnabled = true;
            this.comboPayment.Location = new System.Drawing.Point(204, 3);
            this.comboPayment.Name = "comboPayment";
            this.comboPayment.Size = new System.Drawing.Size(241, 28);
            this.comboPayment.TabIndex = 9;
            this.comboPayment.SelectedIndexChanged += new System.EventHandler(this.comboPayment_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 20);
            this.label12.TabIndex = 8;
            this.label12.Text = "Payment";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Salmon;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 127);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(297, 525);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.labelCustomerName);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.labelPriceAll);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Location = new System.Drawing.Point(355, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 52);
            this.panel1.TabIndex = 5;
            // 
            // labelCustomerName
            // 
            this.labelCustomerName.AutoSize = true;
            this.labelCustomerName.Location = new System.Drawing.Point(82, 12);
            this.labelCustomerName.Name = "labelCustomerName";
            this.labelCustomerName.Size = new System.Drawing.Size(120, 20);
            this.labelCustomerName.TabIndex = 7;
            this.labelCustomerName.Text = "CustomerName";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 20);
            this.label15.TabIndex = 6;
            this.label15.Text = "Name";
            // 
            // labelPriceAll
            // 
            this.labelPriceAll.AutoSize = true;
            this.labelPriceAll.Location = new System.Drawing.Point(357, 12);
            this.labelPriceAll.Name = "labelPriceAll";
            this.labelPriceAll.Size = new System.Drawing.Size(49, 20);
            this.labelPriceAll.TabIndex = 5;
            this.labelPriceAll.Text = "00.00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(276, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 20);
            this.label14.TabIndex = 4;
            this.label14.Text = "Total";
            // 
            // groupFind
            // 
            this.groupFind.BackColor = System.Drawing.Color.White;
            this.groupFind.Controls.Add(this.buttonClear);
            this.groupFind.Controls.Add(this.buttonSearch);
            this.groupFind.Controls.Add(this.textFind);
            this.groupFind.Controls.Add(this.label13);
            this.groupFind.Location = new System.Drawing.Point(7, 6);
            this.groupFind.Name = "groupFind";
            this.groupFind.Size = new System.Drawing.Size(342, 114);
            this.groupFind.TabIndex = 0;
            this.groupFind.TabStop = false;
            this.groupFind.Text = "ค้นหา";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(183, 70);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(142, 30);
            this.buttonClear.TabIndex = 5;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(183, 37);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(142, 30);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textFind
            // 
            this.textFind.Location = new System.Drawing.Point(11, 70);
            this.textFind.Name = "textFind";
            this.textFind.Size = new System.Drawing.Size(152, 26);
            this.textFind.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 20);
            this.label13.TabIndex = 2;
            this.label13.Text = "ค้นหาชื่อสินค้า";
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataMember = "Product";
            this.productBindingSource.DataSource = this.catShopDataSet;
            // 
            // catShopDataSet
            // 
            this.catShopDataSet.DataSetName = "CatShopDataSet";
            this.catShopDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productTableAdapter
            // 
            this.productTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CatagoriesTableAdapter = null;
            this.tableAdapterManager.CustomerTableAdapter = null;
            this.tableAdapterManager.EmployeeTableAdapter = null;
            this.tableAdapterManager.ProductTableAdapter = this.productTableAdapter;
            this.tableAdapterManager.SaleTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Catshop.CatShopDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // customerTableAdapter1
            // 
            this.customerTableAdapter1.ClearBeforeFill = true;
            // 
            // formCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 732);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "formCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formCustomer_FormClosed);
            this.Load += new System.EventHandler(this.formCustomer_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabProfile.ResumeLayout(false);
            this.tabProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabShop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCart)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupFind.ResumeLayout(false);
            this.groupFind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.catShopDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.TabPage tabShop;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textPhoneC;
        private System.Windows.Forms.TextBox textEmailC;
        private System.Windows.Forms.TextBox textAddressFRC;
        private System.Windows.Forms.TextBox textAddressC;
        private System.Windows.Forms.DateTimePicker dateDOBC;
        private System.Windows.Forms.ComboBox comboGenderC;
        private System.Windows.Forms.TextBox textLNameC;
        private System.Windows.Forms.TextBox textFNameC;
        private System.Windows.Forms.TextBox textPasswordC;
        private System.Windows.Forms.TextBox textUsernameC;
        private System.Windows.Forms.GroupBox groupFind;
        private CatShopDataSet catShopDataSet;
        private System.Windows.Forms.BindingSource productBindingSource;
        private CatShopDataSetTableAdapters.ProductTableAdapter productTableAdapter;
        private System.Windows.Forms.TextBox textFind;
        private System.Windows.Forms.Label label13;
        private CatShopDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelCustomerName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label labelPriceAll;
        private System.Windows.Forms.Label label14;
        private CatShopDataSetTableAdapters.CustomerTableAdapter customerTableAdapter1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboPayment;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.DataGridView dataGridCart;
    }
}