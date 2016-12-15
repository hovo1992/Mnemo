using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.XPath;
using System.Drawing.Imaging;
using System.Drawing;
using System.Speech.Synthesis;
using System.Net.Mail;
using System.Windows.Input;

namespace MemoryGameProject
{
	public partial class Registration : Window
	{
		#region Fields

		string captchaRnd;
		Login loginWnd = new Login();

		#endregion Fields

		#region Constructors

		public Registration()
		{
			InitializeComponent();

			captchaRnd = RandomString(6);
			GetCaptcha(captchaRnd);

			TextBoxFirstName.Focus();
		}

		#endregion Constructors

		#region Methods

		private void GetCaptcha(string captchaRnd)
		{
			CaptchaText txt = new CaptchaText(captchaRnd, (int)Image.Width, (int)Image.Height);
			Bitmap bitmap = txt.Image;

			using (MemoryStream memory = new MemoryStream())
			{
				bitmap.Save(memory, ImageFormat.Png);
				memory.Position = 0;
				BitmapImage bitmapImage = new BitmapImage();
				bitmapImage.BeginInit();
				bitmapImage.StreamSource = memory;
				bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
				bitmapImage.EndInit();

				Image.Source = bitmapImage;
			}
		}

		void CreateErrorMsg(string msg, Control field)
		{
			ErrorMsg.Text = msg;

			field.Focus();

			captchaRnd = RandomString(6);
			GetCaptcha(captchaRnd);
		}

		void SubmitButton_Click(object sender, RoutedEventArgs e)
		{
			XmlNode rootNode;
			XPathDocument document;
			XmlDocument xmlDoc = new XmlDocument();
			Account user = new Account();

			if (TextBoxFirstName.Text.Length == 0)
			{
				CreateErrorMsg("Enter a FirstName.", TextBoxFirstName);

				errImg1.Opacity = 1;
			}
			else if (TextBoxFirstName.Text.Length < 2)
			{
				CreateErrorMsg("Please enter a correct FirstName.", TextBoxFirstName);

				errImg1.Opacity = 1;
			}
			else if (TextBoxLastName.Text.Length == 0)
			{
				CreateErrorMsg("Enter a LastName.", TextBoxLastName);

				if (true)
				{
					errImg1.Opacity = 0;
				}

				errImg2.Opacity = 1;
			}
			else if (TextBoxLastName.Text.Length < 2)
			{
				CreateErrorMsg("Please enter a correct LastName.", TextBoxLastName);

				errImg1.Opacity = 0;
				errImg2.Opacity = 1;
			}
			else if (TextBoxEmail.Text.Length == 0)
			{
				CreateErrorMsg("Enter an Email.", TextBoxEmail);

				errImg2.Opacity = 0;
				errImg3.Opacity = 1;
			}
			else if (!IsValidMail(TextBoxEmail.Text))
			{
				CreateErrorMsg("Enter a valid Email.", TextBoxEmail);

				errImg2.Opacity = 0;
				errImg3.Opacity = 1;
			}
			else if (PasswordBox.Password.Length == 0)
			{
				CreateErrorMsg("Enter Password.", PasswordBox);

				errImg3.Opacity = 0;
				errImg4.Opacity = 1;
			}
			else if (PasswordBox.Password.Length < 8)
			{
				CreateErrorMsg("Password is too short (must be at least 8 characters).", PasswordBox);

				errImg3.Opacity = 0;
				errImg4.Opacity = 1;
			}
			else if (PasswordBoxConfirm.Password.Length == 0)
			{
				CreateErrorMsg("Enter Confirm Password.", PasswordBox);

				errImg4.Opacity = 0;
				errImg5.Opacity = 1;
			}
			else if (PasswordBox.Password != PasswordBoxConfirm.Password)
			{
				CreateErrorMsg("Confirm Password must be same as password.", PasswordBoxConfirm);

				errImg4.Opacity = 0;
				errImg5.Opacity = 1;
			}
			else if (TextBoxCaptcha.Text != captchaRnd)
			{
				CreateErrorMsg("Please enter the correct captcha phrase.", TextBoxCaptcha);

				errImg5.Opacity = 0;
			}
			else if (CheckAccount(TextBoxEmail.Text))
			{
				CreateErrorMsg("Email address you entered is already in use.", TextBoxEmail);
			}
			else
			{
				user = new Account
				{
					FirstName = TextBoxFirstName.Text,
					LastName = TextBoxLastName.Text,
					Email = TextBoxEmail.Text,
					Password = PasswordBox.Password
				};

				try
				{
					document = new XPathDocument("Users.xml");
				}
				catch (Exception)
				{
					xmlDoc.RemoveAll();
					XmlNode docNode = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
					xmlDoc.AppendChild(docNode);
					rootNode = xmlDoc.CreateElement("Accounts");
					xmlDoc.AppendChild(rootNode);
					xmlDoc.Save("Users.xml");
				}

				document = new XPathDocument("Users.xml");
				xmlDoc.Load("Users.xml");

				XPathNavigator navigator = document.CreateNavigator();
				navigator = xmlDoc.CreateNavigator();
				navigator.MoveToChild("Accounts", "");
				navigator.AppendChild(user.TagsForFields(xmlDoc));

				xmlDoc.Save("Users.xml");

				ErrorMsg.Text = string.Empty;
				MessageBox.Show("You have successfully registered");
				errImg1.Opacity = 0;
				errImg2.Opacity = 0;
				errImg3.Opacity = 0;
				errImg4.Opacity = 0;
				errImg5.Opacity = 0;
				Game game = new Game(user.FirstName, Account.RegistrID, false);

				Hide();
				game.Show();
			}
		}

