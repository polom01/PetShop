using System;

namespace Training.Spec
{
    public class Where<TItem>
    {
        public static CriteriaBuilder<TItem, TProperty> has_An<TProperty>(Func<TItem, TProperty> propertySelector) 
        {
            return new CriteriaBuilder<TItem, TProperty>(propertySelector);
        }
    }
}