﻿CREATE PROCEDURE [dbo].[UserLogin]
	@Email VARCHAR(50),
	@Password VARCHAR(50)
AS 
	BEGIN
		DECLARE @Salt VARCHAR(100);
		SET @Salt = (SELECT Salt FROM [User] WHERE Email like @Email)

		DECLARE @password_hash VARBINARY(64);
		SET @password_hash = HASHBYTES('SHA2_512', CONCAT(@Salt, @Password, @Salt));
		SELECT Email, UserId, IsClient FROM [User] WHERE Email LIKE @Email AND [Password] = @password_hash
	END