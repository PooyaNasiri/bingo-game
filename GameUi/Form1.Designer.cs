using System;
using System.Windows.Forms;
namespace GameUi
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            for (int i = 0; i <= 5; i++)
                for (int j = 0; j <= 7; j++)
                    buttons[i, j] = new Button();

            for (int i = 0; i < 6; i++)
                for (int j = 0; j < 8; j++)
                {
                    buttons[i, j].Location = new System.Drawing.Point(60 * j + 40, 50 * i + 50);
                    buttons[i, j].Name = (j + 1 + (i * 8)) + "";
                    buttons[i, j].Size = new System.Drawing.Size(55, 45);
                    buttons[i, j].Text = (j + 1 + (i * 8)) + "";
                    buttons[i, j].UseVisualStyleBackColor = true;
                    Controls.Add(this.buttons[i, j]);
                    buttons[i, j].Click += new System.EventHandler(buttons_Click);
                }

            
            next_turn.Location = new System.Drawing.Point(440, 370);
            next_turn.Name = "Next Turn";
            next_turn.Text = "Next Turn";
            next_turn.UseVisualStyleBackColor = true;
            Controls.Add(next_turn);
            next_turn.Click += new System.EventHandler(Next_turn_Click);

            turn.Location = new System.Drawing.Point(40, 370);
            turn.Name = "turn";
            turn.Text = "turn: Your turn";
            turn.AutoSize = true;
            Controls.Add(turn);

            RandomNumber.Location = new System.Drawing.Point(250, 370);
            RandomNumber.Name = "Random Number";
            RandomNumber.Text = "";
            RandomNumber.AutoSize = true;
            Controls.Add(RandomNumber);

            status.Location = new System.Drawing.Point(40, 10);
            status.Name = "status";
            status.Text = "status: Play";
            status.AutoSize = true;
            Controls.Add(status);

            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 420);
            this.ShowIcon = false;
            this.MaximumSize = new System.Drawing.Size(560, 450);
            this.MinimumSize = new System.Drawing.Size(560, 450);
            this.AutoSize = true;

            this.Name = "Dabelna";
            this.Text = "Dabelna";
            this.ResumeLayout(true);
            this.PerformLayout();

        }

        public Button[,] buttons = new Button[6, 8];
        public Button next_turn = new Button();
        public Label turn = new Label();
        public Label RandomNumber = new Label();
        public Label status = new Label();
    }
}

#endregion