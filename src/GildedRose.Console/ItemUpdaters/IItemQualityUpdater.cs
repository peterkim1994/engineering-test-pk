namespace GildedRose.Console.ItemUpdaters;

public interface IItemQualityUpdater
{
    /// <summary>
    /// Adjusts the item's quality based on number of full business days left to sell the item.
    /// </summary>
    public void UpdateItemQuality(Item item);
}