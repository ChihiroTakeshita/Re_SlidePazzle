using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Block : MonoBehaviour
{
    GManager gameManager;
    BlockManager blockManager;

    Vector3 offsetUp, offsetDown, offsetRight, offsetLeft;

    public bool isMatching = false;
    private static bool freezing = false;
    private static int interval = 0;

    private void Start()
    {
        gameManager = GManager.GameManager;
        blockManager = BlockManager.BManager;

        offsetUp = new Vector3(0, (blockManager.blockSize /2) + 0.01f);
        offsetDown = offsetUp * -1;
        offsetRight = new Vector3((blockManager.blockSize /2) + 0.01f, 0);
        offsetLeft = offsetRight * -1;
    }

    private async void OnMouseDown()
    {
        if(!freezing)
        {
            Move();
            freezing = true;
            while (freezing)
            {
                Debug.Log("CheckMatching");
                blockManager.CheckMatching();
                Debug.Log(blockManager.deleteList.Count);
                if (blockManager.deleteList.Count > 0)
                {
                    int additionalScore;
                    switch (interval)
                    {
                        case -1:
                        case 0:
                            additionalScore = (int)(gameManager.defaultScore * gameManager.multiply[0]);
                            break;
                        case 1:
                        case 2:
                            additionalScore = (int)(gameManager.defaultScore * gameManager.multiply[interval]);
                            break;
                        default:
                            additionalScore = gameManager.defaultScore;
                            break;
                    }
                    interval = -1;
                    await CallDelete();
                    gameManager.AddScore(additionalScore);
                }
                else
                {
                    interval++;
                    Debug.Log("Ready to move");
                    freezing = false;
                }
            }
        }
    }

    private void Move()
    {
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position + offsetUp, Vector2.up, 0.3f);
        if (!hitUp)
        {
            var x = (int)(transform.position.x / blockManager.blockSize);
            var y = (int)(transform.position.y / blockManager.blockSize);
            blockManager.blockArray[x, y + 1] = this.gameObject;
            blockManager.blockArray[x, y] = null;
            transform.position += new Vector3(0, blockManager.blockSize);
            Debug.Log($"Moved = {blockManager.blockArray[x, y + 1].name}");
        }

        RaycastHit2D hitDown = Physics2D.Raycast(transform.position + offsetDown, Vector2.down, 0.3f);
        if (!hitDown)
        {
            var x = (int)(transform.position.x / blockManager.blockSize);
            var y = (int)(transform.position.y / blockManager.blockSize);
            blockManager.blockArray[x, y - 1] = this.gameObject;
            blockManager.blockArray[x, y] = null;
            transform.position += new Vector3(0, -blockManager.blockSize);
            Debug.Log($"Moved = {blockManager.blockArray[x, y - 1].name}");
        }

        RaycastHit2D hitRight = Physics2D.Raycast(transform.position + offsetRight, Vector2.right, 0.3f);
        if (!hitRight)
        {
            var x = (int)(transform.position.x / blockManager.blockSize);
            var y = (int)(transform.position.y / blockManager.blockSize);
            blockManager.blockArray[x + 1, y] = this.gameObject;
            blockManager.blockArray[x, y] = null;
            transform.position += new Vector3(blockManager.blockSize, 0);
            Debug.Log($"Moved = {blockManager.blockArray[x + 1, y].name}");
        }

        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position + offsetLeft, Vector2.left, 0.3f);
        if (!hitLeft)
        {
            var x = (int)(transform.position.x / blockManager.blockSize);
            var y = (int)(transform.position.y / blockManager.blockSize);
            blockManager.blockArray[x - 1, y] = this.gameObject;
            blockManager.blockArray[x, y] = null;
            transform.position += new Vector3(-blockManager.blockSize, 0);
            Debug.Log($"Moved = {blockManager.blockArray[x - 1, y].name}");
        }
    }

    private async UniTask CallDelete()
    {
        Debug.Log("Delete");
        await UniTask.Delay(500);
        blockManager.Delete();
        Debug.Log("Finish Delete");
    }
}
