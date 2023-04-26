using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(50, MinimumLength =2)]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [StringLength(50,MinimumLength =2, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string FirstName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        [Display(Name ="Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name ="Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
