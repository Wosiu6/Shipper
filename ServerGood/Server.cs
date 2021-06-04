using Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;

namespace ServerGood
{
    class Server
    {
        public static SortedDictionary<string, Socket> clientsListUDP = new SortedDictionary<string, Socket>();

        public static SortedDictionary<string, Socket> clientsDCListUDP = new SortedDictionary<string, Socket>();

        public static SortedDictionary<string, TcpClient> clientsList = new SortedDictionary<string, TcpClient>();

        public static SortedDictionary<string, TcpClient> clientsDisconectedList = new SortedDictionary<string, TcpClient>();

        public static SortedDictionary<string, int> clientsDCAvatarsIndexesList = new SortedDictionary<string, int>();

        public static SortedDictionary<string, int> clientsAvatarsIndexesList = new SortedDictionary<string, int>();

        public static ArrayList clientsAvatarList = new ArrayList();

        public static List<string> avatarsDirList = new List<string>();

        public static Bitmap ship = new Bitmap("it.jpg");

        public static bool HigherOrLower = false;

        public static int numberToGuess = 0;

        static void Main(string[] args) => StartServer("127.0.0.1", 8888);

        public static void StartServer(string ip, int portNum)
        {
            var ipAddress = IPAddress.Parse(ip);

            var serverSocket = new TcpListener(ipAddress, portNum);

            var clientSocket = default(TcpClient);

            var counter = 0;

            serverSocket.Start();

            Console.WriteLine("Server running...");

            counter = 0;

            while ((true))
            {
                counter++;

                clientSocket = serverSocket.AcceptTcpClient();

                byte[] inStream = new byte[4096];

                var networkStream = clientSocket.GetStream();
                _ = networkStream.Read(inStream, 0, inStream.Length);

                var returnPacket = (Packet)(Packet.Desirialize(inStream));

                var clientNickname = "";
                var clientAvatarID = 0;

                if (returnPacket.Type == PacketType.NICKNAMEPACKET)
                {
                    clientNickname = ((NicknamePacket)returnPacket).nickname;
                    clientAvatarID = ((NicknamePacket)returnPacket).avatarIndex;
                }

                try
                {
                    clientsList.Add(clientNickname, clientSocket); //add Clients to socket HashTable
                    clientsAvatarsIndexesList.Add(clientNickname, clientAvatarID); //add Clients to avatarID HashTable

                    var client = new TCPClientServerClass();

                    client.StartClient(clientSocket, clientNickname, clientsList, clientAvatarID);

                    BroadcastMessage(clientNickname + " Joined ", false);

                    Console.WriteLine(clientNickname + " Joined chat room ");

                    Thread.Sleep(100);

                    SendPacketToAll(new ListOfClientsPacket(clientsAvatarsIndexesList));
                }
                catch (Exception e)
                {
                    SendPacketToClient(returnPacket, clientSocket);
                }
            }
        }

        public static void SendPacketToClient(Packet newPacket, TcpClient client)
        {
            TcpClient broadcastSocket;

            broadcastSocket = client;

            var broadcastStream = broadcastSocket.GetStream();

            byte[] broadcastBytes = null;

            broadcastBytes = Packet.Serialize(newPacket);

            broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);

            broadcastStream.Flush();
        } //end of particular client send packet function

