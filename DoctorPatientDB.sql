USE master;
GO

DROP DATABASE IF EXISTS DoctorPatient;

CREATE DATABASE DoctorPatient;
GO

USE DoctorPatient;
GO

BEGIN TRANSACTION;



CREATE TABLE doctor
(
	doctorId int identity(1,1), --PK
    lastName varchar(64) not null,
    firstName varchar(64) not null,
	specialty varchar(64) not null,

	constraint pk_member primary key (doctorId)
);

CREATE TABLE patient
(
	patientId int identity (1,1), --PK
	lastName varchar(32) not null,
	firstName varchar(100) not null,
	patientDurationMinutes int not null check(patientDurationMinutes >= 30), -- min 30 minutes
	dateOfBirth datetime not null,
	hasInsurance bit not null,  


	constraint pk_patient primary key (patientId),
);

CREATE TABLE appointment
(
	appointmentId int identity (1,1)

	constraint pk_appointment primary key (appointmentId)
)
	
COMMIT TRANSACTION;