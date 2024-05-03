create database minhaescoladb_h;
create database eventsdb_h;
create database authorizationdb_h;

\connect minhaescoladb_h

-- public.color definition

-- Drop table

-- DROP TABLE public.color;

CREATE TABLE public.color (
	id serial4 NOT NULL,
	description varchar(100) NOT NULL,
	CONSTRAINT color_pkey PRIMARY KEY (id)
);


-- public.denomination definition

-- Drop table

-- DROP TABLE public.denomination;

CREATE TABLE public.denomination (
	id serial4 NOT NULL,
	description varchar(100) NOT NULL,
	CONSTRAINT denomination_pkey PRIMARY KEY (id)
);


-- public.documentation definition

-- Drop table

-- DROP TABLE public.documentation;

CREATE TABLE public.documentation (
	id serial4 NOT NULL,
	person_id int4 NOT NULL,
	file_id varchar NOT NULL,
	"valid" bool NOT NULL,
	type_documentation_id int4 NOT NULL,
	CONSTRAINT documentation_pkey PRIMARY KEY (id)
);


-- public.knowledge_area definition

-- Drop table

-- DROP TABLE public.knowledge_area;

CREATE TABLE public.knowledge_area (
	id serial4 NOT NULL,
	"name" varchar(100) NOT NULL,
	description varchar(100) NOT NULL,
	CONSTRAINT knowledge_area_pkey PRIMARY KEY (id)
);


-- public.level_education definition

-- Drop table

-- DROP TABLE public.level_education;

CREATE TABLE public.level_education (
	id serial4 NOT NULL,
	description varchar(100) NOT NULL,
	CONSTRAINT level_education_pkey PRIMARY KEY (id)
);


-- public.modality definition

-- Drop table

-- DROP TABLE public.modality;

CREATE TABLE public.modality (
	id serial4 NOT NULL,
	description varchar(100) NOT NULL,
	CONSTRAINT modality_pkey PRIMARY KEY (id)
);


-- public.nationality definition

-- Drop table

-- DROP TABLE public.nationality;

CREATE TABLE public.nationality (
	id serial4 NOT NULL,
	description varchar(100) NOT NULL,
	CONSTRAINT nationality_pkey PRIMARY KEY (id)
);


-- public.public_agency definition

-- Drop table

-- DROP TABLE public.public_agency;

CREATE TABLE public.public_agency (
	id serial4 NOT NULL,
	description varchar(100) NOT NULL,
	CONSTRAINT public_agency_pkey PRIMARY KEY (id)
);


-- public.sex definition

-- Drop table

-- DROP TABLE public.sex;

CREATE TABLE public.sex (
	id serial4 NOT NULL,
	description varchar(100) NOT NULL,
	CONSTRAINT sex_pkey PRIMARY KEY (id)
);


-- public.type_affiliation definition

-- Drop table

-- DROP TABLE public.type_affiliation;

CREATE TABLE public.type_affiliation (
	id serial4 NOT NULL,
	description varchar(100) NOT NULL,
	CONSTRAINT type_affiliation_pkey PRIMARY KEY (id)
);


-- public.type_documentation definition

-- Drop table

-- DROP TABLE public.type_documentation;

CREATE TABLE public.type_documentation (
	id serial4 NOT NULL,
	description varchar(100) NOT NULL,
	CONSTRAINT type_documentation_pkey PRIMARY KEY (id)
);


-- public.work_load definition

-- Drop table

-- DROP TABLE public.work_load;

CREATE TABLE public.work_load (
	id serial4 NOT NULL,
	weekly_class int4 NOT NULL,
	annual_class int4 NOT NULL,
	week_hours int4 NOT NULL,
	CONSTRAINT work_load_pkey PRIMARY KEY (id)
);


-- public."zone" definition

-- Drop table

-- DROP TABLE public."zone";

CREATE TABLE public."zone" (
	id serial4 NOT NULL,
	"name" varchar(100) NOT NULL,
	CONSTRAINT zone_pkey PRIMARY KEY (id)
);


-- public.address definition

-- Drop table

-- DROP TABLE public.address;

CREATE TABLE public.address (
	id serial4 NOT NULL,
	street varchar(100) NOT NULL,
	cep varchar(20) NOT NULL,
	neighborhood varchar(100) NOT NULL,
	zone_id int4 NOT NULL,
	CONSTRAINT address_pkey PRIMARY KEY (id),
	CONSTRAINT zone_id_fk FOREIGN KEY (zone_id) REFERENCES public."zone"(id)
);


