﻿namespace AMS3ASales.API.Domain.Request
{
    public class ProductRequest
    {
        public string Description { get; set; }
        public double Price { get; set; }
        public double Stock { get; set; }
        public string ImageURL { get; set; }
    }
}
