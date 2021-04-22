using Backend.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backend.Repositorio
{
    public class VeiculoRepositorio : IRepositorio<Veiculo>
    {
        public static List<Veiculo> Veiculos = new List<Veiculo>();

        public void Adicionar(Veiculo entidade)
        {
            Veiculos.Add(entidade);
        }

        public  Veiculo Consultar(int id)
        {
            return Veiculos.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public IEnumerable<Veiculo> Listar()
        {
            return Veiculos.ToList();
        }

        public  void Remover(Veiculo entidade)
        {
            Veiculos.Remove(entidade);
        }

        public Veiculo ConsultarPlaca(string placa)
        {
            return Veiculos.Find(x => x.Placa.Equals(placa));
        }
    }
}
