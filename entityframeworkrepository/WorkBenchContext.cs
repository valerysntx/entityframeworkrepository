// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.51
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entityframeworkrepository
{
    using System.ComponentModel.DataAnnotations;

    using System.Linq;

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.27.0.0")]
    public class WorkBenchContext : System.Data.Entity.DbContext, IWorkBenchContext
    {
        public System.Data.Entity.DbSet<Activity> Activities { get; set; } // Activity
        public System.Data.Entity.DbSet<Company> Companies { get; set; } // Company
        public System.Data.Entity.DbSet<CvBank> CvBanks { get; set; } // CVBank
        public System.Data.Entity.DbSet<CvBankOwner> CvBankOwners { get; set; } // CVBankOwner
        public System.Data.Entity.DbSet<Department> Departments { get; set; } // Department
        public System.Data.Entity.DbSet<Dictionary> Dictionaries { get; set; } // Dictionary
        public System.Data.Entity.DbSet<Event> Events { get; set; } // Event
        public System.Data.Entity.DbSet<InterviewKit> InterviewKits { get; set; } // InterviewKit
        public System.Data.Entity.DbSet<InterviewKitAnswer> InterviewKitAnswers { get; set; } // InterviewKitAnswer
        public System.Data.Entity.DbSet<Job> Jobs { get; set; } // Job
        public System.Data.Entity.DbSet<JobBoard> JobBoards { get; set; } // JobBoard
        public System.Data.Entity.DbSet<JobBoardCart> JobBoardCarts { get; set; } // JobBoardCart
        public System.Data.Entity.DbSet<JobBoardCredential> JobBoardCredentials { get; set; } // JobBoardCredential
        public System.Data.Entity.DbSet<JobForm> JobForms { get; set; } // JobForm
        public System.Data.Entity.DbSet<JobFormResult> JobFormResults { get; set; } // JobFormResult
        public System.Data.Entity.DbSet<JobFormResultDetail> JobFormResultDetails { get; set; } // JobFormResultDetail
        public System.Data.Entity.DbSet<JobFormResultQa> JobFormResultQas { get; set; } // JobFormResultQA
        public System.Data.Entity.DbSet<JobFormResultX> JobFormResultXes { get; set; } // JobFormResultX
        public System.Data.Entity.DbSet<Person> People { get; set; } // Person
        public System.Data.Entity.DbSet<Pipeline> Pipelines { get; set; } // Pipeline
        public System.Data.Entity.DbSet<PricePackage> PricePackages { get; set; } // PricePackage
        public System.Data.Entity.DbSet<Reminder> Reminders { get; set; } // Reminder
        public System.Data.Entity.DbSet<SharedContent> SharedContents { get; set; } // SharedContent
        public System.Data.Entity.DbSet<Stage> Stages { get; set; } // Stage
        public System.Data.Entity.DbSet<Tag> Tags { get; set; } // Tag
        public System.Data.Entity.DbSet<Template> Templates { get; set; } // Template
        public System.Data.Entity.DbSet<TokenManager> TokenManagers { get; set; } // TokenManager

        static WorkBenchContext()
        {
            System.Data.Entity.Database.SetInitializer<WorkBenchContext>(null);
        }

        public WorkBenchContext()
            : base("Name=WorkBenchContext")
        {
        }

        public WorkBenchContext(string connectionString)
            : base(connectionString)
        {
        }

        public WorkBenchContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(connectionString, model)
        {
        }

        public WorkBenchContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        public WorkBenchContext(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == System.DBNull.Value);
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ActivityConfiguration());
            modelBuilder.Configurations.Add(new CompanyConfiguration());
            modelBuilder.Configurations.Add(new CvBankConfiguration());
            modelBuilder.Configurations.Add(new CvBankOwnerConfiguration());
            modelBuilder.Configurations.Add(new DepartmentConfiguration());
            modelBuilder.Configurations.Add(new DictionaryConfiguration());
            modelBuilder.Configurations.Add(new EventConfiguration());
            modelBuilder.Configurations.Add(new InterviewKitConfiguration());
            modelBuilder.Configurations.Add(new InterviewKitAnswerConfiguration());
            modelBuilder.Configurations.Add(new JobConfiguration());
            modelBuilder.Configurations.Add(new JobBoardConfiguration());
            modelBuilder.Configurations.Add(new JobBoardCartConfiguration());
            modelBuilder.Configurations.Add(new JobBoardCredentialConfiguration());
            modelBuilder.Configurations.Add(new JobFormConfiguration());
            modelBuilder.Configurations.Add(new JobFormResultConfiguration());
            modelBuilder.Configurations.Add(new JobFormResultDetailConfiguration());
            modelBuilder.Configurations.Add(new JobFormResultQaConfiguration());
            modelBuilder.Configurations.Add(new JobFormResultXConfiguration());
            modelBuilder.Configurations.Add(new PersonConfiguration());
            modelBuilder.Configurations.Add(new PipelineConfiguration());
            modelBuilder.Configurations.Add(new PricePackageConfiguration());
            modelBuilder.Configurations.Add(new ReminderConfiguration());
            modelBuilder.Configurations.Add(new SharedContentConfiguration());
            modelBuilder.Configurations.Add(new StageConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());
            modelBuilder.Configurations.Add(new TemplateConfiguration());
            modelBuilder.Configurations.Add(new TokenManagerConfiguration());
        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new ActivityConfiguration(schema));
            modelBuilder.Configurations.Add(new CompanyConfiguration(schema));
            modelBuilder.Configurations.Add(new CvBankConfiguration(schema));
            modelBuilder.Configurations.Add(new CvBankOwnerConfiguration(schema));
            modelBuilder.Configurations.Add(new DepartmentConfiguration(schema));
            modelBuilder.Configurations.Add(new DictionaryConfiguration(schema));
            modelBuilder.Configurations.Add(new EventConfiguration(schema));
            modelBuilder.Configurations.Add(new InterviewKitConfiguration(schema));
            modelBuilder.Configurations.Add(new InterviewKitAnswerConfiguration(schema));
            modelBuilder.Configurations.Add(new JobConfiguration(schema));
            modelBuilder.Configurations.Add(new JobBoardConfiguration(schema));
            modelBuilder.Configurations.Add(new JobBoardCartConfiguration(schema));
            modelBuilder.Configurations.Add(new JobBoardCredentialConfiguration(schema));
            modelBuilder.Configurations.Add(new JobFormConfiguration(schema));
            modelBuilder.Configurations.Add(new JobFormResultConfiguration(schema));
            modelBuilder.Configurations.Add(new JobFormResultDetailConfiguration(schema));
            modelBuilder.Configurations.Add(new JobFormResultQaConfiguration(schema));
            modelBuilder.Configurations.Add(new JobFormResultXConfiguration(schema));
            modelBuilder.Configurations.Add(new PersonConfiguration(schema));
            modelBuilder.Configurations.Add(new PipelineConfiguration(schema));
            modelBuilder.Configurations.Add(new PricePackageConfiguration(schema));
            modelBuilder.Configurations.Add(new ReminderConfiguration(schema));
            modelBuilder.Configurations.Add(new SharedContentConfiguration(schema));
            modelBuilder.Configurations.Add(new StageConfiguration(schema));
            modelBuilder.Configurations.Add(new TagConfiguration(schema));
            modelBuilder.Configurations.Add(new TemplateConfiguration(schema));
            modelBuilder.Configurations.Add(new TokenManagerConfiguration(schema));
            return modelBuilder;
        }
    }
}
// </auto-generated>
