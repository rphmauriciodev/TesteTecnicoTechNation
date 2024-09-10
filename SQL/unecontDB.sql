CREATE DATABASE uneContDB;

USE uneContDB;

CREATE TABLE STATUS
(
    id_status INT NOT NULL PRIMARY KEY,
    st_nota VARCHAR(50),
    cd_status VARCHAR(1)
);

CREATE TABLE NOTAS_FISCAIS
(
    id_nota INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    nome_pagador VARCHAR(255),
    dt_emissao DATETIME,
    dt_cobranca DATETIME,
    dt_pagamento DATETIME,
    vl_nota FLOAT,
    documento_nota VARCHAR(255),
    documento_boleto VARCHAR(255),
    id_status INT,
    FOREIGN KEY (id_status) REFERENCES STATUS (id_status)
);

GO

CREATE TRIGGER trg_AtualizarStatusNotaFiscal
ON NOTAS_FISCAIS
AFTER INSERT, UPDATE
AS
BEGIN
    DECLARE @data_atual DATETIME = GETDATE();
    UPDATE NF
    SET id_status = 
        CASE 
            WHEN NF.dt_pagamento IS NOT NULL THEN 4 
            WHEN NF.dt_cobranca <= @data_atual AND DATEDIFF(DAY, NF.dt_cobranca, @data_atual) >= 30 THEN 3 
            WHEN NF.dt_cobranca <= @data_atual AND NF.dt_pagamento IS NULL THEN 2
            ELSE 1 
        END
    FROM NOTAS_FISCAIS AS NF
        INNER JOIN inserted i ON NF.id_nota = i.id_nota
    WHERE NF.id_nota = i.id_nota;
END;

GO
INSERT INTO STATUS
    (id_status, st_nota, cd_status)
VALUES
    (1, 'Emitida', 'E'),
    (2, 'Cobrança realizada', 'C'),
    (3, 'Pagamento em atraso', 'A'),
    (4, 'Pagamento realizado', 'P');

INSERT INTO NOTAS_FISCAIS
    (nome_pagador, dt_emissao, dt_cobranca, dt_pagamento, vl_nota, documento_nota, documento_boleto)
VALUES
    ('João Silva', '2024-01-15T09:00:00', '2024-02-15T09:00:00', '2024-03-01T10:30:00', 1500.00, 'doc_john_silva', 'boleto_john'),
    ('Maria Oliveira', '2024-02-20T11:15:00', '2024-03-20T11:15:00', NULL, 2200.00, 'doc_maria_oliveira', 'boleto_maria'),
    ('Pedro Santos', '2024-03-10T13:45:00', '2024-04-10T13:45:00', '2024-04-15T14:00:00', 3400.00, 'doc_pedro_santos', 'boleto_pedro'),
    ('Ana Costa', '2024-04-05T08:30:00', '2024-05-05T08:30:00', NULL, 2750.00, 'doc_ana_costa', 'boleto_ana'),
    ('Carlos Almeida', '2024-05-25T14:00:00', '2024-06-25T14:00:00', '2024-07-01T15:30:00', 1800.00, 'doc_carlos_almeida', 'boleto_carlos'),
    ('Fernanda Lima', '2024-06-12T12:00:00', '2024-07-12T12:00:00', NULL, 3300.00, 'doc_fernanda_lima', 'boleto_fernanda'),
    ('Lucas Pereira', '2024-08-20T10:00:00', '2024-09-04T14:58:14.040', NULL, 2900.00, 'doc_lucas_pereira', 'boleto_lucas'),
    ('Beatriz Fernandes', '2024-08-18T15:30:00', '2024-09-14T15:30:00', NULL, 2000.00, 'doc_beatriz_fernandes', 'boleto_beatriz'),
    ('Roberto Souza', '2024-01-10T09:00:00', GETDATE() , NULL, 2100.00, 'doc_roberto_souza', 'boleto_roberto'),
    ('Phillipe Coutinho', '2024-01-15T09:00:00', '2024-02-15T09:00:00', '2024-03-19T10:30:00', 1300.00, 'doc_phillipe', 'boleto_coutinho'),
    ('Dimitri Payet', '2024-01-15T09:00:00', '2024-12-15T09:00:00', NULL, 1300.00, 'doc_payet', 'boleto_dimitri');

GO

CREATE FUNCTION dbo.fn_GetNotasPorStatus(
    @ID_Status INT
    )
