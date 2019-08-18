using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountOwnerServer.Controllers
{
    [Route("api/owner")]
    public class OwnerController : Controller
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public OwnerController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllOwners()
        {
            try
            {
                var owners = _repository.Owner.GetAllOwners();

                _logger.LogInfo($"returned all owners from database");

                return Ok(owners);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        public IActionResult GetOwnerById(Guid id)
        {
            try
            {
                var owner = _repository.Owner.GetOwnerById(id);

                if(owner == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with id: {id}");
                    return Ok(owner);
                }
            }
              catch(Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}/account")]
        public IActionResult GetOwnerWithDetails(Guid id)
        {
            try
            {
                var owner = _repository.Owner.GetOwnerWithDetails(id);

                if (owner.OwnerID.Equals(Guid.Empty))
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found");
                    return NotFound();
                }

                else
                {
                    _logger.LogInfo($"Returned owner with details for id: {id}");
                    return Ok(owner);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong insude GetOwnerWithDetails");
                return StatusCode(500, "Internal server error");
            }
        }
        
    }
}
