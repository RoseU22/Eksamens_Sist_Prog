using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AinuParsledzejs : MonoBehaviour {

	//Párslédz ainu uz sákuma ekrańu
	public void UzSakumaEkranu(){
		SceneManager.LoadScene ("SakumaEkrans", LoadSceneMode.Single);
	}

	//Párslédz ainu uz testu
	public void UzQuizAinu(){
		SceneManager.LoadScene("Quiz", LoadSceneMode.Single);
	}

	//Atsákt testu no jauna
	public void AtsaktTestu(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	//Iziet no spéles
	public void IzietNoSpeles(){
		Application.Quit ();
	}
}
