namespace GildedRose.Console.ItemUpdaters;

public class ConjuredItemQualityUpdater(ItemQualityDegrader qualityUpdater) : IItemQualityUpdater
{
    public void UpdateItemQuality(Item item)
    {
        // Conjured items degrade twice as fast as normal items
        qualityUpdater.UpdateItemQuality(item);
        qualityUpdater.UpdateItemQuality(item);
    }
}