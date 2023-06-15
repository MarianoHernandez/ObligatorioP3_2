using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Entity;
using Negocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Negocio.ExcepcionesPropias;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections;

namespace Datos.Repositorios
{
    public class RepositorioMantenimiento : IRepositorioMantenimiento
    {

        public LibreriaContext Contexto { get; set; }
        public IRepositorioCabania Cabania { get; set; }
        public RepositorioMantenimiento(LibreriaContext ctx, IRepositorioCabania cabania)
        {
            Contexto = ctx;
            Cabania = cabania;
        }

        public void Add(Mantenimiento obj)
        {
            IEnumerable<Mantenimiento> mantenimientos = Contexto.Mantenimiento
                .Where(man => man.CabaniaId == obj.CabaniaId && man.fecha.DayOfYear == obj.fecha.DayOfYear)
                .ToList();

            if(mantenimientos.Count() >= 3)
            {
                throw new MantenimientoInvalidoException("Mantenimiento invalido, no se puede crear mas de 3 por dia en la misma cabaña");
            }
            
            Cabania cab = Cabania.FindById(obj.CabaniaId);
            obj.cabania = cab;


            obj.Validar();
            Contexto.Mantenimiento.Add(obj);
            Contexto.SaveChanges();

        }

        public IEnumerable<Mantenimiento> FindAll()
        {
            IEnumerable<Mantenimiento> mantenimiento = Contexto.Mantenimiento
                .Include(man => man.cabania)
                .ThenInclude(cab => cab.TipoCabania)
                .ToList();
            return mantenimiento;
        }
        public void Remove(Mantenimiento mantenimiento)
        {
            Contexto.Mantenimiento.Remove(mantenimiento);
            Contexto.SaveChanges();
        }

        public void Update(Mantenimiento obj)
        {
            Contexto.Mantenimiento.Update(obj);
            Contexto.SaveChanges();
        }

        public Mantenimiento FindById(int id)
        {

            return Contexto.Mantenimiento.Find(id);
        }

        public IEnumerable<Mantenimiento> FindMantenimiento(DateTime Fecha1, DateTime Fecha2)
        {
            IEnumerable<Mantenimiento> lista = Contexto.Mantenimiento
                .Include(o => o.cabania)
                .ToList()
                .Where(man => man.fecha > Fecha1 && man.fecha < Fecha2)
                .OrderByDescending(cos => cos.costo);

            return lista;
        }
        void IRepositorio<Mantenimiento>.Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mantenimiento> FindByCabania(int id) {
            IEnumerable<Mantenimiento> lista = Contexto.Mantenimiento
                .Include(o => o.cabania)
                .ToList()
                .Where(man => man.cabania.Id == id);

            return lista;
        }

        public IEnumerable<Mantenimiento> MantenimientosPorValores(int c1, int c2, string nombreEmpleado)
        {
            IEnumerable<Mantenimiento> lista = Contexto.Mantenimiento
                .ToList()
                .Where(cos => cos.costo >= c1 && cos.costo <= c2)
                .Where(nom => nom.trabajador == nombreEmpleado);
                return lista;
        }
    }
}
