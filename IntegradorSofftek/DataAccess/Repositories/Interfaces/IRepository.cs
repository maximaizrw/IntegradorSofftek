﻿namespace IntegradorSofftek.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<List<T>> GetAll();
        public Task<bool> Modificar(T entity);
        public Task<bool> Eliminar(int codUsuario);

    }
}