﻿namespace LoginForm.DataAccess.Repositories.Abstract
{
    public interface IDatabaseFactory
    {
        IDataContext Get();
    }
}
