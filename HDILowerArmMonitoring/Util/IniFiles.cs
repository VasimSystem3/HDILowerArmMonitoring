using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;
public class IniFiles
{
    [DllImport("kernel32")]
    public static extern long WritePrivateProfileString(string section, string key, string val, string filePath); // ini 파일 쓰기.

    // ini 파일 읽기
    [DllImport("kernel32")]
    public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath); // ini 파일 읽기

    [DllImport("kernel32")]
    static extern int GetPrivateProfileString(string Section, int Key,
               string Value, [MarshalAs(UnmanagedType.LPArray)] byte[] Result,
               int Size, string FileName);

    [DllImport("kernel32")]
    static extern int GetPrivateProfileString(int Section, string Key,
              string Value, [MarshalAs(UnmanagedType.LPArray)] byte[] Result,
              int Size, string FileName);

    public void WriteIniFile(string strSection, string strKey, string strvalue, string strPath, string strFileName)
    {
        //DirectoryInfo dr = new DirectoryInfo(strPath);
        //if (!dr.Exists)
        //{
        //    dr.Create();
        //}
            

        WritePrivateProfileString(strSection, strKey, strvalue, strPath + "\\" + strFileName);
    }

    public string ReadIniFile(string strSection, string strKey, string strPath, string strFileName)
    {
        StringBuilder sb = new StringBuilder(255);
        GetPrivateProfileString(strSection, strKey, "", sb, sb.Capacity, strPath + "\\" + strFileName);

        return sb.ToString();
    }

    public string[] GetSectionNames(string path)  // ini 파일 안의 모든 section 이름 가져오기
    {
        for (int maxsize = 500; true; maxsize *= 2)
        {
            byte[] bytes = new byte[maxsize];
            int size = GetPrivateProfileString(0, "", "", bytes, maxsize, path);


            if (size < maxsize - 2)
            {
                string Selected = Encoding.ASCII.GetString(bytes, 0, size - (size > 0 ? 1 : 0));
                return Selected.Split(new char[] { '\0' });
            }
        }
    }



    public string[] GetEntryNames(string section, string path)   // 해당 section 안의 모든 키 값 가져오기
    {
        for (int maxsize = 500; true; maxsize *= 2)
        {
            byte[] bytes = new byte[maxsize];
            int size = GetPrivateProfileString(section, 0, "", bytes, maxsize, path);

            if (size < maxsize - 2)
            {
                string entries = Encoding.ASCII.GetString(bytes, 0, size - (size > 0 ? 1 : 0));
                return entries.Split(new char[] { '\0' });
            }
        }
    }


}
