using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Servidor
{
    class Server
    {
        IPHostEntry host;
        IPAddress ipAddr;
        IPEndPoint endPoint;

        Socket servidor;
        Socket cliente;

        public Server(string ip, int puerto)
        {
            host = Dns.GetHostEntry(ip);
            ipAddr = host.AddressList[0];
            endPoint = new IPEndPoint(ipAddr, puerto);

            servidor = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            //desde donde a a escuchar
            servidor.Bind(endPoint);
            //cuantas conexiones va a aceptar
            servidor.Listen(10);
        }
        public void iniciarCliente()
        {
            byte[] buffer;
            int finCadena;
            string mensaje;
            cliente = servidor.Accept();
            while (true)
            {
                buffer = new byte[1024];
                cliente.Receive(buffer);
                mensaje = Encoding.ASCII.GetString(buffer);
                finCadena = mensaje.IndexOf("\0");
                if (finCadena > 0)
                    mensaje = mensaje.Substring(0, finCadena);
                Console.WriteLine("Frase: " + mensaje);
                Console.WriteLine("Número de palabras: " + contarPalabras(mensaje));
                Console.WriteLine("Número de vocales: " + contarVocales(mensaje));
                Console.WriteLine("Número de consonantes: " + contarConsonante(mensaje));
            }
        }
        public static int contarPalabras(string frase)
        {
            int contador = 0;
            var arrayString = frase.Split(' ');
            foreach(string cadena in arrayString)
            {
                    contador++;
            }
            return contador;
        }

        public static int contarVocales(string frase)
        {
            int contador = 0;
            int j;
            int i;
            for (j = 0;j < frase.Length; j++)
            {
                i = frase[j];
                int c = char.ToLower((char)i);
                if ((c == 'a')| (c == 'e') | (c == 'i') | (c == 'o') | (c == 'u'))
                {
                    contador++;
                }
            }
            return contador;
        }

        public static int contarConsonante(string frase)
        {
            int contador = 0;
            int j;
            int i;
            for (j = 0; j < frase.Length; j++)
            {
                i = frase[j];
                int c = char.ToLower((char)i);
                if ((c == 'b') | (c == 'c') | (c == 'd') | (c == 'f') | (c == 'g')| 
                    (c == 'h') | (c == 'j') | (c == 'k') | (c == 'l') | (c == 'm')|
                    (c == 'n') | (c == 'p') | (c == 'q') | (c == 'r') | (c == 's')|
                    (c == 't') | (c == 'v') | (c == 'w') | (c == 'x') | (c == 'y')| (c == 'z'))
                {
                    contador++;
                }
            }
            return contador;
        }
    }
}
