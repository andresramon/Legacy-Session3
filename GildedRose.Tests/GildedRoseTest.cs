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
            CheckQuality("TestOneItem", 10, 20, 19);
          
        }

        [Fact]
        public void NotDecrementQualityWhenZero()
        {
            CheckQuality("TestOneItem", 10, 0,0);
        
        }
        
        [Fact]
        public void AgedBrieQualityIncreaseWithTime()
        {
            CheckQuality("Aged Brie", 10, 0, 1);
          
        } 
        
        [Fact]
        public void BackstageQualityIncreaseTwiceWithTimeWhenSellInIsFive()
        {
            CheckQuality("Backstage passes to a TAFKAL80ETC concert", 5, 0, 3);
        }
        
        [Fact]
        public void SulfurasSellInNoChanges()
        {
            var item = new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80};
            IList<Item> Items = new List<Item>{
                item,
            };
           
            var app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();
            int expected = 5;
            Assert.Equal(expected,item.SellIn); 
        }

        [Fact]
        public void NoSulfurasSellInChanges()
        {
            var item = new Item {Name = "Other", SellIn = 5, Quality = 80};
            IList<Item> Items = new List<Item>{
                item,
            };
           
            var app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();
            int expected = 4;
            Assert.Equal(expected,item.SellIn); 
        }
        private static void CheckQuality(string nameItem, int sellIn, int quality, int expectedQuality )
        {
            var item = new Item { Name = nameItem, SellIn = sellIn, Quality = quality };
            IList<Item> Items = new List<Item>
            {
                item,
            };

            var app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();
            int expected = expectedQuality;
            Assert.Equal(expected, item.Quality);
        }

        [Theory]
        [InlineData("Aged Brie", 1, 5,2 )]
        [InlineData("Aged Brie", 1, 6,2)]
        [InlineData("Aged Brie",50,2, 50)]
        [InlineData("Aged Brie",0,2, 1)]
        [InlineData("Aged Brie",0,0, 2)]
        public void AgedBrieQualityChanges(string ItemName, int quality, int sellIn, int expectedQuality)
        {
            var item = new Item {Name = ItemName, SellIn = sellIn, Quality = quality};
            IList<Item> Items = new List<Item>{
                item,
            };
           
            var app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();
            int expected = expectedQuality;
            Assert.Equal(expected,item.Quality); 
        } 
        
        [Theory]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 1, 5,4 )]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 1, 6,3)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert",50,2, 50)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert",0,2, 3)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert",0,0, 0)]
        public void BackstageQualityChanges(string ItemName, int quality, int sellIn, int expectedQuality)
        {
            var item = new Item {Name = ItemName, SellIn = sellIn, Quality = quality};
            IList<Item> Items = new List<Item>{
                item,
            };
           
            var app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();
            int expected = expectedQuality;
            Assert.Equal(expected,item.Quality); 
        } 
        
        [Theory]
        [InlineData("OtherName", 1, 5,0 )]
        [InlineData("OtherName", 1, 0,0 )]
        [InlineData("OtherName", 2, 0,0 )]
        public void OtherNameQualityChanges(string ItemName, int quality, int sellIn, int expectedQuality)
        {
            var item = new Item {Name = ItemName, SellIn = sellIn, Quality = quality};
            IList<Item> Items = new List<Item>{
                item,
            };
           
            var app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();
            int expected = expectedQuality;
            Assert.Equal(expected,item.Quality); 
        }
        
        [Theory]
        // -1, 5, 10, 12
        [InlineData("OtherName", 1, -1,0 )]
        [InlineData("OtherName", 1, 5,0 )]
        [InlineData("OtherName", 1, 10,0 )]
        [InlineData("OtherName", 1, 12,0 )]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 1, -1, 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 1, 5, 4)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 1, 10, 3)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 1, 12, 2)]
        [InlineData("Aged Brie", 1, -1, 3)]
        [InlineData("Aged Brie", 1, 5, 2)]
        [InlineData("Aged Brie", 1, 10, 2)]
        [InlineData("Aged Brie", 1, 12, 2)]
        
        [InlineData("Sulfuras, Hand of Ragnaros", 80, -1, 80)]
        [InlineData("Sulfuras, Hand of Ragnaros", 80, 5, 80)]
        [InlineData("Sulfuras, Hand of Ragnaros", 80, 10, 80)]
        [InlineData("Sulfuras, Hand of Ragnaros", 80, 12, 80)]
        public void sellInIterationQualityChanges(string ItemName, int quality, int sellIn, int expectedQuality)
        {
            var item = new Item {Name = ItemName, SellIn = sellIn, Quality = quality};
            IList<Item> Items = new List<Item>{
                item,
            };
           
            var app = new GildedRoseKata.GildedRose(Items);
            app.UpdateQuality();
            int expected = expectedQuality;
            Assert.Equal(expected,item.Quality);
        }
        
        
    }
}