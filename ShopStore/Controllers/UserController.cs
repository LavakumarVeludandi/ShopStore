using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopStore.Dto;
using ShopStore.Models;
using ShopStore.Repository.Contracts;
using ShopStore.Util;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopStore.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserController(ILogger<UserController> logger,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _logger = logger;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpGet("{userId}")]
    [ProducesResponseType(200, Type = typeof(User))]
    [ProducesResponseType(400)]
    public IActionResult GetUser(int userId)
    {
        if (!_userRepository.UserExists(userId))
            return NotFound();

        var user = _mapper.Map<UserDto>(_userRepository.GetUser(userId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(user);
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
    public IActionResult GetAllUsers()
    { 
        var users = _mapper.Map<List<UserDto>>(_userRepository.GetAll());

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(users);
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateUser([FromQuery] UserDto user, [FromQuery] string password) //Can use [FromBody] which makes us to edit content in JSON 
    {
        if (user == null || password == null)
            return BadRequest(ModelState);

        if (_userRepository.CheckUser(user.Email))
        {
            ModelState.AddModelError("", "Email already exists");
            return StatusCode(422, ModelState);
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var _user = _mapper.Map<User>(user);
        _user.PasswordHash = CryptoUtil.HashString(password);

        if (!_userRepository.AddUser(_user))
        {
            ModelState.AddModelError("", "Something went wrong while saving");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully added a new user");
    }

}

