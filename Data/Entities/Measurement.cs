using System;
using System.Collections.Generic;

namespace spoons.Data.Entities
{
    public partial class Measurement
    {
        public Measurement()
        {
            Ingredient = new HashSet<Ingredient>();
        }

        public int Id { get; set; }
        public string Measurments { get; set; }

        public virtual ICollection<Ingredient> Ingredient { get; set; }
    }
}
