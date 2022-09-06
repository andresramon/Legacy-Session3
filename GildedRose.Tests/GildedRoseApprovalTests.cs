using System.Collections.Generic;
using ApprovalTests.Combinations;
using ApprovalTests.Reporters;
using GildedRoseKata;
using Xunit;

namespace GildedRose.Tests;


[UseReporter(typeof(DiffReporter))]
public class GildedRoseApprovalTests
{
    [Fact]
    public void UpdateQuality()
    {
        string[] itemsName = {"Aged Brie", "foo","Backstage passes to a TAFKAL80ETC concert","Sulfuras, Hand of Ragnaros"};
        int[] sellInValues = {-1,0, 1,6,11};
        int[] qualityValues = {-1,0,1,49,50};
        CombinationApprovals.VerifyAllCombinations(
            doUpdateQuality,
            itemsName,
            sellInValues,
            qualityValues);
    }

    private static string doUpdateQuality(string itemName, int sellIn, int quality)
    {
        IList<Item> Items = new List<Item> {new Item {Name = itemName, SellIn = sellIn, Quality = quality}};
        GildedRoseKata.GildedRose app = new GildedRoseKata.GildedRose(Items);
        app.UpdateQuality();

        return ItemToString(Items[0]);
    }


    private static string ItemToString(Item item)
    {
        return $"{item.Name},{item.SellIn},{item.Quality}";
    }
}