using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour {

	public List<JautajumiUnAtbildes> JuA;
	public List<string> Jautajumi = new List<string>(10); 

	public AtbilžuSkripts Atbilde;

	public GameObject[] opcijas;
	public GameObject QuizPanel;
	public GameObject GOPanel;

	public Text RezultatuTeksts;
	public Text JautajumuTeksts;
	public Text AtbilzuTeksts;

	public int pasreizejaisJautajums;
	public static int JautajumuSkaits = 0;

	int MaksimalieJautajumi = 0;
	public int Rezultats = 0;

	//Tiek noteikts cik daudz jautájumi paślaik eksisté un tad izsauc metodi kura uzǵeneré jautájumu lietotájam
	private void Start(){
		MaksimalieJautajumi = JuA.Count;
		GOPanel.SetActive (false);
		GeneretJautajumu ();
	}

	//Tad kad visi jautájumi ir atbildéti tad paráda visus rezultátus lietotájam, pasakot vińam cik daudz jautájumus vińś ir dabújis pareizus
	//un paráda visas atbildes uz jautájumiem, lai lietotájs zinátu kur vińś ir atbildéjis pareizi un kur nepareizi
	public void SpelesBeigas(){
		QuizPanel.SetActive (false);
		GOPanel.SetActive (true);
		RezultatuTeksts.text = "Pareizi atbildéti jautájumi: " + Rezultats + "/"+ MaksimalieJautajumi;
	}

	//Ja pareizs tiek atbildéts uz jautájuma tad pieskaita klát to rezultátam
	public void Pareizs(){

		Rezultats += 1;
		JuA.RemoveAt(pasreizejaisJautajums);

		JautajumuSkaits++;
		Debug.Log("Atbildētie Jautājumi: " + JautajumuSkaits);

		GeneretJautajumu();
	}

	//Izdara to paśu ko Pareizs() metode bet nepieskaita atbildi klát rezultátam
	public void Nepareizs(){

		JautajumuSkaits++;

		for(int i = 0; i < opcijas.Length; i++){
			if (JuA [pasreizejaisJautajums].PareizaAtbilde == i + 1) {
				AtbilzuTeksts.text += JuA [pasreizejaisJautajums].Jautajums+" - Pareizá atbilde bija: ''"+JuA[pasreizejaisJautajums].Atbildes[i]+"''\n\n";
			}
		}

		Debug.Log("Atbildētie Jautājumi: " + JautajumuSkaits);

		JuA.RemoveAt(pasreizejaisJautajums);
		GeneretJautajumu ();
	}

	/*Pańem paśreizéjo jautájumu, kas tiek parádíts lietotájam un apskatás visas tás atbildes uz to jautájumu 
	lídz kamér atrod to atbildi kura ir pareiza uzdotajam jautájumam un tiek pielikts klát tekstam kurś paradís visas pareizás atbildes testa beigás*/
	void SetAtbildes(){
		for(int i = 0; i < opcijas.Length; i++){

			opcijas [i].GetComponent<AtbilžuSkripts> ().irPareizs = false;
			opcijas[i].transform.GetChild(0).GetComponent<Text>().text = JuA[pasreizejaisJautajums].Atbildes[i];

			if (JuA [pasreizejaisJautajums].PareizaAtbilde == i + 1) {	
				opcijas [i].GetComponent<AtbilžuSkripts> ().irPareizs = true;
				//AtbilzuTeksts.text += JuA [pasreizejaisJautajums].Jautajums+" - Pareizá atbilde bija: ''"+JuA[pasreizejaisJautajums].Atbildes[i]+"''\n\n";
			}
		}
	}

	//Metode kas Uzǵenerés jautájumu un parádís to lietotájam
	void GeneretJautajumu(){

		if (JuA.Count > 0) {
			pasreizejaisJautajums = Random.Range (0, JuA.Count);

			JautajumuTeksts.text = JuA [pasreizejaisJautajums].Jautajums;
			SetAtbildes ();

		} else {
			Debug.Log ("Vairák jautájuma nav!");
			SpelesBeigas ();
		}
	}
}
	