﻿namespace Shared.Services.Interfaces.DTO.Funiafy.SongCollections
{
    public abstract class SongCollectionDTO
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ulong Duration { get; set; }
        public string Cover { get; set; }
        public bool Private { get; set; }
    }
}