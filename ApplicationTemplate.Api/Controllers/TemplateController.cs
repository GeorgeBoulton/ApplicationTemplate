using ApplicationTemplate.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationTemplate.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TemplateController(ITemplateService templateService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetTemplateObject(Guid id)
    {
        var response = await templateService.GetTemplateObject(id);

        // todo maybe we should have an enum that says what type of error it is. cause bad request might be null still
        if (!response.Success)
        {
            if (response.Result is null)
            {
                return NotFound(response.ErrorMessage);
            }
            
            return BadRequest(response.ErrorMessage);
        }
            
        // todo Needs mapper
        return Ok(response.Result);
    }
}