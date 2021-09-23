using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public static BlockManager BManager { get; private set; }

    GManager gameManager;

    [SerializeField] private GameObject effect;
    [SerializeField] private TimeUI timer;
    [SerializeField] private GameObject[] blocks;
    [SerializeField] private CountDown count;

    private int width = 4;
    private int height = 4;
    public float blockSize = 1.152f;

    public GameObject[,] blockArray = new GameObject[4, 4];

    public List<GameObject> deleteList = new List<GameObject>();

    public int nextX;
    public int nextY;

    private bool setting = true;

    private void Awake()
    {
        if (BManager == null)
        {
            BManager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    async void Start()
    {
        gameManager = GManager.GameManager;
        Debug.Log("SetBlocks");
        SetBlocks();
        while(true)
        {
            Debug.Log("CheckMatching");
            CheckMatching();
            if (deleteList.Count > 0)
            {
                Debug.Log("Delete");
                Delete();
                deleteList.Clear();
            }
            else
            {
                setting = false;
                Debug.Log("Game Start!");
                break;
            }
        }
        await count.Count();
        gameManager.freezing = false;
        timer.SetTimer();
    }

    private void SetBlocks()
    {
        for(int i = 0; i < width; i++)
        {
            if(i < width - 1)
            {
                for(int j = 0; j < height; j++)
                {
                    int r = Random.Range(0, 4);
                    var block = Instantiate(blocks[r]);
                    block.transform.position = new Vector3(blockSize * i, blockSize * j);
                    blockArray[i, j] = block;
                }
            }
            else
            {
                for(int j = 0; j < height - 1; j++)
                {
                    int r = Random.Range(0, 4);
                    var block = Instantiate(blocks[r]);
                    block.transform.position = new Vector3(blockSize * i, blockSize * j);
                    blockArray[i, j] = block;
                }
            }
        }
    }

    public void CheckMatching()
    {
        //縦方向の確認
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height - 2; j++)
            {
                if(blockArray[i, j] != null && blockArray[i, j + 1] != null && blockArray[i, j + 2] != null)
                {
                    if (blockArray[i, j].tag == blockArray[i, j + 1].tag && blockArray[i, j].tag == blockArray[i, j + 2].tag)
                    {
                        blockArray[i, j].GetComponent<Block>().isMatching = true;
                        blockArray[i, j + 1].GetComponent<Block>().isMatching = true;
                        blockArray[i, j + 2].GetComponent<Block>().isMatching = true;
                    }
                }
            }
        }

        //横方向の確認
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width - 2; j++)
            {
                if (blockArray[j, i] != null && blockArray[j + 1, i] != null && blockArray[j + 2, i] != null)
                {
                    if (blockArray[j, i].tag == blockArray[j + 1, i].tag && blockArray[j, i].tag == blockArray[j + 2, i].tag)
                    {
                        blockArray[j, i].GetComponent<Block>().isMatching = true;
                        blockArray[j + 1, i].GetComponent<Block>().isMatching = true;
                        blockArray[j + 2, i].GetComponent<Block>().isMatching = true;
                    }
                }
            }
        }

        foreach (var item in blockArray)
        {
            if(item != null)
            {
                if(item.GetComponent<Block>().isMatching)
                {
                    deleteList.Add(item);
                }
            }
        }
    }

    public void Delete()
    {
        foreach (var item in deleteList)
        {
            if(!setting)
            {
                var instanse = Instantiate(effect);
                Debug.Log("Instantiate " + instanse.name);
                instanse.transform.position = new Vector3(item.transform.position.x, item.transform.position.y);
                instanse.GetComponentInChildren<Effect>().PlayEffect(item.tag);
            }
            blockArray[(int)(item.transform.position.x / blockSize), (int)(item.transform.position.y / blockSize)] = null;
            Destroy(item);
            nextX = (int)(item.transform.position.x / blockSize);
            nextY = (int)(item.transform.position.y / blockSize);

            SpawnNewBlock();
        }

        deleteList.Clear();
    }

    private void SpawnNewBlock()
    {
        int r = Random.Range(0, 4);
        Debug.Log($"Selected = {blocks[r].name}");
        var block = Instantiate(blocks[r]);
        block.transform.position = new Vector3(nextX * blockSize, nextY * blockSize);
        blockArray[nextX, nextY] = block;
    }
}
