using GildedRose.Console.ItemUpdaters;
using GildedRose.Console.Types;
using Xunit;

namespace GildedRose.Tests.ItemUpdaters;

public class ItemUpdaterTests
{
    private readonly ItemUpdater _updater = new(
        new EventTicketsQualityUpdater(),
        new ItemQualityAppreciater(),
        new ConjuredItemQualityUpdater(new ItemQualityDegrader()),
        new ItemQualityDegrader());
    
    [Fact]
    public void UpdateItem_QualityChangingItem_UpdatesItemSellByDate()
    {
        var agedBrie = ItemFixtures.AgedBrie(sellIn: 5, quality: 20);
        
        _updater.UpdateItem(agedBrie);
        
        Assert.Equal(4, agedBrie.SellIn);
    }
    
    [Fact]
    public void UpdateItem_QualityNonChangingItem_DoesntUpdateItem()
    {
        var item = ItemFixtures.Sulfuras();

        _updater.UpdateItem(item);

        Assert.Equal(ItemConstants.LegendaryCardQualityRating, item.Quality);
    }
    
    [Fact]
    public void UpdateItem_NormalItem_DecreasesQualityByOne()
    {
        var item = ItemFixtures.DexterityVest(sellIn: 5, quality: 20);

        _updater.UpdateItem(item);

        Assert.Equal(19, item.Quality);
    }

    [Fact]
    public void UpdateItem_ConjuredDegradingItem_ItemQualityDegradesDoubleTheRate()
    {
        var item = ItemFixtures.ConjuredManaCake(sellIn: 0, quality: 10);

        _updater.UpdateItem(item);

        Assert.Equal(6, item.Quality);
    }
}
