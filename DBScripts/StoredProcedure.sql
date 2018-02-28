USE [Knightfury]
GO

/****** Object:  StoredProcedure [dbo].[USP_CRUD_Students]    Script Date: 2/28/2018 4:07:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--====================================
--Author: Sathappa Subramaniam.S
--Desc  : CRUD Procedure for MVC App
--====================================
CREATE PROC [dbo].[USP_CRUD_Students]
@Operation CHAR(2), 
@Student_TblRefID INT = NULL,
@Student_Name NVARCHAR(64) = NULL,
@Student_City NVARCHAR(64) = NULL,
@Student_Address NVARCHAR(128) = NULL
AS
BEGIN TRY
DECLARE @Error_Message NVARCHAR(1024)

/*CREATE*/
IF @Operation = 'C'
BEGIN
	INSERT INTO M_Students (Student_Name, Student_City, Student_Address) VALUES (@Student_Name, @Student_City, @Student_Address)
END
/*READ*/
ELSE IF @Operation LIKE '%R'
BEGIN
	IF @Operation = 'SR'
	BEGIN
		PRINT 'Single Read'
		SELECT Student_TblRefID, Student_Name, Student_City, Student_Address FROM M_Students WHERE Student_TblRefID = @Student_TblRefID
	END
	ELSE IF @Operation = 'MR'
	BEGIN
		PRINT 'Multiple Read'
		SELECT Student_TblRefID, Student_Name, Student_City, Student_Address FROM M_Students
	END
END
/*UPDATE*/
ELSE IF @Operation = 'U' 
BEGIN
	UPDATE M_Students 
	SET 
	Student_Name = @Student_Name, 
	Student_City = @Student_City, 
	Student_Address = @Student_Address,
	UpdatedDateTime = GETDATE()
	WHERE Student_TblRefID = @Student_TblRefID
END
/*DELETE*/
ELSE IF @Operation = 'D' 
BEGIN
	DELETE FROM M_Students WHERE Student_TblRefID = @Student_TblRefID
END
END TRY

BEGIN CATCH
	IF XACT_STATE() != 0 ROLLBACK TRANSACTION
	SET @Error_Message = ERROR_MESSAGE()
	RAISERROR(@Error_Message, 16, 1)
END CATCH

GO


