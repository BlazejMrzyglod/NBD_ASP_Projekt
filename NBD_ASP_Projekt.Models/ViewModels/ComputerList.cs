using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBD_ASP_Projekt.Models.Models;

namespace NBD_ASP_Projekt.Models.ViewModels
{
    public class ComputerList
    {
        public IEnumerable<Computers> Computers { get; set; }
        public ComputerFilter Filter { get; set; }
    }
}
