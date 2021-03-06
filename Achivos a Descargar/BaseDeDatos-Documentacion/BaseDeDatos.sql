/****** EJECUTAR TODO  ******/
CREATE DATABASE Usuarios    
GO

USE [Usuarios]
GO
/****** Object:  Table [dbo].[Area]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionA] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[idC] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](55) NOT NULL,
	[Apellido] [varchar](55) NOT NULL,
	[Mail] [varchar](255) NOT NULL,
	[Areaid] [int] NOT NULL,
	[FechaDeNacimiento] [datetime] NOT NULL,
	[Salario] [money] NULL,
	[usuario] [varchar](50) NULL,
	[clave] [varchar](500) NULL,
	[Perfilid] [int] NULL,
 CONSTRAINT [PK__Clientes__71ABD0A7EBEEE970] PRIMARY KEY CLUSTERED 
(
	[idC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfiles]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfiles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DescripcionP] [varchar](80) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Area] ON 

INSERT [dbo].[Area] ([id], [DescripcionA]) VALUES (1, N'Seleccionar')
INSERT [dbo].[Area] ([id], [DescripcionA]) VALUES (2, N'Operaciones')
INSERT [dbo].[Area] ([id], [DescripcionA]) VALUES (3, N'Liquidacion')
INSERT [dbo].[Area] ([id], [DescripcionA]) VALUES (4, N'Administracion')
INSERT [dbo].[Area] ([id], [DescripcionA]) VALUES (5, N'Auditoria')
SET IDENTITY_INSERT [dbo].[Area] OFF
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([idC], [Nombre], [Apellido], [Mail], [Areaid], [FechaDeNacimiento], [Salario], [usuario], [clave], [Perfilid]) VALUES (1, N'Carlos', N'Gomez', N'gomez@gmail.com', 4, CAST(N'1997-12-02T00:00:00.000' AS DateTime), NULL, N'carl01', N'a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3', 2)
INSERT [dbo].[Clientes] ([idC], [Nombre], [Apellido], [Mail], [Areaid], [FechaDeNacimiento], [Salario], [usuario], [clave], [Perfilid]) VALUES (2, N'Samanta', N'Sosa', N'sosa@hotmail.com', 3, CAST(N'1990-04-03T00:00:00.000' AS DateTime), NULL, N'sam02', N'e9cee71ab932fde863338d08be4de9dfe39ea049bdafb342ce659ec5450b69ae', 3)

SET IDENTITY_INSERT [dbo].[Clientes] OFF
SET IDENTITY_INSERT [dbo].[Perfiles] ON 

INSERT [dbo].[Perfiles] ([id], [DescripcionP]) VALUES (1, N'Seleccionar')
INSERT [dbo].[Perfiles] ([id], [DescripcionP]) VALUES (2, N'Administracion')
INSERT [dbo].[Perfiles] ([id], [DescripcionP]) VALUES (3, N'Liquidacion')
INSERT [dbo].[Perfiles] ([id], [DescripcionP]) VALUES (4, N'Usuario')
SET IDENTITY_INSERT [dbo].[Perfiles] OFF
ALTER TABLE [dbo].[Clientes] ADD  CONSTRAINT [DF_Clientes_Salario]  DEFAULT (($0.0000)) FOR [Salario]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [Areas] FOREIGN KEY([Areaid])
REFERENCES [dbo].[Area] ([id])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [Areas]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [idandPerfilid] FOREIGN KEY([Perfilid])
REFERENCES [dbo].[Perfiles] ([id])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [idandPerfilid]
GO
/****** Object:  StoredProcedure [dbo].[buscarnombre]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[buscarnombre]
@Buscar nvarchar (100)
as


select idC as ID,Nombre as NOMBRE,Apellido AS APELLIDO,Mail AS MAIL ,DescripcionA AS AREA,FechaDeNacimiento AS FECHA_DE_NACIMIENTO,DescripcionP AS PERFIL from Clientes
inner join Area ON Clientes.Areaid=Area.id
inner join Perfiles on Clientes.Perfilid=Perfiles.id

where Nombre like @Buscar +'%' or Apellido like @Buscar +'%'  or Area.DescripcionA LIKE @Buscar +'%'  or Perfiles.DescripcionP LIKE @Buscar +'%'  or Mail LIKE @Buscar +'%' 
GO
/****** Object:  StoredProcedure [dbo].[buscarTablaSalario]    Script Date: 17/3/2020 10:17:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[buscarTablaSalario]
@Buscar nvarchar (100)
as
select idC AS ID,Nombre AS NOMBRE ,Apellido AS APELLIDO ,Mail AS MAIL,DescripcionA as AREA,Salario AS SUELDO from Clientes
inner join Area ON Clientes.Areaid=Area.id
inner join Perfiles on Clientes.Perfilid=Perfiles.id
where Nombre like @Buscar +'%' or Apellido like @Buscar +'%'  or Area.DescripcionA LIKE @Buscar +'%'  or Mail LIKE @Buscar +'%' 
GO
/****** Object:  StoredProcedure [dbo].[EditarArea]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[EditarArea]
@id int ,
@DescripcionA varchar(55)
as
update Area set DescripcionA = @DescripcionA 
where id=@id
GO
/****** Object:  StoredProcedure [dbo].[EliminarArea]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[EliminarArea]
@id int 
as
delete Area where id= @id
GO
/****** Object:  StoredProcedure [dbo].[EliminarRegistro]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[EliminarRegistro]
@idC int 
as
delete Clientes where idC= @idC
GO
/****** Object:  StoredProcedure [dbo].[InsertarArea]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[InsertarArea]
@DescripcionA varchar (55)
as
insert into Area (DescripcionA) VALUES (@DescripcionA)
GO
/****** Object:  StoredProcedure [dbo].[ListaArea]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ListaArea]
as
select * from Area
GO
/****** Object:  StoredProcedure [dbo].[ListaPerfiles]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ListaPerfiles]
as
select * from Perfiles
GO
/****** Object:  StoredProcedure [dbo].[ListarTablaArea]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ListarTablaArea]
as
select id as ID ,DescripcionA as NOMBRE  from Area
GO
/****** Object:  StoredProcedure [dbo].[ListaUsuarios]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[ListarTablaArea2]
as
select id as ID ,DescripcionA as NOMBRE  from Area where id!=1
GO
/****** Object:  StoredProcedure [dbo].[ListaUsuarios]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[ListaUsuarios]
as
select * from Clientes
GO
/****** Object:  StoredProcedure [dbo].[Modificartabla]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Modificartabla] 
@idC int ,
@Nombre varchar(55),
@Apellido varchar(55),
@Mail varchar (255),
@Areaid int ,
@FechaDeNacimiento datetime,
@Perfilid int 
as
update Clientes set Nombre=@Nombre ,Apellido=@Apellido,Mail=@Mail,Areaid=@Areaid,FechaDeNacimiento=@FechaDeNacimiento,Perfilid=@Perfilid 
where idC=@idC
GO
/****** Object:  StoredProcedure [dbo].[ModificartablaSalario]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ModificartablaSalario] 
@idC int,
@Salario money
as
update Clientes set Salario=@Salario
where idC=@idC
GO
/****** Object:  StoredProcedure [dbo].[MostrarTablaClientes2]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[MostrarTablaClientes2]
as
select idC as ID,Nombre as NOMBRE,Apellido AS APELLIDO,Mail AS MAIL ,DescripcionA AS AREA,FechaDeNacimiento AS FECHA_DE_NACIMIENTO,DescripcionP AS PERFIL from Clientes
inner join Area ON Clientes.Areaid=Area.id
inner join Perfiles on Clientes.Perfilid=Perfiles.id
GO
/****** Object:  StoredProcedure [dbo].[MostrarTablaSalario]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[MostrarTablaSalario]
as
select idC AS ID,Nombre AS NOMBRE ,Apellido AS APELLIDO ,Mail AS MAIL ,DescripcionA as AREA,Salario AS SUELDO from Clientes
inner join Area ON Clientes.Areaid=Area.id 
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarUsuario]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertarUsuario]
@Nombre varchar (55) ,
@Apellido varchar (55),
@Mail varchar(255) ,
@Areaid int ,
@FechaDeNacimiento datetime,
@Perfilid int 
as
insert into Clientes(Nombre,Apellido,Mail,Areaid,FechaDeNacimiento,Perfilid) VALUES (@Nombre,@Apellido ,@Mail,@Areaid,@FechaDeNacimiento,@Perfilid)
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'$
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Clientes', @level2type=N'COLUMN',@level2name=N'Salario'
GO
