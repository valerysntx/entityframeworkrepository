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

    // Person
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.27.0.0")]
    public class PersonConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
            : this("dbo")
        {
        }

        public PersonConfiguration(string schema)
        {
            Property(x => x.Email).IsOptional().IsUnicode(false);
            Property(x => x.FirstName).IsOptional().IsUnicode(false);
            Property(x => x.LastName).IsOptional().IsUnicode(false);
            Property(x => x.Telephone).IsOptional().IsUnicode(false);
            Property(x => x.MobilePhone).IsOptional().IsUnicode(false);
            Property(x => x.Headline).IsOptional().IsUnicode(false);
            Property(x => x.Password).IsOptional().IsUnicode(false);
            Property(x => x.IsLockedOut).IsOptional();
            Property(x => x.IsReal).IsOptional();
            Property(x => x.Picture).IsOptional().IsUnicode(false);
            Property(x => x.TimeZone).IsOptional().IsUnicode(false);
            Property(x => x.Signature).IsOptional().IsUnicode(false);
            Property(x => x.Preference).IsOptional().IsUnicode(false);
            Property(x => x.DictionaryTypeId).IsOptional();
            Property(x => x.SignatureOnOff).IsOptional();
            Property(x => x.CampaignSource).IsOptional().IsUnicode(false);
            Property(x => x.UpdatedBy).IsOptional();
            Property(x => x.CreatedBy).IsOptional();
            Property(x => x.DateAdded).IsOptional();
            Property(x => x.DateUpdated).IsOptional();

        }
    }

}
// </auto-generated>
