﻿namespace ContosoPizza.Entities
{
    public class Pizza
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool IsGlutenFree { get; set; }
        public double Price {  get; set; }
    }
}
