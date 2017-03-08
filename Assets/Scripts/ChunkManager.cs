using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    [Header("Prefabs")]

    [SerializeField]
    private List<GameObject> _chunkPrefabs;

    [Space(10)]
    [SerializeField]
    private GameObject _backgroundPrefab;

    [SerializeField]
    private GameObject _startChunk;

    /*[SerializeField]
    private GameObject _rockPrefab;*/

    [SerializeField]
    private GameObject _warningPrefab;

    [Header("Parameters")]

    [SerializeField]
    private float _maxChunkSpawnOffset = 1f;

    [SerializeField]
    private float _chunkSpawnOffsetInterval = 0.2f;

    /*[SerializeField]
    private float _minRockSpawnTimer = 2f;*/

    /*[SerializeField]
    private float _maxRockRespawnTimer = 6f;*/

    /*[SerializeField]
    private float _rockSpawnOffset = 6f;*/

    //======================================================
    //
    //======================================================

    private List<ChunkScript> _chunks = new List<ChunkScript>();
    private List<ChunkScript> _backgrounds = new List<ChunkScript>();
    private List<float> _chunkSpawnXPositions = new List<float>();

    //======================================================
    //
    //======================================================

    // Use this for initialization
    void Start()
    {
        _chunkPrefabs.AddRange(GameManagerScript.Instance.EnvironmentChunks);
        _chunkPrefabs.AddRange(GameManagerScript.Instance.EnvironmentChunks);

        _chunks.Add(_startChunk.GetComponent<ChunkScript>());

        GameObject newBackground = Instantiate<GameObject>(_backgroundPrefab, this.transform);
        ChunkScript bgScript = newBackground.GetComponent<ChunkScript>();
        _backgrounds.Add(bgScript);

        //**********************************

        _chunkSpawnXPositions.Add(0);

        float possibleChunkXPos = _chunkSpawnOffsetInterval;

        while (possibleChunkXPos <= _maxChunkSpawnOffset)
        {
            _chunkSpawnXPositions.Add(possibleChunkXPos);
            possibleChunkXPos += _chunkSpawnOffsetInterval;
        }

        possibleChunkXPos = -_chunkSpawnOffsetInterval;

        while (possibleChunkXPos >= -_maxChunkSpawnOffset)
        {
            _chunkSpawnXPositions.Add(possibleChunkXPos);
            possibleChunkXPos -= _chunkSpawnOffsetInterval;
        }

        if (GameManagerScript.Instance.SpawnRocks)
        {
            Invoke("SpawnRock", Random.Range(GameManagerScript.Instance.MinRockSpawnTimer, GameManagerScript.Instance.MaxRockSpawnTimer));
        }
    }

    //======================================================
    //
    //======================================================

    // Update is called once per frame
    void Update()
    {
        //**********************************************
        // chunk spawning

        Camera camera = Camera.main;

        float cameraUpperYPos = camera.transform.position.y + camera.orthographicSize;
        float chunksUpperYPos = _chunks[_chunks.Count - 1].TopPosition.y;

        if (cameraUpperYPos + 1 >= chunksUpperYPos)
        {
            int randomIndex = Random.Range(0, _chunkPrefabs.Count - 1);
            GameObject newChunk = Instantiate<GameObject>(_chunkPrefabs[randomIndex], this.transform);
            ChunkScript newChunkScript = newChunk.GetComponent<ChunkScript>();

            float newChunkHalfHeight = Mathf.Abs(newChunkScript.BottomPosition.y - newChunkScript.transform.position.y);
            float newChunkXPos = _chunkSpawnXPositions[Random.Range(0, _chunkSpawnXPositions.Count - 1)];

            newChunk.transform.position = new Vector3(newChunkXPos, chunksUpperYPos + newChunkHalfHeight);

            _chunks.Add(newChunkScript);
        }

        //**********************************************
        // bg spawning

        float bgsUpperYPos = _backgrounds[_backgrounds.Count - 1].TopPosition.y;

        if (cameraUpperYPos + 1 >= bgsUpperYPos)
        {
            GameObject newBackground = Instantiate<GameObject>(_backgroundPrefab, this.transform);
            ChunkScript bgScript = newBackground.GetComponent<ChunkScript>();

            float newBackgroundHalfHeight = Mathf.Abs(bgScript.BottomPosition.y - bgScript.transform.position.y);
            newBackground.transform.position = new Vector3(0, bgsUpperYPos + newBackgroundHalfHeight);

            _backgrounds.Add(bgScript);
        }

        //**********************************************
        // chunk despawning

        ChunkScript oldestChunk = _chunks[0];
        float cameraBottomYPos = camera.transform.position.y - camera.orthographicSize;
        float oldestChunkTopYPos = oldestChunk.TopPosition.y;

        if (cameraBottomYPos > oldestChunkTopYPos)
        {
            _chunks.Remove(oldestChunk);
            Destroy(oldestChunk.gameObject);
        }

        //**********************************************
        // bg despawning

        ChunkScript oldestBg = _backgrounds[0];
        float oldestBgTopYPos = oldestBg.TopPosition.y;

        if (cameraBottomYPos > oldestBgTopYPos)
        {
            _backgrounds.Remove(oldestBg);
            Destroy(oldestBg.gameObject);
        }
    }

    //======================================================
    //
    //======================================================

    private void SpawnRock()
    {
        float halfScreenWidth = ((Camera.main.orthographicSize * 2) / Camera.main.pixelHeight) * Camera.main.pixelWidth * 0.5f;

        float yPos = Camera.main.transform.position.y + Camera.main.orthographicSize + GameManagerScript.Instance.RockSpawnOffset;
        float xPos = Random.Range(Camera.main.transform.position.x-halfScreenWidth, Camera.main.transform.position.x+halfScreenWidth);

        //Debug.Log("Spawning Rock, xPos=" + xPos);

        GameObject rock = Instantiate(GameManagerScript.Instance.RockPrefab, this.transform);
        rock.transform.position = new Vector3(xPos, yPos);

        GameObject warning = Instantiate(_warningPrefab, this.transform);
        warning.GetComponent<RockWarningScript>().Initialize(rock.transform);

        Invoke("SpawnRock", Random.Range(GameManagerScript.Instance.MinRockSpawnTimer, GameManagerScript.Instance.MaxRockSpawnTimer));
    }
}
