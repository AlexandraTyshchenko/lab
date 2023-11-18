﻿using WebApplication1.entities;

namespace WebApplication1.DTOs
{
    public class GroupModel
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public int? Course { get; set; }
            public string Curator { get; set; }
    }
}

