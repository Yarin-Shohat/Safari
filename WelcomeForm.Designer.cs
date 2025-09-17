namespace Safari
{
    partial class WelcomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeForm));
            WelcomeLabel = new Label();
            AddNewLakeCapacityBox = new TextBox();
            AddNewLakeButton = new Button();
            AddNewLakeCapacityLabel = new Label();
            StartButton = new Button();
            LakesCapacityList = new ListBox();
            SuspendLayout();
            // 
            // WelcomeLabel
            // 
            WelcomeLabel.AutoSize = true;
            WelcomeLabel.BackColor = Color.Transparent;
            WelcomeLabel.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            WelcomeLabel.ForeColor = SystemColors.ActiveCaptionText;
            WelcomeLabel.Location = new Point(158, 33);
            WelcomeLabel.Name = "WelcomeLabel";
            WelcomeLabel.Size = new Size(499, 60);
            WelcomeLabel.TabIndex = 0;
            WelcomeLabel.Text = "Welcome To The Safari";
            WelcomeLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // AddNewLakeCapacityBox
            // 
            AddNewLakeCapacityBox.Location = new Point(266, 296);
            AddNewLakeCapacityBox.Name = "AddNewLakeCapacityBox";
            AddNewLakeCapacityBox.Size = new Size(244, 27);
            AddNewLakeCapacityBox.TabIndex = 1;
            // 
            // AddNewLakeButton
            // 
            AddNewLakeButton.Location = new Point(266, 335);
            AddNewLakeButton.Name = "AddNewLakeButton";
            AddNewLakeButton.Size = new Size(244, 29);
            AddNewLakeButton.TabIndex = 2;
            AddNewLakeButton.Text = "Add";
            AddNewLakeButton.UseVisualStyleBackColor = true;
            AddNewLakeButton.Click += AddNewLakeButton_Click;
            // 
            // AddNewLakeCapacityLabel
            // 
            AddNewLakeCapacityLabel.AutoSize = true;
            AddNewLakeCapacityLabel.BackColor = Color.DarkGray;
            AddNewLakeCapacityLabel.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddNewLakeCapacityLabel.Location = new Point(281, 264);
            AddNewLakeCapacityLabel.Name = "AddNewLakeCapacityLabel";
            AddNewLakeCapacityLabel.Size = new Size(212, 25);
            AddNewLakeCapacityLabel.TabIndex = 4;
            AddNewLakeCapacityLabel.Text = "Add New Lake Capacity";
            // 
            // StartButton
            // 
            StartButton.Location = new Point(266, 378);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(244, 29);
            StartButton.TabIndex = 5;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // LakesCapacityList
            // 
            LakesCapacityList.FormattingEnabled = true;
            LakesCapacityList.Location = new Point(626, 144);
            LakesCapacityList.Name = "LakesCapacityList";
            LakesCapacityList.Size = new Size(150, 284);
            LakesCapacityList.TabIndex = 3;
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(StartButton);
            Controls.Add(AddNewLakeCapacityLabel);
            Controls.Add(LakesCapacityList);
            Controls.Add(AddNewLakeButton);
            Controls.Add(AddNewLakeCapacityBox);
            Controls.Add(WelcomeLabel);
            Name = "WelcomeForm";
            Text = "Safari Welcome";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label WelcomeLabel;
        private TextBox AddNewLakeCapacityBox;
        private Button AddNewLakeButton;
        private Label AddNewLakeCapacityLabel;
        private Button StartButton;
        private ListBox LakesCapacityList;
    }
}
