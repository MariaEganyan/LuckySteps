using LuckySteps.enums;
using LuckySteps.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LuckySteps.MembersOfGame
{
    public class Column : IColumn
    {
        public int Many { get ; set ; }
        public ColumnDescription Description { get ; set; }
        public Column( ColumnDescription description)
        {
            Many = 0;
            Description = description;
        }
    }
}
