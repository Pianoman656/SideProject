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
	doctor_id int identity(1,1), --PK
    last_name varchar(64) not null,
    first_name varchar(64) not null,
	specialty varchar(64) not null,

	constraint pk_member primary key (doctor_Id)
);

CREATE TABLE patient
(
	patient_id int identity (1,1), --PK
	last_name varchar(32) not null,
	first_name varchar(100) not null,
	date_Of_birth datetime not null,
	insurance_verified bit not null,  


	constraint pk_patient primary key (patient_id)
);

CREATE TABLE appointment
(
	appointment_id int identity (1,1),
	patient_id int not null,
	doctor_id int not null,
	start_time datetime not null,
	reason_for_visit varchar(1000) not null,

	constraint pk_appointment primary key (appointment_id),
	constraint fk_appointment_doctor foreign key (doctor_id) references doctor(doctor_id),
	constraint fk_appointment_patient foreign key (patient_id) references patient(patient_id)
);

COMMIT TRANSACTION;

