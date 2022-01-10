
/**
create database webapp;
use webapp;
create table employee (
	id int IDENTITY(1,1) PRIMARY KEY,
	title char(20) NOT NULL,
	first_name varchar(255) NOT NULL,
	last_name varchar(255),
	designation varchar(255),
	dob date,
	father_name varchar(255),
	department char(100),
	gender char(20),
	spouse_name varchar(255),
	permanent_address varchar(1000),
	temporary_address varchar(1000),
	avatar_path varchar(300),
	created_at datetime,
	updated_at datetime
);

INSERT INTO [dbo].[employee]
           ([title]
           ,[first_name]
           ,[last_name]
           ,[designation]
           ,[dob]
           ,[father_name]
           ,[department]
           ,[gender]
           ,[spouse_name]
           ,[permanent_address]
           ,[temporary_address]
           ,[avatar_path]
           ,[created_at]
           ,[updated_at])
     VALUES
           ('Mr'
           ,'Bishwanath'
           ,'Jha'
           ,'Software Engg'
           ,'1990-08-25'
           ,'Binay Jha'
           ,'IT'
           ,'Male'
           ,'test'
           ,'Bihar'
           ,'Chattarpur'
           ,'test'
           ,GETDATE()
           ,GETDATE())
GO*/


-- create database webapp;
-- select * from dbo.employee
-- sp_help employee;

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddEmployeeReturnID]
      @title varchar(20),
      @first_name varchar(255),
      @last_name varchar(255),
      @designation varchar(255),
      @dob date,
	  @father_name varchar(255),
	  @department varchar(100),
	  @gender char(20),
	  @spouse_name varchar(255),
	  @permanent_address varchar(1000),
	  @temporary_address varchar(1000),
	  @avatar_path varchar(300),
	  @created_at datetime
AS
BEGIN
      SET NOCOUNT ON;
      INSERT INTO [dbo].[employee]
           ([title]
           ,[first_name]
           ,[last_name]
           ,[designation]
           ,[dob]
           ,[father_name]
           ,[department]
           ,[gender]
           ,[spouse_name]
           ,[permanent_address]
           ,[temporary_address]
           ,[avatar_path]
           ,[created_at])
     VALUES
           (@title
           ,@first_name
           ,@last_name
           ,@designation
           ,@dob
           ,@father_name
           ,@department
           ,@gender
           ,@spouse_name
           ,@permanent_address
           ,@temporary_address
           ,@avatar_path
           ,@created_at)
      SELECT SCOPE_IDENTITY()
END

select * from employee;
