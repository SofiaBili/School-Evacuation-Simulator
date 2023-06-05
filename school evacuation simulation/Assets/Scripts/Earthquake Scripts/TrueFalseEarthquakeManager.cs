using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class TrueFalseEarthquakeManager : MonoBehaviour
{
    public TrueFalseQuestions[] questions;
	private static List<TrueFalseQuestions> unansweredQuestions;
	private static TrueFalseQuestions currentQuestion;
	[SerializeField] private TextMeshProUGUI factText;

	[SerializeField] Button trueButton;
	[SerializeField] Button falseButton;
	
	[SerializeField] Camera canvasCamera;
	
    [SerializeField] GameObject slimeObject;
	Animator slimeAnimator;
    private string currentState;
	
    public AudioSource loseAudio;
    public AudioSource winAudio;
	
	static int randomQuestionIndex = -1;
	static bool changeQuest = false;
	static bool isAnsweredCorrect = false;

	private HealthPlayer health;

	void Awake(){
        slimeAnimator = slimeObject.GetComponent<Animator>();
	}
	void Start(){
		if(unansweredQuestions == null || unansweredQuestions.Count==0){
			unansweredQuestions = questions.ToList<TrueFalseQuestions>();
		}
		transform.gameObject.SetActive(false);
		//health = gameObject.transform.parent.parent.parent.transform.Find("Player").GetComponent<HealthPlayer>();
	}
	public static bool UnansweredQuestionsCount(){
		Debug.Log(unansweredQuestions.Count);
		if(unansweredQuestions.Count == 0) return false;
		return true;
	}
	public static void GetQuestion(int index){
		EarthquakeClassScript.flag = false;
		isAnsweredCorrect = false;
		randomQuestionIndex = index;
		currentQuestion = unansweredQuestions[randomQuestionIndex];
		changeQuest = true;

	}
	public static bool IsAnswered(){
		return isAnsweredCorrect;
	}
	void Update(){
		if(changeQuest){
			SetCurrentQuestion();
		}
	}
	void SetCurrentQuestion(){
		GetComponent<CanvasGroup>().interactable = true;
		changeQuest = false;
		Debug.Log(randomQuestionIndex);
		factText.text = currentQuestion.fact;
	}
    private IEnumerator ChangeButtonColour(){
		yield return new WaitForSeconds (1.9f);
		trueButton.GetComponent<Image>().color = Color.white;
		falseButton.GetComponent<Image>().color = Color.white;
	}
	
    private IEnumerator ChangeQuestion(){
		GetComponent<CanvasGroup>().interactable = false;
		yield return new WaitForSeconds (2.3f);
		isAnsweredCorrect = true;
		EarthquakeClassScript.step++;
		EarthquakeClassScript.flag = true;
		transform.gameObject.SetActive(false);
		/*if(unansweredQuestions[randomQuestionIndex+1]!=null)
			EarthquakeClassScript.NextTrueFalseQuestionAndAnimation(randomQuestionIndex+1);*/
	}
	public void UserSelectTrue(){
		if(currentQuestion.isTrue){
			winAudio.Play(0);
			//Debug.Log("Cor");
			trueButton.GetComponent<Image>().color = Color.green;
			StartCoroutine(ChangeAnimationState("congratulations"));
			StartCoroutine(ChangeQuestion());
			StartCoroutine(ChangeButtonColour());
		}else{
			loseAudio.Play(0);
			HealthPlayer.RemoveHeart();
			trueButton.GetComponent<Image>().color = Color.red;
			StartCoroutine(ChangeAnimationState("disappoint"));
		}
	}
	public void UserSelectFalse(){
		if(currentQuestion.isTrue){
			HealthPlayer.RemoveHeart();
			loseAudio.Play(0);
			falseButton.GetComponent<Image>().color = Color.red;
			StartCoroutine(ChangeAnimationState("disappoint"));
		}else{
			winAudio.Play(0);
			falseButton.GetComponent<Image>().color = Color.green;
			StartCoroutine(ChangeAnimationState("congratulations"));
			StartCoroutine(ChangeQuestion());
			StartCoroutine(ChangeButtonColour());
		}
	}
	public IEnumerator ChangeAnimationState(string newState){
        currentState=newState;
        if(!slimeAnimator.GetCurrentAnimatorStateInfo(0).IsName(currentState)){
//			Debug.Log("oooooooooooo");
            slimeAnimator.Play(newState);
			yield return new WaitForSeconds (2.3f);
		}
    }
}
