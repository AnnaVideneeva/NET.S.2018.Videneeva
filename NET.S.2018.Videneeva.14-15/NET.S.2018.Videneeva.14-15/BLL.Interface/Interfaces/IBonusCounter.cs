namespace BLL.Interface.Interfaces
{
    public interface IBonusCounter
    {
        int Increase(int bonusPoints);
        int Reduction(int bonusPoints);
    }
}
