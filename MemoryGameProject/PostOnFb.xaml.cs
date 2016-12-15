using Facebook;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace MemoryGameProject
{
	public partial class PostOnFb : Window
    {
		#region Fields
		#endregion Fields

		#region Constructors

		public PostOnFb()
		{
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
			InitializeComponent();
		}

		#endregion Constructors

		#region Methods

		void ButtonPost_Click(object sender, RoutedEventArgs e)
        {
            dynamic me = Fb.FBClient.Get("me");

            FacebookMediaObject mediaUploader = new FacebookMediaObject
            {
                FileName = "ScreenShot.jpg",
                ContentType = "image/jpg"
            };

            byte[] bytes = File.ReadAllBytes("ScreenShot.jpg");

            mediaUploader.SetValue(bytes);
            var postInfo = new Dictionary<string, object>();

            postInfo.Add("message", TBoxStatus.Text);
            postInfo.Add("image", mediaUploader);

            PostOnFb postWnd = new PostOnFb();

            Fb.FBClient.Post(me.id + "/photos", postInfo);

            MessageBox.Show("Posted");
            Hide();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

		#endregion Methods
	}
}
