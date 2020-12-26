using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour{

    public NumberBox boxPrefab;

    public NumberBox[,] boxes = new NumberBox[4, 4];

    public Sprite[] sprites;

    private int[] array = new int[] { 13, 9, 5, 1, 14, 10, 6, 2, 15, 11, 7, 3, 16, 12, 8, 4};

    TextMeshProUGUI textWin;

    Button button;

    public void Start()
    {
        Init();

        textWin = GameObject.Find("TextWin").GetComponent<TextMeshProUGUI>();
        textWin.SetText("");

        button = GameObject.Find("ButtonNext").GetComponent<Button>();
        button.enabled = false;

        for(int i = 0; i < 50; i++)
            Shuffle();
        
     }


    void Init() {
        int n = 0;  
        for (int y = 3; y >= 0; y--)
            for (int x = 0; x < 4; x++) {
                NumberBox box = Instantiate(boxPrefab, new Vector2(x, y), Quaternion.identity);
                box.Init(x, y, n + 1, sprites[n], ClickToSwap);
                boxes[x, y] = box;
                n++;
            }
    }

    void ClickToSwap(int _x, int _y) {
        int dx = getDx(_x, _y);
        int dy = getDy(_x, _y);
        Swap(_x, _y, dx, dy);
    }

    void Swap(int _x, int _y, int _dx, int _dy) {

        var from = boxes[_x, _y];
        var target = boxes[_x + _dx, _y + _dy];

//        Debug.Log(":v :v" + boxes[0, 0].x + "\t" + boxes[0, 0].y + "\t" + boxes[0, 0].index);

        boxes[_x, _y] = target;
        boxes[_x + _dx, _y + _dy] = from;

        from.UpdatePos(_x + _dx, _y + _dy);
        target.UpdatePos(_x, _y);

        string test = "";
        int w = 0;
        int z = 0;
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                w++;
                test += "\t" + w + "\t" + boxes[i, j].x + "\t" + boxes[i, j].y + "\t" + boxes[i, j].index;
                test += "\n";
                if (array[w - 1] == boxes[i, j].index){
                    z++;
                }
            }
        }
        if (z == 16)
        {
      //      Debug.Log(test + "\n\n" + "Completado");
            Debug.Log("Completado");
            textWin.SetText("COMPLETADO!!!\n\nFELICITACIONES!!!");
            button.enabled = true;
        }
        else {
      //      Debug.Log(test + "\n\n" + "No completado");
            Debug.Log("No completado");

        }
    }

    int getDx(int _x, int _y) {
        if (_x < 3 && boxes[_x + 1, _y].IsEmpty()) 
            return 1;
               
        if (_x > 0 && boxes[_x - 1, _y].IsEmpty())
            return -1;
        return 0;
    }

    int getDy(int _x, int _y) {
        if (_y < 3 && boxes[_x, _y + 1].IsEmpty())
            return 1; 
        if (_y > 0 && boxes[_x, _y - 1].IsEmpty())
            return -1;
        return 0;
    }

    void Shuffle(){
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++){
                if (boxes[i, j].IsEmpty()) {
                    Vector2 pos = getValidMove(i, j);
                    Swap(i, j, (int) pos.x, (int) pos.y);
                }
            }
        }
    }

    private Vector2 lastMove;

    Vector2 getValidMove(int _x, int _y) {
        Vector2 pos = new Vector2();
        do
        {
            int n = Random.Range(0, 4);
            if (n == 0)
                pos = Vector2.left;
            else if (n == 1)
                pos = Vector2.right;
            else if (n == 2)
                pos = Vector2.up;
            else
                pos = Vector2.down;
        }
        while (!(isValidRange(_x + (int)pos.x) && isValidRange(_y + (int)pos.y)) || isRepeatMove(pos));
        lastMove = pos;
        return pos;
    }

    bool isValidRange(int _n){
        return _n >= 0 && _n <= 3;
    }

    bool isRepeatMove(Vector2 _pos) {
        return _pos * -1 == lastMove;
    }

}
