Go
Create Database TesteFinanceiro
Go
use TesteFinanceiro
go
Create Table Lancamentos
(
	Id UNIQUEIDENTIFIER,
	DataLancamento Datetime,
	Valor decimal(16,2),
	Conta varchar(max),
	TipoLancamento char(1)
)
GO
