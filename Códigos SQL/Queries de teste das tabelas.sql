use treinamento;
select * from usuario;
select * from aluno;
select * from professor;
insert into usuario (codigo, senha) values (23304721, 'WaitForIt');

INSERT INTO aluno (IdUsuario, Nome, Email, DataNascimento) VALUES (3, 'Nome', 'nãosei@mail.com', '19970707 00:00:00'); SELECT SCOPE_IDENTITY();


CREATE TABLE professor(
	IdUsuario INT PRIMARY KEY NOT NULL,
	Nome NVARCHAR(30) NOT NULL,
	Cpf VARCHAR(15) NOT NULL,
	CONSTRAINT fk_usuario_professor FOREIGN KEY (IdUsuario) REFERENCES usuario(Id)
);
