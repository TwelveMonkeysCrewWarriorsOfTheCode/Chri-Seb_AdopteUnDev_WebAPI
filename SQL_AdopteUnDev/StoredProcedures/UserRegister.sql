CREATE PROCEDURE [dbo].[UserRegister]
	@Name VARCHAR(50),
	@Telephone VARCHAR(50),
	@Email VARCHAR(50),
	@Password VARCHAR(50),
	@IsClient BIT = 0
AS 
	BEGIN
		DECLARE @Salt VARCHAR(100);
		SET @Salt = CONCAT(NEWID(), NEWID(), NEWID())

		DECLARE @password_hash VARBINARY(64);
		SET @password_hash = HASHBYTES('SHA2_512', CONCAT(@Salt, @Password, @Salt));

		INSERT INTO [User] ([Name], [Telephone], [Email], [Password], [Salt], [IsClient])
		VALUES (@Name, @Telephone, @Email, @password_hash, @Salt, @IsClient)
	END