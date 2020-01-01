using System;
using System.Collections.Generic;
using Training.Spec;

public static class CriteriaBuilderExtensions
{
    public static Criteria<TItem> equalTo<TItem, TProperty>(this CriteriaBuilder<TItem, TProperty> criteriaBuilder, TProperty value)
    {
        var criteria = new AnonymousCriteria<TItem>(item => criteriaBuilder._propertySelector(item).Equals(value));
        return criteriaBuilder.ApplyModifications(criteria);
    }

    public static Criteria<TItem> equalToAny<TItem, TProperty>(this CriteriaBuilder<TItem, TProperty> criteriaBuilder, params TProperty[] values)
    {
        var allowedValues = new List<TProperty>(values);
        var criteria = new AnonymousCriteria<TItem>(item => allowedValues.Contains(criteriaBuilder._propertySelector(item)));
        return criteriaBuilder.ApplyModifications(criteria);
    }

    public static Criteria<TItem> greaterThan<TItem, TProperty>(this CriteriaBuilder<TItem, TProperty> criteriaBuilder, TProperty value) 
                where TProperty: IComparable<TProperty>
    {
        var criteria = new AnonymousCriteria<TItem>(item => value.CompareTo(criteriaBuilder._propertySelector(item))< 0);
        return criteriaBuilder.ApplyModifications(criteria);
    }
}