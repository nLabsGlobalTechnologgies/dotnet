namespace ClassYapilari.DTOs;

public class AddProductDto
{
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}

public class ProdutReportListDto
{
    public string ProductName { get; set; } = string.Empty;
    public int ProductQuantity { get; set; }
}
