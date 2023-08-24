using System;
using System.Linq;
using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraFilmesContexto())
            {
                foreach (var item in contexto.Filmes)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void VizualizarAtores()
        {
            using (var contexto = new AluraFilmesContexto())
            {
                //listar os 10 atores modificados recentemente
                var atores = contexto.Atores.OrderByDescending(x => EF.Property<DateTime>(x, "last_update")).Take(10);
                foreach (var item in atores)
                {
                    Console.WriteLine(item + " - " + contexto.Entry(item).Property("last_update").CurrentValue);
                }
            }
        }

        private static void CriarEAdicionarAtor()
        {
            //select * from actor
            using (var contexto = new AluraFilmesContexto())
            {
                var ator = new Ator();
                ator.PrimeiroNome = "caju";
                ator.UltimoNome = "bom";
                //  contexto.Entry(ator).Property("last_update").CurrentValue = DateTime.Now; -> colocando no OnModelCreating: HasDefaultValue("getdate()")
                contexto.Atores.Add(ator);

                contexto.SaveChanges();
            }
        }
    }
}