-- public.discipline definition

-- Drop table

-- DROP TABLE public.discipline;

CREATE TABLE public.discipline (
	id serial4 NOT NULL,
	"name" varchar(100) NOT NULL,
	knowledgearea_id int4 NOT NULL,
	CONSTRAINT discipline_pkey PRIMARY KEY (id),
	CONSTRAINT knowledgearea_fk FOREIGN KEY (knowledgearea_id) REFERENCES public.knowledge_area(id)
);


-- public.physical_person definition

-- Drop table

-- DROP TABLE public.physical_person;

CREATE TABLE public.physical_person (
	id serial4 NOT NULL,
	years int4 NOT NULL,
	cpf bpchar(11) NOT NULL,
	rg bpchar(10) NOT NULL,
	address_id int4 NOT NULL,
	sex_id int4 NOT NULL,
	color_id int4 NOT NULL,
	nationality_id int4 NOT NULL,
	"name" varchar(100) NOT NULL,
	CONSTRAINT physical_person_pkey PRIMARY KEY (id),
	CONSTRAINT address_fk FOREIGN KEY (address_id) REFERENCES public.address(id),
	CONSTRAINT color_fk FOREIGN KEY (color_id) REFERENCES public.color(id),
	CONSTRAINT nationality_fk FOREIGN KEY (nationality_id) REFERENCES public.nationality(id),
	CONSTRAINT sex_fk FOREIGN KEY (sex_id) REFERENCES public.sex(id)
);


-- public.school definition

-- Drop table

-- DROP TABLE public.school;

CREATE TABLE public.school (
	id serial4 NOT NULL,
	"name" varchar(100) NOT NULL,
	name_abbreviated varchar(70) NOT NULL,
	cnpj varchar(100) NOT NULL,
	status int2 NOT NULL,
	address_id int4 NOT NULL,
	situation_operation_id int4 NOT NULL,
	dependency_administractive_id int4 NOT NULL,
	category_school_privated_id int4 NOT NULL,
	public_agency_id int4 NOT NULL,
	type_organization int2 NOT NULL,
	CONSTRAINT school_pkey PRIMARY KEY (id),
	CONSTRAINT address_fk FOREIGN KEY (address_id) REFERENCES public.address(id),
	CONSTRAINT public_agency_fk FOREIGN KEY (public_agency_id) REFERENCES public.public_agency(id)
);


-- public.stage definition

-- Drop table

-- DROP TABLE public.stage;

CREATE TABLE public.stage (
	id serial4 NOT NULL,
	description varchar(100) NOT NULL,
	level_education_id int2 NOT NULL,
	CONSTRAINT stage_pkey PRIMARY KEY (id),
	CONSTRAINT level_education_fk FOREIGN KEY (level_education_id) REFERENCES public.level_education(id)
);


-- public.student definition

-- Drop table

-- DROP TABLE public.student;

CREATE TABLE public.student (
	id serial4 NOT NULL,
	use_transport bool NOT NULL,
	inep varchar NOT NULL,
	person_id int4 NOT NULL,
	school_id int4 NOT NULL,
	status int2 NOT NULL,
	user_id varchar NOT NULL,
	CONSTRAINT student_pkey PRIMARY KEY (id),
	CONSTRAINT person_fk FOREIGN KEY (person_id) REFERENCES public.physical_person(id),
	CONSTRAINT school_fk FOREIGN KEY (school_id) REFERENCES public.school(id)
);


-- public.user_school definition

-- Drop table

-- DROP TABLE public.user_school;

CREATE TABLE public.user_school (
	id serial4 NOT NULL,
	user_id varchar NOT NULL,
	school_id int4 NOT NULL,
	CONSTRAINT tb_user_school_pkey PRIMARY KEY (id),
	CONSTRAINT school_fk FOREIGN KEY (school_id) REFERENCES public.school(id)
);


-- public.affiliation definition

-- Drop table

-- DROP TABLE public.affiliation;

CREATE TABLE public.affiliation (
	id serial4 NOT NULL,
	releated_id int4 NOT NULL,
	person_id int4 NOT NULL,
	type_affiliation_id int4 NOT NULL,
	CONSTRAINT affiliation_pkey PRIMARY KEY (id),
	CONSTRAINT person_fk FOREIGN KEY (person_id) REFERENCES public.physical_person(id),
	CONSTRAINT releated_fk FOREIGN KEY (releated_id) REFERENCES public.physical_person(id),
	CONSTRAINT type_affiliation_fk FOREIGN KEY (type_affiliation_id) REFERENCES public.type_affiliation(id)
);


