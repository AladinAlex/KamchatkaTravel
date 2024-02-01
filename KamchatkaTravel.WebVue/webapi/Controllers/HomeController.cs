using KamchatkaTravel.Application.Contracts.DTOs;
using KamchatkaTravel.Application.Contracts.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class HomeController : ControllerBase
{
    readonly ILogger<HomeController> _logger;
    readonly IConfiguration _config;    
    readonly ITourService _service;
    public HomeController(ILogger<HomeController> logger, ITourService tourService, IConfiguration config)
    {
        _logger = logger;
        _service = tourService;
        _config = config;
    }

    // TODO: Сделать кэширование туров, отзывов, вопросов.

    [HttpGet("Index")]
    public async Task<IActionResult> Index()
    {
        IndexDto result = await _service.Index(false);
        foreach (var r in result.Reviews)
        {
            if (!string.IsNullOrWhiteSpace(r.LogoImageUrl))
                r.LogoImageUrl = _config["ImageUrl"] + r.LogoImageUrl;
        }
        foreach (var r in result.Tours)
        {
            if (!string.IsNullOrWhiteSpace(r.LogoImageUrl))
                r.LogoImageUrl = _config["ImageUrl"] + r.LogoImageUrl;
        }

        return Ok(result);
    }
}
