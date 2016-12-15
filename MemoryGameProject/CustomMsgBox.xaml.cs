using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows.Interop;

namespace MemoryGameProject
{
	public partial class CustomMsgBox : Window
	{
		#region Fields

		static CustomMsgBox msgBox;
		public static MessageBoxResult result = MessageBoxResult.No;
		public static BitmapSource bitmapSource;

		#endregion Fields

		#region Constructors

		public CustomMsgBox()
		{
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
			InitializeComponent();
		}

		#endregion Constructors

		#region Methods

		public static MessageBoxResult Show(int score, string caption, bool isFB)
		{
			msgBox = new CustomMsgBox();
			msgBox.LabelMsg.Content = Constants.MY_SCORE + score;

			if (!isFB)
			{
				msgBox.ButtonFb.Visibility = Visibility.Hidden;
			}

			msgBox.ShowDialog();

			return result;
		}

		public static MessageBoxResult Show(string gameResult)
		{
			msgBox = new CustomMsgBox();

			msgBox.LabelMsg.Content = gameResult;
			msgBox.ButtonFb.Visibility = Visibility.Hidden;
			msgBox.ShowDialog();

			return result;
		}

		void ButtonOK_Click(object sender, RoutedEventArgs e)
		{
			result = MessageBoxResult.OK;
			Hide();
		}

		void ButtonFb_Click(object sender, RoutedEventArgs e)
		{
			Hide();

			ChangeMessageBoxStyle();

			Thread image = new Thread(() =>
			{
				Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)delegate ()
				{
					PostOnFb postWnd = new PostOnFb();
					JpegBitmapEncoder bitMap = CreateBitmapFromVisual(Screen);
					bitmapSource = bitMap.Frames[0];
					postWnd.ImagePost.Source = bitmapSource;

					string s = System.Reflection.Assembly.GetEntryAssembly().Location;
					postWnd.TBoxPath.Text = s.Replace("MemoryGameProject.exe", "ScreenShot.jpg");
					postWnd.Show();
				});
			});

			image.Start();
		}

		public void ChangeMessageBoxStyle()
		{
			ImageBrush myBrush = new ImageBrush();
			Image image = new Image();

			image.Source = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.messageBg.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

			myBrush.ImageSource = image.Source;
			Screen.Background = myBrush;

			dynamic me = Fb.FBClient.Get("Me");

			ButtonFb.Visibility = ButtonOK.Visibility = Visibility.Hidden;
			fbProfilePicture.Source = new BitmapImage(new Uri("https://graph.facebook.com/" + me.id.ToString() + "/picture/"));
			fbName.Content = me.name;
		}

		public JpegBitmapEncoder CreateBitmapFromVisual(Visual target)
		{
			Rect bounds = VisualTreeHelper.GetDescendantBounds(target);
			RenderTargetBitmap renderTarget = new RenderTargetBitmap(
				(Int32)bounds.Width, (Int32)bounds.Height, 96, 96, PixelFormats.Pbgra32);

			DrawingVisual visual = new DrawingVisual();

			using (DrawingContext context = visual.RenderOpen())
			{
				VisualBrush visualBrush = new VisualBrush(target);
				context.DrawRectangle(visualBrush, null, new Rect(new Point(), bounds.Size));
			}

			renderTarget.Render(visual);
			JpegBitmapEncoder bitmapEncoder = new JpegBitmapEncoder();
			bitmapEncoder.Frames.Add(BitmapFrame.Create(renderTarget));

			using (Stream stm = File.Create("ScreenShot.jpg"))
			{
				bitmapEncoder.Save(stm);
			}

			return bitmapEncoder;
		}

		#endregion Methods
	}
}