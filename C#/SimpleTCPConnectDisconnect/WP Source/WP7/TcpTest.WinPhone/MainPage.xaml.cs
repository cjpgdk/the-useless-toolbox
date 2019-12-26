using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Text;
using Microsoft.Phone.Controls;
using System.Windows;
using System.Net.Sockets;
using System.Net;

namespace TcpTest.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        // Cached Socket object that will be used by each call for the lifetime of this class
        Socket _socket = null;

        // Signaling object used to notify when an asynchronous operation is completed
        static ManualResetEvent _clientDone = new ManualResetEvent(false);

        // Define a timeout in milliseconds for each asynchronous call. If a response is not received within this 
        // timeout period, the call is aborted.
        const int TIMEOUT_MILLISECONDS = 50000;

        // The maximum size of the data buffer to use with the asynchronous socket methods
        const int MAX_BUFFER_SIZE = 2048;

        private void Button_Click(object sender, RoutedEventArgs rea)
        {
            tbResultOutput.Text = "";
            try
            {
                tbResultOutput.Text += "Initializing TCP Connection\r\n";
                string result = "";

                // Create DnsEndPoint. The hostName and port are passed in to this method.
                DnsEndPoint hostEntry = new DnsEndPoint(tbHost.Text, Convert.ToInt32(tbPort.Text));

                // Create a stream-based, TCP socket using the InterNetwork Address Family. 
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Create a SocketAsyncEventArgs object to be used in the connection request
                SocketAsyncEventArgs socketEventArg = new SocketAsyncEventArgs();
                socketEventArg.RemoteEndPoint = hostEntry;

                // Inline event handler for the Completed event.
                // Note: This event handler was implemented inline in order to make this method self-contained.
                socketEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(delegate(object s, SocketAsyncEventArgs e)
                {

                    // Retrieve the result of this request
                    switch (e.SocketError)
                    {
                        case SocketError.AccessDenied:
                            result = " * Access Denied * ";
                            break;
                        case SocketError.AddressAlreadyInUse:
                            result = " * Address Already In Use * ";
                            break;
                        case SocketError.AddressFamilyNotSupported:
                            result = " * Address Family Not Supported * ";
                            break;
                        case SocketError.AddressNotAvailable:
                            result = " * Address Not Available * ";
                            break;
                        case SocketError.AlreadyInProgress:
                            result = " * Address In Progress * ";
                            break;
                        case SocketError.ConnectionAborted:
                            result = " * Connection Aborted * ";
                            break;
                        case SocketError.ConnectionRefused:
                            result = " * Connection Refused * ";
                            break;
                        case SocketError.ConnectionReset:
                            result = " * Connection Reset * ";
                            break;
                        case SocketError.DestinationAddressRequired:
                            result = " * Destination Address Required * ";
                            break;
                        case SocketError.Disconnecting:
                            result = " * Disconnecting * ";
                            break;
                        case SocketError.Fault:
                            result = " * Fault * ";
                            break;
                        case SocketError.HostDown:
                            result = " * Host Down * ";
                            break;
                        case SocketError.HostNotFound:
                            result = " * Host Not Found * ";
                            break;
                        case SocketError.HostUnreachable:
                            result = " * Host Unreachable * ";
                            break;
                        case SocketError.IOPending:
                            result = " * IO Pending * ";
                            break;
                        case SocketError.InProgress:
                            result = " * In Progress * ";
                            break;
                        case SocketError.Interrupted:
                            result = " * Interrupted * ";
                            break;
                        case SocketError.InvalidArgument:
                            result = " * Invalid Argument * ";
                            break;
                        case SocketError.IsConnected:
                            result = " * Is Connected * ";
                            break;
                        case SocketError.MessageSize:
                            result = " * Message Size * ";
                            break;
                        case SocketError.NetworkDown:
                            result = " * Network Down * ";
                            break;
                        case SocketError.NetworkReset:
                            result = " * Network Reset * ";
                            break;
                        case SocketError.NetworkUnreachable:
                            result = " * Network Unreachable * ";
                            break;
                        case SocketError.NoBufferSpaceAvailable:
                            result = " * No Buffer Space Available * ";
                            break;
                        case SocketError.NoData:
                            result = " * No Data * ";
                            break;
                        case SocketError.NoRecovery:
                            result = " * No Recovery * ";
                            break;
                        case SocketError.NotConnected:
                            result = " * Not Connected * ";
                            break;
                        case SocketError.NotInitialized:
                            result = " * Not Initialized * ";
                            break;
                        case SocketError.NotSocket:
                            result = " * Not Socket * ";
                            break;
                        case SocketError.OperationAborted:
                            result = " * Operation Aborted * ";
                            break;
                        case SocketError.OperationNotSupported:
                            result = " * Operation Not Supported * ";
                            break;
                        case SocketError.ProcessLimit:
                            result = " * Process Limit * ";
                            break;
                        case SocketError.ProtocolFamilyNotSupported:
                            result = " * Protocol Family Not Supported * ";
                            break;
                        case SocketError.ProtocolNotSupported:
                            result = " * Protocol Not Supported * ";
                            break;
                        case SocketError.ProtocolOption:
                            result = " * Protocol Option * ";
                            break;
                        case SocketError.ProtocolType:
                            result = " * Protocol Type * ";
                            break;
                        case SocketError.Shutdown:
                            result = " * Shutdown * ";
                            break;
                        case SocketError.SocketError:
                            result = " * Socket Error * ";
                            break;
                        case SocketError.SocketNotSupported:
                            result = " * Socket Not Supported * ";
                            break;
                        case SocketError.Success:
                            result = " * Socket Success * ";
                            break;
                        case SocketError.SystemNotReady:
                            result = " * System Not Ready * ";
                            break;
                        case SocketError.TimedOut:
                            result = " * Timed Out * ";
                            break;
                        case SocketError.TooManyOpenSockets:
                            result = " * Too Many Open Sockets * ";
                            break;
                        case SocketError.TryAgain:
                            result = " * Try Again * ";
                            break;
                        case SocketError.TypeNotFound:
                            result = " * Type Not Found * ";
                            break;
                        case SocketError.VersionNotSupported:
                            result = " * Version Not Supported * ";
                            break;
                        case SocketError.WouldBlock:
                            result = " * Would Block * ";
                            break;
                        default:
                            result = " * ?????????????? * ";
                            break;
                    }
                    // Signal that the request is complete, unblocking the UI thread
                    _clientDone.Set();

                    if (e.ConnectByNameError != null)
                        throw e.ConnectByNameError;
                });

                // Sets the state of the event to nonsignaled, causing threads to block
                _clientDone.Reset();
                tbResultOutput.Text += "Connecting...\r\n";
                tbResultOutput.Text += " - " + tbHost.Text + ":" + tbPort.Text + "\r\n";
                // Make an asynchronous Connect request over the socket
                _socket.ConnectAsync(socketEventArg);
                // Block the UI thread for a maximum of TIMEOUT_MILLISECONDS milliseconds.
                // If no response comes back within this time then proceed
                tbResultOutput.Text += "Waiting for response (Max: " + tbTimeout.Text + " seconds) before displaying result\r\n";
                if (!_clientDone.WaitOne(Convert.ToInt32(Convert.ToInt32(tbTimeout.Text) * 1000)))
                {
                    tbResultOutput.Text += "\r\n - Waited for " + tbTimeout.Text + " seconds, aborting... ";
                }

                tbResultOutput.Text += result + "\r\n";


                //
                //using (StreamSocket streamSocket = new StreamSocket())
                //{
                //    HostName host = new HostName(tbHost.Text);
                //    tbResultOutput.Text += "Connecting...\r\n";
                //    await streamSocket.ConnectAsync(host, tbPort.Text);
                //    tbResultOutput.Text += "Connected..\r\n";
                //}
                //
            }
            catch (Exception ex)
            {
                tbResultOutput.Text = "Error\r\n" + ex.Message;
            }

            tbResultOutput.Text += "Closeing connection\r\n";
            try
            {
                _clientDone.Set();
                _socket.Close();
            }
            catch (Exception)
            {
            }
        }

    }
}