using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDILowerArmMonitoring
{
    public partial class frmSearch : Form
    {

        frmMain MainForm = null;
        CogDisplay[] cogDisplays = null;
        Label[] ResLabels = null;

        public frmSearch()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        public frmSearch(frmMain frmMain)
        {

            InitializeComponent();
            this.MaximizeBox = false;
            MainForm = frmMain;
        }

        private void InitControl()
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

        private void InitForm()
        {
            try
            {
                cbResult.SelectedIndex = 0;
            }
            catch
            {

            }
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            InitControl();
            ScreenDetect();
            InitForm();
        }

        private void frmSearch_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void ScreenDetect()
        {
            try
            {
                Screen[] sc = Screen.AllScreens;

                if (sc.Length > 1)
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

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSetDay_Click(object sender, EventArgs e)
        {
            try
            {
                dtpEnd.Value = DateTime.Now;
                dtpStart.Value = DateTime.Now.AddDays(-1);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnSetWeek_Click(object sender, EventArgs e)
        {
            try
            {
                dtpEnd.Value = DateTime.Now;
                dtpStart.Value = DateTime.Now.AddDays(-7);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnSetMonth_Click(object sender, EventArgs e)
        {
            try
            {
                dtpEnd.Value = DateTime.Now;
                dtpStart.Value = DateTime.Now.AddMonths(-1);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnSetYear_Click(object sender, EventArgs e)
        {
            try
            {
                dtpEnd.Value = DateTime.Now;
                dtpStart.Value = DateTime.Now.AddYears(-1);
            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btn_DB_Search_Click(object sender, EventArgs e)
        {
            try
            {
                string strStartTime = $"{dtpStart.Value.ToString("yyyy-MM-dd")}T00-00-00";
                string strEndTime = $"{dtpEnd.Value.ToString("yyyy-MM-dd")}T23-59-59";

                Task.Run(() =>
                {

                    Invoke(new EventHandler(delegate
                    {
                        List<string[]> list_history = MainForm.DB_sqlite.SelectWhereDateTime(MainForm._var._strSqliteDbPath, MainForm._var._strSqliteDbfile, "LowerArm", strStartTime, strEndTime, cbResult.Text, txt_Engine_Serial.Text);

                        grid_Search.Rows.Clear();
                        for (int i = 0; i < list_history.Count; i++)
                        {
                            grid_Search.Rows.Add(list_history[i]);
                        }
                    }));




                });

            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void grid_Search_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                List<string> lst_StepRes = new List<string>();
                List<string> lst_imageParh = new List<string>();

                Task.Run(() =>
                {
                    Invoke(new EventHandler(delegate
                    {

                        for (int i = 6; i < grid_Search.Columns.Count; i = i + 2)
                        {
                            lst_StepRes.Add(grid_Search[i - 1, e.RowIndex].Value.ToString());
                            lst_imageParh.Add(grid_Search[i, e.RowIndex].Value.ToString());
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


                    }));
                });

                



            }
            catch (Exception ex)
            {
                CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void grid_Search_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
