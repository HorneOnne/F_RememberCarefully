using UnityEngine;

namespace RememberCarefully
{
    [CreateAssetMenu(fileName = "LevelData_", menuName = "RememberCarefully/LevelData", order = 51)]
    public class LevelData : ScriptableObject
    {
        [Header("Level")]
        public Difficulty Difficulty;
        public int Level;
        public bool IsLocking;

        [Header("Camera zoom")]
        public float OrthographicCameraSize = 5;
        public Vector2 CameraOffset;

        [Header("Grid size")]
        public int Width;
        public int Height;
        public int NumOfHiddenObjects;
    }

    public enum Difficulty
    {
        EASY, NORMAL, HARD, EXPERT
    }
}

