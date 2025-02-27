-- Criar banco
CREATE DATABASE loja;
GO

use loja;
GO

CREATE TABLE Categoria
(
	Id			int not null identity primary key,
	Nome		varchar(50) not null unique,
	Foto		varchar(200),
	ExibirHome	bit
);

CREATE TABLE Produto
(
	Id			int not null identity primary key,
	Nome		varchar(100) not null,
	Descricao	varchar(1000),
	CategoriaId	int not null,
	ValorCusto	numeric(10,2),
	ValorVenda	numeric(10,2) not null,
	QtdeEstoque	int not null default 0,
	Destaque	bit default 0,
	foreign key (CategoriaId) references Categoria(Id)
);

CREATE TABLE ProdutoFoto
(
	Id			int not null identity primary key,
	ProdutoId	int not null,
	Foto		varchar(200) not null,
	Descricao	varchar(100),
	foreign key (ProdutoId) references Produto(Id)
);