USE GaleriaLelo
GO

-- Devolver leilões que satisfazem pesquisa de barra de pesquisa do site
CREATE PROCEDURE SearchAuctionsWithInput
    @SearchTerm NVARCHAR(MAX)
AS
BEGIN 
    SELECT 
        leilao_id AS IdLeilao,
        Data_hora_inicio AS DataInicio,
        Data_hora_fim AS DataFim,
        estado AS Leilao_estado, 
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
GO

CREATE PROCEDURE FindAllAuctionsFromUserInState
    @User_id INT,
    @Estado VARCHAR(12)
AS
BEGIN 
    SELECT 
        l.leilao_id AS IdLeilao,
        l.Data_hora_inicio AS DataInicio,
        l.Data_hora_fim As DataFim,
        l.estado AS Leilao_estado,
        l.preco_base,
        l.custo_envio,
        l.prod_nome_artista AS Nome_artista,
        l.prod_comprimento,
        l.prod_altura,
        l.prod_largura,
        l.prod_tipo,
        l.prod_estado,
        l.prod_tecnica,
        l.prod_descricao,
        l.prod_nome,
        l.prod_peso,
        l.admin_id AS IdAdmin
    FROM Leilao AS l
    CROSS APPLY ( -- aplica subquery a cada entrada de tabela leilao
        SELECT TOP 1 lic.valor, lic.data_hora, lic.leilao_id
        FROM Licitacao AS lic 
        INNER JOIN Sessao AS s ON lic.sessao_id = s.sessao_id
            WHERE s.user_id = @User_id AND lic.leilao_id = l.leilao_id
            ORDER BY lic.data_hora DESC
    ) AS latestBid
    WHERE l.estado = @Estado
    ORDER BY latestBid.data_hora DESC;
END;
GO

-- DROP PROCEDURE FindAllAuctionsFromUserInState;
-- EXEC FindAllAuctionsFromUserInState 2,em_leilao; 

CREATE FUNCTION dbo.GetHighestBidFromUser
(
    @IdLeilao INT,
    @IdUser INT
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    DECLARE @HighestBid DECIMAL(10,2)

    SELECT @HighestBid = MAX(valor)
        FROM Licitacao As lic
        INNER JOIN Sessao AS s ON lic.sessao_id = s.sessao_id 
            WHERE leilao_id = @IdLeilao AND s.user_id = @IdUser
    RETURN ISNULL(@HighestBid, 0)
END;
GO

CREATE FUNCTION dbo.GetHighestBid
(
    @IdLeilao INT
)
RETURNS DECIMAL(10,2)
AS
BEGIN
    DECLARE @HighestBid DECIMAL(10,2)

    SELECT @HighestBid = MAX(valor)
        FROM Licitacao
        WHERE leilao_id = @IdLeilao

    RETURN ISNULL(@HighestBid, 0)
END;
GO

CREATE FUNCTION dbo.GetLucrosEntre
(
    @DataInicio DATETIME,
    @DataFim DATETIME
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @LucroTotal DECIMAL(10, 2)

    SELECT @LucroTotal = SUM(dbo.GetHighestBid(leilao_id) * 0.2)
    FROM Leilao
    WHERE estado IN ('por entregar', 'concluido')
        AND Data_hora_fim >= @DataInicio
        AND Data_hora_fim <= @DataFim

    RETURN ISNULL(@LucroTotal, 0)
END;
GO

CREATE FUNCTION dbo.GetMediaLucrosEntre
(
    @DataInicio DATETIME,
    @DataFim DATETIME
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @LucroMedio DECIMAL(10, 2)

    SELECT @LucroMedio = AVG(dbo.GetHighestBid(leilao_id) * 0.2)
    FROM Leilao
    WHERE estado IN ('por entregar', 'concluido')
        AND Data_hora_fim >= @DataInicio
        AND Data_hora_fim <= @DataFim

    RETURN ISNULL(@LucroMedio, 0)
END;
GO

CREATE FUNCTION dbo.GetMediaLicitacoesEntre
(
    @DataInicio DATETIME,
    @DataFim DATETIME
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @MediaLicitacoes DECIMAL(10, 2)

    SELECT @MediaLicitacoes = AVG(dbo.GetHighestBid(leilao_id))
    FROM Leilao
    WHERE estado IN ('por entregar', 'concluido')
        AND Data_hora_fim >= @DataInicio
        AND Data_hora_fim <= @DataFim

    RETURN ISNULL(@MediaLicitacoes, 0)
END;
GO

--obter o tipo de artigo mais vendido entre duas datas
CREATE FUNCTION dbo.GetTipoMaisPopularEntre
(
    @DataInicio DATETIME,
    @DataFim DATETIME
)
RETURNS VARCHAR(10)
AS
BEGIN
    DECLARE @TipoResultado VARCHAR(10)

    SELECT TOP 1 @TipoResultado = prod_tipo
    FROM Leilao
    WHERE estado = 'concluido'
        AND Data_hora_fim >= @DataInicio
        AND Data_hora_fim <= @DataFim
        GROUP BY prod_tipo
        ORDER BY COUNT(*) DESC
    RETURN ISNULL(@TipoResultado,'');
END;
GO

--obter o estado de artigo mais vendido entre duas datas
CREATE FUNCTION dbo.GetEstadoMaisPopularEntre
(
    @DataInicio DATETIME,
    @DataFim DATETIME
)
RETURNS VARCHAR(10)
AS
BEGIN
    DECLARE @EstadoResultado VARCHAR(10)

    SELECT TOP 1 @EstadoResultado = prod_estado
    FROM Leilao
    WHERE estado = 'concluido'
        AND Data_hora_fim >= @DataInicio
        AND Data_hora_fim <= @DataFim
        GROUP BY prod_estado
        ORDER BY COUNT(*) DESC
    RETURN ISNULL(@EstadoResultado,'');
END;
GO

-- EXEC SearchAuctionsWithInput 'grito';

-- Select * FROM Leilao; WHERE estado='concluido';
-- UPDATE Leilao SET estado='concluido' WHERE leilao_id=15;
-- SELECT * FROM Leilao WHERE estado='concluido';