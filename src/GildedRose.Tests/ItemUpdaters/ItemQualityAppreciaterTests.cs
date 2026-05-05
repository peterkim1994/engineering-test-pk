using GildedRose.Console.ItemUpdaters;
using GildedRose.Console.Types;
using Xunit;

namespace GildedRose.Tests.ItemUpdaters;

public class ItemQualityAppreciaterTests
{
    private readonly ItemQualityAppreciater _appreciater = new();

    [Fact]
    public void UpdateItemQuality_AppreciatingItem_IncreasesQualityByOne()
    {
        var item = ItemFixtures.AgedBrie(sellIn: 5, quality: 20);

        _appreciater.UpdateItemQuality(item);

        Assert.Equal(21, item.Quality);
    }

    [Fact]
    public void UpdateItemQuality_AppreciatingItemPastSellByDate_IncreasesQualityByTwo()
    {
        var item = ItemFixtures.AgedBrie(sellIn: -1, quality: 20);

        _appreciater.UpdateItemQuality(item);

        Assert.Equal(22, item.Quality);
    }

    [Fact]
    public void UpdateItemQuality_AppreciatingItemOnSellByDate_IncreasesQualityByOneOnly()
    {
        var item = ItemFixtures.AgedBrie(sellIn: 0, quality: 20);

        _appreciater.UpdateItemQuality(item);

        Assert.Equal(21, item.Quality);
    }

    [Fact]
    public void UpdateItemQuality_AppreciatingItemAtMaxQuality_DoesntIncreaseQuality()
    {
        var item = ItemFixtures.AgedBrie(sellIn: 5, quality: ItemConstants.StandardQualityLimit);

        _appreciater.UpdateItemQuality(item);

        Assert.Equal(ItemConstants.StandardQualityLimit, item.Quality);
    }

    [Fact]
    public void UpdateItemQuality_AppreciatingItemPastSellByDateAtMaxQuality_DoesntIncreaseQuality()
    {
        var item = ItemFixtures.AgedBrie(sellIn: -1, quality: ItemConstants.StandardQualityLimit);

        _appreciater.UpdateItemQuality(item);

        Assert.Equal(ItemConstants.StandardQualityLimit, item.Quality);
    }

    [Fact]
    public void UpdateItemQuality_AppreciatingItemPastSellByDateNearMaxQuality_CapsQualityAtMax()
    {
        var item = ItemFixtures.AgedBrie(sellIn: -1, quality: 49);

        _appreciater.UpdateItemQuality(item);

        Assert.Equal(ItemConstants.StandardQualityLimit, item.Quality);
    }

    [Fact]
    public void UpdateItemQuality_AppreciatingItemFromZeroQuality_IncreasesQualityByOne()
    {
        var item = ItemFixtures.AgedBrie(sellIn: 5, quality: 0);

        _appreciater.UpdateItemQuality(item);

        Assert.Equal(1, item.Quality);
    }

    [Fact]
    public void UpdateItemQuality_AppreciatingItemFromZeroQualityPastSellByDate_IncreasesQualityByTwo()
    {
        var item = ItemFixtures.AgedBrie(sellIn: -1, quality: 0);

        _appreciater.UpdateItemQuality(item);

        Assert.Equal(2, item.Quality);
    }
}
