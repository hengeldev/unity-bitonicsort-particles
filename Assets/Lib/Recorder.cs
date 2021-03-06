﻿using UnityEngine;

namespace kmty.Util {
    public class Recorder : MonoBehaviour {

        public string folderName;
        public int framerate = 60;
        public int maxRecordSeconds = 180;
        public bool recode = false;
        int frameCount;

        void Start() {
            if (recode) StartRecording();
        }

        void StartRecording() {
            System.IO.Directory.CreateDirectory(folderName);
            Time.captureFramerate = framerate;
            frameCount = -1;
        }

        void Update() {
            if (!string.IsNullOrEmpty(folderName) && frameCount > 0 && frameCount < framerate * maxRecordSeconds && recode)
                ScreenCapture.CaptureScreenshot($"{folderName}/frame{frameCount.ToString("0000")}.png");
            frameCount++;
        }
    }
}