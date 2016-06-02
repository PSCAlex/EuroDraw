using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroDraw.Models
{
    public class DrawViewModel
    {
        public IEnumerable<int> people { get; set; }
        public IEnumerable<int> countries { get; set; }
        public string timeStamp { get; set; }
    }
}
