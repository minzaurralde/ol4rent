﻿using Ol4RentAPI.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ol4RentAPI.Facades
{
    class BienFacadeImpl: IBienFacade
    {
        private ModelContainer db = new ModelContainer();

        public Model.Bien Obtener(int id)
        {
            return db.Bienes.Find(id);
        }

        public Model.Bien Crear(Model.Bien bien)
        {
            try {
                db.Bienes.Add(bien);
                db.SaveChanges();
                return bien;
            }
            catch
            {
                return null;
            }
        }

        public Model.Bien Editar(Model.Bien bien)
        {
            try
            {
                db.Entry(bien).State = EntityState.Modified;
                db.SaveChanges();
                return bien;
            }
            catch
            {
                return null;
            }
        }

        public void Eliminar(int id)
        {
            Bien bien = db.Bienes.Find(id);
            if (bien != null)
            {
                db.Bienes.Remove(bien);
                db.SaveChanges();
            }
        }

        public List<Model.Bien> Buscar(string query)
        {
            if (query != null)
            {
                // TODO pasar a linq
                return db.Bienes.Where(b => b.Descripcion.Contains(query) || b.Titulo.Contains(query)).ToList();
            }
            else
            {
                return new List<Bien>();
            }
        }

        public List<Model.Bien> BusquedaAvanzada(Model.Bien templateBien)
        {
            List<Bien> resultadosBusqueda = new List<Bien>();
            if (templateBien.Descripcion != null && templateBien.Titulo != null)
            {
                // TODO pasar a linq
                resultadosBusqueda = db.Bienes.Where(b => b.Descripcion.Contains(templateBien.Descripcion) && b.Titulo.Contains(templateBien.Titulo)).ToList();
            }
            else if (templateBien.Titulo != null)
            {
                // TODO pasar a linq
                resultadosBusqueda = db.Bienes.Where(b => b.Titulo.Contains(templateBien.Titulo)).ToList();
            }
            else if (templateBien.Descripcion != null)
            {
                // TODO pasar a linq
                resultadosBusqueda = db.Bienes.Where(b => b.Descripcion.Contains(templateBien.Descripcion)).ToList();
            }
            return resultadosBusqueda;
        }

        public List<Model.Bien> Wishlist(Model.Usuario usuario)
        {
            // TODO implementar
            throw new NotImplementedException();
        }

        public List<Model.Bien> MisBienes(Model.Usuario usuario)
        {
            // TODO implementar
            throw new NotImplementedException();
        }

        public List<Bien> BienesPopulares
        {
            get
            {
                // TODO sacar este parametro del sitio
                int maximaCantidadPopulares = 10;
                // TODO implementar
                // return db.Bienes.OrderByDescending(bien => bien.CantidadLikes).Take(maximaCantidadPopulares).ToList();
                return Todos;
            }
        }

        public List<Bien> Todos
        {
            get {
                return db.Bienes.ToList();
            }
        }
    }
}
