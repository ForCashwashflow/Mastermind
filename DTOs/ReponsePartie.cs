namespace Mastermind.DTOs
{
    public class ReponsePartie
    {
        public Guid Id { get; set; }

        public List<TentativeHistorique> Tentatives { get; set; } = new();

        public int TentativesRestantes { get; set; }

        public string Etat { get; set; } = string.Empty;
    }
}