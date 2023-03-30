INSERT INTO users (user_id, username, first_name, last_name, email, password)
VALUES 
(
    '2d7149a6-cf08-11ed-afa1-0242ac120002',
    'bioiscool',
    'Harper',
    'Smith',
    'BioTeacher@email.not',
    crypt('bioloGy1', gen_salt('bf'))
),
(
    '2d714d66-cf08-11ed-afa1-0242ac120002',
    'randomUser',
    'London',
    'Bridge',
    'fallingdown@fake.emails',
    crypt('randomPassword!', gen_salt('bf'))
);

INSERT INTO folders (creator,folder_id,name,public)
VALUES 
(
    '2d7149a6-cf08-11ed-afa1-0242ac120002',
    '2d715428-cf08-11ed-afa1-0242ac120002',
    'BIO101',
    TRUE
),
(
    '2d7149a6-cf08-11ed-afa1-0242ac120002',
    '2d715644-cf08-11ed-afa1-0242ac120002',
    'BIO102',
    TRUE
),
(
    '2d714d66-cf08-11ed-afa1-0242ac120002',
    '2d715a04-cf08-11ed-afa1-0242ac120002',
    'Fall 2022',
    FALSE
),
(
    '2d714d66-cf08-11ed-afa1-0242ac120002',
    '2d715c2a-cf08-11ed-afa1-0242ac120002',
    'Fall 2023',
    FALSE
);

INSERT INTO sets (creator,set_id,name,folder_id)
VALUES 
(
    '2d7149a6-cf08-11ed-afa1-0242ac120002',
    '2d715e14-cf08-11ed-afa1-0242ac120002',
    'Exam 1 Review',
    '2d715428-cf08-11ed-afa1-0242ac120002'
),
(
    '2d7149a6-cf08-11ed-afa1-0242ac120002',
    '2d715fea-cf08-11ed-afa1-0242ac120002',
    'Exam 1 Review',
    '2d715644-cf08-11ed-afa1-0242ac120002'
 ),
(
    '2d7149a6-cf08-11ed-afa1-0242ac120002',
    '2d7161fc-cf08-11ed-afa1-0242ac120002',
    'Chapter 4 Vocabulary',
    '2d715644-cf08-11ed-afa1-0242ac120002'
),
(
    '2d714d66-cf08-11ed-afa1-0242ac120002',
    '2d71697c-cf08-11ed-afa1-0242ac120002',
    'Art Terms',
    '2d715a04-cf08-11ed-afa1-0242ac120002'
);

INSERT INTO sets (creator,set_id,name)
VALUES 
(
    '2d714d66-cf08-11ed-afa1-0242ac120002',
    '2d716b52-cf08-11ed-afa1-0242ac120002',
    'Shakespeare'
);

INSERT INTO flashcards (set_id,card_id, question,answer)
VALUES 
(
    '2d715fea-cf08-11ed-afa1-0242ac120002',
    '2d716d0a-cf08-11ed-afa1-0242ac120002',
    '__________ is the powerhouse of the cell.',
    'The Miochondria'
),
(
    '2d715e14-cf08-11ed-afa1-0242ac120002',
    '2d716ec2-cf08-11ed-afa1-0242ac120002',
    'What color is chloroplast?',
    'green'
),
(
    '2d715fea-cf08-11ed-afa1-0242ac120002',
    '2d717070-cf08-11ed-afa1-0242ac120002',
    'Which type of cell has a cell wall?',
    'Plant Cell'
),
(
    '2d71697c-cf08-11ed-afa1-0242ac120002',
    '2d71725a-cf08-11ed-afa1-0242ac120002',   
    'What is the art technique that shows depth?',
    'Perspective'
),
(
    '2d71697c-cf08-11ed-afa1-0242ac120002',
    '2d717408-cf08-11ed-afa1-0242ac120002',
    'Who painted the Mona Lisa?',
    'Leonardo de Vinci'
),
(
    '2d715e14-cf08-11ed-afa1-0242ac120002',
    '2d717584-cf08-11ed-afa1-0242ac120002',
    'What is it called when a cell has shrunk?',
    'Plasmolyse'
),
(
    '2d715fea-cf08-11ed-afa1-0242ac120002',
    '2d717bf6-cf08-11ed-afa1-0242ac120002',
    'What is the name of the vesicle that contains digestive chemicals?',
    'Lysosome'
),
(
    '2d716b52-cf08-11ed-afa1-0242ac120002',
    '2d717d7c-cf08-11ed-afa1-0242ac120002',
    'Which play is this quote from: Fair is foul, and foul is fair.',
    'Macbeth'
),
(
    '2d716b52-cf08-11ed-afa1-0242ac120002',
    '2d717ef8-cf08-11ed-afa1-0242ac120002',
    'Which play is this quote from: Good night, good night! Parting is such sweet sorrow, that I shall say good night till it be morrow.',
    'Romeo and Juliet'
),
(
   '2d715e14-cf08-11ed-afa1-0242ac120002',
    '2d71809c-cf08-11ed-afa1-0242ac120002',
    'What is Biology?',
    'The Study of Living Organisms and How the Function.'
),
(
    '2d715fea-cf08-11ed-afa1-0242ac120002',
    '2d718272-cf08-11ed-afa1-0242ac120002',
    '_________ is the genetic transmission of physical traits and characteristics from a parent to their offspring.',
    'Heredity'
),
(
    '2d716b52-cf08-11ed-afa1-0242ac120002',
    '2d718420-cf08-11ed-afa1-0242ac120002',
    'Which play is this quote from: To be, or not to be, that is the question.',
    'Hamlet'
),
(
    '2d716b52-cf08-11ed-afa1-0242ac120002',
    '2d7185ba-cf08-11ed-afa1-0242ac120002',
    'Which play is this quote from: Love looks not with the eyes, but with the mind, And therefore is winged Cupid painted blind.',
    'A Midsummer Nights Dream'
),
(
    '2d71697c-cf08-11ed-afa1-0242ac120002',
    '2d718790-cf08-11ed-afa1-0242ac120002',
    'Who painted the ceiling of the Sistine Chapel?',
    'Michelangelo'
),
(
    '2d715fea-cf08-11ed-afa1-0242ac120002',
    '2d718bfa-cf08-11ed-afa1-0242ac120002',
    'What is the control center of a cell?',
    'Nucleus'
),
(
    '2d71697c-cf08-11ed-afa1-0242ac120002',
    '2d718dee-cf08-11ed-afa1-0242ac120002',
    '___________ is the illusion of weight/density.',
    'Mass'
),
(
    '2d716b52-cf08-11ed-afa1-0242ac120002',
    '2d71914a-cf08-11ed-afa1-0242ac120002',
    'Which play is this quote from: If love be blind, it best agrees with night.',
    'Romeo and Juliet'
),
(
    '2d716b52-cf08-11ed-afa1-0242ac120002',
    'b04e7cea-cf0d-11ed-afa1-0242ac120002',
    'Which play is this quote from: This above all: to thine own self be true.',
    'Hamlet'
);