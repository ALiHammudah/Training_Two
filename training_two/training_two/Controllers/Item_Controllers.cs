using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using training_two.Items;

namespace training_two.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class Item_Controllers
    {
        //SHOW ALL ITEMS DETAIL
        [HttpGet("show all Items")]
        public List<Item> showItems()
        {
            var context = new MyAppDbContext();

            context.Database.EnsureCreated();

            return context.items.ToList();
        }

        //GET AN ITEM BY ID
        [HttpGet("find Item by id")]
        public Item findItem(int id) 
        {
            var context = new MyAppDbContext();

            context.Database.EnsureCreated();

            return context.items.SingleOrDefault(i => i.Id == id);
        }

        //GET AN ID BY NAME
        [HttpGet("find Item by name")]
        public Item findItem(string name)
        {
            var context = new MyAppDbContext();

            context.Database.EnsureCreated();

            return context.items.SingleOrDefault( i => i.Name == name);
        }

        //SET A NEW ITEM
        [HttpPost("set Item detail")]
        public Item findItem(string name,double price,int count) 
        {
            var context = new MyAppDbContext();

            context.Database.EnsureCreated();

            Item t = context.items.SingleOrDefault(i => i.Name == name);

            if (t != null)
                return null;

            context.items.Add(
                new Item
                {
                    Name = name,
                    price = price,
                    countity = count
                });

            context.SaveChanges();

            return context.items.SingleOrDefault(i => i.Name == name);
        }


        //DELETE AN ITEM BY ITEM ID
        [HttpDelete("Delete an Item by Id")]
        public Item deletItemID(int id)
        {
            var context = new MyAppDbContext();

            context.Database.EnsureCreated();

            Item t = context.items.SingleOrDefault(i => i.Id == id);

            if (t == null)
                return null;

            context.items.Remove(t);

            context.SaveChanges();

            return t;
        }

        //DELETE AN ITEM BY ITEM NAME
        [HttpDelete("Delete an Item by name")]
        public Item deletItemName(string name)
        {
            var context = new MyAppDbContext();

            context.Database.EnsureCreated();

            Item t = context.items.SingleOrDefault(i => i.Name == name);

            if (t == null)
                return null;

            context.items.Remove(t);

            context.SaveChanges();

            return t;
        }

        //ADD AN EXIST ITEM. NOT : ADD A COUNNTITY
        [HttpPut("add Exist Item")]
        public Item addItem(string name)
        {
            var context = new MyAppDbContext();

            context.Database.EnsureCreated();

            Item t = context.items.SingleOrDefault(i => i.Name == name);
            if (t == null)
                return null;

            t.countity++;

            context.SaveChanges();

            return t;
        }

        //SELL AN ITEM, NOTE : COUNTITY DISCOUNT
        [HttpPut("sell an Item")]
        public Item sellItem(string name)
        {
            var context = new MyAppDbContext();

            context.Database.EnsureCreated();

            Item t = context.items.SingleOrDefault(i => i.Name == name);

            if (t == null || t.countity == 1)
                return null;

            t.countity--;

            context.SaveChanges();

            return t;
        }
    }
}
