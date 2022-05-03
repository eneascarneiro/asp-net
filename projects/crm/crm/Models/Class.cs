using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crm.Models
{
    public class Address
    {
        public int ID { get; set; }
        [StringLength(256)]
        [Required]
        [Display(Name = "Calle")]
        public string Street { get; set; } = "";
        [StringLength(100)]
        [Required]
        [Display(Name = "Ciudad")]
        public string City { get; set; } = "";
        [Display(Name = "Numero")]
        [Column("Building_Number")]
        public int BuidingNumber { get; set; }
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Codigo postal")]
        [DataType(DataType.PostalCode)]
        [Required]
        public string PostCode { get; set; } = "00000";
        public virtual Customer Customer { get; set; }
        public virtual Company Company { get; set; }
    }


    public class Company
    {
        
        public int ID { get; set; }
        //
        [StringLength(255)]
        [Required]
        [Display(Name = "Nombre empresa")]
        public string Name { get; set; }
        //
        [StringLength(200)]
        [Display(Name = "Cuenta bancaria")]
        public int Ba_Acc_Num { get; set; }
        //
        [StringLength(200)]
        [Required]
        [Display(Name = "Número de identificación fiscal")]
        public string  NIP { get; set; }
        //
        [StringLength(50)]
        [Display(Name = "Número de identificación fiscal")]
        public string Region { get; set; } = "";
        //
        [ForeignKey("Address")]
        public int Address_Id { get; set; }

        public virtual Address Address { get; set; }
    }
    

    /*
     CREATE TABLE "COMPANY" ( "ID" INTEGER NOT NULL,
       "NAME" VARCHAR(255),
       "BA_ACC_NUM" VARCHAR(200),
       "NIP" VARCHAR(50),
       "REGON" VARCHAR(50),
       "ADDRESS_ID" INTEGER,
       PRIMARY KEY ("ID"),
       FOREIGN KEY ("ADDRESS_ID") REFERENCES ADDRESS); 
     */

    public class Customer
    {

        public int ID { get; set; }
        //
        [StringLength(255)]
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        //
        [StringLength(200)]
        [Required]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        //
        [StringLength(50)]
        [Required]
        [Display(Name = "Nacionalidad")]
        public string Nacionalidad { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_De_Nacimiento { get; set; }
        //
        [StringLength(50)]
        [Required]
        [Display(Name = "Sexo")]

        public string Sexo { get; set; } = "";

        //
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        [Required]
        [Display(Name = "Email")]
        public String Email { get; set; }
        //
        [ForeignKey("Address")]
        [Display(Name = "Calle")]
        public int Address_Id { get; set; }
        public virtual Address Address { get; set; }
        //
        [ForeignKey("Usuarios")]
        [Column("Usuario_id")]
        [Display(Name = "Usuario")]
        public int User_Id { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
    /*
     CREATE TABLE "CUSTOMER" ( "ID" INTEGER NOT NULL,
       "NAME" VARCHAR(255),
       "APELLIDO" VARCHAR(200),
       "NACIONALIDAD" VARCHAR(50),
       "FECHA_DE_NACIMIENTO" VARCHAR(50),
       "SEXO" VARCHAR(50),
       "ADDRESS_ID" int,
       PRIMARY KEY ("ID"),
       FOREIGN KEY ("ADDRESS_ID") REFERENCES ADDRESS);
     */
    public class Invoice
    {

        public int ID { get; set; }
        //
        [Display(Name = "Número de factura")]
        [Required]
        [StringLength(50)]
        public String INVOICE_NUMBER { get; set; }

        //
        [Display(Name = "Fecha de emisión")]
        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FECHA_EMISION { get; set; }
        //
        [Display(Name = "Fecha de vencimiento")]
        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FECHA_VENCIMIENTO { get; set; }
        //
        [Display(Name = "Precio")]
        [Required]
        public float  PRECIO { get; set; }
        //
        [Display(Name = "Medio de pago")]
        [StringLength(50)]
        public String PAYMENTTYPE { get; set; } = "Credit Card";

        //
        [ForeignKey("Customer")]
        public int Customer_Id { get; set; }
        public virtual Customer Customer { get; set; }

        //
        [ForeignKey("Company")]
        public int Company_Id { get; set; }
        public virtual Company Company { get; set; }
        
        
    }
    /*
     *CREATE TABLE [dbo].[INVOICE] (
    [ID]           INT             NOT NULL,
    [INVOICE_NUMBER]          VARCHAR(50)             NOT NULL,
    [FECHA_EMISION]         DATE            NOT NULL,
    [PRECIO]       DECIMAL (10, 2) NOT NULL,
    [PAYMENTTYPE]  VARCHAR (20)    NULL,
    [CUSTOMER_ID]  INT             NOT NULL,
    [COMPANYID_ID] INT             NOT NULL,
    [FECHA_VENCIMIENTO] DATE NOT NULL, 
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([CUSTOMER_ID]) REFERENCES [dbo].[CUSTOMER] ([ID]),
    FOREIGN KEY ([COMPANYID_ID]) REFERENCES [dbo].[COMPANY] ([ID])
);
    */
    public class Pedidos
    {

        public int ID { get; set; }
        //
        [Display(Name = "Precio")]
        [Required]
        public float PRECIO { get; set; }
        //
        [Display(Name = "Fecha de pedido")]
        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FECHA_PEDIDO { get; set; }
        
        //
        [ForeignKey("Customer")]
        public int Customer_Id { get; set; }
        public virtual Customer Customer { get; set; }

        //
        [ForeignKey("Company")]
        public int Company_Id { get; set; }
        public virtual Company Company { get; set; }
        
        
    }

    /*
    CREATE TABLE [dbo].[PEDIDOS] (
    [ID]          INT             NOT NULL,
    [PRECIO]      DECIMAL (10, 2) NOT NULL,
    [CUSTOMER_ID] INT             NULL,
    [PRODUCT_ID]  INT             NULL,
    [FECHA_PEDIDO] DATETIME NOT NULL, 
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([CUSTOMER_ID]) REFERENCES [dbo].[CUSTOMER] ([ID]),
    FOREIGN KEY ([PRODUCT_ID]) REFERENCES [dbo].[PRODUCTOS] ([ID])
);

    */
    public class Productos
    {

        public int ID { get; set; }
        //
        [Display(Name = "Nombre")]
        [Required]
        [StringLength(100)]
        public String NOMBRE_PROD { get; set; } = "";
        //
        [Display(Name = "Descripción")]
        [Required]
        [StringLength(500)]
        public String DESCRIPCION { get; set; }
        //
        [ForeignKey("Company")]
        public int Company_Id { get; set; }
        public virtual Company Company { get; set; }
    }
    /*
     * CREATE TABLE [dbo].[PRODUCTOS] (
    [ID]           INT           NOT NULL,
    [NOMBRE_PROD]  VARCHAR (100) NULL,
    [DESCRIPCION]  VARCHAR (500) NULL,
    [COMPANYID_ID] INT           NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([COMPANYID_ID]) REFERENCES [dbo].[COMPANY] ([ID])
);
     */

    public class Usuarios
    {
        public int ID { get; set; }
        //
        [Display(Name = "Nonbre de usuario")]
        [Required]
        [StringLength(20)]
        public String USUARIO { get; set; } = "";
        //
        [Display(Name = "Password")]
        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "La password debe tener como mínimo 8 caracteres")]
        [DataType(DataType.Password)]
        public String PASSWORD { get; set; } = "";
        [Display(Name = "Fecha de creacíón")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CREATEDDATE { get; set; }
        [Display(Name = "Fecha login")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LASTLOGINDATE { get; set; }
        //
        public int ISACTIVE { get; set; }
        //
        [Display(Name = "Email")]
        [StringLength(100)]
        public String EMAIL { get; set; } = "";
    }
    /*
     *CREATE TABLE [dbo].[USUARIOS] (
    [ID]            INT           NOT NULL,
    [USUARIO]       VARCHAR (20)  NULL,
    [PASSWORD]      VARCHAR (20)  NULL,
    [CREATEDDATE]   DATETIME      NULL,
    [LASTLOGINDATE] DATETIME      NULL,
    [ISACTIVE]      INT           NULL,
    [EMAIL]         VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);
);

     */
}
