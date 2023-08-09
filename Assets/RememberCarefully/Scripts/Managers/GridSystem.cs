using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

namespace RememberCarefully
{

    public class GridSystem : MonoBehaviour
    {
        public static GridSystem Instance { get; private set; }

        [Header("References")]
        [SerializeField] private HiddenBlock _hiddenBlockPrefab;

        [Header("Data")]
        private LevelData _levelData;

        [Header("Properties")]
        [SerializeField] private float _toggleTime = 0.5f;
        [SerializeField] private float _gridSpacing = 0.2f;

        [Header("Logic")]
        public int NumOfHiddenBlockShowed;

        // Cached
        private HiddenBlock[] _gridMap;



        private void Awake()
        {
            Instance = this;
        }



        private void Start()
        {
            LoadLevelData();
            CreateGrid();

            StartCoroutine(Utilities.WaitAfter(1.0f, () =>
            {
                StartCoroutine(PerformToggleWhenStart(()=>
                {
                    GameplayManager.Instance.ChangeGameState(GameplayManager.GameState.PLAYING);
                }));
            }));
            
        }


        private void LoadLevelData()
        {
            // Load Levedata from GameManger.
            this._levelData = GameManager.Instance.PlayingLevelData;

            var mainCam = Camera.main;
            mainCam.orthographicSize = _levelData.OrthographicCameraSize;         
            Vector3 newPosition = new Vector3(mainCam.transform.position.x + _levelData.CameraOffset.x, mainCam.transform.position.y + _levelData.CameraOffset.y, mainCam.transform.position.z);
            mainCam.transform.position = newPosition;

            _gridMap = new HiddenBlock[_levelData.Width * _levelData.Height];
        }

        private void CreateGrid()
        {
            int rows = _levelData.Width;
            int columns = _levelData.Height;

            // Calculate the center position of the nodes.
            Vector3 centerOffset = new Vector3((columns - 1) * _gridSpacing * 0.5f, -(rows - 1) * _gridSpacing * 0.5f, 0f);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Vector3 position = new Vector3(i * _gridSpacing, -j * _gridSpacing, 0f) - centerOffset;
                    _gridMap[i + rows * j] = Instantiate(_hiddenBlockPrefab, position, Quaternion.identity, this.transform);
                }
            }

            List<int> randomHiddenObjectList = GetRandomIndices(_gridMap.Length, _levelData.NumOfHiddenObjects);
            for(int i = 0; i < randomHiddenObjectList.Count; i++) 
            {
                _gridMap[randomHiddenObjectList[i]].HasHiddenObject = true;
            }
        }

        private IEnumerator PerformToggleWhenStart(System.Action callback)
        {
            for(int i = 0; i < _gridMap.Length; i++)
            {
                _gridMap[i].Toggle(_toggleTime);
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(1.0f);
            callback?.Invoke();
        }

        public bool IsWinning()
        {
            return NumOfHiddenBlockShowed == _levelData.NumOfHiddenObjects;
        }


        private List<int> GetRandomIndices(int listLength, int selectionCount)
        {
            if (selectionCount > listLength)
            {
                throw new System.ArgumentException("selectionCount cannot exceed listLength");
            }

            List<int> allIndices = new List<int>();
            for (int i = 0; i < listLength; i++)
            {
                allIndices.Add(i);
            }

            List<int> randomIndices = new List<int>();
            while (randomIndices.Count < selectionCount && allIndices.Count > 0)
            {
                int randomIndex = Random.Range(0, allIndices.Count);
                randomIndices.Add(allIndices[randomIndex]);
                allIndices.RemoveAt(randomIndex);
            }

            return randomIndices;
        }
    }
}