		private void textBox_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (e.Command == ApplicationCommands.Copy ||
				e.Command == ApplicationCommands.Cut ||
				e.Command == ApplicationCommands.Paste)
			{
				e.Handled = true;
			}
		}

		void ResetButton_Click(object sender, RoutedEventArgs e)
		{
			TextBoxFirstName.Text = string.Empty;
			TextBoxLastName.Text = string.Empty;
			TextBoxEmail.Text = string.Empty;
			PasswordBox.Password = string.Empty;
			PasswordBoxConfirm.Password = string.Empty;
            errImg1.Opacity = 0;
            errImg2.Opacity = 0;
            errImg3.Opacity = 0;
            errImg4.Opacity = 0;
            errImg5.Opacity = 0;
        }

		void Login_Click(object sender, RoutedEventArgs e)
		{
			Hide();
			loginWnd.Show();
		}

		static string RandomString(int length)
		{
			Random random = new Random();
			const string chars = "BCDFGHJKLMNPQRSTVWXYZ0123456789";

			return new string(Enumerable.Repeat(chars, length)
			  .Select(s => s[random.Next(s.Length)]).ToArray());
		}

		void ButtonVoice_Clicked(object sender, RoutedEventArgs e)
		{
			Button btnVoice = (Button)sender;

			SpellText(
				started: (object synthesizer, SpeakStartedEventArgs evt) =>
				 {
					 btnVoice.IsEnabled = false;
				 },
				completed: (object synthesizer, SpeakCompletedEventArgs evt) =>
			   {
				   btnVoice.IsEnabled = true;
			   });
		}

		void SpellText(EventHandler<SpeakStartedEventArgs> started = null, EventHandler<SpeakCompletedEventArgs> completed = null)
		{
			SpeechSynthesizer synthesizer = new SpeechSynthesizer { Rate = -4 };

			if (started != null)
			{
				synthesizer.SpeakStarted += started;
			}
			if (completed != null)
			{
				synthesizer.SpeakCompleted += completed;
			}

			synthesizer.SetOutputToDefaultAudioDevice();
			synthesizer.SpeakAsync(captchaRnd);
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

		private void ButtonAgain_Clicked(object sender, RoutedEventArgs e)
		{
			captchaRnd = RandomString(6);

			GetCaptcha(captchaRnd);
		}

		bool CheckAccount(string email)
		{
			XPathDocument xPathDoc = new XPathDocument("Users.xml");
			XPathNavigator xPathNavigator = xPathDoc.CreateNavigator();
			XPathNodeIterator xPathIterator = xPathNavigator.Select("Accounts/Account");

			foreach (XPathNavigator book in xPathIterator)
			{
				XPathNavigator nav = book.SelectSingleNode("Email");

				if (nav.Value == email)
				{
					return true;
				}
			}

			return false;
		}

		private void TextBoxCaptcha_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				SubmitButton_Click(sender, e);
			}
		}

		private void FirstName_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				TextBoxLastName.Focus();
			}
		}

		private void LastName_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				TextBoxEmail.Focus();
			}
		}

		private void Email_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				PasswordBox.Focus();
			}
		}

		private void Password_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				PasswordBoxConfirm.Focus();
			}
		}

		private void ConfPsw_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				TextBoxCaptcha.Focus();
			}
		}

		#endregion Methods
	}
}
