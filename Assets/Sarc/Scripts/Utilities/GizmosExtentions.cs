using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Extensions {
    public static class GizmosExtensions {
        public static void DrawWireSquare(Vector2 size, Color color, Vector3 offset = default) {
            Vector3 topRight = new Vector3(size.x, size.y) + offset;
            Vector3 topLeft = new Vector3(-size.x, size.y) + offset;
            Vector3 bottomRight = new Vector3(size.x, -size.y) + offset;
            Vector3 bottomLeft = new Vector3(-size.x, -size.y) + offset;

            Vector3[] points = new Vector3[5] { topRight, topLeft, bottomLeft, bottomRight, topRight };
            Color[] colors = new Color[5] { color, color, color, color, color };

            Handles.DrawAAPolyLine(colors, points);
        }
    }

    public static class EnumExtensions {
        public static T GetEnumWithHighestValue<T>(Dictionary<T, int> dictionary) where T : Enum {
            T maxEnum = default;
            int maxValue = int.MinValue;

            foreach (var kvp in dictionary) {
                if (kvp.Value > maxValue) {
                    maxEnum = kvp.Key;
                    maxValue = kvp.Value;
                }
            }

            return maxEnum;
        }

        public static T GetNextEnumValue<T>(T currentValue) where T : Enum {
            T[] values = (T[])Enum.GetValues(typeof(T));
            int currentIndex = Array.IndexOf(values, currentValue);
            int nextIndex = (currentIndex + 1) % values.Length;
            return values[nextIndex];
        }

        private static readonly System.Random random = new();

        public static T GetRandomEnumValue<T>() {
            if (!typeof(T).IsEnum) {
                throw new ArgumentException("Type T must be an enum type");
            }

            Array enumValues = Enum.GetValues(typeof(T));

            int randomIndex = random.Next(enumValues.Length);

            return (T)enumValues.GetValue(randomIndex);
        }

    }

    public static class IntExtensions {
        public static int RandomRangeInclusive(this int min, int max) {
            return UnityEngine.Random.Range(min, max + 1);
        }
    }
}