using System;

public class Entity<ID>
{
    public ID Id { get; set; }

    public Entity() { }
    public Entity(ID id)
    {
        Id = id;
    }

    public void SetId(ID id)
    {
        if (!Id?.Equals(default(ID)) ?? false)
            throw new InvalidOperationException("Id is already set.");
        Id = id;
    }
}
