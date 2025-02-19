using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace hrms_backend.Migrations
{
    /// <inheritdoc />
    public partial class i : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityLogs",
                columns: table => new
                {
                    log_id = table.Column<int>(type: "integer", nullable: false),
                    fk_user_id = table.Column<int>(type: "integer", nullable: true),
                    activity_date = table.Column<DateTime>(type: "timestamp", nullable: true), // Change this line
                    activity_description = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Activity__9E2397E0FBE43A42", x => x.log_id);
                });
        

       migrationBuilder.CreateTable(
    name: "ContractTypes",
    columns: table => new
    {
        contract_type_id = table.Column<int>(type: "integer", nullable: false),
        contract_type_name = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
        description = table.Column<string>(type: "text", nullable: true),
        created_date = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "now()"), // Updated this line
        created_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
        modified_date = table.Column<DateTime>(type: "timestamp", nullable: true), // Updated this line
        modified_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
        is_active = table.Column<bool>(type: "boolean", nullable: true)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK__Contract__B66967DF66A70ACD", x => x.contract_type_id);
    });


            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    shortname = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: false),
                    name = table.Column<string>(type: "character varying(150)", unicode: false, maxLength: 150, nullable: false),
                    phonecode = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__countrie__3213E83F4465402F", x => x.id);
                });

            migrationBuilder.CreateTable(
      name: "Department",
      columns: table => new
      {
          department_id = table.Column<int>(type: "integer", nullable: false),
          department_name = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
          description = table.Column<string>(type: "text", nullable: true),
          created_date = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "now()"),
          created_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
          modified_date = table.Column<DateTime>(type: "date", nullable: true),
          modified_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
          is_active = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"), // Updated this line
          fk_designation_id = table.Column<int>(type: "integer", nullable: true)
      },
      constraints: table =>
      {
          table.PrimaryKey("PK__Departme__C22324221B0A5495", x => x.department_id);
      });

            migrationBuilder.CreateTable(
                name: "Designation",
                columns: table => new
                {
                    designation_id = table.Column<int>(type: "integer", nullable: false),
                    designation_name = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "now()"),
                    created_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    modified_date = table.Column<DateTime>(type: "date", nullable: true),
                    modified_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Designat__177649C1BE733CB2", x => x.designation_id);
                });

            migrationBuilder.CreateTable(
                name: "EditOT",
                columns: table => new
                {
                    editot_id = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    original_ot_hours = table.Column<TimeSpan>(type: "interval", nullable: true),
                    edited_ot_hours = table.Column<TimeSpan>(type: "interval", nullable: true),
                    reason = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EditOT__234852D538753D43", x => x.editot_id);
                });

            migrationBuilder.CreateTable(
                name: "EditPaidTime",
                columns: table => new
                {
                    edit_id = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    original_paid_time = table.Column<TimeSpan>(type: "interval", nullable: true),
                    edited_paid_time = table.Column<TimeSpan>(type: "interval", nullable: true),
                    reason = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EditPaid__A8C1B4CC3C18EEAA", x => x.edit_id);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplate",
                columns: table => new
                {
                    TemplateId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Subject = table.Column<string>(type: "text", nullable: true),
                    Stage = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: true),
                    FkCompanyId = table.Column<int>(type: "integer", nullable: true),
                    EmailTemplate = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EmailTem__F87ADD27755A01C1", x => x.TemplateId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeGroups",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "integer", nullable: false),
                    group_name = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "now()"),
                    created_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    modified_date = table.Column<DateTime>(type: "date", nullable: true),
                    modified_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__D57795A05F39F93C", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeStatus",
                columns: table => new
                {
                    emp_status_id = table.Column<int>(type: "integer", nullable: false),
                    status_name = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__8F2E59B90D6860EA", x => x.emp_status_id);
                });

            migrationBuilder.CreateTable(
                name: "EmployementType",
                columns: table => new
                {
                    employee_type_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type_name = table.Column<string>(type: "text", unicode: false, nullable: true),
                    created_date = table.Column<DateTime>(type: "date", nullable: true),
                    created_by = table.Column<string>(type: "text", unicode: false, nullable: true),
                    modified_date = table.Column<DateTime>(type: "date", nullable: true),
                    modified_by = table.Column<string>(type: "text", unicode: false, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employem__A36C7A1C6017A549", x => x.employee_type_id);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    holiday_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    holiday_name = table.Column<string>(type: "text", nullable: true),
                    fk_company_id = table.Column<int>(type: "integer", nullable: true),
                    from_date = table.Column<DateTime>(type: "date", nullable: true),
                    to_date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Holidays__253884EA34BADC18", x => x.holiday_id);
                });

            migrationBuilder.CreateTable(
                name: "Industry",
                columns: table => new
                {
                    industry_id = table.Column<int>(type: "integer", nullable: false),
                    industry_name = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "now()"),
                    created_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    modified_date = table.Column<DateTime>(type: "date", nullable: true),
                    modified_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Industry__A9676AC8181C3389", x => x.industry_id);
                });

            migrationBuilder.CreateTable(
                name: "LoginHistory",
                columns: table => new
                {
                    login_id = table.Column<int>(type: "integer", nullable: false),
                    fk_employee_id = table.Column<int>(type: "integer", nullable: true),
                    login_date = table.Column<DateTime>(type: "timestamp", nullable: true),
                    logout_date = table.Column<DateTime>(type: "timestamp", nullable: true),
                    login_status = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LoginHis__C2C971DBF8021BA2", x => x.login_id);
                });

            migrationBuilder.CreateTable(
                name: "MissingClockInOut",
                columns: table => new
                {
                    missingclockinout_id = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    missing_clock_in_time = table.Column<TimeSpan>(type: "interval", nullable: true),
                    missing_clock_out_time = table.Column<TimeSpan>(type: "interval", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MissingC__190B2EC9CAB71D29", x => x.missingclockinout_id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    module_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    module_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Modules__2B7477870CE44DE4", x => x.module_id);
                });

            migrationBuilder.CreateTable(
                name: "Nationality",
                columns: table => new
                {
                    NationalityID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NationalityName = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__National__F628E7A403D6D417", x => x.NationalityID);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    office_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    office_name = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    address = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    city = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    state = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    country = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    postal_code = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    created_date = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(now())"),
                    created_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    modified_date = table.Column<DateTime>(type: "date", nullable: true),
                    modified_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: true),
                    fk_company_id = table.Column<int>(type: "integer", nullable: true),
                    fk_schedule_id = table.Column<int>(type: "integer", nullable: true),
                    fk_officelocation_id = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: true),
                    contact_no = table.Column<long>(type: "bigint", nullable: true),
                    email = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: true),
                    latitude = table.Column<double>(type: "double precision", nullable: true),
                    longitude = table.Column<double>(type: "double precision", nullable: true),
                    radius = table.Column<double>(type: "double precision", nullable: true),
                    qrcode = table.Column<string>(type: "text", unicode: false, nullable: true),
                    fk_country_id = table.Column<int>(type: "integer", nullable: true),
                    fk_state_id = table.Column<int>(type: "integer", nullable: true),
                    fk_city_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Offices__2A196375281F3BCD", x => x.office_id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    permission_id = table.Column<int>(type: "integer", nullable: false),
                    permission_name = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(now())"),
                    created_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    modified_date = table.Column<DateTime>(type: "date", nullable: true),
                    modified_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Permissi__E5331AFA2BDDFE49", x => x.permission_id);
                });

            migrationBuilder.CreateTable(
                name: "Reminders",
                columns: table => new
                {
                    reminder_id = table.Column<int>(type: "integer", nullable: false),
                    reminder_name = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    reminder_date = table.Column<DateTime>(type: "date", nullable: true),
                    reminder_time = table.Column<TimeSpan>(type: "interval", nullable: true),
                    reminder_details = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(now())"),
                    created_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    modified_date = table.Column<DateTime>(type: "date", nullable: true),
                    modified_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reminder__E27A3628D21485A2", x => x.reminder_id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    role_name = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(now())"),
                    created_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    modified_date = table.Column<DateTime>(type: "date", nullable: true),
                    modified_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    CompanyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Role__760965CCEB4BCDAD", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    section_id = table.Column<int>(type: "integer", nullable: false),
                    section_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    isactive = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sections__80EF0872C779387A", x => x.section_id);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    subscription_id = table.Column<int>(type: "integer", nullable: false),
                    subscription_name = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_date = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(now())"),
                    created_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    modified_date = table.Column<DateTime>(type: "date", nullable: true),
                    modified_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Subscrip__863A7EC12643307C", x => x.subscription_id);
                });

            migrationBuilder.CreateTable(
                name: "UserDevices",
                columns: table => new
                {
                    device_id = table.Column<int>(type: "integer", nullable: false),
                    fk_user_id = table.Column<int>(type: "integer", nullable: true),
                    device_name = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    device_type = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    device_token = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserDevi__3B085D8BCAC5EBDF", x => x.device_id);
                });

            migrationBuilder.CreateTable(
                name: "statess",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: false),
                    country_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__statess__3213E83FE3DCA3CF", x => x.id);
                    table.ForeignKey(
                        name: "FK_statess_countries",
                        column: x => x.country_id,
                        principalTable: "countries",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "RoleModulePermissionMapping",
                columns: table => new
                {
                    mapping_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<int>(type: "integer", nullable: true),
                    module_id = table.Column<int>(type: "integer", nullable: true),
                    permission_flag = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RoleModu__8B5781BD10CE3CB3", x => x.mapping_id);
                    table.ForeignKey(
                        name: "FK_RoleModulePermissionMapping_Modules_module_id",
                        column: x => x.module_id,
                        principalTable: "Modules",
                        principalColumn: "module_id");
                    table.ForeignKey(
                        name: "FK__RoleModul__RoleI__6F4A8121",
                        column: x => x.role_id,
                        principalTable: "Role",
                        principalColumn: "role_id");
                });

            migrationBuilder.CreateTable(
    name: "Company",
    columns: table => new
    {
        company_id = table.Column<int>(type: "integer", nullable: false),
        company_name = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
        description = table.Column<string>(type: "text", nullable: true),
        created_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
        created_date = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(now())"),
        modified_date = table.Column<DateTime>(type: "date", nullable: true),
        modified_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
        is_active = table.Column<bool>(type: "boolean", nullable: true),
        domain = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
        size = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
        logo = table.Column<byte[]>(type: "bytea", nullable: true), // Change 'image' to 'bytea'
        fk_industry_id = table.Column<int>(type: "integer", nullable: true),
        language = table.Column<string>(type: "text", unicode: false, nullable: true),
        contact_number = table.Column<long>(type: "bigint", nullable: true),
        contact_email = table.Column<string>(type: "text", unicode: false, nullable: true),
        company_website = table.Column<string>(type: "text", unicode: false, nullable: true),
        fk_subscription_id = table.Column<int>(type: "integer", nullable: true),
        fk_permission_id = table.Column<int>(type: "integer", nullable: true),
        fk_remainder_id = table.Column<int>(type: "integer", nullable: true),
        fk_contract_type_id = table.Column<int>(type: "integer", nullable: true),
        fk_company_id = table.Column<int>(type: "integer", nullable: true),
        company_guid = table.Column<Guid>(type: "uuid", nullable: true)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK__Company__3E2672351D3755F2", x => x.company_id);
        table.ForeignKey(
            name: "FK_Company_ContractTypes",
            column: x => x.fk_contract_type_id,
            principalTable: "ContractTypes",
            principalColumn: "contract_type_id");
        table.ForeignKey(
            name: "FK_Company_Industry",
            column: x => x.fk_industry_id,
            principalTable: "Industry",
            principalColumn: "industry_id");
        table.ForeignKey(
            name: "FK_Company_Reminders",
            column: x => x.fk_remainder_id,
            principalTable: "Reminders",
            principalColumn: "reminder_id");
        table.ForeignKey(
            name: "FK_Company_Subscription",
            column: x => x.fk_subscription_id,
            principalTable: "Subscription",
            principalColumn: "subscription_id");
    });


            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(30)", unicode: false, maxLength: 30, nullable: false),
                    state_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cities__3213E83F98E1419B", x => x.id);
                    table.ForeignKey(
                        name: "FK_cities_statess",
                        column: x => x.state_id,
                        principalTable: "statess",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "leave_type",
                columns: table => new
                {
                    leave_type_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    created_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    created_date = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(now())"),
                    modified_date = table.Column<DateTime>(type: "date", nullable: true),
                    modified_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    ispaid = table.Column<bool>(type: "boolean", unicode: false, maxLength: 50, nullable: true),
                    count = table.Column<int>(type: "integer", nullable: true),
                    duration = table.Column<string>(type: "text", unicode: false, nullable: true),
                    limit = table.Column<int>(type: "integer", nullable: true),
                    is_carry_forward = table.Column<bool>(type: "boolean", nullable: true),
                    expiry_date = table.Column<DateTime>(type: "date", nullable: true),
                    eligible_employee_type = table.Column<string>(type: "text", unicode: false, nullable: true),
                    specific_employees = table.Column<string>(type: "text", unicode: false, nullable: true),
                    fk_company_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__leave_ty__727714D4AB5334C5", x => x.leave_type_id);
                    table.ForeignKey(
                        name: "FK_leave_type_Company",
                        column: x => x.fk_company_id,
                        principalTable: "Company",
                        principalColumn: "company_id");
                });

            migrationBuilder.CreateTable(
                name: "OffLocation",
                columns: table => new
                {
                    office_location_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    office_name = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "(now())"),
                    created_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    modified_date = table.Column<DateTime>(type: "timestamp", nullable: true),
                    modified_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: true),
                    latitude = table.Column<double>(type: "double precision", nullable: true),
                    longitude = table.Column<double>(type: "double precision", nullable: true),
                    geofencing = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    latitude1 = table.Column<double>(type: "double precision", nullable: true),
                    longitude1 = table.Column<double>(type: "double precision", nullable: true),
                    qrcode = table.Column<byte[]>(type: "bytea", nullable: true),
                    fkcompanyid = table.Column<int>(type: "integer", nullable: true),
                    qrcodeimage = table.Column<string>(type: "text", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OffLocat__C864FABF64C20A3C", x => x.office_location_id);
                    table.ForeignKey(
                        name: "FK_OffLocation_Company",
                        column: x => x.fkcompanyid,
                        principalTable: "Company",
                        principalColumn: "company_id");
                });

            migrationBuilder.CreateTable(
                name: "SectionPermissions",
                columns: table => new
                {
                    section_permission_id = table.Column<int>(type: "integer", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    section_id = table.Column<int>(type: "integer", nullable: false),
                    permission_flag = table.Column<int>(type: "integer", nullable: false),
                    company_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SectionP__9A304360DECD7AB9", x => x.section_permission_id);
                    table.ForeignKey(
                        name: "FK_SectionPermissions_Company",
                        column: x => x.company_id,
                        principalTable: "Company",
                        principalColumn: "company_id");
                    table.ForeignKey(
                        name: "FK__SectionPe__RoleI__038683F8",
                        column: x => x.role_id,
                        principalTable: "Role",
                        principalColumn: "role_id");
                    table.ForeignKey(
                        name: "FK__SectionPe__Secti__047AA831",
                        column: x => x.section_id,
                        principalTable: "Sections",
                        principalColumn: "section_id");
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    StageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StageName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    fk_company_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Stages__03EB7AD812D4BA1A", x => x.StageId);
                    table.ForeignKey(
                        name: "FK_Stages_Company",
                        column: x => x.fk_company_id,
                        principalTable: "Company",
                        principalColumn: "company_id");
                });

            migrationBuilder.CreateTable(
                name: "Workschedule",
                columns: table => new
                {
                    schedule_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    schedule_name = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    hours_per_day = table.Column<TimeSpan>(type: "interval", nullable: true),
                    schedule_type = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    hours_per_week = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    fk_company_id = table.Column<int>(type: "integer", nullable: true),
                    daily_working_hours = table.Column<string>(type: "text", unicode: false, nullable: true),
                    working_days = table.Column<string>(type: "text", unicode: false, nullable: true),
                    created_date = table.Column<DateTime>(type: "date", nullable: true),
                    created_by = table.Column<int>(type: "integer", nullable: true),
                    modified_date = table.Column<DateTime>(type: "date", nullable: true),
                    modified_by = table.Column<int>(type: "integer", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: true),
                    start_time = table.Column<TimeSpan>(type: "interval", nullable: true),
                    end_time = table.Column<TimeSpan>(type: "interval", nullable: true),
                    late_time = table.Column<TimeSpan>(type: "interval", nullable: true),
                    half_day_time = table.Column<TimeSpan>(type: "interval", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Worksche__C46A8A6F0390EBCB", x => x.schedule_id);
                    table.ForeignKey(
                        name: "FK_Workschedule_Company",
                        column: x => x.fk_company_id,
                        principalTable: "Company",
                        principalColumn: "company_id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(now())"),
                    created_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    modified_date = table.Column<DateTime>(type: "date", nullable: true),
                    modified_by = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    fk_department_id = table.Column<int>(type: "integer", nullable: true),
                    line_manager_id = table.Column<int>(type: "integer", nullable: true),
                    fk_company_id = table.Column<int>(type: "integer", nullable: true),
                    fk_user_id = table.Column<int>(type: "integer", nullable: true),
                    first_name = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    last_name = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    mobile_no = table.Column<int>(type: "integer", nullable: true),
                    email = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    password = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    full_name = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    gender = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    date_of_birth = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    marital_status = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    nationality = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    personal_tax_id = table.Column<int>(type: "integer", nullable: true),
                    social_insurance = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    health_insurance = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    phone_number = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    marriage_anniversary = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    alternate_mobile_no = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    fk_empstatus_id = table.Column<int>(type: "integer", nullable: true),
                    fk_login_history_id = table.Column<string>(type: "character(10)", fixedLength: true, maxLength: 10, nullable: true),
                    fk_office_id = table.Column<int>(type: "integer", nullable: true),
                    fk_employee_group_id = table.Column<int>(type: "integer", nullable: true),
                    featured_image = table.Column<byte[]>(type: "bytea", nullable: true),
                    current_state = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    current_session_id = table.Column<int>(type: "integer", nullable: true),
                    service_year = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    image = table.Column<string>(type: "text", unicode: false, nullable: true),
                    IDS = table.Column<int>(type: "integer", nullable: true),
                    join_date = table.Column<DateTime>(type: "date", nullable: true),
                    fk_role_id = table.Column<int>(type: "integer", nullable: true),
                    tenantId = table.Column<int>(type: "integer", nullable: true),
                    Fimage = table.Column<byte[]>(type: "bytea", unicode: false, nullable: true),
                    fk_designation_id = table.Column<int>(type: "integer", nullable: true),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: true),
                    ResetToken = table.Column<string>(type: "text", unicode: false, nullable: true),
                    activation_token = table.Column<string>(type: "text", unicode: false, nullable: true),
                    IsPasswordGenerated = table.Column<int>(type: "integer", nullable: true),
                    fk_schedule_id = table.Column<int>(type: "integer", nullable: true),
                    fk_employement_type_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__C52E0BA8B53E3551", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK_Employee_Employee",
                        column: x => x.fk_designation_id,
                        principalTable: "Designation",
                        principalColumn: "designation_id");
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeGroups",
                        column: x => x.fk_employee_group_id,
                        principalTable: "EmployeeGroups",
                        principalColumn: "group_id");
                    table.ForeignKey(
                        name: "FK_Employee_EmployementType",
                        column: x => x.fk_employement_type_id,
                        principalTable: "EmployementType",
                        principalColumn: "employee_type_id");
                    table.ForeignKey(
                        name: "FK_Employee_Offices",
                        column: x => x.fk_office_id,
                        principalTable: "Offices",
                        principalColumn: "office_id");
                    table.ForeignKey(
                        name: "FK_Employee_Role",
                        column: x => x.fk_role_id,
                        principalTable: "Role",
                        principalColumn: "role_id");
                    table.ForeignKey(
                        name: "FK_Employee_Workschedule",
                        column: x => x.fk_schedule_id,
                        principalTable: "Workschedule",
                        principalColumn: "schedule_id");
                    table.ForeignKey(
                        name: "FK__Employee__fk_com__787EE5A0",
                        column: x => x.fk_company_id,
                        principalTable: "Company",
                        principalColumn: "company_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Employee__fk_dep__75A278F5",
                        column: x => x.fk_department_id,
                        principalTable: "Department",
                        principalColumn: "department_id");
                    table.ForeignKey(
                        name: "FK__Employee__fk_emp__7A672E12",
                        column: x => x.fk_empstatus_id,
                        principalTable: "EmployeeStatus",
                        principalColumn: "emp_status_id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    address_id = table.Column<int>(type: "integer", nullable: false),
                    fk_employee_id = table.Column<int>(type: "integer", nullable: true),
                    primary_address = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    country = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    city = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    state_province = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    postal_code = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    permanent_address = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Address__CAA247C86F05D4A0", x => x.address_id);
                    table.ForeignKey(
                        name: "FK_Address_Employee",
                        column: x => x.fk_employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    attendance_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fk_employee_id = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<bool>(type: "boolean", nullable: true),
                    latitude = table.Column<decimal>(type: "numeric(10,7)", nullable: true),
                    longitude = table.Column<decimal>(type: "numeric(10,7)", nullable: true),
                    fk_office_id = table.Column<int>(type: "integer", nullable: true),
                    datetime = table.Column<DateTime>(type: "timestamp", nullable: true),
                    is_geofence = table.Column<bool>(type: "boolean", nullable: true),
                    parent_attendance_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Attendan__20D6A9683231AAE7", x => x.attendance_id);
                    table.ForeignKey(
                        name: "FK_Attendance_Employee",
                        column: x => x.fk_employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id");
                    table.ForeignKey(
                        name: "FK_Attendance_Offices",
                        column: x => x.fk_office_id,
                        principalTable: "Offices",
                        principalColumn: "office_id");
                });

            migrationBuilder.CreateTable(
                name: "AttendanceSession",
                columns: table => new
                {
                    atttendnace_session_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clockin_time = table.Column<DateTime>(type: "timestamp", nullable: true),
                    clockout_time = table.Column<DateTime>(type: "timestamp", nullable: true),
                    type = table.Column<bool>(type: "boolean", nullable: true),
                    clock_in_latitude = table.Column<decimal>(type: "numeric(18,6)", nullable: true),
                    clock_in_longitude = table.Column<decimal>(type: "numeric(18,6)", nullable: true),
                    fk_office_id = table.Column<int>(type: "integer", nullable: true),
                    fk_employee_id = table.Column<int>(type: "integer", nullable: true),
                    clockingeofence = table.Column<bool>(type: "boolean", nullable: true),
                    clock_out_latitude = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    clock_out_longitude = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    clockoutgeofence = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Attendan__1DCC4B888F5F2789", x => x.atttendnace_session_id);
                    table.ForeignKey(
                        name: "FK_AttendanceSession_Offices",
                        column: x => x.fk_office_id,
                        principalTable: "Offices",
                        principalColumn: "office_id");
                    table.ForeignKey(
                        name: "fk_attendance_session_employee",
                        column: x => x.fk_employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id");
                });

            migrationBuilder.CreateTable(
                name: "BankInformation",
                columns: table => new
                {
                    bank_info_id = table.Column<int>(type: "integer", nullable: false),
                    fk_employee_id = table.Column<int>(type: "integer", nullable: true),
                    bank_name = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    account_name = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    branch = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    account_number = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    swift_bic = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    iban = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    ifsc_code = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BankInfo__DABDF864033B341F", x => x.bank_info_id);
                    table.ForeignKey(
                        name: "FK_BankInformation_Employee",
                        column: x => x.fk_employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id");
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    document_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fk_employee_id = table.Column<int>(type: "integer", nullable: true),
                    document_type = table.Column<string>(type: "text", nullable: true),
                    document_name = table.Column<string>(type: "text", nullable: true),
                    file_path = table.Column<string>(type: "text", nullable: true),
                    uploaded_date = table.Column<DateTime>(type: "date", nullable: true),
                    uploaded_by = table.Column<string>(type: "text", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Document__9666E8AC1802A28D", x => x.document_id);
                    table.ForeignKey(
                        name: "FK_Document_Employee",
                        column: x => x.fk_employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id");
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContact",
                columns: table => new
                {
                    emergency_contact_id = table.Column<int>(type: "integer", nullable: false),
                    fk_employee_id = table.Column<int>(type: "integer", nullable: true),
                    full_name = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    relationship = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    phone_number = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Emergenc__3B08826D8C394B6E", x => x.emergency_contact_id);
                    table.ForeignKey(
                        name: "FK_EmergencyContact_Employee",
                        column: x => x.fk_employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id");
                });

            migrationBuilder.CreateTable(
                name: "JobHistory",
                columns: table => new
                {
                    jobhistory_id = table.Column<int>(type: "integer", nullable: false),
                    fk_job_id = table.Column<int>(type: "integer", nullable: true),
                    start_date = table.Column<DateTime>(type: "date", nullable: true),
                    end_date = table.Column<DateTime>(type: "date", nullable: true),
                    job_title = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    position_type = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    employment_type = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    office = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    note = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    fk_employee_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__JobHisto__3A6F953611205635", x => x.jobhistory_id);
                    table.ForeignKey(
                        name: "FK_JobHistory_JobHistory",
                        column: x => x.fk_employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id");
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    job_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_date = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(now())"),
                    created_by = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    modified_date = table.Column<DateTime>(type: "date", nullable: true),
                    modified_by = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    fk_employee_id = table.Column<int>(type: "integer", nullable: true),
                    fk_company_id = table.Column<int>(type: "integer", nullable: true),
                    probation_start_date = table.Column<DateTime>(type: "date", nullable: true),
                    probation_end_date = table.Column<DateTime>(type: "date", nullable: true),
                    Job_tittle = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    employeement_type = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    department_name = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    office_name = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: true),
                    closing_date = table.Column<DateTime>(type: "date", nullable: true),
                    description = table.Column<string>(type: "text", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Jobs__6E32B6A50FD982C0", x => x.job_id);
                    table.ForeignKey(
                        name: "FK_Jobs_Company",
                        column: x => x.fk_company_id,
                        principalTable: "Company",
                        principalColumn: "company_id");
                    table.ForeignKey(
                        name: "FK_Jobs_Employee",
                        column: x => x.fk_employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id");
                });

            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    leave_id = table.Column<int>(type: "integer", nullable: false),
                    fk_employee_id = table.Column<int>(type: "integer", nullable: true),
                    from_date = table.Column<DateTime>(type: "date", nullable: true),
                    to_date = table.Column<DateTime>(type: "date", nullable: true),
                    actual_total_leaves = table.Column<TimeSpan>(type: "interval", nullable: true),
                    attachment = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    status = table.Column<int>(type: "integer", nullable: true),
                    total_days = table.Column<int>(type: "integer", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: true, defaultValueSql: "true"),
                    fk_leave_type_id = table.Column<int>(type: "integer", nullable: true),
                    note = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    fk_schedule_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Leaves__743350BC7E1164A6", x => x.leave_id);
                    table.ForeignKey(
                        name: "FK__Leaves__fk_emplo__1B9317B3",
                        column: x => x.fk_employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id");
                    table.ForeignKey(
                        name: "FK__Leaves__fk_leave__1D7B6025",
                        column: x => x.fk_leave_type_id,
                        principalTable: "leave_type",
                        principalColumn: "leave_type_id");
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    news_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: false),
                    imageurl = table.Column<string>(type: "character varying(255)", unicode: false, maxLength: 255, nullable: true),
                    content = table.Column<string>(type: "text", nullable: true),
                    published_date = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "(now())"),
                    fk_employee_id = table.Column<int>(type: "integer", nullable: true),
                    fk_company_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__News__954EBDD3319FC91F", x => x.news_id);
                    table.ForeignKey(
                        name: "FK_News_Company",
                        column: x => x.fk_company_id,
                        principalTable: "Company",
                        principalColumn: "company_id");
                    table.ForeignKey(
                        name: "FK_News_Employee",
                        column: x => x.fk_employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDocuments",
                columns: table => new
                {
                    employee_document_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fk_employee_id = table.Column<int>(type: "integer", nullable: true),
                    fk_document_id = table.Column<int>(type: "integer", nullable: true),
                    is_active = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDocuments", x => x.employee_document_id);
                    table.ForeignKey(
                        name: "FK_EmployeeDocuments_Document",
                        column: x => x.fk_document_id,
                        principalTable: "Document",
                        principalColumn: "document_id");
                    table.ForeignKey(
                        name: "FK_EmployeeDocuments_Employee",
                        column: x => x.fk_employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id");
                });

            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    candidate_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fullname = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    mobile_no = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    cv = table.Column<byte[]>(type: "bytea", nullable: true),
                    created_date = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(now())"),
                    created_by = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    join_date = table.Column<DateTime>(type: "date", nullable: true),
                    stages_name = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    fk_company_id = table.Column<int>(type: "integer", nullable: true),
                    fk_job_id = table.Column<int>(type: "integer", nullable: true),
                    source = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Resume = table.Column<string>(type: "text", unicode: false, nullable: true),
                    Skills = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    profile_photo = table.Column<string>(type: "text", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.candidate_id);
                    table.ForeignKey(
                        name: "FK_Candidate_Candidate",
                        column: x => x.fk_job_id,
                        principalTable: "Jobs",
                        principalColumn: "job_id");
                    table.ForeignKey(
                        name: "FK_Candidate_Company",
                        column: x => x.fk_company_id,
                        principalTable: "Company",
                        principalColumn: "company_id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: true),
                    fk_candidate_id = table.Column<int>(type: "integer", nullable: true),
                    fk_company_id = table.Column<int>(type: "integer", nullable: true),
                    fk_employee_id = table.Column<int>(type: "integer", nullable: true),
                    Time = table.Column<TimeSpan>(type: "interval", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comments__C3B4DFCAF71E5AC2", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Candidate",
                        column: x => x.fk_candidate_id,
                        principalTable: "Candidate",
                        principalColumn: "candidate_id");
                    table.ForeignKey(
                        name: "FK_Comments_Company",
                        column: x => x.fk_company_id,
                        principalTable: "Company",
                        principalColumn: "company_id");
                    table.ForeignKey(
                        name: "FK_Comments_Employee",
                        column: x => x.fk_employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_fk_employee_id",
                table: "Address",
                column: "fk_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_fk_employee_id",
                table: "Attendance",
                column: "fk_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_fk_office_id",
                table: "Attendance",
                column: "fk_office_id");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceSession_fk_employee_id",
                table: "AttendanceSession",
                column: "fk_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceSession_fk_office_id",
                table: "AttendanceSession",
                column: "fk_office_id");

            migrationBuilder.CreateIndex(
                name: "IX_BankInformation_fk_employee_id",
                table: "BankInformation",
                column: "fk_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_fk_company_id",
                table: "Candidate",
                column: "fk_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_fk_job_id",
                table: "Candidate",
                column: "fk_job_id");

            migrationBuilder.CreateIndex(
                name: "IX_cities_state_id",
                table: "cities",
                column: "state_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_fk_candidate_id",
                table: "Comments",
                column: "fk_candidate_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_fk_company_id",
                table: "Comments",
                column: "fk_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_fk_employee_id",
                table: "Comments",
                column: "fk_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Company_fk_contract_type_id",
                table: "Company",
                column: "fk_contract_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Company_fk_industry_id",
                table: "Company",
                column: "fk_industry_id");

            migrationBuilder.CreateIndex(
                name: "IX_Company_fk_remainder_id",
                table: "Company",
                column: "fk_remainder_id");

            migrationBuilder.CreateIndex(
                name: "IX_Company_fk_subscription_id",
                table: "Company",
                column: "fk_subscription_id");

            migrationBuilder.CreateIndex(
                name: "IX_Document_fk_employee_id",
                table: "Document",
                column: "fk_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContact_fk_employee_id",
                table: "EmergencyContact",
                column: "fk_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_fk_company_id",
                table: "Employee",
                column: "fk_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_fk_department_id",
                table: "Employee",
                column: "fk_department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_fk_designation_id",
                table: "Employee",
                column: "fk_designation_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_fk_employee_group_id",
                table: "Employee",
                column: "fk_employee_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_fk_employement_type_id",
                table: "Employee",
                column: "fk_employement_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_fk_empstatus_id",
                table: "Employee",
                column: "fk_empstatus_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_fk_office_id",
                table: "Employee",
                column: "fk_office_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_fk_role_id",
                table: "Employee",
                column: "fk_role_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_fk_schedule_id",
                table: "Employee",
                column: "fk_schedule_id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDocuments_fk_document_id",
                table: "EmployeeDocuments",
                column: "fk_document_id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDocuments_fk_employee_id",
                table: "EmployeeDocuments",
                column: "fk_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_JobHistory_fk_employee_id",
                table: "JobHistory",
                column: "fk_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_fk_company_id",
                table: "Jobs",
                column: "fk_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_fk_employee_id",
                table: "Jobs",
                column: "fk_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_leave_type_fk_company_id",
                table: "leave_type",
                column: "fk_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_fk_employee_id",
                table: "Leaves",
                column: "fk_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_fk_leave_type_id",
                table: "Leaves",
                column: "fk_leave_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_News_fk_company_id",
                table: "News",
                column: "fk_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_News_fk_employee_id",
                table: "News",
                column: "fk_employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_OffLocation_fkcompanyid",
                table: "OffLocation",
                column: "fkcompanyid");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModulePermissionMapping_module_id",
                table: "RoleModulePermissionMapping",
                column: "module_id");

            migrationBuilder.CreateIndex(
                name: "IX_RoleModulePermissionMapping_role_id",
                table: "RoleModulePermissionMapping",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_SectionPermissions_company_id",
                table: "SectionPermissions",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_SectionPermissions_role_id",
                table: "SectionPermissions",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_SectionPermissions_section_id",
                table: "SectionPermissions",
                column: "section_id");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_fk_company_id",
                table: "Stages",
                column: "fk_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_statess_country_id",
                table: "statess",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_Workschedule_fk_company_id",
                table: "Workschedule",
                column: "fk_company_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLogs");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "AttendanceSession");

            migrationBuilder.DropTable(
                name: "BankInformation");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "EditOT");

            migrationBuilder.DropTable(
                name: "EditPaidTime");

            migrationBuilder.DropTable(
                name: "EmailTemplate");

            migrationBuilder.DropTable(
                name: "EmergencyContact");

            migrationBuilder.DropTable(
                name: "EmployeeDocuments");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "JobHistory");

            migrationBuilder.DropTable(
                name: "Leaves");

            migrationBuilder.DropTable(
                name: "LoginHistory");

            migrationBuilder.DropTable(
                name: "MissingClockInOut");

            migrationBuilder.DropTable(
                name: "Nationality");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "OffLocation");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "RoleModulePermissionMapping");

            migrationBuilder.DropTable(
                name: "SectionPermissions");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "UserDevices");

            migrationBuilder.DropTable(
                name: "statess");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "leave_type");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Designation");

            migrationBuilder.DropTable(
                name: "EmployeeGroups");

            migrationBuilder.DropTable(
                name: "EmployementType");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Workschedule");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "EmployeeStatus");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "ContractTypes");

            migrationBuilder.DropTable(
                name: "Industry");

            migrationBuilder.DropTable(
                name: "Reminders");

            migrationBuilder.DropTable(
                name: "Subscription");
        }
    }
}
