﻿using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Geekbrains
{
    public class GoodBonus : InteractiveObject, IFlay, IFlicker, IEquatable<GoodBonus>
    {

        public int Point;
        private Material _material;
        private float _lengthFlay;
        private DisplayBonuses _displayBonuses;
        public static SavedData<string> SavedData = new();
        public static SavedData<int> SavedData2 = new();

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFlay = Random.Range(1.0f, 5.0f);
            _displayBonuses = new DisplayBonuses();
        }
        
        protected override void Interaction()
        {
            _displayBonuses.Display(5);
            SavedData.Bonuses += 1;
            SavedData.Id = SavedData.Bonuses.ToString();
            SavedData2.Id = Random.Range(1, 5);
            // Add bonus
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }
        
        //.....

        public bool Equals(GoodBonus other)
        {
            return Point == other.Point;
        }

    }
}
