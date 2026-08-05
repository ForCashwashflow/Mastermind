using Mastermind.Models;

namespace Mastermind.Services
{
    public class MastermindService
    {
        private readonly Dictionary<Guid, Partie> _parties = new();

        public Partie CreerPartie()
        {
            var partie = new Partie
            {
                CodeSecret = GenererCodeSecret()
            };

            _parties.Add(partie.Id, partie);

            return partie;
        }

        public Partie? ObtenirPartie(Guid id)
        {
            _parties.TryGetValue(id, out var partie);

            return partie;
        }

        private List<int> GenererCodeSecret()
        {
            var nombres = new List<int>();

            for (var i = 0; i < 4; i++)
            {
                nombres.Add(Random.Shared.Next(1, 7));
            }

            return nombres;
        }

        private bool PropositionValide(List<int> proposition)
        {
            return proposition.Count == 4
                && proposition.All(chiffre => chiffre >= 1 && chiffre <= 6);
        }

        private Tentative CalculerResultat(
            List<int> codeSecret,
            List<int> proposition)
        {
            var bienPlaces = 0;
            var malPlaces = 0;

            var secretUtilise = new bool[4];
            var propositionUtilisee = new bool[4];

            // Première étape : compter les chiffres bien placés
            for (var i = 0; i < 4; i++)
            {
                if (codeSecret[i] == proposition[i])
                {
                    bienPlaces++;
                    secretUtilise[i] = true;
                    propositionUtilisee[i] = true;
                }
            }

            // Deuxième étape : compter les chiffres mal placés
            for (var i = 0; i < 4; i++)
            {
                if (propositionUtilisee[i])
                {
                    continue;
                }

                for (var j = 0; j < 4; j++)
                {
                    if (secretUtilise[j])
                    {
                        continue;
                    }

                    if (proposition[i] == codeSecret[j])
                    {
                        malPlaces++;
                        propositionUtilisee[i] = true;
                        secretUtilise[j] = true;
                        break;
                    }
                }
            }

            return new Tentative
            {
                Proposition = new List<int>(proposition),
                BienPlaces = bienPlaces,
                MalPlaces = malPlaces
            };
        }

        public Tentative Jouer(Guid idPartie, List<int> proposition)
        {
            var partie = ObtenirPartie(idPartie);

            if (partie is null)
            {
                throw new KeyNotFoundException(
                    "La partie demandée n'existe pas.");
            }

            if (partie.Etat != EtatJeu.EnCours)
            {
                throw new InvalidOperationException(
                    "Cette partie est déjà terminée.");
            }

            if (!PropositionValide(proposition))
            {
                throw new ArgumentException(
                    "La proposition doit contenir exactement 4 chiffres entre 1 et 6.");
            }

            var tentative = CalculerResultat(
                partie.CodeSecret,
                proposition);

            partie.Tentatives.Add(tentative);

            if (tentative.BienPlaces == 4)
            {
                partie.Etat = EtatJeu.Gagnee;
            }
            else if (partie.Tentatives.Count >= 10)
            {
                partie.Etat = EtatJeu.Perdue;
            }

            return tentative;
        }
    }
}