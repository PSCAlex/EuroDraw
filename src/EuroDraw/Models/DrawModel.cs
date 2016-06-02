using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroDraw.Models
{
    public class DrawModel
    {
        public int id { get; set; }
        public string people { get; set; }
        public string countries { get; set; }
        public DateTime timeStamp { get; set; }
    }
}
