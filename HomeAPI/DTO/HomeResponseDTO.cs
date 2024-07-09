﻿using HomeAPI.Models;

namespace HomeAPI.DTO
{
    public class HomeResponseDTO
    {
        public double Id { get; set; }
        public string Name { get; set; }
        public string? Price { get; set; }
        public string? Description { get; set; }

        public string Image { get; set; }
        public string Filepath { get; set; }

    }
}
