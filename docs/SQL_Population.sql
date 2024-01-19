-- Script de povoamento da base de dados

USE GaleriaLelo;
GO

INSERT INTO Utilizador (
    rua_fiscal, cidade_fiscal, codpostal_fiscal, rua_entrega, cidade_entrega, 
    codpostal_entrega, foto, email, username, pass_hash, data_registo
)
VALUES
    ('Rua de Cima 180 1ºE', 'Braga', '4700200', 'Rua de Baixo 163', 'Guimaraes', 
     '4530201', NULL, 'ronnyGamer@gmail.com', 'ronnyGamer12', 0x726F6E6E79, '2024-01-18T13:38:35'
    ),
    ('Rua do Beco 230 3ºD', 'Braga', '4123345', 'Rua do Barco 20', 'Aveiro', 
     '4123234', 'UserPhotos/farol1_user.png', 'aveiroForLife@gmail.com', 'aveirooo23', 0x61766569726F, '2024-01-08T10:24:12'
    );

INSERT INTO Sessao (data_hora_inicio, data_hora_fim, user_id)
VALUES
    ('2024-01-09T08:30:02', '2024-01-09T08:42:15', 1),
    ('2024-01-10T11:00:00', '2024-01-10T11:05:25', 2);

INSERT INTO Administador (email, pass_hash)
VALUES
    ('admin1@gmail.com', 0x),
    ('admin2@gmail.com', 0x);

INSERT INTO Leilao (
    Data_hora_inicio, Data_hora_fim, estado, preco_base, custo_envio, 
    prod_nome_artista, prod_comprimento, prod_altura, prod_largura, prod_tipo, 
    prod_estado, prod_tecnica, prod_descricao, prod_nome, prod_peso, admin_id
)
VALUES
    ('2024-01-05T08:30:00', '2024-02-12T20:30:00', 'Em Leilao', 250.00, 10.00, 
     'Leonardo Da Vinki', 15.00, 10.00, 8.00, 'Pintura', 
     'Excelente', 'Pintou, morreu, famosou', 'Descrição descritiva', 'Maconha Lisa', 
        200, 2
    ),
    ('2024-01-09T08:30:00', '2024-02-10T18:30:00', 'Em Leilao', 100.00, 15.00, 
     'Eduardo Muncha muito', 18.00, 20.00, 4.00, 'Pintura', 
     'Excelente', 'Gritou, Pintou', 'Descrição mais descritiva que a outra descrição', 'O grito louco', 
        140, 1
    ),
    ('2024-01-09T08:30:00', '2024-01-31T18:30:00', 'Em Leilao', 87.00, 20.00, 
     'Desconhecido', 40.00, 20.01, 15.2, 'Escultura', 
     'Bom', 'Esculpir madeira', 
     'Bela escultura de Mambila dos Camarões. O estilo é dominado, os volumes são bem tratados. O corpo é compacto e atarracado. O rosto é expressivo, suave e sensível. A sua presença é pacífica. O rosto apresenta resquícios de pigmentos brancos e vermelhos. O seu cocar é lindo, feito de pontas de madeira. A madeira está danificada em alguns lugares, os insetos atacaram-na, a madeira é sólida. Ver fotos. Vendido como está. Um lindo item de colecionador antigo e autêntico. Por volta de 1950.', 
     'Quadro Mambila, Camarões', 300, 1
    );

INSERT INTO Foto_leilao (foto, leilao_id)
VALUES
    ('AuctionPhotos/monalisa_foto1.jpg', 1),
    ('AuctionPhotos/grito_foto1.jpg', 2),
    ('AuctionPhotos/camaroes_foto1.png',3),
    ('AuctionPhotos/camaroes_foto2.png',3),
    ('AuctionPhotos/camaroes_foto3.png',3);

INSERT INTO Licitacao (valor, data_hora, sessao_id, leilao_id)
VALUES
    (250.00, '2024-01-09T08:33:02', 1, 1),
    (260.00, '2024-01-10T11:02:00', 2, 1),
    (150.00, '2024-01-09T08:31:23', 2, 2),
    (100.00, '2024-01-09T08:34:02', 1, 3),
    (105.20, '2024-01-10T11:04:00', 2, 3);


