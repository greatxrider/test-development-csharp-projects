using ccu1_illumigyn.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static ccu1_illumigyn.Class.class_globals;

namespace ccu1_illumigyn.Class
{
    public class class_voltagetest
    {
        string serialNumber;
        int testStep;
        int retestCount;

        public class_voltagetest()
        {
            //serialNumber = i_serialNumber;
            //testStep = i_testStep;
            //retestCount = i_retestCount;
        }
    
        public async Task<bool> D1VoltageTestAsync()
        {        
            try
            {
                Debug.WriteLine("", JigNumber);
                Debug.WriteLine("=================", JigNumber);
                Debug.WriteLine("D1 PIN1 P3V7 Test", JigNumber);
                Debug.WriteLine("=================", JigNumber);
                remarks = "";
                double D1LL = Convert.ToDouble(config_Dictionary["D1LL"]);
                double D1UL = Convert.ToDouble(config_Dictionary["D1UL"]);
                double D1_value = string.IsNullOrEmpty(Form_ccu1.instance.p1textbox.Text) ? 0 : Convert.ToDouble(Form_ccu1.instance.p1textbox.Text);

                Debug.WriteLine($"[INFO] D1 PIN1 P3V7 Test Lower Limit = {D1LL} V", JigNumber);
                Debug.WriteLine($"[INFO] D1 PIN1 P3V7 Test Upper Limit = {D1UL} V", JigNumber);

                if (D1LL <= Form_ccu1.instance.p1 && Form_ccu1.instance.p1 <= D1UL)
                {
                    Form_ccu1.instance.p1status_i.BackColor = Color.Lime;
                    Form_ccu1.instance.p1status_i.ForeColor = Color.White;
                    Form_ccu1.instance.p1status_i.Text = "PASSED";
                }
                else
                {
                    Form_ccu1.instance.p1status_i.BackColor = Color.Red;
                    Form_ccu1.instance.p1status_i.ForeColor = Color.White;
                    Form_ccu1.instance.p1status_i.Text = "FAILED";
                    Form_picture_guide.instance.errorcodetext.Text = "D1 PIN 1 VOLTAGE TEST ERROR";
                }

                Debug.WriteLine($"[INFO] D1 PIN1 P3V7 Test = {D1_value} V", JigNumber);

                if (D1LL <= D1_value && D1_value <= D1UL)
                {
                    Debug.WriteLine("[OK] D1 PIN1 P3V7 Test", JigNumber);
                }
                else
                {
                    Debug.WriteLine("[NOK] D1 PIN1 P3V7 Test", JigNumber);
                    Debug.WriteLine("[ERROR CODE] D1 PIN 1 VOLTAGE TEST ERROR", JigNumber);

                    if (!(D1LL <= Form_ccu1.instance.p1))
                    {
                        Debug.WriteLine("[REMARKS] MEASURED VOLTAGE BELOW LOWER LIMIT", JigNumber);
                        Form_container.instance.remarkstextbox.Text = "MEASURED VOLTAGE BELOW LOWER LIMIT";
                    }
                    else if (!(Form_ccu1.instance.p1 <= D1UL))
                    {
                        Debug.WriteLine("[REMARKS] MEASURED VOLTAGE ABOVE UPPER LIMIT", JigNumber);
                        Form_container.instance.remarkstextbox.Text = "MEASURED VOLTAGE ABOVE UPPER LIMIT";
                    }

                    Debug.WriteLine("[INFO] TEST FAILED", JigNumber);
                    Form_ccu1.instance.passfail();
                    return false;
                }

                Form_ccu1.instance.passfail();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in D1 PIN1 P3V7 Test.{Environment.NewLine}{ex.Message}", JigNumber);
                return false;
            }
        }

        public async Task<bool> R39VoltageTestAsync()
        {
            //=========================
            //R39 PIN1 SIGNAL P3V3 Test
            //=========================

            try
            {
                Debug.WriteLine("", JigNumber);
                Debug.WriteLine("=========================", JigNumber);
                Debug.WriteLine("R39 PIN1 SIGNAL P3V3 Test", JigNumber);
                Debug.WriteLine("=========================", JigNumber);
                remarks = "";
                double R39LL = Convert.ToDouble(config_Dictionary["R39LL"]);
                double R39UL = Convert.ToDouble(config_Dictionary["R39UL"]);
                double R39_value = string.IsNullOrEmpty(Form_ccu1.instance.p2textbox.Text) ? 0 : Convert.ToDouble(Form_ccu1.instance.p2textbox.Text);

                Debug.WriteLine($"[INFO] R39 PIN1 SIGNAL P3V3 Test Lower Limit = {R39LL} V", JigNumber);
                Debug.WriteLine($"[INFO] R39 PIN1 SIGNAL P3V3 Test Upper Limit = {R39UL} V", JigNumber);

                if (R39LL <= Form_ccu1.instance.p2 && Form_ccu1.instance.p2 <= R39UL)
                {
                    Form_ccu1.instance.p2status_i.BackColor = Color.Lime;
                    Form_ccu1.instance.p2status_i.ForeColor = Color.White;
                    Form_ccu1.instance.p2status_i.Text = "PASSED";
                }
                else
                {
                    Form_ccu1.instance.p2status_i.BackColor = Color.Red;
                    Form_ccu1.instance.p2status_i.ForeColor = Color.White;
                    Form_ccu1.instance.p2status_i.Text = "FAILED";
                    Form_picture_guide.instance.errorcodetext.Text = "R39 PIN 1 VOLTAGE TEST ERROR";
                }

                Debug.WriteLine($"[INFO] R39 PIN1 SIGNAL P3V3 Test = {R39_value} V", JigNumber);

                if (R39LL <= R39_value && R39_value <= R39UL)
                {
                    Debug.WriteLine("[OK] R39 PIN1 SIGNAL P3V3 Test", JigNumber);
                }
                else
                {
                    Debug.WriteLine("[NOK] R39 PIN1 SIGNAL P3V3 Test", JigNumber);
                    Debug.WriteLine("[INFO] ERROR CODE: R39 PIN 1 VOLTAGE TEST ERROR", JigNumber);

                    if (!(R39LL <= Form_ccu1.instance.p2))
                    {
                        Debug.WriteLine("[INFO] REMARKS: MEASURED VOLTAGE BELOW LOWER LIMIT", JigNumber);
                        Form_container.instance.remarkstextbox.Text = "MEASURED VOLTAGE BELOW LOWER LIMIT";
                    }
                    else if (!(Form_ccu1.instance.p2 <= R39UL))
                    {
                        Debug.WriteLine("[INFO] REMARKS: MEASURED VOLTAGE ABOVE UPPER LIMIT", JigNumber);
                        Form_container.instance.remarkstextbox.Text = "MEASURED VOLTAGE ABOVE UPPER LIMIT";
                    }

                    Debug.WriteLine("[INFO] TEST FAILED", JigNumber);
                    Form_ccu1.instance.passfail();
                    return false;
                }

                Form_ccu1.instance.passfail();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in R39 PIN1 SIGNAL P3V3 Test.{Environment.NewLine}{ex.Message}", JigNumber);
                return false;
            }
        }

