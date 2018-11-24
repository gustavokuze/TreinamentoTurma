CREATE DATABASE treinamento;
USE treinamento;

CREATE TABLE usuario(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Codigo INT NOT NULL,
	Senha VARCHAR(30) NOT NULL,
);

CREATE TABLE aluno(
	IdUsuario INT PRIMARY KEY NOT NULL , 
	Nome VARCHAR(30) NOT NULL,
	Email VARCHAR(30) NOT NULL,
	DataNascimento DATETIME NOT NULL,
	Telefone VARCHAR(15) NOT NULL,
	Endereco VARCHAR(50) NOT NULL,
	CONSTRAINT fk_usuario_aluno FOREIGN KEY (IdUsuario) REFERENCES usuario(Id)
);

CREATE TABLE professor(
	IdUsuario INT PRIMARY KEY NOT NULL ,
	Nome VARCHAR(30) NOT NULL,
	Cpf VARCHAR(15) NOT NULL,
	Telefone VARCHAR(15) NOT NULL,
	Endereco VARCHAR(50) NOT NULL,
	CONSTRAINT fk_usuario_professor FOREIGN KEY (IdUsuario) REFERENCES usuario(Id)
);

CREATE TABLE turma(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Descricao VARCHAR(200) NOT NULL,
	LimiteAlunos INT NOT NULL
);

CREATE TABLE inscricao(
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	AlunoId INT NOT NULL,
	TurmaId INT NOT NULL,
	InscritoEm DATETIME NOT NULL,
	CONSTRAINT fk_aluno_inscricao FOREIGN KEY (AlunoId) REFERENCES aluno(IdUsuario),
	CONSTRAINT fk_turma_inscricao FOREIGN KEY (TurmaId) REFERENCES turma(Id)
);

select * from professor;
select * from aluno;
select * from inscricao;
select * from usuario;
select * from turma;

use treinamento;
delete from inscricao;
delete from professor;
delete from aluno;
delete from usuario;

drop table inscricao;
drop table usuario;
drop table aluno;
drop table professor;
