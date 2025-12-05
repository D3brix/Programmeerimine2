namespace KooliProjekt.Application.Data.Models
{
    // Base class for entities stored in ApplicationDbContext
    public abstract class Entity
    {
        public int Id { get; set; }
    }
}
