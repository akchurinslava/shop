﻿using System;
namespace Shop.Core.ChuckNorrisDtos
{
    public class ChuckNorrisResultDto
    {
        public List<string> Categories { get; set; }
        public string CreatedAt { get; set; }
        public string IconUrl { get; set; }
        public string Id { get; set; }
        public string UpdatedAt { get; set; }
        public string Url { get; set; }
        public string Value { get; set; }
    }
}
