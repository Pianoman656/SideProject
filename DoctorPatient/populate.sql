

INSERT INTO doctor ( last_name, first_name, specialty) -- add schedule
OUTPUT INSERTED.doctor_id
VALUES  ('Sampson', 'J', 'Cardiology'),
		('Summer', '', 'Neurology'),
		('Silva', 'Bart', 'Psychiatry'),
		('Doolittle', 'Lisa', 'Vet'),
		('Doom', 'Maggie', 'Pharmacology'),
		('Ventura', 'Abraham', 'Brain Salad'),
		('Simpson', 'Mona', 'Physical Therapy'),
		('Flanders', 'Ned', 'Anesthesiwhatever'),
		('Burns', 'Charles Montgomery Plantagenet Schicklgruber','internal medicine'),
		('Itchy', 'Dr', 'Dermatologist');	

INSERT INTO patient ( last_name, first_name, date_of_birth, insurance_verified)
OUTPUT INSERTED.patient_id
VALUES  ('Smith', 'Jim', '1990-5-21', 1),
		('Jones', 'Sam', '1990-5-21', 1),
		('Hille', 'Joe', '1992-4-21', 1),
		('Dickey', 'Laura', '1995-6-21', 0),
		('McConahy', 'Mara', '1970-5-22', 0),
		('Nass', 'Edwin', '1920-5-29', 1),
		('Conricote', 'Kurt', '1960-5-28', 1),
		('Flanders', 'Ned', '1980-5-26', 1),
		('Burns', 'Side','2000-5-24', 0),
		('Bobertson', 'Bob', '1991-5-22', 0);
		
INSERT INTO appointment ( patient_id, doctor_id, start_time, reason_for_visit )
OUTPUT INSERTED.appointment_id
Values (1, 5, '2022-06-21 08:00:00', 'thorn in butt'),
	   (2, 4, '2022-07-21 08:00:00', 'thorn in paw'),
	   (3, 3, '2022-08-21 08:00:00', 'thorn in feelings'),
	   (4, 2, '2022-09-21 08:00:00', 'thorn in brain'),
	   (5, 1, '2022-10-21 08:00:00', 'thorn in heart');


SELECT * FROM appointment;