using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Items
{
    public class UserItem : MonoBehaviour
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public Sprite Icon { get; private set; }
    }
}
