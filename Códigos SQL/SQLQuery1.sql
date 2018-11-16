use treinamento;
create table aluno(
	Id INT NOT NULL IDENTITY(1,1) primary key,
	Nome VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	DataNascimento Datetime
);

create table turma(
	Id INT NOT NULL IDENTITY(1,1) primary key,
	Nome VARCHAR(250) NOT NULL,
	LimiteAlunos int not null
);

create table inscricao(
	Id INT NOT NULL IDENTITY(1,1) primary key,
	AlunoId int not null,
	TurmaId int not null,
	InscritoEm datetime not null,
	constraint fk_aluno_id foreign key (AlunoId) references aluno(Id),
	constraint fk_turma_id foreign key (TurmaId) references Turma(Id)
);
