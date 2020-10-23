using AppBancoDLL;
using AppBancoADO;
using MySql.Data.MySqlClient;
using System;
using AppBancoDominio;

namespace ConsoleBanco1
{
    class Program
    {
        static void Main(string[] args)
        {
            var usuarioDAO = new UsuarioDAO();
            var usuario = new Usuario();

            while (true)
            {
                Console.Clear();
                usuarioDAO.Menu();
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "0": //inserir
                        usuario = usuarioDAO.DadosUsuario();
                        usuarioDAO.Insert(usuario);
                        break;

                    case "1": //atualizar
                        usuario = usuarioDAO.DadosUsuario();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Informe o Id do usuario que deseja atualizar");
                        Console.ForegroundColor = ConsoleColor.Red;
                        usuario.cd_usuario = int.Parse(Console.ReadLine());
                        usuarioDAO.Atualiza(usuario);
                        break;

                    case "2": //deletar
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Informe o Id do usuario que deseja excluir");
                        Console.ForegroundColor = ConsoleColor.Red;
                        usuario.cd_usuario = int.Parse(Console.ReadLine());
                        usuarioDAO.Delete(usuario.cd_usuario);
                        break;

                    case "4": //sair
                        Environment.Exit(0);
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                if (opcao == "0" || opcao == "1" || opcao == "2" || opcao == "3")
                {
                    var leitor = usuarioDAO.Listar();

                    foreach (var usuarios in leitor)
                    {
                        Console.WriteLine("Id: {0}, Nome: {1}, Cargo: {2}, Data: {3}",
                        usuario.cd_usuario, usuario.nm_usuario, usuario.ds_cargo, usuario.dt_nascimento);
                    };
                }else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Prescione enter e escolha uma das opções: 0, 1, 2, 3 ou 4");
                }
                Console.ReadLine();
            }
        }
    }
}

