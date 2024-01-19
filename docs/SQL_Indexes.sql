
-- DROP INDEX IX_SearchLeiloesParametros ON Leilao;

USE GaleriaLelo
GO
CREATE NONCLUSTERED INDEX IX_SearchLeiloesParametros
ON Leilao (prod_nome_artista, prod_nome, prod_tecnica, prod_tipo);

