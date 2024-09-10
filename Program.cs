using System;
using System.Collections.Generic;

namespace CadastroClientes
{
    class Program
    {
        // Lista para armazenar os clientes
        static List<Cliente> clientes = new List<Cliente>();

        static void Main(string[] args)
        {
            bool executando = true;

            while (executando)
            {
                // Exibe o menu de opções para o usuário
                ExibirMenu();

                // Lê a opção escolhida pelo usuário
                int opcao = ObterOpcaoUsuario();

                // Processa a opção escolhida
                switch (opcao)
                {
                    case 1:
                        AdicionarCliente();
                        break;
                    case 2:
                        VisualizarClientes();
                        break;
                    case 3:
                        EditarCliente();
                        break;
                    case 4:
                        ExcluirCliente();
                        break;
                    case 5:
                        executando = false; // Encerra o programa
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                        break;
                }
            }
        }

        // Método para exibir o menu de opções
        static void ExibirMenu()
        {
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Adicionar cliente");
            Console.WriteLine("2 - Visualizar clientes");
            Console.WriteLine("3 - Editar cliente");
            Console.WriteLine("4 - Excluir cliente");
            Console.WriteLine("5 - Sair");
        }

        // Método para obter a opção do usuário
        static int ObterOpcaoUsuario()
        {
            Console.Write("Digite a opção desejada: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        // Método para adicionar um novo cliente
        static void AdicionarCliente()
        {
            Console.Write("Digite o nome do cliente: ");
            string nome = Console.ReadLine();

            // Verifica se já existe um cliente com o mesmo nome
            if (clientes.Exists(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Cliente já cadastrado. Não é possível adicionar clientes duplicados.");
                return;
            }

            Console.Write("Digite o e-mail do cliente: ");
            string email = Console.ReadLine();

            // Cria um novo objeto Cliente e adiciona à lista
            Cliente cliente = new Cliente(nome, email);
            clientes.Add(cliente);

            Console.WriteLine("Cliente adicionado com sucesso.");
        }

        // Método para visualizar todos os clientes
        static void VisualizarClientes()
        {
            if (clientes.Count == 0)
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
                return;
            }

            // Itera sobre a lista de clientes e exibe seus detalhes
            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine($"Nome: {cliente.Nome}");
                Console.WriteLine($"E-mail: {cliente.Email}");
                Console.WriteLine("----------------------");
            }
        }

        // Método para editar os detalhes de um cliente existente
        static void EditarCliente()
        {
            Console.Write("Digite o nome do cliente que deseja editar: ");
            string nome = Console.ReadLine();

            // Encontra o cliente com o nome fornecido
            Cliente cliente = clientes.Find(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            if (cliente != null)
            {
                Console.Write("Digite o novo nome do cliente: ");
                string novoNome = Console.ReadLine();

                Console.Write("Digite o novo e-mail do cliente: ");
                string novoEmail = Console.ReadLine();

                // Atualiza os detalhes do cliente
                cliente.Nome = novoNome;
                cliente.Email = novoEmail;

                Console.WriteLine("Cliente editado com sucesso.");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }

        // Método para excluir um cliente da lista
        static void ExcluirCliente()
        {
            Console.Write("Digite o nome do cliente que deseja excluir: ");
            string nome = Console.ReadLine();

            // Encontra o cliente com o nome fornecido
            Cliente cliente = clientes.Find(c => c.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));

            if (cliente != null)
            {
                // Remove o cliente da lista
                clientes.Remove(cliente);
                Console.WriteLine("Cliente excluído com sucesso.");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }
    }

    // Classe que representa um cliente
    class Cliente
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        // Construtor da classe Cliente
        public Cliente(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }
}
