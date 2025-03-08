-- SELECT* FROM Lecturer
-- SELECT* FROM Course
-- SELECT* FROM Class
-- SELECT* FROM AttendanceLog
-- SELECT* FROM ClassCourse

-- DELETE FROM Lecturer;
-- DBCC CHECKIDENT ('Lecturer', RESEED, 0);
-- DELETE FROM Course;
-- DBCC CHECKIDENT ('Course', RESEED, 0);
-- DELETE FROM Class;
-- DBCC CHECKIDENT ('Class', RESEED, 0);
-- DELETE FROM AttendanceLog;
-- DBCC CHECKIDENT ('AttendanceLog', RESEED, 0);


-- INSERT INTO Lecturer (Username, Password, AccountName, Email) VALUES ('abc', '123', N'Phan Thị Thanh Nga', 'ngaptt@gmail.com')
-- INSERT INTO Course(CourseId, CourseName, LecturerId) VALUES 
-- ('20CT1202', N'Lập trình hướng đối tượng', 1),
-- ('20CT3132D', N'Ứng dụng di động', 1),
-- ('20CT3106D', N'Lập trình Python', 1),
-- ('20CT2202', N'Ứng dụng desktop', 1);
-- INSERT INTO Class(ClassId, MaxStudents) VALUES
-- ('CTK45A', 80), ('CTK45B', 70);
-- INSERT INTO ClassCourse (ClassId, CourseId) VALUES 
-- (1, 1), (1, 2), (1, 3), (1, 4), 
-- (2, 1), (2, 2), (2, 3), (2, 4);

-- INSERT INTO Lecturer (Username, Password, AccountName, Email) VALUES ('def', '123', N'Nguyễn Thị Lương', 'luongnt@gmail.com')
-- INSERT INTO Course(CourseId, CourseName, LecturerId) VALUES 
-- ('20CT4103D', N'Ứng dụng game nâng cao', 2),
-- ('20CT4102D', N'Ứng dụng mã nguồn mở', 2),
-- ('20CT4107D', N'Thương mại điện tử', 2),
-- ('20CT3113D', N'Các phương pháp học máy', 2);
-- INSERT INTO Class(ClassId, MaxStudents) VALUES
-- ('CTK47B', 50), ('CTK46A', 80);
-- INSERT INTO ClassCourse (ClassId, CourseId) VALUES 
-- (3, 5), (3, 6), (3, 7), (3, 8), 
-- (4, 5), (4, 6), (4, 7), (4, 8);

-- DECLARE @CourseId INT = 1;
-- SELECT c.Id AS CourseId, c.courseId, c.courseName, 
--        cl.Id AS ClassId, cl.classId, cl.maxStudents
-- FROM ClassCourse cc
-- JOIN Course c ON cc.CourseId = c.Id
-- JOIN Class cl ON cc.ClassId = cl.Id
-- WHERE c.Id = @CourseId;

