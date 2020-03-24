namespace Estoque.Core
{
    public interface IServicoLeituraEtiqueta
    {
        void SalvarLeituraEtiqueta(string codigoBarras);
    }
    
    public sealed class ServicoLeituraEtiqueta : IServicoLeituraEtiqueta
    {
        private readonly ILeituraEtiquetaRepository _leituraEtiquetaRepository;

        public ServicoLeituraEtiqueta(ILeituraEtiquetaRepository leituraEtiquetaRepository)
        {
            _leituraEtiquetaRepository = leituraEtiquetaRepository;
        }
        
        public void SalvarLeituraEtiqueta(string codigoBarras)
        {
            var leitura = new LeituraEtiqueta(codigoBarras);

            _leituraEtiquetaRepository.Salvar(leitura);
        }
    }
}
