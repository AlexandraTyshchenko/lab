﻿namespace WebApplication1.entities
{
    public class Student:Base
    {
        public string Name { get; set; }
        public int? GroupId { get; set; }
        public Group? Group { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
    }
}
