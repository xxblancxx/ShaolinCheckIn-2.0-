-- Create View from joining Student and Registration on student Id.
CREATE VIEW StudentRegistration 
AS SELECT s.Id, s.Name, s.Team, r.TimeStamp  
FROM   Student s, Registration r
WHERE s.Id = r.Student
