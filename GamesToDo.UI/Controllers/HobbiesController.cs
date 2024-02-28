using Microsoft.AspNetCore.Mvc;
using RepositoryContracts;
using ServiceContracts;
using ServiceContracts.DTO;

namespace HobbyToFinishApp.Controllers
{
    public class HobbiesController : Controller
    {
        private readonly IAddGamesService _addGamesService;
        private readonly IGetGamesService _getGamesService;
        private readonly IUpdateGamesService _updateGamesService;
        private readonly IDeleteGamesService _deleteGamesService;

        private readonly ILogger<HobbiesController> _logger;

        public HobbiesController(IAddGamesService addGamesService, IGetGamesService getGamesService, IUpdateGamesService updateGameService, IDeleteGamesService deleteGamesService, ILogger<HobbiesController> logger)
        {
            _addGamesService = addGamesService;
            _getGamesService = getGamesService;
            _updateGamesService = updateGameService;
            _deleteGamesService = deleteGamesService;
            _logger = logger; 
        }
        [Route("hobbies/index")]
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Index action method of the hobbies controller has been reached");
            List<GameResponse> games = await _getGamesService.GetAllGames();

            return View(games);
        }
        [HttpGet]
        [Route("[action]/{gameID}")]
        public async Task<IActionResult> Update(Guid gameID)
        {
            GameResponse gameResponse = await _getGamesService.GetGameByGameId(gameID);
            if (gameResponse == null) return RedirectToAction("Index");
            GameUpdateRequest gameUpdateRequest = gameResponse.ToGameUpdateRequest();
            return View(gameUpdateRequest);
        }

        [HttpPost]
        [Route("[action]/{gameID}")]
        public async Task<IActionResult> Update(GameUpdateRequest gameUpdateRequest)
        {
            GameResponse gameResponse = await _getGamesService.GetGameByGameId(gameUpdateRequest.GameID);
            if (gameResponse == null) return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                GameResponse updatedGame = await _updateGamesService.UpdateGame(gameUpdateRequest);
                return RedirectToAction("Index");
            }
            return View(gameResponse.ToGameUpdateRequest());
        }

        [HttpGet]
        [Route("/[action]/{gameID}")]
        public async Task<IActionResult> Delete(Guid gameID)
        {
            GameResponse gameResponse = await _getGamesService.GetGameByGameId(gameID);
            GameUpdateRequest gameRequestToDelete = gameResponse.ToGameUpdateRequest();
            await _deleteGamesService.DeleteGame(gameRequestToDelete);
            return RedirectToAction("Index");
        }
    }
}
