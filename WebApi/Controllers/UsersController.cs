namespace WebApi.Controllers
{
    using DataAccess.Generic;
    using Entities.Domain;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IGenericRepository<User> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IGenericRepository<User> genericRepository, IUnitOfWork unitOfWork)
        {
            this._genericRepository = genericRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _genericRepository.GetAsync(a => a.UserID > 0, a => a.OrderByDescending(b => b.UserID));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var created = await _genericRepository.CreateAsync(user);

            if (created)
                _unitOfWork.Commit();

            return Created("Created", new { Response = StatusCode(201) });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var updated = await _genericRepository.CreateAsync(user);

            if (updated)
                _unitOfWork.Commit();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var deleted = _genericRepository.Delete(user);

            if (deleted)
                _unitOfWork.Commit();

            return Ok();
        }
    }
}