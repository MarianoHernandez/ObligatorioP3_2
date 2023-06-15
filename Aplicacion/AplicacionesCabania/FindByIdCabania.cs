using DTOs;
using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesCabania
{
    public class FindByIdCabania : IFindByIdCabania

    {
        public IRepositorioCabania RepositorioCabania { get; set; }

        public FindByIdCabania(IRepositorioCabania repo) {
            RepositorioCabania = repo;
        }


        public CabaniaDTO FindById(int id)
        {
            Cabania cab = RepositorioCabania.FindById(id);
            if (cab != null && cab is Cabania)
            {
                return new CabaniaDTO()
                {
                    Id = cab.Id,
                    Nombre = cab.Nombre.Value,
                    TipoCabaniaId = cab.TipoCabaniaId,
                    Descripcion = cab.Descripcion.Value,
                    Jacuzzi = cab.Jacuzzi,
                    Habilitada = cab.Habilitada,
                    CantidadPersonas = cab.CantidadPersonas,
                    Foto = cab.Foto,
                    TipoCabaniaDTO = new TipoCabaniaDTO()
                    {
                        Id = cab.TipoCabania.Id,
                        Nombre = cab.TipoCabania.Nombre,
                        Descripcion = cab.TipoCabania.Descripcion.Value,
                        Costo = cab.TipoCabania.Costo
                    }
                };
            }
            else
            {
                return null;
            }

        }
    }
}

