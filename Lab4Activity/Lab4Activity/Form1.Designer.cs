namespace Lab4Activity
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
            tfInput = new RichTextBox();
            tfTokens = new RichTextBox();
            symbolTable = new RichTextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // tfInput
            // 
            tfInput.Location = new Point(57, 29);
            tfInput.Name = "tfInput";
            tfInput.Size = new Size(440, 108);
            tfInput.TabIndex = 0;
            tfInput.Text = "";
            // 
            // tfTokens
            // 
            tfTokens.Location = new Point(67, 162);
            tfTokens.Name = "tfTokens";
            tfTokens.Size = new Size(100, 96);
            tfTokens.TabIndex = 1;
            tfTokens.Text = "";
            // 
            // symbolTable
            // 
            symbolTable.Location = new Point(218, 161);
            symbolTable.Name = "symbolTable";
            symbolTable.Size = new Size(279, 96);
            symbolTable.TabIndex = 2;
            symbolTable.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(247, 278);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 339);
            Controls.Add(button1);
            Controls.Add(symbolTable);
            Controls.Add(tfTokens);
            Controls.Add(tfInput);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox tfInput;
        private RichTextBox tfTokens;
        private RichTextBox symbolTable;
        private Button button1;
    }
}