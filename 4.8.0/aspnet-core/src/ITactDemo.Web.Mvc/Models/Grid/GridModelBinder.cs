using ITactDemo.Grid;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Threading.Tasks;

namespace ITactDemo.Model.Grid
{
    public class GridModelBinderProvider : IModelBinderProvider
    {
        private readonly IModelBinder binder =
            new GridModelBinder();

        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType == typeof(GridSettings) ? binder : null;
        }
    }

    public class GridModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            try
            {
                var request = bindingContext.HttpContext.Request;

                GridSettings gridsettings = new GridSettings
                {
                    IsSearch = bool.Parse(string.IsNullOrEmpty(request.Query["_search"].ToString()) ? "false" : "true"),
                    PageIndex = int.Parse(string.IsNullOrEmpty(request.Query["page"].ToString()) ? "0" : request.Query["page"].ToString()),
                    PageSize = int.Parse(string.IsNullOrEmpty(request.Query["rows"].ToString()) ? "10" : request.Query["rows"].ToString()),
                    SortColumn = !string.IsNullOrEmpty(request.Query["sidx"].ToString()) ? (request.Query["sidx"].ToString().IndexOf(' ') > 0 ? request.Query["sidx"].ToString().Substring(0, request.Query["sidx"].ToString().IndexOf(' ')) : request.Query["sidx"].ToString()) : "", //when grouping then get substring sidx value
                    SortOrder = string.IsNullOrEmpty(request.Query["sord"].ToString()) ? "asc" : request.Query["sord"].ToString(),
                    Where = Filter.Create(string.IsNullOrEmpty(request.Query["filters"].ToString()) ? "" : request.Query["filters"].ToString())
                };

                bindingContext.Result = ModelBindingResult.Success(gridsettings);
            }
            catch (Exception)
            {
                return null;
            }

            return Task.CompletedTask;

        }
    }
}