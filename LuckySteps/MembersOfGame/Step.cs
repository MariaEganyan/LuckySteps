using LuckySteps.enums;
using LuckySteps.interfaces;
using System;

namespace LuckySteps.MembersOfGame
{
    public class Step:IStep
    {
        public IColumn LeftColumn { get; set; } 
        public IColumn RightColumn { get; set; }

        public ColumnDescription TrueColumn { get; set; }

        public Step()
        {
            LeftColumn = new Column(ColumnDescription.left);
            RightColumn = new Column(ColumnDescription.right);
        }
        public void ChoosManyColumn()
        {
            Random random = new Random();
            int number = random.Next(0,1);
            if(number == 0)
            {
                LeftColumn.Many = 20;
                TrueColumn = ColumnDescription.left;
            }
            else
            {
                RightColumn.Many = 20;
                TrueColumn = ColumnDescription.right;
            }
           
        }

    }
}
