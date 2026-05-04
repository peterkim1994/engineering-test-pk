namespace GildedRose.Console.ItemUpdaters;

public class ItemUpdater
{
    private static readonly IReadOnlyList<string> AppreciatingQualityItemNames = new List<string>()
    {
        "Aged Brie"
    };

    private static readonly IReadOnlyList<string> StaticQualityItemNames = new List<string>()
    {
        "Sulfuras, Hand of Ragnaros"
    };
    
    private static readonly IReadOnlyList<string> EventTicketItemNames = new List<string>()
    {
        "Backstage passes to a TAFKAL80ETC concert"
    };
    
    /// <summary>
    /// Decrements the item's SellIn for next business day and adjusts the items quality accordingly.
    /// </summary>
    public void UpdateItem(Item item)
    {
        bool hasUpdateRequirement = !StaticQualityItemNames.Contains(item.Name);
        if (!hasUpdateRequirement)
        {
            return;
        }

        item.SellIn -= 1;

        IItemQualityUpdater updater = GetItemQualityUpdater(item.Name);
        updater.UpdateItemQuality(item);
    }

    private IItemQualityUpdater GetItemQualityUpdater(string itemName)
    {
        bool isEventTicket = EventTicketItemNames.Contains(itemName);
        if (isEventTicket)
        {
            return new EventTicketsQualityUpdater();
        }
        
        bool itemAppreciatesInQuality = AppreciatingQualityItemNames.Contains(itemName);
        if (itemAppreciatesInQuality)
        {
            return new ItemQualityAppreciater();
        }

        bool isConjuredItem = itemName.StartsWith("Conjured ");
        if (isConjuredItem)
        {
            return new ConjuredItemQualityUpdater(new ItemQualityDegrader());
        }
        
        return new ItemQualityDegrader();
    }
}