using Microsoft.AspNetCore.Mvc;
using RepositoryDesignPattern.DTOs;
using RepositoryDesignPattern.Interfaces;
using RepositoryDesignPattern.Models;

namespace RepositoryDesignPattern.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ShoppingCartsController(
    IShoppingCartRepository shoppingCartRepository,
    IOrderRepository orderRepository,
    IUnitOfWork unitOfWork) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add(AddShoppingCartDto request, CancellationToken cancellationToken)
    {
        ShoppingCart shoppingCart = new()
        {
            ProductId = request.ProductId,
            Quantity = request.Quantity,
        };

        await shoppingCartRepository.AddAsync(shoppingCart, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var shoppingCarts = await shoppingCartRepository.GetAllAsync();
        return Ok(shoppingCarts);
    }

    [HttpGet]
    public IActionResult GetAllReturnIQueryable()
    {
        var shoppingCarts = shoppingCartRepository.GetAllReturnIQueryable();
        shoppingCarts.ToList();
        return Ok(shoppingCarts);
    }

    [HttpGet]
    public IActionResult RemoveById(int id)
    {
        shoppingCartRepository.DeleteById(id);
        unitOfWork.SaveChanges();
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var shoppingCart = await shoppingCartRepository.GetByIdAsync(id, cancellationToken);
        if (shoppingCart is not null)
        {
            shoppingCart.ProductId = 2;
            shoppingCart.Quantity = 3;
            shoppingCartRepository.Update(shoppingCart);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
        return Ok(shoppingCart);
    }

    [HttpGet]
    public async Task<IActionResult> CreateOrder()
    {
        var shoppingCarts = await shoppingCartRepository.GetAllAsync();

        foreach (var cart in shoppingCarts)
        {
            Order order = new()
            {
                ProductId = cart.ProductId,
                Quantity = cart.Quantity
            };
            orderRepository.Add(order);

            //throw new ArgumentException("Hata!");
            shoppingCartRepository.DeleteById(cart.Id);
        }

        unitOfWork.SaveChanges();

        return NoContent();
    }
}