        public async Task<bool> R43VoltageTestAsync()
        {
            //=========================
            //R43 PIN1 SIGNAL P2V5 Test
            //=========================

            try
            {             
                Debug.WriteLine("", JigNumber);
                Debug.WriteLine("=========================", JigNumber);
                Debug.WriteLine("R43 PIN1 SIGNAL P2V5 Test", JigNumber);
                Debug.WriteLine("=========================", JigNumber);
                remarks = "";
                double R43LL = Convert.ToDouble(config_Dictionary["R43LL"]);
                double R43UL = Convert.ToDouble(config_Dictionary["R43UL"]);
                double R43_value = string.IsNullOrEmpty(Form_ccu1.instance.p3textbox.Text) ? 0 : Convert.ToDouble(Form_ccu1.instance.p3textbox.Text);

                Debug.WriteLine($"[INFO] R43 PIN1 SIGNAL P2V5 Test Lower Limit = {R43LL} V", JigNumber);
                Debug.WriteLine($"[INFO] R43 PIN1 SIGNAL P2V5 Test Upper Limit = {R43UL} V", JigNumber);

                if (R43LL <= Form_ccu1.instance.p3 && Form_ccu1.instance.p3 <= R43UL)
                {
                    Form_ccu1.instance.p3status_i.BackColor = Color.Lime;
                    Form_ccu1.instance.p3status_i.ForeColor = Color.White;
                    Form_ccu1.instance.p3status_i.Text = "PASSED";
                }
                else
                {
                    Form_ccu1.instance.p3status_i.BackColor = Color.Red;
                    Form_ccu1.instance.p3status_i.ForeColor = Color.White;
                    Form_ccu1.instance.p3status_i.Text = "FAILED";
                    Form_picture_guide.instance.errorcodetext.Text = "R43 PIN 1 VOLTAGE TEST ERROR";
                }

                Debug.WriteLine($"[INFO] R43 PIN1 SIGNAL P2V5 Test = {R43_value} V", JigNumber);

                if (R43LL <= R43_value && R43_value <= R43UL)
                {
                    Debug.WriteLine("[OK] R43 PIN1 SIGNAL P2V5 Test", JigNumber);
                }
                else
                {
                    Debug.WriteLine("[NOK] R43 PIN1 SIGNAL P2V5 Test", JigNumber);
                    Debug.WriteLine("[INFO] ERROR CODE: R43 PIN 1 VOLTAGE TEST ERROR", JigNumber);

                    if (!(R43LL <= Form_ccu1.instance.p3))
                    {
                        Debug.WriteLine("[INFO] REMARKS: MEASURED VOLTAGE BELOW LOWER LIMIT", JigNumber);
                        Form_container.instance.remarkstextbox.Text = "MEASURED VOLTAGE BELOW LOWER LIMIT";
                    }
                    else if (!(Form_ccu1.instance.p3 <= R43UL))
                    {
                        Debug.WriteLine("[INFO] REMARKS: MEASURED VOLTAGE ABOVE UPPER LIMIT", JigNumber);
                        Form_container.instance.remarkstextbox.Text = "MEASURED VOLTAGE ABOVE UPPER LIMIT";
                    }

                    Debug.WriteLine("[INFO] TEST FAILED", JigNumber);
                    Form_ccu1.instance.passfail();
                    return false;
                }

                Form_ccu1.instance.passfail();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in R43 PIN1 SIGNAL P2V5 Test.{Environment.NewLine}{ex.Message}", JigNumber);
                return false;
            }
        }

