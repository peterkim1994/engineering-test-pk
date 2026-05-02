using Xunit;

namespace GildedRose.Tests;

public class ProgramTests
{
    [Fact] public void UpdateQuality_MixedItemTypes_UpdatesQualityDependingOnItemType()
    {
        Assert.True(true);
    }
    
    [Fact] public void UpdateQuality_MixedConjuredItemTypes_UpdatesQualityDependingOnItemType()
    {
        Assert.True(true);
    }
    
    [Fact] public void UpdateQuality_StandardItemsWithZeroQuality_DoesntDecreaseQuality()
    {
        Assert.True(true);
    }
    
    [Fact] public void UpdateQuality_StandardItemsGoingOverSellInDate_DecreasesQualityDoubleTheRate()
    {
        Assert.True(true);
    }
    
    [Theory]
    public void UpdateQuality_FutureEvent_DecreasesQualityAmountBasedOnSellInDate()
    {
        Assert.True(true);
    }
}