using System;
using Alura.Filmes.App.Dados;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //select * from actor
            using (var contexto = new AluraFilmesContexto())
            {
                foreach (var item in contexto.Atores) {
                    Console.WriteLine(item);
                }
            }
        }
    }
}