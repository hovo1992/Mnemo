using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xml;
using System.Xml.XPath;

using static MemoryGameProject.Constants;


namespace MemoryGameProject
{
    public partial class Game : Window
    {
        #region Fields

        bool FbUser;
        public int IP;
        string userID;
        string firstName;
        int count, score;
        CellButton first;
        bool isServer;
        SocketManagement con;
        bool isMyTurn = false;
        bool isWinner = false;
        byte[] gameStateBuffer;
        public static int Size;
        bool isFinished = false;
        public int chuzoxiMiavor;
        Random rnd = new Random();
        CellButton[,] pictureBoxes;
        byte[] temp = new byte[255];
        bool isOpenPictures = false;
        public static bool isMultiPlayer;
        GameState gameState = GameState.First;
        List<ListPoint> pointList = new List<ListPoint>();
        DispatcherTimer controlTimer = new DispatcherTimer();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        readonly TimeSpan hundredSeconds = TimeSpan.FromMilliseconds(100);
        static Dictionary<Pictures, BitmapImage> imageDictionary = new Dictionary<Pictures, BitmapImage>();

        #endregion Fields

        #region Constructors

        public Game(Multiplayer owner, bool isServer, SocketManagement con)
        {
            //ChatWindow cw = new ChatWindow();
            //cw.Show();

            //Left = ChatWindow.leftPadding + Consts.CHAT_WIDTH;
            //Top = ChatWindow.topPadding;

            this.isMyTurn = isServer;
            this.Owner = owner;
            this.isServer = isServer;


            AddInDictionary();
            InitializeComponent();


            ButtonHint.IsEnabled = false;
            hintChange.Source = new BitmapImage(new Uri(@"Images/hint2.png", UriKind.Relative));

            this.con = con;


            if (!isServer)
            {
                Image_Turn.Source = new BitmapImage(new Uri(@"Images/green_turn.png", UriKind.Relative));
                hintChange.Source = new BitmapImage(new Uri(@"Images/hint2.png", UriKind.Relative));

                TextSize.Visibility = Visibility.Hidden;
                ButtonPlay.Visibility = Visibility.Hidden;  //by Ann
                isMyTurn = false;


            }
            else
            {
                isMyTurn = true;
            }

            //by Ann
            gameStateBuffer = new byte[255];

            if (!isServer)
            {
                Image_Turn.Source = new BitmapImage(new Uri(@"Images/red_turn.png", UriKind.Relative));
                ButtonHint.IsEnabled = false;
                hintChange.Source = new BitmapImage(new Uri(@"Images/hint1.png", UriKind.Relative));

                controlTimer.Interval = new TimeSpan(0, 0, 2);
                controlTimer.Tick += CheckGameMode;
                controlTimer.Start();
            }
            else
            {
                Image_Turn.Source = new BitmapImage(new Uri(@"Images/green_turn.png", UriKind.Relative));
                hintChange.Source = new BitmapImage(new Uri(@"Images/hint2.png", UriKind.Relative));

                ButtonHint.IsEnabled = true;
            }
        }

        public Game(string userName, string currentID, bool isFb)
        {
            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            AddInDictionary();
            InitializeComponent();

            firstName = userName;
            userID = currentID;
            FbUser = isFb;
            LabelScore.Content = "Score: ";

            ButtonHint.IsEnabled = false;
            hintChange.Source = new BitmapImage(new Uri(@"Images/hint1.png", UriKind.Relative));

            LabelUser.Content = string.Format("Hi  {0}", userName);
            TextSize.Focus();

            if (isFb)
            {
                CreateFbUser();

                string bestScore = GetScoreFromFbId(currentID);
                LabelBestScore.Content = string.Format("Your Best Score: {0}", bestScore);
            }
            else if (currentID != string.Empty)
            {
                ButtonLogOut.Visibility = Visibility.Visible;

                string bestScore = GetScoreFromId(currentID);
                LabelBestScore.Content = string.Format("Your Best Score: {0}", bestScore);
            }
            else
            {
                ButtonLogOut.Visibility = Visibility.Hidden;
            }

            uiScaleSlider.MouseDoubleClick += RestoreScalingFactor;
        }

        #endregion Constructors

        #region Methods

        void CheckGameMode(object sender, EventArgs e)
        {
            byte[] gameState = con.readGameState();

            if (!ValueEquals(gameState, gameStateBuffer))
            {
                Play(gameState[gameState.Length - 1]);
                GetDataFromOthers();
                GetGridBoard(gameState, pictureBoxes);

                isMyTurn = false;
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)delegate ()
                {
                    Image_Turn.Source = new BitmapImage(new Uri(@"Images/red_turn.png", UriKind.Relative));
                    hintChange.Source = new BitmapImage(new Uri(@"Images/hint1.png", UriKind.Relative));

                    ButtonHint.IsEnabled = false;
                });

