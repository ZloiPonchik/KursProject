namespace StorehouseOfAppliancesPasswordCheckerPasswordChecker
{
    public abstract class BaseChecker<P, R>
        where P : class
    {
        public abstract R Check(P p);
    }
}