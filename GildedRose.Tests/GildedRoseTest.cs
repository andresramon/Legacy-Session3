﻿using System.Collections.Generic;
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
    }
}