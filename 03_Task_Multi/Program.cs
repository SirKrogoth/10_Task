using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _03_Task_Multi
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> lista = new List<Task>();

            lista.Add(Task.Factory.StartNew(Metodo01));
            lista.Add(Task.Factory.StartNew(Metodo01));
            lista.Add(Task.Factory.StartNew(Metodo01));
            lista.Add(Task.Factory.StartNew(Metodo01));
            lista.Add(Task.Factory.StartNew(Metodo01));

            Task.WaitAll(lista.ToArray());

            Console.WriteLine("Programa finalizado após execução de WaitAll.");

            Console.ReadKey();            

            string[] enderecos = new string[]{"http://www.google.com.br", "http://www.microsoft.com.br", "http://www.globoesporte.com.br"};

            var listaEnd = from end in enderecos select DownloadPagina(end);

            Task.WaitAll(listaEnd.ToArray());
        }

        public static void Metodo01()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Valor: " + i + " TaskID: " + Task.CurrentId);
            }
        }

        public async static Task DownloadPagina(string end)
        {
            WebClient web = new WebClient();

            string html = await web.DownloadStringTaskAsync(end);

            Console.WriteLine("Download realizado para página: " + end);

            Console.ReadKey();
        }
    }
}