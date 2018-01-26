create table Visits
(
	TotalPounds int,
	DateOfVisit datetime,
	PatronID int,
	Thanksgiving bit default 0 not null,
	Christmas bit default 0 not null,
	Winter bit default 0 not null,
	Halloween bit default 0 not null,
	School bit default 0 not null,
	Easter bit default 0 not null,
	VisitID int not null
		constraint PK_Visits
			primary key
)
go