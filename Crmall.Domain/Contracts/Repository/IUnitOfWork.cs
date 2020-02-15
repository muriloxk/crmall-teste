namespace Crmall.Domain.Contracts.Repository
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
