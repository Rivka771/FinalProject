use [M:\רבקה פוס\רבקה ותמר פרויקט סיום\FINALPROJECT\YEDIDIMDB.MDF]

--ex1
--צרי פונקצייה שתקבל קוד מתנדב ותחזיר כמה שעות חודשיות נותרו לו 
--החודש.
create function GetAllHoursHasLeft(@idV int)
returns int
as begin
declare  @monthlyHours int
declare @useHours int
select @monthlyHours= sum (MonthlyHours) from  VolunteerServices
where VolunteerID=@idV 
select @useHours= sum(r.Hours)from Requests r
join AssignedRequests a 
on a.RequestID = r.RequestID
where a.VolunteerID = @idV
AND MONTH(R.Date) = MONTH(GETDATE())
AND YEAR(R.Date) = YEAR(GETDATE())
return @monthlyHours-@useHours
end
DROP function GetAllHoursHasLeft
SELECT dbo.GetAllHoursHasLeft(1) AS RemainingHours;


select *from VolunteerServices
select * from Requests
--צרי פרוצדורה שתקבל קוד שירות ותשלוף את המתנדבים שנותרו לו הכי 
--הרבה שעות לתרום החודש בשירות זה.
--ex2
CREATE PROCEDURE GetAvailableVolunteersByService
   @ServiceID INT
AS BEGIN
SELECT V.VolunteerID, V.Name,V.Phone
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
drop  PROCEDURE GetAvailableVolunteersByService
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
--ex4
--צרי פונקצייה שתקבל קוד שירות ותחזיר האם יש מספיק שעות שנתרמו-
-- האם מספר השעות שנתרמו בחודש גדול מהממוצע שעות שמבקשים 
--בחודש.
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
SELECT @StartDate = MIN(Date), @EndDate = MAX(Date)
FROM Requests WHERE ServiceID = @ServiceID
-- בדיקת טווח תאריכים וחישוב מספר החודשים
SET @MonthSpan = DATEDIFF(MONTH, @StartDate, @EndDate) + 1
-- חישוב סך השעות שביקשו עבור השירות
SELECT @TotalRequested = SUM(Hours)
FROM Requests 
WHERE SeekerID = @ServiceID
-- חישוב סך שעות תרומות עבור השירות
SELECT @TotalDonated = SUM(MonthlyHours)
FROM VolunteerServices WHERE ServiceID = @ServiceID
-- השוואה: אם תרמו יותר מהממוצע החודשי של הבקשות
IF @MonthSpan > 0 AND (@TotalRequested / @MonthSpan) < @TotalDonated
SET @ReturnValue = 1
RETURN @ReturnValue
END

SELECT dbo.TheHoursGiven (5)

--ex5
create function CountExclusiveServices(@idV int)
returns int
as begin
declare @cnt int;
select @cnt = count(*)
from VolunteerServices v
where v.VolunteerID = @idV
and not exists (select 1 from VolunteerServices v1
where v1.ServiceID = v.ServiceID
and v1.VolunteerID <> @idV);
return @cnt;
end;

SELECT dbo.CountExclusiveServices(1)

--ex6
create procedure GetAllDetails(@idV int)
as begin
select h.Name,h.Phone,h.Address,
r.RequestContent,r.Date,s.ServiceName from Services s join Requests r
on s.ServiceID=r.ServiceID
join HelpSeekers h on r.SeekerID=h.SeekerID
join VolunteerServices v
on v.ServiceID= s.ServiceID
where @idV=v.VolunteerID
and r.Date>= GETDATE()
order by r.Date
end

DROP PROCEDURE GetAllDetails;

DECLARE @idV INT;

EXEC GetAllDetails
    @idV = 1
SELECT 
    @idV
 
--ex7
create procedure GetVolunteerHours(@idV int,@TotalHoursThisMonth int output,@AvgHoursLastMonth float output)
as begin
--declare @TotalHoursThisMonth int
--declare @AvgHoursLastMonth float

select @TotalHoursThisMonth = SUM(Hours) from Requests r
    join AssignedRequests a  on r.RequestID=a.RequestID
   where a.VolunteerID = @idV
      AND r.Status = 'approved'
      AND MONTH(r.Date) = MONTH(GETDATE())
      AND YEAR(r.Date) = YEAR(GETDATE());

select @AvgHoursLastMonth =AVG(r.Hours)
from Requests r
join AssignedRequests a on r.RequestID = a.RequestID
where a.VolunteerID = @idV
and r.Status = 'approved'
and MONTH(r.Date) = MONTH(DATEADD(MONTH, -1, GETDATE()))
and YEAR(r.Date) = YEAR(DATEADD(MONTH, -1, GETDATE()))

end

DECLARE @TotalHours INT
DECLARE @AvgHours FLOAT

EXEC GetVolunteerHours
    @idV = 1,
    @TotalHoursThisMonth = @TotalHours OUTPUT,
    @AvgHoursLastMonth = @AvgHours OUTPUT

SELECT 
    @TotalHours AS TotalHoursThisMonth,
    @AvgHours AS AvgHoursLastMonth



