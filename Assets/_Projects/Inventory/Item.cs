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
    
    // Тут я не знаю, есть ли в unity способ работать с UUID
}