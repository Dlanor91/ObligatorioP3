using System;
using System.Collections.Generic;
using System.Text;
using Dominio.EntidadesVivero;

namespace Dominio.InterfacesRepositorio
{
   public interface IRepositorio<T>
    {
        bool Add(T obj);
        bool Remove(int id);
        bool Update(T obj);
        IEnumerable<T> FindAll();
        T FindById(int id);
    }
}
