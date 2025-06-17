-- נכניס בקשה חדשה לשירות 1
INSERT INTO Requests VALUES 
(3, 1, 'Help with tire', 'approved', GETDATE(), 1, 4);
use [M:\רבקה פוס\רבקה ותמר פרויקט סיום\FINALPROJECT\YEDIDIMDB.MDF]
-- נשבץ את מתנדב 1 אליה
INSERT INTO AssignedRequests VALUES 
(2, 3, 1);
CREATE PROCEDURE GetAvailableVolunteersByService
   @ServiceID INT
AS BEGIN
SELECT TOP 1
 V.VolunteerID, V.Name,V.Phone
FROM Volunteers V
JOIN VolunteerServices VS ON V.VolunteerID = VS.VolunteerID
JOIN AssignedRequests AR ON V.VolunteerID = AR.VolunteerID
JOIN Requests R ON AR.RequestID = R.RequestID
WHERE VS.ServiceID = @ServiceID
 AND R.ServiceID = @ServiceID
      AND MONTH(R.Date) = MONTH(GETDATE())
      AND YEAR(R.Date) = YEAR(GETDATE())
GROUP BY V.VolunteerID, V.Name,v.Phone
HAVING SUM(VS.MonthlyHours) > SUM(R.Hours)
ORDER BY SUM(VS.MonthlyHours) - SUM(R.Hours) DESC
END
EXEC GetAvailableVolunteersByService @ServiceID = 1;
-- צרי פרוצדורה שתקבל קוד שירות ותחזיר כמה מתנדבים יש בשירת זה וכמה 
--בקשות אושרו בשירות זה השנה
--3

CREATE PROCEDURE GetVolunteerAndRequestStatsForService
    @ServiceID INT,@VolunteerCount INT OUTPUT, @ApprovedRequestCount INT OUTPUT
AS BEGIN
SELECT @VolunteerCount = COUNT(DISTINCT VolunteerID)
FROM VolunteerServices
WHERE ServiceID = @ServiceID
SELECT @ApprovedRequestCount = COUNT(*) FROM Requests
WHERE ServiceID = @ServiceID
AND Status = 'approved'
AND YEAR(Date) = YEAR(GETDATE())
END

DECLARE @Volunteers INT
DECLARE @Approved INT

EXEC GetVolunteerAndRequestStatsForService
    @ServiceID = 1,
    @VolunteerCount = @Volunteers OUTPUT,
    @ApprovedRequestCount = @Approved OUTPUT

SELECT @Volunteers AS VolunteerCount, @Approved AS ApprovedRequestCount
