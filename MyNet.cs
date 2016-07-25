﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace ClientTest {

	public class MyNet {
		/// <summary>
		/// 서버의 IP 주소이다. 수동으로 지정해서 알려주어야 한다.
		/// </summary>
		public static string serverAddress = "127.0.0.1";

		/// <summary>
		/// 서버에서 부여한 아이디이다.
		/// 부여되지 않은 아이디는 -1 이다.
		/// </summary>
		public static int myId = -1;

		/// <summary>
		/// 서버와의 연결을 시작한다.
		/// </summary>
		public static void Start() {
			_MyNet newNet = new _MyNet();
			Thread thread = new Thread(newNet.Run);
			thread.Start();

			StringWriter writer = new StringWriter();
			Thread sendThread = new Thread(writer.SendString);
			sendThread.Start();
		}

		/// <summary>
		/// 서버에게 어떤 메세지를 보내고 싶을 때 사용한다.
		/// </summary>
		/// <param name="message"></param>
		public static void Send(NetString message) {
			StringWriter.buffer.AddLast(message);
		}

		/// <summary>
		/// 서버에게 어떤 메세지를 보내고 싶을 때 사용한다.
		/// </summary>
		/// <param name="message"></param>
		public static void Send(string message) {
			NetString str = new NetString(message);
			StringWriter.buffer.AddLast(str);
		}


		/// <summary>
		/// 서버와의 연결을 그만두고 싶을 때 사용한다.
		/// </summary>
		public static void Stop() {
			NetString str = new NetString(EnumStr.Flow.Exit);
			Send(str);
		}

	}

	/// <summary>
	/// 받은 NetString 을 저장하는 곳
	/// </summary>
	class Received {
		public static LocalQueue<NetString> buffer = new LocalQueue<NetString>();
	}

	/// <summary>
	/// 실제 연결부. 숨기기 위해 앞에 _ 를 붙였다.
	/// </summary>
	public class _MyNet {
		private static TcpClient client = null;
		private ListenServer server = null;
		public static NetworkStream writeStream = null;

		public static bool isServerRun = true;

		public static void _SendString(NetString message) {
			try {
				if (client.Connected) {
					//str = Console.ReadLine() + "\r\n";
					byte[] data = Encoding.UTF8.GetBytes(message.GetString() + "\r\n");
					writeStream.Write(data, 0, data.Length);
					if (message.Equals("-10,exit;\r\n")) {
						isServerRun = false;
						client.Close();
					}
				}
			} catch (Exception ex) {
				Console.WriteLine(ex.ToString());
			}
		}

		public void Run() {
			server = new ListenServer();
			Thread serverListen = new Thread(server.Run);
			serverListen.Start();
			//
			//LocalHost에 지정 포트로 TCP Connection을 생성하고 데이터를 송수신 하기
			//위한 스트림을 얻는다.
			client = new TcpClient();
			client.Connect(MyNet.serverAddress, 1900);
			writeStream = client.GetStream();
		}
	}

	/// <summary>
	/// 서버가 무슨 말을 하는지 하염없이 듣는다.
	/// </summary>
	class ListenServer {
		TcpListener tcpListener = null;
		Socket clientsocket = null;
		NetworkStream stream = null;
		StreamReader reader = null;

		public void Run() {
			//IPAddress ipAd = IPAddress.Parse("192.168.0.34");

			IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 1901);
			tcpListener = new TcpListener(ipep);
			tcpListener.Start();
			try {

				clientsocket = tcpListener.AcceptSocket();
				stream = new NetworkStream(clientsocket);
				reader = new StreamReader(stream, System.Text.Encoding.UTF8);
				while (true) {
					//Console.WriteLine(str);
					//if (str.Equals("exit")) break;
					string reading = reader.ReadLine();
					Console.WriteLine(reading);
					Received.buffer.Push(NetString.Get(reading));
				}
			} catch (Exception e) {
				Console.WriteLine(e.ToString());
				//Console.WriteLine(e.ToString());
			} finally {
				clientsocket.Close();
			}
		}
	}


	/// <summary>
	/// 보낼 메세지를 쌓아두는 곳.
	/// 넣자마자 서버에게 전송된다.
	/// </summary>
	class StringWriter {
		public static LinkedList<NetString> buffer = new LinkedList<NetString>();

		public void SendString() {
			while (_MyNet.isServerRun) {
				if (buffer.Count > 0) {
					NetString str = buffer.ElementAt(0);
					buffer.RemoveFirst();
					//str을 보내야됨
					_MyNet._SendString(str);
				}
				Thread.Sleep(1);
			}
		}
	}

}
