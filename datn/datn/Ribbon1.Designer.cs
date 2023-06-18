namespace datn
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.aboutBtn = this.Factory.CreateRibbonButton();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.readNumberVN = this.Factory.CreateRibbonButton();
            this.readNumberEn = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.textToSpeechEnBtn = this.Factory.CreateRibbonButton();
            this.buttonGroup1 = this.Factory.CreateRibbonButtonGroup();
            this.playOrPause = this.Factory.CreateRibbonButton();
            this.stopSpeech = this.Factory.CreateRibbonButton();
            this.group4 = this.Factory.CreateRibbonGroup();
            this.ActiveControlListBtn = this.Factory.CreateRibbonButton();
            this.listQR = this.Factory.CreateRibbonButton();
            this.group5 = this.Factory.CreateRibbonGroup();
            this.btnAddQrCode = this.Factory.CreateRibbonButton();
            this.createQR = this.Factory.CreateRibbonButton();
            this.qr_showListContentControl = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group3.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.buttonGroup1.SuspendLayout();
            this.group4.SuspendLayout();
            this.group5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.group3);
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Groups.Add(this.group4);
            this.tab1.Groups.Add(this.group5);
            this.tab1.Label = "NewAddIns";
            this.tab1.Name = "tab1";
            // 
            // group3
            // 
            this.group3.Items.Add(this.aboutBtn);
            this.group3.Label = "About";
            this.group3.Name = "group3";
            // 
            // aboutBtn
            // 
            this.aboutBtn.Image = global::datn.Properties.Resources.logo_about;
            this.aboutBtn.Label = "about";
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.ShowImage = true;
            this.aboutBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.aboutBtn_Click);
            // 
            // group1
            // 
            this.group1.Items.Add(this.readNumberVN);
            this.group1.Items.Add(this.readNumberEn);
            this.group1.Label = "Read Number";
            this.group1.Name = "group1";
            // 
            // readNumberVN
            // 
            this.readNumberVN.Image = global::datn.Properties.Resources.number;
            this.readNumberVN.Label = "Đọc số";
            this.readNumberVN.Name = "readNumberVN";
            this.readNumberVN.ShowImage = true;
            this.readNumberVN.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.readNumberVnBtn_Click);
            // 
            // readNumberEn
            // 
            this.readNumberEn.Image = global::datn.Properties.Resources.number;
            this.readNumberEn.Label = "Read Number";
            this.readNumberEn.Name = "readNumberEn";
            this.readNumberEn.ShowImage = true;
            this.readNumberEn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.readNumberEnBtn_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.textToSpeechEnBtn);
            this.group2.Items.Add(this.buttonGroup1);
            this.group2.Label = "text to speech";
            this.group2.Name = "group2";
            // 
            // textToSpeechEnBtn
            // 
            this.textToSpeechEnBtn.Label = "Text To Speech (en)";
            this.textToSpeechEnBtn.Name = "textToSpeechEnBtn";
            this.textToSpeechEnBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.textToSpeechEn_Click);
            // 
            // buttonGroup1
            // 
            this.buttonGroup1.Items.Add(this.playOrPause);
            this.buttonGroup1.Items.Add(this.stopSpeech);
            this.buttonGroup1.Name = "buttonGroup1";
            // 
            // playOrPause
            // 
            this.playOrPause.Image = global::datn.Properties.Resources.play_and_pause_button_icon_media_player_control_icon_vector;
            this.playOrPause.Label = "play/pause";
            this.playOrPause.Name = "playOrPause";
            this.playOrPause.ShowImage = true;
            this.playOrPause.ShowLabel = false;
            this.playOrPause.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.playOrPause_Click);
            // 
            // stopSpeech
            // 
            this.stopSpeech.Image = global::datn.Properties.Resources.stop;
            this.stopSpeech.Label = "stop";
            this.stopSpeech.Name = "stopSpeech";
            this.stopSpeech.ShowImage = true;
            this.stopSpeech.ShowLabel = false;
            this.stopSpeech.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.stopSpeech_Click);
            // 
            // group4
            // 
            this.group4.Items.Add(this.ActiveControlListBtn);
            this.group4.Items.Add(this.listQR);
            this.group4.Label = "Form Control";
            this.group4.Name = "group4";
            // 
            // ActiveControlListBtn
            // 
            this.ActiveControlListBtn.Image = global::datn.Properties.Resources.logo_about;
            this.ActiveControlListBtn.Label = "Content control";
            this.ActiveControlListBtn.Name = "ActiveControlListBtn";
            this.ActiveControlListBtn.ShowImage = true;
            this.ActiveControlListBtn.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button6_Click);
            // 
            // listQR
            // 
            this.listQR.Image = global::datn.Properties.Resources.qrcode_default;
            this.listQR.Label = "List QR Code";
            this.listQR.Name = "listQR";
            this.listQR.ShowImage = true;
            this.listQR.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.listQR_Click);
            // 
            // group5
            // 
            this.group5.Items.Add(this.btnAddQrCode);
            this.group5.Items.Add(this.createQR);
            this.group5.Items.Add(this.qr_showListContentControl);
            this.group5.Label = "QR code";
            this.group5.Name = "group5";
            // 
            // btnAddQrCode
            // 
            this.btnAddQrCode.Image = global::datn.Properties.Resources.qrcode_default;
            this.btnAddQrCode.Label = "Gen QR from selected text";
            this.btnAddQrCode.Name = "btnAddQrCode";
            this.btnAddQrCode.ShowImage = true;
            this.btnAddQrCode.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnAddQrCode_Click);
            // 
            // createQR
            // 
            this.createQR.Image = global::datn.Properties.Resources.qrcode_default;
            this.createQR.Label = "Create QR ";
            this.createQR.Name = "createQR";
            this.createQR.ShowImage = true;
            this.createQR.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.createQRForm_Click);
            // 
            // qr_showListContentControl
            // 
            this.qr_showListContentControl.Image = global::datn.Properties.Resources.qrcode_default;
            this.qr_showListContentControl.Label = "Create QR from content control";
            this.qr_showListContentControl.Name = "qr_showListContentControl";
            this.qr_showListContentControl.ShowImage = true;
            this.qr_showListContentControl.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.qr_showListContentControl_Click);
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.buttonGroup1.ResumeLayout(false);
            this.buttonGroup1.PerformLayout();
            this.group4.ResumeLayout(false);
            this.group4.PerformLayout();
            this.group5.ResumeLayout(false);
            this.group5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton readNumberVN;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton readNumberEn;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton textToSpeechEnBtn;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton aboutBtn;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ActiveControlListBtn;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group5;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAddQrCode;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton playOrPause;
        internal Microsoft.Office.Tools.Ribbon.RibbonButtonGroup buttonGroup1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton stopSpeech;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton createQR;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton qr_showListContentControl;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton listQR;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
