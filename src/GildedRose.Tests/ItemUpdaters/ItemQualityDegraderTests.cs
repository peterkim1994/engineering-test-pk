using GildedRose.Console.ItemUpdaters;
using GildedRose.Console.Types;
using Xunit;

namespace GildedRose.Tests.ItemUpdaters;

public class ItemQualityDegraderTests
{
    private readonly ItemQualityDegrader _updater = new();

    [Fact]
    public void UpdateItemQuality_NormalItem_DecreasesQualityByOne()
    {
        var item = ItemFixtures.DexterityVest(sellIn: 5, quality: 20);

        _updater.UpdateItemQuality(item);

        Assert.Equal(19, item.Quality);
    }

    [Fact]
    public void UpdateItemQuality_NormalItemWithZeroQuality_DoesntDecreaseQuality()
    {
        var item = ItemFixtures.DexterityVest(sellIn: 5, quality: 0);

        _updater.UpdateItemQuality(item);

        Assert.Equal(ItemConstants.MinimumQualityRating, item.Quality);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-10)]
    public void UpdateItemQuality_NormalItemPastSellByDate_DecreasesQualityByTwo(int sellIn)
    {
        var item = ItemFixtures.DexterityVest(sellIn: sellIn, quality: 20);

        _updater.UpdateItemQuality(item);

        Assert.Equal(18, item.Quality);
    }

    [Fact]
    public void UpdateItemQuality_NormalItemPastSellByDateWithOneQuality_DecreasesQualityToZero()
    {
        var item = ItemFixtures.DexterityVest(sellIn: 0, quality: 1);

        _updater.UpdateItemQuality(item);

        Assert.Equal(ItemConstants.MinimumQualityRating, item.Quality);
    }
    
    [Fact]
    public void UpdateItemQuality_NormalItemOnLastDayToSell_DecreasesQualityByOne()
    {
        var item = ItemFixtures.DexterityVest(sellIn: 0, quality: 3);

        _updater.UpdateItemQuality(item);

        Assert.Equal(2, item.Quality);
    }

    [Fact]
    public void UpdateItemQuality_NormalItemPastSellByDateWithZeroQuality_DoesntDecreaseQuality()
    {
        var item = ItemFixtures.DexterityVest(sellIn: -10, quality: 0);

        _updater.UpdateItemQuality(item);

        Assert.Equal(ItemConstants.MinimumQualityRating, item.Quality);
    }

    [Fact]
    public void UpdateItemQuality_NormalItemWithOneQuality_DecreasesQualityToZero()
    {
        var item = ItemFixtures.DexterityVest(sellIn: 5, quality: 1);

        _updater.UpdateItemQuality(item);

        Assert.Equal(ItemConstants.MinimumQualityRating, item.Quality);
    }

    [Fact]
    public void UpdateItemQuality_NormalItemNotPastSellByDate_DoesNotDoubleDecrease()
    {
        var item = ItemFixtures.DexterityVest(sellIn: 1, quality: 20);

        _updater.UpdateItemQuality(item);

        Assert.Equal(19, item.Quality);
    }

    [Fact]
    public void UpdateItemQuality_NormalItemPastSellByDateWithTwoQuality_DecreasesQualityToZero()
    {
        var item = ItemFixtures.DexterityVest(sellIn: -1, quality: 2);

        _updater.UpdateItemQuality(item);

        Assert.Equal(ItemConstants.MinimumQualityRating, item.Quality);
    }
}