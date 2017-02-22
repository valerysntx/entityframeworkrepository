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

    // CVBankOwner
    [Table("CVBankOwner", Schema = "dbo")]
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.27.0.0")]
    public class CvBankOwner
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"CVBankOwnerID", Order = 1, TypeName = "int")]
        [Index(@"PK_CVBankOwner", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Cvb ank owner ID")]
        public int CvBankOwnerId { get; set; } // CVBankOwnerID (Primary key)

        [Column(@"CVBankID", Order = 2, TypeName = "int")]
        [Required]
        [Display(Name = "Cvb ank ID")]
        public int CvBankId { get; set; } // CVBankID

        [Column(@"JobFormResultID", Order = 3, TypeName = "int")]
        [Required]
        [Display(Name = "Job form result ID")]
        public int JobFormResultId { get; set; } // JobFormResultID

        [Column(@"IsDeleted", Order = 4, TypeName = "bit")]
        [Display(Name = "Is deleted")]
        public bool? IsDeleted { get; set; } // IsDeleted

        [Column(@"UpdatedBy", Order = 5, TypeName = "int")]
        [Required]
        [Display(Name = "Updated by")]
        public int UpdatedBy { get; set; } // UpdatedBy

        [Column(@"CreatedBy", Order = 6, TypeName = "int")]
        [Required]
        [Display(Name = "Created by")]
        public int CreatedBy { get; set; } // CreatedBy

        [Column(@"DateAdded", Order = 7, TypeName = "datetime")]
        [Required]
        [Display(Name = "Date added")]
        public System.DateTime DateAdded { get; set; } // DateAdded

        [Column(@"DateUpdated", Order = 8, TypeName = "datetime")]
        [Required]
        [Display(Name = "Date updated")]
        public System.DateTime DateUpdated { get; set; } // DateUpdated

        // Foreign keys
        [ForeignKey("CvBankId")] public virtual CvBank CvBank { get; set; } // FK_CVBankOwner_CVBank
    }

}
// </auto-generated>
