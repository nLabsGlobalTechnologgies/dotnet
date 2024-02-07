#CYCLe hatasına alternatif bir çözüm ürettik
## genelde Entitylerden dolayı cycle hatası yenir kısır yada sonsuz döngü oluşur
## aşagıdaki sorguda cycle den kurtulmuş olduk

```bash
[HttpPost]
public IActionResult GetProducts()
{
    // Veritabanından ürünleri çek, aynı zamanda ilişkili kategori bilgilerini de getir.
    var products = _context.Products.Include(p => p.Category).ToList();

    // Her bir ürünü, yalnızca ilgili özellikleri içerecek şekilde bir anonim nesne içinde düzenle.
    var productsWithCategory = products.Select(p => new
    {
        Name = p.Name,
        Title = p.Title,
        Quantity = p.Quantity,
        Discount = p.Discount,
        Price = p.Price,

        // Kategori bilgilerini de bir anonim nesne içinde düzenle.
        Category = new
        {
            p.Category?.Id,
            p.Category?.Name,
            p.Category?.Icon,
            p.Category?.Description
        }
    });

    // Şimdi simplifiedProducts değişkeni içinde, her bir ürünün kendi özellikleri ve ilişkili kategori bilgisi bulunmaktadır.

    // İşlemlerin tamamlandığına dair bir işareti döndür.

    return Ok(productsWithCategory);
}
```