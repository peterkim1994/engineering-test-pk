namespace GildedRose.Console;
﻿using GildedRose.Console.ItemUpdaters;

public class Program
{
    public IList<Item> Items = new List<Item>();

    private static void Main(string[] args)
    {
        System.Console.WriteLine("OMGHAI!");

        var app = new Program
        {
            Items = new List<Item>
            {
                new() { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new() { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new() { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new() { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
            }
        };

        app.UpdateQuality();

        System.Console.ReadKey();
    }

    public void UpdateQuality()
    {
        var itemUpdater = new ItemUpdater();
        foreach (var item in Items)
        {
            itemUpdater.UpdateItem(item);
            System.Console.WriteLine($"{item.Name} sellin: {item.SellIn}  quality: {item.Quality}");
        }
    }
}

public class Item
{
    public string Name { get; set; } = "";

    public int SellIn { get; set; }

    public int Quality { get; set; }
}