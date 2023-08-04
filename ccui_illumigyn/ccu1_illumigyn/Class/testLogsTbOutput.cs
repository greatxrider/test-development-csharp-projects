using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ccu1_illumigyn
{
    public class testLogsTbOutput : ConsoleTraceListener
    {
        delegate void stringSendDelagate(string text);
        TextBox tboutput;
        Label _lbl;
        string jigNumber;
        string itimeOut;
        stringSendDelagate invoke_write;
        stringSendDelagate invoke_set;

        public testLogsTbOutput(TextBox itbOutput, Label ilbl, string ijigNum, string itimeout)
        {
            tboutput = itbOutput;
            _lbl = ilbl;
            jigNumber = ijigNum;
            itimeOut = itimeout;
            invoke_write = new stringSendDelagate(SendString);
            invoke_set = new stringSendDelagate(SetString);
        }

        public override void WriteLine(string receiveText)
        {
            string temp_text = "";
            string temp_text2 = "";

            if (receiveText == "ABORTED")
            {
                _lbl.Invoke(invoke_set, new object[] { temp_text + Environment.NewLine });
            }

            if (receiveText != "")
            {
                temp_text = receiveText.Substring(0, 1);

                if (temp_text == jigNumber)
                {
                    temp_text2 = receiveText.Substring(3, receiveText.Length - 3);
                    tboutput.Invoke(invoke_write, new object[] { temp_text2 + Environment.NewLine });
                }

                else if (temp_text == itimeOut)
                {
                    temp_text2 = receiveText.Substring(3, receiveText.Length - 3);
                    _lbl.Invoke(invoke_set, new object[] { temp_text2 + Environment.NewLine });
                }
            }
        }

        private void SendString(string text)
        {
            tboutput.AppendText(text);
        }

        private void SetString(string text)
        {
            _lbl.Text = text;
        }
    }
}