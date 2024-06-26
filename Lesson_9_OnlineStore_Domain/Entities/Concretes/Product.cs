﻿using Lesson_9_OnlineStore_Domain.Entities.Abstracts;

namespace Lesson_9_OnlineStore_Domain.Entities.Concretes;

public class Product: Entity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public double? Price { get; set; }

    // Foreign Key
    public int CategoryId { get; set; }
    // Navigation Property
    public virtual Category Category { get; set; }
    public virtual ICollection<Tag> Tags { get; set; }
}
