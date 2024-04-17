using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumManager;
using UnityEngine.Pool;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    public ObjectPool objectPool;

    //public PlayerController player;
    public CameraFollow cameraFollow;

    public Transform gameUICanvasTrans;
    public Player player;

    public Stage currentStage = Stage.Stage1;

    [HideInInspector]
    public Room currentRoom;
    [HideInInspector]
    public int currentRoomClearPoint = 0;


    private void Update()
    {
        if (!currentRoom.isClear)
        {
            if (currentRoomClearPoint == 0) 
            {
                currentRoom.isClear = true;
            }
        }
        // Test

        if (Input.GetKeyDown(KeyCode.T))
        {
            currentRoom.OnClearRoom();
        }
    }



    public void OnPlayerMoveRoom(Room moveRoom)
    {
        //if (moveRoom.roomInfo.roomType == RoomType.Boss)
        //{
        //    AudioClip bgmClip = SoundManager.Instance.GetOrAddAudioClip("AudioSource/bgm/bossRoombgm", SoundManager.Sound.bgm);
        //    AudioSource bgm = SoundManager.Instance.transform.GetChild(0).GetComponent<AudioSource>();
        //    bgm.clip = bgmClip;
        //    bgm.loop = true;
        //    bgm.volume = 0.3f;
        //    SoundManager.Instance.Play(bgm.clip, SoundManager.Sound.bgm);
        //}
        cameraFollow.SetTarget(moveRoom.transform);
        currentRoom = moveRoom;
        currentRoomClearPoint = currentRoom.SpawnEnemy();
    }
}
