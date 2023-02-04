using CadastroPessoa_Fisica_Juridica.Classes;
using System.Text.RegularExpressions;

//***************Metodos Genéricos *******************
PessoaJuridica metodosPj = new PessoaJuridica();
PessoaFisica metodosPf = new PessoaFisica();
List<PessoaFisica> ListaPf = new List<PessoaFisica>();// inicializa uma lista vazia de pessoa física
List<PessoaJuridica> ListaPj = new List<PessoaJuridica>();// inicializa uma lista vazia de pessoa jurídica

//*********************Cadastro da pessoa física**********************
// Cabeçalho do Sistema
Console.WriteLine(@$"
==============================================
|    Bem vindo ao sistema de cadastro de     |
|        Pessoas Físicas e Jurídicas         |
==============================================
");


Utils.Loading("Iniciando Meu Sistema ", 4, 300, ConsoleColor.Yellow, ConsoleColor.Red);

Console.WriteLine();//pula uma linha


Thread.Sleep(1500);//2000ms = 2s

string? opcao;

do
{
    //desenhar o menu
    Console.WriteLine(@$"
==============================================
|       Escolha uma das opções abaixo        |
|--------------------------------------------|
|           1 - Pessoa Física                |
|           2 - Pessoa Jurídica              |
|                                            |
|           0 - Sair                         |
==============================================
");

    opcao = Console.ReadLine();
    // espera o usuário digitar a opção
    // escolha a opção
    //faz algo, e só depois pergunta se é pra continuar

    switch (opcao)
    {
        case "1": //**Cadastro da pessoa física************
            string opcaoPf;
            do
            {
                //desenhar o sub-menu
                Console.WriteLine(@$"
                ==============================================
                |       Escolha uma das opções abaixo        |
                |--------------------------------------------|
                |        1 - Cadastrar Pessoa Física         |
                |        2 - Listar Pessoa Física            |
                |                                            |
                |        0 - Voltar ao menu anterior         |
                ==============================================
                ");
                opcaoPf = Console.ReadLine();

                switch (opcaoPf)
                {
                    case "1"://cadastrar pessoa física
                        Utils.ParadaNoConsole("Opção Cadastrar Pessoa Física");
                        Console.Clear();
                        // Console.WriteLine($"*********************Cadastro da pessoa física**********************");
                        Console.WriteLine();//pula uma linha

                        //CADASTRO preenchimento dos dados
                        //Endereço pessoa fisica 1
                        Endereco enderecoPf = new Endereco();
                        Console.WriteLine($"Digite o Endereço: ");
                        enderecoPf.Logradouro = Console.ReadLine();
                        Console.WriteLine($"Digite o número: ");
                        enderecoPf.Numero = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Endereço comercial? s/n: ");
                        string comercial = Console.ReadLine();
                        if (comercial == "s")
                        {
                            enderecoPf.Comercial = true;
                        }
                        else
                        {
                            enderecoPf.Comercial = false;
                        }

                        //pessoa Física 1
                        PessoaFisica novaPf = new PessoaFisica();
                        Console.WriteLine($"Digite o nome");
                        novaPf.Nome = Console.ReadLine();
                        novaPf.DataNascimento = new DateTime(1985, 10, 20);
                        Console.WriteLine($"Digite o CPF: ");
                        novaPf.Cpf = Console.ReadLine();
                        Console.WriteLine($"Informe o rendimento Bruto: ");
                        novaPf.Rendimento = float.Parse(Console.ReadLine());
                        novaPf.Endereco = enderecoPf;

                        //cadastrando na lista
                        ListaPf.Add(novaPf);//guarda uma pessoa física na lista

                        Utils.ParadaNoConsole("Pessoa Física Cadastrada com sucesso!!! ");

                        break;

                    case "2"://listar pessoa física
                             // EXIBIÇÃO
                        Console.Clear();
                        Console.WriteLine("**********Listagem de Pessoas Físicas***********");//pula uma linha

                        foreach (var pessoa in ListaPf)
                        {//cada pessoa cadastrada
                            Console.WriteLine();//pula uma linha
                            Console.WriteLine($"Nome: {pessoa.Nome}");
                            Console.WriteLine($"CPF: {pessoa.Cpf}");
                            Console.WriteLine($"Rendimento: {pessoa.Rendimento}");
                            Console.WriteLine($"Rendimento Líquido: {metodosPf.PagarImposto(pessoa.Rendimento)}");
                            Console.WriteLine($"Data Nascimento {pessoa.DataNascimento}");
                            // Console.WriteLine($"Maior de idade? {pessoa.ValidarDataNascimento(pessoa.DataNascimento)}");
                            Console.WriteLine(metodosPf.ValidarDataNascimento(pessoa.DataNascimento) ? "Maior de Idade: Sim" : "Maior de Idade: Não");                            
                            Console.WriteLine($"Rua: {pessoa.Endereco.Logradouro}");
                            Console.WriteLine($"Número: {pessoa.Endereco.Numero}");
                            // Console.WriteLine($"Endereço Comercial ? {pessoa.Endereco.Comercial}");
                            // string endComercial = (pessoa.Endereco.Comercial == true ) ? "Endereço Comercial? sim " : "Endereço Comercial? Não ";
                            // Console.WriteLine(endComercial);                            
                            Console.WriteLine((pessoa.Endereco.Comercial) ? "Endereço Comercial? sim" : "Endereço Comercial? Não");                            

                            // if (pessoa.Endereco.Comercial == true)
                            // {
                            //     Console.WriteLine($"Endereço Comercial? Sim ");
                            // }
                            // else
                            // {
                            //     Console.WriteLine($"Endereço Comercial? Não ");
                            // }
                        }
                        Console.WriteLine();//linha vazia
                        Utils.ParadaNoConsole("********** Fim da listagem ***********");
                        break;

                    case "0"://volta ao menu anterior
                        Console.Clear();
                        Utils.ParadaNoConsole("Voltando ao menu anterior");
                        break;

                    default://qualquer opção diferente do menu
                        Console.Clear();
                        Utils.ParadaNoConsole("***** Opção Inválida *****");
                        break;
                }

                   }while(opcaoPf != "0");         

                            break;
        case "2": //pessoa Juridica
         string? opcaoPj;
                do
                {
                Console.Clear();
 Console.WriteLine(@$"
            =======================================
            |    Escolha uma das opções Abaixo    |
            | ----------------------------------- |
            |  1 - Cadastrar Pessoa Jurídica      |
            |  2 - Listar Pessoa Jurídica         |
            |                                     |
            |  0 - Voltar para o Menu anterior    |
            =======================================
                            ");                                       
                            opcaoPj = Console.ReadLine();                             

                            switch (opcaoPj)
                            {
                                case "0":
                                    Utils.ParadaNoConsole("Retornando para o menu Principal");
                                    break;
                                case "1":
                                    Console.Clear(); 
                                    Utils.ParadaNoConsole("Iniciando o Cadastro de Pessoa Jurídica!");

                                    //Endereço
                                    Endereco endPj1 = new Endereco();
                                
                                    Console.Write("Qual endereço ? : ");
                                    endPj1.Logradoura = Console.ReadLine();
                                    Console.Write("Qual numero ? : ");
                                    endPj1.Numero = int.Parse(Console.ReadLine());
                                    Console.Write("Indereço comercial? [s/n] : ");
                                    string comercial = Console.ReadLine();
                                    if (comercial=="s")
                                    {
                                        endPj1.Comercial = true;
                                    }
                                    else if(comercial =="n")
                                    {
                                        endPj1.Comercial = false;
                                    }
                                    
                                    //Atributos da pessoa
                                    PessoaJuridica pj1 = new PessoaJuridica();
                                    
                                    Console.Write("Qual nome completo do Representante? : ");
                                    pj1.Nome = Console.ReadLine();
                                    Console.Write("Qual a razão social? : ");
                                    pj1.RazaoSocial=Console.ReadLine();
                                    Console.Write("Qual o nome fantasia? : ");
                                    pj1.Fantasia=Console.ReadLine();
                                    Console.Write("Qual CNPJ? : ");
                                    pj1.Cnpj= Console.ReadLine(); //"14.625.806/0001-80"
                                    Console.Write("Qual Seu rendimento bruto? : ");
                                    pj1.Rendimento = float.Parse(Console.ReadLine());
                                    Console.WriteLine("");
                                    pj1.Endereco = endPj1;


                                    //Adciona objetos dentro da lista pessoa fisica
                                    ListaPj.Add(pj1);                            

                                    Utils.ParadaNoConsole("Pessoa Jurídica Cadastrada com Sucesso!");
                                    break;

                                case "2":
                                    Console.Clear();
                                    Utils.loading("Carregando Dados de Pessoas Jurídicas ",3,300);
                                    Console.WriteLine("--------------Lista de Pessoas Jurídicas-----------");

                                    foreach (var pessoaJu in ListaPj)
                                    {
                                        Console.WriteLine($"\nRazão Social : {pessoaJu.RazaoSocial}");
                                        Console.WriteLine($"Nome Fantasia : {pessoaJu.Fantasia}");
                                        Console.WriteLine($"Representante : {pessoaJu.Nome}");
                                        Console.WriteLine($"CNPJ : {pessoaJu.Cnpj}");
                                        Console.WriteLine(metodosPj.ValidarCnpj(pessoaJu.Cnpj) ? "CNPJ é Válido!" : "CNPJ Não é Válido!");
                                        Console.WriteLine($"Rendimento anual : {pessoaJu.Rendimento}");
                                        Console.WriteLine($"Rendimento liquido : {metodosPj.PagarImposto(pessoaJu.Rendimento)}");
                                        Console.WriteLine($"Logradouro = {pessoaJu.Endereco.Logradoura},{pessoaJu.Endereco.Numero}");                                      
                                        Console.WriteLine((pessoaJu.Endereco.Comercial) ? "Endereço comercial? : Sim! " : "Endereço comercial? : Não! ");
                                    }
                                             
                                    Utils.ParadaNoConsole(" ");
                                    break;
                                default:
                                    Console.Clear();
                                    Utils.ParadaNoConsole("Opção Invalida!");
                                    break;
                            }
                            
                }while(opcaoPj != "0");          
            break;
        default:
                Utils.ParadaNoConsole("Opção Invalida ");
            break;
    }

} while (op1 != "0");

Utils.Loading("Finalizando Meu Sistema", 4, 400);
Console.WriteLine();//pula uma linha

// DateTime data = new DateTime(1980, 8, 20);
// Console.WriteLine(pessoa.ValidarDataNascimento(data));


//***********ESTUDOS DE CASO****************

// Substring
// .........0123456789..................
// string nome - "Fulano de tal";
// Console.WriteLine( nome.Substrinf(3));
// Console.WriteLine( nome.Substrinf(8));
// Console.WriteLine( nome.Substrinf(0, 4));
// Console.WriteLine( nome.Substrinf(4, 5));
// Console.WriteLine( nome.Substrinf(NotImplementedException.Length));


// string data = "11/12/2022";

// bool dataValida = Regex.IsMatch(data, @"^\d{2}/\d{2}/\d{4}$");

// Console.WriteLine(data);
// Console.WriteLine(dataValida);

// if (dataValida)
// {    
//     String[] partes = data.Split("/");

//     if ( int.Parse(partes[1]) >= 1 && int.Parse(partes[1]) <= 12 )
// {
//     Console.WriteLine("Mês Válido");
// }
// else
// {
//     Console.WriteLine("Mês INVÁLIDO");
// }
// }
//ESTUDO DE CASO PJ
// EXEMPLO COM O USUÁRIO DIGITANDO/ dando INPUT OS DADOS
// Console.WriteLine($"Nome Fantasia?");
// novaPj.Fantasia = Console.ReadLine();
// Console.WriteLine($"Qual é o Rendimento");
// novaPj.Rendimento = float.Parse(Console.ReadLine());
