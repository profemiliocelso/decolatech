USE DB_MYRH
GO
/*
	Exemplos de uso do comando INSERT para inserir
	dados nas quatro tabelas
*/

-- Tabela TB_AREAS
INSERT INTO TB_AREAS (DESCRICAO) VALUES ('Web Front End')

INSERT INTO TB_AREAS (DESCRICAO) VALUES 
('Tecnologia da Informação'),
('Financeiro'),
('Saúde')

--Tabela TB_CARGOS
INSERT INTO TB_CARGOS (ID_AREA, DESCRICAO, SALARIO, TP_SALARIO) VALUES
(1, 'Programador Junior HTML, CSS e Javascript', 3800, 1),
(1, 'Programador Angular Pleno', 6000, 1),
(5, 'Enfermeiro Chefe', 7000, 1),
(5, 'Instrumentador', 100, 2)

-- Tabela TB_CANDIDATOS
INSERT INTO TB_CANDIDATOS (CPF, NOME, TELEFONE, EMAIL) VALUES
('40417734077', 'Eliel Matoso', '3266-6000', 'eliel@mail.com'),
('05519598002', 'Vivaneide Rocha', '99587-1234', 'viva@neide.com'),
('49227828001', 'Pradilina Codonilha Santos','77418-5587', 'pradineide@avanade.com')


-- Tabela TB_INSCRICOES
INSERT INTO TB_INSCRICOES (ID_CARGO, CPF, DATA_INSCRICAO) VALUES
(1, '40417734077', GETDATE()),
(3, '49227828001', '2024-04-24'),
(1, '05519598002', '2024-04-19'),
(2, '05519598002', '2024-04-23'),
(4, '49227828001', GETDATE())
