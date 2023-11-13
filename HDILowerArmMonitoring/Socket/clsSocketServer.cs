using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace HDILowerArmMonitoring
{

    public class ClsSocketServer
    {

        public class AsyncObject
        {
            public Byte[] Buffer;
            public Socket WorkingSocket;
            public AsyncObject(Int32 bufferSize)
            {
                this.Buffer = new Byte[bufferSize];
            }
        }

        public delegate void DataReceivedHandlerFunc(string strRead);
        public delegate void ClientConnectHandler();
        public delegate void ClientDisConnectHandler();
        public DataReceivedHandlerFunc DataReceivedHandler;
        public ClientConnectHandler OnClientConnect;
        public ClientDisConnectHandler OnClientDisConnect;

        private Socket m_ConnectedClient = null;
        private Socket m_ServerSocket = null;
        private AsyncCallback m_fnReceiveHandler;
        private AsyncCallback m_fnSendHandler;
        private AsyncCallback m_fnAcceptHandler;

        public List<Socket> lst_Client = new List<Socket>();


        public IPHostEntry ip_HostInfo = null;
        public IPEndPoint ip_Point = null;
        public IPAddress ip_Address = null;

        int defaultport = 9000;

        bool m_bConn = false;
        bool _IsOpen = false;


        public ClsSocketServer()
        {
            m_fnReceiveHandler = new AsyncCallback(handleDataReceive);
            m_fnSendHandler = new AsyncCallback(handleDataSend);
            m_fnAcceptHandler = new AsyncCallback(handleClientConnectionRequest);
        }

        public bool isOpen
        {
            get { return _IsOpen; }
        }
        public bool OpenServer(string ip, int port)
        {
            try
            {
                string host = Dns.GetHostName();

                //ip_HostInfo = Dns.GetHostEntry(host);
                //ip_Address = ip_HostInfo.AddressList[5];
                ip_Address = IPAddress.Parse(ip);
                ip_Point = new IPEndPoint(ip_Address, port);

                
                m_ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

                
                m_ServerSocket.Bind(ip_Point);

                
                m_ServerSocket.Listen(5);

                //BeginAccept 메서드를 이용해 들어오는 연결 요청을 비동기적으로 처리합니다.
                //연결 요청을 처리하는 함수는 handleClientConnectionRequest 입니다.
                m_ServerSocket.BeginAccept(m_fnAcceptHandler, null);

                _IsOpen = true;
                
            }
            catch
            {
                return false;
            }
            return _IsOpen;
        }


        

        public void CloseServer()
        {
           
            try
            {
                
                m_ServerSocket.Close();
            }
            catch
            {
                
            }
            
        }

        public int SendMessage(String message)
        {
            //추가 정보를 넘기기 위한 변수 선언
            // 크기를 설정하는게 의미가 없습니다.
            // 왜냐하면 바로 밑의 코드에서 문자열을 유니코드 형으로 변환한 바이트 배열을 반환하기 때문에
            // 최소한의 크기르 배열을 초기화합니다.

            if (!m_bConn)
                return -1;

            int nResult = 0;
            AsyncObject ao = new AsyncObject(1);

            //문자열을 바이트 배열으로 변환
            ao.Buffer = Encoding.Default.GetBytes(message);
            ao.WorkingSocket = m_ConnectedClient;

            // 전송 시작!
            try
            {
                m_ConnectedClient.BeginSend(ao.Buffer, 0, ao.Buffer.Length, SocketFlags.None, m_fnSendHandler, ao);

                //for (int i = connectedClients.Count - 1; i >= 0; i--)
                //{
                //    Socket socket = connectedClients[i];
                //    try { socket.Send(ao.Buffer); }
                //    catch
                //    {
                //        // 오류 발생하면 전송 취소하고 리스트에서 삭제한다.
                //        try { socket.Dispose(); } catch { return -1; }
                //        connectedClients.RemoveAt(i);
                //    }
                //}
            }
            catch
            {
                //Console.WriteLine("전송 중 오류 발생!\n메세지: {0}", ex.Message);
                //StopServer();
                //StartServer(5001);

                //if (DataReceivedHandler != null)
                //    DataReceivedHandler("Client Disconnected");

                return -1;

            }
            return nResult;
        }

        public int SendBytes(byte[] bytes)
        {
            //추가 정보를 넘기기 위한 변수 선언
            // 크기를 설정하는게 의미가 없습니다.
            // 왜냐하면 바로 밑의 코드에서 문자열을 유니코드 형으로 변환한 바이트 배열을 반환하기 때문에
            // 최소한의 크기르 배열을 초기화합니다.

            if (!m_bConn)
                return -1;

            int nResult = 0;
            AsyncObject ao = new AsyncObject(1);

            //문자열을 바이트 배열으로 변환
            ao.Buffer = bytes;
            ao.WorkingSocket = m_ConnectedClient;

            // 전송 시작!
            try
            {
                m_ConnectedClient.BeginSend(ao.Buffer, 0, ao.Buffer.Length, SocketFlags.None, m_fnSendHandler, ao);

                //for (int i = connectedClients.Count - 1; i >= 0; i--)
                //{
                //    Socket socket = connectedClients[i];
                //    try { socket.Send(ao.Buffer); }
                //    catch
                //    {
                //        // 오류 발생하면 전송 취소하고 리스트에서 삭제한다.
                //        try { socket.Dispose(); } catch { return -1; }
                //        connectedClients.RemoveAt(i);
                //    }
                //}
            }
            catch
            {
                //Console.WriteLine("전송 중 오류 발생!\n메세지: {0}", ex.Message);
                //StopServer();
                //StartServer(5001);

                //if (DataReceivedHandler != null)
                //    DataReceivedHandler("Client Disconnected");

                return -1;

            }
            return nResult;
        }

        private void handleClientConnectionRequest(IAsyncResult ar)
        {
            Socket sockClient;
            try
            {
                //클라이언트의 연결 요청을 수락합니다.
                sockClient = m_ServerSocket.EndAccept(ar);

                ip_Point = (IPEndPoint)sockClient.RemoteEndPoint;

                if (OnClientConnect != null)
                    OnClientConnect();

                m_ServerSocket.BeginAccept(m_fnAcceptHandler, null);

                m_bConn = true;
            }
            catch
            {
                //if (DataReceivedHandler != null)
                //    DataReceivedHandler(string.Format("연결 수락 도중 오류 발생! 메세지"));
                // Console.WriteLine("연결 수락 도중 오류 발생! 메세지: {0}", ex.Message);
                return;
            }

            //4096 바이트의 크기를 갖는 바이트 배열을 가진 AsyncObject 클래스 생성
            //AsyncObject ao = new AsyncObject(4096);
            AsyncObject ao = new AsyncObject(5242880);

            //작업 중인 소켓을 저장하기 위해 sockClient 할당
            ao.WorkingSocket = sockClient;

            lst_Client.Add(sockClient);

            // 클라이언트 소켓 저장
            m_ConnectedClient = sockClient;

            try
            {
                //비동기적으로 들어오는 자료를 수신하기 위해 BeginReceive 메서드 사용!
                sockClient.BeginReceive(ao.Buffer, 0, ao.Buffer.Length, SocketFlags.None, m_fnReceiveHandler, ao);
            }
            catch
            {
                //예외가 발생하면 예외 정보 출력 후 함수를 종료한다.
                //Console.WriteLine("자료 수신 대기 도중 오류 발생! 메세지: {0}", ex.Message);
                return;
            }
        }
        private void handleDataReceive(IAsyncResult ar)
        {

            //넘겨진 추가 정보를 가져옵니다.
            //AsyncState 속성의 자료형은 Object 형식이기 때문에 형 변환이 필요합니다~!
            AsyncObject ao = (AsyncObject)ar.AsyncState;

            //받은 바이트 수 저장할 변수 선언
            Int32 recvBytes = -1;

            try
            {
                //자료를 수신하고, 수신받은 바이트를 가져옵니다.
                recvBytes = ao.WorkingSocket.EndReceive(ar);
                //if (recvBytes == 0)
                //{
                //    
                //}
            }
            catch
            {
                if (m_bConn)
                {
                    m_bConn = false;

                    if (OnClientDisConnect != null)
                        OnClientDisConnect();

                    //if (DataReceivedHandler != null)
                    //    DataReceivedHandler("Client Disconnected");
                }

                return;
            }


            //수신받은 자료의 크기가 1 이상일 때에만 자료 처리
            if (recvBytes > 0)
            {
                //공백 문자들이 많이 발생할 수 있으므로, 받은 바이트 수 만큼 배열을 선언하고 복사한다.
                Byte[] msgByte = new Byte[recvBytes];
                Array.Copy(ao.Buffer, msgByte, recvBytes);

                if (DataReceivedHandler != null)
                    DataReceivedHandler(Encoding.Default.GetString(msgByte));

                Array.Clear(ao.Buffer, 0, ao.Buffer.Length);

                //받은 메세지를 출력
                //Console.WriteLine("메세지 받음: {0}", Encoding.Unicode.GetString(msgByte));
            }

            try
            {
                //비동기적으로 들어오는 자료를 수신하기 위해 BeginReceive 메서드 사용!

                ao.WorkingSocket.BeginReceive(ao.Buffer, 0, ao.Buffer.Length, SocketFlags.None, m_fnReceiveHandler, ao);
            }
            catch
            {
                //예외가 발생하면 예외 정보 출력 후 함수를 종료한다.
                //Console.WriteLine("자료 수신 대기 도중 오류 발생! 메세지: {0}", ex.Message);
                return;
            }
        }
        private void handleDataSend(IAsyncResult ar)
        {

            //넘겨진 추가 정보를 가져옵니다.
            AsyncObject ao = (AsyncObject)ar.AsyncState;

            //보낸 바이트 수를 저장할 변수 선언
            Int32 sentBytes;

            try
            {
                //자료를 전송하고, 전송한 바이트를 가져옵니다.
                sentBytes = ao.WorkingSocket.EndSend(ar);
            }
            catch
            {
                //예외가 발생하면 예외 정보 출력 후 함수를 종료한다.
                //Console.WriteLine("자료 송신 도중 오류 발생! 메세지: {0}", ex.Message);
                return;
            }

            if (sentBytes > 0)
            {
                //여기도 마찬가지로 보낸 바이트 수 만큼 배열 선언 후 복사한다.
                Byte[] msgByte = new Byte[sentBytes];
                Array.Copy(ao.Buffer, msgByte, sentBytes);

                //Console.WriteLine("메세지 보냄: {0}", Encoding.Unicode.GetString(msgByte));
            }
        }
        private void ChkClient()
        {
            byte[] buf = new byte[1024];

            //while (m_bThread)
            //{

            //    Thread.Sleep(1000);
            //}
        }

        private int ChkMsg(Byte[] message)
        {
            int nResult = 0;
            AsyncObject ao = new AsyncObject(1);

            //문자열을 바이트 배열으로 변환
            ao.Buffer = message;
            //ao.Buffer = Encoding.UTF8.GetBytes(message);
            ao.WorkingSocket = m_ConnectedClient;

            //전송 시작!
            try
            {
                m_ConnectedClient.BeginSend(ao.Buffer, 0, ao.Buffer.Length, SocketFlags.None, m_fnSendHandler, ao);
            }
            catch
            {
                //Console.WriteLine("전송 중 오류 발생!\n메세지: {0}", ex.Message);
                //m_ServerSocket = null;
                //sockClient = null;

                //if (DataReceivedHandler != null)
                //    DataReceivedHandler("Client Disconnected");

                return -1;

            }
            return nResult;
        }


    }
    
    
}
