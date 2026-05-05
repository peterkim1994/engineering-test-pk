using GildedRose.Console.Types;

namespace GildedRose.Console.ItemUpdaters;

public class EventTicketsQualityUpdater() : IItemQualityUpdater
{
    public void UpdateItemQuality(Item item)
    {
        // Event is assumed to be tomorrow if SellIn is zero
        var hasEventOccured = item.SellIn is < 0;
        if (hasEventOccured)
        {
            item.Quality = 0;
            return;
        }
        
        // variables have been named with the assumption that item.SellIn's value is for the next business day.
        var hasMoreThan10FullBusinessDayLeftToSell = item.SellIn is > 9;
        var hasSixToTenFullBusinessDaysLeftToSell = item.SellIn is >= 5 and < 10;
        var fiveFullBusinessDaysOrLessLeftToSell = item.SellIn is < 5 && !hasEventOccured;
        
        if (hasMoreThan10FullBusinessDayLeftToSell)
        {
            item.Quality += 1;
        } 
        else if (hasSixToTenFullBusinessDaysLeftToSell)
        {
            item.Quality += 2;
        } 
        else if (fiveFullBusinessDaysOrLessLeftToSell)
        {
            item.Quality += 3;
        }

        if (item.Quality > ItemConstants.StandardQualityLimit)
        {
            item.Quality = ItemConstants.StandardQualityLimit;
        }
    }
}