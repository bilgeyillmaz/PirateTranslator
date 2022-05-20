namespace CaseAFS.Models.AbstractionExample
{
    public abstract class Abstract
    {
        public abstract void Work();
        public virtual void Finished()
        {
            Console.WriteLine("Mission completed.");
        }
    }
}
