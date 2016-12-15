using NETCOM;
using System;
using System.Windows;

namespace MemoryGameProject
{
    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    /// 
    public partial class ChatWindow : Window
    {
        AgentRelay m_chatProvider = new AgentRelay();
        ServerRelay m_serverRelay = new ServerRelay(true);

        private enum eTcpCommands                            // Contents.. (Parameters)
        {
            InvalidCommand = 0,
            ChatMessage = 1,

            QueryNameRequest = 2,
            QueryNameResponse = 3,
        };

        public ChatWindow()
        {
            InitializeComponent();
            //Loaded += MyChatForm_Load;
        }

        private void MyChatForm_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            m_chatProvider.Dispose();
            m_serverRelay.Dispose();        // m_serverRelay.StopServer(true);
        }

        private void MyChatForm_Load(object sender, RoutedEventArgs e)
        {
            m_chatProvider.OnNewPacketReceived += chatProvider_OnNewPacketReceived;

            m_serverRelay.OnNewAgentConnected += m_serverRelay_OnNewAgentConnected;
            m_serverRelay.OnServerFailedToAcceptConnection += m_serverRelay_OnServerFailedToAcceptConnection;
            m_serverRelay.StartServer(null, 1234);

            m_serverRelay.AcceptIncommingConnections = true;
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                m_chatProvider.Connect(tbIPAddress.Text, 1234);
                btnConnect.IsEnabled = false;
                btnSend.IsEnabled = true;
            }
            catch
            {
                MessageBox.Show("IP Address is invalid or the other side is not accessable!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            SendChatMessage(tbMessage.Text.Trim());
        }

        void m_serverRelay_OnServerFailedToAcceptConnection(Exception ex)
        {
            Dispatcher.Invoke(new Action(() => { lbMessages.Items.Insert(0, "EXCEPTION in ServerRelay: " + ex.Message); }));
        }

        void m_serverRelay_OnNewAgentConnected(AgentRelay agentRelay)
        {
            agentRelay.OnNewPacketReceived += chatProvider_OnNewPacketReceived;
            m_chatProvider = agentRelay;

            SendChatMessage("I am now connected to you!");

            Dispatcher.Invoke(new Action(() =>
            {
                btnSend.IsEnabled = true;
                btnConnect.IsEnabled = false;
                lbMessages.Items.Insert(0, "New agent received...");
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
    }
}
