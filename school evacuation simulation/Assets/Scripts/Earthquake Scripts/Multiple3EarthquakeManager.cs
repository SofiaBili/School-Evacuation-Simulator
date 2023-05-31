using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class Multiple3EarthquakeManager : MonoBehaviour
{
    public Multiple3ChoiceQuestios[] questions;
	private static List<Multiple3ChoiceQuestios> unansweredQuestions;
	private static Multiple3ChoiceQuestios currentQuestion;
	[SerializeField] private TextMeshProUGUI factText;
	[SerializeField] private TextMeshProUGUI ans0Text;
	[SerializeField] private TextMeshProUGUI ans1Text;
	[SerializeField] private TextMeshProUGUI ans2Text;

	[SerializeField] Button but1;
	[SerializeField] Button but2;
	[SerializeField] Button but3;
	
	[SerializeField] Camera canvasCamera;
	
    [SerializeField] GameObject slimeObject;
	Animator slimeAnimator;
    private string currentState;
	
    public AudioSource loseAudio;
    public AudioSource winAudio;
	
	static int randomQuestionIndex = -1;
	static bool changeQuest = false;
	static bool isAnsweredCorrect = false;

	void Awake(){
        slimeAnimator = slimeObject.GetComponent<Animator>();
	}
	void Start(){
		if(unansweredQuestions == null || unansweredQuestions.Count==0){
			unansweredQuestions = questions.ToList<Multiple3ChoiceQuestios>();
		}

		//SetCurrentQuestion();
		transform.gameObject.SetActive(false);
	}
	public static bool UnansweredQuestionsCount(){
		Debug.Log(unansweredQuestions.Count);
		if(unansweredQuestions.Count == 0) return false;
		return true;
	}
	public static void GetQuestion(int index){
		isAnsweredCorrect = false;
		randomQuestionIndex = index;
		changeQuest = true;
		currentQuestion = unansweredQuestions[randomQuestionIndex];

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
		changeQuest = false;
		factText.text = currentQuestion.question;
		ans0Text.text = currentQuestion.ans1;
		ans1Text.text = currentQuestion.ans2;
		ans2Text.text = currentQuestion.ans3;
	}
    private IEnumerator ChangeButtonColour(Button btn){
		yield return new WaitForSeconds (1.9f);
		btn.GetComponent<Image>().color = Color.white;
		//transform.gameObject.SetActive(false);
	}
	
    private IEnumerator ChangeQuestion(bool show){
		GetComponent<CanvasGroup>().interactable = false;
		if(show)
			yield return new WaitForSeconds (2.1f);
		GetComponent<CanvasGroup>().interactable = true;
		//canvasCamera.cullingMask &=  ~(1 << LayerMask.NameToLayer("QuestionCanvas"));
		isAnsweredCorrect = true;
		//SetCurrentQuestion();
		//yield return new WaitForSeconds (0.09f);
	}
	public void UserSelect0(){
		//GetComponent<CanvasGroup>().interactable = false;
		if(currentQuestion.corrAns == 0){
			winAudio.Play(0);
			but1.GetComponent<Image>().color = Color.green;
			//unansweredQuestions.RemoveAt(randomQuestionIndex);
			StartCoroutine(ChangeAnimationState("congratulations"));
			StartCoroutine(ChangeQuestion(true));
		}else{
			loseAudio.Play(0);
			but1.GetComponent<Image>().color = Color.red;
			StartCoroutine(ChangeAnimationState("disappoint"));
		}
		StartCoroutine(ChangeButtonColour(but1));
		//if(UnansweredQuestionsCount()) StartCoroutine(ChangeQuestion(true));
	}
	public void UserSelect1(){
		//GetComponent<CanvasGroup>().interactable = false;
		if(currentQuestion.corrAns == 1){
			winAudio.Play(0);
			but2.GetComponent<Image>().color = Color.green;
			//unansweredQuestions.RemoveAt(randomQuestionIndex);
			StartCoroutine(ChangeAnimationState("congratulations"));
			StartCoroutine(ChangeQuestion(true));
		}else{
			loseAudio.Play(0);
			but2.GetComponent<Image>().color = Color.red;
			StartCoroutine(ChangeAnimationState("disappoint"));
		}
		StartCoroutine(ChangeButtonColour(but2));
		//if(UnansweredQuestionsCount()) StartCoroutine(ChangeQuestion(true));
	}
	public void UserSelect2(){
		//GetComponent<CanvasGroup>().interactable = false;
		if(currentQuestion.corrAns == 2){
			winAudio.Play(0);
			but3.GetComponent<Image>().color = Color.green;
			//unansweredQuestions.RemoveAt(randomQuestionIndex);
			StartCoroutine(ChangeAnimationState("congratulations"));
			StartCoroutine(ChangeQuestion(true));
		}else{
			loseAudio.Play(0);
			but3.GetComponent<Image>().color = Color.red;
			StartCoroutine(ChangeAnimationState("disappoint"));
		}
		StartCoroutine(ChangeButtonColour(but3));
		//if(UnansweredQuestionsCount()) StartCoroutine(ChangeQuestion(true));
	}
	public IEnumerator ChangeAnimationState(string newState){
        currentState=newState;
        if(!slimeAnimator.GetCurrentAnimatorStateInfo(0).IsName(currentState)){
            slimeAnimator.Play(newState);
			yield return new WaitForSeconds (2.3f);
		}
    }
}
