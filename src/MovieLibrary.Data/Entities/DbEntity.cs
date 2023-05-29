namespace MovieLibrary.Data.Entities
{
    //Could be also done as interface IIdEntity, but normally using abstract class can simply strongly DB entities with several properties (Id, UpdatedAt, CreatedBy etc)
    //Or can also have some custom logic preffered by us to be triggered, like OnUpdate() etc that can be moved to SaveChanges of EF Core to be used all around app
    public abstract class DbEntity
    {
        public int Id { get; set; }
    }
}