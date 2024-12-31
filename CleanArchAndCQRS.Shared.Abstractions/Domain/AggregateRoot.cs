namespace CleanArchAndCQRS.Shared.Abstractions.Domain
{
    public abstract class AggregateRoot<T>
    {
        public T Id { get; private set; }
        public int Version { get; private set; }
        public IEnumerable<IDomainEvent> Events => _events;

        private bool _versionIncremented;
        private readonly List<IDomainEvent> _events = new();


        protected void AddEvent(IDomainEvent @event)
        {
            if(!_events.Any() && !_versionIncremented)
            {
                Version++;
                _versionIncremented = true;
            }

            _events.Add(@event);
        }

        public void ClearEvents() => _events.Clear();

        protected void IncrementVersion()
        {
            if (_versionIncremented) return;

            Version++;
            _versionIncremented = true;
        }
    }
}
