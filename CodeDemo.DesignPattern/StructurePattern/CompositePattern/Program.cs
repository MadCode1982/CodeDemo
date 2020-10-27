using System;
using System.Collections.Generic;
using System.Text;

namespace CodeDemo.DesignPattern.StructurePattern.CombinationPattern
{
    // The base Component class declares common operations for both simple and
    // complex objects of a composition.
    //基本的Component类声明简单操作和通用操作
    //合成中的复杂对象。
    abstract class Component
    {
        public Component() { }

        // The base Component may implement some default behavior or leave it to
        // concrete classes (by declaring the method containing the behavior as
        // "abstract").
        //基本Component可能实现某些默认行为，或将其保留给
        //具体类（通过将包含行为的方法声明为
        //“abstract”）。
        public abstract string Operation();

        // In some cases, it would be beneficial to define the child-management
        // operations right in the base Component class. This way, you won't
        // need to expose any concrete component classes to the client code,
        // even during the object tree assembly. The downside is that these
        // methods will be empty for the leaf-level components.
        //在某些情况下，定义子级管理将是有益的
        //在基础Component类中进行操作。 这样，您就不会
        //需要将任何具体的组件类公开给客户端代码，
        //即使在对象树装配期间也是如此。 缺点是这些
        //对于叶级组件，方法将为空。
        public virtual void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(Component component)
        {
            throw new NotImplementedException();
        }

        // You can provide a method that lets the client code figure out whether
        // a component can bear children.
        //您可以提供一种方法，让客户端代码确定是否
        //组件可以带有子代。
        public virtual bool IsComposite()
        {
            return true;
        }
    }

    // The Leaf class represents the end objects of a composition. A leaf can't
    // have any children.
    //
    // Usually, it's the Leaf objects that do the actual work, whereas Composite
    // objects only delegate to their sub-components.
    // Leaf类表示合成的最终对象。 叶子不能
    //有任何孩子。
    //
    //通常，是由Leaf对象完成实际工作，而Composite
    //对象仅委托给它们的子组件。
    class Leaf : Component
    {
        public override string Operation()
        {
            return "Leaf";
        }

        public override bool IsComposite()
        {
            return false;
        }
    }

    // The Composite class represents the complex components that may have
    // children. Usually, the Composite objects delegate the actual work to
    // their children and then "sum-up" the result.
    // Composite类表示可能具有的复杂组件
    //孩子。 通常，Composite对象将实际工作委托给
    //他们的孩子，然后“sum-up”结果。
    class Composite : Component
    {
        protected List<Component> _children = new List<Component>();

        public override void Add(Component component)
        {
            this._children.Add(component);
        }

        public override void Remove(Component component)
        {
            this._children.Remove(component);
        }

        // The Composite executes its primary logic in a particular way. It
        // traverses recursively through all its children, collecting and
        // summing their results. Since the composite's children pass these
        // calls to their children and so forth, the whole object tree is
        // traversed as a result.
        // Composite以特定的方式执行其主要逻辑。 它
        //递归遍历其所有子级，收集并
        //汇总结果。 由于复合材料的孩子通过了这些
        //调用其子对象，依此类推，整个对象树是
        //结果遍历。
        public override string Operation()
        {
            int i = 0;
            string result = "Branch(";

            foreach (Component component in this._children)
            {
                result += component.Operation();
                if (i != this._children.Count - 1)
                {
                    result += "+";
                }
                i++;
            }

            return result + ")";
        }
    }

    class Client
    {
        // The client code works with all of the components via the base
        // interface.
        //客户端代码通过基础与所有组件一起使用
        //接口。
        public void ClientCode(Component leaf)
        {
            Console.WriteLine($"RESULT: {leaf.Operation()}\n");
        }

        // Thanks to the fact that the child-management operations are declared
        // in the base Component class, the client code can work with any
        // component, simple or complex, without depending on their concrete
        // classes.
        //由于声明了子管理操作
        //在基本Component类中，客户端代码可以与任何
        //组件，简单或复杂，不依赖于它们的具体
        //类。
        public void ClientCode2(Component component1, Component component2)
        {
            if (component1.IsComposite())
            {
                component1.Add(component2);
            }

            Console.WriteLine($"RESULT: {component1.Operation()}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            // This way the client code can support the simple leaf
            // components...
            //这样，客户端代码可以支持简单的叶子
            // 组件...
            Leaf leaf = new Leaf();
            Console.WriteLine("Client: I get a simple component:");
            client.ClientCode(leaf);

            // ...as well as the complex composites.
            // ...以及复杂的复合材料。
            Composite tree = new Composite();
            Composite branch1 = new Composite();
            branch1.Add(new Leaf());
            branch1.Add(new Leaf());
            Composite branch2 = new Composite();
            branch2.Add(new Leaf());
            tree.Add(branch1);
            tree.Add(branch2);
            Console.WriteLine("Client: Now I've got a composite tree:");
            client.ClientCode(tree);

            Console.Write("Client: I don't need to check the components classes even when managing the tree:\n");
            client.ClientCode2(tree, leaf);
        }
    }
}
