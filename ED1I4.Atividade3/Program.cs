using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED1I4.Atividade3
{
    /*
        *PARTICIPANTES
        * LUIZ CARLOS MENDES CB3012123
   */
    internal class Program    {

        static void Main(string[] args)
        {
            int opcao = 1;
            Contatos contatos = new Contatos();


            Contato fulano = new Contato("fulano", "fulano", new Data(03, 9, 2023));

            fulano.adicionarTelefone(new Telefone("Celular", "123123123", true));
            fulano.adicionarTelefone(new Telefone("Residencial", "321321321", false));

            contatos.adicionar(fulano);


            while (opcao != 0)
            {
                Console.WriteLine("0. Sair\n1. Adicionar contato\n2. Pesquisar contato\n3. Alterar contato\n4. Remover contato\n5. Listar contatos\n");
                Console.Write("\nDigite a opção: ");
                opcao = int.Parse(Console.ReadLine());

                separador();

                switch (opcao)
                {
                    case 0:
                        sair();
                        break;
                    case 1:
                        adicionar(contatos);
                        break;
                    case 2:
                        pesquisar(contatos);
                        break;
                    case 3:
                        alterar(contatos);
                        break;
                    case 4:
                        remover(contatos);
                        break;
                    case 5:
                        listar(contatos);
                        break;
                    default:
                        Console.WriteLine("\n\nopção invalida, por favor selecione um valor entre 0 e 9\n\n");
                        break;
                }

                separador();
            }
        }

        private static void sair()
        {
            Console.Clear();
            Console.WriteLine("*** PRESSIONE QUALQUER TECLA PARA FINALIZAR ***");
            Console.ReadKey();
        }
        private static void adicionar(Contatos contatos)
        {
            Contato contato = new Contato();
            Data dataNascimento = new Data();
            Telefone telefone = new Telefone();

            Console.Write("Digite o email: ");
            contato.Email = Console.ReadLine();

            Console.Write("Digite o nome: ");
            contato.Nome = Console.ReadLine();

            Console.Write("Digite o dia de nascimento: ");
            dataNascimento.Dia = int.Parse(Console.ReadLine());

            Console.Write("Digite o mes de nascimento: ");
            dataNascimento.Mes = int.Parse(Console.ReadLine());

            Console.Write("Digite o ano de nascimento: ");
            dataNascimento.Ano = int.Parse(Console.ReadLine());

            contato.DtNasc = dataNascimento;

            Console.Write("Digite o tipo do telefone: ");
            telefone.Tipo = Console.ReadLine();

            Console.Write("Digite o numero do telefone: ");
            telefone.numero = Console.ReadLine();

            telefone.principal = true;

            contato.adicionarTelefone(telefone);

            bool cadastradoComSucesso = contatos.adicionar(contato);

            if (cadastradoComSucesso)
            {
                Console.WriteLine("\nContato adicionada com sucesso!");
            }
            else
            {
                Console.WriteLine("\nNão foi possivel adicionar o contato");
            }
        }
        private static void pesquisar(Contatos contatos)
        {
            Contato contato = new Contato();

            Console.Write("Digite o email do contato: ");
            contato.Email = Console.ReadLine();

            contato = contatos.pesquisar(contato);

            if(contato == null)
            {
                Console.WriteLine("\nContato não encontrado");
            }
            else
            {
                Console.WriteLine(contato.ToString());
            }
        }
        private static void alterar(Contatos contatos)
        {
            Contato contato = new Contato();
            Data dataNascimento = new Data();
            Telefone telefone = new Telefone();

            Console.Write("Digite o email do contato: ");
            contato.Email = Console.ReadLine();

            contato = contatos.pesquisar(contato);

            if(contato == null)
            {
                Console.WriteLine("\nContato não encontrato");
            }



            Console.Write("Digite o nome do contato: ");
            contato.Nome = Console.ReadLine();

            Console.Write("Digite o dia que o contato nasceu: ");
            dataNascimento.Dia = int.Parse(Console.ReadLine());

            Console.Write("Digite o mes que o contato nasceu: ");
            dataNascimento.Mes = int.Parse(Console.ReadLine());

            Console.Write("Digite o ano que o contato nasceu: ");
            dataNascimento.Ano = int.Parse(Console.ReadLine());

            contato.DtNasc = dataNascimento;

            Console.Write("Digite o tipo do telefone: ");
            telefone.Tipo = Console.ReadLine();

            Console.Write("Digite o numero do telefone: ");
            telefone.numero = Console.ReadLine();
            telefone.principal = true;
            contato.adicionarTelefone(telefone);


            bool atualizadoComSucesso = contatos.alterar(contato);

            if (atualizadoComSucesso)
            {
                Console.WriteLine("\nContato atualizado com sucesso");
            }
            else
            {
                Console.WriteLine("\nContato não foi atualizado");
            }
        }
        private static void remover(Contatos contatos)
        {
            Contato contato = new Contato();

            Console.Write("Digite o email do contato: ");
            contato.Email = Console.ReadLine();

            bool contatoRemovido = contatos.remover(contato);

            if (contatoRemovido)
            {
                Console.WriteLine("\nContato removido com sucesso");
            }
            else
            {
                Console.WriteLine("\nContato não foi removido");
            }
        }
        private static void listar(Contatos contatos)
        {
            foreach(Contato contato in contatos.Agenda)
            {
                Console.WriteLine(contato.ToString());
            }
        }


        private static void separador()
        {
            Console.WriteLine();
            for (int i = 0; i < 20; i++)
            {
                Console.Write("=*");
            }
            Console.WriteLine("\n");
        }
    }
}
