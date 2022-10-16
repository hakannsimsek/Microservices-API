using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SecondService.Data;
using SecondService.Dtos;
using System;
using System.Collections.Generic;

namespace SecondService.Controllers
{
    [ApiController]
    [Route("api/c/[Controller]")]
    public class FirstServiceController : ControllerBase
    {
        private readonly ISecondRepo _repository;
        private readonly IMapper _mapper;

        public FirstServiceController(ISecondRepo repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FirstReadDto>> GetFirsts()
        {
            Console.WriteLine("--Getting firsts items from second service");

            var firstItems = _repository.GetAllFirsts();
            return Ok(_mapper.Map<IEnumerable<FirstReadDto>>(firstItems));
        }

        [HttpPost]
        public ActionResult TestIncomingConnnection()
        {
            Console.WriteLine("-- Incoming POST # Second service");
            return Ok("Incoming test Ok from second service controller");
        }
    }
}
