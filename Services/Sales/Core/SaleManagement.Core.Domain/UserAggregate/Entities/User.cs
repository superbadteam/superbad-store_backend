using BuildingBlock.Core.Domain;
using SaleManagement.Core.Domain.ProductAggregate.Entities;

namespace SaleManagement.Core.Domain.UserAggregate.Entities;

public sealed class User : AggregateRoot
{
    public User()
    {
        AverageRating = 0;
        ProductSold = 0;
        Carts = new List<Cart>();
        Products = new List<Product>();
    }

    public User(DateTime createdAt, string createdBy) : this()
    {
        CreatedAt = createdAt;
        CreatedBy = createdBy;
    }

    public User(Guid id, string name, DateTime createdAt, string createdBy) : this(createdAt, createdBy)
    {
        Id = id;
        Name = name;
    }

    public string Name { get; set; } = null!;

    public double AverageRating { get; set; }

    public string? AvatarUrl { get; set; }

    public string? CoverUrl { get; set; }

    public int ProductSold { get; set; }

    public List<Cart> Carts { get; set; }

    public List<Product> Products { get; set; }

    public double TotalPrice { get; set; }

    public Cart AddToCart(Guid productTypeId, double price, int quantity)
    {
        var cart = new Cart(productTypeId, price, quantity);

        Carts.Add(cart);

        UpdateTotalPrice();

        return cart;
    }

    public void UpdateTotalPrice()
    {
        TotalPrice = Carts.Sum(item => item.TotalPrice);
    }

    public void RemoveFromCart(Cart cartItem)
    {
        Carts.Remove(cartItem);

        UpdateTotalPrice();
    }
}