using System;
using System.Threading;

namespace Ivory.TesteEstagio.CampoMinado
{
    class Program
    {
        static void Main(string[] args)
        {
            var campoMinado = new CampoMinado();
            Console.WriteLine("Início do jogo\n=========");
            Console.WriteLine(campoMinado.Tabuleiro);

            // Realize sua codificação a partir deste ponto, boa sorte!

            // Primeiro Passo = Achar a Localização das 10 Bombas existentes.

            int[,] MatrizAchaBombas = new int[9,9];

            // Percorrer a Matriz MatrizAchaBombas.         
            
            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    campoMinado.Abrir(i + 1, j + 1);                                     

                    if (campoMinado.JogoStatus == 2)
                    {
                        MatrizAchaBombas[i, j] = 1;
                        campoMinado = new CampoMinado();
                    }
                }
            }

            MostraCampo(MatrizAchaBombas);  
        }

        public static void MostraCampo(int[,] MatrizAchaBombas)
        {
            var campoMinado = new CampoMinado();

            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    if(MatrizAchaBombas[i, j] != 1) // Abrir somente as casas onde não foi encontrado as Bombas.
                    {
                        Console.Clear();

                        campoMinado.Abrir(i + 1, j + 1);

                        Console.WriteLine("Inicio do Jogo.");

                        Console.WriteLine("===========\n");

                        Console.WriteLine(campoMinado.Tabuleiro);

                        Console.WriteLine("\nAguarde...");

                        Thread.Sleep(55);
                    }
                }
                
            }

            if(campoMinado.JogoStatus == 1)
            {
                Console.WriteLine("\nVitoria, você encontrou todas as casas que não possui bomba. ");
            }

        }

    }
}

