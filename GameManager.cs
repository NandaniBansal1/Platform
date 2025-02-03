using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int multiplier=2;
    int streak=0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Score",0);
        PlayerPrefs.SetInt("RockMeter",25);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        Destroy(col.gameObject);
        GetComponent<GameManager>().ResetStreak();
    }

    public int GetScore(){
        return multiplier*100;
    }

    public void AddStreak(){
        if((PlayerPrefs.GetInt("RockMeter")+1)<50)
            PlayerPrefs.SetInt("Rockmeter",PlayerPrefs.GetInt("RockMeter")+1);
        streak++;
        if(streak>=24)
        multiplier=4;
        else if(streak>=16)
        multiplier=3;
        else if(streak>=8)
        multiplier=2;
        else
        multiplier=1;
        UpdateGUI();
        
    }

    public void ResetStreak(){
        
        PlayerPrefs.SetInt("Rockmeter",PlayerPrefs.GetInt("RockMeter")-2);
        if((PlayerPrefs.GetInt("RockMeter")<0))
        Lose();
        streak=0;
        multiplier=1;
        UpdateGUI();
    }

    void Lose(){

    }

    void UpdateGUI(){
        PlayerPrefs.SetInt("streak",streak);
        PlayerPrefs.SetInt("mult",multiplier);
    }
}
