using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;

namespace HDILowerArmMonitoring
{
    public class ClsSqlite
    {

        private string m_strConnectPath;
        private string m_strDBFileName;

        public ClsSqlite()
        {

        }

        public ClsSqlite(string strPath)
        {
            m_strConnectPath = strPath;
        }

        public ClsSqlite(string strPath, string fileName)
        {
            m_strConnectPath = strPath;
            m_strDBFileName = fileName;
        }

        //Create
        public void Create()
        {
            try
            {
                SQLiteConnection.CreateFile(m_strConnectPath);
            }
            catch
            {

            }
        }

        public void Create(string path, string fileName)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);

                if(!dir.Exists)
                {
                    dir.Create();
                }

                string file = dir + "\\" + fileName + ".sqlite";

                SQLiteConnection.CreateFile(file);
            }
            catch
            {

            }
        }

        public void CreateTable(string strTableName, KeyValuePair<string, string>[] tables)
        {
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={m_strConnectPath};Version=3;"))
            using (var command = new SQLiteCommand(conn))
            {
                conn.Open();

                command.CommandText = GetTableCreationCommand(true, strTableName, tables);
                command.ExecuteNonQuery();
            }
        }

        public void CreateTable(string path, string strTableName, KeyValuePair<string, string>[] tables)
        {
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={path};Version=3;"))
            using (var command = new SQLiteCommand(conn))
            {
                conn.Open();

                command.CommandText = GetTableCreationCommand(true, strTableName, tables);
                command.ExecuteNonQuery();
            }
        }

        private string GetTableCreationCommand(bool onlyNotExist, string name, KeyValuePair<string, string>[] elements)
        {
            
            string strQuery = $"CREATE TABLE IF NOT EXISTS '{name}'(id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL";

            for (int i = 0; i < elements.Length; i++)
                strQuery += $", '{elements[i].Key}' {elements[i].Value}";

            strQuery += ");";
            return strQuery;
        }

        public void Query(string strPath, string fileName, string strQuery)
        {
            try
            {
                //if (string.IsNullOrEmpty(m_strConnectPath)) return;

                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={strPath}\\{fileName}.sqlite;Version=3;"))
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                
                //CLogger.Add(LOG.DB, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                //CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }



        //Connect
        public void Connect(string strPath = "", string fileName = "")
        {
            try
            {
                m_strConnectPath = strPath;
                m_strDBFileName = fileName;

                //CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                //CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        //Disconnect


        //Select
        public List<string[]> Select(string strTable, string strWhereCol, string strWhereValue)
        {
            List<string[]> res = new List<string[]>();

            try
            {
                string strQuery = $"SELECT * FROM {strTable} WHERE {strWhereCol} = {strWhereValue}";

                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={Application.StartupPath}\\DB_ALARM.sqlite;Version=3;"))
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();

                    int nIndex = 1;

                    while (rdr.Read())
                    {

                        string time = rdr["time"].ToString().Replace("T", " ");
                        string model = rdr["model"].ToString();
                        string step = rdr["step"].ToString();
                        string ID_Code = rdr["ID_Code"].ToString();
                        string Result = rdr["Result"].ToString();
                        string ResultImgPath = rdr["ngimagepath"].ToString();

                        res.Add(new string[] { nIndex.ToString(), time, model, step, ID_Code, Result, ResultImgPath});
                        nIndex++;
                    }
                }
                return res;
            }
            catch (Exception e)
            {
                return res;
            }
        }

        public List<string[]> SelectAll(string path, string fileName, string strTable)
        {

            List<string[]> res = new List<string[]>();

            try
            {
                string strQuery = $"SELECT * FROM {strTable}";
                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={path}\\{fileName}.sqlite;Version=3;"))
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();

                    int nIndex = 1;

                    while (rdr.Read())
                    {

                        string time = rdr["time"].ToString().Replace("T", " ");
                        string model = rdr["model"].ToString();
                        string step = rdr["step"].ToString();
                        string ID_Code = rdr["ID_Code"].ToString();
                        string Result = rdr["Result"].ToString();
                        string ResultImgPath = rdr["ngimagepath"].ToString();

                        res.Add(new string[] { nIndex.ToString(), time, model, step, ID_Code, Result, ResultImgPath });
                        nIndex++;
                    }
                }

                return res;
            }
            catch
            {
                return res;
            }
        }

        public List<string[]> SelectDate(string path, string fileName, string strTable, string date = "")
        {
            List<string[]> res = new List<string[]>();
            try
            {
                string strQuery = $"SELECT * FROM {strTable}";

                if (!string.IsNullOrEmpty(date))
                {
                    if (!strQuery.Contains("WHERE")) strQuery += " WHERE ";
                    strQuery += $"time LIKE '%{date}%'";
                }

                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={path}\\{fileName}.sqlite;Version=3;"))
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();

                    int nIndex = 1;

                    while (rdr.Read())
                    {


                        string time = rdr["time"].ToString().Replace("T", " ");
                        string model = rdr["model"].ToString();
                        string step = rdr["step"].ToString();
                        string ID_Code = rdr["ID_Code"].ToString();
                        string Result = rdr["Result"].ToString();
                        string ResultImgPath = rdr["ResultImagePath"].ToString();

                        res.Add(new string[] { nIndex.ToString(), time, model, step, ID_Code, Result, ResultImgPath });
                        nIndex++;
                    }
                }



                return res;
            }
            catch
            {
                return res;
            }
            
        }

        public List<string[]> SelectID(string path, string fileName, string strTable, string Id = "")
        {
            List<string[]> res = new List<string[]>();
            try
            {
                string strQuery = $"SELECT * FROM {strTable}";

                if (!string.IsNullOrEmpty(Id))
                {
                    if (!strQuery.Contains("WHERE")) strQuery += " WHERE ";
                    strQuery += $"ID_Code = '{Id}'";
                }

                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={path}\\{fileName}.sqlite;Version=3;"))
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();

                    int nIndex = 1;

                    while (rdr.Read())
                    {

                        string time = rdr["time"].ToString().Replace("T", " ");
                        string model = rdr["model"].ToString();
                        string step = rdr["step"].ToString();
                        string ID_Code = rdr["ID_Code"].ToString();
                        string Result = rdr["Result"].ToString();
                        string ResultImgPath = rdr["ResultImagePath"].ToString();

                        res.Add(new string[] { nIndex.ToString(), time, model, step, ID_Code, Result, ResultImgPath });
                        nIndex++;
                    }
                }



                return res;
            }
            catch
            {
                return res;
            }
        }

        public List<string[]> SelectStep(string path, string fileName, string strTable, string strstep = "")
        {
            List<string[]> res = new List<string[]>();
            try
            {
                string strQuery = $"SELECT * FROM {strTable}";

                if (!string.IsNullOrEmpty(strstep))
                {
                    if (!strQuery.Contains("WHERE")) strQuery += " WHERE ";
                    strQuery += $"step = '{strstep}'";
                }

                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={path}\\{fileName}.sqlite;Version=3;"))
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();

                    int nIndex = 1;

                    while (rdr.Read())
                    {

                        string time = rdr["time"].ToString().Replace("T", " ");
                        string model = rdr["model"].ToString();
                        string step = rdr["step"].ToString();
                        string ID_Code = rdr["ID_Code"].ToString();
                        string Result = rdr["Result"].ToString();
                        string ResultImgPath = rdr["ResultImagePath"].ToString();

                        res.Add(new string[] { nIndex.ToString(), time, model, step, ID_Code, Result, ResultImgPath });
                        nIndex++;
                    }
                }



                return res;
            }
            catch
            {
                return res;
            }
        }

        public List<string[]> SelectResult(string path, string fileName, string strTable, string result = "")
        {
            List<string[]> res = new List<string[]>();
            try
            {
                string strQuery = $"SELECT * FROM {strTable}";

                if (!string.IsNullOrEmpty(result))
                {
                    if (!strQuery.Contains("WHERE")) strQuery += " WHERE ";
                    strQuery += $"Result = '{result}'";
                }

                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={path}\\{fileName}.sqlite;Version=3;"))
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();

                    int nIndex = 1;

                    while (rdr.Read())
                    {

                        string time = rdr["time"].ToString().Replace("T", " ");
                        string model = rdr["model"].ToString();
                        string step = rdr["step"].ToString();
                        string ID_Code = rdr["ID_Code"].ToString();
                        string Result = rdr["Result"].ToString();
                        string ResultImgPath = rdr["ResultImagePath"].ToString();

                        res.Add(new string[] { nIndex.ToString(), time, model, step, ID_Code, Result, ResultImgPath });
                        nIndex++;
                    }
                }



                return res;
            }
            catch
            {
                return res;
            }
        }

        public List<string[]> SelectWhereEngineNum(string path, string fileName, string strTable, string strStartTime, string strEndTime, string EngineNum)
        {
            List<string[]> res = new List<string[]>();
            try
            {
                string strQuery = $"SELECT * FROM {strTable} WHERE (Time BETWEEN '{strStartTime}' AND '{strEndTime}') AND Serial = '{EngineNum}' ORDER BY ROWID DESC LIMIT 1";
                //string strQuery = $"SELECT * FROM {strTable} WHERE (Time BETWEEN '{strStartTime}' AND '{strEndTime}) AND Serial = '{EngineNum}'";

                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={path};Version=3;"))
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();

                    int nIndex = 1;
                    while (rdr.Read())
                    {
                        string time = rdr["Time"].ToString().Replace("T", " ");
                        string model = rdr["Model"].ToString();
                        string serial = rdr["Serial"].ToString();
                        string totalres = rdr["TotalResult"].ToString();
                        string stepResult1 = rdr["StepResult1"].ToString();
                        string stepResultImgPath1 = rdr["StepResultImagePath1"].ToString();
                        string stepResult2 = rdr["StepResult2"].ToString();
                        string stepResultImgPath2 = rdr["StepResultImagePath2"].ToString();
                        string stepResult3 = rdr["StepResult3"].ToString();
                        string stepResultImgPath3 = rdr["StepResultImagePath3"].ToString();
                        string stepResult4 = rdr["StepResult4"].ToString();
                        string stepResultImgPath4 = rdr["StepResultImagePath4"].ToString();
                        string stepResult5 = rdr["StepResult5"].ToString();
                        string stepResultImgPath5 = rdr["StepResultImagePath5"].ToString();
                        string stepResult6 = rdr["StepResult6"].ToString();
                        string stepResultImgPath6 = rdr["StepResultImagePath6"].ToString();
                        string stepResult7 = rdr["StepResult7"].ToString();
                        string stepResultImgPath7 = rdr["StepResultImagePath7"].ToString();
                        string stepResult8 = rdr["StepResult8"].ToString();
                        string stepResultImgPath8 = rdr["StepResultImagePath8"].ToString();

                        res.Add(new string[] { nIndex.ToString(), time, model, serial, totalres, stepResult1, stepResultImgPath1, stepResult2, stepResultImgPath2, stepResult3, stepResultImgPath3,
                        stepResult4, stepResultImgPath4, stepResult5, stepResultImgPath5, stepResult6, stepResultImgPath6, stepResult7, stepResultImgPath7, stepResult8, stepResultImgPath8

                        });
                        nIndex++;
                    }
                }
                return res;
            }
            catch(Exception e)
            {
                return null;
            }

              
        }


        public List<string[]> SelectWhereDateTime(string path, string fileName, string strTable, string strStartTime, string strEndTime, string strResult = "ALL", string strLotID = "")
        {
            List<string[]> res = new List<string[]>();
            try
            {
                string strQuery = $"SELECT * FROM {strTable} WHERE Time BETWEEN '{strStartTime}' AND '{strEndTime}'";

                if (!String.Equals(strResult, "ALL", StringComparison.OrdinalIgnoreCase))
                {
                    strQuery += $" AND TotalResult = '{strResult}'";
                }

                if (!String.Equals(strLotID, "", StringComparison.OrdinalIgnoreCase))
                {
                    strQuery += $" AND Serial = '{strLotID}'";
                }

                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={path};Version=3;"))
                {
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(strQuery, conn);
                    cmd.ExecuteNonQuery();

                    SQLiteDataReader rdr = cmd.ExecuteReader();

                    int nIndex = 1;


                    while (rdr.Read())
                    {
                        string time = rdr["Time"].ToString().Replace("T", " ");
                        string model = rdr["Model"].ToString();
                        string serial = rdr["Serial"].ToString();
                        string totalres = rdr["TotalResult"].ToString();
                        string stepResult1 = rdr["StepResult1"].ToString();
                        string stepResultImgPath1 = rdr["StepResultImagePath1"].ToString();
                        string stepResult2 = rdr["StepResult2"].ToString();
                        string stepResultImgPath2 = rdr["StepResultImagePath2"].ToString();
                        string stepResult3 = rdr["StepResult3"].ToString();
                        string stepResultImgPath3 = rdr["StepResultImagePath3"].ToString();
                        string stepResult4 = rdr["StepResult4"].ToString();
                        string stepResultImgPath4 = rdr["StepResultImagePath4"].ToString();
                        string stepResult5 = rdr["StepResult5"].ToString();
                        string stepResultImgPath5 = rdr["StepResultImagePath5"].ToString();
                        string stepResult6 = rdr["StepResult6"].ToString();
                        string stepResultImgPath6 = rdr["StepResultImagePath6"].ToString();
                        string stepResult7 = rdr["StepResult7"].ToString();
                        string stepResultImgPath7 = rdr["StepResultImagePath7"].ToString();
                        string stepResult8 = rdr["StepResult8"].ToString();
                        string stepResultImgPath8 = rdr["StepResultImagePath8"].ToString();

                        res.Add(new string[] { nIndex.ToString(), time, model, serial, totalres, stepResult1, stepResultImgPath1, stepResult2, stepResultImgPath2, stepResult3, stepResultImgPath3,
                        stepResult4, stepResultImgPath4, stepResult5, stepResultImgPath5, stepResult6, stepResultImgPath6, stepResult7, stepResultImgPath7, stepResult8, stepResultImgPath8

                        });
                        nIndex++;


                    }

                    
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return res;
            }

            return res;
        }

        //Insert

        public void InsertResult(string path, string fileName, string table, string[] field, string[] values)
        {
            try
            {
                string strValue = "";
                string strField = "";

                for (int i = 0; i < field.Length; i++)
                {
                    if (i == field.Length - 1)
                    {
                        strField += field[i];
                    }
                    else
                    {
                        strField += field[i] + ",";
                    }
                }

                for (int i = 0; i < values.Length; i++)
                {
                    if (string.IsNullOrEmpty(values[i]) || string.IsNullOrWhiteSpace(values[i]))
                    {
                        values[i] = "NULL";
                    }

                    if (i == values.Length - 1)
                    {
                        strValue += values[i];
                    }
                    else
                    {
                        strValue += values[i] + ",";
                    }
                }

                string strQuery = $"INSERT INTO {table} ({strField}) VALUES ({strValue})";
                Query(path, fileName,strQuery);

                //CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                //CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        


        //Delete
        public void Delete(string path, string fileName, string strTable, string strWhereCol, string strWhereValue)
        {
            try
            {
                string strQuery = $"DELETE FROM {strTable} WHERE {strWhereCol}='{strWhereValue}'";
                Query(path, fileName, strQuery);

                //CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                //CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        public void DeleteAll(string path, string fileName, string strTable)
        {
            try
            {
                string strQuery = $"DELETE FROM {strTable}";
                Query(path, fileName, strQuery);

                //CLogger.Add(LOG.NORMAL, "[OK] {0}==>{1}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name);
            }
            catch (Exception ex)
            {
                //CLogger.Add(LOG.ABNORMAL, "[FAILED] {0}==>{1}   Execption ==> {2}", MethodBase.GetCurrentMethod().ReflectedType.Name, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

    }
}
