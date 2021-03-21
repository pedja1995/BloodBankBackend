using System;
using System.Collections.Generic;

namespace BackendAPI.Models
{
    public partial class VazeceDoze
    {
        public int DozaKrviId { get; set; }

        public virtual DozaKrvi DozaKrvi { get; set; }
    }
}
