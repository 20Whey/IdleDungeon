using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
namespace MapSpace
{
// Start is called before the first frame update
    [CreateAssetMenu(menuName = "MapModule")]
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
            Medium =1,
            Large =2
        }
    }
    public class MapContainer
    {
        internal Vector2 RelativePos;
        internal string Type;

        internal Color32 Clor;
        //internal Color pix;
        
        public MapContainer(Vector2 position, string type, Color32 clor)
        {
        RelativePos = position;
        Type = type;
        Clor = clor;
        }
    }

    
}
