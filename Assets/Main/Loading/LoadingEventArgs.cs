using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wanderer.GameFramework;

namespace Main.Loading
{
    public class LoadingEventArgs : GameEventArgs<LoadingEventArgs>
    {
        /// <summary>
        /// ��������
        /// </summary>
        public string Tips;
        /// <summary>
        /// �������ؽ���
        /// </summary>
        public float Progress;
    }
}