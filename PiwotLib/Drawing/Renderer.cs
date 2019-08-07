using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using PiwotLib.Math;
using System.Collections;

namespace PiwotLib.Drawing
{
    class Renderer
    {
        public enum HorizontalTextAlignment { left, middle, right }
        public enum VerticalTextAlignment { upper, middle, lower }
        static Int2 windowSize;
        static int debugLines = 0;

        public static Int2 WindowSize
        {
            get { return windowSize; }
            set
            {
                if (windowSize == value)
                    return;
                if (value.X < 0 || value.X < 0)
                {
                    throw new ArgumentException("Width and height of console window must be greater than 0", "windowSize");
                }

                windowSize = value;
                if (debugMode)
                {
                    SetupDebugMode();
                }

                Console.SetWindowSize(windowSize.X, windowSize.X);
            }
        }
        static bool asyncMode;
        static Thread drawingThread;
        static Stopwatch stopwatch;
        static Queue requests = Queue.Synchronized(new Queue());
        static int requestPointer;
        static bool visableCursor;
        public static bool VisableCursor
        {
            get { return visableCursor; }
            set
            {
                if (value == visableCursor)
                    return;
                Console.CursorVisible = value;
                visableCursor = value;
            }
        }
        static bool debugMode;
        public static bool DebugMode
        {
            get { return debugMode; }
            set
            {
                if (value == debugMode)
                    return;
                debugMode = value;
                if (debugMode)
                {
                    SetupDebugMode();
                }

                Console.SetWindowSize(windowSize.X, windowSize.X);
            }
        }
        static long frame = 0;
        static long requestCount = 0;
        static int threadCount = 0;
        static int lastSleepTime = 0;
        static int droppedRequests = 0;
        public static bool AsyncMode
        {
            get { return asyncMode; }
            set
            {
                if (asyncMode == value)
                    return;
                asyncMode = value;
                if (asyncMode)
                {
                    //requests = new Queue<RenderRequest>();
                    drawingThread = new Thread(AsyncWrittingLoop);
                    drawingThread.Start();
                }
                else
                {
                    if (requests != null)
                    {
                        requests.Clear();
                        requests = null;
                    }
                    if (drawingThread.IsAlive)
                    {
                        drawingThread.Abort();
                    }
                }
            }
        }
        static int asyncFrameLenght = 10;
        public static int AsyncFrameLenght
        {
            get { return asyncFrameLenght; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("AsyncFrameLenght cannot be lower than 1", "asyncFrameLenght");
                }
                asyncFrameLenght = value;
            }
        }

        static List<TimedTextRequest> timedTextRequests;

        static Renderer()
        {
            Console.OutputEncoding = Encoding.UTF8;
            timedTextRequests = new List<TimedTextRequest>();
            Console.CursorVisible = false;
            AsyncMode = true;
            requestPointer = 0;
        }

        static void SetupDebugMode()
        {
            debugLines = 0;
            if (debugMode)
            {
                debugLines++;
            }
            windowSize.X += debugLines;
        }

        static void AsyncWrittingDebug()
        {
            int sleepTime, elapsedTime, queleLen = 0, charCount = 0;

            stopwatch.Restart();
            RenderRequest tRequest;
            while (requests.Count > 0)
            {
                queleLen++;
                tRequest = (RenderRequest)requests.Dequeue();
                {
                    charCount += tRequest.Text.Length;
                    Write(tRequest);

                    tRequest = null;
                }
            }
            requests.Clear();
            stopwatch.Stop();
            elapsedTime = (int)stopwatch.ElapsedMilliseconds;
            sleepTime = asyncFrameLenght - elapsedTime - Arit.Clamp(lastSleepTime, int.MinValue, 0);

            if (queleLen > 0)
            {
                string debugString = "";
                debugString += $"Frame len: {$"{asyncFrameLenght}".PadLeft(5)}, ";
                debugString += $"Elapsed: {$"{elapsedTime}".PadLeft(5)}, ";
                debugString += $"Sleep: {$"{sleepTime}".PadLeft(5)}, ";
                debugString += $"Queue len: {$"{queleLen}".PadLeft(5)}, ";
                debugString += $"Chars: {$"{charCount}".PadLeft(8)}, ";
                debugString += $"Requests: {$"{requestCount}".PadLeft(8)}, ";
                debugString += $"Hist ID: {$"{requestPointer}".PadLeft(4)}, ";
                debugString += $"Dropped: {$"{droppedRequests}".PadLeft(2)}";

                AsyncWrite(debugString.PadRight(windowSize.X).Pastel(Color.DarkBlue).PastelBg(Color.LightGray), 0, 0);
            }
            AsyncWrite($"Frame: {$"{frame}".PadLeft(8)}".Pastel(Color.DarkViolet).PastelBg(Color.LightGray), windowSize.x - 16, 0);
            lastSleepTime = sleepTime;
            AgeTimedTextRequests(elapsedTime + sleepTime);

            Thread.Sleep(Arit.Clamp(sleepTime, 0, asyncFrameLenght));
        }

