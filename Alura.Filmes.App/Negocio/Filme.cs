using System.Collections.Generic;
using Alura.Filmes.App.Extensions;

namespace Alura.Filmes.App.Negocio
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public short Duracao { get; set; }
        public string AnoLancamento { get; set; }
        public string TextoClassificacao { get; private set; }

        public ClassificacaoIndicativa Classificacao
        {
            get { return TextoClassificacao.ParaInt(); }
            set { TextoClassificacao = value.ParaString(); }
        }
        public IList<FilmeAtor> Atores { get; set; }
        public IList<FilmeCategoria> Categorias { get; set; }
        public Idioma IdiomaFalado { get; set; }
        public Idioma IdiomaOriginal { get; set; }

        public Filme()
        {
            Atores = new List<FilmeAtor>();
        }

        public override string ToString()
        {
            return $"filme ({Id}): {Titulo} ({AnoLancamento}) - Duração: {Duracao}";
        }
    }
}
