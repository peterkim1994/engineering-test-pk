using GildedRose.Console.Types;

namespace GildedRose.Console.ItemUpdaters;

public class ItemQualityAppreciater : IItemQualityUpdater
{
    public void UpdateItemQuality(Item item)
    {
        if (item.Quality < ItemConstants.StandardQualityLimit)
        {
            item.Quality += 1;
        }
        
        if (item is { SellIn: < 0, Quality: < ItemConstants.StandardQualityLimit })
        {
            item.Quality += 1;
        }
    }
}