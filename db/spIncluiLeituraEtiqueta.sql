DELIMITER $$
DROP PROCEDURE IF EXISTS estoquedb.spIncluiLeituraEtiqueta $$
CREATE PROCEDURE estoquedb.spIncluiLeituraEtiqueta(IN codigo_barras VARCHAR(45),IN data_leitura datetime)
 BEGIN
 INSERT INTO estoquedb.LeiturasEtiquetas (CodigoBarras, DataLeitura) VALUES (codigo_barras, data_leitura);
 END$$
DELIMITER ;