using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class AnimalLoader:MonoBehaviour{



    private List<string[]> Datas = new List<string[]>();

    //カテゴリ
    public  int Category{ get; private set; }
    //public int AID{ get; private set; } フェスでは未使用
    public int ID { get; private set; }
    public string Name { get; private set; }
    //public string NickName { get; private set; } フェスでは未使用
    public int  MoveType { get; private set; }
    public int Favorite { get; private set; }

    //データ読み込み
    public List<string[]> LoadData()
    { 
        string filePath = "Data/";
        string fileName = "test";
        TextAsset csv = Resources.Load(filePath + fileName) as TextAsset;
        StringReader reader = new StringReader(csv.text);
        // csvファイルの内容を一行ずつ末尾まで取得しリストを作成
        while (reader.Peek() > -1)
        {
            // 一行読み込む
            var lineData = reader.ReadLine();
            // カンマ(,)区切りのデータを文字列の配列に変換
            var address = lineData.Split(',');
            // リストに追加
            Datas.Add(address);
            // 末尾まで繰り返し...
            
        }
        Debug.Log("動物csv読み込み終了");
        return Datas;
        
    }
}
