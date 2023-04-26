﻿namespace aspnet_core.Models
{
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
        public string CollectionName2 { get; set; } = null!;
        public string CollectionName3 { get; set; } = null!;
    }
}
