using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP04.models
{
    class Livro
    {
        public Livro(string titulo, string autor, int id)
        {
            Titulo = titulo;
            Autor = autor;
            Id = id;
        }

        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Id { get; set; }
    }
}
