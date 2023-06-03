using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio.InterfacesRepositorio
{
    public interface IRepositorio<T>
    {
        void Add(T obj);
        void Remove(int id);
        T FindById(int id);
        IEnumerable<T> FindAll();
        void Update(T obj);

    }
}
