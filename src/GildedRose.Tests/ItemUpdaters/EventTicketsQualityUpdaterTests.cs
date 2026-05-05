using GildedRose.Console.ItemUpdaters;
using GildedRose.Console.Types;
using Xunit;

namespace GildedRose.Tests.ItemUpdaters;

public class EventTicketsQualityUpdaterTests
{
    private readonly EventTicketsQualityUpdater _updater = new();

    [Theory]
    [InlineData(20, 20, 21)]
    [InlineData(10, 20, 21)]
    public void UpdateItemQuality_EventMoreThanTenDaysAway_IncreasesQualityByOne(
        int sellIn, int quality, int expectedQuality)
    {
        var item = ItemFixtures.BackstagePasses(sellIn: sellIn, quality: quality);

        _updater.UpdateItemQuality(item);

        Assert.Equal(expectedQuality, item.Quality);
    }

    [Theory]
    [InlineData(9, 20, 22)]
    [InlineData(7, 20, 22)]
    [InlineData(5, 20, 22)]
    public void UpdateItemQuality_EventSixToTenDaysAway_IncreasesQualityByTwo(
        int sellIn, int quality, int expectedQuality)
    {
        var item = ItemFixtures.BackstagePasses(sellIn: sellIn, quality: quality);

        _updater.UpdateItemQuality(item);

        Assert.Equal(expectedQuality, item.Quality);
    }

    [Theory]
    [InlineData(4, 20, 23)]
    [InlineData(2, 20, 23)]
    [InlineData(0, 20, 23)]
    public void UpdateItemQuality_EventFiveOrLessDaysAway_IncreasesQualityByThree(
        int sellIn, int quality, int expectedQuality)
    {
        var item = ItemFixtures.BackstagePasses(sellIn: sellIn, quality: quality);

        _updater.UpdateItemQuality(item);

        Assert.Equal(expectedQuality, item.Quality);
    }

    [Fact]
    public void UpdateItemQuality_EventHasOccurred_DropsQualityToZero()
    {
        var item = ItemFixtures.BackstagePasses(sellIn: -1, quality: 20);

        _updater.UpdateItemQuality(item);

        Assert.Equal(ItemConstants.MinimumQualityRating, item.Quality);
    }

    [Theory]
    [InlineData(4, 47, 50)]
    [InlineData(5, 48, 50)]
    [InlineData(10, 49, 50)]
    [InlineData(10, 50, 50)]
    [InlineData(14, 50, 50)]
    public void UpdateItemQuality_EventTicketNearOrAtMaxQuality_DoesntExceedQualityLimit(
        int sellIn, int quality, int expectedQuality)
    {
        var item = ItemFixtures.BackstagePasses(sellIn: sellIn, quality: quality);

        _updater.UpdateItemQuality(item);

        Assert.Equal(expectedQuality, item.Quality);
    }
}
