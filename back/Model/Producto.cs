namespace back.Model
{
    public class Producto
    {
        public Guid id { get; set; }
        public Int16 codigo { get; set; }
        public String descripcion { get; set; }
        public int listaDePrecios { get; set; }
        public string imagen { get; set; }
        public Boolean productoParaLaVenta { get; set; }
        public Int16 porcentajeIva { get; set; }


    }
}
