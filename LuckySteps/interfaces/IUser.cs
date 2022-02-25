
namespace LuckySteps.interfaces
{
    public interface IUser
    {
        string Name { get; set; }
        int Many { get; set; }
        void AddWonMany(int many);
    }
}
