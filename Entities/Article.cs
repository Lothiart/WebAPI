using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Article
    {

        public int Id { get; set; }
        [Required]
        public string Contenu { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }




    }
}
