CREATE TABLE answers
(
	question int REFERENCES question(id),
	answer text
);