using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Lai.Fwk.EntityFrameWork
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGenericDataRepository<T> where T : class
    {
        //string Error { get; set; }
        IList<T> listarTodo(params Expression<Func<T, object>>[] navigationProperties);
        IList<T> listar(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        T obtenerUno(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        int Add(params T[] items);
        int Update(params T[] items);
        int Remove(params T[] items);
    }
}
