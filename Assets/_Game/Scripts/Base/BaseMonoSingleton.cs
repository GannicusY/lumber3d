using System;
using UnityEngine;

namespace _Game.Scripts.Base
{
    public abstract partial class BaseMonoSingleton<T>: MonoBehaviour {
        public static T Instance { get; private set; }

        void Awake() {
            Instance = (T)((object)this);
            DoAwake();
        }

        public virtual void DoAwake() {
        }
    }
}