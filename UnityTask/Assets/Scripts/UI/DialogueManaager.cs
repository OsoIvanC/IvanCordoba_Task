using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class DialogueManaager : MonoBehaviour
{
    public static DialogueManaager Instance { get; private set; }
    [SerializeField] GameObject DialogueUI;
    [SerializeField] TextMeshProUGUI DialogueText;
    private void Awake()
    {
        Instance = this;
        DialogueUI.SetActive(false);
    }

    public async void UpdateText(string text)
    {
        DialogueUI.SetActive(true);
        DialogueText.text = text;
        await Task.Delay(1000);
        DialogueUI.SetActive(false);
    }
}
