
namespace HDILowerArmMonitoring
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cogDisplay7 = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplay6 = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplay5 = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplay4 = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplay3 = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplay2 = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplay1 = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplay = new Cognex.VisionPro.Display.CogDisplay();
            this.lbl_Engine_Serial = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_ImageSearchFrm = new System.Windows.Forms.Button();
            this.lbl_time = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.txt_DBPath = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_SocketPort = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_SocketIP = new System.Windows.Forms.TextBox();
            this.lbl_TotalResult = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btn_SocketSettingSave = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.lbl_Camera4_Result = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbl_Camera3_Result = new System.Windows.Forms.Label();
            this.lbl_Camera1_Result = new System.Windows.Forms.Label();
            this.lbl_Camera2_Result = new System.Windows.Forms.Label();
            this.lbl_Camera5_Result = new System.Windows.Forms.Label();
            this.lbl_Camera6_Result = new System.Windows.Forms.Label();
            this.lbl_Camera7_Result = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbl_Camera8_Result = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lbl_SocketConnect = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cogDisplay7
            // 
            this.cogDisplay7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cogDisplay7.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay7.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay7.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay7.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay7.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay7.DoubleTapZoomCycleLength = 2;
            this.cogDisplay7.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay7.Location = new System.Drawing.Point(1228, 576);
            this.cogDisplay7.Margin = new System.Windows.Forms.Padding(4);
            this.cogDisplay7.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay7.MouseWheelSensitivity = 1D;
            this.cogDisplay7.Name = "cogDisplay7";
            this.cogDisplay7.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay7.OcxState")));
            this.cogDisplay7.Size = new System.Drawing.Size(400, 400);
            this.cogDisplay7.TabIndex = 2115;
            // 
            // cogDisplay6
            // 
            this.cogDisplay6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cogDisplay6.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay6.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay6.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay6.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay6.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay6.DoubleTapZoomCycleLength = 2;
            this.cogDisplay6.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay6.Location = new System.Drawing.Point(820, 576);
            this.cogDisplay6.Margin = new System.Windows.Forms.Padding(4);
            this.cogDisplay6.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay6.MouseWheelSensitivity = 1D;
            this.cogDisplay6.Name = "cogDisplay6";
            this.cogDisplay6.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay6.OcxState")));
            this.cogDisplay6.Size = new System.Drawing.Size(400, 400);
            this.cogDisplay6.TabIndex = 2114;
            // 
            // cogDisplay5
            // 
            this.cogDisplay5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cogDisplay5.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay5.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay5.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay5.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay5.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay5.DoubleTapZoomCycleLength = 2;
            this.cogDisplay5.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay5.Location = new System.Drawing.Point(412, 576);
            this.cogDisplay5.Margin = new System.Windows.Forms.Padding(4);
            this.cogDisplay5.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay5.MouseWheelSensitivity = 1D;
            this.cogDisplay5.Name = "cogDisplay5";
            this.cogDisplay5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay5.OcxState")));
            this.cogDisplay5.Size = new System.Drawing.Size(400, 400);
            this.cogDisplay5.TabIndex = 2113;
            // 
            // cogDisplay4
            // 
            this.cogDisplay4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cogDisplay4.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay4.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay4.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay4.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay4.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay4.DoubleTapZoomCycleLength = 2;
            this.cogDisplay4.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay4.Location = new System.Drawing.Point(4, 576);
            this.cogDisplay4.Margin = new System.Windows.Forms.Padding(4);
            this.cogDisplay4.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay4.MouseWheelSensitivity = 1D;
            this.cogDisplay4.Name = "cogDisplay4";
            this.cogDisplay4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay4.OcxState")));
            this.cogDisplay4.Size = new System.Drawing.Size(400, 400);
            this.cogDisplay4.TabIndex = 2112;
            // 
            // cogDisplay3
            // 
            this.cogDisplay3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cogDisplay3.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay3.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay3.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay3.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay3.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay3.DoubleTapZoomCycleLength = 2;
            this.cogDisplay3.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay3.Location = new System.Drawing.Point(1228, 114);
            this.cogDisplay3.Margin = new System.Windows.Forms.Padding(4);
            this.cogDisplay3.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay3.MouseWheelSensitivity = 1D;
            this.cogDisplay3.Name = "cogDisplay3";
            this.cogDisplay3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay3.OcxState")));
            this.cogDisplay3.Size = new System.Drawing.Size(400, 400);
            this.cogDisplay3.TabIndex = 2111;
            // 
            // cogDisplay2
            // 
            this.cogDisplay2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cogDisplay2.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay2.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay2.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay2.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay2.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay2.DoubleTapZoomCycleLength = 2;
            this.cogDisplay2.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay2.Location = new System.Drawing.Point(820, 114);
            this.cogDisplay2.Margin = new System.Windows.Forms.Padding(4);
            this.cogDisplay2.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay2.MouseWheelSensitivity = 1D;
            this.cogDisplay2.Name = "cogDisplay2";
            this.cogDisplay2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay2.OcxState")));
            this.cogDisplay2.Size = new System.Drawing.Size(400, 400);
            this.cogDisplay2.TabIndex = 2110;
            // 
            // cogDisplay1
            // 
            this.cogDisplay1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cogDisplay1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay1.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay1.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay1.DoubleTapZoomCycleLength = 2;
            this.cogDisplay1.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay1.Location = new System.Drawing.Point(412, 114);
            this.cogDisplay1.Margin = new System.Windows.Forms.Padding(4);
            this.cogDisplay1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay1.MouseWheelSensitivity = 1D;
            this.cogDisplay1.Name = "cogDisplay1";
            this.cogDisplay1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay1.OcxState")));
            this.cogDisplay1.Size = new System.Drawing.Size(400, 400);
            this.cogDisplay1.TabIndex = 2109;
            // 
            // cogDisplay
            // 
            this.cogDisplay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cogDisplay.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay.DoubleTapZoomCycleLength = 2;
            this.cogDisplay.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplay.Location = new System.Drawing.Point(4, 114);
            this.cogDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.cogDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay.MouseWheelSensitivity = 1D;
            this.cogDisplay.Name = "cogDisplay";
            this.cogDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay.OcxState")));
            this.cogDisplay.Size = new System.Drawing.Size(400, 400);
            this.cogDisplay.TabIndex = 2108;
            // 
            // lbl_Engine_Serial
            // 
            this.lbl_Engine_Serial.AutoSize = true;
            this.lbl_Engine_Serial.BackColor = System.Drawing.Color.DarkGray;
            this.lbl_Engine_Serial.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Engine_Serial.ForeColor = System.Drawing.Color.Black;
            this.lbl_Engine_Serial.Location = new System.Drawing.Point(8, 18);
            this.lbl_Engine_Serial.Name = "lbl_Engine_Serial";
            this.lbl_Engine_Serial.Size = new System.Drawing.Size(238, 37);
            this.lbl_Engine_Serial.TabIndex = 2117;
            this.lbl_Engine_Serial.Text = "ENGINE SERIAL :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 32);
            this.label3.TabIndex = 2118;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.btn_ImageSearchFrm);
            this.panel1.Controls.Add(this.lbl_time);
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.lbl_Engine_Serial);
            this.panel1.Location = new System.Drawing.Point(4, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1899, 73);
            this.panel1.TabIndex = 2119;
            // 
            // btn_ImageSearchFrm
            // 
            this.btn_ImageSearchFrm.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ImageSearchFrm.Location = new System.Drawing.Point(1286, 6);
            this.btn_ImageSearchFrm.Name = "btn_ImageSearchFrm";
            this.btn_ImageSearchFrm.Size = new System.Drawing.Size(339, 59);
            this.btn_ImageSearchFrm.TabIndex = 2120;
            this.btn_ImageSearchFrm.Text = "IMAGE SEARCH";
            this.btn_ImageSearchFrm.UseVisualStyleBackColor = true;
            this.btn_ImageSearchFrm.Click += new System.EventHandler(this.btn_ImageSearchFrm_Click);
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.BackColor = System.Drawing.Color.DarkGray;
            this.lbl_time.Font = new System.Drawing.Font("Arial Narrow", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.ForeColor = System.Drawing.Color.Black;
            this.lbl_time.Location = new System.Drawing.Point(811, 20);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(86, 42);
            this.lbl_time.TabIndex = 2119;
            this.lbl_time.Text = "Time";
            this.lbl_time.Click += new System.EventHandler(this.label19_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.Location = new System.Drawing.Point(1631, 6);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(265, 59);
            this.btn_Close.TabIndex = 2118;
            this.btn_Close.Text = "CLOSE";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.txt_DBPath);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txt_SocketPort);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txt_SocketIP);
            this.panel2.Controls.Add(this.lbl_TotalResult);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.btn_SocketSettingSave);
            this.panel2.Location = new System.Drawing.Point(1635, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 940);
            this.panel2.TabIndex = 2137;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(87, 660);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(177, 28);
            this.button2.TabIndex = 2154;
            this.button2.Text = "Modify && Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_DBPath
            // 
            this.txt_DBPath.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DBPath.Location = new System.Drawing.Point(9, 691);
            this.txt_DBPath.Name = "txt_DBPath";
            this.txt_DBPath.ReadOnly = true;
            this.txt_DBPath.Size = new System.Drawing.Size(255, 38);
            this.txt_DBPath.TabIndex = 2153;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.DarkGray;
            this.label12.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(10, 660);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(75, 31);
            this.label12.TabIndex = 2152;
            this.label12.Text = "PATH";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(8, 630);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(256, 27);
            this.label9.TabIndex = 2151;
            this.label9.Text = "DB Setting";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_SocketPort
            // 
            this.txt_SocketPort.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SocketPort.Location = new System.Drawing.Point(91, 807);
            this.txt_SocketPort.Name = "txt_SocketPort";
            this.txt_SocketPort.Size = new System.Drawing.Size(173, 38);
            this.txt_SocketPort.TabIndex = 2150;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.DarkGray;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(10, 814);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 31);
            this.label8.TabIndex = 2149;
            this.label8.Text = "PORT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.DarkGray;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(10, 766);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 31);
            this.label6.TabIndex = 2148;
            this.label6.Text = "IP";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(8, 733);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(256, 27);
            this.label5.TabIndex = 2147;
            this.label5.Text = "Socket Setting";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DarkGray;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(7, 772);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 31);
            this.label4.TabIndex = 2120;
            // 
            // txt_SocketIP
            // 
            this.txt_SocketIP.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SocketIP.Location = new System.Drawing.Point(51, 763);
            this.txt_SocketIP.Name = "txt_SocketIP";
            this.txt_SocketIP.Size = new System.Drawing.Size(213, 38);
            this.txt_SocketIP.TabIndex = 2042;
            // 
            // lbl_TotalResult
            // 
            this.lbl_TotalResult.BackColor = System.Drawing.Color.White;
            this.lbl_TotalResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_TotalResult.Font = new System.Drawing.Font("Arial", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TotalResult.ForeColor = System.Drawing.Color.Black;
            this.lbl_TotalResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_TotalResult.Location = new System.Drawing.Point(3, 44);
            this.lbl_TotalResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_TotalResult.Name = "lbl_TotalResult";
            this.lbl_TotalResult.Size = new System.Drawing.Size(261, 159);
            this.lbl_TotalResult.TabIndex = 2041;
            this.lbl_TotalResult.Text = "RESULT";
            this.lbl_TotalResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Black;
            this.label19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label19.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label19.Location = new System.Drawing.Point(2, 4);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(262, 40);
            this.label19.TabIndex = 2040;
            this.label19.Text = "TOTAL RESULT";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_SocketSettingSave
            // 
            this.btn_SocketSettingSave.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SocketSettingSave.Location = new System.Drawing.Point(2, 848);
            this.btn_SocketSettingSave.Name = "btn_SocketSettingSave";
            this.btn_SocketSettingSave.Size = new System.Drawing.Size(262, 43);
            this.btn_SocketSettingSave.TabIndex = 0;
            this.btn_SocketSettingSave.Text = "Setting Save";
            this.btn_SocketSettingSave.UseVisualStyleBackColor = true;
            this.btn_SocketSettingSave.Click += new System.EventHandler(this.btn_SocketSettingSave_Click);
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Black;
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label20.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label20.Location = new System.Drawing.Point(1228, 85);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(400, 27);
            this.label20.TabIndex = 2138;
            this.label20.Text = "STEP 4";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Camera4_Result
            // 
            this.lbl_Camera4_Result.BackColor = System.Drawing.Color.White;
            this.lbl_Camera4_Result.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Camera4_Result.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.lbl_Camera4_Result.ForeColor = System.Drawing.Color.Black;
            this.lbl_Camera4_Result.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Camera4_Result.Location = new System.Drawing.Point(1228, 518);
            this.lbl_Camera4_Result.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Camera4_Result.Name = "lbl_Camera4_Result";
            this.lbl_Camera4_Result.Size = new System.Drawing.Size(400, 27);
            this.lbl_Camera4_Result.TabIndex = 2139;
            this.lbl_Camera4_Result.Text = "STEP 4 RESULT";
            this.lbl_Camera4_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(4, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 27);
            this.label1.TabIndex = 2140;
            this.label1.Text = "STEP 1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(412, 85);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(400, 27);
            this.label7.TabIndex = 2141;
            this.label7.Text = "STEP 2";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Black;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label14.Location = new System.Drawing.Point(820, 85);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(400, 27);
            this.label14.TabIndex = 2142;
            this.label14.Text = "STEP 3";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Camera3_Result
            // 
            this.lbl_Camera3_Result.BackColor = System.Drawing.Color.White;
            this.lbl_Camera3_Result.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Camera3_Result.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.lbl_Camera3_Result.ForeColor = System.Drawing.Color.Black;
            this.lbl_Camera3_Result.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Camera3_Result.Location = new System.Drawing.Point(820, 518);
            this.lbl_Camera3_Result.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Camera3_Result.Name = "lbl_Camera3_Result";
            this.lbl_Camera3_Result.Size = new System.Drawing.Size(400, 27);
            this.lbl_Camera3_Result.TabIndex = 2143;
            this.lbl_Camera3_Result.Text = "STEP 3 RESULT";
            this.lbl_Camera3_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Camera1_Result
            // 
            this.lbl_Camera1_Result.BackColor = System.Drawing.Color.White;
            this.lbl_Camera1_Result.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Camera1_Result.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.lbl_Camera1_Result.ForeColor = System.Drawing.Color.Black;
            this.lbl_Camera1_Result.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Camera1_Result.Location = new System.Drawing.Point(4, 518);
            this.lbl_Camera1_Result.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Camera1_Result.Name = "lbl_Camera1_Result";
            this.lbl_Camera1_Result.Size = new System.Drawing.Size(400, 27);
            this.lbl_Camera1_Result.TabIndex = 2145;
            this.lbl_Camera1_Result.Text = "STEP 1 RESULT";
            this.lbl_Camera1_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Camera2_Result
            // 
            this.lbl_Camera2_Result.BackColor = System.Drawing.Color.White;
            this.lbl_Camera2_Result.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Camera2_Result.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.lbl_Camera2_Result.ForeColor = System.Drawing.Color.Black;
            this.lbl_Camera2_Result.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Camera2_Result.Location = new System.Drawing.Point(412, 518);
            this.lbl_Camera2_Result.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Camera2_Result.Name = "lbl_Camera2_Result";
            this.lbl_Camera2_Result.Size = new System.Drawing.Size(400, 27);
            this.lbl_Camera2_Result.TabIndex = 2144;
            this.lbl_Camera2_Result.Text = "STEP 2 RESULT";
            this.lbl_Camera2_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Camera5_Result
            // 
            this.lbl_Camera5_Result.BackColor = System.Drawing.Color.White;
            this.lbl_Camera5_Result.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Camera5_Result.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.lbl_Camera5_Result.ForeColor = System.Drawing.Color.Black;
            this.lbl_Camera5_Result.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Camera5_Result.Location = new System.Drawing.Point(4, 980);
            this.lbl_Camera5_Result.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Camera5_Result.Name = "lbl_Camera5_Result";
            this.lbl_Camera5_Result.Size = new System.Drawing.Size(400, 27);
            this.lbl_Camera5_Result.TabIndex = 2153;
            this.lbl_Camera5_Result.Text = "STEP 5 RESULT";
            this.lbl_Camera5_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Camera6_Result
            // 
            this.lbl_Camera6_Result.BackColor = System.Drawing.Color.White;
            this.lbl_Camera6_Result.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Camera6_Result.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.lbl_Camera6_Result.ForeColor = System.Drawing.Color.Black;
            this.lbl_Camera6_Result.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Camera6_Result.Location = new System.Drawing.Point(412, 980);
            this.lbl_Camera6_Result.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Camera6_Result.Name = "lbl_Camera6_Result";
            this.lbl_Camera6_Result.Size = new System.Drawing.Size(400, 27);
            this.lbl_Camera6_Result.TabIndex = 2152;
            this.lbl_Camera6_Result.Text = "STEP 6 RESULT";
            this.lbl_Camera6_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Camera7_Result
            // 
            this.lbl_Camera7_Result.BackColor = System.Drawing.Color.White;
            this.lbl_Camera7_Result.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Camera7_Result.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.lbl_Camera7_Result.ForeColor = System.Drawing.Color.Black;
            this.lbl_Camera7_Result.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Camera7_Result.Location = new System.Drawing.Point(820, 980);
            this.lbl_Camera7_Result.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Camera7_Result.Name = "lbl_Camera7_Result";
            this.lbl_Camera7_Result.Size = new System.Drawing.Size(400, 27);
            this.lbl_Camera7_Result.TabIndex = 2151;
            this.lbl_Camera7_Result.Text = "STEP 7 RESULT";
            this.lbl_Camera7_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(820, 547);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(400, 27);
            this.label10.TabIndex = 2150;
            this.label10.Text = "STEP 7";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Black;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label11.Location = new System.Drawing.Point(412, 547);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(400, 27);
            this.label11.TabIndex = 2149;
            this.label11.Text = "STEP 6";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Black;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Location = new System.Drawing.Point(4, 547);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(400, 27);
            this.label13.TabIndex = 2148;
            this.label13.Text = "STEP 5";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Camera8_Result
            // 
            this.lbl_Camera8_Result.BackColor = System.Drawing.Color.White;
            this.lbl_Camera8_Result.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Camera8_Result.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.lbl_Camera8_Result.ForeColor = System.Drawing.Color.Black;
            this.lbl_Camera8_Result.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Camera8_Result.Location = new System.Drawing.Point(1228, 980);
            this.lbl_Camera8_Result.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_Camera8_Result.Name = "lbl_Camera8_Result";
            this.lbl_Camera8_Result.Size = new System.Drawing.Size(400, 27);
            this.lbl_Camera8_Result.TabIndex = 2147;
            this.lbl_Camera8_Result.Text = "STEP 8 RESULT";
            this.lbl_Camera8_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Black;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label17.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label17.Location = new System.Drawing.Point(1228, 547);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(400, 27);
            this.label17.TabIndex = 2146;
            this.label17.Text = "STEP 8";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_SocketConnect
            // 
            this.lbl_SocketConnect.BackColor = System.Drawing.Color.Red;
            this.lbl_SocketConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_SocketConnect.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.lbl_SocketConnect.ForeColor = System.Drawing.Color.Black;
            this.lbl_SocketConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_SocketConnect.Location = new System.Drawing.Point(1637, 980);
            this.lbl_SocketConnect.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_SocketConnect.Name = "lbl_SocketConnect";
            this.lbl_SocketConnect.Size = new System.Drawing.Size(262, 42);
            this.lbl_SocketConnect.TabIndex = 2155;
            this.lbl_SocketConnect.Text = "DisConnect";
            this.lbl_SocketConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1908, 1037);
            this.Controls.Add(this.lbl_SocketConnect);
            this.Controls.Add(this.lbl_Camera5_Result);
            this.Controls.Add(this.lbl_Camera6_Result);
            this.Controls.Add(this.lbl_Camera7_Result);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lbl_Camera8_Result);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lbl_Camera1_Result);
            this.Controls.Add(this.lbl_Camera2_Result);
            this.Controls.Add(this.lbl_Camera3_Result);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_Camera4_Result);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cogDisplay);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cogDisplay7);
            this.Controls.Add(this.cogDisplay6);
            this.Controls.Add(this.cogDisplay5);
            this.Controls.Add(this.cogDisplay4);
            this.Controls.Add(this.cogDisplay3);
            this.Controls.Add(this.cogDisplay2);
            this.Controls.Add(this.cogDisplay1);
            this.Name = "frmMain";
            this.Text = "HDILowerArmMonitoring";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Cognex.VisionPro.Display.CogDisplay cogDisplay7;
        internal Cognex.VisionPro.Display.CogDisplay cogDisplay6;
        internal Cognex.VisionPro.Display.CogDisplay cogDisplay5;
        internal Cognex.VisionPro.Display.CogDisplay cogDisplay4;
        internal Cognex.VisionPro.Display.CogDisplay cogDisplay3;
        internal Cognex.VisionPro.Display.CogDisplay cogDisplay2;
        internal Cognex.VisionPro.Display.CogDisplay cogDisplay1;
        internal Cognex.VisionPro.Display.CogDisplay cogDisplay;
        private System.Windows.Forms.Label lbl_Engine_Serial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btn_SocketSettingSave;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lbl_Camera4_Result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbl_Camera3_Result;
        private System.Windows.Forms.Label lbl_Camera1_Result;
        private System.Windows.Forms.Label lbl_Camera2_Result;
        private System.Windows.Forms.Label lbl_Camera5_Result;
        private System.Windows.Forms.Label lbl_Camera6_Result;
        private System.Windows.Forms.Label lbl_Camera7_Result;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbl_Camera8_Result;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbl_TotalResult;
        private System.Windows.Forms.Button btn_ImageSearchFrm;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_DBPath;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_SocketPort;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_SocketIP;
        private System.Windows.Forms.Label lbl_SocketConnect;
    }
}

