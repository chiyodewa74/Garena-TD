using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public GameManager gm;
    public EnemySpawner es;
    public Text obj_text;
    public Text wave_text;
    
    
    // Start is called before the first frame update
    void Start()
    {
        obj_text.text = "0";
        wave_text.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        obj_text.text = gm.Health.ToString();
        wave_text.text = es.CurrentWave.ToString();
    }
}
