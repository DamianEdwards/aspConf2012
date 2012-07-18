using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace AdvancedWebForms.ModelBinding
{
    public class RequestValueProvider : IValueProvider, IUnvalidatedValueProvider
    {
        private readonly List<IUnvalidatedValueProvider> _valueProviders = new List<IUnvalidatedValueProvider>();

        public RequestValueProvider(ModelBindingExecutionContext modelBindingExecutionContext)
        {
            _valueProviders.Add(new QueryStringValueProvider(modelBindingExecutionContext));
            _valueProviders.Add(new CookieValueProvider(modelBindingExecutionContext));
            _valueProviders.Add(new FormValueProvider(modelBindingExecutionContext));
        }

        public bool ContainsPrefix(string prefix)
        {
            return _valueProviders.Any(vp => vp.ContainsPrefix(prefix));
        }

        public ValueProviderResult GetValue(string key)
        {
            return GetValue(key, false);
        }

        public ValueProviderResult GetValue(string key, bool skipValidation)
        {
            return _valueProviders.Select(vp => vp.GetValue(key, skipValidation))
                .FirstOrDefault();
        }
    }
}