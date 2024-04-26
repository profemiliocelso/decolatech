USE DB_MYRH
GO

-- consultas na tabela TB_AREAS
-- 1. Buscando TODOS os registros da tabela
SELECT * FROM TB_AREAS

-- 2. Buscando a descrição de todas as áreas
SELECT DESCRICAO FROM TB_AREAS

SELECT DISTINCT DESCRICAO FROM TB_AREAS

SELECT DISTINCT ID, DESCRICAO FROM TB_AREAS

-- 3. Buscando uma área com base no ID informado (usaremos restrições)
SELECT * FROM TB_AREAS WHERE ID = 3

SELECT * FROM TB_AREAS WHERE ID > 2

SELECT * FROM TB_AREAS WHERE ID > 2 AND ID <> 4

-- Buscando todas as áreas cuja descrição inicie com a palavra 'Tec'
-- Obs.: O operador LIKE é usado para retornar partes de um texto
SELECT * FROM TB_AREAS WHERE DESCRICAO LIKE 'TEC%'

SELECT * FROM TB_AREAS WHERE DESCRICAO LIKE '%FRONT%'

SELECT * FROM TB_AREAS WHERE DESCRICAO LIKE 'FRONT'

-- O operador de comparação (=) é usado para retornar a sentença completa
SELECT * FROM TB_AREAS WHERE DESCRICAO = 'TECNOLOGIA da Informação'