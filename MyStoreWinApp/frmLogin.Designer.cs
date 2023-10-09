namespace MyStoreWinApp;

partial class frmLogin
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
        lbEmail = new Label();
        txtEmail = new TextBox();
        lbPassword = new Label();
        txtPassword = new TextBox();
        btnLogin = new Button();
        btnCancel = new Button();
        SuspendLayout();
        // 
        // lbEmail
        // 
        lbEmail.AutoSize = true;
        lbEmail.Location = new Point(37, 35);
        lbEmail.Name = "lbEmail";
        lbEmail.Size = new Size(46, 20);
        lbEmail.TabIndex = 0;
        lbEmail.Text = "Email";
        // 
        // txtEmail
        // 
        txtEmail.Location = new Point(123, 31);
        txtEmail.Margin = new Padding(3, 4, 3, 4);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(295, 27);
        txtEmail.TabIndex = 1;
        // 
        // lbPassword
        // 
        lbPassword.AutoSize = true;
        lbPassword.Location = new Point(37, 93);
        lbPassword.Name = "lbPassword";
        lbPassword.Size = new Size(70, 20);
        lbPassword.TabIndex = 0;
        lbPassword.Text = "Password";
        // 
        // txtPassword
        // 
        txtPassword.Location = new Point(123, 89);
        txtPassword.Margin = new Padding(3, 4, 3, 4);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '*';
        txtPassword.Size = new Size(295, 27);
        txtPassword.TabIndex = 2;
        // 
        // btnLogin
        // 
        btnLogin.Location = new Point(123, 176);
        btnLogin.Margin = new Padding(3, 4, 3, 4);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(93, 39);
        btnLogin.TabIndex = 3;
        btnLogin.Text = "&Login";
        btnLogin.UseVisualStyleBackColor = true;
        btnLogin.Click += btnLogin_Click;
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(266, 176);
        btnCancel.Margin = new Padding(3, 4, 3, 4);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(93, 39);
        btnCancel.TabIndex = 4;
        btnCancel.Text = "&Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // frmLogin
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(475, 289);
        Controls.Add(btnCancel);
        Controls.Add(btnLogin);
        Controls.Add(txtPassword);
        Controls.Add(lbPassword);
        Controls.Add(txtEmail);
        Controls.Add(lbEmail);
        Margin = new Padding(3, 4, 3, 4);
        Name = "frmLogin";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "FStore - Login";
        Load += frmLogin_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lbEmail;
    private TextBox txtEmail;
    private Label lbPassword;
    private TextBox txtPassword;
    private Button btnLogin;
    private Button btnCancel;
}