                controlTimer.Stop();

                TextSize.Visibility = Visibility.Hidden;
                ButtonPlay.Visibility = Visibility.Hidden;
            }
        }

        bool ValueEquals(byte[] first, byte[] second)
        {
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    return false;
                }
            }

            return true;
        }

        public byte[] GetGridInfo(CellButton[,] obj)
        {
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    temp[x * Size + y] = (byte)obj[x, y].BackgroundImage;
                    temp[x * Size + y + Size * Size] = Convert.ToByte(obj[x, y].IsEnabled);
                }
            }

            temp[2 * Size * Size] = Convert.ToByte(isMyTurn);
            temp[temp.Length - 1] = (byte)Size;
            temp[temp.Length - (isServer ? 2 : 3)] = (byte)score;

            return temp;
        }

        public CellButton[,] GetGridBoard(byte[] bytes, CellButton[,] pictureBoxes)
        {
            isMyTurn = true;
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)delegate ()
            {
                Image_Turn.Source = new BitmapImage(new Uri(@"Images/green_turn.png", UriKind.Relative));
                hintChange.Source = new BitmapImage(new Uri(@"Images/hint2.png", UriKind.Relative));


                ButtonHint.IsEnabled = true;
                for (int x = 0; x < Size; x++)
                {
                    for (int y = 0; y < Size; y++)
                    {

                        if (bytes[x * Size + y + Size * Size] == 0)
                        {
                            pictureBoxes[x, y].Source = imageDictionary[pictureBoxes[x, y].BackgroundImage];
                            pictureBoxes[x, y].IsEnabled = false;
                            pictureBoxes[x, y].Opacity = .2;
                        }
                        pictureBoxes[x, y].BackgroundImage = (Pictures)bytes[x * Size + y];
                    }
                }
                if (AllDisable())
                {
                    GetGridInfo(pictureBoxes);

                    isFinished = true;
                    CheckBoard();
                }
            });

            return pictureBoxes;
        }

        void ChangeEnableState(bool enabled)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    pictureBoxes[i, j].IsEnabled = enabled;
                }
            }
            ButtonHint.Opacity = 1;
            ButtonHint.IsEnabled = enabled;
        }

        void PictureBox_Click(object sender, RoutedEventArgs e)
        {
            CellButton clicked = sender as CellButton;

            if (isMultiPlayer)
            {
                if (isMyTurn && isFinished == false)
                {
                    clicked.Source = imageDictionary[clicked.BackgroundImage];
                    clicked.IsEnabled = false;

                    Picture(clicked);

                    if (gameState == GameState.First)
                    {
                        Image_Turn.Source = new BitmapImage(new Uri(@"Images/red_turn.png", UriKind.Relative));
                        hintChange.Source = new BitmapImage(new Uri(@"Images/hint1.png", UriKind.Relative));

                        ButtonHint.IsEnabled = false;

                        if (isOpenPictures)
                        {
                            byte[] boardInfo = GetGridInfo(pictureBoxes);

                            con.sendBoard(boardInfo);
                            GetDataFromOthers();
                        }
                        else
                        {
                            first.IsEnabled = clicked.IsEnabled = true;

                            byte[] boardInfo = GetGridInfo(pictureBoxes);

                            con.sendBoard(boardInfo);
                            GetDataFromOthers();
                        }

                        CheckBoard();
                        ChangeEnableState(true);
                        isMyTurn = false;
                    }
                }
                else
                {
                    hintChange.Source = new BitmapImage(new Uri(@"Images/hint1.png", UriKind.Relative));

                    ButtonHint.IsEnabled = false;
                    MessageBox.Show("Sorry not your turn!");
                }
            }
            else
            {
                Picture(clicked);
            }
            ButtonPlay.IsEnabled = true;
        }

        void CheckBoard()
        {
            if (count == Size * Size / 2)
            {
                isFinished = true;
                isWinner = true;
            }

            if (isFinished)
            {
                isMyTurn = false;
                MessageBox.Show("Your score " + score);

                Environment.Exit(0);
            }
        }

        void GetDataFromOthers()
        {
            Task.Factory.StartNew(() =>
            {
                pictureBoxes = con.getBoard(this, pictureBoxes, isServer);

                CheckBoard();
            });
        }

        void CreateFbUser()
        {
            XmlNode rootNode;
            XmlDocument xmlDoc = new XmlDocument();
            XPathDocument xPathDoc;

            try
            {
                xPathDoc = new XPathDocument("FbUsers.xml");
            }
            catch (Exception)
            {
                xmlDoc.RemoveAll();
                XmlNode docNode = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDoc.AppendChild(docNode);
                rootNode = xmlDoc.CreateElement("Accounts");
                xmlDoc.AppendChild(rootNode);
                xmlDoc.Save("FbUsers.xml");
            }

            xPathDoc = new XPathDocument("FbUsers.xml");
            xmlDoc.Load("FbUsers.xml");

            XPathNavigator navigator = xPathDoc.CreateNavigator();

            XPathNodeIterator xPathIterator = navigator.Select("Accounts/Account");

            if (xPathIterator != null)
            {
                foreach (XPathNavigator FbAccount in xPathIterator)
                {
                    if (FbAccount.GetAttribute("ID", "") == userID)
                    {
                        return;
                    }
                }

                navigator = xmlDoc.CreateNavigator();
                navigator.MoveToChild("Accounts", "");
                navigator.AppendChild(TagsForFbFields(xmlDoc));

                xmlDoc.Save("FbUsers.xml");
            }
        }

        string TagsForFbFields(XmlDocument xmlDoc)
        {
            XmlElement account = xmlDoc.CreateElement("Account");
            account.SetAttribute("ID", userID);

            XmlElement firstName = xmlDoc.CreateElement("FirstName");
            firstName.InnerText = this.firstName;

            account.AppendChild(firstName);

            return Convert.ToString(account.OuterXml);
        }

        string GetScoreFromFbId(string currentID)
        {
            int max = 0;
            XPathDocument xPathDoc = new XPathDocument("FbUsers.xml");
            XPathNavigator xPathNavigator = xPathDoc.CreateNavigator();
            XPathNodeIterator xPathIterator = xPathNavigator.Select("Accounts/Account");

            foreach (XPathNavigator account in xPathIterator)
            {
                if (account.GetAttribute("ID", "") == currentID)
                {
                    XPathNodeIterator xPathIterator2 = account.Select("Score");

                    if (xPathIterator2 != null)
                    {
                        foreach (XPathNavigator score in xPathIterator2)
                        {
                            if (Convert.ToInt32(score.Value) > max)
                            {
                                max = Convert.ToInt32(score.Value);
                            }
                        }

                        return Convert.ToString(max);
                    }
                }
            }

            return "0";
        }

        string GetScoreFromId(string currentID)
        {
            int max = 0;
			XmlNode rootNode;
			XmlDocument xmlDoc = new XmlDocument();
			XPathDocument xPathDoc;

			try
			{
				xPathDoc = new XPathDocument("Users.xml");
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

			xPathDoc = new XPathDocument("Users.xml");
            XPathNavigator xPathNavigator = xPathDoc.CreateNavigator();
            XPathNodeIterator xPathIterator = xPathNavigator.Select("Accounts/Account");

            foreach (XPathNavigator account in xPathIterator)
            {
                if (account.GetAttribute("ID", "") == currentID)
                {
                    XPathNodeIterator xPathIterator2 = account.Select("Score");

                    if (xPathIterator2 != null)
                    {
                        foreach (XPathNavigator score in xPathIterator2)
                        {
                            if (Convert.ToInt32(score.Value) > max)
                            {
                                max = Convert.ToInt32(score.Value);
                            }
                        }

                        return Convert.ToString(max);
                    }
                }
            }

            return "0";
        }

        protected override void OnPreviewMouseWheel(MouseWheelEventArgs args)
        {
            base.OnPreviewMouseWheel(args);

            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                uiScaleSlider.Value += (args.Delta > 0) ? 0.1 : -0.1;
            }
        }

        protected override void OnPreviewMouseDown(MouseButtonEventArgs args)
        {
            base.OnPreviewMouseDown(args);

            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                if (args.MiddleButton == MouseButtonState.Pressed)
                {
                    RestoreScalingFactor(uiScaleSlider, args);
                }
            }
        }

        void RestoreScalingFactor(object sender, MouseButtonEventArgs args)
        {
            ((Slider)sender).Value = 1.0;
        }

        void AddInDictionary()
        {
            if (imageDictionary.Count == 0)
            {
                for (int i = -1; i < Enum.GetNames(typeof(Pictures)).Length - 1; i++)
                {
                    imageDictionary.Add((Pictures)i, new BitmapImage(new Uri(IMG_PATH + i + IMG_FORMAT, UriKind.Relative)));
                }
            }
        }

        void CreateFbScore(string userID, int score)
        {
            XPathDocument xPathDoc = new XPathDocument("FbUsers.xml");
            XmlDocument xmldoc = new XmlDocument();

            xmldoc.Load("FbUsers.xml");
            XPathNavigator xPathNavigator = xmldoc.CreateNavigator();
            XPathNodeIterator xPathIterator = xPathNavigator.Select("Accounts/Account");

            foreach (XPathNavigator book in xPathIterator)
            {
                if (book.GetAttribute("ID", "") == userID)
                {
                    XPathNodeIterator xPathIterator2 = book.Select("Score");

                    foreach (XPathNavigator scoreVal in xPathIterator2)
                    {
                        if (scoreVal.Value == score.ToString())
                        {
                            return;
                        }
                    }

                    book.AppendChild(string.Format("<Score>{0}</Score>", score));

                    xmldoc.Save("FbUsers.xml");
                }
            }
        }

        void CreateScore(string userID, int score)
        {
			XmlNode rootNode;
			XmlDocument xmlDoc = new XmlDocument();
			XPathDocument xPathDoc;

			try
			{
				xPathDoc = new XPathDocument("Users.xml");
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

			xPathDoc = new XPathDocument("Users.xml");
			xmlDoc.Load("Users.xml");

            XPathNavigator xPathNavigator = xmlDoc.CreateNavigator();

            XPathNodeIterator xPathIterator = xPathNavigator.Select("Accounts/Account");

            foreach (XPathNavigator book in xPathIterator)
            {
                if (book.GetAttribute("ID", "") == userID)
                {
                    XPathNodeIterator xPathIterator2 = book.Select("Score");

                    foreach (XPathNavigator scoreVal in xPathIterator2)
                    {
                        if (scoreVal.Value == score.ToString())
                        {
                            return;
                        }
                    }

                    book.AppendChild(string.Format("<Score>{0}</Score>", score));

                    xmlDoc.Save("Users.xml");
                }
            }
        }

        bool ValidValue(string txt)
        {
            int textBoxValue;

            if (string.Empty == txt)
            {
                return false;
            }
            else if (int.TryParse(txt, out textBoxValue))
            {
                if (2 > textBoxValue || textBoxValue > 10)
                {
                    MessageBox.Show(VALID_VAL);
                    return false;
                }
            }

            return true;
        }

        void ButtonPlay_Click(object sender, RoutedEventArgs e)
        {
            ButtonHint.IsEnabled = true;
            hintChange.Source = new BitmapImage(new Uri(@"Images/hint2.png", UriKind.Relative));

            if (isMultiPlayer)
            {
                if (isServer)
                {
                    if (!isWinner)
                    {
                    }
                    hintChange.Source = new BitmapImage(new Uri(@"Images/hint2.png", UriKind.Relative));
                }
            }

            if (isMultiPlayer)
            {
                ButtonHint.IsEnabled = false;
                Play();
                byte[] boardInfo = GetGridInfo(pictureBoxes);

                try
                {

                    if (isServer)
                    {
                        con.sendBoard(boardInfo);
                    }
                    else
                    {
                        GetDataFromOthers();
                        isMyTurn = false;
                    }
                }
                catch (Exception) { }
            }
            else
            {
                Play();
            }
            ButtonHint.Opacity = 1;
        }

        void NumericBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int value;

            if (!int.TryParse(e.Text, out value))
            {
                e.Handled = true;
            }
        }

        void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to quit the game ?", "Confirm", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        void ButtonHint_Click(object sender, RoutedEventArgs e)
        {

            if (isMultiPlayer)
            {
                if (isMyTurn)
                {
                    ButtonHint.Opacity = 1;
                    Hint();
                }
                else if (!isMyTurn)
                {
                    ButtonHint.Opacity = .5;

                }
                else
                {
                    ButtonHint.Opacity = .5;
                }
            }
            else
            {
                Hint();
            }

            ChangeScore(SCORE_SUB);
        }

        void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (pictureBoxes[i, j].IsEnabled == true)
                    {
                        pictureBoxes[i, j].Source = imageDictionary[Pictures.Question];
                    }
                }
            }

            dispatcherTimer.Stop();
        }

        public void ButtonLogOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                Login loginWnd = new Login();
                if (FbUser)
                {
                    Fb f = new Fb();
                    f.DoLogOut();

                }

                loginWnd.Show();
                Hide();
            }
        }

        void NumericBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }

            if (e.Key == Key.Enter)
            {
                ButtonPlay_Click(sender, e);
            }
        }

        void Game_Closing(object sender, ContextMenuEventArgs e)
        {
            Environment.Exit(0);
        }

        void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ("00" == TextSize.Text)
            {
                TextSize.Text = "0";
            }

            if (Regex.IsMatch(TextSize.Text, "[^0-9]"))
            {
                MessageBox.Show(Constants.NMB_VALID_MSG);

                TextSize.Text = string.Empty;
            }
            else
            {
                TextSize.Text = ((TextBox)sender).Text;
            }
        }

        #endregion Methods
    }
}
