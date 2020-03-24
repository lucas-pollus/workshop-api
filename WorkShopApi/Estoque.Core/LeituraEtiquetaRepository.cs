using Dapper;
using Estoque.Core.Util;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Estoque.Core
{
    public interface ILeituraEtiquetaRepository
    {
        void Salvar(LeituraEtiqueta leituraEtiqueta);
        List<LeituraEtiqueta> ObterLeiturasEtiquetas();
    }
    
    public sealed class LeituraEtiquetaRepository : ILeituraEtiquetaRepository
    {
        private readonly DbHelper _dbHelper;

        public LeituraEtiquetaRepository(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<LeituraEtiqueta> ObterLeiturasEtiquetas()
        {
            var query = @"SELECT Id
                               , CodigoBarras
                               , DataLeitura 
                            FROM LeiturasEtiquetas";
            return _dbHelper
                .Connection
                .Query<LeituraEtiqueta>(query)
                .ToList();
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
