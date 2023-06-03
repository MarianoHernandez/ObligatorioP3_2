﻿using Datos.Entity;
using Negocio.EntidadesAuxiliares;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class RepositorioParametros : IRepositorioParametros
    {

        public LibreriaContext LibreriaContext { get; set; }
        public RepositorioParametros(LibreriaContext libreriaContext)
        {
            LibreriaContext = libreriaContext;
        }

        public Parametro ObtenerParametros(string nombre)
        {
            return LibreriaContext.Parametro.Where(par => par.Nombre == nombre).SingleOrDefault();
        }

        public Parametro ObtenerParametrosTipo()
        {
            throw new NotImplementedException();
        }

        public void Add(Parametro obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Parametro FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Parametro> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Parametro obj)
        {
            obj.Validar();
            Parametro actualizar = ObtenerParametros(obj.Nombre);
            if (actualizar == null)
            {
                throw new Exception("No se encontro a que elemento quiere cambiarle el ladrgo de la descripcion");
            }
            actualizar.ValorMinimo = obj.ValorMinimo ;
            actualizar.ValorMaximo = obj.ValorMaximo ;
            actualizar.Validar();
            LibreriaContext.Parametro.Update(actualizar);
            LibreriaContext.SaveChanges();
        }
    }
}
