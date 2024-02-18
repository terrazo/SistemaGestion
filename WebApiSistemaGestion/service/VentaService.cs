
using Microsoft.EntityFrameworkCore;
using WebApiSistemaGestion.database;
using WebApiSistemaGestion.DTOs;
using WebApiSistemaGestion.Mapper;
using WebApiSistemaGestion.models;


namespace WebApiSistemaGestion.service
{
    public class VentaService
    {
        private CoderContext context;

        public VentaService(CoderContext coderContext)
        {
            this.context = coderContext;
        }

        public List<Venta> GetAllVentas()
        {
            return context.Venta.ToList();
        }

        public List<Venta> ObtenerTodasLasVentas()
        {
            List<Venta> v = context.Venta.ToList();

            return v;
        }

        public Venta ObtenerVentaPorId(int id)
        {
            Venta? vbuscada = context.Venta.Where(v => v.Id == id).FirstOrDefault();
            return vbuscada;
        }

        public Venta ObtenerVentaPorId2(int id)
        {
            List<Venta> v = ObtenerTodasLasVentas();

            foreach (Venta item in v)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public bool AgregarVenta(VentaDTO vDTO)
        {

            Venta venta = VentaMapper.MapearAVenta(vDTO);

            context.Venta.Add(venta);

            context.SaveChanges();
            return true;
        }

        public bool ActualizarVentaPorId(VentaDTO vDTO, int id)
        {
            Venta? vBuscado = context.Venta.Where(v => v.Id == id).FirstOrDefault();

            if (vBuscado is not null)
            {
                vBuscado.Comentarios = vDTO.Comentarios;
                vBuscado.IdUsuario = vDTO.IdUsuario;

                context.Venta.Update(vBuscado);

                context.SaveChanges();

                return true;
            }
            return false;
        }


        public bool EliminarVentaPorId(int id)
        {
            Venta? AEliminar = context.Venta.Where(v => v.Id == id).FirstOrDefault();

            if (AEliminar is not null)
            {
                context.Venta.Remove(AEliminar);
                context.SaveChanges();
                return true;
            }
            return false;
        }




    }


}