-- public.component definition

-- Drop table

-- DROP TABLE public.component;

CREATE TABLE public.component (
	id serial4 NOT NULL,
	"name" varchar NOT NULL,
	stage_id int4 NOT NULL,
	modality_id int4 NOT NULL,
	type_organization int2 NOT NULL,
	denomination_id int4 NOT NULL,
	CONSTRAINT component_pkey PRIMARY KEY (id),
	CONSTRAINT denomination_fk FOREIGN KEY (denomination_id) REFERENCES public.denomination(id),
	CONSTRAINT modality_fk FOREIGN KEY (modality_id) REFERENCES public.modality(id),
	CONSTRAINT stage_fk FOREIGN KEY (stage_id) REFERENCES public.stage(id)
);


-- public.discipline_component definition

-- Drop table

-- DROP TABLE public.discipline_component;

CREATE TABLE public.discipline_component (
	id serial4 NOT NULL,
	component_id int4 NOT NULL,
	discipline_id int4 NOT NULL,
	workload varchar(100) NOT NULL,
	school_id int4 NOT NULL,
	CONSTRAINT discipline_component_pkey PRIMARY KEY (id),
	CONSTRAINT discipline_fk FOREIGN KEY (discipline_id) REFERENCES public.discipline(id),
	CONSTRAINT school_fk FOREIGN KEY (school_id) REFERENCES public.school(id)
);


-- public.school_component definition

-- Drop table

-- DROP TABLE public.school_component;

CREATE TABLE public.school_component (
	id serial4 NOT NULL,
	component_id int4 NOT NULL,
	school_id int4 NOT NULL,
	CONSTRAINT school_component_pkey PRIMARY KEY (id),
	CONSTRAINT component_fk FOREIGN KEY (component_id) REFERENCES public.component(id),
	CONSTRAINT school_fk FOREIGN KEY (school_id) REFERENCES public.school(id)
);


-- public."class" definition

-- Drop table

-- DROP TABLE public."class";

CREATE TABLE public."class" (
	id serial4 NOT NULL,
	quantity_student int4 NOT NULL,
	active bool NOT NULL,
	denomination varchar(50) NOT NULL,
	"year" int2 NOT NULL,
	school_id int4 NOT NULL,
	component_id int4 NOT NULL,
	CONSTRAINT class_pkey PRIMARY KEY (id),
	CONSTRAINT component_fk FOREIGN KEY (component_id) REFERENCES public.component(id),
	CONSTRAINT school_fk FOREIGN KEY (school_id) REFERENCES public.school(id)
);


-- public.enrollment definition

-- Drop table

-- DROP TABLE public.enrollment;

CREATE TABLE public.enrollment (
	id serial4 NOT NULL,
	"year" int4 NOT NULL,
	date_enrollment timestamp NOT NULL,
	active bool NOT NULL,
	class_id int4 NOT NULL,
	student_id int4 NOT NULL,
	CONSTRAINT enrollment_pkey PRIMARY KEY (id),
	CONSTRAINT class_fk FOREIGN KEY (class_id) REFERENCES public."class"(id),
	CONSTRAINT student_fk FOREIGN KEY (student_id) REFERENCES public.student(id)
);


-- public.lesson definition

-- Drop table

-- DROP TABLE public.lesson;

CREATE TABLE public.lesson (
	id serial4 NOT NULL,
	description varchar(200) NOT NULL,
	"date" timestamp NOT NULL,
	duration float4 NOT NULL,
	class_id int4 NOT NULL,
	CONSTRAINT lesson_pkey PRIMARY KEY (id),
	CONSTRAINT class_fk FOREIGN KEY (class_id) REFERENCES public."class"(id)
);


-- public.subject definition

-- Drop table

-- DROP TABLE public.subject;

CREATE TABLE public.subject (
	id serial4 NOT NULL,
	description varchar(200) NOT NULL,
	title varchar(100) NOT NULL,
	lesson_id int4 NOT NULL,
	CONSTRAINT subject_pkey PRIMARY KEY (id),
	CONSTRAINT lesson_fk FOREIGN KEY (lesson_id) REFERENCES public.lesson(id)
);


------------ Inserts of tables -------------

------------ zone ------------
INSERT INTO public."zone"
("name")
VALUES('urban');

INSERT INTO public."zone"
("name")
VALUES('rural');


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


