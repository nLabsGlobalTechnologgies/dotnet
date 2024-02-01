using Microsoft.AspNetCore.Mvc;

// Namespace tanımlanır.
namespace DependencyInjection.Controllers;

// Route ve ApiController attribute'ları ile API Controller sınıfı belirlenir.
[Route("api/[controller]/[action]")]
[ApiController]
public class CalculatorsController : ControllerBase
{
    // Calculator sınıfının bir örneği private olarak tanımlanır.
    private readonly Calculator _calculator;

    // Constructor aracılığıyla Calculator örneği alınır.
    public CalculatorsController(Calculator calculator)
    {
        // Dependency Injection ile alınan Calculator örneği, private field'a atanır.
        _calculator = calculator;
    }

    // HTTP GET isteği karşılayan bir metod.
    [HttpGet]
    public IActionResult Plus(int firstNumber, int secondNumber)
    {
        // Calculator sınıfının Plus metoduna gelen parametrelerle çağrı yapılır.
        int result = _calculator.Plus(firstNumber, secondNumber);

        // Sonuç, HTTP 200 OK yanıtı ile birlikte döndürülür.
        return Ok(result);
    }
}