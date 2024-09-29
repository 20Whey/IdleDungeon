using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
namespace MapSpace
{

    public class MapContainer
    {
        internal Vector3 RelativePos;
        internal string Type;
        //internal Color pix;
        
        public MapContainer(Vector3 position, string type)
        {
        RelativePos = position;
        Type = type;
        }
    }

    // Start is called before the first frame update
    [CreateAssetMenu(fileName = "MapPiece", menuName = "MapModule")]
    public class MapModule : ScriptableObject
    {
        [Tooltip("Remember to import as a bitmap image!")]
        public Texture2D mapSprite;
        [Tooltip("What Special Properties Does this have?")]
        public List<KeyInfo> keyInformation;
        public string spriteName;
        [Tooltip("8x8, 12x12, 16x16")]
        public RmSize declaredSize;
        [Tooltip("in 90 degree rotations")]
        [SerializeField] private Rotation currentRotation;
        [Tooltip("Does nothing right now, but will help logic")]
        public SpecificShape specificShape;
        //Defines how reader will interpret image
        public enum KeyInfo{
            SpecialShape,
            SpecialType,
            NotSpawnable,
            Corridor,
            NotApplicable
        }
        public enum SpecificShape
        {
            Square,
            LShape,
            TShape,
            Rectangle,
            Circle
        }

        private enum Rotation
        {
            Base,
            Left,
            Right,
            Flipped
        }
        public enum RmSize
        {
            Small =0,
            Medium ,
            Large
        }
    }
}
