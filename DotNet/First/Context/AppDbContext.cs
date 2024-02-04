using First.Models;
using Microsoft.EntityFrameworkCore;

namespace First.Context;

public sealed class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("");
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }

    public DbSet<Todo>? Todos { get; set; }
}


//public class A
//{
//    private int Age { get; set; }
//    public int Id { get; set; }
//    public void Method() { }
//}

//public interface IInterface
//{
//    string Name { get; set; }
//    void Method2();
//}

//public class B : A //inherit
//{

//}

//public class C : IInterface //implement
//{
//    public string Name { get; set; }

//    public void Method2()
//    {

//    }
//}

//public class D : A, IInterface //inherit + implement
//{
//    public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

//    public void Method2()
//    {
//        throw new NotImplementedException();
//    }
//}
