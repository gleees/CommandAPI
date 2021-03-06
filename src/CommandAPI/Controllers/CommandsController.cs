

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Data;
using CommandAPI.Models;
namespace CommandAPI.Controllers
{
    //Route [controller] is name of controller: Commands[Controller]
    //alternativly you can hardcode [controller] to commands
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {

        private readonly ICommandAPIRepo _repository;
        public CommandsController(ICommandAPIRepo repository)
        {
            _repository = repository;
        }
        /*        [HttpGet]
                public ActionResult<IEnumerable<string>> Get()
                {
                    return new string[] { "this", "is", "hard", "coded" };
                }*/


    
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(commandItems);
        }

        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
        var commandItem = _repository.GetCommandById(id);
        if (commandItem == null)
        {
        return NotFound();
        }
        return Ok(commandItem);
        }
    }
}