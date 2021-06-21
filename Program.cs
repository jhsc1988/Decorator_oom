using System;

namespace decorator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IPizza pizza = new Pizza(); // obična pizza
            IPizza cheeseDecorator = new CheeseDecorator(pizza); // extra cheese
            IPizza onionDecorator = new OnionDecorator(cheeseDecorator); // extra onions
            Console.WriteLine(onionDecorator.GetPizzaType());
        }

        // base interface
        private interface IPizza
        {
            string GetPizzaType();
        }

        // concrete implementation
        private class Pizza : IPizza
        {
            public string GetPizzaType()
            {
                return "This is a normal Pizza";
            }
        }

        // base decorator
        private abstract class PizzaDecorator : IPizza
        {
            private readonly IPizza _pizza;

            protected PizzaDecorator(IPizza pizza)
            {
                _pizza = pizza;
            }

            public virtual string GetPizzaType()
            {
                return _pizza.GetPizzaType();
            }
        }

        // concrete decorators
        private class CheeseDecorator : PizzaDecorator
        {
            public CheeseDecorator(IPizza pizza) : base(pizza)
            {
            }

            public override string GetPizzaType()
            {
                var type = base.GetPizzaType();
                type += "\r\n with extra cheese";
                return type;
            }
        }

        private class OnionDecorator : PizzaDecorator
        {
            public OnionDecorator(IPizza pizza) : base(pizza)
            {
            }

            public override string GetPizzaType()
            {
                var type = base.GetPizzaType();
                type += "\r\n with extra onions";
                return type;
            }
        }
    }
}