using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
Console.WriteLine("|                                                                          |");
Console.WriteLine("|                        Bem-vindo ao Hotel Caribe!                        |");
Console.WriteLine("|                                                                          |");
Console.WriteLine("+--------------------------------------------------------------------------+");
Console.WriteLine("|                         Qual opção irá preferir?                         |");
Console.WriteLine("+--------------------------------------------------------------------------+");
Console.WriteLine("| 1 - Suíte Da Casa . . . . . / Capacidade: 1 Hóspede  / R$110,00 por dia  |");
Console.WriteLine("|                                                                          |");
Console.WriteLine("| 2 - Suíte Beira-Mar . . . . / Capacidade: 2 Hóspedes / R$245,00 por dia  |");
Console.WriteLine("|                                                                          |");
Console.WriteLine("| 3 - Suíte 5-Estrelas  . . . / Capacidade: 2 Hóspedes / R$365,00 por dia  |");
Console.WriteLine("|                                                                          |");
Console.WriteLine("| 4 - Suíte La-Dolce-Vita . . / Capacidade: 2 Hóspedes / R$480,00 por dia  |");
Console.WriteLine("|                                                                          |");
Console.WriteLine("| 5 - Suíte Lar-Doce-Lar  . . / Capacidade: 4 Hóspedes / R$622,00 por dia  |");
Console.WriteLine("|                                                                          |");
Console.WriteLine("| 6 - Suíte Pra-Família-Toda  / Capacidade: 4 Hóspedes / R$800,00 por dia  |");
Console.WriteLine("+--------------------------------------------------------------------------+");


string escolha = Console.ReadLine();
Suite suite;

switch (escolha)
{
    case "1":
        suite = new Suite(tipoSuite: "Da Casa", capacidade: 1, valorDiaria: 110.00M);
        break;
    case "2":
        suite = new Suite(tipoSuite: "Beira-Mar", capacidade: 2, valorDiaria: 245.00M);
        break;
    case "3":
        suite = new Suite(tipoSuite: "5-Estrelas", capacidade: 2, valorDiaria: 365.00M);
        break;
    case "4":
        suite = new Suite(tipoSuite: "La-Dolce-Vita", capacidade: 3, valorDiaria: 480.00M);
        break;
    case "5":
        suite = new Suite(tipoSuite: "Lar-Doce-Lar", capacidade: 4, valorDiaria: 622.00M);
        break;
    case "6":
        suite = new Suite(tipoSuite: "Pra-Família-Toda", capacidade: 6, valorDiaria: 800.00M);
        break;
    default:
        throw new Exception("Erro. Suíte inexistente.");
}

//Criando a suíte dos hóspedes
Console.Write("Diga a quantidade de Hóspedes: ");
int quantidadeDeHospedes = Int32.Parse(Console.ReadLine());
Console.Clear();

for (int i = 0; i < quantidadeDeHospedes; i++)
{
    Console.Write("Escreva nome do hóspede: ");
    string nomeHospede = Console.ReadLine();
    Console.Write("Escreva sobrenome do hóspede: ");
    string sobrenomeHospede = Console.ReadLine();
    hospedes.Add(new Pessoa(nomeHospede, sobrenomeHospede));
    Console.Clear();
}

Console.Write("Digite a quantidade de dias de reserva: ");
int quantidadeDeDias = Int32.Parse(Console.ReadLine());

//Criando uma nova reserva, implementando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: quantidadeDeDias);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

//Onde mostra a informação da quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
foreach (Pessoa i in hospedes)
{
    Console.WriteLine(" - " + i.NomeCompleto);
}
Console.WriteLine($"\nValor diária: {reserva.CalcularValorDiaria()}");