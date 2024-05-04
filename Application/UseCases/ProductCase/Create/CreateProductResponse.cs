﻿namespace Application.UseCases.Product.Create
{
    public sealed record CreateProductResponse
    {
        public Guid ProductId { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }
    }
}