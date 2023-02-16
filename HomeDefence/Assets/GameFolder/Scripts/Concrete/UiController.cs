using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UiController : MonoBehaviour
{
    public static UiController Instance;
    public GameObject uiMenu;
    public TextMeshProUGUI totalMoneyText;
    public Transform scrollViewContent;
    public GameObject playerButtonPrefab;

    private List<Button> buttons;

    [Header("Screens")]
    public GameObject winScreen;
    public GameObject failScreen;

	private void Awake()
	{
        Instance = this;
	}
	void Start()
    {
        SpawnButton();
    }

    public void PressButtonForGame()
	{
        uiMenu.SetActive(false);
        GameController.Instance.StartGameplay();
	}

    public void ShowTotalMoney()
	{
        totalMoneyText.text = GameController.Instance.GetTotalMoney(10).ToString();
	}

    public void SpawnButton()
	{
        buttons = new List<Button>();
		for (int i = 0; i < 10; i++)
		{
            GameObject playerButtonGO = Instantiate(playerButtonPrefab,scrollViewContent);
            buttons.Add(playerButtonGO.GetComponent<Button>());
		}
        StartCoroutine(SpawnButtonCorutine());
	}
    private IEnumerator SpawnButtonCorutine()
	{
		foreach (var item in buttons)
		{
            DisableButton(item);
		}
        ActivateButton(buttons[Random.Range(0, buttons.Count)]);
        yield return new WaitForSeconds(2f);

		if (!GameController.Instance.isGamePlayStarted)
		{
            StartCoroutine(SpawnButtonCorutine());
        }
	}

    private void ActivateButton(Button button)
	{
        button.GetComponent<Image>().color = Color.green;
        button.GetComponentInChildren<TextMeshProUGUI>().text = "PLAY";
        button.enabled = true;
        button.onClick.AddListener(()=> 
        {
            PressButtonForGame();
        });
    }
    private void DisableButton(Button button)
	{
        button.GetComponent<Image>().color = Color.white;
        button.GetComponentInChildren<TextMeshProUGUI>().text = " ";
        button.enabled = false;
        button.onClick.RemoveAllListeners();
    }
}
