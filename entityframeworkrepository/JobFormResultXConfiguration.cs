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

    // JobFormResultX
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.27.0.0")]
    public class JobFormResultXConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<JobFormResultX>
    {
        public JobFormResultXConfiguration()
            : this("dbo")
        {
        }

        public JobFormResultXConfiguration(string schema)
        {
            Property(x => x.FirstName).IsUnicode(false);
            Property(x => x.LastName).IsUnicode(false);
            Property(x => x.Email).IsUnicode(false);
            Property(x => x.Headline).IsUnicode(false);
            Property(x => x.Telephone).IsUnicode(false);
            Property(x => x.Address).IsUnicode(false);
            Property(x => x.Photo).IsUnicode(false);
            Property(x => x.Video).IsUnicode(false);
            Property(x => x.Summary).IsUnicode(false);
            Property(x => x.Source).IsOptional().IsUnicode(false);
            Property(x => x.Referer).IsUnicode(false);
            Property(x => x.IsRead).IsOptional();
            Property(x => x.IsDeleted).IsOptional();
            Property(x => x.AdminBlock).IsOptional();
            Property(x => x.QuestionAnswerXml).IsOptional().IsUnicode(false);
        }
    }

}
// </auto-generated>
