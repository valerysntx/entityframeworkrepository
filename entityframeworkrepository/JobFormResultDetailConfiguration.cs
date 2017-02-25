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
    using entityframeworkrepository.core;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    // JobFormResultDetail
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.27.0.0")]
    public partial class JobFormResultDetailConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<JobFormResultDetail>
    {
        public JobFormResultDetailConfiguration()
            : this("dbo")
        {
        }

        public JobFormResultDetailConfiguration(string schema)
        {
            Property(x => x.SchoolName).IsUnicode(false);
            Property(x => x.SchoolStart).IsOptional();
            Property(x => x.SchoolEnd).IsOptional();
            Property(x => x.SchoolFieldOfStudy).IsOptional().IsUnicode(false);
            Property(x => x.SchoolDegree).IsOptional().IsUnicode(false);
            Property(x => x.Company).IsOptional().IsUnicode(false);
            Property(x => x.Industry).IsOptional().IsUnicode(false);
            Property(x => x.JobTitle).IsOptional().IsUnicode(false);
            Property(x => x.Summary).IsOptional().IsUnicode(false);
            Property(x => x.IsCurrentWork).IsOptional();
            Property(x => x.ExperienceStart).IsOptional();
            Property(x => x.ExperienceEnd).IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
