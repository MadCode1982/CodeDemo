using System;
using System.Collections.Generic;
using System.Text;

namespace CodeDemo.DesignPattern.CreationalPattern.BuilderPattern
{
    // The Builder interface specifies methods for creating the different parts
    // of the Product objects.
    // Builder接口指定用于创建不同零件的方法 //产品对象。
    public interface IBuilder
    {
        void BuildPartA();

        void BuildPartB();

        void BuildPartC();
    }

    // The Concrete Builder classes follow the Builder interface and provide
    // specific implementations of the building steps. Your program may have
    // several variations of Builders, implemented differently.
    // Concrete Builder类遵循Builder界面并提供
    // 构建步骤的特定实现。您的程序可能有
    // Builders的几种变体，实现方式不同。
    public class ConcreteBuilder : IBuilder
    {
        private Product _product = new Product();

        // A fresh builder instance should contain a blank product object, which
        // is used in further assembly.
        //一个新的构建器实例应包含一个空白产品对象，该对象 //用于进一步的汇编。
        public ConcreteBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new Product();
        }

        // All production steps work with the same product instance.
        //所有生产步骤都使用相同的产品实例。
        public void BuildPartA()
        {
            this._product.Add("PartA1");
        }

        public void BuildPartB()
        {
            this._product.Add("PartB1");
        }

        public void BuildPartC()
        {
            this._product.Add("PartC1");
        }

        // Concrete Builders are supposed to provide their own methods for
        // retrieving results. That's because various types of builders may
        // create entirely different products that don't follow the same
        // interface. Therefore, such methods cannot be declared in the base
        // Builder interface (at least in a statically typed programming
        // language).
        //
        // Usually, after returning the end result to the client, a builder
        // instance is expected to be ready to start producing another product.
        // That's why it's a usual practice to call the reset method at the end
        // of the `GetProduct` method body. However, this behavior is not
        // mandatory, and you can make your builders wait for an explicit reset
        // call from the client code before disposing of the previous result.
        //混凝土建造者应该提供自己的方法
        //检索结果。 那是因为各种类型的建筑商可能
        //创建完全不一样的产品
        //接口。 因此，此类方法不能在基础中声明
        // Builder接口（至少在静态类型的编程中
        // 语言）。
        //
        //通常，在将最终结果返回给客户端之后，
        //实例已准备好开始生产其他产品。
        //这就是为什么通常在最后调用reset方法的原因
        // GetProduct方法主体的//。 但是，这种行为不是
        //是必填项，您可以让您的构建器等待明确的重置
        //在处理上一个结果之前从客户端代码调用。
        public Product GetProduct()
        {
            Product result = this._product;

            this.Reset();

            return result;
        }
    }

    // It makes sense to use the Builder pattern only when your products are
    // quite complex and require extensive configuration.
    //
    // Unlike in other creational patterns, different concrete builders can
    // produce unrelated products. In other words, results of various builders
    // may not always follow the same interface.
    //仅当您的产品被使用时才使用Builder模式
    //非常复杂，需要大量配置。
    //
    //与其他创作模式不同，不同的混凝土建造者可以
    //生产无关的产品。 换句话说，各种建造者的结果
    //不一定总是遵循相同的接口。
    public class Product
    {
        private List<object> _parts = new List<object>();

        public void Add(string part)
        {
            this._parts.Add(part);
        }

        public string ListParts()
        {
            string str = string.Empty;

            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2); // removing last ",c"

            return "Product parts: " + str + "\n";
        }
    }

    // The Director is only responsible for executing the building steps in a
    // particular sequence. It is helpful when producing products according to a
    // specific order or configuration. Strictly speaking, the Director class is
    // optional, since the client can control builders directly.
    //总监仅负责执行
    //特定序列。 根据以下要求生产产品时会很有帮助
    //特定的顺序或配置。 严格来说，导演班是
    //可选，因为客户端可以直接控制构建器。
    public class Director
    {
        private IBuilder _builder;

        public IBuilder Builder
        {
            set { _builder = value; }
        }

        // The Director can construct several product variations using the same
        // building steps.
        //总监可以使用相同的内容构造几种产品变体 //建立步骤。
        public void buildMinimalViableProduct()
        {
            this._builder.BuildPartA();
        }

        public void buildFullFeaturedProduct()
        {
            this._builder.BuildPartA();
            this._builder.BuildPartB();
            this._builder.BuildPartC();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // The client code creates a builder object, passes it to the
            // director and then initiates the construction process. The end
            // result is retrieved from the builder object.
            //客户端代码创建一个构建器对象，并将其传递给 //导演，然后启动构建过程。结束 //从构建器对象中检索结果。
            var director = new Director();
            var builder = new ConcreteBuilder();
            director.Builder = builder;

            Console.WriteLine("Standard basic product:");
            director.buildMinimalViableProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Standard full featured product:");
            director.buildFullFeaturedProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            // Remember, the Builder pattern can be used without a Director
            // class.
            //记住，Builder模式可以在没有Director的情况下使用 //类。
            Console.WriteLine("Custom product:");
            builder.BuildPartA();
            builder.BuildPartC();
            Console.Write(builder.GetProduct().ListParts());
        }
    }
}
