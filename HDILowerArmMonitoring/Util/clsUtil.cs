using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;


namespace HDILowerArmMonitoring
{
    public class clsUtil
    {
        public static string InitLogDirectory()
        {
            string strLogPath = Application.StartupPath;
            try
            {
                string strLogPath_YYYY = "Log\\" + DateTime.Now.ToString("yyyy");
                if (!IsExistsDir(strLogPath_YYYY)) clsUtil.InitDirectory(strLogPath_YYYY);

                string strLogPath_MM = strLogPath_YYYY + "\\" + DateTime.Now.ToString("MM");
                if (!IsExistsDir(strLogPath_MM)) clsUtil.InitDirectory(strLogPath_MM);

                return strLogPath = Application.StartupPath + "\\" + "Log\\" + DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("MM");
            }
            catch
            {
                return strLogPath;
            }
        }

        public static bool IsExistsDir(string strPath)
        {
            DirectoryInfo di = new DirectoryInfo(Application.StartupPath + "\\" + strPath);
            if (di.Exists) return true;
            return false;
        }

        public static string LoadImage()
        {
            string Image = null;

            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = Application.StartupPath;
                ofd.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Image = ofd.FileName;

                    return Image;
                }
            }
            catch (Exception ex)
            {

                return Image;
            }

            return Image;
        }


        public static string[] LoadImages()
        {
            string[] Images = null;
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = Application.StartupPath;
                ofd.Filter = "Images Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Images = ofd.FileNames;
                    
                    return Images;
                }
            }
            catch (Exception ex)
            {
                
                return Images;
            }

            return Images;
        }

        public static bool InitDirectory(string strFolderName)
        {
            try
            {
                string strFolderPath = Application.StartupPath + "\\" + strFolderName + "\\";
                DirectoryInfo dirRecipe = new DirectoryInfo(strFolderPath);
                if (dirRecipe.Exists == false) dirRecipe.Create();

                return true;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

        public static void SaveImageFileToJPEG(ICogImage cogImage, string sFilePath)
        {
            if (cogImage != null)
            {
                CogImageFileJPEG cogImageFileJPEG = new CogImageFileJPEG();
                cogImageFileJPEG.Open(sFilePath, CogImageFileModeConstants.Write);
                cogImageFileJPEG.Append(cogImage);
                cogImageFileJPEG.Close();
            }
        }

        public static void SaveImageFileToBMP(ICogImage cogImage, string sFilePath)
        {
            if (cogImage != null)
            {
                CogImageFileBMP cogImageFileBMP = new CogImageFileBMP();
                cogImageFileBMP.Open(sFilePath, CogImageFileModeConstants.Write);
                cogImageFileBMP.Append(cogImage);
                cogImageFileBMP.Close();
            }
        }

        public static void SaveImageFileToPNG(ICogImage cogImage, string sFilePath)
        {
            try
            {
                if (cogImage != null)
                {

                    CogImageFilePNG cogImageFilePNG = new CogImageFilePNG();
                    cogImageFilePNG.Open(sFilePath, CogImageFileModeConstants.Write);
                    cogImageFilePNG.Append(cogImage);
                    cogImageFilePNG.Close();
                }
            }
            catch (Exception ex)
            {

            }

        }

        public static void SaveImageBMP(ICogImage image, bool result)
        {

            Bitmap bitmap = new Bitmap(image.ToBitmap());

            DateTime dateTime = DateTime.Now;
            string imagePath = GlovalVar._strStaicImgPath;
            string strPath;

            if (result)
            {
                strPath = imagePath + dateTime.Year.ToString() + dateTime.Month.ToString("D2") + dateTime.Day.ToString("D2") + "\\OK\\";
            }
            else
            {
                strPath = imagePath + dateTime.Year.ToString() + dateTime.Month.ToString("D2") + dateTime.Day.ToString("D2") + "\\NG\\";
            }


            if (!Directory.Exists(strPath))

            {
                Directory.CreateDirectory(strPath);
            }


            strPath = strPath + dateTime.ToString("HH-mm-ss-fff") + ".bmp";
            bitmap.Save(strPath, System.Drawing.Imaging.ImageFormat.Bmp);

            bitmap.Dispose();
        }

        public static void SaveImageBMP(ICogImage image, string modelName, int step, bool result)
        {

            Bitmap bitmap = new Bitmap(image.ToBitmap());

            DateTime dateTime = DateTime.Now;
            string imagePath = GlovalVar._strStaicImgPath;
            string strPath;

            if (result)
            {
                strPath = imagePath +"\\" + dateTime.Year.ToString() + dateTime.Month.ToString("D2") + dateTime.Day.ToString("D2") + "\\OK\\" + $"\\{modelName}" + $"\\{ step + 1}\\";
            }
            else
            {
                strPath = imagePath +"\\" + dateTime.Year.ToString() + dateTime.Month.ToString("D2") + dateTime.Day.ToString("D2") + "\\NG\\" + $"\\{modelName}" + $"\\{ step + 1}\\";
            }

            if (!Directory.Exists(strPath))

            {
                Directory.CreateDirectory(strPath);
            }


            strPath = strPath + GlovalVar._strSerial + $"_{modelName}_" + dateTime.ToString("HH-mm-ss-fff") + ".bmp";
            bitmap.Save(strPath, System.Drawing.Imaging.ImageFormat.Bmp);

            bitmap.Dispose();
        }


        public static void SaveImageBMP(ICogImage image, string modelName, string path, int step, bool result)
        {

            Bitmap bitmap = new Bitmap(image.ToBitmap());

            DateTime dateTime = DateTime.Now;
            string imagePath = path;
            string strPath;

            if (result)
            {
                strPath = imagePath + dateTime.Year.ToString() + dateTime.Month.ToString("D2") + dateTime.Day.ToString("D2") + "\\OK\\" + $"\\{modelName}" + $"\\{ step + 1}\\";
            }
            else
            {
                strPath = imagePath + dateTime.Year.ToString() + dateTime.Month.ToString("D2") + dateTime.Day.ToString("D2") + "\\NG\\" + $"\\{modelName}" + $"\\{ step + 1}\\";
            }

            if (!Directory.Exists(strPath))

            {
                Directory.CreateDirectory(strPath);
            }


            strPath = strPath + dateTime.ToString("HH-mm-ss-fff") + ".bmp";
            bitmap.Save(strPath, System.Drawing.Imaging.ImageFormat.Bmp);

            bitmap.Dispose();
        }
        public static void SaveImageJPG(ICogImage image, string modelName, string path, int step, bool result)
        {

            Bitmap bitmap = new Bitmap(image.ToBitmap());

            DateTime dateTime = DateTime.Now;
            string imagePath = path;
            string strPath;

            if (result)
            {
                strPath = imagePath + dateTime.Year.ToString() + dateTime.Month.ToString("D2") + dateTime.Day.ToString("D2") + "\\OK\\" + $"\\{modelName}" + $"\\{ step + 1}\\";
            }
            else
            {
                strPath = imagePath + dateTime.Year.ToString() + dateTime.Month.ToString("D2") + dateTime.Day.ToString("D2") + "\\NG\\" + $"\\{modelName}" + $"\\{ step + 1}\\";
            }

            if (!Directory.Exists(strPath))

            {
                Directory.CreateDirectory(strPath);
            }


            strPath = strPath + dateTime.ToString("HH-mm-ss-fff") + ".jpg";
            bitmap.Save(strPath, System.Drawing.Imaging.ImageFormat.Jpeg);

            bitmap.Dispose();
        }

        public static void SaveImageJPG(ICogImage image, string modelName, int step, bool result)
        {

            Bitmap bitmap = new Bitmap(image.ToBitmap());

            DateTime dateTime = DateTime.Now;
            string imagePath = GlovalVar._strStaicImgPath;
            string strPath;

            if (result)
            {
                strPath = imagePath + dateTime.Year.ToString() + dateTime.Month.ToString("D2") + dateTime.Day.ToString("D2") + "\\OK\\" + $"\\{modelName}" + $"\\{ step + 1}\\";
            }
            else
            {
                strPath = imagePath + dateTime.Year.ToString() + dateTime.Month.ToString("D2") + dateTime.Day.ToString("D2") + "\\NG\\" + $"\\{modelName}" + $"\\{ step + 1}\\";
            }

            if (!Directory.Exists(strPath))

            {
                Directory.CreateDirectory(strPath);
            }


            strPath = strPath + GlovalVar._strSerial + $"_{modelName}_" + dateTime.ToString("HH-mm-ss-fff") + ".jpg";
            bitmap.Save(strPath, System.Drawing.Imaging.ImageFormat.Jpeg);

            bitmap.Dispose();
        }

        public static string SaveImageParameter(ICogImage cogImage, string path, int step, int type, bool result, string id = "")
        {

            DateTime dateTime = DateTime.Now;
            string imagePath = path;
            string strPath;
            //string end;
            string file;

            if (result)
            {
                strPath = imagePath + "\\" + dateTime.Year.ToString() + dateTime.Month.ToString("D2") + dateTime.Day.ToString("D2") + $"\\OK\\{step}\\";
                file = strPath + $"{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}_{id}_OK";
            }
            else
            {
                strPath = imagePath + "\\" + dateTime.Year.ToString() + dateTime.Month.ToString("D2") + dateTime.Day.ToString("D2") + $"\\NG\\{step}\\";
                file = strPath + $"{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}_{id}_NG";
            }



            if (!Directory.Exists(strPath))

            {
                Directory.CreateDirectory(strPath);
            }

            //strPath = strPath + @"\" + dateTime.ToString("HH-mm-ss-fff") + ".bmp";



            switch (type)
            {
                case 0:
                    file += ".bmp";
                    SaveImageFileToBMP(cogImage, file);

                    break;
                case 1:
                    file += ".jpg";
                    SaveImageFileToJPEG(cogImage, file);


                    break;

                case 2:
                    file += ".png";
                    SaveImageFileToPNG(cogImage, file);


                    break;
            }

            return file;


        }

        public static List<string> SaveImageParameter(ICogImage[] cogImages, string path, int type, bool result)
        {
            

            DateTime dateTime = DateTime.Now;
            string imagePath = path;
            string strPath;
            //string end;
            List<string> files = new List<string>();
            string file;

            for(int i = 0; i < cogImages.Length; i++)
            {
                if (result)
                {
                    strPath = imagePath + "\\" + dateTime.Year.ToString() + dateTime.Month.ToString("D2") + dateTime.Day.ToString("D2") + $"\\OK\\{i + 1}\\";
                    file = strPath + $"{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}_OK";
                }
                else
                {
                    strPath = imagePath + "\\" + dateTime.Year.ToString() + dateTime.Month.ToString("D2") + dateTime.Day.ToString("D2") + $"\\NG\\{i + 1}\\";
                    file = strPath + $"{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}_NG";
                }



                if (!Directory.Exists(strPath))

                {
                    Directory.CreateDirectory(strPath);
                }

                //strPath = strPath + @"\" + dateTime.ToString("HH-mm-ss-fff") + ".bmp";



                switch (type)
                {
                    case 0:
                        file += ".bmp";
                        SaveImageFileToBMP(cogImages[i], file);

                        break;
                    case 1:
                        file += ".jpg";
                        SaveImageFileToJPEG(cogImages[i], file);


                        break;

                    case 2:
                        file += ".png";
                        SaveImageFileToPNG(cogImages[i], file);


                        break;
                }

                files.Add(file);
            }

            

            return files;


        }


        // 0: bmp, 1: jpg, 2, png

        //public static void SaveImageParameter(ICogImage cogImage, int type, bool result)
        //{
        //    DateTime dateTime = DateTime.Now;
        //    string imagePath = GlovalVar._strStaicImgPath;
        //    string strPath;
        //    if (result)
        //    {
        //        strPath = imagePath + dateTime.Year.ToString() + dateTime.Month.ToString("D2") + dateTime.Day.ToString("D2")+"\\OK\\";
        //    }
        //    else
        //    {
        //        strPath = imagePath + dateTime.Year.ToString() + dateTime.Month.ToString("D2") + dateTime.Day.ToString("D2") + "\\NG\\";
        //    }



        //    if (!Directory.Exists(strPath))

        //    {
        //        Directory.CreateDirectory(strPath);
        //    }

        //    //strPath = strPath + @"\" + dateTime.ToString("HH-mm-ss-fff") + ".bmp";

        //    switch (type)
        //    {
        //        case 0:

        //            SaveImageFileToBMP(cogImage, strPath);

        //            break;
        //        case 1:

        //            SaveImageFileToJPEG(cogImage, strPath);

        //            break;

        //        case 2:

        //            SaveImageFileToPNG(cogImage, strPath);

        //            break;
        //    }
        //}

        public static void SetLabelBackColor(Label lbl, bool OnOff)
        {
            if (lbl.InvokeRequired)
            {
                lbl.Invoke(new Action<Label, bool>(SetLabelBackColor), lbl, OnOff);
            }
            else
            {
                if(OnOff)
                {
                    lbl.BackColor = Color.Red;
                }
                else
                {
                    lbl.BackColor = Color.DarkGray;
                }
            }
        }

        //public static void SetLabelBackColor(LabelControl lbl, bool OnOff)
        //{
        //    if (lbl.InvokeRequired)
        //    {
        //        lbl.Invoke(new Action<LabelControl, bool>(SetLabelBackColor), lbl, OnOff);
        //    }
        //    else
        //    {
        //        if (OnOff)
        //        {
        //            lbl.BackColor = Color.Red;
        //        }
        //        else
        //        {
        //            lbl.BackColor = Color.DarkGray;
        //        }
        //    }
        //}

        //public static void SetLabelText(LabelControl lbl, string txt)
        //{
        //    if (lbl.InvokeRequired)
        //    {
        //        lbl.Invoke(new Action<LabelControl, string>(SetLabelText), lbl, txt);
        //    }
        //    else
        //    {
        //        lbl.Text = txt;
        //    }            
        //}

        //public static void SetBarItemText(Bars bar, string txt)
        //{
        //    if (bar.InvokeRequired)
        //    {
        //        bar.Invoke(new Action<LabelControl, string>(SetLabelText), lbl, txt);
        //    }
        //    else
        //    {
        //        bar.Text = txt;
        //    }
        //}


        //public void Test(int x)
        //{

        //}


        //public int Test(int x)
        //{



        //    return 1;
        //}

    }

    



}
