USE [EmpresaDB];
GO
CREATE OR ALTER PROCEDURE dbo.sp_ListarClientes
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ClienteID, Nombre, CorreoElectronico FROM dbo.Clientes ORDER BY ClienteID;
END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_ObtenerClientePorId
    @ClienteID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ClienteID, Nombre, CorreoElectronico FROM dbo.Clientes WHERE ClienteID = @ClienteID;
END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_CrearCliente
    @Nombre NVARCHAR(100),
    @CorreoElectronico NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Clientes (Nombre, CorreoElectronico) VALUES (@Nombre, @CorreoElectronico);
END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_EditarCliente
    @ClienteID INT,
    @Nombre NVARCHAR(100),
    @CorreoElectronico NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Clientes SET Nombre = @Nombre, CorreoElectronico = @CorreoElectronico WHERE ClienteID = @ClienteID;
END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_ListarPedidos
AS
BEGIN
    SET NOCOUNT ON;
    SELECT PedidoID, FechaPedido, Monto, Estado, ClienteID FROM dbo.Pedidos ORDER BY PedidoID;
END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_ObtenerPedidoPorId
    @PedidoID INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT PedidoID, FechaPedido, Monto, Estado, ClienteID FROM dbo.Pedidos WHERE PedidoID = @PedidoID;
END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_CrearPedido
    @FechaPedido DATE,
    @Monto DECIMAL(10,2),
    @Estado NVARCHAR(50),
    @ClienteID INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Pedidos (FechaPedido, Monto, Estado, ClienteID) VALUES (@FechaPedido, @Monto, @Estado, @ClienteID);
END;
GO
CREATE OR ALTER PROCEDURE dbo.sp_EditarPedido
    @PedidoID INT,
    @FechaPedido DATE,
    @Monto DECIMAL(10,2),
    @Estado NVARCHAR(50),
    @ClienteID INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Pedidos SET FechaPedido = @FechaPedido, Monto = @Monto, Estado = @Estado, ClienteID = @ClienteID WHERE PedidoID = @PedidoID;
END;
GO
