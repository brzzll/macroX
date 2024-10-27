using DiscordRPC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters.Entities;
using static System.Windows.Forms.LinkLabel;

namespace macroX
{
    public partial class Form1 : Form
    {
        private void button_cambiar(string panel) {
            if (panel == "home") {
                homeButtonActived.Visible = true;
                homeButtonDesactived.Visible = false;
                mouseButtonActived.Visible = false;
                mouseButtonDesactived.Visible = true;
                settingsButtonActived.Visible = false;
                settingsButtonDesactived.Visible = true;
            } else if (panel == "mouse") {
                homeButtonActived.Visible = false;
                homeButtonDesactived.Visible = true;
                mouseButtonActived.Visible = true;
                mouseButtonDesactived.Visible = false;
                settingsButtonActived.Visible = false;
                settingsButtonDesactived.Visible = true;
            } else if (panel == "settings") {
                homeButtonActived.Visible = false;
                homeButtonDesactived.Visible = true;
                mouseButtonActived.Visible = false;
                mouseButtonDesactived.Visible = true;
                settingsButtonActived.Visible = true;
                settingsButtonDesactived.Visible = false;
            }
        }
        private Timer timer;
        private TimeSpan tiempo;
        private Timer ocultarLabelTimer;
        public Form1()
        {
            InitializeComponent();
            panelMouse_general2.Visible = false;
            panelMouse_general1.Visible = true;
            panelMouse_minecraft.Visible = false;
            label2.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            ocultarLabelTimer = new Timer();
            ocultarLabelTimer.Interval = 1000;
            ocultarLabelTimer.Tick += OcultarLabelTimer_Tick;
            rpc.rpctimestamp = Timestamps.Now;
            rpc.InitializeRPC();
            label5.Text = Environment.UserName;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(OnTimerTick);
            tiempo = TimeSpan.Zero;
            timer.Start();
            button_cambiar("home");
            defaultSwitch.Checked = true;
            panelHome.Visible = true;
            panelMouse.Visible = false;
            panelSettings.Visible = false;
        }
        private void OnTimerTick(object sender, EventArgs e)
        {
            tiempo = tiempo.Add(TimeSpan.FromSeconds(1));
            label6.Text = tiempo.ToString(@"hh\:mm\:ss");
        }
        public int xClick = 0, yClick = 0;

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void homeButtonDesactived_Click(object sender, EventArgs e)
        {
            button_cambiar("home");
            panelHome.Visible = true;
            panelSettings.Visible = false;
            panelMouse.Visible = false;
        }

        private void settingsButtonDesactived_Click(object sender, EventArgs e)
        {
            button_cambiar("settings");
            panelSettings.Visible = true;
            panelMouse.Visible = false;
            panelHome.Visible = false;
        }

        private void mouseButtonDesactived_Click(object sender, EventArgs e)
        {
            button_cambiar("mouse");
            panelMouse.Visible = true;
            panelSettings.Visible = false;
            panelHome.Visible = false;
        }
        public string lang = "english";
        public bool english_lang = true;
        public bool spain_lang = false;
        public bool peruvian_lang = false;
        private void languageEnglishButton_Click(object sender, EventArgs e)
        {
            lang = "english";
            english_lang = true;
            spain_lang = false;
            peruvian_lang = false;
            //
            languageEnglishButton.FillColor = Color.White;
            languageSpainButton.FillColor = Color.Black;
            languagePeruvianButton.FillColor = Color.Black;
            //
            label1.Text = "Welcome";
            label3.Text = "to";
            label4.Text = "!";
            label7.Text = "Version:";
            label9.Text = "Free";
            label10.Text = "Type:";
            label12.Text = "Created by:";
            label13.Text = "Time:";
            //
            label32.Text = "General";
            label34.Text = "Left Click";
            label33.Text = "Right Click";
            label37.Text = "Left Click";
            label36.Text = "Right Click";
            left_click_keybind_dobleclick_TextBox.PlaceholderText = "KEYBIND";
            right_click_keybind_dobleclick_TextBox.PlaceholderText = "KEYBIND";
            left_click_autoclick_keybind_TextBox.PlaceholderText = "KEYBIND";
            right_click_autoclick_keybind_TextBox.PlaceholderText = "KEYBIND";
            label27.Text = "Right Click";
            label28.Text = "Left Click";
            holdautoclicker_left_keybind_textbox.PlaceholderText = "KEYBIND";
            holdautoclicker_right_keybind_textbox.PlaceholderText = "KEYBIND";
            stap_keybind_TextBox.PlaceholderText = "KEYBIND";
            //
            label14.Text = "Settings";
            label20.Text = "Language:";
            label21.Text = "Need help?";
            label25.Text = "Design";
            label19.Text = "Themes:";
            label29.Text = "ZenX";
            label30.Text = "Dark";
            label31.Text = "Default";
            discord_serverButton.Text = "Discord Server";
            //
            stap_button.Text = stap_button_togel ? "On" : "Off";
            holdautoclicker_left_button.Text = holdautoclicker_left_togel ? "On" : "Off";
            holdautoclicker_right_button.Text = holdautoclicker_right_togel ? "On" : "Off";
            right_click_autoclick_button.Text = right_click_autoclick_button_togel ? "On" : "Off";
            left_click_autoclick_button.Text = left_click_autoclick_button_togel ? "On" : "Off";
            right_click_dobleclick_button.Text = right_click_dobleclick_button_togel ? "On" : "Off";
            left_click_dobleclick_button.Text = left_click_dobleclick_button_togel ? "On" : "Off";
        }

