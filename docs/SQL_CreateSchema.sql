CREATE DATABASE galeriaLelo;

USE galeriaLelo;

CREATE TABLE utilizador (
    user_id INT NOT NULL AUTO_INCREMENT,
    rua_fiscal VARCHAR(100) NOT NULL,
    cidade_fiscal VARCHAR(75) NOT NULL,
    codpostal_fiscal CHAR(8) NOT NULL,
    rua_entrega VARCHAR(100) NOT NULL,
    cidade_entrega VARCHAR(75) NOT NULL,
    codpostal_entrega CHAR(8) NOT NULL,
    foto VARBINARY(MAX), -- está inconsistente na foto do modelo lógico
    email VARCHAR(150) NOT NULL,
    username VARCHAR(25) NOT NULL,
    pass_hash BINARY(64) NOT NULL,
    data_registo DATETIME  NOT NULL,
    PRIMARY KEY  (user_id)
    -- criar indices???
); -- preciso mais alguma cena de engine e charset aqui???

CREATE TABLE sessao (
    sessao_id INT NOT NULL AUTO_INCREMENT,
    data_hora_inicio DATETIME NOT NULL,
    data_hora_fim DATETIME NOT NULL,
    user_id INT,
    PRIMARY KEY (sessao_id),
    CONSTRAINT FK_user_id_sessao FOREIGN KEY (user_id) 
        REFERENCES utilizador(user_id)
    -- foreign keys podem ser NULL ou têm de ser NOT NULL??
);

CREATE TABLE administador (
    admin_id INT NOT NULL AUTO_INCREMENT,
    email VARCHAR(150) NOT NULL,
    pass_hash BINARY(64) NOT NULL,
    PRIMARY KEY (admin_id)
);

CREATE TABLE leilao (
    leilao_id INT NOT NULL AUTO_INCREMENT,
    Data_hora_inicio DATETIME NOT NULL,
    Data_hora_fim DATETIME NOT NULL,
    estado VARCHAR(12) NOT NULL CHECK (estado IN('em leilao', 'por pagar', 'por enviar','por entregar','concluido')),
    preco_base FLOAT NOT NULL,
    custo_envio FLOAT NOT NULL,
    prod_nome_artista VARCHAR(75) NOT NULL,
    prod_comprimento FLOAT NOT NULL,
    prod_altura FLOAT NOT NULL,
    prod_largura FLOAT NOT NULL,
    prod_tipo VARCHAR(10) NOT NULL CHECK (prod_tipo IN('desenho','escultura','pintura','fotografia','outro')),
    prod_estado VARCHAR(10) NOT NULL CHECK (prod_estado IN('excelente','bom''mau','pessimo')),
    prod_tecnica VARCHAR(45) NOT NULL, -- n tá o tipo nas tabelas do overleaf
    prod_descricao VARCHAR(500) NOT NULL,
    prod_nome VARCHAR(75) NOT NULL,
    prod_peso FLOAT NOT NULL,
    admin_id INT,
    PRIMARY KEY (leilao_id),
    CONSTRAINT FK_admin_id_leilao FOREIGN KEY (admin_id) 
            REFERENCES administador(admin_id)
);

CREATE TABLE foto_leilao (
	foto_id INT NOT NULL AUTO_INCREMENT,
	foto LONGBLOB NOT NULL, # podiamos só guardar filePaths para isto??
	leilao_id INT,
    PRIMARY KEY (foto_id),
    CONSTRAINT FK_leilao_id_foto_leilao FOREIGN KEY (leilao_id)
        REFERENCES leilao(leilao_id) 
);

CREATE TABLE licitacao (
	licitacao_id INT NOT NULL AUTO_INCREMENT,
	valor FLOAT NOT NULL,
	data_hora DATETIME NOT NULL,
	sessao_id INT,
	leilao_id INT,
    PRIMARY KEY (licitacao_id),
    CONSTRAINT FK_sessao_id_licitacao FOREIGN KEY (sessao_id)
        REFERENCES sessao(sessao_id),
    CONSTRAINT FK_leilao_id_licitacao FOREIGN KEY (leilao_id)
        REFERENCES leilao(leilao_id) 
);

/*
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO
	CREATE TABLE [dbo].[foto_leilao](
		[id_fotoleilao] [int] NOT NULL,
		[foto] [varbinary](max) NOT NULL,
		[id_leilao] [int] NOT NULL,
	 CONSTRAINT [PK_foto_leilao] PRIMARY KEY CLUSTERED 
	(
		[id_fotoleilao] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	GO
	/****** Object:  Table [dbo].[licitacao]    Script Date: 15/11/2023 17:36:37 ******/
/*
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[licitacao](
	[licitacao_id] [int] NOT NULL,
	[valor] [float] NOT NULL,
	[data_hora] [datetime] NOT NULL,
	[id_sessao] [int] NOT NULL,
	[id_leilao] [int] NOT NULL,
 CONSTRAINT [PK_licitacao] PRIMARY KEY CLUSTERED 
(
	[licitacao_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
*/