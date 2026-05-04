namespace GildedRose.Console.ItemUpdaters;

public class ItemQualityDegrader : IItemQualityUpdater
{
    public void UpdateItemQuality(Item item)
    {
        DecrementQuality(item);
        
        // items degrade twice as fast once passed their sell by date
        if (item.SellIn < 0)
        {
            DecrementQuality(item);
        }
    }

    private void DecrementQuality(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality -= 1;
        }
    }
}