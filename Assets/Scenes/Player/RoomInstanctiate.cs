using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInstanctiate : MonoBehaviour
{
    Dictionary<Vector3Int, GameObject> room_dic;

    public GameObject roomPrefab;

    const float room_size = 64.0f;

    Vector3Int currentIndex = new Vector3Int(99999999, 999999, 99999);
    Vector3 lastPosition = new Vector3(99999.0f, 9999.0f, 9999.0f);

    // Start is called before the first frame update
    void Start()
    {
        room_dic = new Dictionary<Vector3Int, GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        int ix = (int)(transform.position.x / room_size);
        int iy = (int)(transform.position.y / room_size);
        int iz = (int)(transform.position.z / room_size);
        Vector3Int a = new Vector3Int(ix, iy, iz);
        if(a != currentIndex)
        {
            currentIndex = a;
            InstanciateRoomNear(a);
            RemoveNotNeededRooms(a);
        }
    }

    void InstanciateRoom(Vector3Int i)
    {
        GameObject go = Instantiate(roomPrefab, new Vector3((float)i.x * room_size, (float)i.y * room_size, (float)i.z * room_size), Quaternion.identity);
        go.GetComponent<Room>().index = i;
        go.name = i.x + "_" + i.y + "_" + i.z;
        room_dic.Add(i, go);
    }

    void InstanciateRoomNear(Vector3Int rInd)
    {
        Dictionary<Vector3Int, bool> dic = new Dictionary<Vector3Int, bool>();
        
        for(int xd = -1; xd < 2; xd++)
        {
            for (int yd = -1; yd < 2; yd++)
            {
                for (int zd = -1; zd < 2; zd++)
                {
                    dic.Add(new Vector3Int(rInd.x + xd, rInd.y + yd, rInd.z + zd), true);
                }
            }
        }

        foreach (KeyValuePair<Vector3Int, bool> entry in dic)
        {
            if(!room_dic.ContainsKey(entry.Key))
            {
                InstanciateRoom(entry.Key);
            }
        }
    }
            
    void RemoveNotNeededRooms(Vector3Int rInd) //TODO
    {
        Dictionary<Vector3Int, bool> dic = new Dictionary<Vector3Int, bool>();

        for (int xd = -1; xd < 2; xd+= 1)
        {
            for (int yd = -1; yd < 2; yd+= 1)
            {
                for (int zd = -1; zd < 2; zd += 1)
                {
                    dic.Add(new Vector3Int(rInd.x + xd, rInd.y + yd, rInd.z + zd), true);
                }
            }
        }


        List<Vector3Int> removeFromDic = new List<Vector3Int>();
        foreach(KeyValuePair<Vector3Int, GameObject> entry in room_dic)
        {
            Vector3Int r = entry.Value.GetComponent<Room>().index;
            if(!dic.ContainsKey(r))
            {
                Destroy(entry.Value);
                removeFromDic.Add(entry.Key);
            }
        }

        foreach(Vector3Int el in removeFromDic)
        {
            room_dic.Remove(el);
        }

    }
  

}
