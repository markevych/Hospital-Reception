using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalReception
{
    public class Conclusion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Complaints { get; set; }
        public string Analyzes { get; set; }
        public string Recipe { get; set; }
        public string Conclusion_str { get; set; }
    }
}
