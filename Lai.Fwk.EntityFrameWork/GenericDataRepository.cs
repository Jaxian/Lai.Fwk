using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace Lai.Fwk.EntityFrameWork
{
    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class
    {
        private DbContext context;

        public GenericDataRepository(DbContext basedatos)
        {
            context = basedatos;
            
        }

        private void capturar_error(DbEntityValidationException ex)
        {
            string error = string.Empty;
            foreach (var eve in ex.EntityValidationErrors)
                foreach (var ve in eve.ValidationErrors)
                    error += ve.ErrorMessage;

            

            throw new Exception(error);
        }

        public virtual IList<T> listarTodo(params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list = new List<T>();
            try
            {
                IQueryable<T> dbQuery = context.Set<T>();

                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery.AsNoTracking().ToList<T>();
            }
            catch (DbEntityValidationException ex)
            {
                capturar_error(ex);
            }
            return list;
        }

        public virtual IList<T> listar(Func<T, bool> where,
                                       params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list = new List<T>();
            try
            {
                IQueryable<T> dbQuery = context.Set<T>();

                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery.AsNoTracking().Where(where).ToList<T>();
            }
            catch (DbEntityValidationException ex)
            {
                capturar_error(ex);
            }
            return list;
        }

        public virtual T obtenerUno(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;
            try
            {
                IQueryable<T> dbQuery = context.Set<T>();

                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                item = dbQuery.AsNoTracking().FirstOrDefault(where);
            }
            catch (DbEntityValidationException ex)
            {
                capturar_error(ex);
            }

            return item;
        }

        public virtual int Add(params T[] items)
        {
            int totreg = 0;
            try
            {
                foreach (T item in items)
                    context.Entry(item).State = System.Data.EntityState.Added;

                totreg = context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                capturar_error(ex);
            }
            return totreg;
        }

        public virtual int Update(params T[] items)
        {
            int totreg = 0;
            try
            {
                foreach (T item in items)
                    context.Entry(item).State = System.Data.EntityState.Modified;

                totreg = context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                capturar_error(ex);
            }

            return totreg;
        }

        public virtual int Remove(params T[] items)
        {
            int totreg = 0;
            try
            {
                foreach (T item in items)
                    context.Entry(item).State = System.Data.EntityState.Deleted;

                totreg = context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                capturar_error(ex);
            }

            return totreg;
        }
    }
}
