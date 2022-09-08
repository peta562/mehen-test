﻿using System.Collections.Generic;
 using UnityEngine;

namespace Infrastructure.Services.AssetManagement {
    public interface IAssetProvider : IService {
        GameObject Instantiate(string path, Transform parent);
        GameObject Instantiate(string path);
        List<GameObject> InstantiateAll(string path, Transform parent);
    }
}