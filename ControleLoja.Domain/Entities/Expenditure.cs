using System;

namespace ControleLoja.Domain.Entities
{
    public class Expenditure
    {
            
            public Guid Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
            public DateTime PayDay { get; set; }
            public Expenditure()
            {
                CreatedAt = DateTime.UtcNow;
                UpdatedAt = DateTime.UtcNow;
            }
    }
}
