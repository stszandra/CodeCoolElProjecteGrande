namespace OfferOasisBackend.Model;

public class ShoppingCart
{
    private List<Product> _products = new();

    private double _totalPrice = 0;

    public void AddProduct(Product product)
    {
        _products.Add(product);
        _totalPrice += product.Price;
    }

    public void RemoveProduct(Product product)
    {
        _products.Remove(product);
        _totalPrice -= product.Price;
    }

    public ShoppingCart Show()
    {
        return this;
    }
}