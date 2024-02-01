using KamchatkaTravel.Application.Contracts.DTOs;
using KamchatkaTravel.Application.Contracts.Interfaces;
using KamchatkaTravel.Application.Services;
using KamchatkaTravel.EntityFrameworkCore.Migrations;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class TourController : ControllerBase
{
    readonly ILogger<TourController> _logger;
    readonly IConfiguration _config;    
    readonly ITourService _service;
    public TourController(ILogger<TourController> logger, ITourService tourService, IConfiguration config)
    {
        _logger = logger;
        _service = tourService;
        _config = config;
    }

    // TODO: Сделать кэширование туров, отзывов, вопросов.

    /// <summary>
    /// Получение информации о туре по RouteName тура
    /// </summary>
    /// <param name="TourName">RouteName тура</param>
    /// <returns></returns>
    [HttpGet("Tour/{TourName}")]
    public async Task<IActionResult> GetTourByName(string TourName)
    {
        TourViewDto result = await _service.GetTourInfo(TourName, false);
        FillUrls(result);
        return Ok(result);
    }

    [HttpGet("GetTourById/{TourId}")]
    public async Task<IActionResult> GetTourById(Guid TourId)
    {
        TourViewDto result = await _service.GetTourInfo(TourId);
        FillUrls(result);
        return Ok(result);
    }

    private void FillUrls(TourViewDto result)
    {
        foreach (var r in result.Tour.Days)
        {
            if (!string.IsNullOrWhiteSpace(r.ImageUrl))
                r.ImageUrl = _config["ImageUrl"] + r.ImageUrl;
        }
        foreach (var r in result.Tour.Views)
        {
            if (!string.IsNullOrWhiteSpace(r.ImageUrl))
                r.ImageUrl = _config["ImageUrl"] + r.ImageUrl;
        }
        result.Tour.Images = result.Tour.Images.OrderBy(x => x.Ord).Take(8);
        foreach (var r in result.Tour.Images)
        {
            if (!string.IsNullOrWhiteSpace(r.ImageUrl))
                r.ImageUrl = _config["ImageUrl"] + r.ImageUrl;
        }
        if (!string.IsNullOrWhiteSpace(result.Tour.LogoImageUrl))
            result.Tour.LogoImageUrl = _config["ImageUrl"] + result.Tour.LogoImageUrl;
        if (!string.IsNullOrWhiteSpace(result.Tour.DescriptionImageUrl))
            result.Tour.DescriptionImageUrl = _config["ImageUrl"] + result.Tour.DescriptionImageUrl;
    }
}
