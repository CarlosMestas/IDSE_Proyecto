using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberBox : MonoBehaviour{
    public int index = 0;
    public int x = 0;
    public int y = 0;

    private Action<int, int> swapFun = null;

    public void Init(int _i, int _j, int _index, Sprite _sprite, Action<int, int> swapFun) {
        this.index = _index;
        this.GetComponent<SpriteRenderer>().sprite = _sprite;
        UpdatePos(_i, _j);
        this.swapFun = swapFun;
    }

    public void UpdatePos(int _i, int _j){
        x = _i;
        y = _j;
//        this.gameObject.transform.localPosition = new Vector2(_i, _j);
        StartCoroutine(Move());
  //      Debug.Log(":v" + index + "\t" + x + "\t" + y);
    }

    IEnumerator Move() {
        float elapsedTime = 0;
        float duration = 0.2f;
        Vector2 start = this.gameObject.transform.localPosition;
        Vector2 end = new Vector2(x, y);
        while (elapsedTime < duration) {
            this.gameObject.transform.localPosition = Vector2.Lerp(start, end, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        this.gameObject.transform.localPosition = end;
    }

    public bool IsEmpty() {
        return index == 16;
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && swapFun != null) {
            swapFun(x, y);
        }
    }
}

