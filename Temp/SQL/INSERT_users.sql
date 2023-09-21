INSERT INTO users (Id, Name, LastName, Email, Password, YearsOld) VALUES
('e740345a-3b11-44ec-a97d-8b9f932570a9','Matheus Roque','Petrachin','mpetrachin@gmail.com','123456','24'),
('13f3eae3-e949-4f1f-9cb5-addb0fddb4f2','Juliana Roque','Petrachin','jpetrachin@gmail.com','123457','26');
ON CONFLICT DO NOTHING;
