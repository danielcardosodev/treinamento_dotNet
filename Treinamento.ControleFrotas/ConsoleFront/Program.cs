using Backend.Modelo;
using Backend.Repositorio;
using System;
using System.Linq;

namespace ConsoleFront
{
    public class Program
    {
        
        static void Main(string[] args)
        {

            TelaInicial();
                


        }

        static void TelaInicial()
        {
            Console.Clear();
            Console.WriteLine("#### CONTROLE FROTAS ####");
            Console.WriteLine("#FUNCOES#");
            Console.WriteLine("1 - Cadastro de veiculos");
            Console.WriteLine("2 - Consulta de veiculos");
            Console.WriteLine("3 - Listagem de veiculos");
            Console.WriteLine("4 - Exclusao de veiculo");
            Console.WriteLine("-----------------");
            Console.Write("Informe uma opção:");
            var opt = Console.ReadLine();

            switch (opt)
            {
                case "1":
                    Cadastro();
                    break;
                case "2":
                    Consulta();
                    break;
                case "3":
                    Listagem();
                    break;
                case "4":
                    Exclusao();
                    break;
                default:
                    TelaInicial();
                    break;
            }
        }

        static void Cadastro()
        {
            Console.Clear();
            Console.WriteLine("####PREENCHA AS INFORMACOES DO VEICULO####");
            Console.WriteLine("------------------");
            Console.Write("Marca:");
            var marca = Console.ReadLine();
            Console.Write("Modelo:");
            var modelo = Console.ReadLine();
            Console.Write("Placa:");
            var placa = Console.ReadLine();
            Console.Write("KM atual:");
            var quilomentragem = Console.ReadLine();

            var novoVeiculo = new Veiculo
            {
                Id = VeiculoRepositorio.Veiculos.Count + 1,
                Marca = marca,
                Modelo = modelo,
                Placa = placa,
                QuilometragemInicial = int.Parse(quilomentragem)
            };

           new VeiculoRepositorio().Adicionar(novoVeiculo);

            Console.WriteLine("Veiculo cadastrado com sucesso!");
            Console.ReadKey();
            Console.WriteLine("");
            TelaInicial();


        }

        static void Consulta()
        {
            Console.Clear();
            Console.WriteLine("#### CONSULTA ####");
            Console.WriteLine("------------------");
            Console.Write("Informe a placa do veículo:");
            var placa = Console.ReadLine();
            var resultadoConsulta = new VeiculoRepositorio().ConsultarPlaca(placa);
            if (resultadoConsulta != null)
            {
                Console.WriteLine($"ID:{resultadoConsulta.Id}");
                Console.WriteLine($"Marca:{resultadoConsulta.Marca}");
                Console.WriteLine($"Modelo:{resultadoConsulta.Modelo}");
                Console.WriteLine($"Placa:{resultadoConsulta.Placa}");
                Console.WriteLine($"KM Inicial:{resultadoConsulta.QuilometragemInicial}");
            }
            else
            {
                //TODO: mostar via exception
                Console.WriteLine("Nenhum resultado encontrado.");
            }

            Console.ReadKey();
            TelaInicial();
        }

        static void Listagem()
        {
            Console.Clear();
            Console.WriteLine("#### LISTAGEM ####");
            Console.WriteLine("------------------");
            var resultadoListagem = new VeiculoRepositorio().Listar().ToList();
            for (int i = 0; i < resultadoListagem.Count(); i++)
            {
                Console.WriteLine($"ID:{resultadoListagem[i].Id}");
                Console.WriteLine($"Marca:{resultadoListagem[i].Marca}");
                Console.WriteLine($"Modelo:{resultadoListagem[i].Modelo}");
                Console.WriteLine($"Placa:{resultadoListagem[i].Placa}");
                Console.WriteLine($"KM Inicial:{resultadoListagem[i].QuilometragemInicial}");
            }

            Console.ReadKey();
            TelaInicial();
        }

        static void Exclusao()
        {
            Console.Clear();
            Console.WriteLine("#### EXCLUSAO ####");
            Console.WriteLine("------------------");
            Console.Write("Informe a placa do veiculo:");
            var placa = Console.ReadLine();
            var veiculoExcluir = new VeiculoRepositorio().ConsultarPlaca(placa);
            if (veiculoExcluir != null)
            {

                //Console.WriteLine($"ID:{veiculoExcluir.Id}");
                //Console.WriteLine($"Marca:{veiculoExcluir.Marca}");
                //Console.WriteLine($"Modelo:{veiculoExcluir.Modelo}");
                //Console.WriteLine($"Placa:{veiculoExcluir.Placa}");
                //Console.WriteLine($"KM Inicial:{veiculoExcluir.QuilometragemInicial}");
                Console.Write("Deseja realmente excluir o veículo [S/N]?");
                var confirm = Console.ReadLine();
                if (confirm.ToUpper().Equals("S"))
                {
                    new VeiculoRepositorio().Remover(veiculoExcluir);
                    Console.WriteLine("Veiculo excluido com sucesso");
                }
            }
            else
            {
                Console.WriteLine("Nenhum veiculo encontrado.");
            }

            Console.ReadKey();
            TelaInicial();
        }




       
    }
}
