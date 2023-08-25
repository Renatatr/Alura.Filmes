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
            ListarFilmesPorIdioma(); 
        }

        private static void ListarFilmesPorIdioma()
        {
            using (var contexto = new AluraFilmesContexto())
            {

                var idiomas = contexto.Idiomas.Include(x => x.FilmesFalados);
                foreach (var item in idiomas)
                {
                    Console.WriteLine(item);
                    foreach (var item1 in item.FilmesFalados)
                    {
                        Console.WriteLine(item1);
                    }
                    Console.WriteLine("");
                }

                //var filmes = contexto.Filmes.Include(x => x.IdiomaFalado);
                //foreach (var item in filmes)
                //{
                //    Console.WriteLine(item);
                //    Console.WriteLine(item.IdiomaOriginal);

                //}
            }
        }

        private static void ListarFilmeCategoria()
        {
            using (var contexto = new AluraFilmesContexto())
            {
                var filme = contexto.Filmes.Include(c => c.Categorias).ThenInclude(fc => fc.Categoria).First();
                Console.WriteLine($"Categoria do filme {filme}:");
                foreach (var item in filme.Categorias)
                {
                    Console.WriteLine(item.Categoria);
                }

                //var categorias = contexto.Categorias.Include(c => c.Filmes).ThenInclude(fc => fc.Filme);
                //foreach (var c in categorias)
                //{
                //    Console.WriteLine("");
                //    Console.WriteLine($"Filmes da categoria {c}:");
                //    foreach (var fc in c.Filmes)
                //    {
                //        Console.WriteLine(fc.Filme);
                //    }
                //}
            }
        }

        private static void LeituraAtoresDeUmFilme()
        {
            using (var contexto = new AluraFilmesContexto())
            {
                var filme = contexto.Filmes.Include(a => a.Atores).ThenInclude(fa => fa.Ator).First();
                Console.WriteLine($"Elenco do filme {filme}:");
                foreach (var item in filme.Atores)
                {
                    Console.WriteLine(item.Ator);
                }
            }
        }

        private static void LeituraFilmaAtor()
        {
            using (var contexto = new AluraFilmesContexto())
            {
                foreach (var item in contexto.Elenco)
                {
                    var entidade = contexto.Entry(item);
                    var filmeId = entidade.Property("film_id").CurrentValue;
                    var actoriD = entidade.Property("actor_id").CurrentValue;
                    var lastUpdate = entidade.Property("last_update").CurrentValue;

                    Console.WriteLine($"Filme: {filmeId}, Ator: {actoriD}, LastUpdate: {lastUpdate}");
                }
            }
        }

        private static void LeituraFilmes()
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