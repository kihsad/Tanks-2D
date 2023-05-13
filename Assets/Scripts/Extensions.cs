
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tanks
{
    public static class Extensions
    {
        public static Dictionary<DirectionType, Vector3> _directions;
        public static Dictionary<DirectionType, Vector3> _rotations;

        static Extensions()
        {
            _directions = new Dictionary<DirectionType, Vector3> 
            {
                { DirectionType.Up, new Vector3(0f,1f,0f) },
                { DirectionType.Right, new Vector3(1f,0f,0f) },
                { DirectionType.Down, new Vector3(0f,-1f,0f) },
                { DirectionType.Left, new Vector3(-1f,0f,0f) },
                { DirectionType.Error, new Vector3(0f,0f,0f) }

            };

            _rotations = new Dictionary<DirectionType, Vector3>
            {  
                { DirectionType.Up, new Vector3(0f,0f,0f) },
                { DirectionType.Right, new Vector3(0f,0f,270f) },
                { DirectionType.Down, new Vector3(0f,0f,180f) },
                { DirectionType.Left, new Vector3(0f,0f,90f) },
                { DirectionType.Error, new Vector3(0f,0f,0f) }

            };


        }

        public static Vector3 ConvertTypeFromDirection (DirectionType type) => _directions[type];
        public static DirectionType ConvertDirectionFromType (this Vector3 direction) => _directions.First(t => t.Value == direction).Key;

        public static DirectionType ConvertDirectionFromType (this Vector2 direction) // Vector2 converter
        {
            var dir = (Vector3)direction;
            return _directions.First(t => t.Value == dir).Key;
        }

        public static Vector3 ConvertTypeFromRotation(DirectionType type) => _rotations[type];

        public static DirectionType  ConvertRotationFromType (Vector3 rotation) => _rotations.First(t =>t.Value == rotation).Key;


    }

    public enum SideType : byte { None, Player, Enemy }

    public enum DirectionType : byte { Error, Up, Right, Down, Left }


}
