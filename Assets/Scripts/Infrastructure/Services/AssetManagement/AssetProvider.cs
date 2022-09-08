﻿using System.Collections.Generic;
 using UnityEngine;

namespace Infrastructure.Services.AssetManagement {
    public sealed class AssetProvider : IAssetProvider {
        public GameObject Instantiate(string path, Transform parent) {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, parent);
        }

        public GameObject Instantiate(string path) {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        public List<GameObject> InstantiateAll(string path, Transform parent) {
            var prefabs = Resources.LoadAll<GameObject>(path);
            
            var result = new List<GameObject>();
            foreach (var prefab in prefabs) {
                result.Add(Object.Instantiate(prefab, parent));
            }

            return result;
        }
    }
}