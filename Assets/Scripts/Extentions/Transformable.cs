using System;
using UnityEngine;

namespace Extentions
{
    public class Transformable : MonoBehaviour
    {
        private Transform _transform;
        
        public Transform Transform => _transform ??= gameObject.transform;

        [Obsolete]
        public new Transform transform => Transform;
    }
}