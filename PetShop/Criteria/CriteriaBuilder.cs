using System;
using Training.DomainClasses;

namespace Training.Spec
{
    public class CriteriaBuilder<TItem, TProperty>
    {
        public readonly Func<TItem, TProperty> _propertySelector;
        private bool _negateCriteria;

        public CriteriaBuilder(Func<TItem, TProperty> propertySelector)
        {
            _propertySelector = propertySelector;
        }
        public CriteriaBuilder<TItem, TProperty> Not()
        {
            _negateCriteria = !_negateCriteria;
            return this;
        }
        public Criteria<TItem> ApplyModifications(Criteria<TItem> criteriaBeforeModifications)
        {
            var result = criteriaBeforeModifications;
            if (_negateCriteria)
                result = new Negate<TItem>(criteriaBeforeModifications);

            return result;
        }
    }
}