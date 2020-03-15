using System;
using System.Collections.Generic;

namespace DataGridControl.Data.Models
{
    public partial class Questions
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public virtual Answers Answers { get; set; }
    }
}
