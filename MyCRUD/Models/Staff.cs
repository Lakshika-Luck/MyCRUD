using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyCRUD.Models
{
    [Table("Staff_tbl")]
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Staff Number")]
        public String StaffNo { get; set; }


        [Display(Name ="First Name")]
        public String Fname { get; set; }


        [Display(Name = "Last Name")]
        public String Lname { get; set; }


        public String Position { get; set; }


        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        public int Salary { get; set; }

        
        [ForeignKey("branch")]
        public String BranchNoRef { get; set; }
        public virtual Branch branch { get; set; }

        public List<Rent> rent { get; set; }
    }
}