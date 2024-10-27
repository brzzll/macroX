using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace macrosx_
{
    public partial class Form1 : Form
    {
        private static Dictionary<string, string> keyValues = new Dictionary<string, string>
        {
            { "Left", "0x01" },
            { "Right", "0x02" },
            { "Middle", "0x04" },
            { "XButton1", "0x05" },
            { "XButton2", "0x06" },
            { "Back", "0x08" },
            { "Menu", "0x12" },
            { "Pause", "0x13" },
            { "Capital", "0x14" },
            { "Escape", "0x1B" },
            { "Space", "0x20" },
            { "PageUp", "0x21" },
            { "Next", "0x22" },
            { "End", "0x23" },
            { "Home", "0x24" },
            { "Insert", "0x2D" },
            { "Delete", "0x2E" },
            { "0", "0x30" },
            { "1", "0x31" },
            { "2", "0x32" },
            { "3", "0x33" },
            { "4", "0x34" },
            { "5", "0x35" },
            { "6", "0x36" },
            { "7", "0x37" },
            { "8", "0x38" },
            { "9", "0x39" },
            { "A", "0x41" },
            { "B", "0x42" },
            { "C", "0x43" },
            { "D", "0x44" },
            { "E", "0x45" },
            { "F", "0x46" },
            { "G", "0x47" },
            { "H", "0x48" },
            { "I", "0x49" },
            { "J", "0x4A" },
            { "K", "0x4B" },
            { "L", "0x4C" },
            { "M", "0x4D" },
            { "N", "0x4E" },
            { "O", "0x4F" },
            { "P", "0x50" },
            { "Q", "0x51" },
            { "R", "0x52" },
            { "S", "0x53" },
            { "T", "0x54" },
            { "U", "0x55" },
            { "V", "0x56" },
            { "W", "0x57" },
            { "X", "0x58" },
            { "Y", "0x59" },
            { "Z", "0x5A" },
            { "Apps", "0x5D" },
            { "F1", "0x70" },
            { "F2", "0x71" },
            { "F3", "0x72" },
            { "F4", "0x73" },
            { "F5", "0x74" },
            { "F6", "0x75" },
            { "F7", "0x76" },
            { "F8", "0x77" },
            { "F9", "0x78" },
            { "F10", "0x79" },
            { "F11", "0x7A" },
            { "F12", "0x7B" },
            { "F13", "0x7C" },
            { "F14", "0x7D" },
            { "F15", "0x7E" },
            { "F16", "0x7F" },
            { "F17", "0x80" },
            { "F18", "0x81" },
            { "F19", "0x82" },
            { "F20", "0x83" },
            { "F21", "0x84" },
            { "F22", "0x85" },
            { "F23", "0x86" },
            { "F24", "0x87" },
            { "VolumeMute", "0xAD" },
            { "VolumeDown", "0xAE" },
            { "VolumeUp", "0xAF" },
            { "MediaNextTrack", "0xB0" },
            { "MediaPreviousTrack", "0xB1" },
            { "MediaPlayPause", "0xB3" },
            { "SelectMedia", "0xB5" },
        };
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);
        private int cps = 0; //cps
        private int ms = 0; //ms
        private const int vk_s = 0x53; //VK de tecla S
        private const int vk_right_button = 0x02;  //VK de clic derecho
        private const int vk_left_button = 0x01; //VK de clic izquierdo
        private const uint keyboard_keydown = 0x0000; //Tecla abajo
        private const uint keyboard_keyup = 0x0002; //Tecla arriba
        private const uint mouse_rightdown = 0x0008; //Mouse derecho abajo
        private const uint mouse_rightup = 0x0010; //Mouse derecho arriba
        private const uint mouse_leftdown = 0x0002; //Mouse izquierdo abajo
        private const uint mouse_leftup = 0x0004; //Mouse izquierdo arriba
        private static bool method_click_active = false;
        private static bool hold = false; //Pulsando
        private int vk_keyactive = 0; //Keybind - Keybind_activate
        private int vk_hold_button = 0; //Keybind_Hold
        private string lang = "";
        public void process_dobleclick_left() {
            bool presionao = false;
            while (true)
            {
                if (method_click_active)
                {
                    if (GetAsyncKeyState(vk_left_button) < 0)
                    {
                        Thread.Sleep(ms);
                        mouse_event(mouse_leftdown, 0, 0, 0, 0);
                        mouse_event(mouse_leftup, 0, 0, 0, 0);
                        this.button_dobleclick_left.FillColor = Color.Yellow;
                        this.button_dobleclick_left.ForeColor = Color.Olive;
                        if (lang == "spanish")
                        {
                            this.button_dobleclick_left.Text = "Pulsado!";
                        }
                        else {
                            this.button_dobleclick_left.Text = "Clicked!";
                        }
                    }
                }

                if (GetAsyncKeyState(vk_keyactive) < 0)
                {
                    if (!presionao)
                    {
                        method_click_active = !method_click_active;
                        if (method_click_active)
                        {
                            this.button_dobleclick_left.FillColor = Color.LimeGreen;
                            this.button_dobleclick_left.ForeColor = Color.DarkGreen;
                            if (lang == "spanish")
                            {
                                this.button_dobleclick_left.Text = "Habilitado";
                            }
                            else {
                                this.button_dobleclick_left.Text = "Enabled";
                            }
                        }
                        else
                        {
                            this.button_dobleclick_left.FillColor = Color.Maroon;
                            this.button_dobleclick_left.ForeColor = Color.Red;
                            if (lang == "spanish")
                            {
                                this.button_dobleclick_left.Text = "Deshabilitado";
                            }
                            else
                            {
                                this.button_dobleclick_left.Text = "Disabled";
                            }
                        }
                        presionao = true;
                        Thread.Sleep(325);
                    }
                }
                else
                {
                    presionao = false;
                }
            }
        }
        public void process_dobleclick_right() {
            bool presionao = false;
            while (true)
            {
                if (method_click_active)
                {
                    if (GetAsyncKeyState(vk_left_button) < 0)
                    {
                        Thread.Sleep(ms);
                        mouse_event(mouse_rightdown, 0, 0, 0, 0);
                        mouse_event(mouse_rightup, 0, 0, 0, 0);
                        this.button_dobleclick_right.FillColor = Color.Yellow;
                        this.button_dobleclick_right.ForeColor = Color.Olive;
                        if (lang == "spanish")
                        {
                            this.button_dobleclick_right.Text = "Pulsado!";
                        }
                        else {
                            this.button_dobleclick_right.Text = "Clicked!";
                        }
                    }
                }

                if (GetAsyncKeyState(vk_keyactive) < 0)
                {
                    if (!presionao)
                    {
                        method_click_active = !method_click_active;
                        if (method_click_active)
                        {
                            this.button_dobleclick_right.FillColor = Color.LimeGreen;
                            this.button_dobleclick_right.ForeColor = Color.DarkGreen;
                            if (lang == "spanish")
                            {
                                this.button_dobleclick_right.Text = "Habilitado";
                            }
                            else {
                                this.button_dobleclick_right.Text = "Enabled";
                            }
                        }
                        else
                        {
                            this.button_dobleclick_right.FillColor = Color.Maroon;
                            this.button_dobleclick_right.ForeColor = Color.Red;
                            if (lang == "spanish")
                            {
                                this.button_dobleclick_right.Text = "Deshabilitado";
                            }
                            else {
                                this.button_dobleclick_right.Text = "Disabled";
                            }
                        }
                        presionao = true;
                        Thread.Sleep(325);
                    }
                }
                else
                {
                    presionao = false;
                }
            }
        }
        public void process_autoclicker_left() {
            bool presionao = false;
            while (true)
            {
                if (method_click_active)
                {
                    mouse_event(mouse_leftdown, 0, 0, 0, 0);
                    mouse_event(mouse_leftup, 0, 0, 0, 0);
                    this.button_autoclicker_left.FillColor = Color.Yellow;
                    this.button_autoclicker_left.ForeColor = Color.Olive;
                    if (lang == "spanish")
                    {
                        this.button_autoclicker_left.Text = "Clicqueando...";
                    }
                    else {
                        this.button_autoclicker_left.Text = "Clicking...";
                    }
                    Thread.Sleep(ms);
                }
                if (GetAsyncKeyState(vk_keyactive) < 0)
                {
                    if (!presionao)
                    {
                        method_click_active = !method_click_active;
                        if (method_click_active)
                        {
                            this.button_autoclicker_left.FillColor = Color.LimeGreen;
                            this.button_autoclicker_left.ForeColor = Color.DarkGreen;
                            if (lang == "spanish")
                            {
                                this.button_autoclicker_left.Text = "Habilitado";
                            }
                            else {
                                this.button_autoclicker_left.Text = "Enabled";
                            }
                        }
                        else
                        {
                            this.button_autoclicker_left.FillColor = Color.Maroon;
                            this.button_autoclicker_left.ForeColor = Color.Red;
                            if (lang == "spanish")
                            {
                                this.button_autoclicker_left.Text = "Deshabilitado";
                            }
                            else
                            {
                                this.button_autoclicker_left.Text = "Disabled";
                            }
                        }
                        presionao = true;
                        Thread.Sleep(325);
                    }
                }
                else
                {
                    presionao = false;
                }
            }
        }
        public void process_autoclicker_right() {
            bool presionao = false;
            while (true)
            {
                if (method_click_active)
                {
                    mouse_event(mouse_rightdown, 0, 0, 0, 0);
                    mouse_event(mouse_rightup, 0, 0, 0, 0);
                    this.button_autoclicker_right.FillColor = Color.Yellow;
                    this.button_autoclicker_right.ForeColor = Color.Olive;
                    if (lang == "spanish")
                    {
                        this.button_autoclicker_right.Text = "Clicqueando...";
                    }
                    else
                    {
                        this.button_autoclicker_right.Text = "Clicking...";
                    }
                    Thread.Sleep(ms);
                }
                if (GetAsyncKeyState(vk_keyactive) < 0)
                {
                    if (!presionao)
                    {
                        method_click_active = !method_click_active;
                        if (method_click_active)
                        {
                            this.button_autoclicker_right.FillColor = Color.LimeGreen;
                            this.button_autoclicker_right.ForeColor = Color.DarkGreen;
                            if (lang == "spanish")
                            {
                                this.button_autoclicker_right.Text = "Habilitado";
                            }
                            else
                            {
                                this.button_autoclicker_right.Text = "Enabled";
                            }
                        }
                        else
                        {
                            this.button_autoclicker_right.FillColor = Color.Maroon;
                            this.button_autoclicker_right.ForeColor = Color.Red;
                            if (lang == "spanish")
                            {
                                this.button_autoclicker_right.Text = "Deshabilitado";
                            }
                            else
                            {
                                this.button_autoclicker_right.Text = "Disabled";
                            }
                        }
                        presionao = true;
                        Thread.Sleep(325);
                    }
                }
                else
                {
                    presionao = false;
                }
            }
        }
        public void process_holdautoclicker_left() {
            while (true)
            {
                if (method_click_active)
                {
                    if (GetAsyncKeyState(vk_hold_button) < 0)
                    {
                        mouse_event(mouse_leftdown, 0, 0, 0, 0);
                        mouse_event(mouse_leftup, 0, 0, 0, 0);
                        this.button_holdautoclicker_left.FillColor = Color.Yellow;
                        this.button_holdautoclicker_left.ForeColor = Color.Olive;
                        if (lang == "spanish")
                        {
                            this.button_holdautoclicker_left.Text = "Clicqueando...";
                        }
                        else
                        {
                            this.button_holdautoclicker_left.Text = "Clicking...";
                        }
                        Thread.Sleep(ms);
                    }
                }
                if (GetAsyncKeyState(vk_keyactive) < 0)
                {
                    method_click_active = !method_click_active;
                    if (method_click_active)
                    {
                        this.button_holdautoclicker_left.FillColor = Color.LimeGreen;
                        this.button_holdautoclicker_left.ForeColor = Color.DarkGreen;
                        if (lang == "spanish")
                        {
                            this.button_holdautoclicker_left.Text = "Habilitado";
                        }
                        else
                        {
                            this.button_holdautoclicker_left.Text = "Enabled";
                        }
                    }
                    else
                    {
                        this.button_holdautoclicker_left.FillColor = Color.Maroon;
                        this.button_holdautoclicker_left.ForeColor = Color.Red;
                        if (lang == "spanish")
                        {
                            this.button_holdautoclicker_left.Text = "Deshabilitado";
                        }
                        else
                        {
                            this.button_holdautoclicker_left.Text = "Disabled";
                        }
                    }
                    Thread.Sleep(350);
                }
            }
        }
        public void process_holdautoclicker_right()
        {
            while (true)
            {
                if (method_click_active)
                {
                    if (GetAsyncKeyState(vk_hold_button) < 0)
                    {
                        mouse_event(mouse_rightdown, 0, 0, 0, 0);
                        mouse_event(mouse_rightup, 0, 0, 0, 0);
                        this.button_holdautoclicker_right.FillColor = Color.Yellow;
                        this.button_holdautoclicker_right.ForeColor = Color.Olive;
                        if (lang == "spanish")
                        {
                            this.button_holdautoclicker_right.Text = "Clicqueando...";
                        }
                        else
                        {
                            this.button_holdautoclicker_right.Text = "Clicking...";
                        }
                        Thread.Sleep(ms);
                    }
                }
                if (GetAsyncKeyState(vk_keyactive) < 0)
                {
                    method_click_active = !method_click_active;
                    if (method_click_active)
                    {
                        this.button_holdautoclicker_right.FillColor = Color.LimeGreen;
                        this.button_holdautoclicker_right.ForeColor = Color.DarkGreen;
                        if (lang == "spanish")
                        {
                            this.button_holdautoclicker_right.Text = "Habilitado";
                        }
                        else
                        {
                            this.button_holdautoclicker_right.Text = "Enabled";
                        }
                    }
                    else
                    {
                        this.button_holdautoclicker_right.FillColor = Color.Maroon;
                        this.button_holdautoclicker_right.ForeColor = Color.Red;
                        if (lang == "spanish")
                        {
                            this.button_holdautoclicker_right.Text = "Deshabilitado";
                        }
                        else
                        {
                            this.button_holdautoclicker_right.Text = "Disabled";
                        }
                    }
                    Thread.Sleep(350);
                }
            }
        }
        public void process_stap() {
            bool key_presionada = false;//Activar Metodo Click validacion
            while (true)
            {
                if (method_click_active)
                {
                    if (GetAsyncKeyState(vk_hold_button) < 0)
                    {
                        if (!hold)
                        {
                            keybd_event(vk_s, 0, keyboard_keydown, 0);
                            hold = true;
                            this.button_stap.FillColor = Color.Yellow;
                            this.button_stap.ForeColor = Color.Olive;
                            if (lang == "spanish")
                            {
                                this.button_stap.Text = "Pulsando...";
                            }
                            else
                            {
                                this.button_stap.Text = "Pressing...";
                            }
                        }
                    }
                    else
                    {
                        if (hold)
                        {
                            keybd_event(vk_s, 0, keyboard_keyup, 0);
                            hold = false;
                            this.button_stap.FillColor = Color.Yellow;
                            this.button_stap.ForeColor = Color.Olive;
                            if (lang == "spanish")
                            {
                                this.button_stap.Text = "Soltado!";
                            }
                            else
                            {
                                this.button_stap.Text = "Released!";
                            }
                        }
                    }
                }
                if (GetAsyncKeyState(vk_keyactive) < 0)
                {
                    if (!key_presionada)
                    {
                        method_click_active = !method_click_active;
                        if (method_click_active)
                        {
                            this.button_stap.FillColor = Color.LimeGreen;
                            this.button_stap.ForeColor = Color.DarkGreen;
                            if (lang == "spanish")
                            {
                                this.button_stap.Text = "Habilitado";
                            }
                            else
                            {
                                this.button_stap.Text = "Enabled";
                            }
                        }
                        else {
                            this.button_stap.FillColor = Color.Maroon;
                            this.button_stap.ForeColor = Color.Red;
                            if (lang == "spanish")
                            {
                                this.button_stap.Text = "Deshabilitado";
                            }
                            else
                            {
                                this.button_stap.Text = "Disabled";
                            }
                        }
                        key_presionada = true;
                        Thread.Sleep(325);
                    }
                }
                else
                {
                    key_presionada = false;
                }
            }
        }
        public Form1(int param1, int param2, string param3, string param4, string param5, string param6)
        {
            InitializeComponent();
            label_dobleclick_left.Visible = false;
            label_dobleclick_right.Visible = false;
            label_autoclicker_left.Visible = false;
            label_autoclicker_right.Visible = false;
            label_holdautoclicker_left.Visible = false;
            label_holdautoclicker_right.Visible = false;
            label_stap.Visible = false;
            panel_dobleclick_left.Visible = false;
            panel_dobleclick_right.Visible = false;
            panel_autoclicker_left.Visible = false;
            panel_autoclicker_right.Visible = false;
            panel_holdautoclicker_left.Visible = false;
            panel_holdautoclicker_right.Visible = false;
            panel_stap.Visible = false;
            lang = param6;
            if (keyValues.TryGetValue(param3, out string value)) {
                vk_keyactive = Convert.ToInt32(value, 16);
            }
            if (param4 == "stap" || param4 == "hold_autoclicker_right" || param4 == "hold_autoclicker_left")
            {
                if (keyValues.TryGetValue(param5, out string value2))
                {
                    vk_hold_button = Convert.ToInt32(value2, 16);
                }
            };
            if (param4 != "stap") {
                ms = param1 / (param2 == 0 ? 1 : param2);
                cps = param2;
            };
            switch (param4)
            {
                case "dobleclick_left":
                    label_dobleclick_left.Visible = true;
                    panel_dobleclick_left.Visible = true;
                    Task.Run(() => process_dobleclick_left());
                    break;
                case "dobleclick_right":
                    label_dobleclick_right.Visible = true;
                    panel_dobleclick_right.Visible = true;
                    Task.Run(() => process_dobleclick_right());
                    break;
                case "autoclicker_left":
                    label_autoclicker_left.Visible = true;
                    panel_autoclicker_left.Visible = true;
                    Task.Run(() => process_autoclicker_left());
                    break;
                case "autoclicker_right":
                    label_autoclicker_right.Visible = true;
                    panel_autoclicker_right.Visible = true;
                    Task.Run(() => process_autoclicker_right());
                    break;
                case "hold_autoclicker_left":
                    label_holdautoclicker_left.Visible = true;
                    panel_holdautoclicker_left.Visible = true;
                    Task.Run(() => process_holdautoclicker_left());
                    break;
                case "hold_autoclicker_right":
                    label_holdautoclicker_right.Visible = true;
                    panel_holdautoclicker_right.Visible = true;
                    Task.Run(() => process_holdautoclicker_right());
                    break;
                case "stap":
                    label_stap.Visible = true;
                    panel_stap.Visible = true;
                    Task.Run(() => process_stap());
                    break;
                default:
                    MessageBox.Show($"No se reconoce la opción: {param4}", "Error");
                    Application.Exit();
                    break;
            }
        } 
        private int xClick = 0, yClick = 0;
        private void panel_superior_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { xClick = e.X; yClick = e.Y; } else { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }
    }
}
