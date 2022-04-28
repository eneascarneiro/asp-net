CREATE TABLE [Actor] (
          [ID] int NOT NULL IDENTITY,
          [Nombre] nvarchar(max) NOT NULL,
          [FechaNacimiento] datetime2 NOT NULL,
          [Edad] int NOT NULL,
          [Sexo] nvarchar(max) NOT NULL,
          CONSTRAINT [PK_Actor] PRIMARY KEY ([ID])
      );
      CREATE TABLE [Alumno] (
          [ID] int NOT NULL IDENTITY,
          [Nombre] nvarchar(max) NOT NULL,
          [Apellidos] nvarchar(max) NOT NULL,
          [Edad] int NOT NULL,
          [FechaDeNacimiento] datetime2 NOT NULL,
          [Genero] nvarchar(max) NOT NULL,
          [NotaMedia] decimal(18,2) NOT NULL,
          CONSTRAINT [PK_Alumno] PRIMARY KEY ([ID])
      );
      CREATE TABLE [Animal] (
          [ID] int NOT NULL IDENTITY,
          [Nombre] nvarchar(max) NOT NULL,
          [FechaNacimiento] datetime2 NOT NULL,
          [Edad] int NOT NULL,
          CONSTRAINT [PK_Animal] PRIMARY KEY ([ID])
      );
      CREATE TABLE [Director] (
          [ID] int NOT NULL IDENTITY,
          [Nombre] nvarchar(max) NOT NULL,
          [FechaNacimiento] datetime2 NOT NULL,
          [Edad] int NOT NULL,
          CONSTRAINT [PK_Director] PRIMARY KEY ([ID])
      );
      CREATE TABLE [Insecto] (
          [ID] int NOT NULL IDENTITY,
          [Nombre] nvarchar(max) NOT NULL,
          [Edad] int NOT NULL,
          CONSTRAINT [PK_Insecto] PRIMARY KEY ([ID])
      );
      CREATE TABLE [Pelicula] (
          [ID] int NOT NULL IDENTITY,
          [Title] nvarchar(max) NOT NULL,
          [ReleaseDate] datetime2 NOT NULL,
          [Genre] nvarchar(max) NOT NULL,
          [Price] decimal(18,2) NOT NULL,
          CONSTRAINT [PK_Pelicula] PRIMARY KEY ([ID])
      );
