using System;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.XPath;

namespace MemoryGameProject
{
	public partial class Login : Window
	{
		#region Fields

		#endregion Fields

		#region Constructors

		public Login()
		{
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
			InitializeComponent();

			TextBoxEmail.Focus();
			ButtonPlay.IsEnabled = false;
			ButtonPlay.Opacity = .5;
		}

		#endregion Constructors

		#region Methods

		void ButtonSignIn_Click(object sender, RoutedEventArgs e)
		{
			#region Validation

			if (0 == TextBoxEmail.Text.Length)
			{
				ErrorMsg.Text = "Enter an email.";
				TextBoxEmail.Focus();
			}
			else if (0 == PasswordBox.Password.Length)
			{
				ErrorMsg.Text = "Enter a password.";
				PasswordBox.Focus();
			}
			else if (!IsValidMail(TextBoxEmail.Text))
			{
				ErrorMsg.Text = "Enter a valid email.";
				TextBoxEmail.Select(0, TextBoxEmail.Text.Length);
				TextBoxEmail.Focus();
			}
			else
			{
				if (VerifyAccount(TextBoxEmail.Text, PasswordBox.Password) != string.Empty)
				{
					string currentID = VerifyAccount(TextBoxEmail.Text, PasswordBox.Password);

					string userName = GetNameFromID(currentID);

					Game gameWnd = new Game(userName, currentID, false);

					gameWnd.Show();
					Hide();
				}
				else
				{
					ErrorMsg.Text = "Sorry! Please enter existing email and password.";
					TextBoxEmail.Focus();
				}
			}

			#endregion Validation
		}

		string GetNameFromID(string currentID)
		{
			XPathDocument xPathDoc = new XPathDocument("Users.xml");
			XPathNavigator xPathNavigator = xPathDoc.CreateNavigator();
			XPathNodeIterator xPathIterator = xPathNavigator.Select("Accounts/Account");

			foreach (XPathNavigator book in xPathIterator)
			{
				if (book.GetAttribute("ID", "") == currentID)
				{
					XPathNavigator nav = book.SelectSingleNode("FirstName");
					return nav.Value;
				}
			}

			return "Guest";
		}

		bool IsValidMail(string emailaddress)
		{
			try
			{
				MailAddress m = new MailAddress(emailaddress);

				return true;
			}
			catch (FormatException)
			{
				return false;
			}
		}

		string VerifyAccount(string email, string password)
		{
			XPathDocument xPathDoc = new XPathDocument("Users.xml");
			XPathNavigator xPathNavigator = xPathDoc.CreateNavigator();
			XPathNodeIterator xPathIterator = xPathNavigator.Select("Accounts/Account");

			foreach (XPathNavigator book in xPathIterator)
			{
				XPathNavigator nav = book.SelectSingleNode("Email");
				XPathNavigator nav2 = book.SelectSingleNode("Password");

				if (nav.InnerXml == email && nav2.InnerXml == Account.CalculateMD5Hash(password))
				{
					return book.GetAttribute("ID", "");
				}
			}

			return string.Empty;
		}

		bool CheckEmailAndPassword()
		{
			string email = TextBoxEmail.Text;
			string password = PasswordBox.Password;

			XPathDocument xPathDoc = new XPathDocument("Users.xml");
			XPathNavigator xPathNavigator = xPathDoc.CreateNavigator();
			XPathNodeIterator xPathIterator = xPathNavigator.Select("Accounts/Account");

			foreach (XPathNavigator book in xPathIterator)
			{
				XPathNavigator nav = book.SelectSingleNode("Email");
				XPathNavigator nav2 = book.SelectSingleNode("Password");

				if (nav.InnerXml == email && nav2.InnerXml == Account.CalculateMD5Hash(password))
				{
					return true;
				}
			}

			return false;
		}

		void PasswordBox_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				ButtonSignIn_Click(sender, e);
			}
		}

		void ButtonSignInWithFacebook_Click(object sender, RoutedEventArgs e)
		{
			Fb fbWnd = new Fb();

			Hide();
			fbWnd.Show();
		}

		void ButtonPlay_Click(object sender, RoutedEventArgs e)
		{
			Game gameWnd = new Game("Guest", string.Empty, false);
			
			Hide();
			gameWnd.Show();
		}

		void TextBoxEmail_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				PasswordBox.Focus();
			}
		}

		private void ButtonSignUp_Click(object sender, RoutedEventArgs e)
		{
			Registration registrationWnd = new Registration();

			Hide();
			registrationWnd.Show();
		}

		private void ButtonMultiplayer_Click(object sender, RoutedEventArgs e)
		{
            Game.isMultiPlayer = true;
			Multiplayer mp = new Multiplayer();

			Hide();
			mp.Show();
		}

        private void Email_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBoxEmail.Focus();
        }

        private void Password_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PasswordBox.Focus();
        }

        private void Login_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBoxEmail.Focus();
        }

        private void ImgPassword_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            PasswordBox.Focus();
        }

		#endregion Methods

		private void checkBox_Checked(object sender, RoutedEventArgs e)
		{
			ButtonPlay.IsEnabled = true;
			ButtonPlay.Opacity = 1;
		}

		private void checkBox_UnChecked(object sender, RoutedEventArgs e)
		{
			ButtonPlay.IsEnabled = false;
			ButtonPlay.Opacity = 0.5;
		}
	}
}