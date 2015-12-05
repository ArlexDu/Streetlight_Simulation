using UnityEngine;
using System.Collections;
using LitJson;
using System.IO;
public class JsonManager : MonoBehaviour {

    private string filename = "data.txt";
    private float Slight1_y;
    private float Slight2_y;
    private float Slight3_y;
    private float Slight4_y;
    private float Flight1_y;
    private float Flight2_y;
    private float Flight3_y;
    private float Flight4_y;
    private JsonData data;
    public static JsonManager shareJsonManager = null;
    void Awake()
    {
        StreamReader reader = new StreamReader(Application.dataPath+"/LoadData/"+filename);
        string rawData = reader.ReadToEnd();
        Debug.Log("rawData is "+rawData);
        reader.Close();
        data = JsonMapper.ToObject(rawData);
        getvalue();
    }

    private void getvalue()
    {
        Slight1_y = float.Parse(data["Slight1_y"].ToString());
        Slight2_y = float.Parse(data["Slight2_y"].ToString());
        Slight3_y = float.Parse(data["Slight3_y"].ToString());
        Slight4_y = float.Parse(data["Slight4_y"].ToString());
        Flight1_y = float.Parse(data["Flight1_y"].ToString());
        Flight2_y = float.Parse(data["Flight2_y"].ToString());
        Flight3_y = float.Parse(data["Flight3_y"].ToString());
        Flight4_y = float.Parse(data["Flight4_y"].ToString());
    }

    public static JsonManager instance {
        get {
            if (shareJsonManager == null)
            {
                shareJsonManager=FindObjectOfType(typeof(JsonManager)) as JsonManager;

            }
            return shareJsonManager;
        } }

    public float getSvalue(int id)
    {
        switch (id)
        {
            case 1: return Slight1_y;
            case 2: return Slight2_y;
            case 3: return Slight3_y;
            case 4: return Slight4_y;
            default: return 0;
        }
    }

    public float getFvalue(int id)
    {
        switch (id)
        {
            case 1: return Flight1_y;
            case 2: return Flight2_y;
            case 3: return Flight3_y;
            case 4: return Flight4_y;
            default: return 0;
        }
    }
}
