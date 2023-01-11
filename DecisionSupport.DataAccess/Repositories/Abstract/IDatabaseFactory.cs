namespace DecisionSupport.DataAccess.Repositories.Abstract
{
    public interface IDatabaseFactory
    {
        IDataContext Get();
    }
}
