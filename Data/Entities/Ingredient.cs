using System;
using System.Collections.Generic;

namespace spoons.Data.Entities
{
    public partial class Ingredient
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? RecipeId { get; set; }
        public string Quantity { get; set; }
        public int? MeasurementId { get; set; }
        public string Ingredient1 { get; set; }

        public virtual Measurement Measurement { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual User User { get; set; }
    }
}
