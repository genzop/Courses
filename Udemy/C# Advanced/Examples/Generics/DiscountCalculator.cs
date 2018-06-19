namespace Generics
{
    //Ejemplo de una clase genérica con una restriccion de Clase
    public class DiscountCalculator<TProduct> where TProduct : Product
    {
        public float CalculateDiscount(TProduct product)
        {
            return product.Price;
        }
    }
}
