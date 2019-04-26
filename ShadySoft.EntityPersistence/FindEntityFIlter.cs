using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace ShadySoft.EntityPersistence
{
    public class FindEntityFilter<TEntity> : IAsyncActionFilter where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public FindEntityFilter(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext actionContext, ActionExecutionDelegate next)
        {
            if (actionContext.ActionArguments.ContainsKey("id"))
            {
                var entity = await _repository.GetAsync((int)actionContext.ActionArguments["id"]);
                if (entity is null)
                {
                    actionContext.Result = new NotFoundResult();
                    return;
                }

                actionContext.HttpContext.Items.Add("shadyEntity", entity);
            }

            await next();
        }
    }
}