using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MinhaEscola.Service.Infrastructure.Data.Migrations
{
    public partial class databasev10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "category_school_privated",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category_school_privated", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "color",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_color", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "component",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar", nullable: false),
                    denomination = table.Column<string>(type: "varchar(50)", nullable: false),
                    type_organization = table.Column<short>(type: "int2", nullable: false),
                    StageId = table.Column<long>(type: "bigint", nullable: false),
                    ModalityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_component", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dependency_administractive",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dependency_administractive", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "discipline",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discipline", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "knowledge_area",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    description = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_knowledge_area", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "location_operation",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_location_operation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nationality",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nationality", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "public_agency",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_public_agency", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sex",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sex", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "situation_operation",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_situation_operation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "type_affiliation",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_type_affiliation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "type_documentation",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_type_documentation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "work_load",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    weekly_class = table.Column<int>(type: "int4", nullable: false),
                    annual_class = table.Column<int>(type: "int4", nullable: false),
                    week_hours = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_work_load", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "zone",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zone", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "address",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    street = table.Column<string>(type: "varchar(100)", nullable: false),
                    cep = table.Column<string>(type: "varchar(20)", nullable: false),
                    neighborhood = table.Column<string>(type: "varchar(100)", nullable: false),
                    zone_id = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.id);
                    table.ForeignKey(
                        name: "FK_address_zone_zone_id",
                        column: x => x.zone_id,
                        principalSchema: "public",
                        principalTable: "zone",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "physical_person",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    years = table.Column<int>(type: "int4", nullable: false),
                    cpf = table.Column<string>(type: "char(11)", nullable: true),
                    address_id = table.Column<int>(type: "int4", nullable: false),
                    sex_id = table.Column<int>(type: "int4", nullable: false),
                    color_id = table.Column<int>(type: "int4", nullable: false),
                    rg = table.Column<string>(type: "char(10)", nullable: true),
                    nationality_id = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_physical_person", x => x.id);
                    table.ForeignKey(
                        name: "FK_physical_person_address_address_id",
                        column: x => x.address_id,
                        principalSchema: "public",
                        principalTable: "address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_physical_person_color_color_id",
                        column: x => x.color_id,
                        principalSchema: "public",
                        principalTable: "color",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_physical_person_nationality_nationality_id",
                        column: x => x.nationality_id,
                        principalSchema: "public",
                        principalTable: "nationality",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_physical_person_sex_sex_id",
                        column: x => x.sex_id,
                        principalSchema: "public",
                        principalTable: "sex",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "school",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    address_id = table.Column<int>(type: "int4", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    name_abbreviated = table.Column<string>(type: "varchar(70)", nullable: false),
                    situation_operation_id = table.Column<int>(type: "int4", nullable: false),
                    dependency_administractive_id = table.Column<int>(type: "int4", nullable: false),
                    category_school_privated_id = table.Column<int>(type: "int4", nullable: false),
                    cnpj = table.Column<string>(type: "varchar(100)", nullable: false),
                    public_agency_id = table.Column<int>(type: "int4", nullable: false),
                    location_operation_id = table.Column<int>(type: "int4", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_school", x => x.id);
                    table.ForeignKey(
                        name: "FK_school_address_address_id",
                        column: x => x.address_id,
                        principalSchema: "public",
                        principalTable: "address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_school_category_school_privated_category_school_privated_id",
                        column: x => x.category_school_privated_id,
                        principalSchema: "public",
                        principalTable: "category_school_privated",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_school_dependency_administractive_dependency_administractiv~",
                        column: x => x.dependency_administractive_id,
                        principalSchema: "public",
                        principalTable: "dependency_administractive",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_school_location_operation_location_operation_id",
                        column: x => x.location_operation_id,
                        principalSchema: "public",
                        principalTable: "location_operation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_school_public_agency_public_agency_id",
                        column: x => x.public_agency_id,
                        principalSchema: "public",
                        principalTable: "public_agency",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_school_situation_operation_situation_operation_id",
                        column: x => x.situation_operation_id,
                        principalSchema: "public",
                        principalTable: "situation_operation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "affiliation",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    releated_id = table.Column<int>(type: "int4", nullable: false),
                    person_id = table.Column<int>(type: "int4", nullable: false),
                    type_affiliation_id = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_affiliation", x => x.id);
                    table.ForeignKey(
                        name: "FK_affiliation_physical_person_person_id",
                        column: x => x.person_id,
                        principalSchema: "public",
                        principalTable: "physical_person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_affiliation_type_affiliation_type_affiliation_id",
                        column: x => x.type_affiliation_id,
                        principalSchema: "public",
                        principalTable: "type_affiliation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "documentation",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    person_id = table.Column<int>(type: "int4", nullable: false),
                    file_id = table.Column<string>(type: "varchar", nullable: false),
                    type_documentation_id = table.Column<int>(type: "int4", nullable: false),
                    valid = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documentation", x => x.id);
                    table.ForeignKey(
                        name: "FK_documentation_physical_person_person_id",
                        column: x => x.person_id,
                        principalSchema: "public",
                        principalTable: "physical_person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_documentation_type_documentation_type_documentation_id",
                        column: x => x.type_documentation_id,
                        principalSchema: "public",
                        principalTable: "type_documentation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "class",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    quantity_student = table.Column<int>(type: "int4", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    denomination = table.Column<string>(type: "varchar(50)", nullable: false),
                    component_id = table.Column<int>(type: "int4", nullable: false),
                    year = table.Column<short>(type: "int2", nullable: false),
                    school_id = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_class", x => x.id);
                    table.ForeignKey(
                        name: "FK_class_component_component_id",
                        column: x => x.component_id,
                        principalSchema: "public",
                        principalTable: "component",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_class_school_school_id",
                        column: x => x.school_id,
                        principalSchema: "public",
                        principalTable: "school",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "discipline_component",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    component_id = table.Column<int>(type: "int4", nullable: false),
                    discipline_id = table.Column<int>(type: "int4", nullable: false),
                    workload_id = table.Column<int>(type: "int4", nullable: false),
                    knowledgearea_id = table.Column<int>(type: "int4", nullable: false),
                    school_id = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discipline_component", x => x.id);
                    table.ForeignKey(
                        name: "FK_discipline_component_component_component_id",
                        column: x => x.component_id,
                        principalSchema: "public",
                        principalTable: "component",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_discipline_component_discipline_component_id",
                        column: x => x.component_id,
                        principalSchema: "public",
                        principalTable: "discipline",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_discipline_component_knowledge_area_component_id",
                        column: x => x.component_id,
                        principalSchema: "public",
                        principalTable: "knowledge_area",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_discipline_component_school_school_id",
                        column: x => x.school_id,
                        principalSchema: "public",
                        principalTable: "school",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_discipline_component_work_load_component_id",
                        column: x => x.component_id,
                        principalSchema: "public",
                        principalTable: "work_load",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "school_component",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    school_id = table.Column<int>(type: "int4", nullable: false),
                    component_id = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_school_component", x => x.id);
                    table.ForeignKey(
                        name: "FK_school_component_component_component_id",
                        column: x => x.component_id,
                        principalSchema: "public",
                        principalTable: "component",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_school_component_school_component_id",
                        column: x => x.component_id,
                        principalSchema: "public",
                        principalTable: "school",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "student",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    school_id = table.Column<long>(type: "bigint", nullable: false),
                    person_id = table.Column<long>(type: "bigint", nullable: false),
                    inep = table.Column<long>(type: "bigint", nullable: false),
                    use_transport = table.Column<bool>(type: "boolean", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.id);
                    table.ForeignKey(
                        name: "FK_student_physical_person_person_id",
                        column: x => x.person_id,
                        principalSchema: "public",
                        principalTable: "physical_person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_student_school_school_id",
                        column: x => x.school_id,
                        principalSchema: "public",
                        principalTable: "school",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClassId = table.Column<long>(type: "bigint", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    Year = table.Column<long>(type: "bigint", nullable: false),
                    DateEnrollee = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollment_class_ClassId",
                        column: x => x.ClassId,
                        principalSchema: "public",
                        principalTable: "class",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "public",
                        principalTable: "student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_address_zone_id",
                schema: "public",
                table: "address",
                column: "zone_id");

            migrationBuilder.CreateIndex(
                name: "IX_affiliation_person_id",
                schema: "public",
                table: "affiliation",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_affiliation_type_affiliation_id",
                schema: "public",
                table: "affiliation",
                column: "type_affiliation_id");

            migrationBuilder.CreateIndex(
                name: "IX_class_component_id",
                schema: "public",
                table: "class",
                column: "component_id");

            migrationBuilder.CreateIndex(
                name: "IX_class_school_id",
                schema: "public",
                table: "class",
                column: "school_id");

            migrationBuilder.CreateIndex(
                name: "IX_discipline_component_component_id",
                schema: "public",
                table: "discipline_component",
                column: "component_id");

            migrationBuilder.CreateIndex(
                name: "IX_discipline_component_school_id",
                schema: "public",
                table: "discipline_component",
                column: "school_id");

            migrationBuilder.CreateIndex(
                name: "IX_documentation_person_id",
                schema: "public",
                table: "documentation",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_documentation_type_documentation_id",
                schema: "public",
                table: "documentation",
                column: "type_documentation_id");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_ClassId",
                table: "Enrollment",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_StudentId",
                table: "Enrollment",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_physical_person_address_id",
                schema: "public",
                table: "physical_person",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_physical_person_color_id",
                schema: "public",
                table: "physical_person",
                column: "color_id");

            migrationBuilder.CreateIndex(
                name: "IX_physical_person_nationality_id",
                schema: "public",
                table: "physical_person",
                column: "nationality_id");

            migrationBuilder.CreateIndex(
                name: "IX_physical_person_sex_id",
                schema: "public",
                table: "physical_person",
                column: "sex_id");

            migrationBuilder.CreateIndex(
                name: "IX_school_address_id",
                schema: "public",
                table: "school",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_school_category_school_privated_id",
                schema: "public",
                table: "school",
                column: "category_school_privated_id");

            migrationBuilder.CreateIndex(
                name: "IX_school_dependency_administractive_id",
                schema: "public",
                table: "school",
                column: "dependency_administractive_id");

            migrationBuilder.CreateIndex(
                name: "IX_school_location_operation_id",
                schema: "public",
                table: "school",
                column: "location_operation_id");

            migrationBuilder.CreateIndex(
                name: "IX_school_public_agency_id",
                schema: "public",
                table: "school",
                column: "public_agency_id");

            migrationBuilder.CreateIndex(
                name: "IX_school_situation_operation_id",
                schema: "public",
                table: "school",
                column: "situation_operation_id");

            migrationBuilder.CreateIndex(
                name: "IX_school_component_component_id",
                schema: "public",
                table: "school_component",
                column: "component_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_person_id",
                schema: "public",
                table: "student",
                column: "person_id");

            migrationBuilder.CreateIndex(
                name: "IX_student_school_id",
                schema: "public",
                table: "student",
                column: "school_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "affiliation",
                schema: "public");

            migrationBuilder.DropTable(
                name: "discipline_component",
                schema: "public");

            migrationBuilder.DropTable(
                name: "documentation",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "school_component",
                schema: "public");

            migrationBuilder.DropTable(
                name: "type_affiliation",
                schema: "public");

            migrationBuilder.DropTable(
                name: "discipline",
                schema: "public");

            migrationBuilder.DropTable(
                name: "knowledge_area",
                schema: "public");

            migrationBuilder.DropTable(
                name: "work_load",
                schema: "public");

            migrationBuilder.DropTable(
                name: "type_documentation",
                schema: "public");

            migrationBuilder.DropTable(
                name: "class",
                schema: "public");

            migrationBuilder.DropTable(
                name: "student",
                schema: "public");

            migrationBuilder.DropTable(
                name: "component",
                schema: "public");

            migrationBuilder.DropTable(
                name: "physical_person",
                schema: "public");

            migrationBuilder.DropTable(
                name: "school",
                schema: "public");

            migrationBuilder.DropTable(
                name: "color",
                schema: "public");

            migrationBuilder.DropTable(
                name: "nationality",
                schema: "public");

            migrationBuilder.DropTable(
                name: "sex",
                schema: "public");

            migrationBuilder.DropTable(
                name: "address",
                schema: "public");

            migrationBuilder.DropTable(
                name: "category_school_privated",
                schema: "public");

            migrationBuilder.DropTable(
                name: "dependency_administractive",
                schema: "public");

            migrationBuilder.DropTable(
                name: "location_operation",
                schema: "public");

            migrationBuilder.DropTable(
                name: "public_agency",
                schema: "public");

            migrationBuilder.DropTable(
                name: "situation_operation",
                schema: "public");

            migrationBuilder.DropTable(
                name: "zone",
                schema: "public");
        }
    }
}
