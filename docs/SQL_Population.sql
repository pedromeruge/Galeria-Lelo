-- Script de povoamento da base de dados

USE GaleriaLelo;
GO

INSERT INTO Utilizador (
    rua_fiscal, cidade_fiscal, codpostal_fiscal, rua_entrega, cidade_entrega, 
    codpostal_entrega, foto, email, username, pass_hash, data_registo
)
VALUES
    ('Rua de Cima 180 1ºE', 'Braga', '4700200', 'Rua de Baixo 163', 'Guimaraes', 
     '4530201', NULL, 'ronnyGamer@gmail.com', 'ronnyGamer12', 'ronny', '2024-01-08T13:38:35'
    ),
    ('Rua do Beco 230 3ºD', 'Braga', '4123345', 'Rua do Barco 20', 'Aveiro', 
     '4123234', 'UserPhotos/farol1_user.png', 'aveiroForLife@gmail.com', 'aveirooo23', 'aveiroo', '2024-01-08T10:24:12'
    ),
	('Rua do Metro 180 1ºE', 'Porto', '4778400', 'Rua do Metro 180 1ºE', 'Porto', 
     '4778400', 'UserPhotos/farol1_user.png', 'rasteirinho@gmail.com', 'Macholo', 'soubig', '2024-01-09T17:32:27'
    ),
    ('Rua das Tocas  174 1ºD', 'Almada', '4393945', 'Rua das Tocas  230 3ºD', 'Almada', 
     '4393945', 'UserPhotos/farol1_user.png', 'gymBro@gmail.com', 'samuelmassas', '30faralho', '2024-01-10T21:14:13'
    ),
	('Rua dos Santinhos  24 1ºE', 'Fátima', '4384638', 'Rua dos Santinhos  24 1ºE', 'Fátima', 
     '4384638', 'UserPhotos/farol1_user.png', 'Jesusrocks@gmail.com', 'godalike', 'aialminhas', '2024-01-11T21:17:54'
    ),
    ('Rua das Andorinhas  17 1ºD', 'Braga', '4356538', 'Rua do Monte  32 1ºE', 'Braga', 
     '4356537', 'UserPhotos/farol1_user.png', 'zaza@gmail.com', 'blaze420', 'damelumemeumenino', '2024-01-11T13:21:01'
    );
	

INSERT INTO Sessao (data_hora_inicio, data_hora_fim, user_id)
VALUES
    ('2024-01-09T08:31:27', '2024-01-09T18:42:11', 1),
    ('2024-01-10T07:00:31', '2024-01-10T21:05:27', 2),
	('2024-01-10T08:11:12', '2024-01-10T18:32:15', 3),
    ('2024-01-11T06:03:32', '2024-01-11T22:45:23', 4),
	('2024-01-12T04:31:42', '2024-01-12T19:57:34', 5),
    ('2024-01-12T07:05:37', '2024-01-12T17:23:42', 6),
	('2024-01-13T09:13:12', '2024-01-13T19:47:33', 2),
	('2024-01-13T07:21:22', '2024-01-13T17:47:54', 5),
    ('2024-01-14T05:15:37', '2024-01-14T17:51:17', 4);

INSERT INTO Administrador (email, pass_hash)
VALUES
    ('admin1@gmail.com', 'admin1'),
    ('admin2@gmail.com', 'admin2');