        public async Task<bool> R42VoltageTestAsync()
        {
            //=========================
            //R42 PIN1 SIGNAL P1V1 Test
            //=========================
            try
            {
                Debug.WriteLine("", JigNumber);
                Debug.WriteLine("====================", JigNumber);
                Debug.WriteLine("R42 PIN1 SIGNAL P1V1 Test", JigNumber);
                Debug.WriteLine("====================", JigNumber);
                remarks = "";
                double R42LL = Convert.ToDouble(config_Dictionary["R42LL"]);
                double R42UL = Convert.ToDouble(config_Dictionary["R42UL"]);
                double R42_value = 0;

                Debug.WriteLine("[INFO] R42 PIN1 SIGNAL P1V1 Test Lower Limit = " + R42LL + " V", JigNumber);
                Debug.WriteLine("[INFO] R42 PIN1 SIGNAL P1V1 Test Upper Limit = " + R42UL + " V", JigNumber);

                if (Form_ccu1.instance.p4 >= double.Parse(config_Dictionary["R42LL"]) && Form_ccu1.instance.p4 <= double.Parse(config_Dictionary["R42UL"]))
                {
                    Form_ccu1.instance.p4status_i.BackColor = Color.Lime;
                    Form_ccu1.instance.p4status_i.ForeColor = Color.White;
                    Form_ccu1.instance.p4status_i.Text = "PASSED";
                }
                else
                {
                    Form_ccu1.instance.p4status_i.BackColor = Color.Red;
                    Form_ccu1.instance.p4status_i.ForeColor = Color.White;
                    Form_ccu1.instance.p4status_i.Text = "FAILED";
                    Form_picture_guide.instance.errorcodetext.Text = "R42 PIN 1 VOLTAGE TEST ERROR";
                }

                //Get R42 PIN1 SIGNAL P1V1 Value
                if (string.IsNullOrEmpty(Form_ccu1.instance.p4textbox.Text))
                {
                    R42_value = 0;
                }
                else
                {
                    R42_value = Convert.ToDouble(Form_ccu1.instance.p4textbox.Text);
                }          

                Debug.WriteLine("[INFO] R42 PIN1 SIGNAL P1V1 Test = " + R42_value + " V", JigNumber);

                if (R42LL <= R42_value && R42_value <= R42UL)
                {
                    Debug.WriteLine("[OK] R42 PIN1 SIGNAL P1V1 Test", JigNumber);
                    Form_ccu1.instance.passfail();
                    return true;
                }
                else
                {
                    Debug.WriteLine("[NOK] R42 PIN1 SIGNAL P1V1 Test", JigNumber);
                    Debug.WriteLine("[INFO] ERROR CODE: R42 PIN 1 VOLTAGE TEST ERROR", JigNumber);

                    if (!(Form_ccu1.instance.p4 >= double.Parse(config_Dictionary["R42LL"])))
                    {
                        Debug.WriteLine("[INFO] REMARKS: MEASURED VOLTAGE BELOW LOWER LIMIT", JigNumber);
                        Form_container.instance.remarkstextbox.Text = "MEASURED VOLTAGE BELOW LOWER LIMIT";
                    }
                    else if (!(Form_ccu1.instance.p4 <= double.Parse(config_Dictionary["R42UL"])))
                    {
                        Debug.WriteLine("[INFO] REMARKS: MEASURED VOLTAGE ABOVE UPPER LIMIT", JigNumber);
                        Form_container.instance.remarkstextbox.Text = "MEASURED VOLTAGE ABOVE UPPER LIMIT";
                    }

                    Debug.WriteLine("[INFO] TEST FAILED", JigNumber);
                    Form_ccu1.instance.passfail();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in R42 PIN1 SIGNAL P1V1 Test." + Environment.NewLine + ex.Message, JigNumber);
                return false;
            }
        }

        public async Task<bool> U10VoltageTestAsync()
        {
            //===========================
            //U10 PIN5 SIGNAL VRES_H Test
            //===========================
            try
            {
                Debug.WriteLine("", JigNumber);
                Debug.WriteLine("====================", JigNumber);
                Debug.WriteLine("U10 PIN5 SIGNAL VRES_H Test", JigNumber);
                Debug.WriteLine("====================", JigNumber);
                remarks = "";
                double U10LL = Convert.ToDouble(config_Dictionary["U10LL"]);
                double U10UL = Convert.ToDouble(config_Dictionary["U10UL"]);
                double U10_value = 0;

                Debug.WriteLine("[INFO] U10 PIN5 SIGNAL VRES_H Test Lower Limit = " + U10LL + " V", JigNumber);
                Debug.WriteLine("[INFO] U10 PIN5 SIGNAL VRES_H Test Upper Limit = " + U10UL + " V", JigNumber);

                if (Form_ccu1.instance.s1 >= double.Parse(config_Dictionary["U10LL"]) && Form_ccu1.instance.s1 <= double.Parse(config_Dictionary["U10UL"]))
                {
                    Form_ccu1.instance.s1status_i.BackColor = Color.Lime;
                    Form_ccu1.instance.s1status_i.ForeColor = Color.White;
                    Form_ccu1.instance.s1status_i.Text = "PASSED";
                }
                else
                {
                    Form_ccu1.instance.s1status_i.BackColor = Color.Red;
                    Form_ccu1.instance.s1status_i.ForeColor = Color.White;
                    Form_ccu1.instance.s1status_i.Text = "FAILED";
                    Form_picture_guide.instance.errorcodetext.Text = "U10 PIN 5 VOLTAGE TEST ERROR";
                }


                //Get U10 PIN5 SIGNAL VRES_H Value

                if (string.IsNullOrEmpty(Form_ccu1.instance.s1textbox.Text))
                {
                    U10_value = 0;
                }
                else
                {
                    U10_value = Convert.ToDouble(Form_ccu1.instance.s1textbox.Text);
                }

                Debug.WriteLine("[INFO] U10 PIN5 SIGNAL VRES_H Test = " + U10_value + " V", JigNumber);

                if (U10LL <= U10_value && U10_value <= U10UL)
                {
                    Debug.WriteLine("[OK] U10 PIN5 SIGNAL VRES_H Test", JigNumber);
                    Form_ccu1.instance.passfail();
                    return true;
                }
                else
                {
                    Debug.WriteLine("[NOK] U10 PIN5 SIGNAL VRES_H Test", JigNumber);
                    Debug.WriteLine("[INFO] ERROR CODE: U10 PIN 5 VOLTAGE TEST ERROR", JigNumber);

                    if (!(Form_ccu1.instance.s1 >= double.Parse(config_Dictionary["U10LL"])))
                    {
                        Debug.WriteLine("[INFO] REMARKS: MEASURED VOLTAGE BELOW LOWER LIMIT", JigNumber);
                        Form_container.instance.remarkstextbox.Text = "MEASURED VOLTAGE BELOW LOWER LIMIT";
                    }
                    else if (!(Form_ccu1.instance.s1 <= double.Parse(config_Dictionary["U10UL"])))
                    {
                        Debug.WriteLine("[INFO] REMARKS: MEASURED VOLTAGE ABOVE UPPER LIMIT", JigNumber);
                        Form_container.instance.remarkstextbox.Text = "MEASURED VOLTAGE ABOVE UPPER LIMIT";
                    }

                    Debug.WriteLine("[INFO] TEST FAILED", JigNumber);
                    Form_ccu1.instance.passfail();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in U10 PIN5 SIGNAL VRES_H Test." + Environment.NewLine + ex.Message, JigNumber);
                return false;
            }
        }

        public async Task<bool> U11VoltageTestAsync()
        {
            //===========================
            //U11 PIN5 SIGNAL VDD20 Test
            //===========================
            try
            {
                Debug.WriteLine("", JigNumber);
                Debug.WriteLine("====================", JigNumber);
                Debug.WriteLine("U11 PIN5 SIGNAL VDD20 Test", JigNumber);
                Debug.WriteLine("====================", JigNumber);
                remarks = "";
                double U11LL = Convert.ToDouble(config_Dictionary["U11LL"]);
                double U11UL = Convert.ToDouble(config_Dictionary["U11UL"]);
                double U11_value = 0;

                Debug.WriteLine("[INFO] U11 PIN5 SIGNAL VDD20 Test Lower Limit = " + U11LL + " V", JigNumber);
                Debug.WriteLine("[INFO] U11 PIN5 SIGNAL VDD20 Test Upper Limit = " + U11UL + " V", JigNumber);

                if (Form_ccu1.instance.s2 >= double.Parse(config_Dictionary["U11LL"]) && Form_ccu1.instance.s2 <= double.Parse(config_Dictionary["U11UL"]))
                {
                    Form_ccu1.instance.s2status_i.BackColor = Color.Lime;
                    Form_ccu1.instance.s2status_i.ForeColor = Color.White;
                    Form_ccu1.instance.s2status_i.Text = "PASSED";
                }
                else
                {
                    Form_ccu1.instance.s2status_i.BackColor = Color.Red;
                    Form_ccu1.instance.s2status_i.ForeColor = Color.White;
                    Form_ccu1.instance.s2status_i.Text = "FAILED";
                    Form_picture_guide.instance.errorcodetext.Text = "U11 PIN 5 VOLTAGE TEST ERROR";
                }

                //Get U11 PIN5 SIGNAL VDD20 Value
                if (string.IsNullOrEmpty(Form_ccu1.instance.s2textbox.Text))
                {
                    U11_value = 0;
                }
                else
                {
                    U11_value = Convert.ToDouble(Form_ccu1.instance.s2textbox.Text);
                }

                Debug.WriteLine("[INFO] U11 PIN5 SIGNAL VDD20 Test = " + U11_value + " V", JigNumber);

                if (U11LL <= U11_value && U11_value <= U11UL)
                {
                    Debug.WriteLine("[OK] U11 PIN5 SIGNAL VDD20 Test", JigNumber);
                    Form_ccu1.instance.passfail();
                    return true;
                }
                else
                {
                    Debug.WriteLine("[NOK] U11 PIN5 SIGNAL VDD20 Test", JigNumber);
                    Debug.WriteLine("[INFO] ERROR CODE: U11 PIN 5 VOLTAGE TEST ERROR", JigNumber);

                    if (!(Form_ccu1.instance.s2 >= double.Parse(config_Dictionary["U11LL"])))
                    {
                        Debug.WriteLine("[INFO] REMARKS: MEASURED VOLTAGE BELOW LOWER LIMIT", JigNumber);
                        Form_container.instance.remarkstextbox.Text = "MEASURED VOLTAGE BELOW LOWER LIMIT";
                    }
                    else if (!(Form_ccu1.instance.s2 <= double.Parse(config_Dictionary["U11UL"])))
                    {
                        Debug.WriteLine("[INFO] REMARKS: MEASURED VOLTAGE ABOVE UPPER LIMIT", JigNumber);
                        Form_container.instance.remarkstextbox.Text = "MEASURED VOLTAGE ABOVE UPPER LIMIT";
                    }

                    Debug.WriteLine("[INFO] TEST FAILED", JigNumber);
                    Form_ccu1.instance.passfail();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in U11 PIN5 SIGNAL VDD20 Test." + Environment.NewLine + ex.Message, JigNumber);
                return false;
            }
        }

        public async Task<bool> U12VoltageTestAsync()
        {
            //===========================
            //U12 PIN5 signal VDD33 Test
            //===========================
            try
            {
                Debug.WriteLine("", JigNumber);
                Debug.WriteLine("====================", JigNumber);
                Debug.WriteLine("U12 PIN5 signal VDD33 Test", JigNumber);
                Debug.WriteLine("====================", JigNumber);
                remarks = "";
                double U12LL = Convert.ToDouble(config_Dictionary["U12LL"]);
                double U12UL = Convert.ToDouble(config_Dictionary["U12UL"]);
                double U12_value = 0;

                Debug.WriteLine("[INFO] U12 PIN5 signal VDD33 Test Lower Limit = " + U12LL + " V", JigNumber);
                Debug.WriteLine("[INFO] U12 PIN5 signal VDD33 Test Upper Limit = " + U12UL + " V", JigNumber);

                if (Form_ccu1.instance.s3 >= double.Parse(config_Dictionary["U12LL"]) && Form_ccu1.instance.s3 <= double.Parse(config_Dictionary["U12UL"]))
                {
                    Form_ccu1.instance.s3status_i.BackColor = Color.Lime;
                    Form_ccu1.instance.s3status_i.ForeColor = Color.White;
                    Form_ccu1.instance.s3status_i.Text = "PASSED";
                }
                else
                {
                    Form_ccu1.instance.s3status_i.BackColor = Color.Red;
                    Form_ccu1.instance.s3status_i.ForeColor = Color.White;
                    Form_ccu1.instance.s3status_i.Text = "FAILED";
                    Form_picture_guide.instance.errorcodetext.Text = "U12 PIN 5 VOLTAGE TEST ERROR";
                }

                //Get U12 PIN5 SIGNAL VDD20 Value
                if (string.IsNullOrEmpty(Form_ccu1.instance.s3textbox.Text))
                {
                    U12_value = 0;
                }
                else
                {
                    U12_value = Convert.ToDouble(Form_ccu1.instance.s3textbox.Text);
                }

                Debug.WriteLine("[INFO] U12 PIN5 signal VDD33 Test = " + U12_value + " V", JigNumber);

                if (U12LL <= U12_value && U12_value <= U12UL)
                {
                    Debug.WriteLine("[OK] U12 PIN5 signal VDD33 Test", JigNumber);
                    Form_ccu1.instance.passfail();
                    return true;
                }
                else
                {
                    Debug.WriteLine("[NOK] U12 PIN5 signal VDD33 Test", JigNumber);
                    Debug.WriteLine("[INFO] ERROR CODE: U12 PIN 5 VOLTAGE TEST ERROR", JigNumber);

                    if (!(Form_ccu1.instance.s3 >= double.Parse(config_Dictionary["U12LL"])))
                    {
                        Debug.WriteLine("[INFO] REMARKS: MEASURED VOLTAGE BELOW LOWER LIMIT", JigNumber);
                        Form_container.instance.remarkstextbox.Text = "MEASURED VOLTAGE BELOW LOWER LIMIT";

                    }
                    else if (!(Form_ccu1.instance.s3 <= double.Parse(config_Dictionary["U12UL"])))
                    {
                        Debug.WriteLine("[INFO] REMARKS: MEASURED VOLTAGE ABOVE UPPER LIMIT", JigNumber);
                        Form_container.instance.remarkstextbox.Text = "MEASURED VOLTAGE ABOVE UPPER LIMIT";
                    }

                    Debug.WriteLine("[INFO] TEST FAILED", JigNumber);
                    Form_ccu1.instance.passfail();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in U12 PIN5 signal VDD33 Test." + Environment.NewLine + ex.Message, JigNumber);
                return false;
            }
        }

        public async Task<bool> U13VoltageTestAsync()
        {
            //===========================
            //U13 PIN5 SIGNAL VDDPIX Test
            //===========================
            try
            {
                Debug.WriteLine("", JigNumber);
                Debug.WriteLine("====================", JigNumber);
                Debug.WriteLine("U13 PIN5 SIGNAL VDDPIX Test", JigNumber);
                Debug.WriteLine("====================", JigNumber);
                remarks = "";
                double U13LL = Convert.ToDouble(config_Dictionary["U13LL"]);
                double U13UL = Convert.ToDouble(config_Dictionary["U13UL"]);
                double U13_value = 0;

                Debug.WriteLine("[INFO] U13 PIN5 SIGNAL VDDPIX Test Lower Limit = " + U13LL + " V", JigNumber);
                Debug.WriteLine("[INFO] U13 PIN5 SIGNAL VDDPIX Test Upper Limit = " + U13UL + " V", JigNumber);

                if (Form_ccu1.instance.s4 >= double.Parse(config_Dictionary["U13LL"]) && Form_ccu1.instance.s4 <= double.Parse(config_Dictionary["U13UL"]))
                {
                    Form_ccu1.instance.s4status_i.BackColor = Color.Lime;
                    Form_ccu1.instance.s4status_i.ForeColor = Color.White;
                    Form_ccu1.instance.s4status_i.Text = "PASSED";
                }
                else
                {
                    Form_ccu1.instance.s4status_i.BackColor = Color.Red;
                    Form_ccu1.instance.s4status_i.ForeColor = Color.White;
                    Form_ccu1.instance.s4status_i.Text = "FAILED";
                    Form_picture_guide.instance.errorcodetext.Text = "U13 PIN 5 VOLTAGE TEST ERROR";
                }

                //Get U13 PIN5 SIGNAL VDDPIX Value
                if (string.IsNullOrEmpty(Form_ccu1.instance.s4textbox.Text))
                {
                    U13_value = 0;
                }
                else
                {
                    U13_value = Convert.ToDouble(Form_ccu1.instance.s4textbox.Text);
                }

                Debug.WriteLine("[INFO] U13 PIN5 SIGNAL VDDPIX Test = " + U13_value + " V", JigNumber);

                if (U13LL <= U13_value && U13_value <= U13UL)
                {
                    Debug.WriteLine("[OK] U13 PIN5 SIGNAL VDDPIX Test", JigNumber);
                    Form_ccu1.instance.passfail();
                    return true;
                }
                else
                {
                    Debug.WriteLine("[NOK] U13 PIN5 SIGNAL VDDPIX Test", JigNumber);
                    Debug.WriteLine("[INFO] ERROR CODE: U13 PIN 5 VOLTAGE TEST ERROR", JigNumber);

                    if (!(Form_ccu1.instance.s4 >= double.Parse(config_Dictionary["U13LL"])))
                    {
                        Debug.WriteLine("[INFO] REMARKS: MEASURED VOLTAGE BELOW LOWER LIMIT", JigNumber);
                        Form_container.instance.remarkstextbox.Text = "MEASURED VOLTAGE BELOW LOWER LIMIT";
                    }
                    else if (!(Form_ccu1.instance.s4 <= double.Parse(config_Dictionary["U13UL"])))
                    {
                        Debug.WriteLine("[INFO] REMARKS: MEASURED VOLTAGE ABOVE UPPER LIMIT", JigNumber);
                        Form_container.instance.remarkstextbox.Text = "MEASURED VOLTAGE ABOVE UPPER LIMIT";
                    }

                    Debug.WriteLine("[INFO] TEST FAILED", JigNumber);
                    Form_ccu1.instance.passfail();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in U13 PIN5 SIGNAL VDDPIX Test." + Environment.NewLine + ex.Message, JigNumber);
                return false;
            }
        }

        public async Task<bool> U5VoltageTestAsync()
        {
            //=====================
            //U5 PIN5 SIGNAL VRES_H
            //=====================
            try
            {
                Debug.WriteLine("", JigNumber);
                Debug.WriteLine("====================", JigNumber);
                Debug.WriteLine("U5 PIN5 SIGNAL VRES_H Test", JigNumber);
                Debug.WriteLine("====================", JigNumber);
                remarks = "";
                double U5LL = Convert.ToDouble(config_Dictionary["U5LL"]);
                double U5UL = Convert.ToDouble(config_Dictionary["U5UL"]);
                double U5_value = 0;

                Debug.WriteLine("[INFO] U5 PIN5 SIGNAL VRES_H Test Lower Limit = " + U5LL + " V", JigNumber);
                Debug.WriteLine("[INFO] U5 PIN5 SIGNAL VRES_H Test Upper Limit = " + U5UL + " V", JigNumber);

                if (Form_ccu1.instance.sm1 >= double.Parse(config_Dictionary["U5LL"]) && Form_ccu1.instance.sm1 <= double.Parse(config_Dictionary["U5UL"]))
                {
                    Form_ccu1.instance.sm1status_i.BackColor = Color.Lime;
                    Form_ccu1.instance.sm1status_i.ForeColor = Color.White;
                    Form_ccu1.instance.sm1status_i.Text = "PASSED";
                }
                else
                {
                    Form_ccu1.instance.sm1status_i.BackColor = Color.Red;
                    Form_ccu1.instance.sm1status_i.ForeColor = Color.White;
                    Form_ccu1.instance.sm1status_i.Text = "FAILED";
                    Form_picture_guide.instance.errorcodetext.Text = "U5 PIN 5 VOLTAGE TEST ERROR";
                }

                //Get U5 PIN5 SIGNAL VDDPIX Value
                if (string.IsNullOrEmpty(Form_ccu1.instance.sm1textbox.Text))
                {
                    U5_value = 0;
                }
                else
                {
                    U5_value = Convert.ToDouble(Form_ccu1.instance.sm1textbox.Text);
                }

                Debug.WriteLine("[INFO] U5 PIN5 SIGNAL VRES_H Test = " + U5_value + " V", JigNumber);

                if (U5LL <= U5_value && U5_value <= U5UL)
                {
                    Debug.WriteLine("[OK] U5 PIN5 SIGNAL VRES_H Test", JigNumber);
                    Form_ccu1.instance.passfail();
                    return true;
                }
                else
                {
                    Debug.WriteLine("[NOK] U5 PIN5 SIGNAL VRES_H Test", JigNumber);
                    Debug.WriteLine("[INFO] ERROR CODE: U5 PIN 5 VOLTAGE TEST ERROR", JigNumber);

                    if (!(Form_ccu1.instance.sm1 >= double.Parse(config_Dictionary["U5LL"])))
                    {
                        Debug.WriteLine("[INFO] REMARKS: MEASURED VOLTAGE BELOW LOWER LIMIT", JigNumber);
                        Form_container.instance.remarkstextbox.Text = "MEASURED VOLTAGE BELOW LOWER LIMIT";
                    }
                    else if (!(Form_ccu1.instance.sm1 <= double.Parse(config_Dictionary["U5UL"])))
                    {
                        Debug.WriteLine("[INFO] REMARKS: MEASURED VOLTAGE ABOVE UPPER LIMIT", JigNumber);
                        Form_container.instance.remarkstextbox.Text = "MEASURED VOLTAGE ABOVE UPPER LIMIT";
                    }

                    Debug.WriteLine("[INFO] TEST FAILED", JigNumber);
                    Form_ccu1.instance.passfail();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in U5 PIN5 SIGNAL VRES_H Test." + Environment.NewLine + ex.Message, JigNumber);
                return false;
            }
        }

        public async Task<bool> U6VoltageTestAsync()
        {
            //====================
            //U6 PIN5 SIGNAL VDD20
            //====================
            try
            {
                Debug.WriteLine("", JigNumber);
                Debug.WriteLine("====================", JigNumber);
                Debug.WriteLine("U6 PIN5 SIGNAL VDD20 Test", JigNumber);
                Debug.WriteLine("====================", JigNumber);
                remarks = "";
                double U6LL = Convert.ToDouble(config_Dictionary["U6LL"]);
                double U6UL = Convert.ToDouble(config_Dictionary["U6UL"]);
                double U6_value = 0;

                Debug.WriteLine("[INFO] U6 PIN5 SIGNAL VDD20 Test Lower Limit = " + U6LL + " V", JigNumber);
                Debug.WriteLine("[INFO] U6 PIN5 SIGNAL VDD20 Test Upper Limit = " + U6UL + " V", JigNumber);

                if (Form_ccu1.instance.sm2 >= double.Parse(config_Dictionary["U6LL"]) && Form_ccu1.instance.sm2 <= double.Parse(config_Dictionary["U6UL"]))
                {
                    Form_ccu1.instance.sm2status_i.BackColor = Color.Lime;
                    Form_ccu1.instance.sm2status_i.ForeColor = Color.White;
                    Form_ccu1.instance.sm2status_i.Text = "PASSED";
                }
                else
                {
                    Form_ccu1.instance.sm2status_i.BackColor = Color.Red;
                    Form_ccu1.instance.sm2status_i.ForeColor = Color.White;
                    Form_ccu1.instance.sm2status_i.Text = "FAILED";
                    Form_picture_guide.instance.errorcodetext.Text = "U6 PIN 5 VOLTAGE TEST ERROR";
                }
                
                //Get U6 PIN5 SIGNAL VDDPIX Value
                if (string.IsNullOrEmpty(Form_ccu1.instance.sm2textbox.Text))
                {
                    U6_value = 0;
                }
                else
                {
                    U6_value = Convert.ToDouble(Form_ccu1.instance.sm2textbox.Text);
                }

                Debug.WriteLine("[INFO] U6 PIN5 SIGNAL VDD20 Test = " + U6_value + " V", JigNumber);
                
                if (U6LL <= U6_value && U6_value <= U6UL)
                {
                    Debug.WriteLine("[OK] U6 PIN5 SIGNAL VDD20 Test", JigNumber);
                    Form_ccu1.instance.passfail();
                    return true;
                }
                else
                {
                    Debug.WriteLine("[NOK] U6 PIN5 SIGNAL VDD20 Test", JigNumber);
                    Debug.WriteLine("[INFO] ERROR CODE: U6 PIN 5 VOLTAGE TEST ERROR", JigNumber);

                    if (!(Form_ccu1.instance.sm2 >= double.Parse(config_Dictionary["U6LL"])))
                    {
                        Debug.WriteLine("[INFO] REMARKS: MEASURED VOLTAGE BELOW LOWER LIMIT", JigNumber);
                        Form_container.instance.remarkstextbox.Text = "MEASURED VOLTAGE BELOW LOWER LIMIT";
                    }
                    else if (!(Form_ccu1.instance.sm2 <= double.Parse(config_Dictionary["U6UL"])))
                    {
                        Debug.WriteLine("[INFO] REMARKS: MEASURED VOLTAGE ABOVE UPPER LIMIT", JigNumber);
                        Form_container.instance.remarkstextbox.Text = "MEASURED VOLTAGE ABOVE UPPER LIMIT";
                    }
                    Debug.WriteLine("[INFO] TEST FAILED", JigNumber);
                    Form_ccu1.instance.passfail();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in U6 PIN5 SIGNAL VDD20 Test." + Environment.NewLine + ex.Message, JigNumber);
                return false;
            }        
        }

        public async Task<bool> U7VoltageTestAsync()
        {
            //====================
            //U7 PIN5 signal VDD33
            //====================
            try
            {
                Debug.WriteLine("", JigNumber);
                Debug.WriteLine("====================", JigNumber);
                Debug.WriteLine("U7 PIN5 signal VDD33 Test", JigNumber);
                Debug.WriteLine("====================", JigNumber);
                remarks = "";
                double U7LL = Convert.ToDouble(config_Dictionary["U7LL"]);
                double U7UL = Convert.ToDouble(config_Dictionary["U7UL"]);
                double U7_value = 0;

                Debug.WriteLine("[INFO] U7 PIN5 signal VDD33 Test Lower Limit = " + U7LL + " V", JigNumber);
                Debug.WriteLine("[INFO] U7 PIN5 signal VDD33 Test Upper Limit = " + U7UL + " V", JigNumber);

                if (Form_ccu1.instance.sm3 >= double.Parse(config_Dictionary["U7LL"]) && Form_ccu1.instance.sm3 <= double.Parse(config_Dictionary["U7UL"]))
                {
                    Form_ccu1.instance.sm3status_i.BackColor = Color.Lime;
                    Form_ccu1.instance.sm3status_i.ForeColor = Color.White;
                    Form_ccu1.instance.sm3status_i.Text = "PASSED";
                }
                else
                {
                    Form_ccu1.instance.sm3status_i.BackColor = Color.Red;
                    Form_ccu1.instance.sm3status_i.ForeColor = Color.White;
                    Form_ccu1.instance.sm3status_i.Text = "FAILED";
                    Form_picture_guide.instance.errorcodetext.Text = "U7 PIN 5 VOLTAGE TEST ERROR";
                }

                //Get U7 PIN5 SIGNAL VDDPIX Value
                if (string.IsNullOrEmpty(Form_ccu1.instance.sm3textbox.Text))
                {
                    U7_value = 0;
                }
                else
                {
                    U7_value = Convert.ToDouble(Form_ccu1.instance.sm3textbox.Text);
                }

                Debug.WriteLine("[INFO] U7 PIN5 signal VDD33 Test = " + U7_value + " V", JigNumber);
                if (U7LL <= U7_value && U7_value <= U7UL)
                {
                    Debug.WriteLine("[OK] U7 PIN5 signal VDD33 Test", JigNumber);
                    Form_ccu1.instance.passfail();
                    return true;
                }             
                else
                {
                    Debug.WriteLine("[NOK] U7 PIN5 signal VDD33 Test", JigNumber);
                    Debug.WriteLine("[INFO] ERROR CODE: U7 PIN 5 VOLTAGE TEST ERROR", JigNumber);

                    if (!(Form_ccu1.instance.sm3 >= double.Parse(config_Dictionary["U7LL"])))
                    {
                        Debug.WriteLine("[INFO] REMARKS: MEASURED VOLTAGE BELOW LOWER LIMIT", JigNumber);
                        Form_container.instance.remarkstextbox.Text = "MEASURED VOLTAGE BELOW LOWER LIMIT";
                    }
                    else if (!(Form_ccu1.instance.sm3 <= double.Parse(config_Dictionary["U7UL"])))
                    {
                        Debug.WriteLine("[INFO] REMARKS: MEASURED VOLTAGE ABOVE UPPER LIMIT", JigNumber);
                        Form_container.instance.remarkstextbox.Text = "MEASURED VOLTAGE ABOVE UPPER LIMIT";
                    }

                    Debug.WriteLine("[INFO] TEST FAILED", JigNumber);
                    Form_ccu1.instance.passfail();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in U7 PIN5 signal VDD33 Test." + Environment.NewLine + ex.Message, JigNumber);
                return false;
            }
        }

        public async Task<bool> U8VoltageTestAsync()
        {
            //=====================
            //U8 PIN5 SIGNAL VDDPIX
            //=====================
            try
            {
                Debug.WriteLine("", JigNumber);
                Debug.WriteLine("====================", JigNumber);
                Debug.WriteLine("U8 PIN5 SIGNAL VDDPIX Test", JigNumber);
                Debug.WriteLine("====================", JigNumber);
                remarks = "";
                double U8LL = Convert.ToDouble(config_Dictionary["U8LL"]);
                double U8UL = Convert.ToDouble(config_Dictionary["U8UL"]);
                double U8_value = 0;

                Debug.WriteLine("[INFO] U8 PIN5 SIGNAL VDDPIX Test Lower Limit = " + U8LL + " V", JigNumber);
                Debug.WriteLine("[INFO] U8 PIN5 SIGNAL VDDPIX Test Upper Limit = " + U8UL + " V", JigNumber);

                if (Form_ccu1.instance.sm4 >= double.Parse(config_Dictionary["U8LL"]) && Form_ccu1.instance.sm4 <= double.Parse(config_Dictionary["U8UL"]))
                {
                    Form_ccu1.instance.sm4status_i.BackColor = Color.Lime;
                    Form_ccu1.instance.sm4status_i.ForeColor = Color.White;
                    Form_ccu1.instance.sm4status_i.Text = "PASSED";
                }
                else
                {
                    Form_ccu1.instance.sm4status_i.BackColor = Color.Red;
                    Form_ccu1.instance.sm4status_i.ForeColor = Color.White;
                    Form_ccu1.instance.sm4status_i.Text = "FAILED";
                    Form_picture_guide.instance.errorcodetext.Text = "U8 PIN 5 VOLTAGE TEST ERROR";
                }
                Form_ccu1.instance.sm4status_i.ReadOnly = true;

                //Get U8 PIN5 SIGNAL VDDPIX Value
                if (string.IsNullOrEmpty(Form_ccu1.instance.sm4textbox.Text))
                {
                    U8_value = 0;
                }
                else
                {
                    U8_value = Convert.ToDouble(Form_ccu1.instance.sm4textbox.Text);
                }

                Debug.WriteLine("[INFO] U8 PIN5 SIGNAL VDDPIX Test = " + U8_value + " V", JigNumber);

                if (U8LL <= U8_value && U8_value <= U8UL)
                {
                    Debug.WriteLine("[OK] U8 PIN5 SIGNAL VDDPIX Test", JigNumber);
                    Form_ccu1.instance.passfail();
                    return true;
                }
                else
                {
                    Debug.WriteLine("[NOK] U8 PIN5 SIGNAL VDDPIX Test", JigNumber);
                    Debug.WriteLine("[INFO] ERROR CODE: U8 PIN 5 VOLTAGE TEST ERROR", JigNumber);

                    if (!(Form_ccu1.instance.sm4 >= double.Parse(config_Dictionary["U8LL"])))
                    {
                        Debug.WriteLine("[INFO] REMARKS: MEASURED VOLTAGE BELOW LOWER LIMIT", JigNumber);
                        Form_container.instance.remarkstextbox.Text = "MEASURED VOLTAGE BELOW LOWER LIMIT";
                    }
                    else if (!(Form_ccu1.instance.sm4 <= double.Parse(config_Dictionary["U8UL"])))
                    {
                        Debug.WriteLine("[INFO] REMARKS: MEASURED VOLTAGE ABOVE UPPER LIMIT", JigNumber);
                        Form_container.instance.remarkstextbox.Text = "MEASURED VOLTAGE ABOVE UPPER LIMIT";
                    }

                    Debug.WriteLine("[INFO] TEST FAILED", JigNumber);
                    Form_ccu1.instance.passfail();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in U8 PIN5 SIGNAL VDDPIX Test." + Environment.NewLine + ex.Message, JigNumber);
                return false;
            }
        }

        public void i_Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
