using ProtoBuf;
using UnityEngine;
using System.IO;
using UnityEditor;

public class TestProtoBuf : MonoBehaviour
{
    FileStream fs;
    
    void Start()
    {
        MyUser myUser = new MyUser();
        myUser.ID = 1;
        myUser.level = 100;
        myUser.PassWord = "123456";
        myUser.UserName = "zhb";
        myUser._UserType = MyUser.UserType.Master;

        using (fs = File.Create(Application.dataPath + "/User.bin"))
        {
            Serializer.Serialize<MyUser>(fs, myUser);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("???");
            OpenRead();
        }
    }

    void OpenRead()
    {
        MyUser user = null;
        using (fs = File.OpenRead(Application.dataPath + "/User.bin"))
        {
            user = Serializer.Deserialize<MyUser>(fs);

            Debug.Log(user.ID);
            Debug.Log(user.UserName);
        }
    }

    private void OnDestroy()
    {
        AssetDatabase.Refresh();
    }
}
