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

    // JobBoardCredential
    [Table("JobBoardCredential", Schema = "dbo")]
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.27.0.0")]
    public partial class JobBoardCredential: BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"JobBoardCredentialID", Order = 1, TypeName = "int")]
        [Index(@"PK_JobBoardCredential", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Job board credential ID")]
        public int JobBoardCredentialId { get; set; } // JobBoardCredentialID (Primary key)

        [Column(@"JobID", Order = 2, TypeName = "int")]
        [Required]
        [Display(Name = "Job ID")]
        public int JobId { get; set; } // JobID

        [Column(@"JobBoardID", Order = 3, TypeName = "int")]
        [Required]
        [Display(Name = "Job board ID")]
        public int JobBoardId { get; set; } // JobBoardID

        [Column(@"JobBoardUserName", Order = 4, TypeName = "varchar")]
        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Job board user name")]
        public string JobBoardUserName { get; set; } // JobBoardUserName (length: 50)

        [Column(@"JobBoardPassword", Order = 5, TypeName = "varchar")]
        [Required]
        [MaxLength(100)]
        [StringLength(100)]
        [DataType(DataType.Password)]
        [Display(Name = "Job board password")]
        public string JobBoardPassword { get; set; } // JobBoardPassword (length: 100)

        [Column(@"JobBoardURL", Order = 6, TypeName = "varchar")]
        [Required]
        [MaxLength(200)]
        [StringLength(200)]
        [Display(Name = "Job board url")]
        public string JobBoardUrl { get; set; } // JobBoardURL (length: 200)

        [Column(@"UpdatedBy", Order = 7, TypeName = "int")]
        [Required]
        [Display(Name = "Updated by")]
        public int UpdatedBy { get; set; } // UpdatedBy

        [Column(@"CreatedBy", Order = 8, TypeName = "int")]
        [Required]
        [Display(Name = "Created by")]
        public int CreatedBy { get; set; } // CreatedBy

        [Column(@"DateAdded", Order = 9, TypeName = "datetime")]
        [Required]
        [Display(Name = "Date added")]
        public System.DateTime DateAdded { get; set; } // DateAdded

        [Column(@"DateUpdated", Order = 10, TypeName = "datetime")]
        [Required]
        [Display(Name = "Date updated")]
        public System.DateTime DateUpdated { get; set; } // DateUpdated

        // Foreign keys
        [ForeignKey("JobBoardId")] public virtual JobBoard JobBoard { get; set; } // FK_JobBoardCredential_JobBoard

        public JobBoardCredential()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
