namespace BlogBackend.Domain.Common;

public abstract class BaseEntity : ICreatedByEntity, IModifiedByEntity
{
    protected BaseEntity()
    {
        Id = Guid.CreateVersion7();
    }

    public virtual Guid Id { get; set; }
    public virtual string? CreatedByUserId { get; set; }
    public virtual DateTimeOffset CreatedAt { get; set; }
    public virtual string? ModifiedByUserId { get; set; }
    public virtual DateTimeOffset ModifiedAt { get; set; }

    private readonly List<IDomainEvent> _domainEvents = [];

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    protected void RemoveDomainEvent(IDomainEvent domainEvent) => _domainEvents.Remove(domainEvent);

    public void ClearDomainEvents() => _domainEvents.Clear();
}
