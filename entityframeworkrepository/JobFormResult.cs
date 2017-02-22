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

    // JobFormResult
    [Table("JobFormResult", Schema = "dbo")]
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.27.0.0")]
    public partial class JobFormResult: BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"JobFormResultID", Order = 1, TypeName = "int")]
        [Index(@"PK_JobFormResult", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Job form result ID")]
        public int JobFormResultId { get; set; } // JobFormResultID (Primary key)

        [Column(@"JobFormID", Order = 2, TypeName = "int")]
        [Display(Name = "Job form ID")]
        public int? JobFormId { get; set; } // JobFormID

        [Column(@"CandidateID", Order = 3, TypeName = "int")]
        [Display(Name = "Candidate ID")]
        public int? CandidateId { get; set; } // CandidateID

        [Column(@"FirstName", Order = 4, TypeName = "varchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "First name")]
        public string FirstName { get; set; } // FirstName (length: 50)

        [Column(@"LastName", Order = 5, TypeName = "varchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Last name")]
        public string LastName { get; set; } // LastName (length: 50)

        [Column(@"Email", Order = 6, TypeName = "varchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } // Email (length: 50)

        [Column(@"Headline", Order = 7, TypeName = "varchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Headline")]
        public string Headline { get; set; } // Headline (length: 50)

        [Column(@"Telephone", Order = 8, TypeName = "varchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Phone]
        [Display(Name = "Telephone")]
        public string Telephone { get; set; } // Telephone (length: 50)

        [Column(@"Address", Order = 9, TypeName = "varchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Address")]
        public string Address { get; set; } // Address (length: 50)

        [Column(@"Photo", Order = 10, TypeName = "varchar")]
        [MaxLength(100)]
        [StringLength(100)]
        [Display(Name = "Photo")]
        public string Photo { get; set; } // Photo (length: 100)

        [Column(@"Video", Order = 11, TypeName = "varchar")]
        [MaxLength(100)]
        [StringLength(100)]
        [Display(Name = "Video")]
        public string Video { get; set; } // Video (length: 100)

        [Column(@"Summary", Order = 12, TypeName = "varchar")]
        [MaxLength(200)]
        [StringLength(200)]
        [Display(Name = "Summary")]
        public string Summary { get; set; } // Summary (length: 200)

        [Column(@"CVBankID", Order = 13, TypeName = "int")]
        [Display(Name = "Cvb ank ID")]
        public int? CvBankId { get; set; } // CVBankID

        [Column(@"Source", Order = 14, TypeName = "varchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Source")]
        public string Source { get; set; } // Source (length: 50)

        [Column(@"Referer", Order = 15, TypeName = "varchar")]
        [Required]
        [MaxLength(150)]
        [StringLength(150)]
        [Display(Name = "Referer")]
        public string Referer { get; set; } // Referer (length: 150)

        [Column(@"IsRead", Order = 16, TypeName = "int")]
        [Display(Name = "Is read")]
        public int? IsRead { get; set; } // IsRead

        [Column(@"IsDeleted", Order = 17, TypeName = "int")]
        [Display(Name = "Is deleted")]
        public int? IsDeleted { get; set; } // IsDeleted

        [Column(@"AdminBlock", Order = 18, TypeName = "int")]
        [Display(Name = "Admin block")]
        public int? AdminBlock { get; set; } // AdminBlock

        [Column(@"ISCoverLetterIncluded", Order = 19, TypeName = "int")]
        [Display(Name = "Isc over letter included")]
        public int? IsCoverLetterIncluded { get; set; } // ISCoverLetterIncluded

        [Column(@"QuestionAnswerXML", Order = 20, TypeName = "varchar(max)")]
        [Display(Name = "Question answer xml")]
        public string QuestionAnswerXml { get; set; } // QuestionAnswerXML

        [Column(@"UpdatedBy", Order = 21, TypeName = "int")]
        [Display(Name = "Updated by")]
        public int? UpdatedBy { get; set; } // UpdatedBy

        [Column(@"CreatedBy", Order = 22, TypeName = "int")]
        [Display(Name = "Created by")]
        public int? CreatedBy { get; set; } // CreatedBy

        [Column(@"DateAdded", Order = 23, TypeName = "datetime")]
        [Display(Name = "Date added")]
        public System.DateTime? DateAdded { get; set; } // DateAdded

        [Column(@"DateUpdated", Order = 24, TypeName = "datetime")]
        [Display(Name = "Date updated")]
        public System.DateTime? DateUpdated { get; set; } // DateUpdated

        public JobFormResult()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>