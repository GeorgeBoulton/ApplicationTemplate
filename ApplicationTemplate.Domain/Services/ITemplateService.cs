using ApplicationTemplate.Domain.Entities;
using ApplicationTemplate.Shared;
using ApplicationTemplate.Shared.Models;

namespace ApplicationTemplate.Domain.Services;

public interface ITemplateService
{
    Task<TryResult<TemplateObject>> GetTemplateObject(Guid id);
}