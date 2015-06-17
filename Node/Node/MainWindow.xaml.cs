using NBitcoin;
using NBitcoin.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Node
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NodeServer server;

        public MainWindow()
        {
            InitializeComponent();

            server = new NodeServer(Network.Main);
            server.ExternalEndpoint = new IPEndPoint(IPAddress.Parse("101.165.103.43"), 8333);
            server.NodeAdded += server_NodeAdded;
            server.MessageReceived += server_MessageReceived;
            server.NodeRemoved += server_NodeRemoved;
        }

        void server_NodeRemoved(NodeServer sender, NBitcoin.Protocol.Node node)
        {
            Log("Node removed");
        }

        void server_NodeAdded(NodeServer sender, NBitcoin.Protocol.Node node)
        {
            String message = node.ToString();
            Log(message);
        }

        void server_MessageReceived(NodeServer sender, IncomingMessage message)
        {
            Log(message.ToString());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //server.FindOrConnect(new IPEndPoint(IPAddress.Parse("104.210.94.255"), 8333));

            //bitseed.xf2.org
            NodesCollection nodes = server.ConnectedNodes;
        }

        private void Log(String message)
        {
            this.Logs.Items.Add(String.Format("{0} {1}", DateTime.Now, message));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            server.Listen();
            server.FindOrConnect(new IPEndPoint(IPAddress.Parse("104.210.94.255"), 8333));
        }
    }
}
