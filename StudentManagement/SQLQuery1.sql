alter proc GetAcademicByID
@StudentID nvarchar(30),
@Module nvarchar(30),
@Year nvarchar(10)

as
begin
select Discipline.DisciplineID, ProcessMark, MidtermMark, FinaltermMark, AvarageMark, DisciplineStatus  
from AcademicMark join Discipline on AcademicMark.DisciplineID=Discipline.DisciplineID join RegisterStudyUnit on RegisterStudyUnit.DisciplineID=Discipline.DisciplineID join Semester on Semester.SemesterID=RegisterStudyUnit.SemesterID
where @StudentID=AcademicMark.StudentID and  SemesterName=@Module and  YearSemester=@Year

end


exec GetAcademicByID '74550','Module 1','Year 1'


select * from Semester