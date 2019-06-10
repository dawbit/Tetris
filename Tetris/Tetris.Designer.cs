namespace Tetris
{
    partial class Tetris
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel_field = new System.Windows.Forms.Panel();
            this.button_start = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_score = new System.Windows.Forms.Label();
            this.scoreboard = new System.Windows.Forms.Label();
            this.instruction_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel_field
            // 
            this.panel_field.Location = new System.Drawing.Point(1, 87);
            this.panel_field.Margin = new System.Windows.Forms.Padding(4);
            this.panel_field.Name = "panel_field";
            this.panel_field.Size = new System.Drawing.Size(300, 500);
            this.panel_field.TabIndex = 1;
            this.panel_field.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);
            // 
            // button_start
            // 
            this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_start.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.button_start.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_start.Location = new System.Drawing.Point(-3, -3);
            this.button_start.Margin = new System.Windows.Forms.Padding(4);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(307, 59);
            this.button_start.TabIndex = 0;
            this.button_start.Text = "Start game";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.Button_start_game_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // label_score
            // 
            this.label_score.AutoSize = true;
            this.label_score.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_score.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_score.Location = new System.Drawing.Point(12, 60);
            this.label_score.Name = "label_score";
            this.label_score.Size = new System.Drawing.Size(74, 23);
            this.label_score.TabIndex = 3;
            this.label_score.Text = "Score:";
            // 
            // scoreboard
            // 
            this.scoreboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.scoreboard.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.scoreboard.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.scoreboard.Location = new System.Drawing.Point(92, 60);
            this.scoreboard.Name = "scoreboard";
            this.scoreboard.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.scoreboard.Size = new System.Drawing.Size(188, 23);
            this.scoreboard.TabIndex = 4;
            this.scoreboard.Text = "0";
            this.scoreboard.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // instruction_label
            // 
            this.instruction_label.AutoSize = true;
            this.instruction_label.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.instruction_label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.instruction_label.Location = new System.Drawing.Point(12, 591);
            this.instruction_label.Name = "instruction_label";
            this.instruction_label.Size = new System.Drawing.Size(202, 51);
            this.instruction_label.TabIndex = 4;
            this.instruction_label.Text = "Game instruction:\r\nclick [A] or [←] to turn left,\r\nclick [D] or [→] to turn right" +
    "\r\n";
            // 
            // Tetris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(292, 652);
            this.Controls.Add(this.instruction_label);
            this.Controls.Add(this.scoreboard);
            this.Controls.Add(this.label_score);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.panel_field);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Tetris";
            this.ShowIcon = false;
            this.Text = "Tetris";
            this.Load += new System.EventHandler(this.Tetris_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tetris_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_field;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_score;
        private System.Windows.Forms.Label scoreboard;
        private System.Windows.Forms.Label instruction_label;
    }
}

