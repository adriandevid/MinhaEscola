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

insert into level_education (description) values ('Educação básica');
insert into level_education (description) values ('Educação superior');


insert into stage (level_education_id, description) values (1, 'Educação infantil');
insert into stage (level_education_id, description) values (1, 'Educação fundamental');
insert into stage (level_education_id, description) values (1, 'Educação médio');

insert into stage (level_education_id, description) values (2, 'Bacharel');
insert into stage (level_education_id, description) values (2, 'Mestrado');
insert into stage (level_education_id, description) values (2, 'Tecnologo');
insert into stage (level_education_id, description) values (2, 'Pós-graudação');


insert into modality (description) values ('Educação Especial');
insert into modality (description) values ('Educação de Jovens e Adultos (EJA)');
insert into modality (description) values ('Educação Profissional e Tecnologica (EPT)');
insert into modality (description) values ('Educação a Distância (EAD)');
insert into modality (description) values ('Educação do Campo');
insert into modality (description) values ('Educação Indígena');
insert into modality (description) values ('Educação Quilombola');
insert into modality (description) values ('Educação Presencial');


insert into public.denomination (description) values ('Creche (0 a 3 anos)');
insert into public.denomination (description) values ('Pré-escola (4 e 5 anos)');
insert into public.denomination (description) values ('Unificada (0 a 5 anos)');
insert into public.denomination (description) values ('1º ano ');
insert into public.denomination (description) values ('2º ano ');
insert into public.denomination (description) values ('3º ano ');
insert into public.denomination (description) values ('4º ano ');
insert into public.denomination (description) values ('5º ano ');
insert into public.denomination (description) values ('6º ano ');
insert into public.denomination (description) values ('7º ano ');
insert into public.denomination (description) values ('8º ano ');
insert into public.denomination (description) values ('9º ano ');
insert into public.denomination (description) values ('Multi ');
insert into public.denomination (description) values ('Correção de fluxo ');
insert into public.denomination (description) values ('1º ano/série ');
insert into public.denomination (description) values ('2º ano/série ');
insert into public.denomination (description) values ('3º ano/série ');
insert into public.denomination (description) values ('4º ano/série ');
insert into public.denomination (description) values ('Não sériada ');
insert into public.denomination (description) values ('1º série ');
insert into public.denomination (description) values ('2º série ');
insert into public.denomination (description) values ('3º série ');
insert into public.denomination (description) values ('4º série ');