INSERT INTO Leilao (
    Data_hora_inicio, Data_hora_fim, estado, preco_base, custo_envio, 
    prod_nome_artista, prod_comprimento, prod_altura, prod_largura, prod_tipo, 
    prod_estado, prod_tecnica, prod_descricao, prod_nome, prod_peso, admin_id
)
VALUES
    ('2024-01-05T08:30:00', '2024-02-12T20:30:00', 'em_leilao', 100.00, 10.00, 
     'Leonardo Da Vinki', 15.00, 10.00, 8.00, 'pintura', 
     'excelente', 'Sfumato', 'Seu sorriso sutil e olhar cativante convidam à reflexão em meio à técnica sfumato, criando uma aura de mistério atemporal', 'Mona Grossa', 
        200, 2
    ),
    ('2024-01-09T08:30:00', '2024-02-10T18:30:00', 'em_leilao', 100.00, 15.00, 
     'Eduardo Muncha muito', 18.00, 20.00, 4.00, 'pintura', 
     'excelente', 'Têmpera', 'Uma explosão de angústia capturada em cores vibrantes e formas distorcidas, refletindo a intensidade da condição humana', 'O grito louco', 
        140, 1
    ),
    ('2024-01-09T08:30:00', '2024-01-31T18:30:00', 'em_leilao', 87.00, 20.00, 
     'Desconhecido', 40.00, 20.01, 15.2, 'escultura', 
     'bom', 'Entalhe', 
     'Bela escultura de Mambila dos Camarões. O estilo é dominado, os volumes são bem tratados. O corpo é compacto e atarracado. O rosto é expressivo, suave e sensível. A sua presença é pacífica. O rosto apresenta resquícios de pigmentos brancos e vermelhos. O seu cocar é lindo, feito de pontas de madeira. A madeira está danificada em alguns lugares, os insetos atacaram-na, a madeira é sólida. Ver fotos. Vendido como está. Um lindo item de colecionador antigo e autêntico. Por volta de 1950.', 
     'Quadro Mambila, Camarões', 300, 1
    ),
    ('2024-01-09T08:30:00', '2024-01-30T18:30:00', 'concluido', 87.00, 20.00, 
     'Desconhecido', 40.00, 20.01, 15.2, 'escultura', 
     'bom', 'Entalhe', 
     'Bela escultura de Mambila dos Camarões. O estilo é dominado, os volumes são bem tratados. O corpo é compacto e atarracado. O rosto é expressivo, suave e sensível. A sua presença é pacífica. O rosto apresenta resquícios de pigmentos brancos e vermelhos. O seu cocar é lindo, feito de pontas de madeira. A madeira está danificada em alguns lugares, os insetos atacaram-na, a madeira é sólida. Ver fotos. Vendido como está. Um lindo item de colecionador antigo e autêntico. Por volta de 1950.', 
     'Quadro Mambila, Camarões', 300, 1
    ),
	('2024-01-09T08:30:00', '2024-01-31T18:30:00', 'em_leilao', 87.00, 20.00, 
     'Bianca', 15.00, 10.00, 8.00, 'pintura', 
     'excelente', 'Afresco seco', 
     'Um frenesi de formas e cores entrelaça-se neste quadro, onde sete homens, uma mulher e uma criança emergem como elementos vibrantes de uma sinfonia visual, transcendendo as fronteiras da individualidade para criar uma expressão única de coletividade', 'Convivio', 200, 1
    ),
	('2024-01-09T08:30:00', '2024-01-31T18:30:00', 'em_leilao', 87.00, 20.00, 
     'lutadéro', 15.00, 10.00, 8.00, 'outro', 
     'bom', 'Entalhe', 
     'Um pequeno escudo tribal africano, intrincadamente entalhado, exibe uma dança caleidoscópica de padrões geométricos, simbolizando a conexão sagrada entre atradição, a comunidade e a espiritualidade.','Escudo tribal africano', 200, 1
    ),
	('2024-01-09T08:30:00', '2024-01-31T18:30:00', 'em_leilao', 87.00, 20.00, 
     'Gaby', 15.00, 10.00, 8.00, 'pintura', 
     'excelente', 'Grisalha', 
     'Um homem religioso diante de um crucifixo, cercado por uma caveira, chicote e água benta, explora a complexidade entre penitência e redenção','la barranquilha', 200, 1
    ),
	('2024-01-09T08:30:00', '2024-01-31T18:30:00', 'em_leilao', 87.00, 20.00, 
     'Picollo', 15.00, 10.00, 8.00, 'pintura', 
     'bom', 'Sfumato', 
     'lamento silencioso, um quadro que ecoa a tristeza intemporal','la llorona', 200, 1
    ),
	('2024-01-09T08:30:00', '2024-01-31T18:30:00', 'em_leilao', 87.00, 20.00, 
     'Desconhecido', 15.00, 10.00, 8.00, 'outro', 
     'bom', 'Entalhe', 
     'banco xpto','sentocu', 200, 1
    ),
	('2024-01-09T08:30:00', '2024-01-31T18:30:00', 'por_pagar', 87.00, 20.00, 
     'shinji ping', 15.00, 10.00, 8.00, 'pintura', 
     'bom', 'Sumi-e', 
     'Um quadro japonês capta a intensidade de três pássaros em luta, enquanto um terceiro espelha a passividade do zé povinho','uccellinos', 200, 1
    ),
	('2024-01-09T08:30:00', '2024-01-31T18:30:00', 'por_entregar', 87.00, 20.00, 
     'Sun Tzu', 15.00, 10.00, 8.00, 'outro', 
     'mau', 'Forjar', 
     'Uma armadura samurai, testemunha silenciosa de bravura e tradição','ultimo samurai', 200, 1
    );

INSERT INTO Foto_leilao (foto, leilao_id)
VALUES
    ('AuctionPhotos/monalisa_foto1.jpg', 1),
    ('AuctionPhotos/grito_foto1.jpg', 2),
    ('AuctionPhotos/camaroes_foto1.png',3),
    ('AuctionPhotos/camaroes_foto2.png',3),
    ('AuctionPhotos/camaroes_foto3.png',3),
    ('AuctionPhotos/camaroes_foto1.png',4),
	('AuctionPhotos/convivio_foto1.png',5),
	('AuctionPhotos/escudo_tribal_africano_foto1.png',6),
	('AuctionPhotos/la_barranquilha_foto1.png',7),
	('AuctionPhotos/la_llorona_foto1.png',8),
	('AuctionPhotos/sentocu_foto1.png',9),
    ('AuctionPhotos/uccellinos_foto1.png',10),
    ('AuctionPhotos/ultimo_samurai_foto1.png',11);

INSERT INTO Licitacao (valor, data_hora, sessao_id, leilao_id)
VALUES
    (250.00, '2024-01-09T10:33:02', 1, 1),
    (260.00, '2024-01-10T11:02:00', 2, 1),
    (270.00, '2024-01-10T11:03:02', 3, 1),
    (150.00, '2024-01-09T10:31:23', 2, 2),
    (100.00, '2024-01-09T10:34:02', 1, 3),
    (105.20, '2024-01-10T11:04:00', 2, 3),
    (120.20,'2024-01-09T11:04:00', 1, 4),
	(250.00, '2024-01-12T10:33:02', 6, 5),
    (260.00, '2024-01-11T11:02:00', 4, 6),
    (270.00, '2024-01-13T11:03:02', 2, 7),
    (150.00, '2024-01-09T10:31:23', 2, 8),
    (100.00, '2024-01-09T10:34:02', 1, 9),
    (105.20, '2024-01-10T11:04:00', 3, 9),
    (120.20,'2024-01-09T11:04:00', 1, 10),
	(250.00, '2024-01-09T10:33:02', 1, 11),
    (260.00, '2024-01-13T11:02:00', 5, 5),
    (270.00, '2024-01-12T11:03:02', 5, 6),
    (280.00, '2024-01-14T10:31:23', 4, 7),
    (115.20, '2024-01-13T11:04:00', 5, 9),
    (130.20,'2024-01-14T11:04:00', 4, 4);
