using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//ATTACH TO MAIN CAMERA, shows your health and coins
public class GUIManager : MonoBehaviour 
{	
//World Space UI
	public Canvas scoreCanvas;
	public Slider healthSlider;
	public Text scoreText;
    public Combat combat; 
	
	//public GUISkin guiSkin;					//assign the skin for GUI display
	[HideInInspector]
	public int coinsCollected;

	private int coinsInLevel;
	
	
	//setup, get how many coins are in this level
	void Start()
	{
		coinsInLevel = GameObject.FindGameObjectsWithTag("Coin").Length;		
		combat = GameObject.FindGameObjectWithTag("Player").GetComponent<Combat>();
	}
	
	//show current health and how many coins you've collected
	void OnGUI()
	{
        //	GUI.skin = guiSkin;
        //	GUILayout.Space(5f);
        if (combat)
        {
            scoreText.text = coinsCollected.ToString();
            Debug.Log("Coins Collected" + coinsCollected.ToString());
            healthSlider.value = combat.currentHealth;
            Debug.Log("Current Health" + combat.currentHealth.ToString());
        }
			GUILayout.Label ("Health: " + combat.currentHealth);
		if(coinsInLevel > 0)
			GUILayout.Label ("Cubes: " + coinsCollected + " / " + coinsInLevel);
	}
}