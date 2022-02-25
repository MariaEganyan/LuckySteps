using LuckySteps.interfaces;


namespace LuckySteps.MembersOfGame
{
    public class User : IUser
    {
        public string Name { get ; set ; }
        public int Many { get ; set ; }

        public User(string name)
        {
            Name = name;
            Many = 0;
        }
        public void AddWonMany(int many)
        {
            Many += many;
        }
    }
}
