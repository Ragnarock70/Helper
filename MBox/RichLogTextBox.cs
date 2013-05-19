//-----------------------
// Copyright © Ragnarock
//----------------------

using System;
using System.Drawing;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MBox
{
    class RichLogTextBox : RichTextBox
    {
        public enum OutputMode
        {
            Log,
            Error,
            Debug,
        }

        public bool ShowDebugMessages { get; set; }

        public RichLogTextBox()
        {
            ReadOnly = true;
        }

        public void Log(string message, OutputMode mode = OutputMode.Log)
        {
            Log(message, mode, true);
        }

        private void Log(string message, OutputMode mode, bool time)
        {
            Color txtColor;

            switch (mode)
            {
                case OutputMode.Log:
                    txtColor = Color.DarkBlue;
                    break;
                case OutputMode.Error:
                    if (ShowDebugMessages)
                        return;
                    txtColor = Color.Red;
                    break;
                case OutputMode.Debug:
                    txtColor = Color.SaddleBrown;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("mode");
            }

            var output = string.Format("\r\n{0}{1}", (time ? GetTime() : ""), message);

            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    SelectionStart = Text.Length;
                    SelectionColor = txtColor;
                    AppendText(output);
                    ScrollToCaret();
                }));
            }
            else
            {
                SelectionStart = Text.Length;
                SelectionColor = txtColor;
                AppendText(output);
                ScrollToCaret();
            }
        }

        public void WriteRandomShit()
        {
            Log(GetRandomShit());
            Text = Text.Trim();
        }

        private static string GetRandomShit()
        {
            var rnd = new Random();

            switch (rnd.Next(9, 16))
            {
                case 0:
                case 1:
                    return "Hi there :)";
                case 2:
                    return "Trial version expired ! 50$ to purchase lifetime license.\r\n\r\nLOLJK";
                case 3:
                    return "Meh. Shitty day for me. How is your ?";
                case 4:
                    return "Take a greeeaaat inspiration and say hello to the IRL !";
                case 5:
                    return string.Format("Day {0}: They still believe I am just a program.", rnd.Next(20, 77));
                case 6:
                    return "BEHIND YOU !";
                case 7:
                    return "BIG BROTHER IS WATCHING YOU /\\";
                case 8:
                    return "CONGRATULATION, YOU ARE THE 1'000'000 USER OF MBOX ! CLICK HERE TO GAIN YOUR PRICE !";
                case 9:
                    return "I DARE YOU, I DOUBBLE DARE YOU MOTHERF***ER ! SAY 'THIS PROGRAM IS NOT WORKING' ONE MORE GODDAM TIME !!";
                case 10:
                    return "Any suggestion ? E-mail me at... Nah ! I don't care about what you think `''';..;'''´\r\n(Real link is in the 'About' tab..)";
                case 11:
                    return "Hello";
                case 12:
                    return ".";
                default:
                    return "Random out of range.";
            }
        }


        public void WriteQuote()
        {
            if (Settings.Instance.QOTD == Quote.GTFO)
                return;

            var dlString = Settings.Instance.QOTD == Quote.English ? "http://www.bash.org/?random" : "http://danstonchat.com/random.html";
            var wClient = new WebClient();
            wClient.DownloadStringCompleted += delegate(object sender1, DownloadStringCompletedEventArgs e1)
            {
                if (e1.Error != null)
                {
                    Log("Unable to get your free quote... Be nice to Santa next time (or check your internet connection) !");
                    return;
                }

                var msg = "Your free quote of the day (thanks to bash.org & bashFR.org !):\r\n\r\n";
                string res;

                if (Settings.Instance.QOTD == Quote.English)
                {
                    var regex =
                        Regex.Match(e1.Result, "<p class=\"qt\">([^`]*?)</p>").
                            Value;
                    res = regex.Replace("<p class=\"qt\">", "")
                               .Replace("<br />", "")
                               .Replace("</p>", "");
                }
                else //french
                {
                    var regex = Regex.Match(e1.Result, "<p class=\"item-content\">([^`]*?)</p>").Value;

                    while (regex.Contains("<"))
                    {
                        var start = regex.IndexOf('<');
                        var end = regex.IndexOf('>');
                        regex = regex.Remove(start, end - start + 1);
                    }
                    res = regex;
                }

                var decoded = WebUtility.HtmlDecode(res.Trim());

                var bytes = Encoding.GetEncoding(28591).GetBytes(decoded); //iso-8859-1
                res = Encoding.UTF8.GetString(bytes);

                msg += res + "\r\n";
                Log(msg);
                wClient.Dispose();
            };
            wClient.DownloadStringAsync(new Uri(dlString));
        }

        private static string GetTime()
        {
            return string.Format("[{0}:{1:000}] ", DateTime.Now.ToLongTimeString(), DateTime.Now.Millisecond);
        }
    }
}
