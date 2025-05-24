using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool AktywnoscPokoi = true;

    public MapGenerator mapGenerator;
    public GameObject MapObject;

    void Start()
    {
        mapGenerator.SetupDungeon();
    }


    void mapButton()
    {
        AktywnoscPokoi = !AktywnoscPokoi;
        MapObject.gameObject.SetActive(AktywnoscPokoi);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            mapButton();
        }

    }
}