﻿using System;
using System.Collections.Generic;
using Extentions;
using UnityEngine;

namespace Gameplay
{
    public class Pause : MonoBehaviour
    {
        private readonly List<MonoBehaviour> _pauseSources = new List<MonoBehaviour>();

        public bool IsPaused => _pauseSources.Count > 0;
        
        public void PauseFromSource(MonoBehaviour source)
        {
            if (_pauseSources.Contains(source))
                return;
            _pauseSources.Add(source);
        }

        public void UnpauseFromSource(MonoBehaviour source)
        {
            if ( ! _pauseSources.Contains(source))
                return;
            _pauseSources.Remove(source);
        }
    }
}