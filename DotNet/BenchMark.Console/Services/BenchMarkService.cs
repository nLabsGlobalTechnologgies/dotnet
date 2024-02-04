using BenchMark.Console.Context;
using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;

namespace BenchMark.Console.Services;
internal sealed class BenchMarkService
{
    AppDbContext context = new();

    //[Benchmark(Baseline = true)]
    //public async Task ToListAsync()
    //{
    //    await context.ShoppingCarts.ToListAsync();
    //}

    //[Benchmark]
    //public void ToList()
    //{
    //    context.ShoppingCarts.ToList();
    //}

    [Benchmark(Baseline = true)]
    public async Task ToListAsyncWithAsNoTracking()
    {
        await context.ShoppingCarts.AsNoTracking().ToListAsync();
    }

    [Benchmark]
    public async Task ToListAsync()
    {
        await context.ShoppingCarts.ToListAsync();
    }
}
