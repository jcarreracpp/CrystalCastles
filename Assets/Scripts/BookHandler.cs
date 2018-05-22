using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookHandler : MonoBehaviour {
    public SkinnedMeshRenderer smr;
    public MeshRenderer booksmr;
    public float speed;
    public bool isRunning = false;
    public Texture[] pages;
    public Texture[] book;
    public int cursor = 0;
    public Material bufferPage;
    public Material bufferBook;

    private void Start()
    {
        bufferPage = new Material(Shader.Find("Diffuse"));
        bufferBook = new Material(Shader.Find("Diffuse"));
        pages = new Texture[6];
        pages[0] = Resources.Load("Book Textures/page0") as Texture;
        pages[1] = Resources.Load("Book Textures/page1") as Texture;
        pages[2] = Resources.Load("Book Textures/page2") as Texture;
        pages[3] = Resources.Load("Book Textures/page3") as Texture;
        pages[4] = Resources.Load("Book Textures/page4") as Texture;
        pages[5] = Resources.Load("Book Textures/page5") as Texture;
        book = new Texture[6];
        book[0] = Resources.Load("Book Textures/book0") as Texture;
        book[1] = Resources.Load("Book Textures/book1") as Texture;
        book[2] = Resources.Load("Book Textures/book2") as Texture;
        book[3] = Resources.Load("Book Textures/book3") as Texture;
        book[4] = Resources.Load("Book Textures/book4") as Texture;
        book[5] = Resources.Load("Book Textures/book5") as Texture;
        bufferPage.SetTexture("_MainTex", pages[0]);
        bufferBook.SetTexture("_MainTex", book[0]);
        transform.Find("Pages").GetComponent<SkinnedMeshRenderer>().material = bufferPage;
        transform.Find("Book").GetComponent<MeshRenderer>().material = bufferBook;
    }

    public void flipRight() {
        if (!isRunning && cursor >= 0 && cursor <= 4)
        {
            isRunning = true;
            StartCoroutine(right());
        }
    }

    public void flipLeft() {
        if (!isRunning && cursor >= 1 && cursor <= 5)
        {
            isRunning = true;
            StartCoroutine(left());
        }
    }

    private IEnumerator right() {
        float increment = 0;
        bool swapped = false;
        while (increment < 100)
        {
            yield return null;
            smr.SetBlendShapeWeight(0, increment);
            increment += speed * Time.deltaTime;
            if (increment >= 15 && !swapped)
            {
                bufferBook.SetTexture("_MainTex", book[cursor + 1]);
                swapped = true;
            }
        }
        swapped = false;
        smr.SetBlendShapeWeight(0, 0);
        bufferPage.SetTexture("_MainTex", pages[cursor + 1]);
        bufferBook.SetTexture("_MainTex", book[cursor]);
        smr.SetBlendShapeWeight(1, 100);
        increment = 100;
        while (increment > 0) {
            yield return null;
            smr.SetBlendShapeWeight(1, increment);
            increment -= speed * Time.deltaTime;
            if (increment <= 10 && !swapped)
            {
                bufferBook.SetTexture("_MainTex", book[cursor + 1]);
            }
        }
        smr.SetBlendShapeWeight(1, 0);
        yield return null;
        isRunning = false;
        cursor++;
    }

    private IEnumerator left() {
        float increment = 0;
        bool swapped = false;
        while (increment < 100)
        {
            yield return null;
            smr.SetBlendShapeWeight(1, increment);
            increment += speed * Time.deltaTime;
            if (increment >= 15 && !swapped)
            {
                bufferBook.SetTexture("_MainTex", book[cursor - 1]);
                swapped = true;
            }
        }
        swapped = false;
        smr.SetBlendShapeWeight(1, 0);
        bufferPage.SetTexture("_MainTex", pages[cursor - 1]);
        bufferBook.SetTexture("_MainTex", book[cursor]);
        smr.SetBlendShapeWeight(0, 100);
        increment = 100;
        while (increment > 0)
        {
            yield return null;
            smr.SetBlendShapeWeight(0, increment);
            increment -= speed * Time.deltaTime;
            if (increment <= 15 && !swapped)
            {
                bufferBook.SetTexture("_MainTex", book[cursor - 1]);
            }
        }
        smr.SetBlendShapeWeight(0, 0);
        yield return null;
        isRunning = false;
        cursor--;
    }
}
