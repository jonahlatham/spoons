using System;
using System.Collections.Generic;

namespace spoons.Data.Entities
{
    public partial class User
    {
        public User()
        {
            Ingredient = new HashSet<Ingredient>();
            Recipe = new HashSet<Recipe>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Ingredient> Ingredient { get; set; }
        public virtual ICollection<Recipe> Recipe { get; set; }
    }
}
