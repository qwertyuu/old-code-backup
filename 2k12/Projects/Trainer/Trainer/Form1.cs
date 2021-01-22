using System;
using System.Windows.Forms;

namespace Trainer{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e){
            axShockwaveFlash1.SetVariable("_root.game.ennemies.ennemybase2.health", "-1");
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e){
            if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 5){
                axShockwaveFlash1.SetVariable("cash", "1000000000000");
            }
            if (comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 5){
                axShockwaveFlash1.SetVariable("tech_level", "5");
            }
            if (comboBox1.SelectedIndex == 2 || comboBox1.SelectedIndex == 5){
                axShockwaveFlash1.SetVariable("xp", "100000000000000");
            }
            if (comboBox1.SelectedIndex == 3 || comboBox1.SelectedIndex == 5){
                axShockwaveFlash1.SetVariable("addons", "3");
            }
            if (comboBox1.SelectedIndex == 4 || comboBox1.SelectedIndex == 5){
                axShockwaveFlash1.SetVariable("_root.game.ennemies.ennemybase1.max_health", "10000000000000");
                axShockwaveFlash1.SetVariable("_root.game.ennemies.ennemybase1.health", "10000000000000");
            }
        }
    }
}