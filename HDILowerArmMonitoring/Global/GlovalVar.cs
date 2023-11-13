using HDILowerArmMonitoring;
using System.Collections.Generic;
using System.Windows.Forms;


public class GlovalVar
{
    // ini 파일 관련 변수.
    public string _strConfigPath = Application.StartupPath + "\\Config";
    public string _strLogPath = Application.StartupPath + "\\Log";
    public string _strImgPath = Application.StartupPath + "\\Image";
    public static string _strStaicImgPath = Application.StartupPath + "\\Image";
    public string _strCameraInfoPath = Application.StartupPath + "\\CameraInfo";
    public string _strCommInfoPath = Application.StartupPath + "\\Communication";
    public string _strMasterImagePath = Application.StartupPath + "\\MasterImage";
    public string _strModelPath = Application.StartupPath + "\\Model";
    public string _strRecipePath = Application.StartupPath + "\\RECIPE";
    public string _strLightPath = Application.StartupPath + "\\Light";

    //public string _strSqliteDbPath = Application.StartupPath + "\\DB";
    public string _strSqliteDbPath = "";
    public string _strSqliteDbfile = "HDI";

    public static string _strWorkspaceIniPath = Application.StartupPath + "\\vrws\\vrws.ini";
    public static string _strWorkspacePath;


    // 화면 해상도.
    public int _nWidth = 1282;
    public int _nHeight = 883;


    public int _nTotalCnt;
    public int _nOKCnt;
    public int _nNGCnt;


    public struct CamPram  //카메라 파라미터
    {
        public string strCamType;
        public string strCamSerial;
        public string strCamFormat;
        public string strIP;
        public double dExpose;
        public double dBright;
        public double dContract;
        public int nTimeout;
        public bool bTiime;
        public string strCopy;
        public long Width;
        public long Height;
        public double FPS;
        public long Gain;
        //public bool bConnect;
    }

    public enum MsgType             // Message 출력 구분.
    {
        Log,
        Alarm
    }

    public enum CamParamType
    {
        Exposure,
        Brightness,
        Constrast
    }

    public struct ModelParam            // 모델 파라미터
    {
        public int nGrabdelay;
        public double dExpose;
        public string strCode;
        public int nDefectCnt;
        public string strExposeInc;
    }

    public enum CameraInterface
    {
        Basler,
        HIK,
    }

    // PLC 파라미터 구조체.
    public struct PLCPrameter
    {
        public int nCommType;
        public string strPLCIP;
        public string strPLCPort;
        public string strPLCKind;
        public short shRack;
        public short shSlot;
        public string strHeartBeatAddr;
        public int nHearBeatInterval;
        public string strStartSignal;
        public string strOKSignal;
        public string strNGSignal;
        public int nReadInterval;
        public string strReadStartAddr;
        public string strReadLength;
        public string strReadStartTrigger;
        public string strReadEndTrigger;
        public string strReadModelStart;
        public string strReadModelEnd;
        public string strReadLotStart;
        public string strReadLotEnd;
        public string strReadCamPassStart;
        public string strReadCamPassEnd;

        public string strReadOperButtonStart;
        public string strReadOperButtonEnd;

        public string strWriteStartAddr;
        public string strWriteTriggerStart;
        public string strWriteModelStart;
        public string strWriteLotStart;
        public string strWriteResStart;
        public string strWriteTotalRes;
        public string strWrite2DRes;
        public string strWrite2DData;
        public string strWriteAlignX;
        public string strWriteAlignY;
        public string strWriteAlignZ;
        public string strWritePinChange;
        public bool bIndividualTrigger;
        public string strWriteCamPointRes;
        public int nDataFormat;
        public string strReadStepStartAddr;
        public string strReadStepEndAddr;
        public string strReadPlcHeartBitStartAddr;
        public string strReadPlcHeartBitEndAddr;
        public string strReadInitStartAddr;
        public string strReadInitEndAddr;
        public string strWriteInitComp;
        public string strWriteStepFeedBack;
        public string strWrite2stOK;
        public string strWrite2stNG;
        public string strWriteVisionReady;
        public string strWriteVisionError;
        public string strWrite1stComp;
        public string strWrite2stComp;
        public string strTriggerAck;
        public string strSendData;


    }

    public enum PLCType
    {
        //MITSUBITSH,
        //LS,
        Simens
    }

    public enum SettingScreen
    {
        Model,
        Communication,
        Camera,
        Light,
        ImageSearch,

    }

    public enum AdminMode
    {
        Model,
        Communication,
        Camera,
        Light,
        ProgramSetting,
        ImageSearch,
    }

    public struct GraphicVproParam
    {
        public string[] strName;
        public bool[] bUse;
        public int[] nColor;
        public int[] nLineThick;
    }

    public struct GraphicVIDIResParam
    {
        public int nAlign;
        public int nFontSize;
        public int nWidth;
        public int nHeight;
        public bool bCamUse;
        public int nFont;
        public int nPosY;
    }

    public struct GraphicVIDIParam
    {
        public string[] strName;
        public bool[] bUse;
        public int[] nColor;
        public int[] nLineThick;
    }

    public struct GraphicVproResParam
    {
        public int nAlign;
        public int nFontSize;
        public int nWidth;
        public int nHeight;
        public bool bCamUse;
        public int nFont;
        public int nPosY;
    }

    public enum GraphicAlign
    {
        Left,
        Center,
        Right
    }

    public enum GraphicColor
    {
        Green,
        Yellow,
        Blue,
        Cyan,
        Magenta,
        Red
    }

    public enum PositionType
    {
        Previous,
        Next
    }

    public struct LightParam
    {
        //public string ch;
        public string value;
        public bool ON;
    }

    

    // 모델 네임 변수.
    public int _iModelToltalCount = 0;
    public string _strModelNo = "";
    public int _iModelIndex;
    public string _strModelName = "";
    public string _strModelCode = "";
    public List<string> _listModel = new List<string>();
    public List<string> _listModelCode = new List<string>();

    public int _nScreenCnt = 1;
    //Step
    public static int MaxStep = 8;
    public static int MaxLightCount = 8;
    public static int MaxLightController = 2;
    public static int MaxCamCount = 2;

    public static bool _bPassmode;
    public static bool _bOriginImageSave;
    public static bool _bResultImageSave;
    public static bool _bBMPImageSave;
    public static bool _bJPGImageSave;
    public static bool _bOKImageSave;
    public static bool _bNGImageSave;

    public static bool _bAutoDeleteUse;
    public static string _strDrivePercent;
    public static bool _bAutoDeleteRunChk;

    public static string _strSerial;

    public static int _iCameraModel;

    public static string tmpSendEngineSerial = "";

    public static string strServerIP = "127.0.0.1";
    public static string strPort = "9000";


}



