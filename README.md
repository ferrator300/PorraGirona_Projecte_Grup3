# PorraGirona_Projecte_Grup3
## Requisits
Per poder utilitzar aquesta aplicació es requereix de una ***base de dades en execució***.
Concretament s'ha d'utilitzar una base de dades en concret que podeu obtenir mitjançant el següent ***script SQL***,
que podreu executar en programes com DBeaver, phpMyAdmin o qualsevol altre que treballi amb ***MariaDB***.
> Nota: el script ja esta disenyat per esborrar la anterior base de dades i crearla de nou en cas de ja tenirla.

> IMPORTANT: Si executeu l'script per segon cop sobre la mateixa base de dades ***ELIMINARA*** totes les dades que hi tinguem guardades.

SCRIPT
```
drop database if exists FootballPoll;
create database FootballPoll;
use FootballPoll;
-- SELECT * FROM information_schema.columns WHERE table_schema = 'FootballPoll';

/*
select user();
select * from mysql.user;
select * from PollMember;

insert into PollMember(PollMember_ID, name)
	values(123, 'Hola');
*/
/*
start transaction;
delete from PollMember where User_ID = 15;
rollback; 
*/

drop table if exists Password;
drop table if exists Bet;
drop table if exists ScoreHistory;
drop table if exists MatchResult;
drop table if exists PollMember;
drop table if exists ShownMatch;
drop table if exists Club;
drop table if exists Championship;

create or replace table PollMember (
	PollMember_ID INT(5),
	Name varchar(50),
	Surname varchar(50),
	Address varchar(100),
	Nif varchar(9),
	Email varchar(150),
	GlobalScore int(4) default 0,
	constraint pk_PollMember 
		primary key (PollMember_ID)
);

/*
select * from pollmember p ;
UPDATE PollMember
	SET GlobalScore = ifnull(GlobalScore + 5, 5)
	WHERE PollMember_ID = 3;
start transaction;
insert into pollmember 
	values(1, 'Hola', 'Ho', 'ADSF', 'ADFHLÑ', 'eklf@', 4);
commit;
rollback;
SELECT * FROM PollMember WHERE PollMember_ID = 1;
*/
create or replace table Championship (
	Name varchar(50),
	Championship_ID int(5),
	Division int(2),
	Club_Slots int(2),
	constraint pk_Championship 
		primary key (Championship_ID) 
);

create or replace table Club (
	Name varchar(50),
	Short_name varchar(15),
	Club_ID int(5),
	Championship_ID int(5),
	Stadium varchar(50),
	Locality varchar(50),
	-- Image mediumblob,
	constraint pk_Club 
		primary key (Club_ID),
	constraint fk_Club_Championship_ID 
		foreign key (Championship_ID) 
		references Championship(Championship_ID)
		on delete cascade
);

create or replace table ShownMatch (
	ShownMatch_ID int(5),
	Match_dateTime Datetime default adddate(current_date, interval 1 day),
	LocalClub_ID int(5),
	AwayClub_ID int(5),
	constraint pk_ShownMatch 
		primary key (ShownMatch_ID),
	constraint fk_ShownMatch_LocalClub_ID
		foreign key (LocalClub_ID)
		references Club(Club_ID)
		on delete cascade,
	constraint fk_ShownMatch_AwayClub_ID
		foreign key (AwayClub_ID)
		references Club(Club_ID)
		on delete cascade
);
/*
INSERT INTO ShownMatch
	values(null, '2020-01-01', 1, 2);
select * from shownmatch;
select * from matchresult;
insert into matchresult 
	values(2, 2, 3);
*/
create or replace table Bet (
	PollMember_ID int(5),
	ShownMatch_ID int(5),
	Submission_time Datetime default current_timestamp,
	Local_goals int(2),
	Away_goals int(2),
	constraint pk_Bet 
		primary key (ShownMatch_ID, PollMember_ID),
	constraint fk_Bet_ShownMatch_ID
		foreign key (ShownMatch_ID) 
		references ShownMatch(ShownMatch_ID)
		on delete cascade,
	constraint fk_Bet_PollMember_ID
		foreign key (PollMember_ID)
		references PollMember(PollMember_ID)
		on delete cascade
);

create or replace table ScoreHistory (
	PollMember_ID int(5),
	ShownMatch_ID int(5),
	Score int(4),
	constraint pk_ScoreHistory
		primary key (PollMember_ID, ShownMatch_ID),
	constraint fk_Scores_PollMember_ID
		foreign key (PollMember_ID)
		references PollMember(PollMember_ID),
	constraint fk_Scores_ShownMatch_ID
		foreign key (ShownMatch_ID)
		references ShownMatch(ShownMatch_ID)
);

create or replace table MatchResult (
	ShownMatch_ID int(5),
	Local_goals int(2),
	Away_goals int(2),
	constraint pk_MatchResult
		primary key (ShownMatch_ID),
	constraint fk_MatchResult_ShownMatch_ID
		foreign key (ShownMatch_ID)
		references ShownMatch(ShownMatch_ID)
		on delete cascade
);

create or replace table Password (
	PollMember_ID int(5),
	Password varchar(30),
	constraint pk_Password
		primary key (PollMember_ID),
	constraint fk_Password_PollMember_ID
		foreign key (PollMember_ID)
		references PollMember(PollMember_ID)
		on delete cascade
);

#############################################################################
-- TRIGGERS

delimiter //
create or replace trigger bi_PollMember 
	before insert on PollMember
	for each row 
begin 
	declare vLastPollMember_ID type of PollMember.PollMember_ID;

	select max(PollMember_ID) into vLastPollMember_ID 
		from PollMember;
	
	if vLastPollMember_ID is not null then
		set new.PollMember_ID := vLastPollMember_ID + 1;
	else
		set new.PollMember_ID := 1;
	end if;
end
//
delimiter ;

/*start transaction;
insert into pollmember
	values(5, 'Joanica', 'Peralt', 'Sant Joan torta', '12345678B', 'Joanica.Peralt@gmail.com');
select * from PollMember;
rollback;
*/

delimiter //
create or replace trigger bi_Championship 
	before insert on Championship
	for each row 
begin 
	declare vLastChampionship_ID type of Championship.Championship_ID;

	select max(Championship_ID) into vLastChampionship_ID
		from championship;
	
	if vLastChampionship_ID is not null then
		set new.Championship_ID := vLastChampionship_ID + 1;
	else
		set new.Championship_ID := 1;
	end if;
end
//
delimiter ;

delimiter //
create or replace trigger bi_Club
	before insert on Club
	for each row 
begin 
	declare vLastClub_ID type of Club.Club_ID;

	select max(Club_ID) into vLastClub_ID
		from Club;
	
	if vLastClub_ID is not null then
		set new.Club_ID := vLastClub_ID + 1;
	else
		set new.Club_ID := 1;
	end if;
end
//
delimiter ;

delimiter //
create or replace trigger bi_ShownMatch
	before insert on ShownMatch
	for each row 
begin 
	declare vLastShownMatch_ID type of ShownMatch.ShownMatch_ID;

	select max(ShownMatch_ID) into vLastShownMatch_ID
		from ShownMatch;
	
	if vLastShownMatch_ID is not null then
		set new.ShownMatch_ID := vLastShownMatch_ID + 1;
	else
		set new.ShownMatch_ID := 1;
	end if;
end
//
delimiter ;

delimiter //
create or replace trigger bd_PollMember
	before delete on PollMember
for each row
begin 
	declare vPollMemberId type of PollMember.PollMember_ID;

	delete from Password 
		where PollMember_ID = old.PollMember_ID;
end
delimiter ;

#Lliga per defecte
insert into championship 
	values('Liga Smartbank', 1, 2, 22);
#Usuari administrador
insert into pollmember 
	values(1, 'Admin', '', '', '', '', 0);
#Contrasenya de l'administrador: admin
insert into password 
	values(1, 'admin');
	
#Equips predefinits
insert into club(Name, Short_name, Championship_ID, Stadium, Locality)
	values('Girona FC', 'Girona', 1, 'Montilivi', 'Girona');
insert into club(Name, Short_name, Championship_ID, Stadium, Locality)
	values('SD Eibar', 'Eibar', 1, 'Ipurua', 'Eibar');
insert into club(Name, Short_name, Championship_ID, Stadium, Locality)
	values('UD Almería', 'Almería', 1, 'Juegos del Mediterraneo', 'Almeria');
insert into club(Name, Short_name, Championship_ID, Stadium, Locality)
	values('Valladolid CF', 'Valladolid', 1, 'José Zorrilla', 'Valladolid');
insert into club(Name, Short_name, Championship_ID, Stadium, Locality)
	values('CD Tenerife', 'Tenerife', 1, 'Eliodoro Rodríguez López', 'Santa Cruz de Tenerife');
insert into club(Name, Short_name, Championship_ID, Stadium, Locality)
	values('UD Las Palmas', 'Las Palmas', 1, 'Gran Canaria', 'Las Palmas de Gran Canaria');
insert into club(Name, Short_name, Championship_ID, Stadium, Locality)
	values('Real Oviedo', 'Oviedo', 1, 'Carlos Tartiere', 'Oviedo');
insert into club(Name, Short_name, Championship_ID, Stadium, Locality)
	values('SD Ponferradina', 'Ponfe', 1, 'El Toralín', 'Ponferrada');
insert into club(Name, Short_name, Championship_ID, Stadium, Locality)
	values('FC Cartagena', 'Cartagena', 1, 'Cartagonova', 'Cartagena');
insert into club(Name, Short_name, Championship_ID, Stadium, Locality)
	values('Burgos CF', 'Burgos', 1, 'El Plantio', 'Burgos');
insert into club(Name, Short_name, Championship_ID, Stadium, Locality)
	values('SD Huesca', 'Huesca', 1, 'El Alcoraz', 'Osca');
insert into club(Name, Short_name, Championship_ID, Stadium, Locality)
	values('CD Leganés', 'Leganés', 1, 'Butarque', 'Leganés');
insert into club(Name, Short_name, Championship_ID, Stadium, Locality)
	values('Real Zaragoza', 'Zaragoza', 1, 'La Romareda', 'Saragossa');
insert into club(Name, Short_name, Championship_ID, Stadium, Locality)
	values('UD Ibiza', 'Ibiza', 1, 'Can Misses', 'Eivissa');
insert into club(Name, Short_name, Championship_ID, Stadium, Locality)
	values('CD Mirandés', 'Mirandés', 1, 'Anduva', 'Miranda de Ebro');
insert into club(Name, Short_name, Championship_ID, Stadium, Locality)
	values('CD Lugo', 'Lugo', 1, 'Ángel Carro', 'Lugo');
insert into club(Name, Short_name, Championship_ID, Stadium, Locality)
	values('Real Sporting de Gijón', 'Sporting', 1, 'El Molinón', 'Gijón');
insert into club(Name, Short_name, Championship_ID, Stadium, Locality)
	values('Málaga CF', 'Málaga', 1, 'La Rosaleda', 'Màlaga');
insert into club(Name, Short_name, Championship_ID, Stadium, Locality)
	values('Real Sociedad de Fútbol B', 'Real Sociedad B', 1, 'José Luis Orbegozo', 'Sant Sebastià');
insert into club(Name, Short_name, Championship_ID, Stadium, Locality)
	values('SD Amorebieta', 'Amorebieta', 1, 'Urritxe', 'Amorebieta-Etxano');
insert into club(Name, Short_name, Championship_ID, Stadium, Locality)
	values('CF Fuenlabrada', 'Fuenlabrada', 1, 'Fernando Torres', 'Fuenlabrada');
insert into club(Name, Short_name, Championship_ID, Stadium, Locality)
	values('Agrupación Deportiva Alcorcón', 'Alcorcón', 1, 'Santo Domingo', 'Alcorcón');

select * from pollmember;
select * from password p ;
select * from scorehistory s ;
select * from bet;

```


