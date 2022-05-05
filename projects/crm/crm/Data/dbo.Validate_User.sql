
CREATE PROCEDURE [dbo].[Validate_User]
      @Username NVARCHAR(20),
      @Password NVARCHAR(20)
AS
BEGIN
      SET NOCOUNT ON;
      DECLARE @UserId INT, @LastLoginDate DATETIME, @ISACTIVE int
     
      SELECT @UserId = ID, @LastLoginDate = LASTLOGINDATE, @ISACTIVE = ISACTIVE
      FROM USUARIOS WHERE USUARIO = @Username AND [Password] = @Password
     
      IF @UserId IS NOT NULL
      BEGIN
            IF @ISACTIVE = 1
            BEGIN
                  UPDATE USUARIOS
                  SET LastLoginDate = GETDATE()
                  WHERE ID = @UserId
                  SELECT * from  USUARIOS where ID = @UserId-- User Valid
            END
            ELSE
            BEGIN
                  SELECT -2 -- User not activated.
            END
      END
      ELSE
      BEGIN
            SELECT -1 -- User invalid.
      END
END