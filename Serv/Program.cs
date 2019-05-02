/*
 * Created by SharpDevelop.
 * User: Plyskay
 * Date: 9/13/2018
 * Time: 9:34 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Collections.Generic;

namespace Serv
{
	class Program
	{
		public static void Main(string[] args)
		{
			TcpListener serverSocket = new TcpListener(8888);
            int requestCount = 0;
            TcpClient clientSocket = default(TcpClient);
            serverSocket.Start();
            Console.WriteLine(" >> Server Started");
            clientSocket = serverSocket.AcceptTcpClient();
            Console.WriteLine(" >> Accept connection from client");
            requestCount = 0;
            while ((true))
            {
                try
                {
                    requestCount = requestCount + 1;
                    NetworkStream networkStream = clientSocket.GetStream();
                    byte[] bytesFrom = new byte[10025];
                    networkStream.Read(bytesFrom, 0, 10025);
                    string dataFromClient = Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    Console.WriteLine(" >> Data from client - " + dataFromClient);
//                    string serverResponse = "Last Message from client" + dataFromClient;
//                    Byte[] sendBytes = Encoding.ASCII.GetBytes(serverResponse);
//                    networkStream.Write(sendBytes, 0, sendBytes.Length);
//                    networkStream.Flush();
//                    Console.WriteLine(" >> " + serverResponse);
              //    if()
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            
            }

            clientSocket.Close();
            serverSocket.Stop();
            Console.WriteLine(" >> exit");
            //Console.ReadLine();
            
        }

    }
				
}