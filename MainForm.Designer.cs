namespace Beacon;

partial class MainForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.label5 = new System.Windows.Forms.Label();
        this.label6 = new System.Windows.Forms.Label();
        this.button1 = new System.Windows.Forms.Button();
        this.panel1 = new System.Windows.Forms.Panel();
        this.SuspendLayout();
        // 
        // textBox1
        // 
        this.textBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
        this.textBox1.Location = new System.Drawing.Point(118, 157);
        this.textBox1.Multiline = true;
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(224, 214);
        this.textBox1.TabIndex = 0;
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label2.Location = new System.Drawing.Point(272, 33);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(251, 73);
        this.label2.TabIndex = 2;
        this.label2.Text = "Beacon";
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.BackColor = System.Drawing.SystemColors.AppWorkspace;
        this.label3.Location = new System.Drawing.Point(393, 157);
        this.label3.Name = "label3";
        this.label3.Padding = new System.Windows.Forms.Padding(5);
        this.label3.Size = new System.Drawing.Size(143, 23);
        this.label3.TabIndex = 3;
        this.label3.Text = "Check if this is a ZIP folder";
        // 
        // label4
        // 
        this.label4.BackColor = System.Drawing.SystemColors.AppWorkspace;
        this.label4.Location = new System.Drawing.Point(393, 216);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(320, 40);
        this.label4.TabIndex = 4;
        this.label4.Text = "Check the size for this ZIP folder";
        // 
        // label5
        // 
        this.label5.BackColor = System.Drawing.SystemColors.AppWorkspace;
        this.label5.Location = new System.Drawing.Point(393, 271);
        this.label5.Name = "label5";
        this.label5.Size = new System.Drawing.Size(320, 40);
        this.label5.TabIndex = 5;
        this.label5.Text = "Check if this folder is password protected";
        // 
        // label6
        // 
        this.label6.BackColor = System.Drawing.SystemColors.AppWorkspace;
        this.label6.Location = new System.Drawing.Point(393, 331);
        this.label6.Name = "label6";
        this.label6.Size = new System.Drawing.Size(320, 40);
        this.label6.TabIndex = 6;
        this.label6.Text = "Check if this folder contains malicious files";
        // 
        // button1
        // 
        this.button1.Location = new System.Drawing.Point(305, 391);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(201, 33);
        this.button1.TabIndex = 7;
        this.button1.Text = "Check Folder";
        this.button1.UseVisualStyleBackColor = true;
        // 
        // panel1
        // 
        this.panel1.BackColor = System.Drawing.Color.Black;
        this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.panel1.Location = new System.Drawing.Point(88, 120);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(651, 3);
        this.panel1.TabIndex = 8;
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.White;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Controls.Add(this.panel1);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.label6);
        this.Controls.Add(this.label5);
        this.Controls.Add(this.label4);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.textBox1);
        this.Name = "Form1";
        this.Text = "Form1";
        this.Load += new System.EventHandler(this.MainForm_Load);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Panel panel1;

}