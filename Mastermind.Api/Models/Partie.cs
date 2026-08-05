namespace Mastermind.Mastermind.Api.Models
{
    public class Partie
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public List<int> CodeSecret { get; set; } = new();

        public List<Tentative> Tentatives { get; set; } = new();

        public EtatJeu Etat { get; set; } = EtatJeu.EnCours;

        public DateTime DateCreation { get; set; } = DateTime.UtcNow;

        public int TentativesRestantes => 10 - Tentatives.Count;
    }
}