using System;
using System.Media;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

using System.Windows.Media;
using static MemoryGameProject.Constants;
using System.Windows.Media.Imaging;

namespace MemoryGameProject
{
    public partial class Game : Window
    {
        #region Methods

        public void Play(int size = -1)
        {

            if (-1 == size)
            {
                if (ValidValue(TextSize.Text))
                {
                    Size = Convert.ToInt32(TextSize.Text);
                }
                else
                {
                    Size = 3;
                    TextSize.Text = "3";
                }
            }
            else
            {
                Size = size;
            }

            score = 0;
            count = 0;

            LabelScore.Content = string.Format("Score: {0}", score);

            string bestScore = FbUser ? GetScoreFromFbId(userID) : GetScoreFromId(userID);

            if (FbUser || userID != string.Empty)
            {
                LabelBestScore.Content = string.Format("Your Best Score: {0}", bestScore);
            }

            ButtonHint.IsEnabled = true;
         
            if (Size > 7)
            {
          // MyGrid.Height = 600 + (Size - 6) * 85;

            }

            if (pictureBoxes != null)
            {
                MyGrid.Children.Clear();
                MyGrid.RowDefinitions.Clear();
                MyGrid.ColumnDefinitions.Clear();
            }

            for (int i = 0; i < Size; i++)
            {
                MyGrid.ColumnDefinitions.Add(new ColumnDefinition());
                MyGrid.RowDefinitions.Add(new RowDefinition());
            }

            pictureBoxes = new CellButton[Size, Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (Size > 7)
                    {
                        pictureBoxes[i, j] = new CellButton()
                        {
                            Width = 55,
                            Height = 55,
                            Source = imageDictionary[Pictures.Question],
                        };
                        //goto B;
                    }
                    else
                    {
                        pictureBoxes[i, j] = new CellButton()
                        {
                            Width = 80,
                            Height = 80,
                            Source = imageDictionary[Pictures.Question],
                        };

                    }
                
                    CellButton pBox = pictureBoxes[i, j];

                    Grid.SetRow(pBox, i);
                    Grid.SetColumn(pBox, j);

                    MyGrid.Children.Add(pBox);

                    pBox.MouseDown += PictureBox_Click;
                    pointList.Add(new ListPoint(i, j));
                }
            }
            if (Size > 7)
            {
                MyGrid.Width = MyGrid.Height = Size * 55;
            }
          else
            {
                MyGrid.Width = MyGrid.Height = Size * 80;
            }

            //if (Size > 6)
            //{
            //    ContentElement.Height = 653;

            //    //   ContentElement.Height = MyGrid.Height + 293;
            //}
            //else
            //{
            //    ContentElement.Height = 653;
            //}

            #region Pictures

            #region JockerCard

            if (Size % 2 != 0)
            {
                int rand1 = rnd.Next(0, pointList.Count);

                pictureBoxes[pointList[rand1].X, pointList[rand1].Y].BackgroundImage = Pictures.Jocker;
                pointList.Remove(pointList[rand1]);
            }

            #endregion JockerCard

            for (int i = 0; i < (Size * Size) / 2; i++)
            {
                int imageValue = rnd.Next(1, Enum.GetNames(typeof(Pictures)).Length - 1);

                RndNumber: int rand1 = rnd.Next(0, pointList.Count);
                int rand2 = rnd.Next(0, pointList.Count);

                if (rand2 == rand1)
                {
                    goto RndNumber;
                }

                pictureBoxes[pointList[rand1].X, pointList[rand1].Y].BackgroundImage = (Pictures)imageValue;
                pictureBoxes[pointList[rand2].X, pointList[rand2].Y].BackgroundImage = (Pictures)imageValue;

                ListPoint point1 = pointList[rand1];
                ListPoint point2 = pointList[rand2];

                pointList.Remove(point1);
                pointList.Remove(point2);
            }

            #endregion Pictures

        }

