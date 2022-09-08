﻿using UnityEngine;

namespace UI.Windows {
    public sealed class WindowBackground : MonoBehaviour {
        public void Show() {
            gameObject.SetActive(true);
        }

        public void Hide() {
            gameObject.SetActive(false);
        }
    }
}