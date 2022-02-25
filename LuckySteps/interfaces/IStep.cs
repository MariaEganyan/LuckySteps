using LuckySteps.enums;

namespace LuckySteps.interfaces
{
    public interface IStep
    {
        IColumn LeftColumn { get; set; }
        IColumn RightColumn { get; set; }
        ColumnDescription TrueColumn { get; set; }
        void ChoosManyColumn();
    }
}
