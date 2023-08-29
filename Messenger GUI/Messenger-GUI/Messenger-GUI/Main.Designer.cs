namespace Messenger_GUI
{
    partial class Main
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
            listBox1 = new ListBox();
            richTextBox1 = new RichTextBox();
            textBox1 = new TextBox();
            button1 = new Button();
            textBox2 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            textBox3 = new TextBox();
            button6 = new Button();
            button7 = new Button();
            listBox2 = new ListBox();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 139);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(120, 334);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(137, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(698, 432);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(138, 450);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(587, 23);
            textBox1.TabIndex = 2;
            textBox1.KeyDown += textBox1_KeyDown;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // button1
            // 
            button1.Location = new Point(731, 450);
            button1.Name = "button1";
            button1.Size = new Size(105, 24);
            button1.TabIndex = 3;
            button1.Text = "Send";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(15, 3);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Friend name";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 4;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // button2
            // 
            button2.Location = new Point(15, 32);
            button2.Name = "button2";
            button2.Size = new Size(100, 24);
            button2.TabIndex = 5;
            button2.Text = "Add friend";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(15, 62);
            button3.Name = "button3";
            button3.Size = new Size(100, 24);
            button3.TabIndex = 6;
            button3.Text = "Refresh friends";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(12, 109);
            button4.Name = "button4";
            button4.Size = new Size(58, 24);
            button4.TabIndex = 7;
            button4.Text = "Friends";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(76, 109);
            button5.Name = "button5";
            button5.Size = new Size(58, 24);
            button5.TabIndex = 8;
            button5.Text = "Groups";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button3);
            panel1.Location = new Point(4, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(130, 93);
            panel1.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(button6);
            panel2.Controls.Add(button7);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(130, 93);
            panel2.TabIndex = 10;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(15, 3);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Group code";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 4;
            // 
            // button6
            // 
            button6.Location = new Point(15, 32);
            button6.Name = "button6";
            button6.Size = new Size(100, 24);
            button6.TabIndex = 5;
            button6.Text = "Join group";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(15, 62);
            button7.Name = "button7";
            button7.Size = new Size(100, 24);
            button7.TabIndex = 6;
            button7.Text = "Refresh groups";
            button7.UseVisualStyleBackColor = true;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(851, 28);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(120, 454);
            listBox2.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(851, 10);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 11;
            label1.Text = "Chat members";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 486);
            Controls.Add(label1);
            Controls.Add(listBox2);
            Controls.Add(panel1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(richTextBox1);
            Controls.Add(listBox1);
            Name = "Main";
            Text = "Main";
            Load += Main_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private RichTextBox richTextBox1;
        private TextBox textBox1;
        private Button button1;
        private TextBox textBox2;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Panel panel1;
        private ListBox listBox2;
        private Label label1;
        private Panel panel2;
        private TextBox textBox3;
        private Button button6;
        private Button button7;
    }
}