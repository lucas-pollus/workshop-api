using Dapper;
using Estoque.Core.Util;
using System.Data;

namespace Estoque.Core
{
    public interface ILeituraEtiquetaRepository
    {
        void Salvar(LeituraEtiqueta leituraEtiqueta);
    }
    
    public sealed class LeituraEtiquetaRepository : ILeituraEtiquetaRepository
    {
        private readonly DbHelper _dbHelper;

        public LeituraEtiquetaRepository(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        
        public void Salvar(LeituraEtiqueta leituraEtiqueta)
        {
            _dbHelper
                .Connection
                .Execute("spIncluiLeituraEtiqueta", 
                new 
                { 
                    codigo_barras = leituraEtiqueta.CodigoBarras, 
                    data_leitura = leituraEtiqueta.DataLeitura 
                }, commandType: CommandType.StoredProcedure);
        }
    }
}
