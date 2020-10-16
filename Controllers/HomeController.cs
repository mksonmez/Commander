using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public HomeController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
            // Status 200 Ok
        }

        public ActionResult<IEnumerable<CommandReadDto>> Index()
        {
            ViewBag.Message = "List of Commands";

            var commandItems = _repository.GetAllCommands();

            return View(commandItems);
        }
    }
}
