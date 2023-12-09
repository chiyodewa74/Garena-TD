using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public GameManager gm;
    public EnemySpawner es;
    public SuperTextMesh obj_text;
    
    
    // Start is called before the first frame update
    void Start()
    {
        obj_text.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        obj_text.text = gm.Health.ToString();
    }
}
