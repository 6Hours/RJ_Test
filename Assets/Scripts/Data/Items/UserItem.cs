using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Items
{
    public class UserItem : BaseItem
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public Sprite Icon { get; private set; }

        public UserItem(long id, string name, Sprite icon)
        {
            Id = id;
            Name = name;
            Icon = icon;
        }
    }
}
