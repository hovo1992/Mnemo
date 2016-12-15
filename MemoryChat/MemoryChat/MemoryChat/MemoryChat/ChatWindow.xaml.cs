using NETCOM;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using static MemoryChat.Consts;

namespace MemoryChat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        public static double leftPadding = (SystemParameters.WorkArea.Width - (GAME_WIDTH + CHAT_WIDTH)) / 2;
        public static double topPadding = (SystemParameters.WorkArea.Height - GAME_HEIGHT) / 2;
        public static string connectIP;
        public static bool isChatServer = false;
        AgentRelay m_chatProvider = new AgentRelay();
        ServerRelay m_serverRelay = new ServerRelay(true);

        private enum eTcpCommands
        {
            InvalidCommand = 0,
            ChatMessage = 1,

            QueryNameRequest = 2,
            QueryNameResponse = 3,
        };

        public ChatWindow()
        {
            Left = leftPadding;
            Top = ChatWindow.topPadding;

            ResizeMode = ResizeMode.NoResize;

            InitializeComponent();
            if (!isChatServer)
            {
                try
                {
                    m_chatProvider.Connect(connectIP, 1234);
                    btnSend.IsEnabled = true;
                }
                catch
                {
                    MessageBox.Show("IP Address is invalid or the other side is not accessable!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void MyChatForm_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            m_chatProvider.Dispose();
            m_serverRelay.Dispose();
        }

        private void MyChatForm_Load(object sender, RoutedEventArgs e)
        {
            m_chatProvider.OnNewPacketReceived += chatProvider_OnNewPacketReceived;

            m_serverRelay.OnNewAgentConnected += m_serverRelay_OnNewAgentConnected;
            m_serverRelay.StartServer(null, 1234);

            m_serverRelay.AcceptIncommingConnections = true;
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            SendChatMessage(TbName.Text.Trim() + ":  " + tbMessage.Text.Trim());
            tbMessage.Text = string.Empty;

        }

        void m_serverRelay_OnNewAgentConnected(AgentRelay agentRelay)
        {
            agentRelay.OnNewPacketReceived += chatProvider_OnNewPacketReceived;
            m_chatProvider = agentRelay;

            Dispatcher.Invoke(new Action(() =>
            {
                btnSend.IsEnabled = true;
            }));
        }

        public bool SendChatMessage(string txt)
        {
            return m_chatProvider.SendMessage((int)eTcpCommands.ChatMessage, txt);
        }

        private void chatProvider_OnNewPacketReceived(AgentRelay.Packet packet, AgentRelay agentRelay)
        {
            switch (packet.Command)
            {
                case (byte)eTcpCommands.ChatMessage:
                    Dispatcher.Invoke(new Action(() => { lbMessages.Items.Insert(0, AgentRelay.MakeStringFromPacketContents(packet)); }));
                    break;

                case (byte)eTcpCommands.QueryNameRequest:
                    agentRelay.SendMessage((int)eTcpCommands.QueryNameResponse, "TCP/IP Test");
                    break;

                case (byte)eTcpCommands.QueryNameResponse:
                    Dispatcher.Invoke(new Action(() => { lbMessages.Items.Insert(0, "NAME: " + AgentRelay.MakeStringFromPacketContents(packet)); }));
                    break;

                default:
                    agentRelay.SendResponse(AgentRelay.eResponseTypes.InvalidCommand);
                    break;
            }
        }

        private void Message_Enter(object sender, DragEventArgs e)
        {

            if (tbMessage.Text == "Place Holder text...")
            {
                tbMessage.Text = "";
            }
        }

        private void Message_Leave(object sender, DragEventArgs e)
        {
            if (tbMessage.Text == "")
            {
                tbMessage.Text = "Place Holder text...";
            }
        }

        private void enter_to_Send(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (tbMessage.Text != "")
            {
                btnSend_Click(sender, e);
            }
        }
        
    }
}