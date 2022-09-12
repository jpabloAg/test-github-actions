CREATE TABLE accounts (
	user_id VARCHAR ( 50 ) PRIMARY KEY,
	username VARCHAR ( 50 ) UNIQUE NOT NULL,
	password VARCHAR ( 50 ) NOT NULL,
	email VARCHAR ( 255 ) UNIQUE NOT NULL
);

INSERT INTO accounts (user_id, username, password, email) VALUES('1','test1','aww','test1@gmail.com');
INSERT INTO accounts (user_id, username, password, email) VALUES('2','test2','x9p','test2@gmail.com');

SELECT	* FROM accounts;
