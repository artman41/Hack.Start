using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GridSplit : MonoBehaviour {

    public int IconSize = 32;
    public string SortingLayer = "Desktop";
    Texture2D[] textures;
    int IconNum = 0;

    void Start() {
        textures = Resources.LoadAll<Texture2D>("Icons");

        var scale = Camera.main.ViewportToScreenPoint(transform.localScale);

        Debug.Log(scale);

        var numRow = (scale.y - IconSize) / IconSize;
        var numCol = (scale.x - IconSize) / IconSize;

        Debug.Log($"Rows: {numRow}");
        Debug.Log($"Columns: {numCol}");


        for (int i = 0; i < numCol; i++) {
            #region Column Management
            if (!(IconNum < textures.Length)) return;
            var holder = new GameObject($"Column {i}");
            holder.transform.SetParent(this.transform);
            holder.layer = this.gameObject.layer;
            #endregion

            for (int j = 0; j < numRow; j++) {

                if (!(IconNum < textures.Length)) return;
                #region Icon Instantiation
                var x = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Desktop/DesktopTile"));
                x.name = textures[IconNum].name;
                x.transform.SetParent(holder.transform);
                var sr = x.GetComponent<SpriteRenderer>();
                sr.sprite = Sprite.Create(textures[IconNum], new Rect(0.0f, 0.0f, textures[IconNum].width, textures[IconNum].height), new Vector2(0.5f, 0.5f), 100.0f);
                x.transform.position = Camera.main.ScreenToWorldPoint(new Vector3((i * IconSize) + 9 * IconSize / 10, (numRow - j) * IconSize, scale.z));

                ClickHandler(x.GetComponent<ClickBehaviour>());
                #endregion

                IconNum++; //Move on to next icon
            }
        }
    }

    void ClickHandler(ClickBehaviour cb) {
        switch (cb.name.ToLower()) {
            case "my-computer":
                cb.MouseDown.AddListener(() => {
                    var go = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Windows/WindowContent"));
                    go.name = "Computer";
                    var title = go.GetComponent<ContentPointer>().Title.GetComponent<Text>();
                    //title.text = go.name;
                    go.transform.SetParent(GameObject.Find("Window Container").transform);
                    go.transform.localPosition = new Vector3(0f, 0f);
                });
                break;
            case "32-32_orange":
                cb.MouseDown.AddListener(() => Debug.Log($"ORANGE"));
                break;
            default:
                cb.MouseDown.AddListener(() => Debug.Log($"Sprite {cb.name} was clicked"));
                break;
        }
        
    }

}
