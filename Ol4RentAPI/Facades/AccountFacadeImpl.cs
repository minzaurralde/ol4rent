using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ol4RentAPI.Model;
using System.Data;

namespace Ol4RentAPI.Facades
{
    class AccountFacadeImpl : IAccountFacade
    {
        private ModelContainer db = new ModelContainer();

        public List<Model.Usuario> Todos
        {
            get { return db.Usuarios.ToList(); }
        }
        
        public Usuario Obtener(int id)
        {
            return db.Usuarios.Find(id);
        }

        Usuario ObtenerPorNombre(string NombreUsuario)
        {
            return db.Usuarios.Where(u => u.NombreUsuario.ToLower() == NombreUsuario.ToLower()).First();
        }

        public Usuario Crear(Usuario usuario)
        {
            try
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return usuario;
            }
            catch
            {
                return null;
            }

        }
        
        public Usuario Editar(Usuario usuario)
        {
            try
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return usuario;
            }
            catch
            {
                return null;
            }
        }

        public void Eliminar(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
            db.SaveChanges();
        }
    }
}
