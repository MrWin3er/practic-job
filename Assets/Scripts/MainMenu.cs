using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public Slider slider;
	public Text TextLink;
	int TestValue;
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = slider.value;
		TestValue = (int) (slider.value * 100);
		TextLink.text = TestValue.ToString();
    }
	public void PlayGame()
	{
		 Application.LoadLevel ("level1");
	}
	
}
