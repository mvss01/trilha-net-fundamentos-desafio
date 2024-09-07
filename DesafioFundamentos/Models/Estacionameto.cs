using DesafioEstacionamento.Services;

namespace DesafioEstacionamento.Models
{
    public class Estacionameto(decimal precoInicial, decimal precoHora)
    {
        private readonly decimal precoInicial = precoInicial;
        private readonly decimal precoHora = precoHora;
        private decimal faturamento = 0;
        private readonly List<Veiculo> veiculos = [];

        public void Estacionar()
        {
            string placa = LerPlacas.Ler("Digite a placa do veículo: ");
            bool estacionado = false;
            foreach(Veiculo veiculo in veiculos)
            {
                if(veiculo.Placa == placa){
                    estacionado = true;
                    break;
                }
            }

            if(!estacionado){
                veiculos.Add(new Veiculo(placa));
            }
            else
            {
                Console.WriteLine("Um carro com esta placa já está estacionado.\nPressione Enter para continuar.");
                Console.ReadKey();
            }
        }

        public void LiberarVaga()
        {
            string placa = LerPlacas.Ler("Digite a placa do veículo para remover: ");
            Veiculo? veiculo = null;
            foreach(Veiculo estacionado in veiculos)
            {
                if(estacionado.Placa == placa)
                {
                    veiculo = estacionado;
                    break;
                }
            }
            if(veiculo != null){
                int horas = LerNumeros.Ler("Digite quantas horas o veículo ficou estacionado: ");
                decimal preco = CalcularPreco(horas);
                Console.WriteLine("Pagamento realizado? (Pressione Enter para confirmar)");
                Console.ReadKey();
                faturamento += preco;
                veiculos.Remove(veiculo);
            }
            else
            {
                Console.WriteLine("Nenhum veículo estacionado com esta palca.\nPressione Enter para continuar.");
                Console.ReadKey();
            }

        }

        private decimal CalcularPreco(int horas)
        {
            return precoInicial + precoHora * horas;
        }

        public void VeiculosEstacionados()
        {
            foreach(Veiculo veiculo in veiculos)
            {
                Console.WriteLine($"{veiculo.Placa}");
            }
            Console.WriteLine("Pressione Enter para continuar.");
            Console.ReadKey();
        }

        public bool FecharCaixa()
        {
            if(veiculos.Count == 0)
            {
                Console.WriteLine($"Faturamento do dia: R${faturamento}");
                return false;
            }
            Console.WriteLine("Há carros estacionados. Não é possível fechar o estacionamento.\nPressione Enter para continuar.");
            Console.ReadKey();
            return true;
        }
    }
}
