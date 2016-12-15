using Facebook;
using System;
using System.Dynamic;
using System.Windows;
using System.Windows.Navigation;

namespace MemoryGameProject
{
	public partial class Fb : Window
	{
		#region Fields

		string _accessToken;
		bool mustLogout = false;
		public static FacebookClient FBClient;
		public static string AccessToken { get; set; }
		string redirect_url = "http://www.facebook.com/connect/login_success.html";

		#endregion 

		#region Constructors

		public Fb()
		{
			InitializeComponent();

			string loginUrl = GenerateLoginUrl();
			WBrowser.Navigate(loginUrl);

		}
		
		#endregion Constructors

		#region Methods

		private string GenerateLoginUrl()
		{
			dynamic parameters = new ExpandoObject();

			parameters.client_id = Constants.APP_ID;
			parameters.redirect_uri = "https://www.facebook.com/connect/login_success.html";
			parameters.response_type = "token";
			parameters.display = "popup";

			if (!string.IsNullOrWhiteSpace(Constants.EXTENDEDPERMISSIONSNEEDED))
			{
				parameters.scope = Constants.EXTENDEDPERMISSIONSNEEDED;
			}

			var fb = new FacebookClient();
			Uri loginUri = fb.GetLoginUrl(parameters);

			return loginUri.AbsoluteUri;
		}

		public void DoLogOut()
		{
			var logoutUrl = (new FacebookClient(AccessToken)).GetLogoutUrl(
				new { access_token = AccessToken, next = "https://www.facebook.com/connect/login_success.html" });
			WBrowser.Navigate(logoutUrl);

			(new Fb() { mustLogout = true }).Hide();
		}

		private void LoginWebBrowserNavigated(object sender, NavigationEventArgs e)
		{
			if (WBrowser.IsVisible)
			{
				var fb = new FacebookClient();
				FacebookOAuthResult oauthResult;

				if (fb.TryParseOAuthCallbackUrl(e.Uri, out oauthResult))
				{
					if (oauthResult.IsSuccess)
					{
						AccessToken = e.Uri.Fragment.Split('&')[0].Replace("#access_token=", "");
						FBClient = new FacebookClient(AccessToken);
						dynamic me = FBClient.Get("Me");

						Game gameWnd;

						_accessToken = oauthResult.AccessToken;

						fb = new FacebookClient(_accessToken);
						gameWnd = new Game(me.name, me.id, true);

						gameWnd.Show();
						Hide();

						if (mustLogout)
						{
							gameWnd.ButtonLogOut_Click(null, null);
						}
					}
					else
					{
						Login login = new Login();
						
						Hide();
						login.Show();
					}
				}
			}
			mustLogout = false;
		}

		private void WBrowser_OnNavigated(object sender, NavigationEventArgs e)
		{
			if (e.Uri.ToString().StartsWith(redirect_url))
			{
				var fb = new FacebookClient();
				FacebookOAuthResult oauthResult;

				if (fb.TryParseOAuthCallbackUrl(e.Uri, out oauthResult))
				{
					if (oauthResult.IsSuccess)
					{
						string accesstoken = oauthResult.AccessToken;
					}
					else
					{
						string errorDescription = oauthResult.ErrorDescription;
						string errorReason = oauthResult.ErrorReason;
					}
				}

				Hide();
			}
		}

		#endregion
	}
}
