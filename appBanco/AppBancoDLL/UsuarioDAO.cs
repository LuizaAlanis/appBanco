using AppBancoADO;
using AppBancoDominio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDLL
{
    public class UsuarioDAO
    {
        private Banco db;

        public void Insert(Usuario usuario)
        {
            string strQuery = string.Format("Insert into tbl_usuario(nm_usuario,ds_cargo,dt_nascimento)" +
                              "values('{0}','{1}','{2}');", usuario.nm_usuario, usuario.ds_cargo, usuario.dt_nascimento.ToString("yyyy-MM-dd"));
            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void Atualiza(Usuario usuario)
        {
            var strQuery = "";
            strQuery += "update tbl_usuario set ";
            strQuery += string.Format(" nm_usuario = '{0}', ", usuario.nm_usuario);
            strQuery += string.Format(" ds_cargo = '{0}', ", usuario.ds_cargo);
            strQuery += string.Format(" dt_nascimento = '{0}' ", usuario.dt_nascimento.ToString("yyyy-MM-dd"));
            strQuery += string.Format(" where cd_usuario = {0}; ", usuario.cd_usuario);

            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public List<Usuario> Listar()
        {
            var db = new Banco();
            var strQuery = "select * from tbl_usuario; ";
            var retorno = db.Retornacomando(strQuery);
            return ListaDeUsuario(retorno);
        }

        // método para associar o reader e o list
        public List<Usuario> ListaDeUsuario(MySqlDataReader retorno)
        {
            var usuarios = new List<Usuario>();
            while (retorno.Read())
            {
                var TempUsuario = new Usuario();
                {
                    TempUsuario.cd_usuario = int.Parse(retorno["cd_usuario"].ToString());
                    TempUsuario.nm_usuario = retorno["nm_usuario"].ToString();
                    TempUsuario.ds_cargo = retorno["ds_cargo"].ToString();
                    TempUsuario.dt_nascimento = DateTime.Parse(retorno["dt_nascimento"].ToString());
                };
                usuarios.Add(TempUsuario);
            }
            return usuarios;
        }

        public void Delete(int cd_usuario)
        {
            string strQuery = string.Format("delete from tbl_usuario where cd_usuario = {0}; ", cd_usuario);
            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Usuario usuario)
        {
            if (usuario.cd_usuario > 0)
                Atualiza(usuario);
            else
                Insert(usuario);
        }

        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-------------AppBanco-------------");
            Console.WriteLine("-     0 - Cadastrar Usuario      -");
            Console.WriteLine("-     1 - Editar Usuario         -");
            Console.WriteLine("-     2 - Excluir                -");
            Console.WriteLine("-     3 - Listar Usuario         -");
            Console.WriteLine("-     4 - Sair                   -");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Qual opção você deseja?");
        }

        public Usuario DadosUsuario()
        {
            var usuario = new Usuario();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Digite o nome do usuário");
            Console.ForegroundColor = ConsoleColor.Red;
            usuario.nm_usuario = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Digite o cargo");
            Console.ForegroundColor = ConsoleColor.Red;
            usuario.ds_cargo = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Digite a data nascimento");
            Console.ForegroundColor = ConsoleColor.Red;
            usuario.dt_nascimento = DateTime.Parse(Console.ReadLine());

            return usuario;
        }
    }
}
