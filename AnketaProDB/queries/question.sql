CREATE TABLE question
(
	id int PRIMARY KEY,
	anketa int REFERENCES anketa(id),
	qText text 	
);