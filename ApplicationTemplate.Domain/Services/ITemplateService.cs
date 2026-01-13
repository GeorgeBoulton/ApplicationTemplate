using ApplicationTemplate.Domain.Entities;
using ApplicationTemplate.Shared;

namespace ApplicationTemplate.Domain.Services;

public interface ITemplateService
{
    Task<TryResult<TemplateObject>> GetTemplateObject(Guid id);
}