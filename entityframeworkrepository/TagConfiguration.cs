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
    using System.ComponentModel.DataAnnotations;

    // Tag
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.27.0.0")]
    public partial class TagConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Tag>
    {
        public TagConfiguration()
            : this("dbo")
        {
        }

        public TagConfiguration(string schema)
        {
            Property(x => x.TagName).IsUnicode(false);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>