        public static void SendPacketToAll(Packet newPacket)
        {
            foreach (KeyValuePair<string, TcpClient> Item in clientsList)
            {
                TcpClient broadcastSocket;

                broadcastSocket = Item.Value;

                var broadcastStream = broadcastSocket.GetStream();

                byte[] broadcastBytes = null;

                broadcastBytes = Packet.Serialize(newPacket);

                broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);

                broadcastStream.Flush();
            }
        }  //end of packet send function

        public static byte[] GetSerialisedImage(Bitmap bm)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bm.Save(ms, ImageFormat.Bmp);
                return ms.ToArray();
            }
        }

        public static Bitmap GetDesarialisedImage(byte[] serialisedImage)
        {
            using (MemoryStream ms = new MemoryStream(serialisedImage))
                return new Bitmap(ms);

        }

        public static void BroadcastMessage(string msg, bool userWriting)
        {
            foreach (KeyValuePair<string, TcpClient> Item in clientsList)
            {
                TcpClient broadcastSocket;

                broadcastSocket = Item.Value;

                var broadcastStream = broadcastSocket.GetStream();

                byte[] broadcastBytes = null;

                if (userWriting)
                {
                    broadcastBytes = Packet.Serialize(new MessagePacket(msg));
                }

                else
                {
                    broadcastBytes = Packet.Serialize(new MessagePacket(msg));
                }

                broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);

                broadcastStream.Flush();
            }
        }  //end broadcast function

        public class TCPClientServerClass
        {
            TcpClient clientSocket;

            string clientID;

            SortedDictionary<string, TcpClient> clientsList;

            int ClientAvatarID;

            bool connected;

            public void StartClient(TcpClient inClientSocket, string clientID, SortedDictionary<string, TcpClient> cList, int ClientAvatarID)
            {
                this.ClientAvatarID = ClientAvatarID;

                clientSocket = inClientSocket;

                this.clientID = clientID;

                clientsList = cList;

                connected = true;

                var ctThread = new Thread(GetRequestsFromClient);

                ctThread.Start();
            }

            Packet ReadPacket()
            {
                var serverStream = clientSocket.GetStream();

                byte[] inStream = new byte[4096];

                var bytesRead = serverStream.Read(inStream, 0, inStream.Length);

                var newPacket = (Packet)Packet.Desirialize(inStream);

                serverStream.Flush();

                return newPacket;
            }

            void GetRequestsFromClient()
            {
                while (true)
                {
                    Packet newPacket = null;
                    if (connected)
                        try
                        {
                            newPacket = ReadPacket();

                            switch (newPacket.Type) //do different things depending on request type
                            {
                                case PacketType.AVATAR:
                                    {
                                        UpdateAvatars(newPacket);
                                        SendPacketToAll(new ListOfClientsPacket(clientsAvatarsIndexesList));
                                        BroadcastMessage(clientID + " changed their avatar!", false);
                                        break;
                                    }
                                case PacketType.MESSAGEPACKET:
                                    {
                                        bool msgSent = false;
                                        msgSent = PlayGuessNumber(newPacket);

                                        if (!msgSent)
                                        {
                                            BroadcastMessage(clientID + ": " + ((MessagePacket)newPacket).msg, true);
                                            Console.WriteLine("From client - " + clientID + " : " + ((MessagePacket)newPacket).msg);
                                            break;
                                        }
                                        break;
                                    }
                                case PacketType.REQUESTCONNECT:
                                    {
                                        ReopenClient((RequestConnectPacket)newPacket);
                                        break;
                                    }
                                case PacketType.REQUESTDISCONNECT:
                                    {
                                        DisconnectClient((RequestDisconnectPacket)newPacket);
                                        break;
                                    }
                                case PacketType.LISTOFCLIENTREQUEST:
                                    {
                                        SendPacketToAll(new ListOfClientsPacket(clientsAvatarsIndexesList));
                                        break;
                                    }
                                case PacketType.DIRECTMESSAGE:
                                    {
                                        var client = FindClient((DirectMessagePacket)newPacket);
                                        SendPacketToClient(new DirectMessagePacket(clientID, ((DirectMessagePacket)newPacket).msg), client);
                                        break;
                                    }
                                case PacketType.CLIENTCLOSE:
                                    {
                                        CloseClient((ClientClosePacket)newPacket);
                                        connected = false;
                                        break;
                                    }
                                case PacketType.IMAGE:
                                    {
                                        SendPacketToAll(new ImagePacket(((ImagePacket)newPacket).direction, GetSerialisedImage(ship)));
                                        break;
                                    }
                                case PacketType.ENDPOINT:
                                    {
                                        Console.WriteLine("EndPoint Received");
                                        CreateUDPClient(newPacket);
                                        break;
                                    }

                            }
                        }
                        catch (KeyNotFoundException keyE)
                        {
                            SendPacketToClient(new DirectMessagePacket("Client not found"), clientSocket);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Remote host forecefully shut the connection - " + clientID + "\nCause: " + e.Message);
                            CloseClient(new ClientClosePacket());
                            return;
                        }
                    else
                        Thread.Sleep(1000);
                }
            }

            bool PlayGuessNumber(Packet newPacket)
            {
                string messageReceived = ((MessagePacket)newPacket).msg;
                int guess;


                messageReceived = Regex.Replace(messageReceived, @"\s+", "");
                if (!HigherOrLower)
                    if (Regex.IsMatch(messageReceived, "HighOrLow"))
                    {

                        string[] charac = Regex.Split(messageReceived, "HighOrLow");
                        Int32.TryParse(charac[1], out numberToGuess);
                        if (!(Regex.IsMatch(charac[1], "^[0-9]+$")))
                        { }
                        else
                        {
                            HigherOrLower = true;
                            BroadcastMessage(clientID + " Started Guess a number game!", false);
                            Console.WriteLine("From client - " + clientID + " : " + ((MessagePacket)newPacket).msg);
                            return true;
                        }
                    }
                if (HigherOrLower)
                {
                    bool num = Int32.TryParse(messageReceived, out guess);
                    if (num)
                    {
                        if (guess == numberToGuess)
                        {
                            BroadcastMessage(clientID + ": " + ((MessagePacket)newPacket).msg, true);
                            Console.WriteLine("From client - " + clientID + " : " + ((MessagePacket)newPacket).msg);

                            BroadcastMessage(clientID + " has guessed the correct number!", false);
                            HigherOrLower = false;
                            return true;
                        }
                        else if (guess > numberToGuess)
                        {
                            BroadcastMessage(clientID + ": " + ((MessagePacket)newPacket).msg, true);
                            Console.WriteLine("From client - " + clientID + " : " + ((MessagePacket)newPacket).msg);

                            BroadcastMessage(clientID + " try lower!", false);
                            return true;
                        }
                        else if (guess < numberToGuess)
                        {
                            BroadcastMessage(clientID + ": " + ((MessagePacket)newPacket).msg, true);
                            Console.WriteLine("From client - " + clientID + " : " + ((MessagePacket)newPacket).msg);

                            BroadcastMessage(clientID + " try higher!", false);
                            return true;
                        }
                    }
                }
                return false;
            }
            void CreateUDPClient(Packet newPacket)
            {
                var UDPClient = new UDPClientServerClass(((EndPointPacket)newPacket).EndPoint, clientID);
            }

            void UpdateAvatars(Packet newPacket)
            {
                var index = ((AvatarChangePacket)newPacket).avatarID;

                clientsAvatarsIndexesList[clientID] = index;
            }

            TcpClient FindClient(DirectMessagePacket newPacket)
            {
                var client = (TcpClient)(clientsList[newPacket.receiverID]);
                return client;
            }

            void CloseClient(ClientClosePacket newPacket)
            {
                clientsDisconectedList.Add(clientID, clientsList[clientID]);
                clientsDCAvatarsIndexesList.Add(clientID, clientsAvatarsIndexesList[clientID]);

                clientsList.Remove(clientID);
                clientsAvatarsIndexesList.Remove(clientID);

                Console.WriteLine("Client " + clientID + " Succesfully removed.");

                BroadcastMessage(clientID + " disconnected.", false);

                Thread.Sleep(100);

                SendPacketToAll(new ListOfClientsPacket(clientsAvatarsIndexesList));
            }

            void DisconnectClient(RequestDisconnectPacket newPacket)
            {
                clientsDisconectedList.Add(clientID, clientsList[clientID]);
                clientsDCAvatarsIndexesList.Add(clientID, clientsAvatarsIndexesList[clientID]);

                clientsList.Remove(clientID);
                clientsAvatarsIndexesList.Remove(clientID);

                Console.WriteLine("Client " + clientID + " Succesfully removed.");

                BroadcastMessage(clientID + " disconnected.", false);

                Thread.Sleep(100);

                SendPacketToAll(new ListOfClientsPacket(clientsAvatarsIndexesList));
            }

            void ReopenClient(RequestConnectPacket newPacket)
            {
                clientsList.Add(clientID, clientsDisconectedList[clientID]);
                clientsAvatarsIndexesList.Add(clientID, clientsDCAvatarsIndexesList[clientID]);

                clientsDisconectedList.Remove(clientID);
                clientsDCAvatarsIndexesList.Remove(clientID);

                Console.WriteLine("Client " + clientID + " Succesfully reconnected.");

                BroadcastMessage(clientID + " reconnected.", false);

                Thread.Sleep(100);

                SendPacketToAll(new ListOfClientsPacket(clientsAvatarsIndexesList));
            }
        }

        public class UDPClientServerClass
        {
            public bool connected;
            public string ClientID;
            public Socket UDPSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            public UDPClientServerClass(EndPoint endPoint, string ClientID)
            {
                UDPSocket.Connect(endPoint);
                this.ClientID = ClientID;
                SendPacketToClient(new EndPointPacket(UDPSocket.LocalEndPoint), (TcpClient)clientsList[ClientID]);
                Console.WriteLine("Local: " + UDPSocket.LocalEndPoint);
                Console.WriteLine("Remote: " + UDPSocket.RemoteEndPoint);
                connected = true;
                Console.WriteLine("UDP Client Connected");
                clientsListUDP.Add(ClientID, UDPSocket);

                var ctThread = new Thread(GetRequestsFromClient);

                ctThread.Start();
            }
            Packet ReadPacket()
            {
                byte[] inStream = new byte[4096];

                var lenght = UDPSocket.Receive(inStream);

                var newPacket = (Packet)Packet.Desirialize(inStream);

                return newPacket;
            }

            void GetRequestsFromClient()
            {
                while (UDPSocket.Connected)
                {
                    if (connected)
                        try
                        {
                            var newPacket = ReadPacket();

                            switch (newPacket.Type) //do different things depending on request type
                            {
                                case PacketType.MESSAGEPACKET:
                                    {
                                        Console.WriteLine("UDP Packet Received");
                                        SendPacketToAll_UDP(newPacket);
                                        break;
                                    }
                                case PacketType.PAINT:
                                    {
                                        SendPacketToAll_UDP(newPacket);
                                        break;
                                    }
                                case PacketType.CHANGEPAINT:
                                    {
                                        SendPacketToAll_UDP(newPacket);
                                        break;
                                    }
                                case PacketType.REQUESTPAINT:

                                    break;


                            }
                        }
                        catch (Exception e)
                        {
                            UDPSocket.Close();
                            Console.WriteLine("Remote host forecefully shut the connection - " + ClientID + "\nCause: " + e.Message);
                            return;
                        }
                    else
                        Thread.Sleep(1000);
                }
            }

            void SendPacketToAll_UDP(Packet newPacket)
            {
                foreach (KeyValuePair<string, Socket> Item in clientsListUDP)
                    Item.Value.Send(Packet.Serialize(newPacket));

            }
            void SendPacketToAllExceptSender_UDP(Packet newPacket)
            {
                foreach (KeyValuePair<string, Socket> Item in clientsListUDP)
                {
                    if (!(this.ClientID.Equals(Item.Key)))
                        Item.Value.Send(Packet.Serialize(newPacket));
                }

            }

            void SendPacketToCliient_UDP(Packet newPacket, string username)
            {
                if (clientsListUDP.ContainsKey(username))
                    ((Socket)clientsListUDP[username]).Send(Packet.Serialize(newPacket));
            }
        }
    }
}