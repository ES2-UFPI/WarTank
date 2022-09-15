using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestPlayerMoviment
{
    [Test]
    public void TestPlayerMovimentSimplePasses()
    {
        var playerMoviment = new PlayerMoviment();
        float resultCalcRotate = playerMoviment.CalcRotate(3.0f, 3.0f, 3.0f);

        Assert.AreEqual(resultCalcRotate, 27.0f);
    }
}
