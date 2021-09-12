using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    GManager gameManager;
    BlockManager blockManager;

    Vector3 offsetUp, offsetDown, offsetRight, offsetLeft;

    public bool isMatching = false;
    private bool freezing = false;

    public int[] coodinate;

    private void Start()
    {
        gameManager = GManager.GameManager;
        blockManager = BlockManager.BManager;

        coodinate = new int[] { (int)(transform.position.x / blockManager.blockSize), (int)(transform.position.y / blockManager.blockSize) };

        offsetUp = new Vector3(0, (blockManager.blockSize /2) + 0.01f);
        offsetDown = offsetUp * -1;
        offsetRight = new Vector3((blockManager.blockSize /2) + 0.01f, 0);
        offsetLeft = offsetRight * -1;
    }

    private void OnMouseDown()
    {
        Move();
        freezing = true;
        while(freezing)
        {
            Debug.Log("CheckMatching");
            blockManager.CheckMatching();
            Debug.Log(blockManager.deleteList.Count);
            if(blockManager.deleteList.Count > 0)
            {
                Debug.Log("Delete");
                blockManager.Delete();
                blockManager.deleteList.Clear();
            }
            else
            {
                Debug.Log("Ready to move");
                freezing = false;
            }
        }
    }

    private void Move()
    {
        if(!freezing)
        {
            RaycastHit2D hitUp = Physics2D.Raycast(transform.position + offsetUp, Vector2.up, 0.3f);
            if (!hitUp)
            {
                var x = (int)(transform.position.x / blockManager.blockSize);
                var y = (int)(transform.position.y / blockManager.blockSize);
                blockManager.blockArray[x, y + 1] = this.gameObject;
                blockManager.blockArray[x, y] = null;
                transform.position += new Vector3(0, blockManager.blockSize);
                coodinate[0] = x;
                coodinate[1] = y + 1;
                Debug.Log(blockManager.blockArray[x, y + 1].name);
            }

            RaycastHit2D hitDown = Physics2D.Raycast(transform.position + offsetDown, Vector2.down, 0.3f);
            if (!hitDown)
            {
                var x = (int)(transform.position.x / blockManager.blockSize);
                var y = (int)(transform.position.y / blockManager.blockSize);
                blockManager.blockArray[x, y - 1] = this.gameObject;
                blockManager.blockArray[x, y] = null;
                transform.position += new Vector3(0, -blockManager.blockSize);
                coodinate[0] = x;
                coodinate[1] = y - 1;
                Debug.Log(blockManager.blockArray[x, y - 1].name);
            }

            RaycastHit2D hitRight = Physics2D.Raycast(transform.position + offsetRight, Vector2.right, 0.3f);
            if (!hitRight)
            {
                var x = (int)(transform.position.x / blockManager.blockSize);
                var y = (int)(transform.position.y / blockManager.blockSize);
                blockManager.blockArray[x + 1, y] = this.gameObject;
                blockManager.blockArray[x, y] = null;
                transform.position += new Vector3(blockManager.blockSize, 0);
                coodinate[0] = x + 1;
                coodinate[1] = y;
                Debug.Log(blockManager.blockArray[x + 1, y].name);
            }

            RaycastHit2D hitLeft = Physics2D.Raycast(transform.position + offsetLeft, Vector2.left, 0.3f);
            if (!hitLeft)
            {
                var x = (int)(transform.position.x / blockManager.blockSize);
                var y = (int)(transform.position.y / blockManager.blockSize);
                blockManager.blockArray[x - 1, y] = this.gameObject;
                blockManager.blockArray[x, y] = null;
                transform.position += new Vector3(-blockManager.blockSize, 0);
                coodinate[0] = x - 1;
                coodinate[1] = y;
                Debug.Log(blockManager.blockArray[x - 1, y].name);
            }
        }
    }
}
