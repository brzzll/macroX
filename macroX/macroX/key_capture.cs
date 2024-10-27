using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace macroX
{
    public partial class key_capture : Form
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
        public string CapturedKey { get; private set; }
        public key_capture()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += Key_Capture_KeyDown;
        }
        public static string get_vk(string description)
        {
            if (keyValues.TryGetValue(description, out string value))
            {
                return value;
            }
            return null;
        }
        public static string get_val(string description)
        {
            if (keyValues.TryGetValue(description, out string value))
            {
                return description;
            }
            return null;
        }
        private void Key_Capture_KeyDown(object sender, KeyEventArgs e)
        {
            var nepe = get_vk(e.KeyCode.ToString()) ?? "-";
            var valorxd = get_val(e.KeyCode.ToString()) ?? "-";
            label_key.Text = $"{valorxd}";
        }
        private void guna2Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            var nepe = get_vk(e.Button.ToString()) ?? "-";
            var valorxd = get_val(e.Button.ToString()) ?? "-";
            label_key.Text = $"{valorxd}";
        }
        private void button_OK_Click(object sender, EventArgs e)
        {
            CapturedKey = label_key.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private int xClick = 0, yClick = 0;
        private void panel_superior_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) { xClick = e.X; yClick = e.Y; } else { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }
    }
}