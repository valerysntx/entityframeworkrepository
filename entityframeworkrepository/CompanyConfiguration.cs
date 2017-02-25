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

    // Company
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.27.0.0")]
    public partial class CompanyConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Company>
    {
        public CompanyConfiguration()
            : this("dbo")
        {
        }

        public CompanyConfiguration(string schema)
        {
            Property(x => x.CompanyName).IsUnicode(false);
            Property(x => x.CompanyUrl).IsOptional().IsUnicode(false);
            Property(x => x.CompanySubDomain).IsOptional().IsUnicode(false);
            Property(x => x.CompanyLogo).IsOptional().IsUnicode(false);
            Property(x => x.CompanyProfile).IsUnicode(false);
            Property(x => x.CompanyTelephone).IsOptional().IsUnicode(false);
            Property(x => x.CompanyTheme).IsOptional().IsUnicode(false);
            Property(x => x.FirstName).IsOptional().IsUnicode(false);
            Property(x => x.LastName).IsOptional().IsUnicode(false);
            Property(x => x.VatNo).IsOptional().IsUnicode(false);
            Property(x => x.Address).IsOptional().IsUnicode(false);
            Property(x => x.PostCode).IsOptional().IsUnicode(false);
            Property(x => x.IsDeleted).IsOptional();
            Property(x => x.CountryId).IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
