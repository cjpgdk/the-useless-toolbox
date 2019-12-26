using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Networking;
using Windows.Networking.Sockets;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace TcpTest.WinPhone
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            tbResultOutput.Text = "";
            try
            {
                tbResultOutput.Text += "Initializing TCP Connection\r\n";
                using (StreamSocket streamSocket = new StreamSocket())
                {
                    HostName host = new HostName(tbHost.Text);
                    tbResultOutput.Text += "Connecting...\r\n";
                    await streamSocket.ConnectAsync(host, tbPort.Text);
                    tbResultOutput.Text += "Connected..\r\n";
                }
                tbResultOutput.Text += "Connecting seems okay.\r\n";
            }
            catch (Exception ex)
            {
                tbResultOutput.Text = "Error\r\n" + ex.Message;
            }
        }

        private static async Task<Windows.Storage.Streams.IBuffer> ReadAsync(StreamSocket socket)
        {
            // all responses are smaller that 1024
            IBuffer buffer = new byte[1024].AsBuffer();
            await socket.InputStream.ReadAsync(buffer, buffer.Capacity, InputStreamOptions.Partial);
            return buffer;
        }


    }
}
