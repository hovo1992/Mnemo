using Facebook;
using System.Windows;
namespace MemoryGameProject
{
    /// <summary>
    /// Interaction logic for FbInfo.xaml
    /// </summary>
    public partial class FbInfo : Window
    {

        #region Fields

        Fb startPage;

        #endregion

        #region Constructors

        public FbInfo(FacebookClient FBClient, Fb page)
        {
            InitializeComponent();
            dynamic me = FBClient.Get("Me");
            //TBInfos.Text = " Name :  " + me.name + "\n\r" +
            //               " ID :  " + me.id + "\n\r";
            startPage = page;
            //ProfilePicture.Source = new BitmapImage(new Uri("https://graph.facebook.com/" + me.id.ToString() + "/picture/"));
        }

        #endregion

        #region Methods 

        public void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            startPage.DoLogOut();
        }

        #endregion

    }
}
