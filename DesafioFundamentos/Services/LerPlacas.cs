namespace DesafioEstacionamento.Services
{
    public class LerPlacas
    {
        public static string Ler(string mensagem)
        {
            string placa = string.Empty;
            int tamanho = 5;
            ConsoleKeyInfo tecla = new();
            Console.WriteLine(mensagem);
            do
            {

                tecla = Console.ReadKey(intercept: true);

                if(placa.Length < tamanho)
                {
                    if(char.IsLetter(tecla.KeyChar))
                    {
                        if(placa.Length < 3)
                        {
                            placa += char.ToUpper(tecla.KeyChar);
                            Console.Write(char.ToUpper(tecla.KeyChar));
                        }

                        if(placa.Length == 4)
                        {
                            tamanho = 7;
                            placa += char.ToUpper(tecla.KeyChar);
                            Console.Write(char.ToUpper(tecla.KeyChar));
                        }

                    }

                    if (char.IsDigit(tecla.KeyChar))
                    {

                        if (placa.Length >= 5){
                            placa += tecla.KeyChar;
                            Console.Write(tecla.KeyChar);
                        }

                        if(placa.Length == 4){
                            tamanho = 8;
                            placa = placa.Insert(placa.Length - 1, "-");
                            placa += tecla.KeyChar;
                            Console.SetCursorPosition(0, Console.CursorTop);
                            Console.Write(placa);
                        }

                        if(placa.Length == 3){
                            placa += tecla.KeyChar;
                            Console.Write(tecla.KeyChar);
                        }

                    }
                }

                if (tecla.Key == ConsoleKey.Backspace && placa.Length > 0)
                {
                    if (placa.Length > 3 && placa[^2] == '-')
                    {
                        placa = placa[..^2];
                        Console.Write("\b \b\b \b");
                    }

                    else if(placa.Length > 1)
                    {
                        placa = placa[..^1];
                        Console.Write("\b \b");
                    }

                    else if (placa.Length == 1)
                    {
                        placa = string.Empty;
                        Console.Write("\b \b");
                    }

                    if(placa.Length == 3)
                    {
                        tamanho = 5;
                    }
                }

            }while(tecla.Key != ConsoleKey.Enter);
            Console.Write("\n");
            return placa;
        }
    }
}
