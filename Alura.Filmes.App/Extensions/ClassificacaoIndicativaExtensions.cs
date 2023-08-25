using System.Collections.Generic;
using System.Linq;
using Alura.Filmes.App.Negocio;

namespace Alura.Filmes.App.Extensions
{
    public static class ClassificacaoIndicativaExtensions
    {
        private static Dictionary<string, ClassificacaoIndicativa> mapa = new Dictionary<string, ClassificacaoIndicativa>
        {
            { "G", ClassificacaoIndicativa.Livre },
            { "PG", ClassificacaoIndicativa.MaioresQue10 },
            { "PG-13", ClassificacaoIndicativa.MaioresQue13 },
            { "R", ClassificacaoIndicativa.MaioresQue14 },
            { "NC-17", ClassificacaoIndicativa.MaioresQue18 }
        };

        public static string ParaString(this ClassificacaoIndicativa valor)
        {
            return mapa.First(x => x.Value == valor).Key;
        }

        public static ClassificacaoIndicativa ParaInt(this string texto)
        {
            return mapa.First(x => x.Key == texto).Value;
        }
    }
}
