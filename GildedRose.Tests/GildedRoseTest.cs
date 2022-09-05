using System.Collections.Generic;
using GildedRoseKata;
using Xunit;

namespace GildedRose.Tests
{
    public class GildedRoseTest
    {
        [Fact]
        public void TestRandomBehaviour()
        {
            Assert.True(true);
        }

        [Fact]
        public void DecrementQualityOnce()
        {
            var item = new Item {Name = "TestOneItem", SellIn = 10, Quality = 20};
            IList<Item> Items = new List<Item>{
                item,
            };
           
            var app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();
            int expected = 19;
            Assert.Equal(expected,item.Quality);
        }

        [Fact]
        public void NotDecrementQualityWhenZero()
        {
            var item = new Item {Name = "TestOneItem", SellIn = 10, Quality = 0};
            IList<Item> Items = new List<Item>{
                item,
            };
           
            var app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();
            int expected = 0;
            Assert.Equal(expected,item.Quality); 
        }
        
        [Fact]
        public void AgedBrieQualityIncreaseWithTime()
        {
            var item = new Item {Name = "Aged Brie", SellIn = 10, Quality = 0};
            IList<Item> Items = new List<Item>{
                item,
            };
           
            var app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();
            int expected = 1;
            Assert.Equal(expected,item.Quality); 
        } 
        
        [Fact]
        public void BackstageQualityIncreaseTwiceWithTimeWhenSellInIsFive()
        {
            var item = new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 0};
            IList<Item> Items = new List<Item>{
                item,
            };
           
            var app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();
            int expected = 3;
            Assert.Equal(expected,item.Quality); 
        }  
        
    }
}