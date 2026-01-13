using ApplicationTemplate.Domain.Entities;
using ApplicationTemplate.Shared;

namespace ApplicationTemplate.Domain.Services;

public class TemplateService : ITemplateService
{
    public async Task<TryResult<TemplateObject>> GetTemplateObject(Guid id)
    {
        // todo actually get this from some upstream bullshit. Need to setup both DB and upstream call
        var templateObject = new TemplateObject(id);
        
        return new TryResult<TemplateObject>(null, false);
    }
}