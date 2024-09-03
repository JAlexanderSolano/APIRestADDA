Scripts para ejecutar en la base de datos 
create database PruebaAdda;
USE [PruebaAdda]
GO
/****** Object:  Table [dbo].[application]    Script Date: 30/08/2024 4:14:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[application](
	[app_id] [bigint] IDENTITY(1,1) NOT NULL,
	[app_code] [varchar](60) NULL,
	[app_name] [varchar](60) NULL,
	[app_description] [varchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[app_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[company]    Script Date: 30/08/2024 4:14:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[company](
	[id_company] [bigint] IDENTITY(1,1) NOT NULL,
	[codigo_company] [varchar](60) NULL,
	[name_company] [varchar](60) NULL,
	[decription_company] [varchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_company] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TMP_LLENAR_CAMPOS]    Script Date: 30/08/2024 4:14:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TMP_LLENAR_CAMPOS](
	[id_company] [bigint] NULL,
	[codigo_company] [varchar](60) NULL,
	[name_company] [varchar](60) NULL,
	[description_company] [varchar](60) NULL,
	[version_id] [bigint] NULL,
	[app_id] [bigint] NULL,
	[version] [varchar](60) NULL,
	[version_description] [varchar](60) NULL,
	[version_company_id] [bigint] NULL,
	[company_id] [bigint] NULL,
	[version_company_description] [varchar](60) NULL,
	[app_code] [varchar](60) NULL,
	[app_name] [varchar](60) NULL,
	[app_description] [varchar](60) NULL,
	[id] [bigint] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[version]    Script Date: 30/08/2024 4:14:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[version](
	[version_id] [bigint] IDENTITY(1,1) NOT NULL,
	[app_id] [bigint] NULL,
	[version] [varchar](60) NULL,
	[version_description] [varchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[version_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[version_company]    Script Date: 30/08/2024 4:14:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[version_company](
	[version_company_id] [bigint] IDENTITY(1,1) NOT NULL,
	[company_id] [bigint] NULL,
	[version_id] [bigint] NULL,
	[version_company_description] [varchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[version_company_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[version]  WITH CHECK ADD FOREIGN KEY([app_id])
REFERENCES [dbo].[application] ([app_id])
GO
ALTER TABLE [dbo].[version_company]  WITH CHECK ADD FOREIGN KEY([company_id])
REFERENCES [dbo].[company] ([id_company])
GO
ALTER TABLE [dbo].[version_company]  WITH CHECK ADD FOREIGN KEY([version_id])
REFERENCES [dbo].[version] ([version_id])
GO
------------ Procedimiento alamacenado -------------------------------------
/****** Object:  StoredProcedure [dbo].[sp_ingresarDatos]    Script Date: 30/08/2024 4:14:40 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Alexander Solano
-- Create date: 2024-08-30
-- Description:	Procedimiento almacenado para ingresar informacion a las 4 tablas 
-- =============================================
CREATE PROCEDURE [dbo].[sp_ingresarDatos] 
	-- parametros de compañia 
	@codigo_company varchar(60),
	@name_company varchar(60),
	@description_company varchar(60),
	--- parametros de aplicacion
	@app_code varchar(60),
	@app_name varchar(60),
	@app_description varchar(60),
	-- parametros de version 
	@version varchar(60),
	@version_description varchar(60),
	-- parametros de version company
	@version_company_description varchar(60),
	-- parametro de salida 
	@result varchar(60) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   -- declaramos variables internas que se encargaran de asignar el valor de las fk asignadas
	  declare @version_id bigint;
	  declare @company_id bigint;
	  declare @app_id bigint; 

  -- primero llenamos la tabla de compañia 
	  insert into company([codigo_company], [name_company], [decription_company])
	  values (@codigo_company, @name_company, @description_company)
	  -- obtenemos el id registrado en la tabla correspondiente
	  set @company_id = (select SCOPE_IDENTITY())

  -- segundo llenamos la tabla de aplicacion
	  insert into application ([app_code], [app_name], [app_description])
	  values (@app_code, @app_name, @app_description)
	  -- obtenemos el id registrado en la tabla correspondiente
	  set @app_id = (select SCOPE_IDENTITY())

-- tercero llenamos la tabla de version 
	  insert into version ([app_id], [version], [version_description])
	  values (@app_id, @version, @version_description)
-- obtenemos el id registrado en la tabla correspondiente
	  set @version_id = (select SCOPE_IDENTITY())
	
-- cuarto llenamos la tabla de version company
	  insert into version_company ([company_id], [version_id], [version_company_description])
	  values (@company_id, @version_id, @version_company_description)

 set @result = (select 'Información guardada con exito' as result)
END
GO
USE [PruebaAdda]

-------- Trigger ------------------------
USE [PruebaAdda]
GO
/****** Object:  Trigger [dbo].[Trg_IngresarDatos]    Script Date: 3/09/2024 2:32:20 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Alexander Solano 
-- Create date: 2024-08-30
-- Description:	Trigger para obtener datos de la tabla temporal e ingresarlos al sp 
-- =============================================
ALTER TRIGGER [dbo].[Trg_IngresarDatos] 
   ON  [dbo].[TMP_LLENAR_CAMPOS] 
   AFTER insert, update, delete
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	-- declaramos las variables para enviar al sp 
	-- parametros de compañia 
	declare @codigo_company varchar(60)
	declare @name_company varchar(60)
	declare @description_company varchar(60)
	--- parametros de aplicacion
	declare @app_code varchar(60)
	declare @app_name varchar(60)
	declare @app_description varchar(60)
	-- parametros de version 
	declare @version varchar(60)
	declare @version_description varchar(60)
	-- parametros de version company
	declare @version_company_description varchar(60)
 -- obtener los datos de la tabla temporal el ultimo registro ingresado
	if EXISTS(select top 1 * from inserted i order by i.id desc)
	begin
		if EXISTS (select top 1* from deleted d order by d.id desc)
		begin
		 --- actualizar
			-- update de compañia 
			if(UPDATE([codigo_company]) or UPDATE([name_company]) or UPDATE([description_company]))
			begin
				update company set codigo_company = i.codigo_company, name_company = i.name_company,
				decription_company = i.description_company
				from inserted i 
				where company.id_company = i.id_company
			end
			-- update de aplicacion 
			if(UPDATE([app_code]) or UPDATE([app_name]) or UPDATE([app_description]))
			begin
				update application set app_code = i.app_code, app_name = i.app_name, app_description = i.app_description 
				from inserted i
				where application.app_id = i.app_id
			end
			-- update de version
			if(UPDATE([version]) or UPDATE([version_description]))
			begin
				update version set version = i.version, version_description = i.version_description 
				from inserted i
				where version.version_id = i.version_id
			end
		end
		else
		begin
		  -- insertar 
			select top 1  
			@codigo_company = codigo_company,
			@name_company = name_company,
			@description_company = description_company,
			@app_code = app_code,
			@app_name = app_name,
			@app_description = app_description,
			@version = version,
			@version_description = version_description,
			@version_company_description = version_company_description
			from  TMP_LLENAR_CAMPOS 
			order by id desc 
			-- una vez obteniendo esto ejecutamos el procedimiento almacenado y si el mensaje es exitoso indicamos un OK
			declare @insertoint int
			declare @mensaje varchar(60)
			exec @insertoint = [dbo].[sp_ingresarDatos] @codigo_company, @name_company, @description_company, @app_code, @app_name, @app_description, @version, @version_description, @version_company_description, @mensaje output
			if @mensaje = 'Información guardada con exito'
			begin
				print 'OK'
			end
		end
	end
	else 
	begin
		-- proceso para eliminar 
		delete vc from version_company vc
		where vc.version_company_id in (select d.version_company_id from deleted d where 
		d.version_company_id = d.id)
		delete v from version v 
		where v.version_id in (select d.version_id from deleted d where d.version_id = d.id)
		delete a from application a
		where a.app_id in (select d.app_id from deleted d where d.app_id = d.id)
		delete c from company c 
		where c.id_company in (select d.company_id from deleted d where d.company_id = d.id)
	end 
END
