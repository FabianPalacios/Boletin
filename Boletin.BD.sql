Create table tb_student(
	id int identity not null primary key,
	firstName nvarchar(100)  not null,
	secondName nvarchar(100)  not null,
	firstSurName nvarchar(100)  not null,
	secondSurName nvarchar(100)  not null,
	documento nvarchar(100) not null
)


Create table tb_grade(
	id int identity not null primary key,
	degree nvarchar(100)  not null
)

Create table tb_period(
	id int identity not null primary key,
	numPeriod nvarchar(100) not null
)

Create table tb_bulletin(
	id int identity not null primary key,
	id_student int not null,
	id_grade int not null,
	id_period int not null,
	foreign key (id_student) references tb_student,
	foreign key (id_grade) references tb_grade,
	foreign key (id_period) references tb_period,
)

Create table tb_matter(
	id int identity not null primary key,
	id_bulletin int not null,
	name nvarchar(100) not null,
	description nvarchar(500)  not null,
	foreign key (id_bulletin) references tb_bulletin
)

Create table tb_result(
	id int identity not null primary key,
	id_matter int not null,
	nota nvarchar(4) not null,
	foreign key (id_matter) references tb_matter
)
