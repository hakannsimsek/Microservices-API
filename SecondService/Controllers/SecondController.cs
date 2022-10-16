using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SecondService.Data;
using SecondService.Dtos;
using SecondService.Models;
using System;
using System.Collections.Generic;

namespace SecondService.Controllers
{
    [ApiController]
    [Route("api/c/first/{firstId}/[Controller]")]
    public class SecondController : ControllerBase
    {
        private readonly ISecondRepo _repository;
        private readonly IMapper _mapper;

        public SecondController(ISecondRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<SecondReadDto>> GetSecondsForFirst(int firstId)
        {
            Console.WriteLine($"-- Hit GetSecondsForFirst: {firstId}");

            if (!_repository.FirstExist(firstId))
            {
                return NotFound();
            }

            var seconds = _repository.GetSecondsForPlatform(firstId);
            return Ok(_mapper.Map<IEnumerable<SecondReadDto>>(seconds));
        }

        [HttpGet("{secondId}")]
        public ActionResult<SecondReadDto> GetSecondForFirst(int firstId, int secondId)
        {
            Console.WriteLine($"-- Hit GetSecondForFirst: {firstId} / {secondId}");

            if (!_repository.FirstExist(firstId))
            {
                return NotFound();
            }

            var second = _repository.GetSecond(firstId, secondId);

            if (second == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SecondReadDto>(second));
        }

        [HttpPost]
        public ActionResult<SecondReadDto> CreateSecondForFirst(int firstId, SecondCreateDto secondDto)
        {
            Console.WriteLine($"-- Hit CreateSecondForFirst: {firstId}");

            if (!_repository.FirstExist(firstId))
            {
                return NotFound();
            }

            var second = _mapper.Map<Second>(secondDto);

            _repository.CreateSecond(firstId, second);
            _repository.SaveChanges();

            var secondReadDto = _mapper.Map<SecondReadDto>(second);

            return Ok(secondReadDto);
        }

    }

}
