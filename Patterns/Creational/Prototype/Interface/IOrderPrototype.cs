namespace Patterns.Creational.Prototype.Interface
{
    internal interface IOrderPrototype
    {
        IOrderPrototype FlashSaleShallowClone();
        IOrderPrototype ReOrderDeepClone();
    }
}
