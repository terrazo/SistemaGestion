using System.Text.Json.Serialization;

namespace WebApiSistemaGestion.models
{
    public partial class ProductoVendido
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }

        [JsonIgnore]
        public virtual Producto IdProductoNavigation { get; set; } = null!;

        [JsonIgnore]
        public virtual Venta IdVentaNavigation { get; set; } = null!;

    }
}
