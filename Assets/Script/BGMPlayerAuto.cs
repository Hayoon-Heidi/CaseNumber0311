using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMPlayerAuto : MonoBehaviour
{

    BGMManager BGM;

    public int playMusicTrack;

    // Start is called before the first frame update
    void Start()
    {
        BGM = FindObjectOfType<BGMManager>();
        BGM.Play(playMusicTrack);
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
