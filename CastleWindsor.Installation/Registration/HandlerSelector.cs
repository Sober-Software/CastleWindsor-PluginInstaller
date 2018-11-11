using System;
using System.Linq;
using Castle.MicroKernel;
using CastleWindsor.Installation.Licensing;

namespace CastleWindsor.Installation.Registration
{
    public class HandlerSelector<TImplementation, TService> : IHandlerSelector
        where TImplementation : TService where TService : class
    {
        private readonly string apiKey;

        private readonly ISelectionCriterion[] selectionCriteria;

        public HandlerSelector(string apiKey, ISelectionCriterion[] selectionCriteria)
        {
            this.apiKey = apiKey;
            this.selectionCriteria = selectionCriteria;
        }

        public bool HasOpinionAbout(string key, Type service)
        {
            return apiKey == ContextUtilities.ContextValidationString && service == typeof(TService) &&
                   SelectionCriteriaAreTrue();
        }

        public IHandler SelectHandler(string key, Type service, IHandler[] handlers)
        {
            return handlers.First(h => h.ComponentModel.Implementation == typeof(TImplementation));
        }

        private bool SelectionCriteriaAreTrue()
        {
            return selectionCriteria.Length == 0 || selectionCriteria.Any(x => x.IsTrue());
        }
    }
}