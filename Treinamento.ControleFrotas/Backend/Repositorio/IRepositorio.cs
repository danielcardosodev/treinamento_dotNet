using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Repositorio
{
    interface IRepositorio<T> where T : class
    {
        //List<T> Veiculos { get; set; }
        void Adicionar(T entidade);
        void Remover(T entidade);
        T Consultar(int id);
        IEnumerable<T> Listar();

    }
}
