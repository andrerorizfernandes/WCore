using System.Data;
using System.Data.SqlClient;

namespace WCore.Models
{
    public class UsuarioDAL: IUsuarioDAL
    {
        public void AddUsuario(Usuario usuario)
        {
            using (SqlConnection con = new SqlConnection(Conexao.strCon))
            {
                string comandoSQL = "INSERT INTO Usuario(Nome) " +
                    "VALUES (@Nome)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Nome", usuario.Nome);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteUsuario(int? id)
        {
            using (SqlConnection con = new SqlConnection(Conexao.strCon))
            {
                string comandoSQL = "DELETE FROM Usuario WHERE IdUsuario = @IdUsuario";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@IdUsuario", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public IEnumerable<Usuario> GetAllUsuarios()
        {
            List<Usuario> lstusuario = new List<Usuario>();

            using (SqlConnection con = new SqlConnection(Conexao.strCon))
            {
                SqlCommand cmd = new SqlCommand("SELECT IdUsuario, Nome FROM Usuario", con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Usuario usuario = new Usuario();

                    usuario.IdUsuario = Convert.ToInt32(rdr["IdUsuario"]);
                    usuario.Nome = rdr["Nome"].ToString();

                    lstusuario.Add(usuario);
                }

                con.Close();
            }

            return lstusuario;
        }

        public Usuario GetUsuario(int? id)
        {
            Usuario usuario = new Usuario();

            using (SqlConnection con = new SqlConnection(Conexao.strCon))
            {
                string sqlQuery = "SELECT * FROM Usuario WHERE IdUsuario = " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    usuario.IdUsuario = Convert.ToInt32(rdr["IdUsuario"]);
                    usuario.Nome = rdr["Nome"].ToString();
                }
            }

            return usuario;
        }

        public void UpdateUsuario(Usuario usuario)
        {
            using (SqlConnection con = new SqlConnection(Conexao.strCon))
            {
                string comandoSQL = "UPDATE Usuario SET Nome = @Nome " +
                    "WHERE IdUsuario = @IdUsuario";

                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@Nome", usuario.Nome);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
