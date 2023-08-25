﻿using System;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
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
                var sql = "INSERT INTO language (name) VALUES ('Teste 1'), ('Teste 2'), ('Teste 3')";
                var registros = contexto.Database.ExecuteSqlCommand(sql);
                Console.WriteLine($"total registros afetados {registros}");

                var deleteSql = "DELETE FROM language where name LIKE 'Teste%'";
                registros = contexto.Database.ExecuteSqlCommand(deleteSql);
                Console.WriteLine($"total registros afetados {registros}");
            }
        }

        private static void UsandoStoredProcedure()
        {
            using (var contexto = new AluraFilmesContexto())
            {
                var categ = "Action";
                var paramCateg = new SqlParameter("category_name", categ);
                var paramTotal = new SqlParameter
                {
                    ParameterName = "@total_actors",
                    Size = 4,
                    Direction = System.Data.ParameterDirection.Output
                };

                contexto.Database.ExecuteSqlCommand("total_actors_from_given_category @category_name, @total_actors OUT",
                    paramCateg, paramTotal);
                Console.WriteLine($"O total de atores na categoria {categ} é de {paramTotal.Value}");
            }
        }

        private static void SelectSemEntity()
        {
            using (var contexto = new AluraFilmesContexto())
            {
                var sql = @"select a.*
                            from actor a
                              inner join top5_most_starred_actors filmes on filmes.actor_id = a.actor_id";

                // var atoresMaisAtuantes = contexto.Atores.Include(x => x.Filmografia).OrderByDescending(x => x.Filmografia.Count).Take(5); -> gera um sql complexo e ineficiente
                var atoresMaisAtuantes = contexto.Atores.FromSql(sql).Include(x => x.Filmografia);
                foreach (var item in atoresMaisAtuantes)
                {
                    Console.WriteLine(
                        $"O ator: {item.PrimeiroNome + " " + item.UltimoNome} atuou em {item.Filmografia.Count} filmes");
                }
            }
        }

        private static void InclusaoFilme()
        {
            using (var contexto = new AluraFilmesContexto())
            {
                //var livre = ClassificacaoIndicativa.MaioresQue13;
                //Console.WriteLine(livre.ParaString());
                //Console.WriteLine("G".ParaInt());

                var idioma = new Idioma { Nome = "English" };

                var filme = new Filme();
                filme.Titulo = "mom";
                filme.Duracao = 110;
                filme.AnoLancamento = "2013";
                filme.Classificacao = ClassificacaoIndicativa.MaioresQue13;
                filme.IdiomaFalado = idioma;
                contexto.Entry(filme).Property("last_update").CurrentValue = DateTime.Now;

                contexto.Filmes.Add(filme);
                contexto.SaveChanges();

                var filmeInserido = contexto.Filmes.First(f => f.Titulo == "mom");
                Console.WriteLine(filmeInserido.Classificacao);
            }
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