﻿namespace MusinfoDB.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Release> Releases { get; set; } = new HashSet<Release>();
    }
}
