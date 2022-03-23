using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPannelApp.Repository.Interface
{
    public interface IBook
    {
    }

    public interface GenericInterface<T>
    {
        List<T> GetData();
    }
}
