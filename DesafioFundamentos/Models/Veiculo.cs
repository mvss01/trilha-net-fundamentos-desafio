namespace DesafioEstacionamento.Models
{
    public class Veiculo(string placa)
    {
        public string Placa { get; private set; } = placa;
    }
}
