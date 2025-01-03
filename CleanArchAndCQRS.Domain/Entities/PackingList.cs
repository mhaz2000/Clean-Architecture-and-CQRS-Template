﻿using CleanArchAndCQRS.Domain.Events;
using CleanArchAndCQRS.Domain.Exceptions;
using CleanArchAndCQRS.Domain.ValueObjects;
using CleanArchAndCQRS.Shared.Abstractions.Domain;

namespace CleanArchAndCQRS.Domain.Entities
{
    public sealed class PackingList : AggregateRoot<PackingListId>
    {
        public PackingListId Id { get; private set; }

        public PackingListName _name;
        public Localization _localization;

        private readonly LinkedList<PackingItem> _items = new();

        public PackingList()
        {
            
        }

        internal PackingList(Guid id, PackingListName name, Localization localization)
        {
            Id = id;
            _name = name;
            _localization = localization;

        }

        public void AddItem(PackingItem item)
        {
            var alreadyExists = _items.Any(i => i.Name == item.Name);
            if (alreadyExists)
                throw new PackingItemAlreadyExistsException(_name, item.Name);

            _items.AddLast(item);
            AddEvent(new PackingItemAdded(this, item));
        }

        public void AddItems(IEnumerable<PackingItem> items)
        {
            foreach (var item in items)
                AddItem(item); 
        }

        public void PackItem(string itemName)
        {
            var item = GetItem(itemName);
            var packedItem = item with { IsPacked = true };

             _items.Find(item)!.Value = packedItem;
            AddEvent(new PackingItemPacked(this, item));
        }

        public void RemoveItem(string itemName)
        {
            var item = GetItem(itemName);
            _items.Remove(item);

            AddEvent(new PackingItemRemoved(this, item));
        }

        private PackingItem GetItem(string itemName)
        {
            var item = _items.SingleOrDefault(i => i.Name == itemName);

            if (item is null)
                throw new PackingItemNotFoundException(itemName);

            return item;
        }
    }
}
