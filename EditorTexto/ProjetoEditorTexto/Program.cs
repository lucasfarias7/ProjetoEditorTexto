using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoEditorTexto
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{Menu()}\n");
            Console.Write("Informe o que deseja: ");
            short val = Convert.ToInt16(Console.ReadLine());

            Escolher(val);
            Console.ReadLine();
        }

        static void Escolher(short val)
        {
            switch (val)
            {
                case 0: Environment.Exit(0); break;
                case 1: AbrirArquivo(); break;
                case 2: CriarArquivo(); break;
                default: FinalizarPrograma(); break;
            }
        }

        static void FinalizarPrograma()
        {
            Console.WriteLine("Programa finalizado!");
        }

        static void CriarArquivo()
        {
            TextoInicial();
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            SalvarArquivo(text);
        }

        static void SalvarArquivo(string text)
        {
            Thread.Sleep(2000);
            Console.WriteLine("\nInforme o caminho que voce quer salvar o texto");
            string path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo salvo com sucesso no caminho {path}");
        }

        static void TextoInicial()
        {
            Console.WriteLine("Digite seu texto abaixo");
            Console.WriteLine("---------------------");
        }

        static void AbrirArquivo()
        {
            Console.Clear();
            Console.WriteLine("Qual caminho do arquivo que voce quer ler? ");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string conteudo = file.ReadToEnd();
                Console.WriteLine(conteudo);
            }
        }

        static string Menu()
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Escolha uma opção abaixo.");
            sb.AppendLine("1 - Abrir Arquivo");
            sb.AppendLine("2 - Criar novo arquivo");
            sb.AppendLine("0 - Sair");

            return sb.ToString();
        }
    }
}
