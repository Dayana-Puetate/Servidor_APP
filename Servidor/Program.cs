using System;

namespace Servidor
{
    class Program
    {
        static void Main(string[] args)
        {
            Server s = new Server("localhost", 4000);
            s.iniciarCliente();
            Console.ReadKey();
        }
    }
}
