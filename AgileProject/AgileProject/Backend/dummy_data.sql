INSERT INTO users (username, first_name, last_name, email, password)
VALUES ('bioiscool','Harper','Smith','BioTeacher@email.not','biology1');

INSERT INTO users (username, first_name, last_name, email, password)
VALUES ('randomUser','London','Bridge','fallingdown@fake.emails','randomPassword!');

INSERT INTO folders (creator,name,public)
VALUES (0,'BIO101',TRUE);

INSERT INTO folders (creator,name,public)
VALUES (0,'BIO102',TRUE);

INSERT INTO folders (creator,name,public)
VALUES (1,'Fall 2022',FALSE);

INSERT INTO folders (creator,name,public)
VALUES (1,'Fall 2023',FALSE);

INSERT INTO sets (creator,name,folder_id)
VALUES (0,'Exam 1 Review',0);

INSERT INTO sets (creator,name,folder_id)
VALUES (0,'Exam 1 Review',1);

INSERT INTO sets (creator,name,folder_id)
VALUES (0,'Chapter 4 Vocabulary',1);

INSERT INTO sets (creator,name,folder_id)
VALUES (1,'Art Terms',2);

INSERT INTO sets (creator,name)
VALUES (1,'Shakespeare');

INSERT INTO flashcards (set_id,question,aswer)
VALUES (1,'__________ is the powerhouse of the cell.','The Miochondria');

INSERT INTO flashcards (set_id,question,aswer)
VALUES (0,'What color is chloroplast?','green');

INSERT INTO flashcards (set_id,question,aswer)
VALUES (1,'Which type of cell has a cell wall?','Plant Cell');

INSERT INTO flashcards (set_id,question,aswer)
VALUES (3,'What is the art technique that shows depth?','Perspective');

INSERT INTO flashcards (set_id,question,aswer)
VALUES (3,'Who painted the Mona Lisa?','Leonardo de Vinci');

INSERT INTO flashcards (set_id,question,aswer)
VALUES (0,'What is it called when a cell has shrunk?','Plasmolyse');

INSERT INTO flashcards (set_id,question,aswer)
VALUES (1,'What is the name of the vesicle that contains digestive chemicals?','Lysosome');

INSERT INTO flashcards (set_id,question,aswer)
VALUES (4,'Which play is this quote from: Fair is foul, and foul is fair.','Macbeth');

INSERT INTO flashcards (set_id,question,aswer)
VALUES (4,'Which play is this quote from: Good night, good night! Parting is such sweet sorrow, that I shall say good night till it be morrow.','Romeo and Juliet');

INSERT INTO flashcards (set_id,question,aswer)
VALUES (0,'What is Biology?','The Study of Living Organisms and How the Function.');

INSERT INTO flashcards (set_id,question,aswer)
VALUES (1,'_________ is the genetic transmission of physical traits and characteristics from a parent to their offspring.','Heredity');

INSERT INTO flashcards (set_id,question,aswer)
VALUES (4,'Which play is this quote from: To be, or not to be, that is the question.','Hamlet');


INSERT INTO flashcards (set_id,question,aswer)
VALUES (4,'Which play is this quote from: Love looks not with the eyes, but with the mind, And therefore is winged Cupid painted blind.','A Midsummer Night's Dream');

INSERT INTO flashcards (set_id,question,aswer)
VALUES (3,'Who painted the ceiling of the Sistine Chapel?','Michelangelo');

INSERT INTO flashcards (set_id,question,aswer)
VALUES (1,'What is the control center of a cell?','Nucleus');

INSERT INTO flashcards (set_id,question,aswer)
VALUES (3,'___________ is the illusion of weight/density.','Mass');

INSERT INTO flashcards (set_id,question,aswer)
VALUES (4,'Which play is this quote from: If love be blind, it best agrees with night.','Romeo and Juliet');

INSERT INTO flashcards (set_id,question,aswer)
VALUES (4,'Which play is this quote from: This above all: to thine own self be true.','Hamlet');






