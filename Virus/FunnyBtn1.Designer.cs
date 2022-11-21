namespace Virus
{
	public partial class FunnyBtn1 : global::System.Windows.Forms.Form
	{
        private global::System.Windows.Forms.Button button1;
        private void InitializeComponent()
		{
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.button1.Location = new System.Drawing.Point(101, 52);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "dont press";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 144);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FunnyBtn1";
            this.Text = "Virus.exe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FunnyBtn1_FormClosing);
            this.Load += new System.EventHandler(this.FunnyBtn_Load);
            this.Shown += new System.EventHandler(this.FunnyBtn1_Shown);
            this.ResumeLayout(false);

		}
	}
}
