using System;
using System.Windows.Forms;

namespace Virus
{
	public partial class FunnyBtn1 : Form
	{
		public FunnyBtn1()
		{
			this.InitializeComponent();
		}

        public int buttonPressedCount;
        private void FunnyBtn_Load(object sender, EventArgs e)
        {
            Helper.DownloadSound();
        }
        private void FunnyBtn1_Shown(object sender, EventArgs e)
        {
            MessageBox.Show("Whatever you do, DON'T press the button!", "Man A", MessageBoxButtons.OK);
        }
        private void button1_Click(object sender, EventArgs e)
		{
			if (this.buttonPressedCount == 0)
			{
				DialogResult dialogResult = MessageBox.Show("Are you sure you want to press it?", "Virus.exe", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.Yes)
				{
					this.buttonPressedCount++;
					MessageBox.Show("Are you serious? I just told you not to press it! You better not do it again :/", "Man A", MessageBoxButtons.OK);
					return;
				}
				if (dialogResult == DialogResult.No)
				{
					MessageBox.Show("Well, okay then. That was close!", "Man A", MessageBoxButtons.OK);
				}
				return;
			}
			else if (this.buttonPressedCount == 1)
			{
				DialogResult dialogResult2 = MessageBox.Show("Are you sure you want to press it?", "Virus.exe", MessageBoxButtons.YesNo);
				if (dialogResult2 == DialogResult.Yes)
				{
					this.buttonPressedCount++;
					MessageBox.Show("Didn't I just tell you not to do that?", "Man A", MessageBoxButtons.OK);
					return;
				}
				if (dialogResult2 == DialogResult.No)
				{
					MessageBox.Show("Stop it! You're pestering me.", "Man A", MessageBoxButtons.OK);
				}
				return;
			}
			else
			{
				if (this.buttonPressedCount != 2)
				{
					return;
				}
				DialogResult dialogResult3 = MessageBox.Show("Are you sure you want to press it?", "Virus.exe", MessageBoxButtons.YesNo);
				if (dialogResult3 == DialogResult.Yes)
				{
					MessageBox.Show("THAT'S IT! I've had it with you! Prepare...", "Man A", MessageBoxButtons.OK);
					Helper.Kill();
					MessageBox.Show("Don't mess with me again, or I'll wipe your hardrive ://", "Man A", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					Helper.KillSelf();
					return;
				}
				if (dialogResult3 == DialogResult.No)
				{
					MessageBox.Show("Just give up already!", "Man A", MessageBoxButtons.OK);
				}
				return;
			}
		}
		
        private void FunnyBtn1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Random randNum = new Random();
            int aRandomPos = randNum.Next(Helper.closingmessages.Count);
            MessageBox.Show(Helper.closingmessages[aRandomPos], "Man A", MessageBoxButtons.OK);
            e.Cancel = true;
        }
    }
}
