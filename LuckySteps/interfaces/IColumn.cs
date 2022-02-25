using LuckySteps.enums;

namespace LuckySteps.interfaces
{
    public  interface IColumn
    {
        int Many { get; set; }
        ColumnDescription Description { get; set; }
    }
}
