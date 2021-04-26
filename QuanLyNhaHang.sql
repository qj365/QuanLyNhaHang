CREATE PROCEDURE [dbo].[DemSoMonAn]
@From DATE, @To DATE
AS
BEGIN
    SELECT dbo.MONAN.MAMA, TENMONAN, COUNT(CHITIETDATMON.MAMA) AS 'SoLuong'
	FROM dbo.CHITIETDATMON
	INNER JOIN dbo.MONAN
	ON MONAN.MAMA = CHITIETDATMON.MAMA
	INNER JOIN (SELECT * FROM dbo.PHIEUYEUCAU WHERE NGAYLAP > @From AND NGAYLAP < @To) C
	ON C.MAPYC = CHITIETDATMON.MAPYC
	GROUP BY dbo.MONAN.MAMA, TENMONAN
END
GO

CREATE PROC [dbo].[ThemSuaKH]
@makh VARCHAR(10), @tenkh nVARCHAR(50), @sdtkh VARCHAR(10)
as
begin
	declare @tontai int

	select @tontai = count(*)
	from dbo.KHACHHANG
	where MAKH = @makh
	if (@tontai = 0)
	begin
		insert into dbo.KHACHHANG
		(
		    MAKH,
		    TENKH,
		    SDT
		)
		VALUES
		(   @makh,  -- MAKH - char(10)
		    @tenkh, -- TENKH - nvarchar(50)
		    @sdtkh   -- SDT - char(10)
		    )
	end
	else if(@tontai > 0)
	begin
		update dbo.KHACHHANG
		set TENKH = @tenkh, SDT = @sdtkh
		where MAKH = @makh
	end
END
GO

CREATE PROC [dbo].[ThemSuaNCC]
@mancc VARCHAR(10), @tenncc NVARCHAR(50), @sdtncc VARCHAR(10), @diachincc NVARCHAR(100)
as
begin
	declare @tontai int

	select @tontai = count(*)
	from dbo.NHACUNGCAP
	where MANCC = @mancc
	if (@tontai = 0)
	begin
		insert into dbo.NHACUNGCAP
		(
		    MANCC,
		    TENNCC,
		    DIACHI,
		    SDT
		)
		VALUES
		(   @mancc,  -- MANCC - char(10)
		    @tenncc, -- TENNCC - nvarchar(50)
		    @diachincc, -- DIACHI - nvarchar(100)
		    @sdtncc   -- SDT - char(10)
		    )
	end
	else if(@tontai > 0)
	begin
		update dbo.NHACUNGCAP
		set TENNCC = @tenncc, SDT = @sdtncc
		where MANCC = @mancc
	end
END
GO

CREATE FUNCTION [dbo].[TAOMAKH]()
RETURNS VARCHAR(10)
AS
BEGIN
DECLARE @MAKH VARCHAR(10)
DECLARE @MAXMAKH VARCHAR(10)
DECLARE @MAX INT
SELECT @MAXMAKH = MAX(MAKH) FROM dbo.KHACHHANG
IF EXISTS (SELECT MAKH FROM dbo.KHACHHANG)
	SET @MAX = CONVERT(INT, SUBSTRING(@MAXMAKH, 3 ,8))+1
ELSE SET @MAX = 1
IF (@MAX < 10) SET @MAKH = '000' + CONVERT (VARCHAR(1), @MAX)
ELSE
IF (@MAX < 100) SET @MAKH = '00' + CONVERT (VARCHAR(2), @MAX)
ELSE
IF (@MAX < 1000) SET @MAKH = '0' + CONVERT (VARCHAR(3), @MAX)
RETURN @MAKH
END
GO

CREATE FUNCTION [dbo].[TAOMANCC]()
RETURNS VARCHAR(10)
AS
BEGIN
DECLARE @MANCC VARCHAR(10)
DECLARE @MAXMANCC VARCHAR(10)
DECLARE @MAX INT
SELECT @MAXMANCC = MAX(MANCC) FROM dbo.NHACUNGCAP
IF EXISTS (SELECT MANCC FROM dbo.NHACUNGCAP)
	SET @MAX = CONVERT(INT, SUBSTRING(@MAXMANCC, 3 ,8))+1
ELSE SET @MAX = 1
IF (@MAX < 10) SET @MANCC = '000' + CONVERT (VARCHAR(1), @MAX)
ELSE
IF (@MAX < 100) SET @MANCC = '00' + CONVERT (VARCHAR(2), @MAX)
ELSE
IF (@MAX < 1000) SET @MANCC = '0' + CONVERT (VARCHAR(3), @MAX)
RETURN @MANCC
END