        private void languageSpainButton_Click(object sender, EventArgs e)
        {
            lang = "spanish";
            english_lang = false;
            spain_lang = true;
            peruvian_lang = false;
            //
            languageEnglishButton.FillColor = Color.Black;
            languageSpainButton.FillColor = Color.White;
            languagePeruvianButton.FillColor = Color.Black;
            //
            label1.Text = "Bienvenido";
            label5.Location = new Point(162, 34);
            label3.Text = "a";
            label4.Text = "!";
            label7.Text = "Versión:";
            label9.Text = "Gratis";
            label10.Text = "Tipo:";
            label12.Text = "Creado por:";
            label13.Text = "Tiempo:";
            //
            label32.Text = "General";
            label34.Text = "Clic Izquierdo";
            label33.Text = "Clic Derecho";
            label37.Text = "Clic Izquierdo";
            label36.Text = "Clic Derecho";
            left_click_keybind_dobleclick_TextBox.PlaceholderText = "TECLA";
            right_click_keybind_dobleclick_TextBox.PlaceholderText = "TECLA";
            left_click_autoclick_keybind_TextBox.PlaceholderText = "TECLA";
            right_click_autoclick_keybind_TextBox.PlaceholderText = "TECLA";
            label27.Text = "Clic Derecho";
            label28.Text = "Clic Izquierdo";
            holdautoclicker_left_keybind_textbox.PlaceholderText = "TECLA";
            holdautoclicker_right_keybind_textbox.PlaceholderText = "TECLA";
            stap_keybind_TextBox.PlaceholderText = "TECLA";
            //
            label14.Text = "Configuración";
            label20.Text = "Lenguaje:";
            label21.Text = "¿Necesitas ayuda?";
            label25.Text = "Diseño";
            label19.Text = "Temas:";
            label29.Text = "ZenX";
            label30.Text = "Oscuro";
            label31.Text = "Por defecto";
            discord_serverButton.Size = new Size(128, 43);
            discord_serverButton.Text = "Servidor de Discord";
            //
            stap_button.Text = stap_button_togel ? "Activo" : "Inactivo";
            holdautoclicker_left_button.Text = holdautoclicker_left_togel ? "Activo" : "Inactivo";
            holdautoclicker_right_button.Text = holdautoclicker_right_togel ? "Activo" : "Inactivo";
            right_click_autoclick_button.Text = right_click_autoclick_button_togel ? "Activo" : "Inactivo";
            left_click_autoclick_button.Text = left_click_autoclick_button_togel ? "Activo" : "Inactivo";
            right_click_dobleclick_button.Text = right_click_dobleclick_button_togel ? "Activo" : "Inactivo";
            left_click_dobleclick_button.Text = left_click_dobleclick_button_togel ? "Activo" : "Inactivo";
        }

        private void languagePeruvianButton_Click(object sender, EventArgs e)
        {
            lang = "spanish";
            english_lang = false;
            spain_lang = false;
            peruvian_lang = true;
            //
            languageEnglishButton.FillColor = Color.Black;
            languageSpainButton.FillColor = Color.Black;
            languagePeruvianButton.FillColor = Color.White;
            //
            label1.Text = "Hi mano";
            label5.Location = new Point(132, 34);
            label3.Text = "a";
            label4.Text = "pe!";
            label7.Text = "Versión:";
            label9.Text = "Chihuán/Aguja/Misio";
            label10.Text = "Tipo:";
            label12.Text = "Creado por:";
            label13.Text = "Time:";
            //
            label32.Text = "General más na’";
            label34.Text = "Clic Izquierdo";
            label33.Text = "Clic Derecho";
            label37.Text = "Clic Izquierdo";
            label36.Text = "Clic Derecho";
            left_click_keybind_dobleclick_TextBox.PlaceholderText = "TECLA";
            right_click_keybind_dobleclick_TextBox.PlaceholderText = "TECLA";
            left_click_autoclick_keybind_TextBox.PlaceholderText = "TECLA";
            right_click_autoclick_keybind_TextBox.PlaceholderText = "TECLA";
            label27.Text = "Clic Derecho";
            label28.Text = "Clic Izquierdo";
            holdautoclicker_left_keybind_textbox.PlaceholderText = "TECLA";
            holdautoclicker_right_keybind_textbox.PlaceholderText = "TECLA";
            stap_keybind_TextBox.PlaceholderText = "TECLA";
            //
            label14.Text = "Configureishon";
            label20.Text = "Verbo:";
            label21.Text = "¿Necesitas una consulta?";
            label25.Text = "Diseño";
            label19.Text = "Temas:";
            label29.Text = "CausasX";
            label30.Text = "Oscuro";
            label31.Text = "Por defecto";
            discord_serverButton.Size = new Size(128, 43);
            discord_serverButton.Text = "Servidor de Discord";
            //
            stap_button.Text = stap_button_togel ? "Activo" : "Inactivo";
            holdautoclicker_left_button.Text = holdautoclicker_left_togel ? "Activo" : "Inactivo";
            holdautoclicker_right_button.Text = holdautoclicker_right_togel ? "Activo" : "Inactivo";
            right_click_autoclick_button.Text = right_click_autoclick_button_togel ? "Activo" : "Inactivo";
            left_click_autoclick_button.Text = left_click_autoclick_button_togel ? "Activo" : "Inactivo";
            right_click_dobleclick_button.Text = right_click_dobleclick_button_togel ? "Activo" : "Inactivo";
            left_click_dobleclick_button.Text = left_click_dobleclick_button_togel ? "Activo" : "Inactivo";
        }

