using GildedRose.Console;
using GildedRose.Console.Types;
using Xunit;

namespace GildedRose.Tests;

public class ProgramTests
{
    [Fact]
    public void UpdateQuality_MixedItemTypes_UpdatesQualityDependingOnItemType()
    {
        var app = new Program
        {
            Items = new List<Item>
            {
                ItemFixtures.DexterityVest(sellIn: 10, quality: 20),
                ItemFixtures.AgedBrie(sellIn: 10, quality: 20),
                ItemFixtures.ElixirOfTheMongoose(sellIn: 10, quality: 20),
                ItemFixtures.Sulfuras(sellIn: 10),
                ItemFixtures.BackstagePasses(sellIn: 10, quality: 20)
            }
        };

        app.UpdateQuality();

        Assert.Equal(19, app.Items[0].Quality);
        Assert.Equal(9, app.Items[0].SellIn);

        Assert.Equal(21, app.Items[1].Quality);
        Assert.Equal(9, app.Items[1].SellIn);

        Assert.Equal(19, app.Items[2].Quality);
        Assert.Equal(9, app.Items[2].SellIn);

        Assert.Equal(ItemConstants.LegendaryCardQualityRating, app.Items[3].Quality);
        Assert.Equal(10, app.Items[3].SellIn);

        Assert.Equal(22, app.Items[4].Quality);
        Assert.Equal(9, app.Items[4].SellIn);
    }
}