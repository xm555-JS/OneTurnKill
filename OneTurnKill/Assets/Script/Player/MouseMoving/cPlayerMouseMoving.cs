using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cPlayerMouseMoving : MonoBehaviour
{
    bool isCatch;
    float gapX;
    float gapY;

    public void ResetIsCatch() { isCatch = false; }

    void Update()
    {
        CatchPlayer();
        MovePlayer();
    }

    void CatchPlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 playerVec = GameManager.instance.player.transform.position;
            gapX = playerVec.x - pos.x;
            gapY = playerVec.y - pos.y;
            RaycastHit2D[] hits = Physics2D.RaycastAll(pos, Vector2.zero);
            if (hits == null)
                return;

            foreach (var obj in hits)
            {
                if (obj.transform.gameObject.CompareTag("Player"))
                    isCatch = true;
            }
        }
        if (Input.GetMouseButtonUp(0))
            if (isCatch)
                isCatch = false;
    }

    void MovePlayer()
    {
        if (Input.GetMouseButton(0) && isCatch)
        {
            Vector2 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 playerPos = new Vector2(worldMousePos.x + gapX, worldMousePos.y + gapY);
            GameManager.instance.player.transform.position = playerPos;
        }
    }
}
