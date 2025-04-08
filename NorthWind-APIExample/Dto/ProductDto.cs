namespace NorthWind_APIExample.Dto
{
    public class ProductDto
    {
        public int ProductId{ get; set; }
        public string ProductName{ get; set; }
        public decimal? UnitPrice{ get; set; }
        public short? UnitInStock{ get; set; }
    }
}
