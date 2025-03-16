SET IDENTITY_INSERT sensors ON; 
GO

INSERT INTO Sensors (SensorId, Name, AreaId) VALUES
(1, N'Cảm biến độ ẩm 1', 1),
(2, N'Cảm biến rung động 1', 1),
(3, N'Cảm biến mực nước 1', 2),
(4, N'Cảm biến độ ẩm 2', 3),
(5, N'Cảm biến rung động 2', 3),
(6, N'Cảm biến áp suất đất', 4),
(7, N'Cảm biến nghiêng', 5),
(8, N'Cảm biến địa chấn', 6),
(9, N'Cảm biến nhiệt độ', 7),
(10, N'Cảm biến gió', 8);