        static void AsyncWritting()
        {
            stopwatch.Restart();
            while (requests.Count > 0)
            {
                Write((RenderRequest)requests.Dequeue());
            }
            AgeTimedTextRequests((int)stopwatch.ElapsedMilliseconds);
            Thread.Sleep(Arit.Clamp(asyncFrameLenght - (int)stopwatch.ElapsedMilliseconds, 0, asyncFrameLenght));
        }

        static void AsyncWrittingLoop()
        {
            threadCount++;
            frame = 0;
            stopwatch = new Stopwatch();
            try
            {
                while (asyncMode)
                {
                    if (debugMode)
                    {
                        AsyncWrittingDebug();
                    }
                    else
                    {
                        AsyncWritting();
                    }
                    frame++;
                }
            }
            catch (ThreadAbortException e)
            {

            }
        }

        public static void Write(RenderRequest request)
        {
            requestCount++;
            AsyncWrite(request.Text, request.X, request.Y + debugLines);
        }
        static void AsyncWrite(string text, int x, int y)
        {
            if (x < 0)
                x = 0;
            if (y < 0)
                y = 0;
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }
        public static void Write(string text, Int2 position)
        {
            Write(text, position.x, position.y);
        }
        public static void Write(string text, int x, int y)
        {
            if (AsyncMode)
            {
                requests.Enqueue(new RenderRequest(text, x, y));
                return;
            }
            if (x < 0)
                x = 0;
            if (y < 0)
                y = 0;
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }

        public static void SyncWrite(string text, Int2 position)
        {
            SyncWrite(text, position.x, position.y);
        }

        public static void SyncWrite(string text, int x, int y)
        {
            if (x < 0)
                x = 0;
            if (y < 0)
                y = 0;
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }

        public static void Write(int text, Int2 position)
        {
            Write(text.ToString(), position.x, position.y);
        }
        public static void Write(int text, int x, int y)
        {
            Write(text.ToString(), x, y);
        }

        public static bool IsBorder(Int2 pos, Int2 size)
        {
            return !(pos.x > 0 && pos.x < size.x - 1 && pos.y > 0 && pos.y < size.y - 1);
        }

        public static void AddDissapearingText(string text, int timeOnScreen, Int2 position)
        {
            AddDissapearingText(text, "", timeOnScreen, position);
        }

        public static void AddDissapearingText(string text, string clearingString, int timeOnScreen, Int2 position)
        {
            timedTextRequests.Add(new TimedTextRequest(text, clearingString, timeOnScreen, position));
            Write(text, position);
        }

        public static void EraseTimedText(TimedTextRequest ttr)
        {
            Write(ttr.ClearingString, ttr.Position);
            timedTextRequests.Remove(ttr);
        }

        static void AgeTimedTextRequests(int elapsed)
        {
            for (int i = 0; i < timedTextRequests.Count; i++)
            {
                timedTextRequests[i].Age(elapsed);
            }
        }

    }

    class RenderRequest
    {
        public string Text { get; protected set; }
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public RenderRequest(string text, int x, int y)
        {
            Text = text;
            X = x;
            Y = y;
        }
    }

    class TimedTextRequest
    {
        public int lifeTime { get; protected set; }
        public string Text { get; protected set; }
        public string ClearingString { get; protected set; }
        public Int2 Position { get; protected set; }
        public TimedTextRequest(string text, string clearingString, int lifeTime, Int2 position)
        {
            Position = position;
            Text = text;
            if (clearingString.Length < text.Length)
            {
                clearingString = clearingString.PadRight(text.Length - clearingString.Length, ' ');
            }
            ClearingString = clearingString;
            this.lifeTime = lifeTime;
        }

        public void Age(int time)
        {
            lifeTime -= time;
            if (lifeTime <= 0)
            {
                Renderer.EraseTimedText(this);
            }
        }
    }
