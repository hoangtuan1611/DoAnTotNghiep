select* from Lecturer
select* from Course

insert into Lecturer (Username, Password, AccountName) values ('abc', '123', 'Nguễn Thị Lương'), ('def', '456', 'Phan Thị Thanh Nga');

insert into Course(CourseId, CourseName, LecturerId) values ('20CT1202', 'Lập trình hướng đối tượng', 1), 
('20CT3132D', 'Ứng dụng di động', 1), ('20CT3106D', 'Lập trình Python', 2), ('20CT2202', 'Ứng dụng desktop', 2);

-- Table Lecturer {
--   Id integer [primary key]
--   userName varchar(50)
--   password varchar(50)
--   accountName nvarchar(100)
--   email varchar(100)
-- }

-- Table Course {
--   Id integer [primary key]
--   courseId varchar(10)
--   courseName varchar(10)
--   lecturerId int
-- }

-- Ref: Course.lecturerId > Lecturer.Id