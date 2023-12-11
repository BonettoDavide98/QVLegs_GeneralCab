namespace QVLEGS
{
    partial class FormPrincipale
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnMinimizza = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFormatoCorrente = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblUserText = new System.Windows.Forms.Label();
            this.lblRicetta = new System.Windows.Forms.Label();
            this.lblTurnoText = new System.Windows.Forms.Label();
            this.lblTurno = new System.Windows.Forms.Label();
            this.lblDataOraAtt = new System.Windows.Forms.Label();
            this.lblDataOra = new System.Windows.Forms.Label();
            this.btnLingua1 = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnStazione3 = new System.Windows.Forms.Button();
            this.btnStazione2 = new System.Windows.Forms.Button();
            this.btnStazione1 = new System.Windows.Forms.Button();
            this.btnAllCamere = new System.Windows.Forms.Button();
            this.btnStazione4 = new System.Windows.Forms.Button();
            this.btnStazione5 = new System.Windows.Forms.Button();
            this.btnChiudi = new System.Windows.Forms.Button();
            this.btnRicette = new System.Windows.Forms.Button();
            this.timerUpdateScreen = new System.Windows.Forms.Timer(this.components);
            this.ucTabControlPagine = new QVLEGS.UCTabControl();
            this.tabPageRicette = new System.Windows.Forms.TabPage();
            this.ucPaginaRicette = new QVLEGS.Pagine.UCPaginaRicette();
            this.tabPageStazione1 = new System.Windows.Forms.TabPage();
            this.ucPaginaMain1 = new QVLEGS.Pagine.UCPaginaMain();
            this.tabPageStazione2 = new System.Windows.Forms.TabPage();
            this.ucPaginaMain2 = new QVLEGS.Pagine.UCPaginaMain();
            this.tabPageStazione3 = new System.Windows.Forms.TabPage();
            this.ucPaginaMain3 = new QVLEGS.Pagine.UCPaginaMain();
            this.tabPageStazione4 = new System.Windows.Forms.TabPage();
            this.ucPaginaMain4 = new QVLEGS.Pagine.UCPaginaMain();
            this.tabPageStazione5 = new System.Windows.Forms.TabPage();
            this.ucPaginaMain5 = new QVLEGS.Pagine.UCPaginaMain();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.ucPaginaLog1 = new QVLEGS.Pagine.UCPaginaLog();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.ucTabControlPagine.SuspendLayout();
            this.tabPageRicette.SuspendLayout();
            this.tabPageStazione1.SuspendLayout();
            this.tabPageStazione2.SuspendLayout();
            this.tabPageStazione3.SuspendLayout();
            this.tabPageStazione4.SuspendLayout();
            this.tabPageStazione5.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.btnLog);
            this.panel1.Controls.Add(this.btnMinimizza);
            this.panel1.Controls.Add(this.tableLayoutPanel5);
            this.panel1.Controls.Add(this.btnLingua1);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.btnChiudi);
            this.panel1.Controls.Add(this.btnRicette);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 60);
            this.panel1.TabIndex = 84;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.BackgroundImage = global::QVLEGS.Properties.Resources.index;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.Location = new System.Drawing.Point(4, 5);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(60, 49);
            this.btnHome.TabIndex = 11;
            this.btnHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnLog
            // 
            this.btnLog.BackgroundImage = global::QVLEGS.Properties.Resources.alarm_OFF;
            this.btnLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLog.FlatAppearance.BorderSize = 0;
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.Location = new System.Drawing.Point(133, 4);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(60, 49);
            this.btnLog.TabIndex = 10;
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnMinimizza
            // 
            this.btnMinimizza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizza.BackgroundImage = global::QVLEGS.Properties.Resources.reduce_IconRed2;
            this.btnMinimizza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMinimizza.FlatAppearance.BorderSize = 0;
            this.btnMinimizza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizza.Location = new System.Drawing.Point(1840, 16);
            this.btnMinimizza.Name = "btnMinimizza";
            this.btnMinimizza.Size = new System.Drawing.Size(36, 32);
            this.btnMinimizza.TabIndex = 8;
            this.btnMinimizza.UseVisualStyleBackColor = true;
            this.btnMinimizza.Click += new System.EventHandler(this.btnMinimizza_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.94703F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.07126F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.94703F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.03469F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.lblFormatoCorrente, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblUser, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblUserText, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblRicetta, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblTurnoText, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblTurno, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblDataOraAtt, 3, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblDataOra, 3, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(413, 7);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1315, 44);
            this.tableLayoutPanel5.TabIndex = 7;
            // 
            // lblFormatoCorrente
            // 
            this.lblFormatoCorrente.BackColor = System.Drawing.Color.Transparent;
            this.lblFormatoCorrente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFormatoCorrente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormatoCorrente.ForeColor = System.Drawing.Color.White;
            this.lblFormatoCorrente.Location = new System.Drawing.Point(252, 17);
            this.lblFormatoCorrente.Name = "lblFormatoCorrente";
            this.lblFormatoCorrente.Size = new System.Drawing.Size(534, 27);
            this.lblFormatoCorrente.TabIndex = 87;
            this.lblFormatoCorrente.Text = "------------------------------------------------------";
            this.lblFormatoCorrente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUser
            // 
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(3, 17);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(243, 27);
            this.lblUser.TabIndex = 7;
            this.lblUser.Text = "--------";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserText
            // 
            this.lblUserText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUserText.AutoSize = true;
            this.lblUserText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserText.ForeColor = System.Drawing.Color.White;
            this.lblUserText.Location = new System.Drawing.Point(86, 0);
            this.lblUserText.Name = "lblUserText";
            this.lblUserText.Size = new System.Drawing.Size(76, 16);
            this.lblUserText.TabIndex = 6;
            this.lblUserText.Text = "LBL_USER";
            // 
            // lblRicetta
            // 
            this.lblRicetta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRicetta.AutoSize = true;
            this.lblRicetta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRicetta.ForeColor = System.Drawing.Color.White;
            this.lblRicetta.Location = new System.Drawing.Point(471, 0);
            this.lblRicetta.Name = "lblRicetta";
            this.lblRicetta.Size = new System.Drawing.Size(96, 16);
            this.lblRicetta.TabIndex = 8;
            this.lblRicetta.Text = "LBL_RICETTA";
            // 
            // lblTurnoText
            // 
            this.lblTurnoText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTurnoText.AutoSize = true;
            this.lblTurnoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurnoText.ForeColor = System.Drawing.Color.White;
            this.lblTurnoText.Location = new System.Drawing.Point(870, 0);
            this.lblTurnoText.Name = "lblTurnoText";
            this.lblTurnoText.Size = new System.Drawing.Size(87, 16);
            this.lblTurnoText.TabIndex = 11;
            this.lblTurnoText.Text = "LBL_TURNO";
            // 
            // lblTurno
            // 
            this.lblTurno.BackColor = System.Drawing.Color.Transparent;
            this.lblTurno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurno.ForeColor = System.Drawing.Color.White;
            this.lblTurno.Location = new System.Drawing.Point(792, 17);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(243, 27);
            this.lblTurno.TabIndex = 12;
            this.lblTurno.Text = "--------";
            this.lblTurno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDataOraAtt
            // 
            this.lblDataOraAtt.BackColor = System.Drawing.Color.Transparent;
            this.lblDataOraAtt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataOraAtt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataOraAtt.ForeColor = System.Drawing.Color.White;
            this.lblDataOraAtt.Location = new System.Drawing.Point(1041, 17);
            this.lblDataOraAtt.Name = "lblDataOraAtt";
            this.lblDataOraAtt.Size = new System.Drawing.Size(271, 27);
            this.lblDataOraAtt.TabIndex = 2;
            this.lblDataOraAtt.Text = "dd/MM/yyyy \r\nHH:mm:ss";
            this.lblDataOraAtt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDataOra
            // 
            this.lblDataOra.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDataOra.AutoSize = true;
            this.lblDataOra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataOra.ForeColor = System.Drawing.Color.White;
            this.lblDataOra.Location = new System.Drawing.Point(1121, 0);
            this.lblDataOra.Name = "lblDataOra";
            this.lblDataOra.Size = new System.Drawing.Size(111, 16);
            this.lblDataOra.TabIndex = 11;
            this.lblDataOra.Text = "LBL_DATA_ORA";
            // 
            // btnLingua1
            // 
            this.btnLingua1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLingua1.BackColor = System.Drawing.Color.Turquoise;
            this.btnLingua1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLingua1.FlatAppearance.BorderSize = 0;
            this.btnLingua1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLingua1.Location = new System.Drawing.Point(1734, -1);
            this.btnLingua1.Name = "btnLingua1";
            this.btnLingua1.Size = new System.Drawing.Size(45, 42);
            this.btnLingua1.TabIndex = 5;
            this.btnLingua1.UseVisualStyleBackColor = false;
            this.btnLingua1.Visible = false;
            this.btnLingua1.Click += new System.EventHandler(this.btnLingua1_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogin.BackgroundImage = global::QVLEGS.Properties.Resources.btnAccedi_Image;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(1785, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(49, 43);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.btnStazione3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStazione2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStazione1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAllCamere, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStazione4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStazione5, 4, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(199, 14);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(208, 34);
            this.tableLayoutPanel1.TabIndex = 88;
            // 
            // btnStazione3
            // 
            this.btnStazione3.BackColor = System.Drawing.Color.Gainsboro;
            this.btnStazione3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStazione3.FlatAppearance.BorderSize = 0;
            this.btnStazione3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStazione3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStazione3.ForeColor = System.Drawing.Color.White;
            this.btnStazione3.Location = new System.Drawing.Point(71, 3);
            this.btnStazione3.Name = "btnStazione3";
            this.btnStazione3.Size = new System.Drawing.Size(28, 28);
            this.btnStazione3.TabIndex = 11;
            this.btnStazione3.Text = "3";
            this.btnStazione3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStazione3.UseVisualStyleBackColor = false;
            this.btnStazione3.Click += new System.EventHandler(this.btnStazione3_Click);
            // 
            // btnStazione2
            // 
            this.btnStazione2.BackColor = System.Drawing.Color.Gainsboro;
            this.btnStazione2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStazione2.FlatAppearance.BorderSize = 0;
            this.btnStazione2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStazione2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStazione2.ForeColor = System.Drawing.Color.White;
            this.btnStazione2.Location = new System.Drawing.Point(37, 3);
            this.btnStazione2.Name = "btnStazione2";
            this.btnStazione2.Size = new System.Drawing.Size(28, 28);
            this.btnStazione2.TabIndex = 10;
            this.btnStazione2.Text = "2";
            this.btnStazione2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStazione2.UseVisualStyleBackColor = false;
            this.btnStazione2.Click += new System.EventHandler(this.btnStazione2_Click);
            // 
            // btnStazione1
            // 
            this.btnStazione1.BackColor = System.Drawing.Color.Gainsboro;
            this.btnStazione1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStazione1.FlatAppearance.BorderSize = 0;
            this.btnStazione1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStazione1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStazione1.ForeColor = System.Drawing.Color.White;
            this.btnStazione1.Location = new System.Drawing.Point(3, 3);
            this.btnStazione1.Name = "btnStazione1";
            this.btnStazione1.Size = new System.Drawing.Size(28, 28);
            this.btnStazione1.TabIndex = 9;
            this.btnStazione1.Text = "1";
            this.btnStazione1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStazione1.UseVisualStyleBackColor = false;
            this.btnStazione1.Click += new System.EventHandler(this.btnStazione1_Click);
            // 
            // btnAllCamere
            // 
            this.btnAllCamere.BackColor = System.Drawing.Color.DarkOrange;
            this.btnAllCamere.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAllCamere.FlatAppearance.BorderSize = 0;
            this.btnAllCamere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllCamere.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllCamere.ForeColor = System.Drawing.Color.White;
            this.btnAllCamere.Location = new System.Drawing.Point(173, 3);
            this.btnAllCamere.Name = "btnAllCamere";
            this.btnAllCamere.Size = new System.Drawing.Size(32, 28);
            this.btnAllCamere.TabIndex = 12;
            this.btnAllCamere.Text = "ALL";
            this.btnAllCamere.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAllCamere.UseVisualStyleBackColor = false;
            this.btnAllCamere.Visible = false;
            this.btnAllCamere.Click += new System.EventHandler(this.btnAllCamere_Click);
            // 
            // btnStazione4
            // 
            this.btnStazione4.BackColor = System.Drawing.Color.Gainsboro;
            this.btnStazione4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStazione4.FlatAppearance.BorderSize = 0;
            this.btnStazione4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStazione4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStazione4.ForeColor = System.Drawing.Color.White;
            this.btnStazione4.Location = new System.Drawing.Point(105, 3);
            this.btnStazione4.Name = "btnStazione4";
            this.btnStazione4.Size = new System.Drawing.Size(28, 28);
            this.btnStazione4.TabIndex = 13;
            this.btnStazione4.Text = "4";
            this.btnStazione4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStazione4.UseVisualStyleBackColor = false;
            this.btnStazione4.Click += new System.EventHandler(this.btnStazione4_Click);
            // 
            // btnStazione5
            // 
            this.btnStazione5.BackColor = System.Drawing.Color.Gainsboro;
            this.btnStazione5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStazione5.FlatAppearance.BorderSize = 0;
            this.btnStazione5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStazione5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStazione5.ForeColor = System.Drawing.Color.White;
            this.btnStazione5.Location = new System.Drawing.Point(139, 3);
            this.btnStazione5.Name = "btnStazione5";
            this.btnStazione5.Size = new System.Drawing.Size(28, 28);
            this.btnStazione5.TabIndex = 14;
            this.btnStazione5.Text = "5";
            this.btnStazione5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStazione5.UseVisualStyleBackColor = false;
            this.btnStazione5.Click += new System.EventHandler(this.btnStazione5_Click);
            // 
            // btnChiudi
            // 
            this.btnChiudi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChiudi.BackgroundImage = global::QVLEGS.Properties.Resources.CloseSmall;
            this.btnChiudi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnChiudi.FlatAppearance.BorderSize = 0;
            this.btnChiudi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChiudi.Location = new System.Drawing.Point(1874, 4);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(49, 32);
            this.btnChiudi.TabIndex = 3;
            this.btnChiudi.UseVisualStyleBackColor = true;
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // btnRicette
            // 
            this.btnRicette.BackgroundImage = global::QVLEGS.Properties.Resources.checklist;
            this.btnRicette.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRicette.FlatAppearance.BorderSize = 0;
            this.btnRicette.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRicette.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRicette.Location = new System.Drawing.Point(70, 5);
            this.btnRicette.Name = "btnRicette";
            this.btnRicette.Size = new System.Drawing.Size(60, 49);
            this.btnRicette.TabIndex = 1;
            this.btnRicette.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRicette.UseVisualStyleBackColor = true;
            this.btnRicette.Click += new System.EventHandler(this.btnRicette_Click);
            // 
            // timerUpdateScreen
            // 
            this.timerUpdateScreen.Interval = 500;
            this.timerUpdateScreen.Tick += new System.EventHandler(this.timerUpdateScreen_Tick);
            // 
            // ucTabControlPagine
            // 
            this.ucTabControlPagine.Controls.Add(this.tabPageRicette);
            this.ucTabControlPagine.Controls.Add(this.tabPageStazione1);
            this.ucTabControlPagine.Controls.Add(this.tabPageStazione2);
            this.ucTabControlPagine.Controls.Add(this.tabPageStazione3);
            this.ucTabControlPagine.Controls.Add(this.tabPageStazione4);
            this.ucTabControlPagine.Controls.Add(this.tabPageStazione5);
            this.ucTabControlPagine.Controls.Add(this.tabPageLog);
            this.ucTabControlPagine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTabControlPagine.HideTab = true;
            this.ucTabControlPagine.Location = new System.Drawing.Point(0, 60);
            this.ucTabControlPagine.Name = "ucTabControlPagine";
            this.ucTabControlPagine.SelectedIndex = 0;
            this.ucTabControlPagine.Size = new System.Drawing.Size(1920, 1020);
            this.ucTabControlPagine.TabIndex = 86;
            // 
            // tabPageRicette
            // 
            this.tabPageRicette.Controls.Add(this.ucPaginaRicette);
            this.tabPageRicette.Location = new System.Drawing.Point(4, 22);
            this.tabPageRicette.Name = "tabPageRicette";
            this.tabPageRicette.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRicette.Size = new System.Drawing.Size(1912, 994);
            this.tabPageRicette.TabIndex = 2;
            this.tabPageRicette.Text = "tabPageRicette";
            this.tabPageRicette.UseVisualStyleBackColor = true;
            // 
            // ucPaginaRicette
            // 
            this.ucPaginaRicette.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ucPaginaRicette.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPaginaRicette.Location = new System.Drawing.Point(3, 3);
            this.ucPaginaRicette.Name = "ucPaginaRicette";
            this.ucPaginaRicette.Size = new System.Drawing.Size(1906, 988);
            this.ucPaginaRicette.TabIndex = 0;
            // 
            // tabPageStazione1
            // 
            this.tabPageStazione1.Controls.Add(this.ucPaginaMain1);
            this.tabPageStazione1.Location = new System.Drawing.Point(4, 22);
            this.tabPageStazione1.Name = "tabPageStazione1";
            this.tabPageStazione1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStazione1.Size = new System.Drawing.Size(1272, 938);
            this.tabPageStazione1.TabIndex = 7;
            this.tabPageStazione1.Text = "tabPageStazione1";
            this.tabPageStazione1.UseVisualStyleBackColor = true;
            // 
            // ucPaginaMain1
            // 
            this.ucPaginaMain1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ucPaginaMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPaginaMain1.Location = new System.Drawing.Point(3, 3);
            this.ucPaginaMain1.Name = "ucPaginaMain1";
            this.ucPaginaMain1.Size = new System.Drawing.Size(1266, 932);
            this.ucPaginaMain1.TabIndex = 0;
            // 
            // tabPageStazione2
            // 
            this.tabPageStazione2.Controls.Add(this.ucPaginaMain2);
            this.tabPageStazione2.Location = new System.Drawing.Point(4, 22);
            this.tabPageStazione2.Name = "tabPageStazione2";
            this.tabPageStazione2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStazione2.Size = new System.Drawing.Size(1272, 938);
            this.tabPageStazione2.TabIndex = 8;
            this.tabPageStazione2.Text = "tabPageStazione2";
            this.tabPageStazione2.UseVisualStyleBackColor = true;
            // 
            // ucPaginaMain2
            // 
            this.ucPaginaMain2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ucPaginaMain2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPaginaMain2.Location = new System.Drawing.Point(3, 3);
            this.ucPaginaMain2.Name = "ucPaginaMain2";
            this.ucPaginaMain2.Size = new System.Drawing.Size(1266, 932);
            this.ucPaginaMain2.TabIndex = 1;
            // 
            // tabPageStazione3
            // 
            this.tabPageStazione3.Controls.Add(this.ucPaginaMain3);
            this.tabPageStazione3.Location = new System.Drawing.Point(4, 22);
            this.tabPageStazione3.Name = "tabPageStazione3";
            this.tabPageStazione3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStazione3.Size = new System.Drawing.Size(1272, 938);
            this.tabPageStazione3.TabIndex = 9;
            this.tabPageStazione3.Text = "tabPageStazione3";
            this.tabPageStazione3.UseVisualStyleBackColor = true;
            // 
            // ucPaginaMain3
            // 
            this.ucPaginaMain3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ucPaginaMain3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPaginaMain3.Location = new System.Drawing.Point(3, 3);
            this.ucPaginaMain3.Name = "ucPaginaMain3";
            this.ucPaginaMain3.Size = new System.Drawing.Size(1266, 932);
            this.ucPaginaMain3.TabIndex = 2;
            // 
            // tabPageStazione4
            // 
            this.tabPageStazione4.Controls.Add(this.ucPaginaMain4);
            this.tabPageStazione4.Location = new System.Drawing.Point(4, 22);
            this.tabPageStazione4.Name = "tabPageStazione4";
            this.tabPageStazione4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStazione4.Size = new System.Drawing.Size(1272, 938);
            this.tabPageStazione4.TabIndex = 11;
            this.tabPageStazione4.Text = "tabPageStazione4";
            this.tabPageStazione4.UseVisualStyleBackColor = true;
            // 
            // ucPaginaMain4
            // 
            this.ucPaginaMain4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ucPaginaMain4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPaginaMain4.Location = new System.Drawing.Point(3, 3);
            this.ucPaginaMain4.Name = "ucPaginaMain4";
            this.ucPaginaMain4.Size = new System.Drawing.Size(1266, 932);
            this.ucPaginaMain4.TabIndex = 3;
            // 
            // tabPageStazione5
            // 
            this.tabPageStazione5.Controls.Add(this.ucPaginaMain5);
            this.tabPageStazione5.Location = new System.Drawing.Point(4, 22);
            this.tabPageStazione5.Name = "tabPageStazione5";
            this.tabPageStazione5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStazione5.Size = new System.Drawing.Size(1272, 938);
            this.tabPageStazione5.TabIndex = 12;
            this.tabPageStazione5.Text = "tabPageStazione5";
            this.tabPageStazione5.UseVisualStyleBackColor = true;
            // 
            // ucPaginaMain5
            // 
            this.ucPaginaMain5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ucPaginaMain5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPaginaMain5.Location = new System.Drawing.Point(3, 3);
            this.ucPaginaMain5.Name = "ucPaginaMain5";
            this.ucPaginaMain5.Size = new System.Drawing.Size(1266, 932);
            this.ucPaginaMain5.TabIndex = 3;
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.ucPaginaLog1);
            this.tabPageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Size = new System.Drawing.Size(1272, 938);
            this.tabPageLog.TabIndex = 10;
            this.tabPageLog.Text = "tabPageLog";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // ucPaginaLog1
            // 
            this.ucPaginaLog1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ucPaginaLog1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPaginaLog1.Location = new System.Drawing.Point(0, 0);
            this.ucPaginaLog1.Name = "ucPaginaLog1";
            this.ucPaginaLog1.Size = new System.Drawing.Size(1272, 938);
            this.ucPaginaLog1.TabIndex = 0;
            // 
            // FormPrincipale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.ucTabControlPagine);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPrincipale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ucTabControlPagine.ResumeLayout(false);
            this.tabPageRicette.ResumeLayout(false);
            this.tabPageStazione1.ResumeLayout(false);
            this.tabPageStazione2.ResumeLayout(false);
            this.tabPageStazione3.ResumeLayout(false);
            this.tabPageStazione4.ResumeLayout(false);
            this.tabPageStazione5.ResumeLayout(false);
            this.tabPageLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private UCTabControl ucTabControlPagine;
        private System.Windows.Forms.Button btnRicette;
        private System.Windows.Forms.TabPage tabPageRicette;
        private Pagine.UCPaginaRicette ucPaginaRicette;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblUserText;
        private System.Windows.Forms.Timer timerUpdateScreen;
        private System.Windows.Forms.Label lblTurnoText;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.Button btnChiudi;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblFormatoCorrente;
        private System.Windows.Forms.Button btnLingua1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lblRicetta;
        private System.Windows.Forms.Button btnMinimizza;
        private System.Windows.Forms.TabPage tabPageStazione1;
        private Pagine.UCPaginaMain ucPaginaMain1;
        private System.Windows.Forms.TabPage tabPageStazione2;
        private Pagine.UCPaginaMain ucPaginaMain2;
        private System.Windows.Forms.Button btnStazione2;
        private System.Windows.Forms.Button btnStazione1;
        private System.Windows.Forms.TabPage tabPageStazione3;
        private Pagine.UCPaginaMain ucPaginaMain3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnStazione3;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Label lblDataOraAtt;
        private System.Windows.Forms.Button btnAllCamere;
        private System.Windows.Forms.Label lblDataOra;
        private Pagine.UCPaginaLog ucPaginaLog1;
        private System.Windows.Forms.TabPage tabPageStazione4;
        private Pagine.UCPaginaMain ucPaginaMain4;
        private System.Windows.Forms.TabPage tabPageStazione5;
        private Pagine.UCPaginaMain ucPaginaMain5;
        private System.Windows.Forms.Button btnStazione4;
        private System.Windows.Forms.Button btnStazione5;
    }
}