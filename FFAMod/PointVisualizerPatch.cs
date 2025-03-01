﻿using HarmonyLib;
using Sonigon;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace FFAMod
{
    [HarmonyPatch(typeof(PointVisualizer))]
    internal class PointVisualizerPatch
    {
        [HarmonyPatch("DoShowPoints")]
        private static void Postfix()
        {
            var instance = PointVisualizer.instance;
            if (GM_ArmsRacePatch.winningTeamID == 2)
            {
                instance.text.color = PlayerSkinBank.GetPlayerSkinColors(2).winText;
                if (GM_ArmsRacePatch.p3Points == 1)
                {
                    instance.orangeFill.fillAmount = 0.5f;
                    HalfRed();
                    return;
                }
                instance.orangeFill.fillAmount = 1f;
                RoundRed();
                return;
            }
            else if (GM_ArmsRacePatch.winningTeamID == 3)
            {
                instance.text.color = PlayerSkinBank.GetPlayerSkinColors(3).winText;
                if (GM_ArmsRacePatch.p4Points == 1)
                {
                    instance.blueFill.fillAmount = 0.5f;
                    HalfGreen();
                    return;
                }
                instance.blueFill.fillAmount = 1f;
                RoundGreen();
                return;
            }
        }

        private static void HalfRed()
        {
            PointVisualizer.instance.text.text = "HALF RED";
        }

        private static void RoundRed()
        {
            PointVisualizer.instance.text.text = "ROUND RED";
        }

        private static void HalfGreen()
        {
            PointVisualizer.instance.text.text = "HALF GREEN";
        }

        private static void RoundGreen()
        {
            PointVisualizer.instance.text.text = "ROUND GREEN";
        }

        //[HarmonyPatch("DoWinSequence")]
        //private static bool Prefix(ref IEnumerator __result, int orangePoints, int bluePoints, int orangeRounds, int blueRounds)
        //{
        //    __result = DoWinSequence(orangePoints, bluePoints, orangeRounds, blueRounds);
        //    return false;
        //}

        //private static IEnumerator DoWinSequence(int orangePoints, int bluePoints, int orangeRounds, int blueRounds)
        //{
        //    int redRounds = GM_ArmsRacePatch.p3Rounds;
        //    int greenRounds = GM_ArmsRacePatch.p4Rounds;
        //    bool orangeWinner = GM_ArmsRacePatch.winningTeamID == 0;
        //    bool blueWinner = GM_ArmsRacePatch.winningTeamID == 1;
        //    bool redWinner = GM_ArmsRacePatch.winningTeamID == 2;
        //    var instance = PointVisualizer.instance;
        //    var resetBalls = AccessTools.Method(typeof(PointVisualizer), "ResetBalls");
        //    var close = AccessTools.Method(typeof(PointVisualizer), "Close");
        //    var getPointPos = AccessTools.Method(typeof(RoundCounter), "GetPointPos");
        //    RectTransform orangeBallRT = (RectTransform)AccessTools.Field(typeof(PointVisualizer), "orangeBallRT").GetValue(instance);
        //    RectTransform blueBallRT = (RectTransform)AccessTools.Field(typeof(PointVisualizer), "blueBallRT").GetValue(instance);
        //    float ballSmallSize = (float)AccessTools.Field(typeof(PointVisualizer), "ballSmallSize").GetValue(instance);
        //    float bigBallScale = (float)AccessTools.Field(typeof(PointVisualizer), "bigBallScale").GetValue(instance);
        //    yield return new WaitForSecondsRealtime(0.35f);
        //    SoundManager.Instance.Play(instance.soundWinRound, instance.transform);
        //    // this.ResetBalls();
        //    resetBalls.Invoke(instance, null);
        //    instance.bg.SetActive(true);
        //    instance.blueBall.gameObject.SetActive(true);
        //    instance.orangeBall.gameObject.SetActive(true);
        //    yield return new WaitForSecondsRealtime(0.2f);
        //    GamefeelManager.instance.AddUIGameFeelOverTime(10f, 0.1f);
        //    instance.DoShowPoints(orangePoints, bluePoints, orangeWinner);
        //    yield return new WaitForSecondsRealtime(0.35f);
        //    SoundManager.Instance.Play(instance.sound_UI_Arms_Race_A_Ball_Shrink_Go_To_Left_Corner, instance.transform);
        //    float c = 0f;
        //    while (c < instance.timeToScale)
        //    {
        //        if (orangeWinner)
        //        {
        //            // instance.orangeBallRT.sizeDelta = Vector2.LerpUnclamped(instance.orangeBallRT.sizeDelta, Vector2.one * instance.ballSmallSize, instance.scaleCurve.Evaluate(c / instance.timeToScale));
        //            orangeBallRT.sizeDelta = Vector2.LerpUnclamped(orangeBallRT.sizeDelta, Vector2.one * ballSmallSize, instance.scaleCurve.Evaluate(c / instance.timeToScale));
        //        }
        //        else if (blueWinner)
        //        {
        //            blueBallRT.sizeDelta = Vector2.LerpUnclamped(blueBallRT.sizeDelta, Vector2.one * ballSmallSize, instance.scaleCurve.Evaluate(c / instance.timeToScale));
        //        }
        //        else if (redWinner)
        //        {
        //            orangeBallRT.sizeDelta = Vector2.LerpUnclamped(orangeBallRT.sizeDelta, Vector2.one * ballSmallSize, instance.scaleCurve.Evaluate(c / instance.timeToScale));
        //        }
        //        else
        //        {
        //            blueBallRT.sizeDelta = Vector2.LerpUnclamped(blueBallRT.sizeDelta, Vector2.one * ballSmallSize, instance.scaleCurve.Evaluate(c / instance.timeToScale));
        //        }
        //        c += Time.unscaledDeltaTime;
        //        yield return null;
        //    }
        //    yield return new WaitForSecondsRealtime(instance.timeBetween);
        //    c = 0f;
        //    while (c < instance.timeToMove)
        //    {
        //        if (orangeWinner)
        //        {
        //            // instance.orangeBall.position = Vector3.LerpUnclamped(instance.orangeBall.position, UIHandler.instance.roundCounterSmall.GetPointPos(0), instance.scaleCurve.Evaluate(c / instance.timeToMove));
        //            instance.orangeBall.position = Vector3.LerpUnclamped(instance.orangeBall.position, (Vector3)getPointPos.Invoke(UIHandler.instance.roundCounterSmall, new object[] { 0 }), instance.scaleCurve.Evaluate(c / instance.timeToMove));

        //        }
        //        else if (blueWinner)
        //        {
        //            instance.blueBall.position = Vector3.LerpUnclamped(instance.blueBall.position, (Vector3)getPointPos.Invoke(UIHandler.instance.roundCounterSmall, new object[] { 1 }), instance.scaleCurve.Evaluate(c / instance.timeToMove));
        //        }
        //        else if (redWinner)
        //        {
        //            instance.orangeBall.position = Vector3.LerpUnclamped(instance.orangeBall.position, (Vector3)getPointPos.Invoke(UIHandlerPatch.roundCounterSmall2, new object[] { 0 }), instance.scaleCurve.Evaluate(c / instance.timeToMove));
        //        }
        //        else
        //        {
        //            instance.blueBall.position = Vector3.LerpUnclamped(instance.blueBall.position, (Vector3)getPointPos.Invoke(UIHandlerPatch.roundCounterSmall2, new object[] { 1 }), instance.scaleCurve.Evaluate(c / instance.timeToMove));
        //        }
        //        c += Time.unscaledDeltaTime;
        //        yield return null;
        //    }
        //    SoundManager.Instance.Play(instance.sound_UI_Arms_Race_B_Ball_Go_Down_Then_Expand, instance.transform);
        //    if (orangeWinner)
        //    {
        //        instance.orangeBall.position = (Vector3)getPointPos.Invoke(UIHandler.instance.roundCounterSmall, new object[] { 0 });
        //    }
        //    else if (blueWinner)
        //    {
        //        instance.blueBall.position = (Vector3)getPointPos.Invoke(UIHandler.instance.roundCounterSmall, new object[] { 1 });
        //    }
        //    else if (redWinner)
        //    {
        //        instance.orangeBall.position = (Vector3)getPointPos.Invoke(UIHandlerPatch.roundCounterSmall2, new object[] { 0 });
        //    }
        //    else
        //    {
        //        instance.blueBall.position = (Vector3)getPointPos.Invoke(UIHandlerPatch.roundCounterSmall2, new object[] { 1 });
        //    }
        //    yield return new WaitForSecondsRealtime(instance.timeBetween);
        //    c = 0f;
        //    while (c < instance.timeToMove)
        //    {
        //        if (!orangeWinner)
        //        {
        //            instance.orangeBall.position = Vector3.LerpUnclamped(instance.orangeBall.position, CardChoiceVisuals.instance.transform.position, instance.scaleCurve.Evaluate(c / instance.timeToMove));
        //        }
        //        else if (!blueWinner)
        //        {
        //            instance.blueBall.position = Vector3.LerpUnclamped(instance.blueBall.position, CardChoiceVisuals.instance.transform.position, instance.scaleCurve.Evaluate(c / instance.timeToMove));
        //        }
        //        else if (!redWinner)
        //        {
        //            instance.orangeBall.position = Vector3.LerpUnclamped(instance.orangeBall.position, CardChoiceVisuals.instance.transform.position, instance.scaleCurve.Evaluate(c / instance.timeToMove));
        //        }
        //        else
        //        {
        //            instance.blueBall.position = Vector3.LerpUnclamped(instance.blueBall.position, CardChoiceVisuals.instance.transform.position, instance.scaleCurve.Evaluate(c / instance.timeToMove));
        //        }
        //        c += Time.unscaledDeltaTime;
        //        yield return null;
        //    }
        //    if (!orangeWinner)
        //    {
        //        instance.orangeBall.position = CardChoiceVisuals.instance.transform.position;
        //    }
        //    else if (!blueWinner)
        //    {
        //        instance.blueBall.position = CardChoiceVisuals.instance.transform.position;
        //    }
        //    else if (!redWinner)
        //    {
        //        instance.orangeBall.position = CardChoiceVisuals.instance.transform.position;
        //    }
        //    else
        //    {
        //        instance.blueBall.position = CardChoiceVisuals.instance.transform.position;
        //    }
        //    yield return new WaitForSecondsRealtime(instance.timeBetween);
        //    c = 0f;
        //    while (c < instance.timeToScale)
        //    {
        //        if (!orangeWinner)
        //        {
        //            orangeBallRT.sizeDelta = Vector2.LerpUnclamped(orangeBallRT.sizeDelta, Vector2.one * bigBallScale, instance.scaleCurve.Evaluate(c / instance.timeToScale));
        //        }
        //        else if (!blueWinner)
        //        {
        //            blueBallRT.sizeDelta = Vector2.LerpUnclamped(blueBallRT.sizeDelta, Vector2.one * bigBallScale, instance.scaleCurve.Evaluate(c / instance.timeToScale));
        //        }
        //        else if (!redWinner)
        //        {
        //            orangeBallRT.sizeDelta = Vector2.LerpUnclamped(orangeBallRT.sizeDelta, Vector2.one * bigBallScale, instance.scaleCurve.Evaluate(c / instance.timeToScale));
        //        }
        //        else
        //        {
        //            blueBallRT.sizeDelta = Vector2.LerpUnclamped(blueBallRT.sizeDelta, Vector2.one * bigBallScale, instance.scaleCurve.Evaluate(c / instance.timeToScale));
        //        }
        //        c += Time.unscaledDeltaTime;
        //        yield return null;
        //    }
        //    SoundManager.Instance.Play(instance.sound_UI_Arms_Race_C_Ball_Pop_Shake, instance.transform);
        //    GamefeelManager.instance.AddUIGameFeelOverTime(10f, 0.2f);
        //    // CardChoiceVisuals.instance.Show((!orangeWinner) ? 0 : 1, false);
        //    CardChoiceVisuals.instance.Show(GM_ArmsRacePatch.winningTeamID, false);
        //    UIHandler.instance.roundCounterSmall.UpdateRounds(orangeRounds, blueRounds);
        //    UIHandlerPatch.roundCounterSmall2.UpdateRounds(redRounds, greenRounds);
        //    UIHandler.instance.roundCounterSmall.UpdatePoints(0, 0);
        //    UIHandlerPatch.roundCounterSmall2.UpdatePoints(0, 0);
        //    instance.DoShowPoints(0, 0, orangeWinner);
        //    close.Invoke(instance, null);
        //    yield break;
        //}
    }
}
