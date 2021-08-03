using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemasWeb.Models
{
    public class DataPaginador<T>
    {
        public List<T> List { get; set; }
        public string PagiInfo { get; set; }
        public string PagiNavegation { get; set; }
        public T Entity { get; set; }
        public int Records { get; set; }
        public string Search { get; set; }

        public string ErrorMessage { get; set; }
    }
}
