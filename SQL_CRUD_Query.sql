create database db_Student;

use[db_Student]

create table StudentInformation(
StuId int identity(1,1) primary key,
FirstName nvarchar(50),
EmailAddress nvarchar(50)

)

Select * from StudentInformation



create proc SP_SaveStudent  'Siraj' , 'siraj@gmail.com'
@FirstName nvarchar(50),
@EmailAddress nvarchar(50)
as 
begin
insert into StudentInformation(FirstName, EmailAddress) values (@FirstName , @EmailAddress)
end


Select * from StudentInformation

create proc SP_GetStudents
as
begin
select * from StudentInformation
end

create proc SP_DeleteStudents 3
@StuId int 
as
begin
delete from  StudentInformation where  StuId=@StuId
end


create proc  SP_UpdateStudents
@StuId int, 
@FirstName nvarchar(50),
@EmailAddress nvarchar(50)

as
begin
Update StudentInformation
set FirstName=@FirstName,
EmailAddress=@EmailAddress

where StuId=@StuId
end












