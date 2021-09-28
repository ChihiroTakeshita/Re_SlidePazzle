using Cysharp.Threading.Tasks;
using UnityEngine;

public class Block : MonoBehaviour
{
    GManager gameManager;
    BlockManager blockManager;
    SoundEffectManager sfx;

    Vector3 offsetUp, offsetDown, offsetRight, offsetLeft;

    public bool isMatching = false;
    private static int interval = 0;
    private bool isMoved = false;

    private void Start()
    {
        gameManager = GManager.GameManager;
        blockManager = BlockManager.BManager;
        sfx = SoundEffectManager.sfx;

        offsetUp = new Vector3(0, (blockManager.blockSize /2) + 0.01f);
        offsetDown = offsetUp * -1;
        offsetRight = new Vector3((blockManager.blockSize /2) + 0.01f, 0);
        offsetLeft = offsetRight * -1;
    }

    private async void OnMouseDown()
    {
        if(!gameManager.freezing)
        {
            Move();
            if(isMoved)
            {
                gameManager.freezing = true;
                while (true)
                {
                    blockManager.CheckMatching();
                    if (blockManager.deleteList.Count > 0)
                    {
                        int additionalScore;
                        switch (interval)
                        {
                            case -1:
                            case 0:
                                additionalScore = (int)(gameManager.defaultScore * gameManager.multiply[0]) * blockManager.deleteList.Count;
                                break;
                            case 1:
                            case 2:
                                additionalScore = (int)(gameManager.defaultScore * gameManager.multiply[interval]) * blockManager.deleteList.Count;
                                break;
                            default:
                                additionalScore = gameManager.defaultScore * blockManager.deleteList.Count;
                                break;
                        }
                        interval = -1;
                        await CallDelete();
                        gameManager.AddScore(additionalScore);
                    }
                    else
                    {
                        interval++;
                        if (!gameManager.timeUp)
                        {
                            gameManager.freezing = false;
                        }
                        break;
                    }
                }
                isMoved = false;
            }
        }
    }

    private void Move()
    {
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position + offsetUp, Vector2.up, 0.3f);
        if (!hitUp)
        {
            isMoved = true;
            sfx.PlayMoveBlockSFX();
            var x = (int)(transform.position.x / blockManager.blockSize);
            var y = (int)(transform.position.y / blockManager.blockSize);
            blockManager.blockArray[x, y + 1] = this.gameObject;
            blockManager.blockArray[x, y] = null;
            transform.position += new Vector3(0, blockManager.blockSize);
        }

        RaycastHit2D hitDown = Physics2D.Raycast(transform.position + offsetDown, Vector2.down, 0.3f);
        if (!hitDown)
        {
            isMoved = true;
            sfx.PlayMoveBlockSFX();
            var x = (int)(transform.position.x / blockManager.blockSize);
            var y = (int)(transform.position.y / blockManager.blockSize);
            blockManager.blockArray[x, y - 1] = this.gameObject;
            blockManager.blockArray[x, y] = null;
            transform.position += new Vector3(0, -blockManager.blockSize);
        }

        RaycastHit2D hitRight = Physics2D.Raycast(transform.position + offsetRight, Vector2.right, 0.3f);
        if (!hitRight)
        {
            isMoved = true;
            sfx.PlayMoveBlockSFX();
            var x = (int)(transform.position.x / blockManager.blockSize);
            var y = (int)(transform.position.y / blockManager.blockSize);
            blockManager.blockArray[x + 1, y] = this.gameObject;
            blockManager.blockArray[x, y] = null;
            transform.position += new Vector3(blockManager.blockSize, 0);
        }

        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position + offsetLeft, Vector2.left, 0.3f);
        if (!hitLeft)
        {
            isMoved = true;
            sfx.PlayMoveBlockSFX();
            var x = (int)(transform.position.x / blockManager.blockSize);
            var y = (int)(transform.position.y / blockManager.blockSize);
            blockManager.blockArray[x - 1, y] = this.gameObject;
            blockManager.blockArray[x, y] = null;
            transform.position += new Vector3(-blockManager.blockSize, 0);
        }
    }

    private async UniTask CallDelete()
    {
        await UniTask.Delay(500);
        blockManager.Delete();
        sfx.PlayDeleteBlockSFX();
    }
}
