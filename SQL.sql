CREATE table dbo.Employee(
	UserId int identity(1,1),
	EmployeeName varchar(500),
	EmployeeRole varchar(500),
	Motto varchar(500),
	Hobbies varchar(500),
	Hometown varchar(500),
	PersonalBlog varchar(500),
	PhotoFileName varchar(500)
)

insert into dbo.Employee(EmployeeName, EmployeeRole, Motto, Hobbies, Hometown, PersonalBlog, PhotoFileName)
VALUES ('John Doe','Tech Lead at ABC Software','Have fun','Football & Technology', 'Victoria, Gozo', 'www.johndoe.com', 'pictureone.jpg'),
	   ('Sam Green','Software Engineer at ABC Software','Code all day','Gaming','Xewkija, Gozo',null,'picturetwo.jpg'),
	   ('Richard White','UI Designer at ABC Software','Design is art','Reading','Victoria, Gozo','www.richardwhite.com','picturethree.png');