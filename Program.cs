using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;

namespace Braille.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Braille Display";
            //Connect to device on serial port 
            SerialPort serialPort = Connect();
            //When data is received(Event) from console Transmission is performed
            while (true)
            { 
                string data = Console.ReadLine();
                int [] Number = new int[8];
                for (int i = 0; i < 8; i+=2)
                {
                    switch (data[i])
                    { 
                        case 'a':
                            Number[i] = 1;
                            Number[i + 1] = 0;
                            break;
                        case 'b':
                            Number[i] = 4;
                            Number[i + 1] = 0;
                            break;
                        case 'c':
                            Number[i] = 1;
                            Number[i + 1] = 1;
                            break;
                        case 'd':
                            Number[i] = 1;
                            Number[i + 1] = 4;
                            break;
                        case 'e':
                            Number[i] = 1;
                            Number[i + 1] = 2;
                            break;
                        case 'f':
                            Number[i] = 4;
                            Number[i + 1] = 1;
                            break;
                        case 'g':
                            Number[i] = 4;
                            Number[i + 1] = 4;
                            break;
                        case 'h':
                            Number[i] = 4;
                            Number[i + 1] = 2;
                            break;
                        case 'i':
                            Number[i] = 2;
                            Number[i + 1] = 1;
                            break;
                        case 'j':
                            Number[i] = 2;
                            Number[i + 1] = 4;
                            break;
                        case 'k':
                            Number[i] = 5;
                            Number[i + 1] = 0;
                            break;
                        case 'l':
                            Number[i] = 7;
                            Number[i + 1] = 0;
                            break;
                        case 'm':
                            Number[i] = 5;
                            Number[i + 1] = 1;
                            break;
                        case 'n':
                            Number[i] = 5;
                            Number[i + 1] = 4;
                            break;
                        case 'o':
                            Number[i] = 5;
                            Number[i + 1] = 2;
                            break;
                        case 'p':
                            Number[i] = 7;
                            Number[i + 1] = 1;
                            break;
                        case 'q':
                            Number[i] = 7;
                            Number[i + 1] = 4;
                            break;
                        case 'r':
                            Number[i] = 7;
                            Number[i + 1] = 2;
                            break;
                        case 's':
                            Number[i] = 6;
                            Number[i + 1] = 1;
                            break;
                        case 't':
                            Number[i] = 7;
                            Number[i + 1] = 4;
                            break;
                        case 'u':
                            Number[i] = 5;
                            Number[i + 1] = 3;
                            break;
                        case 'v':
                            Number[i] = 7;
                            Number[i + 1] = 3;
                            break;
                        case 'w':
                            Number[i] = 2;
                            Number[i + 1] = 7;
                            break;
                        case 'x':
                            Number[i] = 5;
                            Number[i + 1] = 5;
                            break;
                        case 'y':
                            Number[i] = 5;
                            Number[i + 1] = 7;
                            break;
                        case 'z':
                            Number[i] = 5;
                            Number[i + 1] = 6;
                            break;
                        case ' ':
                            Number[i] = 0;
                            Number[i + 1] = 0;
                            break;
                        case ',':
                            Number[i] = 2;
                            Number[i + 1] = 0;
                            break;
                        case ';':
                            Number[i] = 6;
                            Number[i + 1] = 0;
                            break;
                        case ':':
                            Number[i] = 2;
                            Number[i + 1] = 2;
                            break;
                        case '.':
                            Number[i] = 2;
                            Number[i + 1] = 6;
                            break;
                        case '?':
                            Number[i] = 6;
                            Number[i + 1] = 3;
                            break;
                        case '!':
                            Number[i] = 6;
                            Number[i + 1] = 2;
                            break;
                        case '\'':
                            Number[i] = 3;
                            Number[i + 1] = 0;
                            break;
                        case '-':
                            Number[i] = 3;
                            Number[i + 1] = 3;
                            break;
                    }
                }
                string result = string.Join("", Number);
                serialPort.Write(result);
                Console.WriteLine("");
            }
        }

        private static SerialPort Connect()
        {
            //Connect to COM3 at 9600 baud rate
            SerialPort serialPort = new SerialPort(portName: "COM3", baudRate: 9600);   
            serialPort.Open();
            Console.WriteLine("Connected to {0}", serialPort.PortName);
            return serialPort;
        }

        private static void Disconnect(SerialPort serialPort)
        {
            serialPort.Close();
            serialPort.Dispose();
        }
    }
}