RETURNS TABLE
AS
RETURN
    SELECT
    NF.id_nota,
    NF.nome_pagador,
    NF.dt_emissao,
    NF.dt_cobranca,
    NF.dt_pagamento,
    NF.vl_nota,
    NF.documento_nota,
    NF.documento_boleto,
    NF.id_status,
    ST.st_nota
FROM NOTAS_FISCAIS AS NF
    INNER JOIN STATUS AS ST
    ON NF.id_status = ST.id_status
WHERE (@ID_Status = 0 OR NF.id_status = @ID_Status)
GO
CREATE FUNCTION dbo.fn_GetNotasPorData(
        @Month INT,
        @Year INT,
        @Tipo_data VARCHAR(1),
        @ID_Status INT
    )
    RETURNS TABLE
    AS
    RETURN
        SELECT
    NF.id_nota,
    NF.nome_pagador,
    NF.dt_emissao,
    NF.dt_cobranca,
    NF.dt_pagamento,
    NF.vl_nota,
    NF.documento_nota,
    NF.documento_boleto,
    NF.id_status,
    ST.st_nota
FROM NOTAS_FISCAIS AS NF
    INNER JOIN STATUS AS ST
    ON NF.id_status = ST.id_status
WHERE 
        (
        (@Tipo_data = 'E' AND MONTH(NF.dt_emissao) = @Month AND YEAR(NF.dt_emissao) = @Year) OR
        (@Tipo_data = 'P' AND MONTH(NF.dt_pagamento) = @Month AND YEAR(NF.dt_pagamento) = @Year) OR
        (@Tipo_data = 'C' AND MONTH(NF.dt_cobranca) = @Month AND YEAR(NF.dt_cobranca) = @Year)
        )
    AND
    (
        (@ID_Status = 0 OR NF.id_status = @ID_Status)
        );


GO

CREATE FUNCTION dbo.fn_GetResumoNotas(
    @Month INT = NULL,
    @FinalMonth INT = NULL,
    @Year INT = NULL
)
RETURNS TABLE
AS
RETURN
    SELECT 
        SUM(NF.vl_nota) AS valor_total,
        NF.id_status
    FROM 
        NOTAS_FISCAIS AS NF
    LEFT JOIN 
        STATUS AS ST ON NF.id_status = ST.id_status
    WHERE
    (
        (@Year IS NOT NULL AND YEAR(dt_emissao) = @Year
            AND (@Month IS NULL OR MONTH(dt_emissao) BETWEEN @Month AND ISNULL(@FinalMonth, @Month)))
        OR
        (@Month IS NOT NULL AND MONTH(dt_emissao) = @Month AND @Year IS NULL)
        OR
        (@Year IS NULL AND @Month IS NULL AND @FinalMonth IS NULL)
    )
        AND NF.id_status <> 2
    GROUP BY 
        NF.id_status;

GO

SELECT * FROM NOTAS_FISCAIS

UPDATE NOTAS_FISCAIS
SET dt_cobranca = '2023-12-15T09:00:00.000'
WHERE id_nota = 11

GO
CREATE FUNCTION dbo.fn_GetInadimplenciaPorAno(
    @Year INT 
)
RETURNS TABLE
AS
RETURN
SELECT SUM(vl_nota) AS total_inadimplencia,
       CASE 
           WHEN MONTH(dt_cobranca) = 12 THEN 1
           ELSE MONTH(DATEADD(MONTH, 1, dt_cobranca))
       END AS mes_inadimplencia
FROM NOTAS_FISCAIS
WHERE (YEAR(dt_cobranca) = @Year AND MONTH(dt_cobranca) != 12
       AND id_status = 3)
   OR (YEAR(dt_cobranca) = @Year - 1 AND MONTH(dt_cobranca) = 12
       AND id_status = 3)
GROUP BY CASE 
            WHEN MONTH(dt_cobranca) = 12 THEN 1
            ELSE MONTH(DATEADD(MONTH, 1, dt_cobranca))
         END;

GO
CREATE FUNCTION dbo.fn_GetReceitaPorAno(
    @Year INT 
)
RETURNS TABLE
AS
RETURN
SELECT SUM(vl_nota) AS total_receita,
       MONTH(dt_pagamento) AS mes_pagamento
       FROM NOTAS_FISCAIS
WHERE YEAR(dt_pagamento) = @Year
GROUP BY MONTH(dt_pagamento)

GO

SELECT * FROM fn_GetInadimplenciaPorAno(2024)
ORDER BY mes_inadimplencia
SELECT * FROM fn_GetReceitaPorAno(2024)
ORDER BY mes_pagamento

SELECT * FROM NOTAS_FISCAIS