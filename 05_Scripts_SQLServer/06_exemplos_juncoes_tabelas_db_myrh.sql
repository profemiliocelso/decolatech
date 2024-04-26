USE DB_MYRH
GO

-- Buscando as áreas e seus respectivos cargos, usando ALIAS para as colunas
-- 1. Usando os campos e as tabelas com seus nomes completos
SELECT 
	TB_AREAS.DESCRICAO AS ÁREA, 
	TB_CARGOS.DESCRICAO AS CARGO, 
	TB_CARGOS.SALARIO AS SALARIO
FROM
	TB_AREAS, TB_CARGOS
WHERE
	TB_AREAS.ID = TB_CARGOS.ID_AREA




--2. O mesmo exemplo anterior, contendo ALIASES para as tabelas
SELECT 
	A.DESCRICAO AS ÁREA, 
	C.DESCRICAO AS CARGO, 
	C.SALARIO AS SALARIO
FROM
	TB_AREAS A, TB_CARGOS C
WHERE
	A.ID = C.ID_AREA



-- 3. Usando as tabelas TB_CARGOS e TB_INSCRICOES, apresentar:
-- cargo, salario, cpf do inscrito e data da inscrição
SELECT 
	C.DESCRICAO AS CARGO,
	C.SALARIO,
	I.CPF,
	I.DATA_INSCRICAO AS [DATA INSCRIÇÃO]
FROM 
	TB_CARGOS C, TB_INSCRICOES I
WHERE 
	C.ID = I.ID_CARGO

-- 4. Usando as tabelas TB_CARGOS, TB_INCRICOES e TB_CANDIDATOS, apresentar
-- id da área e descrição (cargos)
-- data da inscrição (inscrições)
-- nome e telefone (candidatos)

SELECT 
	C.ID_AREA			AS AREA,
	C.DESCRICAO			AS CARGO,
	CONVERT(VARCHAR(10),I.DATA_INSCRICAO,104) 	AS [DATA INSCRICAO],
	CD.NOME				AS CANDIDATO,
	CD.TELEFONE
FROM
	TB_CARGOS C, TB_INSCRICOES I, TB_CANDIDATOS CD
WHERE
	C.ID = I.ID_CARGO AND I.CPF = CD.CPF
-- --------------------------------------------------------------------------

-- Uso de JOINS
--5. Usando INNER JOIN entre as tabelas TB_AREAS e TB_CARGOS
SELECT
	A.DESCRICAO AS AREA,
	C.DESCRICAO AS CARGO,
	C.SALARIO
FROM
	TB_AREAS A INNER JOIN TB_CARGOS C
ON
	A.ID = C.ID_AREA



SELECT
	A.DESCRICAO AS AREA,
	C.DESCRICAO AS CARGO,
	C.SALARIO
FROM
	TB_AREAS A LEFT JOIN TB_CARGOS C
ON
	A.ID = C.ID_AREA



SELECT
	A.DESCRICAO AS AREA,
	C.DESCRICAO AS CARGO,
	C.SALARIO
FROM
	TB_AREAS A RIGHT JOIN TB_CARGOS C
ON
	A.ID = C.ID_AREA