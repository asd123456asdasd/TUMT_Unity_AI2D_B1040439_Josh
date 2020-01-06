using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class npc : MonoBehaviour
{
    public enum state
    {
        star, notComplete, complete
    }

    public state _state;

    public string star = "請收集7枚硬幣，並回來找我";
    public string notcomplete = "還沒找到7枚嗎";
    public string complete = "感謝你的配合";

    public float talkspeed = 0.1f;

    public bool mission_complete = false;
    public int count_player = 0;
    public int finish = 5;

    public GameObject objcan;
    public Text textSay;

    public static npc count;

    private void Start()
    {
        count = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "play")
        {
            Say();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Sayout();
    }

    void Say()
    {
        objcan.SetActive(true);
        StopAllCoroutines();

        if (count_player >= finish) _state = state.complete;

        switch (_state)
        {
            case state.star:
                StartCoroutine(ShowDialog(star));
                _state = state.notComplete;
                break;
            case state.notComplete:
                StartCoroutine(ShowDialog(notcomplete));
                break;
            case state.complete:
                StartCoroutine(ShowDialog(complete));
                break;
        }
    }

    private IEnumerator ShowDialog(string say)
    {
        textSay.text = "";

        for (int i = 0; i < say.Length; i++)
        {
            textSay.text += say[i].ToString();
            yield return new WaitForSeconds(talkspeed);
        }
    }

    void Sayout()
    {
        StopAllCoroutines();
        objcan.SetActive(false);
    }

    void Get()
    {
        count_player++;
    }
}
