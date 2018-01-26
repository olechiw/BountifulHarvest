create table Patrons
(
	FirstName nvarchar(max),
	MiddleInitial nvarchar(max),
	LastName nvarchar(max),
	Gender nvarchar(max),
	DateOfLastVisit datetime default '1900-01-01 00:00:00.000' not null,
	DateOfBirth nvarchar(max) default (1-12)-1900,
	Family nvarchar(max),
	FamilyGenders nvarchar(max),
	FamilyDateOfBirths nvarchar(max),
	PhoneNumber nvarchar(max),
	Address nvarchar(max),
	Comments nvarchar(max),
	DateOfInitialVisit datetime default '1900-01-01 00:00:00.000' not null,
	VisitsEveryWeek bit default 0 not null,
	Veteran bit default 0 not null,
	Senior bit default 0 not null,
	PatronID int not null
		constraint PK_Patrons
			primary key,
	Males int default 0 not null,
	Females int default 0 not null,
	Toddler int default 0,
	Young int default 0 not null,
	Medium int default 0 not null,
	Old int default 0 not null
)
go

declare @sn nvarchar(30)
set @sn = schema_name()
execute sp_addextendedproperty N'MS_Description', N'data for each patron', N'SCHEMA', @sn, N'TABLE', N'Patrons'
go