        public void Picture(CellButton clicked)
        {
            clicked.Source = imageDictionary[clicked.BackgroundImage];
            clicked.IsEnabled = false;

            Thread soundThread = new Thread(() =>
            {
                SoundPlayer player = new SoundPlayer(Properties.Resources.win);

                player.Load();
                player.Play();
            });

            Action checkForWin = delegate ()
            {
                if (count / 2 != 0 && count == ((Size * Size) - 1) / 2)
                {
                    for (int i = 0; i < Size; i++)
                    {
                        for (int j = 0; j < Size; j++)
                        {
                            if (pictureBoxes[i, j].IsEnabled == true)
                            {
                                pictureBoxes[i, j].Source = imageDictionary[pictureBoxes[i, j].BackgroundImage];
                                pictureBoxes[i, j].IsEnabled = false;
                            }
                        }
                    }
                }
                if (count == Size * Size / 2)
                {
                    hintChange.Source = new BitmapImage(new Uri(@"Images/hint1.png", UriKind.Relative));

                    //     ButtonHint.Background = Brushes.Gray;
                    //ButtonHint.Background = OpacityMask;
                    ButtonHint.IsEnabled = false;

                    if (userID != string.Empty && !FbUser)
                    {
                        CreateScore(userID, score);
                    }
                    else if (FbUser)
                    {
                        CreateFbScore(userID, score);
                    }

                    soundThread.Start();
                    CustomMsgBox.Show(score, WIN_MSG, FbUser);
                }
            };

            Action<CellButton> caseJoker = delegate (CellButton cb)
            {
                Thread.Sleep(hundredSeconds);

                count++;
                cb.IsEnabled = false;

                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        var pBox = pictureBoxes[i, j];

                        if (pBox.BackgroundImage == cb.BackgroundImage && pBox.IsEnabled == true)
                        {
                            pBox.Source = imageDictionary[pBox.BackgroundImage];
                            pBox.Opacity = clicked.Opacity = first.Opacity = .2;
                            pBox.IsEnabled = first.IsEnabled = clicked.IsEnabled = false;
                            ChangeScore(SCORE_ADD);

                            goto OutOfLoops;
                        }
                    }
                }

                OutOfLoops: checkForWin();
                gameState = GameState.First;
            };

            Thread notMatch = new Thread(() =>
            {
                Thread.Sleep(NOT_MATCH_TIME);

                Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)delegate ()
                {
                    Thread.Sleep(NOT_MATCH_TIME);

                    clicked.IsEnabled = true;
                    first.IsEnabled = true;

                    clicked.Source = imageDictionary[Pictures.Question];
                    first.Source = imageDictionary[Pictures.Question];

                    ChangeScore(SCORE_SUB);

                    LabelScore.Content = string.Format("Score: {0}", score);
                });
            });

            Thread match = new Thread(() =>
            {
                Thread.Sleep(hundredSeconds);

                Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)delegate ()
                {
                    Thread.Sleep(hundredSeconds);

                    count++;

                    clicked.IsEnabled = false;
                    first.IsEnabled = false;

                    first.Opacity = .2;
                    clicked.Opacity = .2;

                    ChangeScore(SCORE_ADD);

                    checkForWin();

                });
            });

            switch (gameState)
            {
                case GameState.First:
                    {
                        first = clicked;

                        gameState = clicked.BackgroundImage == Pictures.Jocker ? GameState.FirstAndJocker : GameState.Second;
                    }
                    break;
                case GameState.Second:
                    {
                        if (clicked != first)
                        {
                            if (clicked.BackgroundImage == first.BackgroundImage)
                            {
                                isOpenPictures = true;

                                match.Start();

                            }
                            else if (clicked.BackgroundImage == Pictures.Jocker)
                            {
                                isOpenPictures = true;

                                goto case GameState.SecondAndJocker;
                            }
                            else
                            {
                                isOpenPictures = false;

                                notMatch.Start();
                            }
                        }

                        gameState = GameState.First;
                    }
                    break;
                case GameState.FirstAndJocker:
                    {
                        isOpenPictures = true;

                        caseJoker(clicked);

                    }
                    break;
                case GameState.SecondAndJocker:
                    {
                        caseJoker(first);
                    }
                    break;
            }
        }

        bool AllDisable()
        {
            //bool x = true;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (pictureBoxes[i, j].IsEnabled == true)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void ChangeScore(int newVal)
        {
            score += newVal;

            if (score < 0)
            {
                score = 0;
            }

            LabelScore.Content = string.Format("Score: {0}", score);
        }

        public void Hint()
        {
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);

            dispatcherTimer.Tick += DispatcherTimer_Tick;
            dispatcherTimer.Start();

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    CellButton pBox = pictureBoxes[i, j];

                    if (pBox.IsEnabled == true)
                    {
                        pBox.Source = imageDictionary[pBox.BackgroundImage];
                    }
                }
            }
        }

        #endregion Methods
    }
}
