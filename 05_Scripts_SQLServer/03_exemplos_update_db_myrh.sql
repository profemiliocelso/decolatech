USE DB_MYRH
GO

-- 1. Alterar a descri��o da �rea cujo c�digo (ID) seja igual a 2
UPDATE TB_AREAS SET DESCRICAO = 'Front End com Javascript' WHERE ID = 2


-- 2. Reajustar os sal�rios da tabela TB_CARGOS em 10%
SELECT * FROM TB_CARGOS
UPDATE TB_CARGOS SET SALARIO = SALARIO * 1.1