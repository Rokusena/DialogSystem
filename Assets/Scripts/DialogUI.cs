using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class DialogUI : MonoBehaviour
{
    public static DialogUI instance;

    public GameObject dialogUI;
    public Image portrait;
    public TextMeshProUGUI dialog;
    
    public float duration = 0.1f;
    

    int index = 0;
    bool isTalking;
    Character character;
    AudioSource audioSource;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);

        dialogUI.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    public void StartDialog(Character character)
    {
        Selector.instance.active = false;

        this.character = character;
        dialogUI.SetActive(true);
        index = 0;
        StartCoroutine(PlayMonologue());
    }

    private void Update()
    {
        if (!dialogUI.activeSelf) return;

        if (Input.GetKeyDown(KeyCode.Mouse0) && !isTalking)
        {
            index++;

            index = index >= character.monologue.Count ? 0 : index;

            StartCoroutine(PlayMonologue());
        }

        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            StopAllCoroutines();
            isTalking = false;
            dialogUI.SetActive(false);
            Selector.instance.active = true;
        }
    }

    IEnumerator PlayMonologue()
    {
        isTalking = true;

        var dialogLine = character.monologue[index];
        portrait.sprite = FindEmotion(dialogLine.emotion);

        dialog.text = "";

        foreach (var letter in dialogLine.text)
        {
            dialog.text += letter;
            
            audioSource.pitch = Random.Range(0.8f, 1.2f);
            audioSource.PlayOneShot(character.sound);

            yield return new WaitForSeconds(duration);
        }

        isTalking = false;
    }

    public Sprite FindEmotion(Emotion emotion)
    {
        foreach (var portrait in character.portraits)
        {
            if (portrait.emotion == emotion)
                return portrait.sprite;
        }

        return null;
    }
}