        private void defaultSwitch_Click(object sender, EventArgs e)
        {
            if (zenxSwitch.Checked != false || darkSwitch.Checked != false)
            {
                defaultSwitch.Checked = true;
                darkSwitch.Checked = false;
                zenxSwitch.Checked = false;
                //
                panel_superior.FillColor = Color.Black;
                panel_superior.FillColor2 = Color.Black;
                panel_superior.BackColor = Color.FromArgb(21, 21, 21);
                minimizeButton.BackColor = Color.FromArgb(21, 21, 21);
                minimizeButton.FillColor = Color.Black;
                exitButton.BackColor = Color.FromArgb(21, 21, 21);
                exitButton.FillColor = Color.Black;
                panel_lateral.BackColor = Color.Black;
                panelSettings.BackColor = Color.FromArgb(15,15,15);
                panelMouse.BackColor = Color.FromArgb(15, 15, 15);
                panelHome.BackColor = Color.FromArgb(15, 15, 15);
                guna2Panel3.FillColor = Color.FromArgb(10, 10, 10);
                if (defaultSwitch.Checked) {
                    defaultSwitch.CheckedState.FillColor = Color.White;
                };
                if (darkSwitch.Checked) {
                    darkSwitch.CheckedState.FillColor = Color.White;
                };
                if (zenxSwitch.Checked) {
                    zenxSwitch.CheckedState.FillColor = Color.White;
                }
                discord_serverButton.FillColor = Color.Black;
                if (english_lang == true)
                {
                    languageEnglishButton.FillColor = Color.White;
                }
                else if (spain_lang == true)
                {
                    languageSpainButton.FillColor = Color.White;
                }
                else if (peruvian_lang == true) {
                    languagePeruvianButton.FillColor = Color.White;
                }
                guna2Panel2.FillColor = Color.FromArgb(10, 10, 10);
                label5.ForeColor = SystemColors.Highlight;
                label9.ForeColor = Color.LimeGreen;
                panelMouse_general1.FillColor = Color.FromArgb(10, 10, 10);
                panelMouse_general2.FillColor = Color.FromArgb(10, 10, 10);
                panelMouse_minecraft.FillColor = Color.FromArgb(10, 10, 10);
            }
            else {
                defaultSwitch.Checked = true;
            }
        }

        private void darkSwitch_Click(object sender, EventArgs e)
        {
            if (zenxSwitch.Checked != false || defaultSwitch.Checked != false)
            {
                darkSwitch.Checked = true;
                zenxSwitch.Checked = false;
                defaultSwitch.Checked = false;
                //
            }
            else {
                darkSwitch.Checked = true;
            }
        }

        private void zenxSwitch_Click(object sender, EventArgs e)
        {
            if (darkSwitch.Checked != false || defaultSwitch.Checked != false)
            {
                zenxSwitch.Checked = true;
                darkSwitch.Checked = false;
                defaultSwitch.Checked = false;
                //
            }
            else {
                zenxSwitch.Checked = true;
            }
        }

        private void discord_serverButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/zCQ8jQ2GBf");
        }

        private void scrollbar_mouse_Scroll(object sender, ScrollEventArgs e)
        {
            if (scrollbar_mouse.Value < 30)
            {
                label2.Font = new Font(label2.Font.FontFamily, 10.67f, FontStyle.Bold);
                label15.Font = new Font(label2.Font.FontFamily, 9.75f, FontStyle.Regular);
                label16.Font = new Font(label2.Font.FontFamily, 9.75f, FontStyle.Regular);
                panelMouse_general2.Visible = false;
                panelMouse_general1.Visible = true;
                panelMouse_minecraft.Visible = false;
            }
            else if (scrollbar_mouse.Value > 30 && scrollbar_mouse.Value < 55) {
                label15.Font = new Font(label2.Font.FontFamily, 10.67f, FontStyle.Bold);
                label2.Font = new Font(label2.Font.FontFamily, 9.75f, FontStyle.Regular);
                label16.Font = new Font(label2.Font.FontFamily, 9.75f, FontStyle.Regular);
                panelMouse_general2.Visible = true;
                panelMouse_general1.Visible = false;
                panelMouse_minecraft.Visible = false;
            } else {
                label16.Font = new Font(label2.Font.FontFamily, 10.67f, FontStyle.Bold);
                label15.Font = new Font(label2.Font.FontFamily, 9.75f, FontStyle.Regular);
                label2.Font = new Font(label2.Font.FontFamily, 9.75f, FontStyle.Regular);
                panelMouse_general2.Visible = false;
                panelMouse_general1.Visible = false;
                panelMouse_minecraft.Visible = true;
            }
            label2.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            ocultarLabelTimer.Stop();
            ocultarLabelTimer.Start();
            //0
            //35
            //100
        }
        private void OcultarLabelTimer_Tick(object sender, EventArgs e)
        {
            label2.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            ocultarLabelTimer.Stop();
        }

        private void stap_Switch_CheckedChanged(object sender, EventArgs e)
        {
            if (stap_Switch.Checked)
            {
                stap_button.Enabled = true;
                stap_keybind_TextBox.ReadOnly = false;
                stap_holdkeybind_TextBox.ReadOnly = false;
            }
            else 
            {
                stap_button.Enabled = false;
                stap_keybind_TextBox.ReadOnly = true;
                stap_holdkeybind_TextBox.ReadOnly = true;
            }
        }

