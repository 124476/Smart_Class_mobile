using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Models
{
    public class Subsection
    {
        [Key]
        public int Id { get; set; }
        public string Name {  get; set; }
        public string Description {  get; set; }
        public virtual Topic Topic { get; set; }
        public int Topic_Id { get; set; }
    }
}
