using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MultiRobot_Cooperation_API.Models
{
    public class Robot
    {
        [Key]
        [DisplayName("Robot Id")]
        public int IdRobot { get; set; }

        [Required(ErrorMessage = "Please enter The Robot's name")]
        [Column(TypeName ="nvarchar(50)")]
        [DisplayName("Robot Name")]
        [StringLength(50)]
        public string NameRobot { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Robot Type")]
        public string TypeRobot { get; set; }
        [RegularExpression(@"waiting|running|broken|sleeping")]
        [Column(TypeName = "nvarchar(10)")]
        [DisplayName("Robot Status")]
        public string StatusRobot { get; set; }

       /* [Required(ErrorMessage = "Please choose profile image for the robot")]
        [Display(Name = "Profile Picture")]
        public IFormFile ProfileImage { get; set; }
        */
    }
    
}
