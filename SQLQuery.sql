-- SELECT* FROM Teachers
-- SELECT* FROM Subjects
-- SELECT* FROM TimeTables
-- SELECT* FROM Schedules
-- SELECT* FROM Classes
-- SELECT* FROM AttendanceLogs

-- INSERT INTO Teachers (TeacherCode, TeacherName) VALUES 
-- ('011.034.00010', N'Nguyễn Thị Lương'),
-- ('011.034.00020', N'Phan Thị Thanh Nga'),
-- ('011.034.00027', N'Đoàn Minh Khuê'),
-- ('011.034.00028', N'Trần Thị Phương Linh'),
-- ('011.034.00018', N'Thái Duy Quý'),
-- ('011.034.00017', N'Tạ Hoàng Thắng'),
-- ('011.031.00125', N'La Quốc Thắng'), 
-- ('011.031.00140', N'Lê Thiên Anh');

-- DELETE FROM Teachers;
-- DBCC CHECKIDENT ('Teachers', RESEED, 0);

-- DELETE FROM Subjects;
-- DBCC CHECKIDENT ('Subjects', RESEED, 0);
-- DELETE FROM Classes;
-- DBCC CHECKIDENT ('Classes', RESEED, 0);
-- DELETE FROM Schedules;
-- DBCC CHECKIDENT ('Schedules', RESEED, 0);
-- DELETE FROM TimeTables;
-- DBCC CHECKIDENT ('TimeTables', RESEED, 0);

-- INSERT INTO AttendanceLogs (StudentCount, LogDate, LogTime, ImgPath, ScheduleId) VALUES
-- (20, '2025-01-05', '07:30:00', '/storage/logs/20250105_0730.jpg', 1),
-- (30, '2025-01-05', '08:00:00', '/storage/logs/20250105_0800.jpg', 1),
-- (44, '2025-01-05', '08:30:00', '/storage/logs/20250105_0830.jpg', 1),
-- (56, '2025-01-05', '09:00:00', '/storage/logs/20250105_0900.jpg', 1),
-- (72, '2025-01-05', '09:30:00', '/storage/logs/20250105_0930.jpg', 1),
-- (19, '2025-01-05', '10:00:00', '/storage/logs/20250105_1000.jpg', 1);

-- (10, '2025-01-02', '13:00:00', '/storage/logs/20250102_1300.jpg', 2),
-- (12, '2025-01-02', '13:30:00', '/storage/logs/20250102_1330.jpg', 2),
-- (14, '2025-01-02', '14:00:00', '/storage/logs/20250102_1400.jpg', 2),
-- (15, '2025-01-02', '14:30:00', '/storage/logs/20250102_1430.jpg', 2),
-- (17, '2025-01-02', '15:00:00', '/storage/logs/20250102_1500.jpg', 2);