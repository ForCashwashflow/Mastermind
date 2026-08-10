
using Mastermind.Mastermind.Api.DTOs;
using Mastermind.Mastermind.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mastermind.Mastermind.Api.Controllers
{
    [ApiController]
    [Route("api/jeu")]
    public class JeuController : ControllerBase
    {
        private readonly MastermindService _service;

        public JeuController(MastermindService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<ReponseCreationPartie> CreerPartie()
        {
            var partie = _service.CreerPartie();

            var reponse = new ReponseCreationPartie
            {
                Id = partie.Id
            };

            return Ok(reponse);
        }

        [HttpPost("{id}/tentative")]
        public ActionResult<ReponseTentative> Jouer(
          Guid id,
          RequeteTentative requete)
        {
            try
            {
                var tentative = _service.Jouer(id, requete.Proposition);
                var partie = _service.ObtenirPartie(id)!;

                return Ok(new ReponseTentative
                {
                    BienPlaces = tentative.BienPlaces,
                    MalPlaces = tentative.MalPlaces,
                    TentativesRestantes = partie.TentativesRestantes,
                    Etat = partie.Etat.ToString()
                });
            }
            catch (KeyNotFoundException exception)
            {
                return NotFound(new { message = exception.Message });
            }
            catch (ArgumentException exception)
            {
                return BadRequest(new { message = exception.Message });
            }
            catch (InvalidOperationException exception)
            {
                return Conflict(new { message = exception.Message });
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ReponsePartie> ObtenirPartie(Guid id)
        {
            var partie = _service.ObtenirPartie(id);

            if (partie is null)
            {
                return NotFound(new
                {
                    message = "La partie demandée n'existe pas."
                });
            }

            return Ok(new ReponsePartie
            {
                Id = partie.Id,
                TentativesRestantes = partie.TentativesRestantes,
                Etat = partie.Etat.ToString(),
                Tentatives = partie.Tentatives.Select(tentative => new TentativeHistorique
                {
                    Proposition = tentative.Proposition,
                    BienPlaces = tentative.BienPlaces,
                    MalPlaces = tentative.MalPlaces
                }).ToList()
            });
        }
    }
}