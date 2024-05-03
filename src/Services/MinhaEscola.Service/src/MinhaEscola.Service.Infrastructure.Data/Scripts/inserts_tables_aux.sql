\connect minhaescoladb_h
----------- situation operation ------------
INSERT INTO public.situation_operation
(description)
VALUES('in activity');

INSERT INTO public.situation_operation
(description)
VALUES('paralyzed');


INSERT INTO public.situation_operation
(description)
VALUES('extinct');

------------ zone ------------
INSERT INTO public."zone"
("name")
VALUES('urban');

INSERT INTO public."zone"
("name")
VALUES('rural');


----------- dependency administractvie -----------------
INSERT INTO public.dependency_administractive
(description)
VALUES('Federal');

INSERT INTO public.dependency_administractive
(description)
VALUES('State');

INSERT INTO public.dependency_administractive
(description)
VALUES('Municipal');

INSERT INTO public.dependency_administractive
(description)
VALUES('Private');

-------- category school privated -------

INSERT INTO public.category_school_privated
(description)
VALUES('Particular');

INSERT INTO public.category_school_privated
(description)
VALUES('Particular');

INSERT INTO public.category_school_privated
(description)
VALUES('Confessional');


INSERT INTO public.category_school_privated
(description)
VALUES('Philanthropic');

--------------- location operation ---

INSERT INTO public.location_operation
(description)
VALUES('school building');

INSERT INTO public.location_operation
(description)
VALUES('Room(s) at another school');

INSERT INTO public.location_operation
(description)
VALUES('shed / ranch / barn / shed');

INSERT INTO public.location_operation
(description)
VALUES('Socio-educational service unit');

INSERT INTO public.location_operation
(description)
VALUES('prison unit');


INSERT INTO public.location_operation
(description)
VALUES('Others');

insert into level_education (description) values ('Educa��o b�sica');
insert into level_education (description) values ('Educa��o superior');


insert into stage (level_education_id, description) values (1, 'Educa��o infantil');
insert into stage (level_education_id, description) values (1, 'Educa��o fundamental');
insert into stage (level_education_id, description) values (1, 'Educa��o m�dio');

insert into stage (level_education_id, description) values (2, 'Bacharel');
insert into stage (level_education_id, description) values (2, 'Mestrado');
insert into stage (level_education_id, description) values (2, 'Tecnologo');
insert into stage (level_education_id, description) values (2, 'P�s-grauda��o');


insert into modality (description) values ('Educa��o Especial');
insert into modality (description) values ('Educa��o de Jovens e Adultos (EJA)');
insert into modality (description) values ('Educa��o Profissional e Tecnologica (EPT)');
insert into modality (description) values ('Educa��o a Dist�ncia (EAD)');
insert into modality (description) values ('Educa��o do Campo');
insert into modality (description) values ('Educa��o Ind�gena');
insert into modality (description) values ('Educa��o Quilombola');
insert into modality (description) values ('Educa��o Presencial');


insert into public.denomination (description) values ('Creche (0 a 3 anos)');
insert into public.denomination (description) values ('Pr�-escola (4 e 5 anos)');
insert into public.denomination (description) values ('Unificada (0 a 5 anos)');
insert into public.denomination (description) values ('1� ano ');
insert into public.denomination (description) values ('2� ano ');
insert into public.denomination (description) values ('3� ano ');
insert into public.denomination (description) values ('4� ano ');
insert into public.denomination (description) values ('5� ano ');
insert into public.denomination (description) values ('6� ano ');
insert into public.denomination (description) values ('7� ano ');
insert into public.denomination (description) values ('8� ano ');
insert into public.denomination (description) values ('9� ano ');
insert into public.denomination (description) values ('Multi ');
insert into public.denomination (description) values ('Corre��o de fluxo ');
insert into public.denomination (description) values ('1� ano/s�rie ');
insert into public.denomination (description) values ('2� ano/s�rie ');
insert into public.denomination (description) values ('3� ano/s�rie ');
insert into public.denomination (description) values ('4� ano/s�rie ');
insert into public.denomination (description) values ('N�o s�riada ');
insert into public.denomination (description) values ('1� s�rie ');
insert into public.denomination (description) values ('2� s�rie ');
insert into public.denomination (description) values ('3� s�rie ');
insert into public.denomination (description) values ('4� s�rie ');


