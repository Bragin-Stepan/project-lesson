namespace Project.Inventory
{
    public struct Item : IIdentifiable
    {
        public string Id { get; }
        public string Name;
        
        public Item (string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}