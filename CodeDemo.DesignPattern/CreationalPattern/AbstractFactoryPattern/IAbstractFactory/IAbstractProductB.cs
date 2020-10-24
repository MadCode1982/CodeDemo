namespace CodeDemo.DesignPattern.CreationalPattern.AbstractFactoryPattern
{
    public interface IAbstractProductB
    {
        public string UsefulFunctionB();
        // The Abstract Factory makes sure that all products it creates are of
        // the same variant and thus, compatible.
        string AnotherUsefulFunctionB(IAbstractProductA collaborator);
    }
}