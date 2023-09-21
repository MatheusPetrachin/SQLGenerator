INSERT INTO users (Id, Name, LastName, Email, Password, YearsOld) VALUES
('7f3564bf-73c1-4937-affe-5cf10bad0f99','Matheus Roque','Petrachin','mpetrachin@gmail.com','123456','24'),
('073c9083-9086-4a3a-a1a4-1fb79d0b8502','Juliana Roque','Petrachin','jpetrachin@gmail.com','123457','26');
ON CONFLICT DO NOTHING;
