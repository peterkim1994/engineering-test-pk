using GildedRose.Console;
using GildedRose.Console.Types;

namespace GildedRose.Tests;

public static class ItemFixtures
{
    public static Item DexterityVest(int sellIn = 10, int quality = 20) =>
        new() { Name = "+5 Dexterity Vest", SellIn = sellIn, Quality = quality };

    public static Item AgedBrie(int sellIn = 2, int quality = 0) =>
        new() { Name = "Aged Brie", SellIn = sellIn, Quality = quality };

    public static Item ElixirOfTheMongoose(int sellIn = 5, int quality = 7) =>
        new() { Name = "Elixir of the Mongoose", SellIn = sellIn, Quality = quality };

    public static Item Sulfuras(int sellIn = 0) =>
        new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = ItemConstants.LegendaryCardQualityRating };

    public static Item BackstagePasses(int sellIn = 15, int quality = 20) =>
        new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality };

    public static Item ConjuredDexterityVest(int sellIn = 10, int quality = 20) =>
        new() { Name = "Conjured +5 Dexterity Vest", SellIn = sellIn, Quality = quality };

    public static Item ConjuredAgedBrie(int sellIn = 2, int quality = 0) =>
        new() { Name = "Conjured Aged Brie", SellIn = sellIn, Quality = quality };

    public static Item ConjuredElixirOfTheMongoose(int sellIn = 5, int quality = 7) =>
        new() { Name = "Conjured Elixir of the Mongoose", SellIn = sellIn, Quality = quality };

    public static Item ConjuredSulfuras(int sellIn = 0) =>
        new() { Name = "Conjured Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = ItemConstants.LegendaryCardQualityRating };

    public static Item ConjuredBackstagePasses(int sellIn = 15, int quality = 20) =>
        new() { Name = "Conjured Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality };
}
