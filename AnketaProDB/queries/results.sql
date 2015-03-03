CREATE TABLE results
(
	anketa int REFERENCES anketa(id),
	solver int REFERENCES user(id),
);