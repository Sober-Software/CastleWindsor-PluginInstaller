using System;
using System.Linq;
using Castle.MicroKernel;

namespace SoberSoftware.CastleWindsor.Installation.Registration
{
    public class HandlerSelector<TImplementation, TService> : IHandlerSelector
        where TImplementation : TService where TService : class
    {
        private readonly ISelectionCriterion[] selectionCriteria;

        public HandlerSelector(ISelectionCriterion[] selectionCriteria)
        {
            this.selectionCriteria = selectionCriteria;
        }

        public bool HasOpinionAbout(string key, Type service)
        {
            return service == typeof(TService) &&
                   SelectionCriteriaAreTrue();
        }

        public IHandler SelectHandler(string key, Type service, IHandler[] handlers)
        {
            return handlers.First(h => h.ComponentModel.Implementation == typeof(TImplementation));
        }

        private bool SelectionCriteriaAreTrue()
        {
            return selectionCriteria.Length > 0 && selectionCriteria.All(x => x.IsTrue());
        }
    }
}