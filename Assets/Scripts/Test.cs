using System;
using System.Collections;
using System.Collections.Generic;
using NewNamespace;


namespace Geekbrains
{
    using UnityEngine;
    using static TestStatic;
    public static class TestStatic
    {
        public static void Do(){}
    }
    
    
    public class Test : MonoBehaviour
    {
        private GoodBonus[] _bonus;
        Player player;
        private void Start()
        {
            // var objects = new ListInteractableObject();
            //
            // for (int i = 0; i < objects.Count; i++)
            // {
            //     print($"{objects[i]}");
            // }
            player = GetComponent<PlayerMoveNew>();
            player.Move();
            Array.Sort(_bonus, new GoodBonusComparer());
            var bonuses = new BonusIndexer();
            Do();
            var goodBonus = bonuses[0];
        }

        public class BonusIndexer
        {
            private GoodBonus[] _bonuses;
            public GoodBonus this[int a] => _bonuses[a];
        }

        public class ComparerTest : IComparable
        {
            public int A;
            
            public int CompareTo(object obj)
            {
                var t = (ComparerTest) obj;
                if (t.A > A)
                    return 1;
                if (t.A < A)
                    return -1;
                return 0;
            }
        }

        
        
        

        #region Operators

        public class OperatorTest
        {
            public int A;

            
            public static implicit operator ForEachTest(OperatorTest a) => new ForEachTest();
        }

        #endregion

        #region ForEach

        public class ForEachTest
        {
            public Enumerator GetEnumerator() => new Enumerator();
        }
        
        public class Enumerator
        {
            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public object Current { get; }
        }
        
        public class Cars : IEnumerable, IEnumerator<Cars.Car>
        {
            private Car[] _carlist;
            private int _position = -1;

            private Car _current;

            //Create internal array in constructor.
            public Cars()
            {
                _carlist= new Car[6]
                {
                    new Car("Ford",1992),
                    new Car("Fiat",1988),
                    new Car("Buick",1932),
                    new Car("Ford",1932),
                    new Car("Dodge",1999),
                    new Car("Honda",1977)
                };
            }
            //IEnumerator and IEnumerable require these methods.
            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)this;
            }
            //IEnumerator
            public bool MoveNext()
            {
                _position++;
                return (_position < _carlist.Length);
            }
            
            public void Reset() => _position = -1;

            Car IEnumerator<Car>.Current => _current;

            //IEnumerable
            public object Current => _carlist[_position];

            public class Car
            {
                private int year;
                private string make;
                public Car(string Make,int Year)
                {
                    make=Make;
                    year=Year;
                }
                public int Year
                {
                    get  {return year;}
                    set {year=value;}
                }
                public string Make
                {
                    get {return make;}
                    set {make=value;}
                }

                
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
