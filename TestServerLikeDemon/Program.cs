﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestServerLikeDemon
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread thread = Thread.CurrentThread;
            thread.Name = "АЦЦЦКИЙ ВИРУЗ";
            //Установка
            const string ip = "192.168.0.104";
            const int port = 8080;

            string openUrl = "https://zombie-film.com/serial-sverhestestvennoe-sezon-8-seriya-10";

            IPEndPoint tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            /// <summary>
            /// 1.param AddressFamily.InterNetwork - использование протокола IP4 версии
            /// 2.SocketType.Stream  - Потоковы тип данных
            /// 3.ProtocolType.Tcp - протокрол TCP
            /// </summary>
            Socket tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpSocket.Bind(tcpEndPoint);//привязывает сокет к локальному адресу, после чего может ожидать входяших соединений
            tcpSocket.Listen(1);//Слушаем запросы входящего (в данном случае) соединения
            StringBuilder data = new StringBuilder();

            while (true)
            {
                Socket listener = tcpSocket.Accept(); //Принимаем входящее соединение на наш сокет (Спасибо Эрриксон)
                byte[] buffer = new byte[255]; //размер буффера для приёма данных
                int size = 0;


                do
                {
                    size = listener.Receive(buffer); //запишем количество полученных байт
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));


                } while (listener.Available > 0);//проверка  что мы получили запрос (цикл с постусловием)

                //Console.Title = "Server";
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine(data);
                MessageBox.Show("АТАКАУЮТ ХАЦКЕРЫ");
                //Process.Start("firefox", "https://zombie-film.com/serial-sverhestestvennoe-sezon-8-seriya-10");
                //Process.Start("cmd", "/c shutdown -s -f -t 00");
                //listener.Shutdown(SocketShutdown.Both);
                //listener.Close();
            }
        }
    }
}
