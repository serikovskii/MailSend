using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DCA.Models
{
    public class Reciver : Entity
    {
        public string FullName { get; set; }
        public string Adress { get; set; }
        public ICollection<Mail> Mails { get; set; } = new List<Mail>();
    }
}