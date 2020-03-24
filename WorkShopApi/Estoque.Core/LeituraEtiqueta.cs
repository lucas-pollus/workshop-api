using System;

namespace Estoque.Core
{
    public class LeituraEtiqueta
    {
        public int Id { get; set; }
        public string CodigoBarras { get; set; }
        public DateTime DataLeitura { get; set; }

        public LeituraEtiqueta(string codigoBarras)
        {
            CodigoBarras = codigoBarras;
            DataLeitura = DateTime.Now;
        }
    }
}
