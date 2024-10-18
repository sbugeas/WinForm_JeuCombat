﻿namespace WinForms_JeuCombat
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            PlayButton = new Button();
            QuitButton = new Button();
            label1 = new Label();
            DamagerButton = new Button();
            HealerButton = new Button();
            TankButton = new Button();
            AssasinButton = new Button();
            textBox1 = new TextBox();
            AttackButton = new Button();
            DefendButton = new Button();
            SpellButton = new Button();
            SuspendLayout();
            // 
            // PlayButton
            // 
            PlayButton.BackColor = Color.Transparent;
            PlayButton.BackgroundImageLayout = ImageLayout.None;
            PlayButton.FlatAppearance.BorderSize = 0;
            PlayButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            PlayButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            PlayButton.FlatStyle = FlatStyle.Flat;
            PlayButton.ForeColor = Color.Transparent;
            PlayButton.Image = (Image)resources.GetObject("PlayButton.Image");
            PlayButton.Location = new Point(12, 12);
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new Size(597, 110);
            PlayButton.TabIndex = 0;
            PlayButton.TextImageRelation = TextImageRelation.ImageAboveText;
            PlayButton.UseVisualStyleBackColor = false;
            PlayButton.Click += button1_Click;
            // 
            // QuitButton
            // 
            QuitButton.BackColor = Color.Transparent;
            QuitButton.BackgroundImageLayout = ImageLayout.Center;
            QuitButton.FlatAppearance.BorderSize = 0;
            QuitButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            QuitButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            QuitButton.FlatStyle = FlatStyle.Flat;
            QuitButton.ForeColor = Color.Transparent;
            QuitButton.Image = (Image)resources.GetObject("QuitButton.Image");
            QuitButton.Location = new Point(12, 128);
            QuitButton.Name = "QuitButton";
            QuitButton.Size = new Size(597, 106);
            QuitButton.TabIndex = 1;
            QuitButton.TextImageRelation = TextImageRelation.ImageAboveText;
            QuitButton.UseVisualStyleBackColor = false;
            QuitButton.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 75F);
            label1.Location = new Point(12, 237);
            label1.Name = "label1";
            label1.Size = new Size(321, 133);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // DamagerButton
            // 
            DamagerButton.Location = new Point(0, -30);
            DamagerButton.Name = "DamagerButton";
            DamagerButton.Size = new Size(75, 23);
            DamagerButton.TabIndex = 3;
            DamagerButton.Tag = "1";
            DamagerButton.Text = "Damager";
            DamagerButton.UseVisualStyleBackColor = true;
            DamagerButton.Click += button3_Click;
            // 
            // HealerButton
            // 
            HealerButton.Location = new Point(0, -30);
            HealerButton.Name = "HealerButton";
            HealerButton.Size = new Size(75, 23);
            HealerButton.TabIndex = 4;
            HealerButton.Tag = "2";
            HealerButton.Text = "Healer";
            HealerButton.UseVisualStyleBackColor = true;
            HealerButton.Click += button3_Click;
            // 
            // TankButton
            // 
            TankButton.Location = new Point(0, -30);
            TankButton.Name = "TankButton";
            TankButton.Size = new Size(75, 23);
            TankButton.TabIndex = 5;
            TankButton.Tag = "3";
            TankButton.Text = "Tank";
            TankButton.UseVisualStyleBackColor = true;
            TankButton.Click += button3_Click;
            // 
            // AssasinButton
            // 
            AssasinButton.Location = new Point(0, -30);
            AssasinButton.Name = "AssasinButton";
            AssasinButton.Size = new Size(75, 23);
            AssasinButton.TabIndex = 6;
            AssasinButton.Tag = "4";
            AssasinButton.Text = "Assassin";
            AssasinButton.UseVisualStyleBackColor = true;
            AssasinButton.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.AcceptsReturn = true;
            textBox1.Location = new Point(637, 57);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(583, 265);
            textBox1.TabIndex = 7;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // AttackButton
            // 
            AttackButton.Location = new Point(625, 328);
            AttackButton.Name = "AttackButton";
            AttackButton.Size = new Size(75, 23);
            AttackButton.TabIndex = 8;
            AttackButton.Tag = "1";
            AttackButton.Text = "Attack";
            AttackButton.UseVisualStyleBackColor = true;
            AttackButton.Click += button7_Click;
            // 
            // DefendButton
            // 
            DefendButton.Location = new Point(625, 357);
            DefendButton.Name = "DefendButton";
            DefendButton.Size = new Size(75, 23);
            DefendButton.TabIndex = 9;
            DefendButton.Tag = "2";
            DefendButton.Text = "Defend";
            DefendButton.UseVisualStyleBackColor = true;
            DefendButton.Click += button7_Click;
            // 
            // SpellButton
            // 
            SpellButton.Location = new Point(625, 386);
            SpellButton.Name = "SpellButton";
            SpellButton.Size = new Size(75, 23);
            SpellButton.TabIndex = 10;
            SpellButton.Tag = "3";
            SpellButton.Text = "Spell";
            SpellButton.UseVisualStyleBackColor = true;
            SpellButton.Click += button7_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(800, 450);
            Controls.Add(SpellButton);
            Controls.Add(DefendButton);
            Controls.Add(AttackButton);
            Controls.Add(textBox1);
            Controls.Add(AssasinButton);
            Controls.Add(TankButton);
            Controls.Add(HealerButton);
            Controls.Add(DamagerButton);
            Controls.Add(label1);
            Controls.Add(QuitButton);
            Controls.Add(PlayButton);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button PlayButton;
        private Button QuitButton;
        private Label label1;
        private Button DamagerButton;
        private Button HealerButton;
        private Button TankButton;
        private Button AssasinButton;
        private TextBox textBox1;
        private Button AttackButton;
        private Button DefendButton;
        private Button SpellButton;
    }
}
