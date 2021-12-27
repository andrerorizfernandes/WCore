namespace WCore.Models
{
    public interface IUsuarioDAL
    {
        IEnumerable<Usuario> GetAllUsuarios();
        void AddUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        Usuario GetUsuario(int? id);
        void DeleteUsuario(int? id);
    }
}
