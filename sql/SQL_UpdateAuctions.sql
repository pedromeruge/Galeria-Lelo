USE GaleriaLelo;
GO

--procedure que o agente vai correr
CREATE PROCEDURE UpdateLeilaoState
AS
BEGIN

    -- Update auctions that have ended and are still in 'em_leilao' state
    UPDATE Leilao
    SET estado = CASE
                    WHEN GETDATE() > Data_hora_fim THEN
                        CASE
                            WHEN NOT EXISTS (SELECT 1 FROM Licitacao WHERE Licitacao.leilao_id = Leilao.leilao_id) THEN 'concluido'
                            ELSE 'por_pagar'
                        END
                    ELSE estado
                END
    FROM Leilao
    WHERE estado = 'em_leilao' AND GETDATE() > Data_hora_fim;
END;

-- -- criar schedule para associar ao sql agent

-- DECLARE @currentTime DATETIME = GETDATE()
-- DECLARE @next15Minutes DATETIME

-- -- Calculate the next 15-minute interval
-- SET @next15Minutes = DATEADD(MINUTE, (DATEDIFF(MINUTE, 0, @currentTime) / 15 + 1) * 15, 0)

-- EXEC sp_add_schedule 
--     @schedule_name = N'RunEvery15Minutes',
--     @freq_type = 4,                     -- Frequency type: daily
--     @freq_interval = 1,                 -- Daily frequency
--     @freq_subday_type = 4,              -- Subfrequency type: minutes
--     @freq_subday_interval = 15,         -- Run every 15 minutes
--     @active_start_time = @next15Minutes;    -- Start time: rounded current time
-- GO