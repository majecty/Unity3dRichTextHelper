//  Copyright 2018 Park Juhyung <majecty@gmail.com>
//  Permission is hereby granted, free of charge, to any person obtaining a 
//  copy of this software and associated documentation files (the "Software"), 
//  to deal in the Software without restriction, including without limitation 
//  the rights to use, copy, modify, merge, publish, distribute, sublicense, 
//  and/or sell copies of the Software, and to permit persons to whom the 
//  Software is furnished to do so, subject to the following conditions:
//
//  The above copyright notice and this permission notice shall be included in 
//  all copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS 
//  OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING 
//  FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
//  DEALINGS IN THE SOFTWARE.

using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using RichTextSubstringHelper;

public class RichTextHelperTest
{
    [Test]
    public void SimpleTest() {
        Assert.AreEqual("a".RichTextSubString(0), "");
        Assert.AreEqual("a".RichTextSubString(1), "a");

        var sampleText = "UnityTest behaves ";
        Assert.AreEqual(sampleText.RichTextSubString(sampleText.Length), sampleText);
        Assert.AreEqual(sampleText.RichTextLength(), sampleText.Length);
    }

    [Test]
    public void TagTest()
    {
        var sampleTagText = "<color=#000>blah</color>x";
        Assert.AreEqual(sampleTagText.RichTextSubString(5), sampleTagText);
        Assert.AreEqual(sampleTagText.RichTextSubString(1), "<color=#000>b</color>");
        Assert.AreEqual(sampleTagText.RichTextLength(), 5);
    }

    [Test]
    public void NestedTest()
    {
        var sampleTagText = "<color=#000>a<i>b<b>c</b>d</i></color>e";
        Assert.AreEqual(sampleTagText.RichTextSubString(5), sampleTagText);
        Assert.AreEqual(sampleTagText.RichTextSubString(1), "<color=#000>a</color>");
        Assert.AreEqual(sampleTagText.RichTextSubString(2), "<color=#000>a<i>b</i></color>");
        Assert.AreEqual(sampleTagText.RichTextSubString(3), "<color=#000>a<i>b<b>c</b></i></color>");
        Assert.AreEqual(sampleTagText.RichTextSubString(4), "<color=#000>a<i>b<b>c</b>d</i></color>");
        Assert.AreEqual(sampleTagText.RichTextLength(), 5);
    }

    [Test]
    public void CloseTagIsLast()
    {
        var sampleTagText = "<color=#000>a<i>b<b>c</b>d</i></color>";
        Assert.AreEqual(sampleTagText.RichTextSubString(5), sampleTagText);
        Assert.AreEqual(sampleTagText.RichTextSubString(1), "<color=#000>a</color>");
        Assert.AreEqual(sampleTagText.RichTextSubString(2), "<color=#000>a<i>b</i></color>");
        Assert.AreEqual(sampleTagText.RichTextSubString(3), "<color=#000>a<i>b<b>c</b></i></color>");
        Assert.AreEqual(sampleTagText.RichTextSubString(4), "<color=#000>a<i>b<b>c</b>d</i></color>");
        Assert.AreEqual(sampleTagText.RichTextLength(), 4);
    }
}
