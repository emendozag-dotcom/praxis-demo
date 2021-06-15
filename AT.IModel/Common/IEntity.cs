namespace AT.IModel.Common {
    public interface IEntity {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}