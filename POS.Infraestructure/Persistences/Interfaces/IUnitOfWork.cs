namespace POS.Infraestructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //Declaracion o matricula de nuestra interfaces a nivel de repository
        public ICategoryRepository Category { get; }

        public void SaveChanges();

        public Task SaveChangesAsync();
    }
}
