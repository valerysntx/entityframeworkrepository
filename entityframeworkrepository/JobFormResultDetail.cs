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
    [Table("JobFormResultDetail", Schema = "dbo")]
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.27.0.0")]
    public partial class JobFormResultDetail: BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"JobFormResultDetailID", Order = 1, TypeName = "int")]
        [Index(@"PK_JobFormResultDetail", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Job form result detail ID")]
        public int JobFormResultDetailId { get; set; } // JobFormResultDetailID (Primary key)

        [Column(@"JobFormResultID", Order = 2, TypeName = "int")]
        [Required]
        [Display(Name = "Job form result ID")]
        public int JobFormResultId { get; set; } // JobFormResultID

        [Column(@"CandidateID", Order = 3, TypeName = "int")]
        [Required]
        [Display(Name = "Candidate ID")]
        public int CandidateId { get; set; } // CandidateID

        [Column(@"SchoolName", Order = 4, TypeName = "varchar")]
        [Required]
        [MaxLength(100)]
        [StringLength(100)]
        [Display(Name = "School name")]
        public string SchoolName { get; set; } // SchoolName (length: 100)

        [Column(@"SchoolStart", Order = 5, TypeName = "int")]
        [Display(Name = "School start")]
        public int? SchoolStart { get; set; } // SchoolStart

        [Column(@"SchoolEnd", Order = 6, TypeName = "int")]
        [Display(Name = "School end")]
        public int? SchoolEnd { get; set; } // SchoolEnd

        [Column(@"SchoolFieldOfStudy", Order = 7, TypeName = "varchar")]
        [MaxLength(100)]
        [StringLength(100)]
        [Display(Name = "School field of study")]
        public string SchoolFieldOfStudy { get; set; } // SchoolFieldOfStudy (length: 100)

        [Column(@"SchoolDegree", Order = 8, TypeName = "varchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "School degree")]
        public string SchoolDegree { get; set; } // SchoolDegree (length: 50)

        [Column(@"Company", Order = 9, TypeName = "varchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Company")]
        public string Company { get; set; } // Company (length: 50)

        [Column(@"Industry", Order = 10, TypeName = "varchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Industry")]
        public string Industry { get; set; } // Industry (length: 50)

        [Column(@"JobTitle", Order = 11, TypeName = "varchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Job title")]
        public string JobTitle { get; set; } // JobTitle (length: 50)

        [Column(@"Summary", Order = 12, TypeName = "varchar")]
        [MaxLength(100)]
        [StringLength(100)]
        [Display(Name = "Summary")]
        public string Summary { get; set; } // Summary (length: 100)

        [Column(@"IsCurrentWork", Order = 13, TypeName = "bit")]
        [Display(Name = "Is current work")]
        public bool? IsCurrentWork { get; set; } // IsCurrentWork

        [Column(@"ExperienceStart", Order = 14, TypeName = "int")]
        [Display(Name = "Experience start")]
        public int? ExperienceStart { get; set; } // ExperienceStart

        [Column(@"ExperienceEnd", Order = 15, TypeName = "int")]
        [Display(Name = "Experience end")]
        public int? ExperienceEnd { get; set; } // ExperienceEnd

        [Column(@"UpdatedBy", Order = 16, TypeName = "int")]
        [Required]
        [Display(Name = "Updated by")]
        public int UpdatedBy { get; set; } // UpdatedBy

        [Column(@"CreatedBy", Order = 17, TypeName = "int")]
        [Required]
        [Display(Name = "Created by")]
        public int CreatedBy { get; set; } // CreatedBy

        [Column(@"DateAdded", Order = 18, TypeName = "datetime")]
        [Required]
        [Display(Name = "Date added")]
        public System.DateTime DateAdded { get; set; } // DateAdded

        [Column(@"DateUpdated", Order = 19, TypeName = "datetime")]
        [Required]
        [Display(Name = "Date updated")]
        public System.DateTime DateUpdated { get; set; } // DateUpdated

        public JobFormResultDetail()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
