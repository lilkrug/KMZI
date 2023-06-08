namespace LW12
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
            algorithmBox = new ComboBox();
            label1 = new Label();
            executeButton = new Button();
            label2 = new Label();
            timeLabel = new Label();
            textBox = new RichTextBox();
            resultBox = new RichTextBox();
            SuspendLayout();
            // 
            // algorithmBox
            // 
            algorithmBox.FormattingEnabled = true;
            algorithmBox.Items.AddRange(new object[] { "RSA", "Elgamal", "Shnorr" });
            algorithmBox.Location = new Point(12, 12);
            algorithmBox.Name = "algorithmBox";
            algorithmBox.Size = new Size(151, 28);
            algorithmBox.TabIndex = 0;
            algorithmBox.SelectedIndexChanged += algorithmBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 67);
            label1.Name = "label1";
            label1.Size = new Size(45, 20);
            label1.TabIndex = 2;
            label1.Text = "Текст";
            // 
            // executeButton
            // 
            executeButton.Location = new Point(1054, 12);
            executeButton.Name = "executeButton";
            executeButton.Size = new Size(150, 41);
            executeButton.TabIndex = 3;
            executeButton.Text = "Выполнить";
            executeButton.UseVisualStyleBackColor = true;
            executeButton.Click += executeButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 327);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 5;
            label2.Text = "Результат";
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Location = new Point(218, 12);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(68, 20);
            timeLabel.TabIndex = 6;
            timeLabel.Text = "Время: ?";
            // 
            // textBox
            // 
            textBox.Location = new Point(12, 90);
            textBox.Name = "textBox";
            textBox.Size = new Size(1192, 234);
            textBox.TabIndex = 7;
            textBox.Text = "";
            // 
            // resultBox
            // 
            resultBox.Location = new Point(12, 350);
            resultBox.Name = "resultBox";
            resultBox.Size = new Size(1192, 234);
            resultBox.TabIndex = 8;
            resultBox.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1216, 644);
            Controls.Add(resultBox);
            Controls.Add(textBox);
            Controls.Add(timeLabel);
            Controls.Add(label2);
            Controls.Add(executeButton);
            Controls.Add(label1);
            Controls.Add(algorithmBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox algorithmBox;
        private Label label1;
        private Button executeButton;
        private Label label2;
        private Label timeLabel;
        private RichTextBox textBox;
        private RichTextBox resultBox;
    }
}