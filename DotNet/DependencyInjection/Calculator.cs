namespace DependencyInjection;

// Calculator sınıfı, basit bir toplama işlemi gerçekleştiren bir sınıftır.
public class Calculator
{
    // Plus metodu, iki sayıyı toplar ve sonucu döndürür.
    internal int Plus(int firstNumber, int secondNumber)
    {
        // Toplama işlemi gerçekleştirilir.
        int result = firstNumber + secondNumber;

        // Toplam sonucu döndürülür.
        return result;
    }
}