-- USE master;
-- GO

-- ALTER DATABASE GaleriaLelo
-- SET SINGLE_USER
-- WITH ROLLBACK IMMEDIATE;

-- DROP DATABASE GaleriaLelo; 
-- GO


CREATE DATABASE GaleriaLelo;
GO

USE GaleriaLelo;
GO

CREATE TABLE Utilizador (
    user_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    rua_fiscal VARCHAR(100) NOT NULL,
    cidade_fiscal VARCHAR(75) NOT NULL,
    codpostal_fiscal CHAR(7) NOT NULL,
    rua_entrega VARCHAR(100) NOT NULL,
    cidade_entrega VARCHAR(75) NOT NULL,
    codpostal_entrega CHAR(8) NOT NULL,
    foto VARCHAR(150),
    email VARCHAR(150) NOT NULL,
    username VARCHAR(25) NOT NULL,
    pass_hash VARCHAR(64) NOT NULL,
    data_registo DATETIME NOT NULL
);

CREATE TABLE Sessao (
    sessao_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    data_hora_inicio DATETIME NOT NULL,
    data_hora_fim DATETIME,
    user_id INT,
    CONSTRAINT FK_user_id_sessao FOREIGN KEY (user_id) 
        REFERENCES Utilizador(user_id)
);

-- Create the Administrador table
CREATE TABLE Administrador (
    admin_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    email VARCHAR(150) NOT NULL,
    pass_hash VARCHAR(64) NOT NULL
);

CREATE TABLE Leilao (
    leilao_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Data_hora_inicio DATETIME NOT NULL,
    Data_hora_fim DATETIME NOT NULL,
    estado VARCHAR(12) NOT NULL CHECK (estado IN('em_leilao', 'por_pagar', 'por_enviar','por_entregar','concluido')),
    preco_base DECIMAL(10,2) NOT NULL,
    custo_envio DECIMAL(10,2) NOT NULL,
    prod_nome_artista VARCHAR(75) NOT NULL,
    prod_comprimento DECIMAL(10,5) NOT NULL,
    prod_altura DECIMAL(10,5) NOT NULL,
    prod_largura DECIMAL(10,5) NOT NULL,
    prod_tipo VARCHAR(10) NOT NULL CHECK (prod_tipo IN('desenho','escultura','pintura','fotografia','outro')),
    prod_estado VARCHAR(10) NOT NULL CHECK (prod_estado IN('excelente','bom','mau','pessimo')),
    prod_tecnica VARCHAR(45) NOT NULL,
    prod_descricao VARCHAR(500) NOT NULL,
    prod_nome VARCHAR(75) NOT NULL,
    prod_peso DECIMAL(10,2) NOT NULL,
    admin_id INT,
    CONSTRAINT FK_admin_id_leilao FOREIGN KEY (admin_id) 
        REFERENCES Administrador(admin_id)
);

-- Create the Foto_leilao table
CREATE TABLE Foto_leilao (
    foto_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    foto VARCHAR(150) NOT NULL,
    leilao_id INT,
    CONSTRAINT FK_leilao_id_foto_leilao FOREIGN KEY (leilao_id)
        REFERENCES Leilao(leilao_id)
);

CREATE TABLE Licitacao (
    licitacao_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    valor DECIMAL(10,2) NOT NULL,
    data_hora DATETIME NOT NULL,
    sessao_id INT,
    leilao_id INT,
    CONSTRAINT FK_sessao_id_licitacao FOREIGN KEY (sessao_id)
        REFERENCES Sessao(sessao_id),
    CONSTRAINT FK_leilao_id_licitacao FOREIGN KEY (leilao_id)
        REFERENCES Leilao(leilao_id)
);