        private void left_click_dobleclick_Switch_CheckedChanged(object sender, EventArgs e)
        {
            if (left_click_dobleclick_Switch.Checked) {
                left_click_dobleclick_button.Enabled = true;
                left_click_ms_dobleclick_TextBox.ReadOnly = false;
                left_click_keybind_dobleclick_TextBox.ReadOnly = false;
            } else {
                left_click_dobleclick_button.Enabled = false;
                left_click_ms_dobleclick_TextBox.ReadOnly = true;
                left_click_keybind_dobleclick_TextBox.ReadOnly = true;
            }
        }

        private void right_click_dobleclick_Switch_CheckedChanged(object sender, EventArgs e)
        {
            if (right_click_dobleclick_Switch.Checked)
            {
                right_click_dobleclick_button.Enabled = true;
                right_click_ms_dobleclick_TextBox.ReadOnly = false;
                right_click_keybind_dobleclick_TextBox.ReadOnly = false;
            }
            else {
                right_click_dobleclick_button.Enabled = false;
                right_click_ms_dobleclick_TextBox.ReadOnly = true;
                right_click_keybind_dobleclick_TextBox.ReadOnly = true;
            }
        }

        private void left_click_autoclick_Switch_CheckedChanged(object sender, EventArgs e)
        {
            if (left_click_autoclick_Switch.Checked) {
                left_click_autoclick_button.Enabled = true;
                left_click_autoclick_cps_TextBox.ReadOnly = false;
                left_click_autoclick_ms_TextBox.ReadOnly = false;
                left_click_autoclick_keybind_TextBox.ReadOnly = false;
            } else {
                left_click_autoclick_button.Enabled = false;
                left_click_autoclick_cps_TextBox.ReadOnly = true;
                left_click_autoclick_ms_TextBox.ReadOnly = true;
                left_click_autoclick_keybind_TextBox.ReadOnly = true;
            }
        }

