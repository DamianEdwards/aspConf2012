using System;
using System.Web;
using System.Web.ModelBinding;

namespace AdvancedWebForms.ModelBinding
{
    public class RequestAttribute : ValueProviderSourceAttribute
    {
        public override IValueProvider GetValueProvider(ModelBindingExecutionContext modelBindingExecutionContext)
        {
            return new RequestValueProvider(modelBindingExecutionContext);
        }
    }
}