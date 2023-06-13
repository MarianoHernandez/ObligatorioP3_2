    using Datos.Entity;
using Negocio.Entidades;
using Negocio.ExcepcionesPropias;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Datos.Repositorios
{
    public class RepositorioTipoCabania : IRepositorioTipoCabania
    {

        public LibreriaContext LibreriaContext { get; set; }
        public RepositorioTipoCabania(LibreriaContext libreriaContext) {
            LibreriaContext = libreriaContext;

        }
        public void Add(TipoCabania obj)
        {
            obj.Validar();
            LibreriaContext.TipoCabania.Add(obj);
            LibreriaContext.SaveChanges();
        }

        public IEnumerable<TipoCabania> FindAll()
        {
            return LibreriaContext.TipoCabania.ToList();
        }

        public TipoCabania FindByName(string nombre)
        {
            TipoCabania tipo = LibreriaContext.TipoCabania.SingleOrDefault(tipo => tipo.Nombre == nombre);
            return tipo == null ? throw new NoEncontradoException("No se encontro el Tipo de Cabania") : tipo;
        }

        public void Remove(string nombre)
        {
            TipoCabania tipo = FindByName(nombre);
            LibreriaContext.TipoCabania.Remove(tipo);
            LibreriaContext.SaveChanges();
        }
        public void Update(TipoCabania obj)
        {
            obj.Validar();
            LibreriaContext.TipoCabania.Update(obj);
            LibreriaContext.SaveChanges();
        }
        public TipoCabania FindById(int id)
        {
            TipoCabania tipo = LibreriaContext.TipoCabania.SingleOrDefault(tipo => tipo.Id == id);
            return tipo == null ? throw new NoEncontradoException("No se encontro el Tipo de Cabania") : tipo;
        }
        #region Not Implemented


        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
