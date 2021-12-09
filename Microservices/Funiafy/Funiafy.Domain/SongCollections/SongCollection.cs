namespace Funiafy.Domain.SongCollections
{
    public abstract class SongCollection
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