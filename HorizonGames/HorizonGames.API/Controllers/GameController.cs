using Microsoft.AspNetCore.Mvc;
using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HorizonGames.API.Data;
using HorizonGames.API.Models;
using HorizonGames.API.Models.DTOS;

namespace HorizonGames.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly GameDbContext _gameDbContext;
        private readonly IMapper _mapper;
        private readonly APIResponse _response;
        public GameController(GameDbContext gameDbContext, IMapper mapper)
        {
            _gameDbContext = gameDbContext;
            _mapper = mapper;
            _response = new();
        }
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetGames()
        {
            try
            {
                List<Game> games = await _gameDbContext.Games.ToListAsync();
                if (games.Count == 0)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.Message = "Games Not Found";
                    _response.IsSuccess = false;
                    _response.Result = null;
                    return _response;
                }


                List<GamesDTO> result = _mapper.Map<List<GamesDTO>>(games);
                if (result == null)
                {
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.Message = "Games Not found";
                    _response.IsSuccess = false;
                    _response.Result = null;
                    return _response;
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = result;

            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<APIResponse>> GetGame(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.Message = "Incorrect Data Passed";
                    _response.Result = null;
                    return _response;
                }
                Game game = await _gameDbContext.Games.FirstOrDefaultAsync(x => x.Id == id);

                if (game == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.Message = "Incorrect Data Passed";
                    _response.Result = null;
                    return _response;
                }
                GamesDTO result = _mapper.Map<GamesDTO>(game);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = result;
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.Message = ex.Message;
                _response.IsSuccess = false;
            }
            return _response;
        }
    }
}
