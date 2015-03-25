USE [PlaceHolder]
GO

IF OBJECT_ID(N'[dbo].[usp_InsertBangdiem]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_InsertBangdiem]

IF OBJECT_ID(N'[dbo].[usp_InsertBangdiemNull]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_InsertBangdiemNull]

IF OBJECT_ID(N'[dbo].[usp_UpdateBangdiem]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_UpdateBangdiem]

IF OBJECT_ID(N'[dbo].[usp_DeleteBangdiem]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteBangdiem]

IF OBJECT_ID(N'[dbo].[usp_SelectBangdiem]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectBangdiem]

IF OBJECT_ID(N'[dbo].[usp_SelectBangdiemNamHocByMaHocSinh]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectBangdiemNamHocByMaHocSinh]

IF OBJECT_ID(N'[dbo].[usp_DeleteBangdiemsDynamic]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteBangdiemsDynamic]

IF OBJECT_ID(N'[dbo].[usp_SelectBangdiemsDynamic]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectBangdiemsDynamic]

IF OBJECT_ID(N'[dbo].[usp_SelectBangdiemsAll]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectBangdiemsAll]
GO

CREATE PROCEDURE [dbo].[usp_InsertBangdiem]
	@MAHOCSINH int,
	@MAMONHOC varchar(5),
	@MAHOCKY int,
	@NAMHOC varchar(10),
	@MADIEM15 int,
	@MADIEM1T int,
	@MADIEMHK int
AS

SET NOCOUNT ON

INSERT INTO [dbo].[BANGDIEM] (
	[MAHOCSINH],
	[MAMONHOC],
	[MAHOCKY],
	[NAMHOC],
	[MADIEM15],
	[MADIEM1T],
	[MADIEMHK]
) VALUES (
	@MAHOCSINH,
	@MAMONHOC,
	@MAHOCKY,
	@NAMHOC,
	@MADIEM15,
	@MADIEM1T,
	@MADIEMHK
)
GO

CREATE PROCEDURE [dbo].[usp_InsertBangdiemNull]
	@MAHOCSINH int,
	@MAMONHOC varchar(5),
	@MAHOCKY int,
	@NAMHOC varchar(10)
AS

SET NOCOUNT ON

INSERT INTO [dbo].[BANGDIEM] (
	[MAHOCSINH],
	[MAMONHOC],
	[MAHOCKY],
	[NAMHOC]
) VALUES (
	@MAHOCSINH,
	@MAMONHOC,
	@MAHOCKY,
	@NAMHOC
)
GO

CREATE PROCEDURE [dbo].[usp_UpdateBangdiem]
	@MAHOCSINH int,
	@MAMONHOC varchar(5),
	@MAHOCKY int,
	@NAMHOC varchar(10),
	@MADIEM15 int,
	@MADIEM1T int,
	@MADIEMHK int
AS

SET NOCOUNT ON

UPDATE [dbo].[BANGDIEM] SET
	[MADIEM15] = @MADIEM15,
	[MADIEM1T] = @MADIEM1T,
	[MADIEMHK] = @MADIEMHK
WHERE
	[MAHOCSINH] = @MAHOCSINH
	AND [MAHOCKY] = @MAHOCKY
	AND [MAMONHOC] = @MAMONHOC
	AND [NAMHOC] = @NAMHOC
GO

CREATE PROCEDURE [dbo].[usp_DeleteBangdiem]
	@MAHOCSINH int,
	@MAHOCKY int,
	@MAMONHOC varchar(5),
	@NAMHOC varchar(10)
AS

SET NOCOUNT ON

DELETE FROM [dbo].[BANGDIEM]
WHERE
	[MAHOCSINH] = @MAHOCSINH
	AND [MAHOCKY] = @MAHOCKY
	AND [MAMONHOC] = @MAMONHOC
	AND [NAMHOC] = @NAMHOC
GO

CREATE PROCEDURE [dbo].[usp_SelectBangdiem]
	@MAHOCSINH int,
	@MAHOCKY int,
	@MAMONHOC varchar(5),
	@NAMHOC varchar(10)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[MAHOCSINH],
	[MAMONHOC],
	[MAHOCKY],
	[NAMHOC],
	[MADIEM15],
	[MADIEM1T],
	[MADIEMHK],
	[DIEMTRUNGBINH]
FROM
	[dbo].[BANGDIEM]
WHERE
	[MAHOCSINH] = @MAHOCSINH
	AND [MAHOCKY] = @MAHOCKY
	AND [MAMONHOC] = @MAMONHOC
	AND [NAMHOC] = @NAMHOC
GO

CREATE PROCEDURE [dbo].[usp_SelectBangdiemNamHocByMaHocSinh]
	@MAHOCSINH int,
	@NAMHOC varchar(10)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[MAHOCSINH],
	[MAMONHOC],
	[MAHOCKY],
	[NAMHOC],
	[MADIEM15],
	[MADIEM1T],
	[MADIEMHK],
	[DIEMTRUNGBINH]
FROM
	[dbo].[BANGDIEM]
WHERE
	[MAHOCSINH] = @MAHOCSINH
	AND [NAMHOC] = @NAMHOC
GO

CREATE PROCEDURE [dbo].[usp_DeleteBangdiemsDynamic]
	@WhereCondition nvarchar(500)
AS

SET NOCOUNT ON

DECLARE @SQL nvarchar(3250)

SET @SQL = '
DELETE FROM
	[dbo].[BANGDIEM]
WHERE
	' + @WhereCondition

EXEC sp_executesql @SQL
GO

CREATE PROCEDURE [dbo].[usp_SelectBangdiemsDynamic]
	@WhereCondition nvarchar(500),
	@OrderByExpression nvarchar(250) = NULL
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

DECLARE @SQL nvarchar(3250)

SET @SQL = '
SELECT
	[MAHOCSINH],
	[MAMONHOC],
	[MAHOCKY],
	[NAMHOC],
	[MADIEM15],
	[MADIEM1T],
	[MADIEMHK],
	[DIEMTRUNGBINH]
FROM
	[dbo].[BANGDIEM]
WHERE
	' + @WhereCondition

IF @OrderByExpression IS NOT NULL AND LEN(@OrderByExpression) > 0
BEGIN
	SET @SQL = @SQL + '
ORDER BY
	' + @OrderByExpression
END

EXEC sp_executesql @SQL
GO

CREATE PROCEDURE [dbo].[usp_SelectBangdiemsAll]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[MAHOCSINH],
	[MAMONHOC],
	[MAHOCKY],
	[NAMHOC],
	[MADIEM15],
	[MADIEM1T],
	[MADIEMHK],
	[DIEMTRUNGBINH]
FROM
	[dbo].[BANGDIEM]
GO

--region Diem
IF OBJECT_ID(N'[dbo].[usp_InsertDiem]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_InsertDiem]

IF OBJECT_ID(N'[dbo].[usp_UpdateDiem]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_UpdateDiem]

IF OBJECT_ID(N'[dbo].[usp_DeleteDiem]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteDiem]

IF OBJECT_ID(N'[dbo].[usp_DeleteDiemsDynamic]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteDiemsDynamic]

IF OBJECT_ID(N'[dbo].[usp_SelectDiem]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectDiem]

IF OBJECT_ID(N'[dbo].[usp_SelectDiemsDynamic]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectDiemsDynamic]

IF OBJECT_ID(N'[dbo].[usp_SelectDiemsAll]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectDiemsAll]

IF OBJECT_ID(N'[dbo].[usp_SelectLastMaDiem]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectLastMaDiem]
GO

CREATE PROCEDURE [dbo].[usp_InsertDiem]
	@MADIEM int,
	@MALOAIDIEM varchar(3),
	@GIATRI float
AS

SET NOCOUNT ON

INSERT INTO [dbo].[DIEM] (
	[MADIEM],
	[MALOAIDIEM],
	[GIATRI]
) VALUES (
	@MADIEM,
	@MALOAIDIEM,
	@GIATRI
)
GO

CREATE PROCEDURE [dbo].[usp_UpdateDiem]
	@MADIEM int,
	@MALOAIDIEM varchar(3),
	@GIATRI float
AS

SET NOCOUNT ON

UPDATE [dbo].[DIEM] SET
	[MALOAIDIEM] = @MALOAIDIEM,
	[GIATRI] = @GIATRI
WHERE
	[MADIEM] = @MADIEM
GO

CREATE PROCEDURE [dbo].[usp_DeleteDiem]
	@MADIEM int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[DIEM]
WHERE
	[MADIEM] = @MADIEM
GO

CREATE PROCEDURE [dbo].[usp_DeleteDiemsDynamic]
	@WhereCondition nvarchar(500)
AS

SET NOCOUNT ON

DECLARE @SQL nvarchar(3250)

SET @SQL = '
DELETE FROM
	[dbo].[DIEM]
WHERE
	' + @WhereCondition

EXEC sp_executesql @SQL
GO

CREATE PROCEDURE [dbo].[usp_SelectDiem]
	@MADIEM int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[MADIEM],
	[MALOAIDIEM],
	[GIATRI]
FROM
	[dbo].[DIEM]
WHERE
	[MADIEM] = @MADIEM
GO

CREATE PROCEDURE [dbo].[usp_SelectDiemsDynamic]
	@WhereCondition nvarchar(500),
	@OrderByExpression nvarchar(250) = NULL
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

DECLARE @SQL nvarchar(3250)

SET @SQL = '
SELECT
	[MADIEM],
	[MALOAIDIEM],
	[GIATRI]
FROM
	[dbo].[DIEM]
WHERE
	' + @WhereCondition

IF @OrderByExpression IS NOT NULL AND LEN(@OrderByExpression) > 0
BEGIN
	SET @SQL = @SQL + '
ORDER BY
	' + @OrderByExpression
END

EXEC sp_executesql @SQL
GO

CREATE PROCEDURE [dbo].[usp_SelectDiemsAll]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[MADIEM],
	[MALOAIDIEM],
	[GIATRI]
FROM
	[dbo].[DIEM]
GO

CREATE PROCEDURE [dbo].[usp_SelectLastMaDiem]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT TOP 1 MADIEM
FROM
	[dbo].[DIEM]
ORDER BY 
	MADIEM DESC
GO

--region HocKy
IF OBJECT_ID(N'[dbo].[usp_InsertHocky]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_InsertHocky]

IF OBJECT_ID(N'[dbo].[usp_UpdateHocky]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_UpdateHocky]

IF OBJECT_ID(N'[dbo].[usp_DeleteHocky]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteHocky]

IF OBJECT_ID(N'[dbo].[usp_DeleteHockiesDynamic]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteHockiesDynamic]

IF OBJECT_ID(N'[dbo].[usp_SelectHocky]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectHocky]

IF OBJECT_ID(N'[dbo].[usp_SelectHockiesDynamic]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectHockiesDynamic]

IF OBJECT_ID(N'[dbo].[usp_SelectHockiesAll]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectHockiesAll]
GO

CREATE PROCEDURE [dbo].[usp_InsertHocky]
	@MAHOCKY int,
	@TENHOCKY nvarchar(30)
AS

SET NOCOUNT ON

INSERT INTO [dbo].[HOCKY] (
	[MAHOCKY],
	[TENHOCKY]
) VALUES (
	@MAHOCKY,
	@TENHOCKY
)
GO

CREATE PROCEDURE [dbo].[usp_UpdateHocky]
	@MAHOCKY int,
	@TENHOCKY nvarchar(30)
AS

SET NOCOUNT ON

UPDATE [dbo].[HOCKY] SET
	[TENHOCKY] = @TENHOCKY
WHERE
	[MAHOCKY] = @MAHOCKY
GO

CREATE PROCEDURE [dbo].[usp_DeleteHocky]
	@MAHOCKY int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[HOCKY]
WHERE
	[MAHOCKY] = @MAHOCKY
GO

CREATE PROCEDURE [dbo].[usp_DeleteHockiesDynamic]
	@WhereCondition nvarchar(500)
AS

SET NOCOUNT ON

DECLARE @SQL nvarchar(3250)

SET @SQL = '
DELETE FROM
	[dbo].[HOCKY]
WHERE
	' + @WhereCondition

EXEC sp_executesql @SQL
GO

CREATE PROCEDURE [dbo].[usp_SelectHocky]
	@MAHOCKY int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[MAHOCKY],
	[TENHOCKY]
FROM
	[dbo].[HOCKY]
WHERE
	[MAHOCKY] = @MAHOCKY
GO

CREATE PROCEDURE [dbo].[usp_SelectHockiesDynamic]
	@WhereCondition nvarchar(500),
	@OrderByExpression nvarchar(250) = NULL
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

DECLARE @SQL nvarchar(3250)

SET @SQL = '
SELECT
	[MAHOCKY],
	[TENHOCKY]
FROM
	[dbo].[HOCKY]
WHERE
	' + @WhereCondition

IF @OrderByExpression IS NOT NULL AND LEN(@OrderByExpression) > 0
BEGIN
	SET @SQL = @SQL + '
ORDER BY
	' + @OrderByExpression
END

EXEC sp_executesql @SQL
GO

CREATE PROCEDURE [dbo].[usp_SelectHockiesAll]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[MAHOCKY],
	[TENHOCKY]
FROM
	[dbo].[HOCKY]
GO

--region HoSoHocSinh
IF OBJECT_ID(N'[dbo].[usp_InsertHosohocsinh]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_InsertHosohocsinh]

IF OBJECT_ID(N'[dbo].[usp_UpdateHosohocsinh]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_UpdateHosohocsinh]

IF OBJECT_ID(N'[dbo].[usp_DeleteHosohocsinh]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteHosohocsinh]

IF OBJECT_ID(N'[dbo].[usp_DeleteHosohocsinhsDynamic]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteHosohocsinhsDynamic]

IF OBJECT_ID(N'[dbo].[usp_SelectHosohocsinh]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectHosohocsinh]

IF OBJECT_ID(N'[dbo].[usp_SelectHosohocsinhsDynamic]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectHosohocsinhsDynamic]

IF OBJECT_ID(N'[dbo].[usp_SelectHosohocsinhsAll]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectHosohocsinhsAll]

IF OBJECT_ID(N'[dbo].[usp_SelectLastMaHocSinh]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectLastMaHocSinh]
GO

CREATE PROCEDURE [dbo].[usp_InsertHosohocsinh]
	@MAHOCSINH int,
	@HOTEN nvarchar(30),
	@DIACHI nvarchar(30),
	@NGAYSINH smalldatetime,
	@EMAIL varchar(30),
	@GIOITINH nvarchar(3)
AS

SET NOCOUNT ON

INSERT INTO [dbo].[HOSOHOCSINH] (
	[MAHOCSINH],
	[HOTEN],
	[DIACHI],
	[NGAYSINH],
	[EMAIL],
	[GIOITINH]
) VALUES (
	@MAHOCSINH,
	@HOTEN,
	@DIACHI,
	@NGAYSINH,
	@EMAIL,
	@GIOITINH
)
GO

CREATE PROCEDURE [dbo].[usp_UpdateHosohocsinh]
	@MAHOCSINH int,
	@HOTEN nvarchar(30),
	@DIACHI nvarchar(30),
	@NGAYSINH smalldatetime,
	@EMAIL varchar(30),
	@GIOITINH nvarchar(3)
AS

SET NOCOUNT ON

UPDATE [dbo].[HOSOHOCSINH] SET
	[HOTEN] = @HOTEN,
	[DIACHI] = @DIACHI,
	[NGAYSINH] = @NGAYSINH,
	[EMAIL] = @EMAIL,
	[GIOITINH] = @GIOITINH
WHERE
	[MAHOCSINH] = @MAHOCSINH
GO

CREATE PROCEDURE [dbo].[usp_DeleteHosohocsinh]
	@MAHOCSINH int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[HOSOHOCSINH]
WHERE
	[MAHOCSINH] = @MAHOCSINH
GO

CREATE PROCEDURE [dbo].[usp_DeleteHosohocsinhsDynamic]
	@WhereCondition nvarchar(500)
AS

SET NOCOUNT ON

DECLARE @SQL nvarchar(3250)

SET @SQL = '
DELETE FROM
	[dbo].[HOSOHOCSINH]
WHERE
	' + @WhereCondition

EXEC sp_executesql @SQL
GO

CREATE PROCEDURE [dbo].[usp_SelectHosohocsinh]
	@MAHOCSINH int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[MAHOCSINH],
	[HOTEN],
	[DIACHI],
	[NGAYSINH],
	[EMAIL],
	[GIOITINH]
FROM
	[dbo].[HOSOHOCSINH]
WHERE
	[MAHOCSINH] = @MAHOCSINH
GO

CREATE PROCEDURE [dbo].[usp_SelectHosohocsinhsDynamic]
	@WhereCondition nvarchar(500),
	@OrderByExpression nvarchar(250) = NULL
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

DECLARE @SQL nvarchar(3250)

SET @SQL = '
SELECT
	[MAHOCSINH],
	[HOTEN],
	[DIACHI],
	[NGAYSINH],
	[EMAIL],
	[GIOITINH]
FROM
	[dbo].[HOSOHOCSINH]
WHERE
	' + @WhereCondition

IF @OrderByExpression IS NOT NULL AND LEN(@OrderByExpression) > 0
BEGIN
	SET @SQL = @SQL + '
ORDER BY
	' + @OrderByExpression
END

EXEC sp_executesql @SQL
GO

CREATE PROCEDURE [dbo].[usp_SelectHosohocsinhsAll]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[MAHOCSINH],
	[HOTEN],
	[DIACHI],
	[NGAYSINH],
	[EMAIL],
	[GIOITINH]
FROM
	[dbo].[HOSOHOCSINH]
GO

CREATE PROCEDURE [dbo].[usp_SelectLastMaHocSinh]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT TOP 1 MAHOCSINH
FROM
	[dbo].[HOSOHOCSINH]
ORDER BY 
	MAHOCSINH DESC
GO

--region Khoi
IF OBJECT_ID(N'[dbo].[usp_InsertKhoi]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_InsertKhoi]

IF OBJECT_ID(N'[dbo].[usp_UpdateKhoi]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_UpdateKhoi]

IF OBJECT_ID(N'[dbo].[usp_DeleteKhoi]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteKhoi]

IF OBJECT_ID(N'[dbo].[usp_DeleteKhoisDynamic]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteKhoisDynamic]

IF OBJECT_ID(N'[dbo].[usp_SelectKhoi]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectKhoi]

IF OBJECT_ID(N'[dbo].[usp_SelectKhoisDynamic]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectKhoisDynamic]

IF OBJECT_ID(N'[dbo].[usp_SelectKhoisAll]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectKhoisAll]
GO

CREATE PROCEDURE [dbo].[usp_InsertKhoi]
	@MAKHOI varchar(3),
	@KHOI nvarchar(10)
AS

SET NOCOUNT ON

INSERT INTO [dbo].[KHOI] (
	[MAKHOI],
	[KHOI]
) VALUES (
	@MAKHOI,
	@KHOI
)

GO
CREATE PROCEDURE [dbo].[usp_UpdateKhoi]
	@MAKHOI varchar(3),
	@KHOI nvarchar(10)
AS

SET NOCOUNT ON

UPDATE [dbo].[KHOI] SET
	[KHOI] = @KHOI
WHERE
	[MAKHOI] = @MAKHOI

GO
CREATE PROCEDURE [dbo].[usp_DeleteKhoi]
	@MAKHOI varchar(3)
AS

SET NOCOUNT ON

DELETE FROM [dbo].[KHOI]
WHERE
	[MAKHOI] = @MAKHOI

GO
CREATE PROCEDURE [dbo].[usp_DeleteKhoisDynamic]
	@WhereCondition nvarchar(500)
AS

SET NOCOUNT ON

DECLARE @SQL nvarchar(3250)

SET @SQL = '
DELETE FROM
	[dbo].[KHOI]
WHERE
	' + @WhereCondition

EXEC sp_executesql @SQL

GO
CREATE PROCEDURE [dbo].[usp_SelectKhoi]
	@MAKHOI varchar(3)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[MAKHOI],
	[KHOI]
FROM
	[dbo].[KHOI]
WHERE
	[MAKHOI] = @MAKHOI

GO
CREATE PROCEDURE [dbo].[usp_SelectKhoisDynamic]
	@WhereCondition nvarchar(500),
	@OrderByExpression nvarchar(250) = NULL
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

DECLARE @SQL nvarchar(3250)

SET @SQL = '
SELECT
	[MAKHOI],
	[KHOI]
FROM
	[dbo].[KHOI]
WHERE
	' + @WhereCondition

IF @OrderByExpression IS NOT NULL AND LEN(@OrderByExpression) > 0
BEGIN
	SET @SQL = @SQL + '
ORDER BY
	' + @OrderByExpression
END

EXEC sp_executesql @SQL

GO
CREATE PROCEDURE [dbo].[usp_SelectKhoisAll]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[MAKHOI],
	[KHOI]
FROM
	[dbo].[KHOI]
GO

--region LoaiDiem
IF OBJECT_ID(N'[dbo].[usp_InsertLoaidiem]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_InsertLoaidiem]

IF OBJECT_ID(N'[dbo].[usp_UpdateLoaidiem]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_UpdateLoaidiem]

IF OBJECT_ID(N'[dbo].[usp_DeleteLoaidiem]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteLoaidiem]

IF OBJECT_ID(N'[dbo].[usp_DeleteLoaidiemsDynamic]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteLoaidiemsDynamic]

IF OBJECT_ID(N'[dbo].[usp_SelectLoaidiem]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectLoaidiem]

IF OBJECT_ID(N'[dbo].[usp_SelectLoaidiemsDynamic]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectLoaidiemsDynamic]

IF OBJECT_ID(N'[dbo].[usp_SelectLoaidiemsAll]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectLoaidiemsAll]
GO

CREATE PROCEDURE [dbo].[usp_InsertLoaidiem]
	@MALOAIDIEM varchar(3),
	@TENLOAIDIEM nvarchar(30),
	@HESO int
AS

SET NOCOUNT ON

INSERT INTO [dbo].[LOAIDIEM] (
	[MALOAIDIEM],
	[TENLOAIDIEM],
	[HESO]
) VALUES (
	@MALOAIDIEM,
	@TENLOAIDIEM,
	@HESO
)
GO

CREATE PROCEDURE [dbo].[usp_UpdateLoaidiem]
	@MALOAIDIEM varchar(3),
	@TENLOAIDIEM nvarchar(30),
	@HESO int
AS

SET NOCOUNT ON

UPDATE [dbo].[LOAIDIEM] SET
	[TENLOAIDIEM] = @TENLOAIDIEM,
	[HESO] = @HESO
WHERE
	[MALOAIDIEM] = @MALOAIDIEM
GO

CREATE PROCEDURE [dbo].[usp_DeleteLoaidiem]
	@MALOAIDIEM varchar(3)
AS

SET NOCOUNT ON

DELETE FROM [dbo].[LOAIDIEM]
WHERE
	[MALOAIDIEM] = @MALOAIDIEM
GO

CREATE PROCEDURE [dbo].[usp_DeleteLoaidiemsDynamic]
	@WhereCondition nvarchar(500)
AS

SET NOCOUNT ON

DECLARE @SQL nvarchar(3250)

SET @SQL = '
DELETE FROM
	[dbo].[LOAIDIEM]
WHERE
	' + @WhereCondition

EXEC sp_executesql @SQL
GO

CREATE PROCEDURE [dbo].[usp_SelectLoaidiem]
	@MALOAIDIEM varchar(3)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[MALOAIDIEM],
	[TENLOAIDIEM],
	[HESO]
FROM
	[dbo].[LOAIDIEM]
WHERE
	[MALOAIDIEM] = @MALOAIDIEM
GO

CREATE PROCEDURE [dbo].[usp_SelectLoaidiemsDynamic]
	@WhereCondition nvarchar(500),
	@OrderByExpression nvarchar(250) = NULL
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

DECLARE @SQL nvarchar(3250)

SET @SQL = '
SELECT
	[MALOAIDIEM],
	[TENLOAIDIEM],
	[HESO]
FROM
	[dbo].[LOAIDIEM]
WHERE
	' + @WhereCondition

IF @OrderByExpression IS NOT NULL AND LEN(@OrderByExpression) > 0
BEGIN
	SET @SQL = @SQL + '
ORDER BY
	' + @OrderByExpression
END

EXEC sp_executesql @SQL
GO

CREATE PROCEDURE [dbo].[usp_SelectLoaidiemsAll]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[MALOAIDIEM],
	[TENLOAIDIEM],
	[HESO]
FROM
	[dbo].[LOAIDIEM]
GO

--region Lop
IF OBJECT_ID(N'[dbo].[usp_InsertLop]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_InsertLop]

IF OBJECT_ID(N'[dbo].[usp_UpdateLop]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_UpdateLop]

IF OBJECT_ID(N'[dbo].[usp_DeleteLop]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteLop]

IF OBJECT_ID(N'[dbo].[usp_DeleteLopsDynamic]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteLopsDynamic]

IF OBJECT_ID(N'[dbo].[usp_SelectLop]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectLop]

IF OBJECT_ID(N'[dbo].[usp_SelectLopByNamHoc]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectLopByNamHoc]

IF OBJECT_ID(N'[dbo].[usp_SelectLopsDynamic]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectLopsDynamic]

IF OBJECT_ID(N'[dbo].[usp_SelectLopsAll]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectLopsAll]

IF OBJECT_ID(N'[dbo].[usp_SelectLopsByMAKHOI_NAMHOC]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectLopsByMAKHOI_NAMHOC]

IF OBJECT_ID(N'[dbo].[usp_SelectLastMaLop]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectLastMaLop]
GO

CREATE PROCEDURE [dbo].[usp_InsertLop]
	@MALOP int,
	@MAKHOI varchar(3),
	@TENLOP nvarchar(50),
	@NAMHOC varchar(10),
	@SISO int
AS

SET NOCOUNT ON

INSERT INTO [dbo].[LOP] (
	[MALOP],
	[MAKHOI],
	[TENLOP],
	[NAMHOC],
	[SISO]
) VALUES (
	@MALOP,
	@MAKHOI,
	@TENLOP,
	@NAMHOC,
	@SISO
)
GO

CREATE PROCEDURE [dbo].[usp_UpdateLop]
	@MALOP int,
	@MAKHOI varchar(3),
	@TENLOP nvarchar(50),
	@NAMHOC varchar(10),
	@SISO int
AS

SET NOCOUNT ON

UPDATE [dbo].[LOP] SET
	[MAKHOI] = @MAKHOI,
	[TENLOP] = @TENLOP,
	[NAMHOC] = @NAMHOC,
	[SISO] = @SISO
WHERE
	[MALOP] = @MALOP
GO

CREATE PROCEDURE [dbo].[usp_DeleteLop]
	@MALOP int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[LOP]
WHERE
	[MALOP] = @MALOP
GO

CREATE PROCEDURE [dbo].[usp_DeleteLopsDynamic]
	@WhereCondition nvarchar(500)
AS

SET NOCOUNT ON

DECLARE @SQL nvarchar(3250)

SET @SQL = '
DELETE FROM
	[dbo].[LOP]
WHERE
	' + @WhereCondition

EXEC sp_executesql @SQL
GO

CREATE PROCEDURE [dbo].[usp_SelectLop]
	@MALOP int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[MALOP],
	[MAKHOI],
	[TENLOP],
	[NAMHOC],
	[SISO]
FROM
	[dbo].[LOP]
WHERE
	[MALOP] = @MALOP
GO

CREATE PROCEDURE [dbo].[usp_SelectLopByNamHoc]
	@NAMHOC varchar(10)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[MALOP],
	[MAKHOI],
	[TENLOP],
	[NAMHOC],
	[SISO]
FROM
	[dbo].[LOP]
WHERE
	[NAMHOC] = @NAMHOC
GO

CREATE PROCEDURE [dbo].[usp_SelectLopsDynamic]
	@WhereCondition nvarchar(500),
	@OrderByExpression nvarchar(250) = NULL
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

DECLARE @SQL nvarchar(3250)

SET @SQL = '
SELECT
	[MALOP],
	[MAKHOI],
	[TENLOP],
	[NAMHOC],
	[SISO]
FROM
	[dbo].[LOP]
WHERE
	' + @WhereCondition

IF @OrderByExpression IS NOT NULL AND LEN(@OrderByExpression) > 0
BEGIN
	SET @SQL = @SQL + '
ORDER BY
	' + @OrderByExpression
END

EXEC sp_executesql @SQL
GO

CREATE PROCEDURE [dbo].[usp_SelectLopsAll]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[MALOP],
	[MAKHOI],
	[TENLOP],
	[NAMHOC],
	[SISO]
FROM
	[dbo].[LOP]
GO

CREATE PROCEDURE [dbo].[usp_SelectLopsByMAKHOI_NAMHOC]
	@MAKHOI varchar(3),
	@NAMHOC varchar(10)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[MALOP],
	[MAKHOI],
	[TENLOP],
	[NAMHOC],
	[SISO]
FROM
	[dbo].[LOP]
WHERE
	[MAKHOI] = @MAKHOI AND
	[NAMHOC] = @NAMHOC
GO

CREATE PROCEDURE [dbo].[usp_SelectLastMaLop]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT TOP 1 MALOP
FROM
	[dbo].[LOP]
ORDER BY 
	MALOP DESC
GO

--region MonHoc
IF OBJECT_ID(N'[dbo].[usp_InsertMonhoc]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_InsertMonhoc]

IF OBJECT_ID(N'[dbo].[usp_UpdateMonhoc]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_UpdateMonhoc]

IF OBJECT_ID(N'[dbo].[usp_DeleteMonhoc]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteMonhoc]

IF OBJECT_ID(N'[dbo].[usp_DeleteMonhocsDynamic]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteMonhocsDynamic]

IF OBJECT_ID(N'[dbo].[usp_SelectMonhoc]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectMonhoc]

IF OBJECT_ID(N'[dbo].[usp_SelectMonhocsDynamic]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectMonhocsDynamic]

IF OBJECT_ID(N'[dbo].[usp_SelectMonhocsAll]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectMonhocsAll]
GO

CREATE PROCEDURE [dbo].[usp_InsertMonhoc]
	@MAMONHOC varchar(5),
	@TENMONHOC nvarchar(30)
AS

SET NOCOUNT ON

INSERT INTO [dbo].[MONHOC] (
	[MAMONHOC],
	[TENMONHOC]
) VALUES (
	@MAMONHOC,
	@TENMONHOC
)
GO

CREATE PROCEDURE [dbo].[usp_UpdateMonhoc]
	@MAMONHOC varchar(5),
	@TENMONHOC nvarchar(30)
AS

SET NOCOUNT ON

UPDATE [dbo].[MONHOC] SET
	[TENMONHOC] = @TENMONHOC
WHERE
	[MAMONHOC] = @MAMONHOC
GO

CREATE PROCEDURE [dbo].[usp_DeleteMonhoc]
	@MAMONHOC varchar(5)
AS

SET NOCOUNT ON

DELETE FROM [dbo].[MONHOC]
WHERE
	[MAMONHOC] = @MAMONHOC
GO

CREATE PROCEDURE [dbo].[usp_DeleteMonhocsDynamic]
	@WhereCondition nvarchar(500)
AS

SET NOCOUNT ON

DECLARE @SQL nvarchar(3250)

SET @SQL = '
DELETE FROM
	[dbo].[MONHOC]
WHERE
	' + @WhereCondition

EXEC sp_executesql @SQL
GO

CREATE PROCEDURE [dbo].[usp_SelectMonhoc]
	@MAMONHOC varchar(5)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[MAMONHOC],
	[TENMONHOC]
FROM
	[dbo].[MONHOC]
WHERE
	[MAMONHOC] = @MAMONHOC
GO

CREATE PROCEDURE [dbo].[usp_SelectMonhocsDynamic]
	@WhereCondition nvarchar(500),
	@OrderByExpression nvarchar(250) = NULL
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

DECLARE @SQL nvarchar(3250)

SET @SQL = '
SELECT
	[MAMONHOC],
	[TENMONHOC]
FROM
	[dbo].[MONHOC]
WHERE
	' + @WhereCondition

IF @OrderByExpression IS NOT NULL AND LEN(@OrderByExpression) > 0
BEGIN
	SET @SQL = @SQL + '
ORDER BY
	' + @OrderByExpression
END

EXEC sp_executesql @SQL
GO

CREATE PROCEDURE [dbo].[usp_SelectMonhocsAll]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[MAMONHOC],
	[TENMONHOC]
FROM
	[dbo].[MONHOC]
GO

--region NamHoc
IF OBJECT_ID(N'[dbo].[usp_InsertNamhoc]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_InsertNamhoc]

IF OBJECT_ID(N'[dbo].[usp_UpdateNamhoc]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_UpdateNamhoc]

IF OBJECT_ID(N'[dbo].[usp_DeleteNamhoc]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteNamhoc]

IF OBJECT_ID(N'[dbo].[usp_DeleteNamhocsDynamic]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteNamhocsDynamic]

IF OBJECT_ID(N'[dbo].[usp_SelectNamhoc]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectNamhoc]

IF OBJECT_ID(N'[dbo].[usp_SelectNamhocsDynamic]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectNamhocsDynamic]

IF OBJECT_ID(N'[dbo].[usp_SelectNamhocsAll]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectNamhocsAll]
GO

CREATE PROCEDURE [dbo].[usp_InsertNamhoc]
	@NAMHOC varchar(10)
AS

SET NOCOUNT ON

INSERT INTO [dbo].[NAMHOC] (
	[NAMHOC]
) VALUES (
	@NAMHOC
)
GO

CREATE PROCEDURE [dbo].[usp_DeleteNamhoc]
	@NAMHOC varchar(10)
AS

SET NOCOUNT ON

DELETE FROM [dbo].[NAMHOC]
WHERE
	[NAMHOC] = @NAMHOC
GO

CREATE PROCEDURE [dbo].[usp_DeleteNamhocsDynamic]
	@WhereCondition nvarchar(500)
AS

SET NOCOUNT ON

DECLARE @SQL nvarchar(3250)

SET @SQL = '
DELETE FROM
	[dbo].[NAMHOC]
WHERE
	' + @WhereCondition

EXEC sp_executesql @SQL
GO

CREATE PROCEDURE [dbo].[usp_SelectNamhoc]
	@NAMHOC varchar(10)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[NAMHOC]
FROM
	[dbo].[NAMHOC]
WHERE
	[NAMHOC] = @NAMHOC
GO

CREATE PROCEDURE [dbo].[usp_SelectNamhocsDynamic]
	@WhereCondition nvarchar(500),
	@OrderByExpression nvarchar(250) = NULL
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

DECLARE @SQL nvarchar(3250)

SET @SQL = '
SELECT
	[NAMHOC]
FROM
	[dbo].[NAMHOC]
WHERE
	' + @WhereCondition

IF @OrderByExpression IS NOT NULL AND LEN(@OrderByExpression) > 0
BEGIN
	SET @SQL = @SQL + '
ORDER BY
	' + @OrderByExpression
END

EXEC sp_executesql @SQL
GO

CREATE PROCEDURE [dbo].[usp_SelectNamhocsAll]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[NAMHOC]
FROM
	[dbo].[NAMHOC]
GO

--region XepLop
IF OBJECT_ID(N'[dbo].[usp_InsertXeplop]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_InsertXeplop]

IF OBJECT_ID(N'[dbo].[usp_UpdateXeplop]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_UpdateXeplop]

IF OBJECT_ID(N'[dbo].[usp_DeleteXeplop]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteXeplop]

IF OBJECT_ID(N'[dbo].[usp_DeleteXeplopsByMALOP]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteXeplopsByMALOP]

IF OBJECT_ID(N'[dbo].[usp_DeleteXeplopsDynamic]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_DeleteXeplopsDynamic]

IF OBJECT_ID(N'[dbo].[usp_SelectXeplop]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectXeplop]

IF OBJECT_ID(N'[dbo].[usp_SelectXeplopsByMALOP]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectXeplopsByMALOP]

IF OBJECT_ID(N'[dbo].[usp_SelectXeplopsByMAHOCSINH]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectXeplopsByMAHOCSINH]

IF OBJECT_ID(N'[dbo].[usp_SelectXeplopsDynamic]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectXeplopsDynamic]

IF OBJECT_ID(N'[dbo].[usp_SelectXeplopsAll]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectXeplopsAll]
	
GO

CREATE PROCEDURE [dbo].[usp_InsertXeplop]
	@MAHOCSINH int,
	@MALOP int
AS

SET NOCOUNT ON

INSERT INTO [dbo].[XEPLOP] (
	[MAHOCSINH],
	[MALOP]
) VALUES (
	@MAHOCSINH,
	@MALOP
)
GO

CREATE PROCEDURE [dbo].[usp_UpdateXeplop]
	@MAHOCSINH int,
	@MALOP int,
	@NEWMAHOCSINH int,
	@NEWMALOP int
AS

SET NOCOUNT ON

UPDATE [dbo].[XEPLOP] SET
	[MAHOCSINH] = @NEWMAHOCSINH,
	[MALOP] = @NEWMALOP
WHERE
	[MAHOCSINH] = @MAHOCSINH AND
	[MALOP] = @MALOP
GO

CREATE PROCEDURE [dbo].[usp_DeleteXeplop]
	@MALOP int,
	@MAHOCSINH int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[XEPLOP]
WHERE
	[MAHOCSINH] = @MAHOCSINH AND
	[MALOP] = @MALOP
GO

CREATE PROCEDURE [dbo].[usp_DeleteXeplopsByMALOP]
	@MALOP int
AS

SET NOCOUNT ON

DELETE FROM [dbo].[XEPLOP]
WHERE
	[MALOP] = @MALOP
GO

CREATE PROCEDURE [dbo].[usp_DeleteXeplopsDynamic]
	@WhereCondition nvarchar(500)
AS

SET NOCOUNT ON

DECLARE @SQL nvarchar(3250)

SET @SQL = '
DELETE FROM
	[dbo].[XEPLOP]
WHERE
	' + @WhereCondition

EXEC sp_executesql @SQL
GO

CREATE PROCEDURE [dbo].[usp_SelectXeplop]
	@MAHOCSINH int,
	@MALOP int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[MAHOCSINH],
	[MALOP]
FROM
	[dbo].[XEPLOP]
WHERE
	[MAHOCSINH] = @MAHOCSINH AND
	[MALOP] = @MALOP
GO

CREATE PROCEDURE [dbo].[usp_SelectXeplopsByMALOP]
	@MALOP int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[MAHOCSINH],
	[MALOP]
FROM
	[dbo].[XEPLOP]
WHERE
	[MALOP] = @MALOP
GO

CREATE PROCEDURE [dbo].[usp_SelectXeplopsByMAHOCSINH]
	@MAHOCSINH int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[MAHOCSINH],
	[MALOP]
FROM
	[dbo].[XEPLOP]
WHERE
	[MAHOCSINH] = @MAHOCSINH
GO

CREATE PROCEDURE [dbo].[usp_SelectXeplopsDynamic]
	@WhereCondition nvarchar(500),
	@OrderByExpression nvarchar(250) = NULL
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

DECLARE @SQL nvarchar(3250)

SET @SQL = '
SELECT
	[MAHOCSINH],
	[MALOP]
FROM
	[dbo].[XEPLOP]
WHERE
	' + @WhereCondition

IF @OrderByExpression IS NOT NULL AND LEN(@OrderByExpression) > 0
BEGIN
	SET @SQL = @SQL + '
ORDER BY
	' + @OrderByExpression
END

EXEC sp_executesql @SQL
GO

CREATE PROCEDURE [dbo].[usp_SelectXeplopsAll]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[MAHOCSINH],
	[MALOP]
FROM
	[dbo].[XEPLOP]
GO

--region ThamSo
IF OBJECT_ID(N'[dbo].[usp_SelectThamSoAll]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectThamSoAll]

IF OBJECT_ID(N'[dbo].[usp_UpdateThamSo]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_UpdateThamSo]
GO

CREATE PROCEDURE [dbo].[usp_SelectThamSoAll]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT *
FROM
	[dbo].[THAMSO]
GO

CREATE PROCEDURE [dbo].[usp_UpdateThamSo]
	@TUOITOIDA int,
	@TUOITOITHIEU int,
	@SISOTOIDA int,
	@DIEMTOIDA int,
	@DIEMTOITHIEU int,
	@ĐIEMDATMON int,
	@SOLOPTOIDAKHOI10 INT,
	@SOLOPTOIDAKHOI11 INT,
	@SOLOPTOIDAKHOI12 INT
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

UPDATE [dbo].[THAMSO]
SET [TUOITOIDA] = @TUOITOIDA ,
	[TUOITOITHIEU] = @TUOITOITHIEU,
	[SISOTOIDA] = @SISOTOIDA,
	[DIEMTOIDA] = @DIEMTOIDA,
	[DIEMTOITHIEU] = @DIEMTOITHIEU,
	[DIEMDATMON]= @ĐIEMDATMON,
	[SOLOPTOIDAKHOI10] = @SOLOPTOIDAKHOI10,
	[SOLOPTOIDAKHOI11] = @SOLOPTOIDAKHOI11,
	[SOLOPTOIDAKHOI12] = @SOLOPTOIDAKHOI12
GO

--region Utilities
IF OBJECT_ID(N'[dbo].[usp_SelectHocSinhChuaPhanLop]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectHocSinhChuaPhanLop]

IF OBJECT_ID(N'[dbo].[usp_SelectHocSinhTheoMALOP]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectHocSinhTheoMALOP]

IF OBJECT_ID(N'[dbo].[usp_SelectMALOPByMAHOCSINH_NAMHOC]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectMALOPByMAHOCSINH_NAMHOC]

IF OBJECT_ID(N'[dbo].[usp_SelectBaoCaoMonHocByNAMHOC_MONHOC_HOCKY]') IS NOT NULL
	DROP PROCEDURE [dbo].[usp_SelectBaoCaoMonHocByNAMHOC_MONHOC_HOCKY]
GO

--Lấy danh sách các học sinh chưa phân lớp
CREATE PROCEDURE [dbo].[usp_SelectHocSinhChuaPhanLop]
	@NAMHOC varchar(10)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT DISTINCT [dbo].[HOSOHOCSINH].MAHOCSINH, HOTEN, DIACHI, NGAYSINH, EMAIL, GIOITINH
FROM
	[dbo].[HOSOHOCSINH], [dbo].[XEPLOP], [dbo].[THAMSO]
WHERE
	[dbo].[HOSOHOCSINH].MAHOCSINH NOT IN(
										SELECT MAHOCSINH FROM [dbo].[XEPLOP], [dbo].[LOP]
										WHERE [dbo].[XEPLOP].MALOP = [dbo].[LOP].MALOP AND [dbo].[LOP].NAMHOC = @NAMHOC) 
		AND (CONVERT(int, SUBSTRING(@NAMHOC, 1, 4)) - year(NGAYSINH)) >=  (SELECT TOP 1 [TUOITOITHIEU] FROM THAMSO)
		AND (CONVERT(int, SUBSTRING(@NAMHOC, 1, 4)) - year(NGAYSINH)) <=  (SELECT TOP 1 [TUOITOIDA] FROM THAMSO)
GO

--Lấy danh sách học sinh theo lớp
CREATE PROCEDURE [dbo].[usp_SelectHocSinhTheoMALOP]
	@MALOP int
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT DISTINCT [dbo].[HOSOHOCSINH].MAHOCSINH, HOTEN, DIACHI, NGAYSINH, EMAIL, GIOITINH
FROM
	[dbo].[HOSOHOCSINH], [dbo].[XEPLOP]
WHERE
	[dbo].[HOSOHOCSINH].MAHOCSINH IN(SELECT MAHOCSINH FROM XEPLOP WHERE MALOP = @MALOP)
GO

--Lấy mã lớp của học sinh vào năm học
CREATE PROCEDURE [dbo].[usp_SelectMALOPByMAHOCSINH_NAMHOC]
	@MAHOCSINH int,
	@NAMHOC varchar(10)
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT DISTINCT [dbo].[XEPLOP].MALOP
FROM
	[dbo].[LOP], [dbo].[XEPLOP]
WHERE
	LOP.NAMHOC = @NAMHOC AND
	LOP.MALOP = XEPLOP.MALOP AND
	XEPLOP.MAHOCSINH = @MAHOCSINH

GO
CREATE PROCEDURE [dbo].[usp_SelectBaoCaoMonHocByNAMHOC_MONHOC_HOCKY]
	@MAMONHOC VARCHAR(5),
	@MAHOCKY INT,
	@NAMHOC VARCHAR(10)
AS
	DECLARE @MABAOCAOMON INT = (SELECT MABAOCAOMON FROM BAOCAOMONHOC WHERE [BAOCAOMONHOC].[NAMHOC] = @NAMHOC AND
																			[BAOCAOMONHOC].[MAMONHOC] = @MAMONHOC AND
																			[BAOCAOMONHOC].[MAHOCKY] = @MAHOCKY)
SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT  TENLOP, SISO, SOLUONGDAT
FROM
	CHITIETBAOCAOMON, LOP
WHERE
	MABAOCAOMON = @MABAOCAOMON AND
	CHITIETBAOCAOMON.MALOP = LOP.MALOP
