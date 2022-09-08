using System.Collections.Generic;
using UnityEngine;

namespace Configs {
    [CreateAssetMenu(fileName = "ShopConfig", menuName = "Configs/ShopConfig", order = 0)]
    public class ShopConfig : ScriptableObject {
        public List<ShopItemDescription> ShopItemDescriptions;
    }
}