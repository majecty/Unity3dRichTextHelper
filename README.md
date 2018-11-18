# Unity3dRichTextHelper
This library helps you get substring of unity3d's rich  text. You can use this to implement a dialogue system

## How to use(simple)
```csharp

using RichTextSubstringHelper;

var richText = "<color=blue>blue</color>black";
richText.RichTextSubString(3); // <color=blue>blu</color>
richText.RichTextSubString(6); // <color=blue>blue</color>bl
```

When you want to make a dialogue system, displaying richtext may cause a trouble.
![CommonError](http://g.recordit.co/2sqiTVG655.gif)

This library helps you get substring of richtext easily.

## How to Install

Get unity package from below link

https://github.com/majecty/Unity3dRichTextHelper/releases

Or just copy and paste this file

https://github.com/majecty/Unity3dRichTextHelper/blob/master/Assets/RichTextHelper/RichTextHelper.cs

## More example
```csharp
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using RichTextSubstringHelper;

public class NewBehaviourScript : MonoBehaviour {
    [SerializeField]
    Text uiText;
    IEnumerator Start () {
        var firstText = "<color=blue>blah</color>x";
        for (int i = 0; i < firstText.RichTextLength(); i++)
        {
            yield return new WaitForSeconds(0.5f);
            uiText.text = firstText.RichTextSubString(i + 1);
        }
    }

}
```

## Performance

`richText.RichTextSubString(i)` takes O(i) time because it should read string character by character every time.

If you consider performance, use like below example.

```csharp
using System.Collections;
using UnityEngine;
using RichTextSubstringHelper;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {
    [SerializeField]
    Text uiText;

    IEnumerator Start ()
    {
        var richText = "<color=blue>blue</color>black";
        var maker = new RichTextSubStringMaker(richText);
        
        while (maker.IsConsumable())
        {
            maker.Consume();
            uiText.text = maker.GetRichText();
            yield return new WaitForSeconds(0.5f);
        }
    }
}

```


