namespace Training.DomainClasses
{
    public class Negate<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _criteria2Negate;

        public Negate(Criteria<TItem> criteria2negate)
        {
            _criteria2Negate = criteria2negate;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return !_criteria2Negate.IsSatisfiedBy(item);
        }
    }
}