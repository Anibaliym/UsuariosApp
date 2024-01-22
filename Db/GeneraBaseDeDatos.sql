-- create database "usuariosdb"

create table public."History" (
	"Id" uuid NULL,
	"AggregateId" uuid NULL,
	"Data" text NOT NULL,
	"Action" varchar(100) NULL,
	"Date" timestamp NULL,
	"User" text NOT NULL,
	constraint History_pk primary key ("Id")
);

create table if not exists public."Usuario"
(
    "Id" uuid not null,
    "IdPersona" uuid not null,
    "Nick" varchar(50) not null, 
    "Tipo" varchar(50) not null, 
    "Estado" varchar(50) not null, 
    constraint usuario_pk primary key ("Id")
); 

create table if not exists public."Seguridad"
(
    "Id" uuid not null,
    "IdUsuario" uuid not null,
    "Contrasena" varchar(50) not null, 
    "intentos" integer not null, 
    "FechaCreacion" timestamp not null, 
    constraint seguridad_pk primary key ("Id")
); 

create table if not exists public."Log"
(
    "Id" uuid not null,
    "IdUsuario" uuid not null,
    "Accion" varchar(50) not null, 
    "Observacion" varchar(255) not null,  
    "FechaCreacion" timestamp not null, 
    constraint log_pk primary key ("Id")
); 
