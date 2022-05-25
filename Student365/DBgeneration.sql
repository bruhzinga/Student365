use Student365
go

create table Subjects
(
    Name       nvarchar(50)                                 not null
        constraint PK__Subjects__737584F7CC6E23D3
            primary key,
    IsSelected bit
        constraint DF__Subjects__IsSele__2A164134 default 0 not null
)
go

create table GroupSubjects
(
    Id       int identity
        constraint GroupSuvjects_pk
            primary key,
    [Group]  smallint,
    Subject  nvarchar(50)
        constraint FK__GroupSubj__Subje__0C85DE4D
            references Subjects
            on update cascade on delete cascade,
    Max_Labs int,
    Kurs     tinyint
)
go

create table Schedule
(
    [Group]        smallint not null,
    SubGroup       smallint not null,
    [Week Num]     tinyint  not null
        constraint [CK__Schedule__Week N__160F4887]
            check ([Week Num] = 2 OR [Week Num] = 1),
    Subject        nvarchar(50)
        constraint FK__Schedule__Subjec__17036CC0
            references Subjects,
    [Subject Num]  tinyint  not null
        constraint CK__Schedule__Subjec__17F790F9
            check ([Subject Num] = 4 OR [Subject Num] = 3 OR [Subject Num] = 2 OR [Subject Num] = 1),
    [Subject Type] nvarchar(50)
        constraint CK__Schedule__Subjec__18EBB532
            check ([Subject Type] = 'ЛР' OR [Subject Type] = 'ПЗ' OR [Subject Type] = 'ЛК'),
    Auditorium     nvarchar(50),
    Day            tinyint  not null
        constraint CK__Schedule__Day__19DFD96B
            check ([day] = 6 OR [day] = 5 OR [day] = 4 OR [day] = 3 OR [day] = 2 OR [day] = 1),
    Id             int identity
        constraint PK__Schedule__3214EC078B2505A5
            primary key,
    Kurs           tinyint
)
go

create table Users
(
    UserName nvarchar(50)                not null
        constraint Users_pk
            primary key,
    Role     nvarchar(10) default 'User' not null
        check ([Role] = 'Teacher' OR [Role] = 'Admin' OR [Role] = 'User'),
    Password nvarchar(32)                not null
)
go

create table Absence
(
    Id       int identity
        primary key,
    Username nvarchar(50)
        constraint FK__Absence__Usernam__236943A5
            references Users
            on delete cascade,
    Date     date         not null,
    Reason   varchar(255),
    Subject  nvarchar(50) not null
        constraint FK__Absence__Subject__245D67DE
            references Subjects
)
go

create table Grade
(
    subject  nvarchar(50)
        references Subjects,
    grade    smallint     not null
        check ([grade] >= 0 AND [grade] <= 10),
    username nvarchar(50) not null
        references Users,
    id       int identity
        primary key
)
go

create table LabWorks
(
    Id                       int identity
        primary key,
    Subject                  nvarchar(50)
        constraint FK__LabWorks__Subjec__02084FDA
            references Subjects,
    Username                 nvarchar(50)
        constraint FK__LabWorks__Userna__02FC7413
            references Users
            on update cascade on delete cascade,
    [Max amount of Labs]     int,
    [Current amount of Labs] int,
    Completion               as CONVERT([int],
                (CONVERT([decimal], [Current amount of Labs]) / CONVERT([decimal], [Max amount of Labs])) * 100)
)
go

create table Notes
(
    Username nvarchar(50)  not null
        constraint FK__Notes__Username__4CA06362
            references Users
            on update cascade on delete cascade,
    Text     nvarchar(max) not null,
    Header   nvarchar(50)  not null,
    Id       smallint identity
        constraint Notes_pk
            primary key
)
go

create table Students
(
    Name     nvarchar(50)       not null,
    Id       int identity
        primary key,
    [Group]  smallint           not null,
    Kurs     int                not null,
    SubGroup smallint default 1 not null
        check ([SubGroup] = 2 OR [SubGroup] = 1),
    UserName nvarchar(50)
        constraint FK__Students__UserNa__59FA5E80
            references Users
            on update cascade on delete cascade,
    Phone    nvarchar(15)
)
go

create table Teachers
(
    Name     nvarchar(50),
    Id       int identity
        constraint Teachers_pk
            primary key,
    Username nvarchar(50)
        constraint Teachers_username
            references Users
)
go

