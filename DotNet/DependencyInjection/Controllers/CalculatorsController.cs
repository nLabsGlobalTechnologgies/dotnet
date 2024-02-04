using Microsoft.AspNetCore.Mvc;

// Namespace tanımlanır.
namespace DependencyInjection.Controllers;

// Route ve ApiController attribute'ları ile API Controller sınıfı belirlenir.
[Route("api/[controller]/[action]")]
[ApiController]
public class CalculatorsController : ControllerBase
{
    //new keywordü bir classı bir objeye dönüştürür. Bu Dönüştürme işlemine instance türetme denir.
    // Calculator sınıfının bir örneği private olarak tanımlanır.
    private readonly Calculator _calculator;
    private readonly A _a;

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

public class A
{
    private readonly Calculator _calculator;
    public A(Calculator calculator)
    {
        _calculator = calculator;
    }
    public int Metot()
    {

        var result = _calculator.Add(5, 10);
        return result;
    }
}