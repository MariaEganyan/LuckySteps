using LuckySteps.interfaces;
using System.Collections.Generic;

namespace LuckySteps.MembersOfGame
{
    public  class TicetOfGame
    {
       public List<IStep> Steps { get; set; }
        public TicetOfGame()
        {
            Steps=new List<IStep>(0);
        }

        public void AddStep(IStep step)
        {
            Steps.Add(step);
        }
    }
}
