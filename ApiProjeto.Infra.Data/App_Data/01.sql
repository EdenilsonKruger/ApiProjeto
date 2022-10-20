USE master
GO

CREATE DATABASE ApiProjeto
GO

USE ApiProjeto
GO

CREATE TABLE Pessoa (
    Pessoa_Id	  INT		   NOT NULL IDENTITY,
	Nome_Fantasia VARCHAR(255) NOT NULL,
	Cnpj_Cpf	  VARCHAR(20)  NOT NULL
	CONSTRAINT PK_Pessoa PRIMARY KEY CLUSTERED (Pessoa_Id)
);
GO

INSERT INTO Pessoa VALUES ('Filipe Leandro Renan Rocha', '39135821507');
INSERT INTO Pessoa VALUES ('Heloise Daiane Clarice Galvão', '82183766239');
INSERT INTO Pessoa VALUES ('Ester Emilly Joana Farias', '05221097567');
INSERT INTO Pessoa VALUES ('Rafaela Patrícia Isabella Silveira', '49122337733');
INSERT INTO Pessoa VALUES ('Felipe Murilo Novaes', '15662319227');
INSERT INTO Pessoa VALUES ('Martin Ruan César Silveira', '16590839077');
INSERT INTO Pessoa VALUES ('Márcia Joana Vera Pinto', '93435974958');
INSERT INTO Pessoa VALUES ('Yasmin Mariana Peixoto', '32877300293');
INSERT INTO Pessoa VALUES ('Renata Esther da Cruz', '09151632330');
INSERT INTO Pessoa VALUES ('Kauê Sérgio da Cunha', '25455448099');
GO