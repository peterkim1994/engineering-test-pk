using GildedRose.Console.ItemUpdaters;
using Xunit;

namespace GildedRose.Tests.ItemUpdaters;

public class ConjuredItemQualityUpdaterTests
{
    private readonly ConjuredItemQualityUpdater _updater = new(new ItemQualityDegrader());

    [Fact]
    public void UpdateItemQuality_ConjuredDegradingItemNotPassedSellByDate_ItemQualityDegradesDoubleTheRate()
    {
        var item = ItemFixtures.ConjuredDexterityVest(sellIn: 5, quality: 10);

        _updater.UpdateItemQuality(item);

        Assert.Equal(8, item.Quality);
    }
    
    [Fact]
    public void UpdateItemQuality_ConjuredDegradingItemPassedSellByDate_ItemQualityDegradesDoubleTheRate()
    {
        var item = ItemFixtures.ConjuredDexterityVest(sellIn: -1, quality: 10);

        _updater.UpdateItemQuality(item);

        Assert.Equal(6, item.Quality);
    }
}