using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace MemoryGameProject
{
	public partial class Multiplayer : Window
	{
		#region Fields

		bool isServer = false;
		public static string IP;
		private SocketManagement con;
		Login newLogin = new Login();

		#endregion Fields

		#region Constructors

		public Multiplayer()
		{
            InitializeComponent();

            IpBox.Focus();
        }

		#endregion Constructors

		#region Methods

		private bool checkIPandPort(string ip, string port)
		{
			if (Regex.IsMatch(ip, @"^[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}$") && Regex.IsMatch(port, "^[0-9]{1,6}$"))
			{
				string[] temp = ip.Split('.');

				foreach (string q in temp)
				{
					try
					{
						if (int.Parse(q) > 255) return false;
					}
					catch (Exception) { return false; }
				}

				return true;
			}

			return false;
		}

		private void ConnectAsServer(string ip, int port)
		{
			con = new SocketManagement(ip, port);

			if (con.StartAsServer())
			{
				GameStart();
			}
		}

		private void ConnectAsClient(string ip, int port)
		{
			con = new SocketManagement(ip, port);

			if (con.StartAsClient())
			{
				GameStart();
			}
		}

		private void GameStart()
		{
			Hide();

			new Game(this, isServer, con).Show();
		}

		private void StartAsServerBtn_Click(object sender, RoutedEventArgs e)
		{
			DisableAll();

			if (checkIPandPort(IpBox.Text, PortBox.Text))
			{
				isServer = true;
				//ChatWindow.isChatServer = true;
				ConnectAsServer(IpBox.Text, int.Parse(PortBox.Text));
			}
			else
			{
				EnableAll();
			}
		}

		private void StartAsClientBtn_Click(object sender, RoutedEventArgs e)
		{
			//ChatWindow.connectIP = IpBox.Text;
			DisableAll();

			if (checkIPandPort(IpBox.Text, PortBox.Text))
			{
				ConnectAsClient(IpBox.Text, int.Parse(PortBox.Text));
			}
			else
			{
				EnableAll();
			}
		}

		private void EnableAll()
		{
			IpBox.IsEnabled = true;
			PortBox.IsEnabled = true;

			StartAsClientBtn.IsEnabled = true;
			StartAsServerBtn.IsEnabled = true;
		}

		private void DisableAll()
		{
			IpBox.IsEnabled = false;
			PortBox.IsEnabled = false;
			StartAsClientBtn.IsEnabled = false;
			StartAsServerBtn.IsEnabled = false;
		}

		private void CloseBtn_Click(object sender, RoutedEventArgs e)
		{
			Environment.Exit(0);
		}

        private void BackTo(object sender, RoutedEventArgs e)
        {
            Hide();
            newLogin.Show();
        }

		#endregion Methods
	}
}
