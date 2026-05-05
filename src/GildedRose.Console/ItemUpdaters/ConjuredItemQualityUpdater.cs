namespace GildedRose.Console.ItemUpdaters;

public class ConjuredItemQualityUpdater(IItemQualityUpdater qualityDegrader) : IItemQualityUpdater
{
    public void UpdateItemQuality(Item item)
    {
        // Conjured items degrade twice as fast as normal items
        qualityDegrader.UpdateItemQuality(item);
        qualityDegrader.UpdateItemQuality(item);
    }
}