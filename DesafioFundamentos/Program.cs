using DesafioFundamentos.Models;
using DesafioFundamentos.Services;

class Program
{
    private static Estacionameto estacionamento = new(0, 0);
    private static bool executanto;

    static void Main()
    {

        estacionamento = IniciarEstacionamento();
        Console.Clear();

        int funcao;
        do
        {
            funcao = ExibirMenu();
            Executar(funcao);

        }while(executanto);

    }

    static Estacionameto IniciarEstacionamento()
    {
        executanto = true;
        decimal precoInicial = LerNumeros.Ler("--------------\nEstacionamento\n--------------\nDigite o preço inicial: ");
        decimal precoHora = LerNumeros.Ler("Digite o preço por hora: ");
        return new Estacionameto(precoInicial, precoHora);
    }
    static int ExibirMenu()
    {
        Console.Clear();

        int funcao = LerNumeros.Ler("Selecione uma funcionalidade:\nCadastrar Veículo[1]\nRemover Veículo[2]\nLista de Veículos[3]\nFechar estacionamento[0]");

        if (funcao < 0 || funcao > 3){
            do
            {
                funcao = LerNumeros.Ler("Opção inválida. Tente novamente: ");
            }while(funcao < 0 || funcao > 3);
        }

        return funcao;
    }

    static void Executar(int funcao)
    {
        switch(funcao)
        {
            case 0:
                executanto = estacionamento.FecharCaixa();
                break;
            case 1:
                estacionamento.Estacionar();
                break;
            case 2:
                estacionamento.LiberarVaga();
                break;
            case 3:
                estacionamento.VeiculosEstacionados();
                break;
        }
    }
}
