use [M:\רבקה פוס\רבקה ותמר פרויקט סיום\FINALPROJECT\YEDIDIMDB.MDF]

CREATE FUNCTION TheHoursGiven(@ServiceID INT)
RETURNS BIT
AS BEGIN
DECLARE @TotalRequested INT = 0
DECLARE @TotalDonated INT = 0
DECLARE @MonthSpan INT = 0
DECLARE @StartDate DATE
DECLARE @EndDate DATE
DECLARE @ReturnValue BIT = 0
-- שליפת התאריכים הקיצוניים של בקשות השירות
SELECT @StartDate = MIN(RequestsDate), @EndDate = MAX(RequestsDate)
FROM Requests WHERE IdService = @ServiceID
-- בדיקת טווח תאריכים וחישוב מספר החודשים
SET @MonthSpan = DATEDIFF(MONTH, @StartDate, @EndDate) + 1
-- חישוב סך השעות שביקשו עבור השירות
SELECT @TotalRequested = SUM(NumberOfHours)
FROM Requests 
WHERE IdService = @ServiceID
-- חישוב סך שעות תרומות עבור השירות
SELECT @TotalDonated = SUM(VolunteerHoursInMonth)
FROM VolunteerService WHERE IdService = @ServiceID
-- השוואה: אם תרמו יותר מהממוצע החודשי של הבקשות
IF @MonthSpan > 0 AND (@TotalRequested / @MonthSpan) < @TotalDonated
SET @ReturnValue = 1
RETURN @ReturnValue
END
DECLARE @Result BIT
EXEC @Result = dbo.TheHoursGiven @ServiceID = 1
SELECT @Result AS HasEnoughDonatedHours