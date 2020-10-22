using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyCRUD.Models
{
    [Table("Branch_tbl")]
    public class Branch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Branch Number")]
        public String BranchNo { get; set; }


        public String Street { get; set; }

        public String City { get; set; }

        public String PostCode { get; set; }

        public List<Rent> rent { get; set; }
        public List<Staff> staff { get; set; }
    }
}