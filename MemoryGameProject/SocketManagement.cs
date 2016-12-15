using System;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Windows;

namespace MemoryGameProject
{
	public class SocketManagement
	{
		private IPAddress _IP;
		private int _PORT;
		private TcpListener _TCP;
		private TcpClient _CLIENT;
		private NetworkStream _STREAM;
        

        public SocketManagement(string ip, int port)
		{
			_IP = IPAddress.Parse(ip);
			_PORT = port;
		}

		public bool StartAsServer()
		{
			try
			{
				_TCP = new TcpListener(_IP, _PORT);
				_TCP.Start();
				_CLIENT = GetTcpClient();
				_STREAM = _CLIENT.GetStream();
			}
			catch (Exception ex) { MessageBox.Show(ex.Message); return false; }

			return true;
		}

		public TcpClient GetTcpClient()
		{
			return _TCP.AcceptTcpClient();
		}

		public bool StartAsClient()
		{
			try
			{
				_CLIENT = new TcpClient();
				_CLIENT.Connect(_IP, _PORT);
				_STREAM = _CLIENT.GetStream();
			}
			catch (Exception ex) { MessageBox.Show(ex.Message); return false; }

			return true;
		}

		public bool sendBoard(byte[] temp)
		{
			try
			{
				//byte[] bytes = new byte[255];
				//bytes = new ASCIIEncoding().GetBytes(()temp);

				_STREAM.Write(temp, 0, temp.Length);

				//for (int i = 0; i < temp.Length; i++)
				//{
				//	temp[i] = (byte)temp[i];
				//}
			}
			catch (Exception ex) { MessageBox.Show(ex.Message); return false; }

			return true;
		}

		public CellButton[,] getBoard(Game game, CellButton[,] pBoxes, bool isServer)
		{
            byte[] bytes = new byte[255];
            _STREAM.Read(bytes, 0, bytes.Length);
            string temp = new ASCIIEncoding().GetString(bytes);
            char[] charOfTemp = temp.ToCharArray();
			game.chuzoxiMiavor = bytes[bytes.Length - (isServer ? 3 : 2)];
            return game.GetGridBoard(bytes, pBoxes);
		}

		public int GetChuzoxMiavor(bool isServer)
		{
			byte[] bytes = new byte[255];
			_STREAM.Read(bytes, 0, bytes.Length);
			return bytes[bytes.Length - (isServer ? 3 : 2)];
		}

        public byte[] readGameState()
        {
            byte[] bytes = new byte[255];

            try
            {
                _STREAM.Read(bytes, 0, bytes.Length);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return bytes;
        }
    }
}
