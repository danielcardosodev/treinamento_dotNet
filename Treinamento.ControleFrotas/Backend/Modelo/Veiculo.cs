using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Modelo
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public int QuilometragemInicial { get; set; }
    }
}