        private void right_click_autoclick_Switch_CheckedChanged(object sender, EventArgs e)
        {
            if (right_click_autoclick_Switch.Checked) {
                right_click_autoclick_button.Enabled = true;
                right_click_autoclick_cps_TextBox.ReadOnly = false;
                right_click_autoclick_ms_TextBox.ReadOnly = false;
                right_click_autoclick_keybind_TextBox.ReadOnly = false;
            } else {
                right_click_autoclick_button.Enabled = false;
                right_click_autoclick_cps_TextBox.ReadOnly = true;
                right_click_autoclick_ms_TextBox.ReadOnly = true;
                right_click_autoclick_keybind_TextBox.ReadOnly = true;
            }
        }
        private static string OpenKeyCaptureForm()
        {
            using (key_capture captureForm = new key_capture())
            {
                if (captureForm.ShowDialog() == DialogResult.OK)
                {
                    string capturedKey = captureForm.CapturedKey;
                    return capturedKey;
                }
            }
            return "Error";
        }
        private void left_click_keybind_dobleclick_TextBox_Click(object sender, EventArgs e)
        {
            if (left_click_keybind_dobleclick_TextBox.ReadOnly == false) {
                if (spain_lang == true || peruvian_lang == true)
                {
                    MessageBox.Show("Pulsa la tecla/botón con la que habilitarás el doble clic izquierdo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (english_lang == true)
                {
                    MessageBox.Show("Press the key/button with which you will enable the double left click.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                left_click_keybind_dobleclick_TextBox.Text = OpenKeyCaptureForm();
            }
        }
        private void right_click_keybind_dobleclick_TextBox_Click(object sender, EventArgs e)
        {
            if (right_click_keybind_dobleclick_TextBox.ReadOnly == false)
            {
                if (spain_lang == true || peruvian_lang == true)
                {
                    MessageBox.Show("Pulsa la tecla/botón con la que habilitarás el doble clic derecho.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else if (english_lang == true)
                {
                    MessageBox.Show("Press the key/button with which you will enable the double right click.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                right_click_keybind_dobleclick_TextBox.Text = OpenKeyCaptureForm();
            }
        }

        private void left_click_autoclick_keybind_TextBox_Click(object sender, EventArgs e)
        {
            if (left_click_autoclick_keybind_TextBox.ReadOnly == false)
            {
                if (spain_lang == true || peruvian_lang == true)
                {
                    MessageBox.Show("Pulsa la tecla/botón con la que activarás el autoclic izquierdo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (english_lang == true)
                {
                    MessageBox.Show("Press the key/button with which you will activate the left autoclick.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                left_click_autoclick_keybind_TextBox.Text = OpenKeyCaptureForm();
            }
        }

        private void right_click_autoclick_keybind_TextBox_Click(object sender, EventArgs e)
        {
            if (right_click_autoclick_keybind_TextBox.ReadOnly == false)
            {
                if (spain_lang == true || peruvian_lang == true)
                {
                    MessageBox.Show("Pulsa la tecla/botón con la que activarás el autoclic derecho.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (english_lang == true)
                {
                    MessageBox.Show("Press the key/button with which you will activate the right autoclick.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                right_click_autoclick_keybind_TextBox.Text = OpenKeyCaptureForm();
            }
        }
        private void stap_keybind_TextBox_Click(object sender, EventArgs e)
        {
            if (stap_keybind_TextBox.ReadOnly == false)
            {
                if (spain_lang == true || peruvian_lang == true)
                {
                    MessageBox.Show("Pulsa la tecla/botón con la que habilitarás el S-Tap.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (english_lang == true)
                {
                    MessageBox.Show("Press the key/button to enable the S-Tap.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                stap_keybind_TextBox.Text = OpenKeyCaptureForm();
            }
        }
        public bool left_click_dobleclick_button_togel = false;
        private static Process dobleclick_left_process;
        private void left_click_dobleclick_button_Click(object sender, EventArgs e)
        {
            if (left_click_ms_dobleclick_TextBox.Text == "" || left_click_ms_dobleclick_TextBox.Text == "-")
            {
                if (english_lang == true)
                {
                    MessageBox.Show("You must place the MS.", "Error MiniSeconds", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Debes colocar los MS.", "Error MiniSegundos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (left_click_keybind_dobleclick_TextBox.Text == "" || left_click_keybind_dobleclick_TextBox.Text == "-")
            {
                if (english_lang == true)
                {
                    MessageBox.Show("You must place the activation key.", "Error KEYBIND", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Debes colocar la tecla de activación.", "Error TECLA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            left_click_dobleclick_button_togel = !left_click_dobleclick_button_togel;
            if (english_lang == true)
            {
                left_click_dobleclick_button.Text = left_click_dobleclick_button_togel ? "On" : "Off";
            }
            else if (spain_lang == true || peruvian_lang == true)
            {
                left_click_dobleclick_button.Text = left_click_dobleclick_button_togel ? "Activo" : "Inactivo";
            }

            if (left_click_dobleclick_button_togel == false)
            {
                left_click_dobleclick_button.FillColor = Color.Black;
                left_click_dobleclick_button.ForeColor = Color.White;
                dobleclick_left_process?.Kill();
            }
            else
            {
                left_click_dobleclick_button.FillColor = Color.White;
                left_click_dobleclick_button.ForeColor = Color.Black;
                //ms-cps-keybind-option
                Task.Run(() => {
                    ProcessStartInfo process = new ProcessStartInfo
                    {
                        FileName = "macrosx_.exe",
                        Arguments = $"{left_click_ms_dobleclick_TextBox.Text} 0 {left_click_keybind_dobleclick_TextBox.Text} dobleclick_left 0 {lang}",
                        UseShellExecute = false
                    };
                    dobleclick_left_process = Process.Start(process);
                    dobleclick_left_process.WaitForExit();
                });
            }
        }
        public bool right_click_dobleclick_button_togel = false;
        private static Process dobleclick_right_process;
        private void right_click_dobleclick_button_Click(object sender, EventArgs e)
        {
            if (right_click_ms_dobleclick_TextBox.Text == "" || right_click_ms_dobleclick_TextBox.Text == "-")
            {
                if (english_lang == true)
                {
                    MessageBox.Show("You must place the MS.", "Error MiniSeconds", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Debes colocar los MS.", "Error MiniSegundos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (right_click_keybind_dobleclick_TextBox.Text == "" || right_click_keybind_dobleclick_TextBox.Text == "-")
            {
                if (english_lang == true)
                {
                    MessageBox.Show("You must place the activation key.", "Error KEYBIND", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Debes colocar la tecla de activación.", "Error TECLA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            right_click_dobleclick_button_togel = !right_click_dobleclick_button_togel;
            if (english_lang == true)
            {
                right_click_dobleclick_button.Text = right_click_dobleclick_button_togel ? "On" : "Off";
            }
            else if (spain_lang == true || peruvian_lang == true)
            {
                right_click_dobleclick_button.Text = right_click_dobleclick_button_togel ? "Activo" : "Inactivo";
            }

            if (right_click_dobleclick_button_togel == false)
            {
                right_click_dobleclick_button.FillColor = Color.Black;
                right_click_dobleclick_button.ForeColor = Color.White;
                dobleclick_right_process?.Kill();
            }
            else
            {
                right_click_dobleclick_button.FillColor = Color.White;
                right_click_dobleclick_button.ForeColor = Color.Black;
                //ms-cps-keybind-option
                Task.Run(() => {
                    ProcessStartInfo process = new ProcessStartInfo
                    {
                        FileName = "macrosx_.exe",
                        Arguments = $"{right_click_ms_dobleclick_TextBox.Text} 0 {right_click_keybind_dobleclick_TextBox.Text} dobleclick_right 0 {lang}",
                        UseShellExecute = false
                    };
                    dobleclick_right_process = Process.Start(process);
                    dobleclick_right_process.WaitForExit();
                });
            }
        }
        public bool left_click_autoclick_button_togel = false;
        private static Process autoclicker_left_process;
        private void left_click_autoclick_button_Click(object sender, EventArgs e)
        {
            if (left_click_autoclick_ms_TextBox.Text == "" || left_click_autoclick_ms_TextBox.Text == "-")
            {
                if (english_lang == true)
                {
                    MessageBox.Show("You must place the MS.", "Error MiniSeconds", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Debes colocar los MS.", "Error MiniSegundos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (left_click_autoclick_cps_TextBox.Text == "" || left_click_autoclick_cps_TextBox.Text == "-")
            {
                if (english_lang == true)
                {
                    MessageBox.Show("You must place the CPS.", "Error ClicksPerSecond", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Debes colocar los CPS.", "Error ClicsPorSegundo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (left_click_autoclick_keybind_TextBox.Text == "" || left_click_autoclick_keybind_TextBox.Text == "-")
            {
                if (english_lang == true)
                {
                    MessageBox.Show("You must place the activation key.", "Error KEYBIND", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Debes colocar la tecla de activación.", "Error TECLA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            left_click_autoclick_button_togel = !left_click_autoclick_button_togel;
            if (english_lang == true)
            {
                left_click_autoclick_button.Text = left_click_autoclick_button_togel ? "On" : "Off";
            }
            else if (spain_lang == true || peruvian_lang == true)
            {
                left_click_autoclick_button.Text = left_click_autoclick_button_togel ? "Activo" : "Inactivo";
            }

            if (left_click_autoclick_button_togel == false)
            {
                left_click_autoclick_button.FillColor = Color.Black;
                left_click_autoclick_button.ForeColor = Color.White;
                autoclicker_left_process?.Kill();
            }
            else
            {
                left_click_autoclick_button.FillColor = Color.White;
                left_click_autoclick_button.ForeColor = Color.Black;
                //ms-cps-keybind-option
                Task.Run(() => {
                    ProcessStartInfo process = new ProcessStartInfo
                    {
                        FileName = "macrosx_.exe",
                        Arguments = $"{left_click_autoclick_ms_TextBox.Text} {left_click_autoclick_cps_TextBox.Text} {left_click_autoclick_keybind_TextBox.Text} autoclicker_left 0 {lang}",
                        UseShellExecute = false
                    };
                    autoclicker_left_process = Process.Start(process);
                    autoclicker_left_process.WaitForExit();
                });
            }
        }
        public bool right_click_autoclick_button_togel = false;
        private static Process autoclicker_right_process;
        private void right_click_autoclick_button_Click(object sender, EventArgs e)
        {
            if (right_click_autoclick_ms_TextBox.Text == "" || right_click_autoclick_ms_TextBox.Text == "-")
            {
                if (english_lang == true)
                {
                    MessageBox.Show("You must place the MS.", "Error MiniSeconds", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Debes colocar los MS.", "Error MiniSegundos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (right_click_autoclick_cps_TextBox.Text == "" || right_click_autoclick_cps_TextBox.Text == "-")
            {
                if (english_lang == true)
                {
                    MessageBox.Show("You must place the CPS.", "Error ClicksPerSecond", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Debes colocar los CPS.", "Error ClicsPorSegundo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (right_click_autoclick_keybind_TextBox.Text == "" || right_click_autoclick_keybind_TextBox.Text == "-")
            {
                if (english_lang == true)
                {
                    MessageBox.Show("You must place the activation key.", "Error KEYBIND", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Debes colocar la tecla de activación.", "Error TECLA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            right_click_autoclick_button_togel = !right_click_autoclick_button_togel;
            if (english_lang == true)
            {
                right_click_autoclick_button.Text = right_click_autoclick_button_togel ? "On" : "Off";
            }
            else if (spain_lang == true || peruvian_lang == true)
            {
                right_click_autoclick_button.Text = right_click_autoclick_button_togel ? "Activo" : "Inactivo";
            }

            if (right_click_autoclick_button_togel == false)
            {
                right_click_autoclick_button.FillColor = Color.Black;
                right_click_autoclick_button.ForeColor = Color.White;
                autoclicker_right_process?.Kill();
            }
            else
            {
                right_click_autoclick_button.FillColor = Color.White;
                right_click_autoclick_button.ForeColor = Color.Black;
                //ms-cps-keybind-option
                Task.Run(() => {
                    ProcessStartInfo process = new ProcessStartInfo
                    {
                        FileName = "macrosx_.exe",
                        Arguments = $"{right_click_autoclick_ms_TextBox.Text} {right_click_autoclick_cps_TextBox.Text} {right_click_autoclick_keybind_TextBox.Text} autoclicker_right 0 {lang}",
                        UseShellExecute = false
                    };
                    autoclicker_right_process = Process.Start(process);
                    autoclicker_right_process.WaitForExit();
                });
            }
        }
        public bool stap_button_togel = false;
        private static Process stap_process;
        private void stap_button_Click(object sender, EventArgs e)
        {
            if (stap_keybind_TextBox.Text == "" || stap_keybind_TextBox.Text == "-")
            {
                if (english_lang == true)
                {
                    MessageBox.Show("You must place the activation key.", "Error KEYBIND", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Debes colocar la tecla de activación.", "Error TECLA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (stap_holdkeybind_TextBox.Text == "" || stap_holdkeybind_TextBox.Text == "-") {
                if (english_lang == true)
                {
                    MessageBox.Show("You must place the key/button with which you will S-Tap.", "Error HoldKey", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Debes colocar la tecla/botón con la que harás S-Tap.", "Error HoldKey", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            stap_button_togel = !stap_button_togel;
            if (english_lang == true)
            {
                stap_button.Text = stap_button_togel ? "On" : "Off";
            }
            else if (spain_lang == true || peruvian_lang == true)
            {
                stap_button.Text = stap_button_togel ? "Activo" : "Inactivo";
            }

            if (stap_button_togel == false)
            {
                stap_button.FillColor = Color.Black;
                stap_button.ForeColor = Color.White;
                stap_process?.Kill();
            }
            else
            {
                stap_button.FillColor = Color.White;
                stap_button.ForeColor = Color.Black;
                //ms-cps-keybind-option
                Task.Run(() => {
                    ProcessStartInfo process = new ProcessStartInfo
                    {
                        FileName = "macrosx_.exe",
                        Arguments = $"0 0 {stap_keybind_TextBox.Text} stap {stap_holdkeybind_TextBox.Text} {lang}",
                        UseShellExecute = false
                    };
                    stap_process = Process.Start(process);
                    stap_process.WaitForExit(); 
                });
            }
        }
        public bool holdautoclicker_left_togel = false;
        private static Process holdautoclicker_left_process;
        private void holdautoclicker_left_button_Click(object sender, EventArgs e)
        {
            if (holdautoclicker_left_ms_textbox.Text == "" || holdautoclicker_left_ms_textbox.Text == "-")
            {
                if (english_lang == true)
                {
                    MessageBox.Show("You must place the MS.", "Error MiniSeconds", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Debes colocar los MS.", "Error MiniSegundos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (holdautoclicker_left_cps_textbox.Text == "" || holdautoclicker_left_cps_textbox.Text == "-")
            {
                if (english_lang == true)
                {
                    MessageBox.Show("You must place the CPS.", "Error ClicksPerSecond", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Debes colocar los CPS.", "Error ClicsPorSegundo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (holdautoclicker_left_keybind_textbox.Text == "" || holdautoclicker_left_keybind_textbox.Text == "-")
            {
                if (english_lang == true)
                {
                    MessageBox.Show("You must place the activation key of the click mode.", "Error KEYBIND", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Debes colocar la tecla de activación del modo de clic.", "Error TECLA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else if (holdautoclicker_left_holdkeybind_textbox.Text == "" || holdautoclicker_left_holdkeybind_textbox.Text == "-")
            {
                if (english_lang == true)
                {
                    MessageBox.Show("You must place the key/button with which you will do the click mode.", "Error HoldKey", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Debes colocar la tecla/boton con la que harás el modo de click.", "Error HoldKey", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            holdautoclicker_left_togel = !holdautoclicker_left_togel;
            if (english_lang == true)
            {
                holdautoclicker_left_button.Text = holdautoclicker_left_togel ? "On" : "Off";
            }
            else if (spain_lang == true || peruvian_lang == true)
            {
                holdautoclicker_left_button.Text = holdautoclicker_left_togel ? "Activo" : "Inactivo";
            }

            if (holdautoclicker_left_togel == false)
            {
                holdautoclicker_left_button.FillColor = Color.Black;
                holdautoclicker_left_button.ForeColor = Color.White;
                holdautoclicker_left_process?.Kill();
            }
            else
            {
                holdautoclicker_left_button.FillColor = Color.White;
                holdautoclicker_left_button.ForeColor = Color.Black;
                //ms-cps-keybind-option
                Task.Run(() => {
                    ProcessStartInfo process = new ProcessStartInfo
                    {
                        FileName = "macrosx_.exe",
                        Arguments = $"{holdautoclicker_left_ms_textbox.Text} {holdautoclicker_left_cps_textbox.Text} {holdautoclicker_left_keybind_textbox.Text} hold_autoclicker_left {holdautoclicker_left_holdkeybind_textbox.Text} {lang}",
                        UseShellExecute = false
                    };
                    holdautoclicker_left_process = Process.Start(process);
                    holdautoclicker_left_process.WaitForExit();
                });
            }
        }
        public bool holdautoclicker_right_togel = false;
        private static Process holdautoclicker_right_process;
        private void holdautoclicker_right_button_Click(object sender, EventArgs e)
        {
            if (holdautoclicker_right_ms_textbox.Text == "" || holdautoclicker_right_ms_textbox.Text == "-")
            {
                if (english_lang == true)
                {
                    MessageBox.Show("You must place the MS.", "Error MiniSeconds", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Debes colocar los MS.", "Error MiniSegundos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (holdautoclicker_right_cps_textbox.Text == "" || holdautoclicker_right_cps_textbox.Text == "-")
            {
                if (english_lang == true)
                {
                    MessageBox.Show("You must place the CPS.", "Error ClicksPerSecond", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Debes colocar los CPS.", "Error ClicsPorSegundo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (holdautoclicker_right_keybind_textbox.Text == "" || holdautoclicker_right_keybind_textbox.Text == "-")
            {
                if (english_lang == true)
                {
                    MessageBox.Show("You must place the activation key.", "Error KEYBIND", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Debes colocar la tecla de activación.", "Error TECLA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (holdautoclicker_right_holdkeybind_textbox.Text == "" || holdautoclicker_right_holdkeybind_textbox.Text == "-")
            {
                if (english_lang == true)
                {
                    MessageBox.Show("You must place the key/button with which you will do the click mode.", "Error HoldKey", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Debes colocar la tecla/boton con la que harás el modo de click.", "Error HoldKey", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            holdautoclicker_right_togel = !holdautoclicker_right_togel;
            if (english_lang == true)
            {
                holdautoclicker_right_button.Text = holdautoclicker_right_togel ? "On" : "Off";
            }
            else if (spain_lang == true || peruvian_lang == true)
            {
                holdautoclicker_right_button.Text = holdautoclicker_right_togel ? "Activo" : "Inactivo";
            }

            if (holdautoclicker_right_togel == false)
            {
                holdautoclicker_right_button.FillColor = Color.Black;
                holdautoclicker_right_button.ForeColor = Color.White;
                holdautoclicker_right_process?.Kill();
            }
            else
            {
                holdautoclicker_right_button.FillColor = Color.White;
                holdautoclicker_right_button.ForeColor = Color.Black;
                //ms-cps-keybind-option
                Task.Run(() => {
                    ProcessStartInfo process = new ProcessStartInfo
                    {
                        FileName = "macrosx_.exe",
                        Arguments = $"{holdautoclicker_right_ms_textbox.Text} {holdautoclicker_right_cps_textbox.Text} {holdautoclicker_right_keybind_textbox.Text} hold_autoclicker_right {holdautoclicker_left_holdkeybind_textbox.Text} {lang}",
                        UseShellExecute = false
                    };
                    holdautoclicker_right_process = Process.Start(process);
                    holdautoclicker_right_process.WaitForExit();
                });
            }
        }

        private void holdautoclicker_left_keybind_textbox_Click(object sender, EventArgs e)
        {
            if (holdautoclicker_left_keybind_textbox.ReadOnly == false)
            {
                if (spain_lang == true || peruvian_lang == true)
                {
                    MessageBox.Show("Pulsa la tecla/botón con la que habilitarás el modo de clic.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (english_lang == true)
                {
                    MessageBox.Show("Press the key/button with which you will enable the click mode.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                holdautoclicker_left_keybind_textbox.Text = OpenKeyCaptureForm();
            }
        }

        private void holdautoclicker_right_keybind_textbox_Click(object sender, EventArgs e)
        {
            if (holdautoclicker_right_keybind_textbox.ReadOnly == false)
            {
                if (spain_lang == true || peruvian_lang == true)
                {
                    MessageBox.Show("Pulsa la tecla/botón con la que habilitarás el modo de clic.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (english_lang == true)
                {
                    MessageBox.Show("Press the key / button with which you will enable the click mode.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                holdautoclicker_right_keybind_textbox.Text = OpenKeyCaptureForm();
            }
        }

        private void holdautoclicker_left_Switch_CheckedChanged(object sender, EventArgs e)
        {
            if (holdautoclicker_left_Switch.Checked)
            {
                holdautoclicker_left_button.Enabled = true;
                holdautoclicker_left_ms_textbox.ReadOnly = false;
                holdautoclicker_left_cps_textbox.ReadOnly = false;
                holdautoclicker_left_keybind_textbox.ReadOnly = false;
                holdautoclicker_left_holdkeybind_textbox.ReadOnly = false;
            }
            else
            {
                holdautoclicker_left_button.Enabled = false;
                holdautoclicker_left_ms_textbox.ReadOnly = true;
                holdautoclicker_left_cps_textbox.ReadOnly = true;
                holdautoclicker_left_keybind_textbox.ReadOnly = true;
                holdautoclicker_left_holdkeybind_textbox.ReadOnly = true;
            }
        }

        private void holdautoclicker_right_Switch_CheckedChanged(object sender, EventArgs e)
        {
            if (holdautoclicker_right_Switch.Checked)
            {
                holdautoclicker_right_button.Enabled = true;
                holdautoclicker_right_ms_textbox.ReadOnly = false;
                holdautoclicker_right_cps_textbox.ReadOnly = false;
                holdautoclicker_right_keybind_textbox.ReadOnly = false;
                holdautoclicker_right_holdkeybind_textbox.ReadOnly = false;
            }
            else
            {
                holdautoclicker_right_button.Enabled = false;
                holdautoclicker_right_ms_textbox.ReadOnly = true;
                holdautoclicker_right_cps_textbox.ReadOnly = true;
                holdautoclicker_right_keybind_textbox.ReadOnly = true;
                holdautoclicker_right_holdkeybind_textbox.ReadOnly = true;
            }
        }

        private void stap_holdkeybind_TextBox_Click(object sender, EventArgs e)
        {
            if (stap_holdkeybind_TextBox.ReadOnly == false)
            {
                if (spain_lang == true || peruvian_lang == true)
                {
                    MessageBox.Show("Pulsa la tecla/botón con la que harás S-Tap.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (english_lang == true)
                {
                    MessageBox.Show("Press the key/button with which you will S-Tap.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                stap_holdkeybind_TextBox.Text = OpenKeyCaptureForm();
            }
        }

        private void holdautoclicker_left_holdkeybind_textbox_Click(object sender, EventArgs e)
        {
            if (holdautoclicker_left_holdkeybind_textbox.ReadOnly == false)
            {
                if (spain_lang == true || peruvian_lang == true)
                {
                    MessageBox.Show("Pulsa la tecla/botón con la que harás el modo de clic.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (english_lang == true)
                {
                    MessageBox.Show("Press the key/button with which you will do the click mode.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                holdautoclicker_left_holdkeybind_textbox.Text = OpenKeyCaptureForm();
            }
        }

        private void holdautoclicker_right_holdkeybind_textbox_Click(object sender, EventArgs e)
        {
            if (holdautoclicker_right_holdkeybind_textbox.ReadOnly == false)
            {
                if (spain_lang == true || peruvian_lang == true)
                {
                    MessageBox.Show("Pulsa la tecla/botón con la que harás el modo de clic.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (english_lang == true)
                {
                    MessageBox.Show("Press the key/button with which you will do the click mode.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                holdautoclicker_right_holdkeybind_textbox.Text = OpenKeyCaptureForm();
            }
        }

        private void guna2GradientPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { xClick = e.X; yClick = e.Y; } else { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }
    }
}
