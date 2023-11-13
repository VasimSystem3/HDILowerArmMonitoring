using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex;
using Cognex.VisionPro.Display;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace HDILowerArmMonitoring
{
    public partial class frmMain : Form
    {
        frmSearch frm_Search = null;


        private GlovalVar.SettingScreen _SetScreen = new GlovalVar.SettingScreen();
        private GlovalVar.AdminMode _AdminMode = GlovalVar.AdminMode.ImageSearch;

        CogDisplay[] cogDisplays = null;
        Label[] ResLabels = null;
        
        List<CogImage8Grey> lst_cogMonoImage = null;
        List<CogImage24PlanarColor> lst_cogColorImage = null;

        public ClsSqlite DB_sqlite = null;
        public IniFiles ini = new IniFiles();
        public GlovalVar _var = new GlovalVar();

        bool _bTimeThread = false;
        Thread thread_Time = null;

        
        public ClsSocketClient Socket_Client = null;

        public frmMain()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                Loading();

                ScreenDetect();

                InitForm();
            }
            catch
            {

            }

            
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if(Socket_Client.b_Connected)
                {
                    Socket_Client.CloseClient();
                }


                if (thread_Time != null && thread_Time.IsAlive)
                {
                    thread_Time.Abort();
                    Thread.Sleep(100);

                }

                

            }
            catch
            {

            }
            


        }

        private void ScreenDetect()
        {
            try
            {
                Screen[] sc = Screen.AllScreens;

                if(sc.Length > 1)
                {
                    Screen screen = (sc[0].WorkingArea.Contains(this.Location) ? sc[1] : sc[0]);

                    this.Show();
                    this.Location = screen.Bounds.Location;
                    //this.WindowState = FormWindowState.Maximized;
                }
            }
            catch
            {

            }
        }

        private void LoadingControl()
        {
            try
            {
                cogDisplays = new CogDisplay[] { cogDisplay, cogDisplay1, cogDisplay2, cogDisplay3, cogDisplay4, cogDisplay5, cogDisplay6, cogDisplay7 };

                ResLabels = new Label[] { lbl_Camera1_Result, lbl_Camera2_Result, lbl_Camera3_Result, lbl_Camera4_Result, lbl_Camera5_Result, lbl_Camera6_Result, lbl_Camera7_Result, lbl_Camera8_Result };

            }
            catch
            {

            }
        }

        private void Loading()
        {
            try
            {
                LoadingControl();
                Delay(50);

                LoadSet();
                Delay(50);

                InitDB();
                Delay(50);

                InitSocket();
                Delay(50);


                _bTimeThread = true;
                thread_Time = new Thread(CurrentTime);
                thread_Time.Start();
            }
            catch
            {

            }
            


        }

        private void LoadSet()
        {
            try
            {

                _var._strSqliteDbPath = ini.ReadIniFile("DBPath", "Value", _var._strConfigPath, "Config.ini");
                GlovalVar.strServerIP = ini.ReadIniFile("SocketIP", "Value", _var._strConfigPath, "Config.ini");
                GlovalVar.strPort = ini.ReadIniFile("SocketPort", "Value", _var._strConfigPath, "Config.ini");


            }
            catch
            {

            }
        }


        private void InitForm()
        {

            Invoke(new EventHandler(delegate
            {
                txt_DBPath.Text = _var._strSqliteDbPath;

                txt_SocketIP.Text = GlovalVar.strServerIP;
                txt_SocketPort.Text = GlovalVar.strPort;
            }));



        }

        private void InitSocket()
        {
            try
            {

                Socket_Client = new ClsSocketClient();

                Socket_Client.OnConnect = OnServerConnect;
                Socket_Client.OnDisconnect = OnServerDisConnect;
                Socket_Client.OnClientRecvData = OnClientRecvData;

                if (!Socket_Client.b_Connected)
                {
                    Socket_Client.OpenClient(GlovalVar.strServerIP, int.Parse(GlovalVar.strPort));
                }

            }
            catch
            {

            }
        }

        private void OnServerConnect()
        {
            try
            {
                Invoke(new EventHandler(delegate
                {
                    lbl_SocketConnect.BackColor = Color.Green;
                    lbl_SocketConnect.Text = "Server Connect";
                }));

                


            }
            catch
            {

            }
        }

        private void ReServerConnect()
        {
            try
            {
                if(Socket_Client != null)
                {
                    while(!Socket_Client.b_Connected)
                    {
                        bool tmp = Socket_Client.OpenClient(GlovalVar.strServerIP, int.Parse(GlovalVar.strPort));

                        if(tmp)
                        {
                            break;
                        }

                    }
                }
            }
            catch
            {

            }
        }


        private void OnServerDisConnect()
        {
            try
            {
                Invoke(new EventHandler(delegate
                {
                    Socket_Client.b_Connected = false;
                    lbl_SocketConnect.BackColor = Color.Red;
                    lbl_SocketConnect.Text = "Server DisConnect";
                }));

                
            }
            catch
            {

            }


        }

        private void OnClientRecvData(string data)
        {
            try
            {

                if (!string.IsNullOrEmpty(data))
                {
                    string strStartTime = $"{DateTime.Now.ToString("yyyy-MM-dd")}T00-00-00";
                    string strEndTime = $"{DateTime.Now.ToString("yyyy-MM-dd")}T23-59-59";

                    
                    List<string[]> list_EngineNum = new List<string[]>();
                    List<string> lst_imageParh = new List<string>();
                    List<string> lst_StepRes = new List<string>();

                    Task.Run(() =>
                    {
                        Invoke(new EventHandler(delegate
                        {
                            
                            for(int j = 0; j < cogDisplays.Length; j++)
                            {
                                cogDisplays[j].Image = null;
                            }



                            list_EngineNum = DB_sqlite.SelectWhereEngineNum(_var._strSqliteDbPath, _var._strSqliteDbfile, "LowerArm", strStartTime, strEndTime, data);

                            if(list_EngineNum != null)
                            {
                                if(list_EngineNum.Count > 0)
                                {
                                    lbl_Engine_Serial.Text = $"ENGINE SERIAL : {list_EngineNum[0][3]}";
                                    lbl_TotalResult.Text = list_EngineNum[0][4];

                                    if(list_EngineNum[0][4] == "OK")
                                    {
                                        lbl_TotalResult.BackColor = Color.Green;
                                    }
                                    else
                                    {
                                        lbl_TotalResult.BackColor = Color.Red;
                                    }


                                    

                                    for(int k = 6; k < list_EngineNum[0].Length; k = k + 2)
                                    {
                                        lst_StepRes.Add(list_EngineNum[0][k - 1]);
                                        lst_imageParh.Add(list_EngineNum[0][k]);
                                    }

                                    
                                    for (int i = 0; i < lst_imageParh.Count; i++)
                                    {

                                        using (Bitmap bmp = new Bitmap(lst_imageParh[i]))
                                        using (CogImage8Grey img = new CogImage8Grey(bmp))
                                        {

                                            cogDisplays[i].Image = img;

                                            ResLabels[i].Text = lst_StepRes[i];

                                            if (lst_StepRes[i] == "OK")
                                            {
                                                ResLabels[i].BackColor = Color.Green;
                                            }
                                            else if (lst_StepRes[i] == "NG")
                                            {
                                                ResLabels[i].BackColor = Color.Red;
                                            }
                                            else
                                            {
                                                ResLabels[i].BackColor = Color.Yellow;
                                            }

                                        }




                                    }
                                }
                                

                            }


                        }));
                    });
                }

                



            }
            catch
            {

            }
        }

        private void InitDB()
        {
            try
            {
                DB_sqlite = new ClsSqlite();

                

                FileInfo file = new FileInfo(_var._strSqliteDbPath);

                if (!file.Exists)
                {
                    DB_sqlite.Create(_var._strSqliteDbPath, _var._strSqliteDbfile);
                    DB_sqlite.CreateTable(file.FullName, "LowerArm", new KeyValuePair<string, string>[]
                    {
                        new KeyValuePair<string, string>("Time", "TEXT NOT NULL"),
                        new KeyValuePair<string, string>("Model", "TEXT"),
                        new KeyValuePair<string, string>("Serial", "TEXT"),
                        new KeyValuePair<string, string>("TotalResult", "TEXT"),
                        new KeyValuePair<string, string>("StepResult1", "TEXT"),
                        new KeyValuePair<string, string>("StepResultImagePath1", "TEXT"),
                        new KeyValuePair<string, string>("StepResult2", "TEXT"),
                        new KeyValuePair<string, string>("StepResultImagePath2", "TEXT"),
                        new KeyValuePair<string, string>("StepResult3", "TEXT"),
                        new KeyValuePair<string, string>("StepResultImagePath3", "TEXT"),
                        new KeyValuePair<string, string>("StepResult4", "TEXT"),
                        new KeyValuePair<string, string>("StepResultImagePath4", "TEXT"),
                        new KeyValuePair<string, string>("StepResult5", "TEXT"),
                        new KeyValuePair<string, string>("StepResultImagePath5", "TEXT"),
                        new KeyValuePair<string, string>("StepResult6", "TEXT"),
                        new KeyValuePair<string, string>("StepResultImagePath6", "TEXT"),
                        new KeyValuePair<string, string>("StepResult7", "TEXT"),
                        new KeyValuePair<string, string>("StepResultImagePath7", "TEXT"),
                        new KeyValuePair<string, string>("StepResult8", "TEXT"),
                        new KeyValuePair<string, string>("StepResultImagePath8", "TEXT"),
                    });
                }


                CLogger.Add(LOG.DB, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);

            }
            catch (System.Exception ex)
            {
                CLogger.Add(LOG.EXCEPTION, "[FAILED] {0}==>{1} Execption ==> {2} DB Init Fail", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {

            

            this.Dispose();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CurrentTime()                                      // 현재 시간 표시 함수.
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            try
            {
                while (_bTimeThread)
                {
                    if (sw.ElapsedMilliseconds >= 1000)
                    {
                        sw.Reset();
                        sw.Start();

                        Invoke(new EventHandler(delegate
                        {
                            //lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                            //bar_DateTime.Caption = "DATE TIME : " + DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss");
                            //bar_DateTime.ItemAppearance.Normal.Font = new Font("Tahoma", 12, FontStyle.Bold);

                            lbl_time.Text = "DATE TIME : " + DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss");

                            //if (bar_DateTime.Caption == DateTime.Now.ToString("yyyy-mm-dd-" + "05:00:00"))
                            //{
                            //    lbl_bar_TotalNum.Caption = "0";
                            //    lbl_bar_NGNum.Caption = "0";
                            //    lbl_bar_OKNum.Caption = "0";
                            //    _var._nTotalCnt = 0;
                            //    _var._nOKCnt = 0;
                            //    _var._nNGCnt = 0;

                            //    //SaveCount();
                            //}

                            //if (lblTime.Caption == "00:00:00")
                            //ResetCount();
                        }));
                    }
                    Thread.Sleep(1);
                }
            }
            catch (System.Exception ex)
            {
                //AddMsg(Str.CatchError + ex.Message, red, false, false, GlovalVar.MsgType.Alarm);
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        public void Delay(int ms)                               // 딜레이 함수.
        {
            DateTime dateTimeNow = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, ms);
            DateTime dateTimeAdd = dateTimeNow.Add(duration);

            while (dateTimeAdd >= dateTimeNow)
            {
                System.Windows.Forms.Application.DoEvents();
                dateTimeNow = DateTime.Now;
            }
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();

                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    string strFilePath = ofd.FileName;


                    string strpath = _var._strConfigPath + "\\";

                    DirectoryInfo dir = new DirectoryInfo(strpath);

                    if(!dir.Exists)
                    {
                        dir.Create();
                    }

                    _var._strSqliteDbPath = strFilePath;
                    ini.WriteIniFile("DBPath", $"Value", _var._strSqliteDbPath, strpath, "Config.ini");
                }

            }
            catch
            {

            }
        }

        private void btn_SocketSettingSave_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = txt_SocketIP.Text;
                string port = txt_SocketPort.Text;

                if(!string.IsNullOrEmpty(ip) && !string.IsNullOrEmpty(port))
                {
                    ini.WriteIniFile("SocketIP", "Value", ip, _var._strConfigPath, "Config.ini");
                    ini.WriteIniFile("SocketPort", "Value", port, _var._strConfigPath, "Config.ini");

                }


            }
            catch
            {

            }
        }

        private void btn_ImageSearchFrm_Click(object sender, EventArgs e)
        {
            try
            {
                _AdminMode = GlovalVar.AdminMode.ImageSearch;                         
                ChkPassNext();
            }
            catch
            {

            }
        }

        private void ChkPassNext()
        {
            

            if (_AdminMode == GlovalVar.AdminMode.ImageSearch)
            {
                _SetScreen = GlovalVar.SettingScreen.Communication;                     
                if (_SetScreen == GlovalVar.SettingScreen.Communication)
                {
                    if (frm_Search != null)                                    
                    {
                        frm_Search.Dispose();
                        frm_Search = null;
                    }

                    frm_Search = new frmSearch(this);                     
                    frm_Search.Show();
                }
                
            }

           
            
        }
    }
}
