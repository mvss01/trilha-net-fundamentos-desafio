namespace DesafioEstacionamento.Services
{
    public static class LerNumeros
    {
        public static int Ler(string mensagem)
        {
            Console.WriteLine(mensagem);
            string input = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(input, out int numero))
            {
                do
                {
                    Console.WriteLine("Entrada inválida. Tente novamente: ");
                    input = Console.ReadLine() ?? string.Empty;
                } while (!int.TryParse(input, out numero));
            }
            return numero;
        }
    }
}
