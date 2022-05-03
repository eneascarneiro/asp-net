CREATE TABLE [dbo].[ADDRESS] (
    [ID]              INT           NOT NULL,
    [STREET]          VARCHAR (256) NULL,
    [CITY]            VARCHAR (100) NULL,
    [BUILDING_NUMBER] INT           NULL,
    [POSTCODE]        VARCHAR (20)  NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[COMPANY] (
    [ID]         INT           NOT NULL,
    [NAME]       VARCHAR (255) NULL,
    [BA_ACC_NUM] VARCHAR (200) NULL,
    [NIP]        VARCHAR (50)  NULL,
    [REGON]      VARCHAR (50)  NULL,
    [ADDRESS_ID] INT           NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([ADDRESS_ID]) REFERENCES [dbo].[ADDRESS] ([ID])
);

CREATE TABLE [dbo].[USUARIOS] (
    [ID]            INT           NOT NULL,
    [USUARIO]       VARCHAR (20)  NULL,
    [PASSWORD]      VARCHAR (20)  NULL,
    [CREATEDDATE]   DATETIME      NULL,
    [LASTLOGINDATE] DATETIME      NULL,
    [ISACTIVE]      INT           NULL,
    [EMAIL]         VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[CUSTOMER] (
    [ID]                  INT           NOT NULL,
    [NAME]                VARCHAR (255) NULL,
    [APELLIDO]            VARCHAR (200) NULL,
    [NACIONALIDAD]        VARCHAR (50)  NULL,
    [FECHA_DE_NACIMIENTO] DATETIME      NULL,
    [SEXO]                VARCHAR (50)  NULL,
    [ADDRESS_ID]          INT           NULL,
    [EMAIL]               VARCHAR (50)  NULL,
    [Usuario_id]          INT           NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([ADDRESS_ID]) REFERENCES [dbo].[ADDRESS] ([ID]),
    FOREIGN KEY ([Usuario_id]) REFERENCES [dbo].[USUARIOS] ([ID])
);
CREATE TABLE [dbo].[INVOICE] (
    [ID]                INT             NOT NULL,
    [INVOICE_NUMBER]    VARCHAR (50)    NOT NULL,
    [FECHA_EMISION]     DATE            NOT NULL,
    [PRECIO]            DECIMAL (10, 2) NOT NULL,
    [PAYMENTTYPE]       VARCHAR (20)    NULL,
    [CUSTOMER_ID]       INT             NOT NULL,
    [COMPANYID_ID]      INT             NOT NULL,
    [FECHA_VENCIMIENTO] DATE            NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([COMPANYID_ID]) REFERENCES [dbo].[COMPANY] ([ID]),
    FOREIGN KEY ([CUSTOMER_ID]) REFERENCES [dbo].[CUSTOMER] ([ID])
);
CREATE TABLE [dbo].[PEDIDOS] (
    [ID]           INT             NOT NULL,
    [PRECIO]       DECIMAL (10, 2) NOT NULL,
    [CUSTOMER_ID]  INT             NULL,
    [PRODUCT_ID]   INT             NULL,
    [FECHA_PEDIDO] DATETIME        NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([CUSTOMER_ID]) REFERENCES [dbo].[CUSTOMER] ([ID]),
    FOREIGN KEY ([PRODUCT_ID]) REFERENCES [dbo].[PRODUCTOS] ([ID])
);
CREATE TABLE [dbo].[PRODUCTOS] (
    [ID]           INT           NOT NULL,
    [NOMBRE_PROD]  VARCHAR (100) NULL,
    [DESCRIPCION]  VARCHAR (500) NULL,
    [COMPANYID_ID] INT           NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([COMPANYID_ID]) REFERENCES [dbo].[COMPANY] ([ID])
);
CREATE TABLE [dbo].[REL_CUSTOMER_ADDRESS] (
    [ID]          INT NOT NULL,
    [CUSTOMER_ID] INT NULL,
    [ADDRESS_ID]  INT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([CUSTOMER_ID]) REFERENCES [dbo].[CUSTOMER] ([ID]),
    FOREIGN KEY ([ADDRESS_ID]) REFERENCES [dbo].[ADDRESS] ([ID])
);

