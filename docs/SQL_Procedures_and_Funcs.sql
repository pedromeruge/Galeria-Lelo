USE GaleriaLelo
GO

-- Devolver leilões que satisfazem pesquisa de barra de pesquisa do site
CREATE PROCEDURE SearchAuctionsWithInput
    @SearchTerm NVARCHAR(MAX)
AS
BEGIN 
    SELECT 
        leilao_id AS IdLeilao,
        Data_hora_inicio,
        Data_hora_fim,
        estado,
        preco_base,
        custo_envio,
        prod_nome_artista AS Nome_artista,
        prod_comprimento,
        prod_altura,
        prod_largura,
        prod_tipo,
        prod_estado,
        prod_tecnica,
        prod_descricao,
        prod_nome,
        prod_peso,
        admin_id AS IdAdmin
    FROM Leilao 
    WHERE EXISTS (
        SELECT 1
        FROM STRING_SPLIT(@SearchTerm,' ') AS SearchTerm -- partir a string de input em palavras
        CROSS APPLY ( -- combinar subqueries que vêm nome do autor, nome da obra, tecnica
            SELECT prod_nome_artista AS ColumnValue
            UNION 
            SELECT prod_nome
            UNION
            SELECT prod_tecnica
        ) AS ColumnsToSearch
        WHERE EXISTS (
            SELECT 1
            FROM STRING_SPLIT(ColumnsToSearch.ColumnValue, ' ') AS WordInColumn -- ver se alguma palavra de alguma das subqueries dá match com as palavras de input
            WHERE WordInColumn.Value LIKE '%' + SearchTerm.value + '%'
        )
        OR prod_tipo LIKE '%' + SearchTerm.value + '%' -- verificar também se alguma palavra de input indica o tipo (pré-definido) do objeto do leilao
    );
END;

-- EXEC SearchAuctionsWithInput 'grito';

CREATE NONCLUSTERED INDEX IX_SearchLeiloesParametros
ON Leilao (prod_nome_artista, prod_nome, prod_tecnica, prod_tipo);
