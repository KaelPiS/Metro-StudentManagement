alter proc GetDateRegisterUnit
as
begin
declare @DateRegisterUnit Smalldatetime, @Nowday smalldatetime
set @Nowday=GETDATE()
select @DateRegisterUnit =Semester.DateRegister from Semester  where Semester.IsDateRegister='1'
select CONVERT(time, @Nowday)

end