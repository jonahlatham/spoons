using System;
using System.Collections.Generic;

namespace spoons.Data.Entities
{
    public partial class Recipe
    {
        public Recipe()
        {
            Ingredient = new HashSet<Ingredient>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; }
        public string Instruction { get; set; }
        public string Servings { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Ingredient> Ingredient { get; set; }
    }
}
