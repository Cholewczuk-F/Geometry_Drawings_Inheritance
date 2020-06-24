namespace Geometria
{
    partial class Geometria
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
            this.canvas = new System.Windows.Forms.Panel();
            this.controlsPanel = new System.Windows.Forms.Panel();
            this.radiusBox = new System.Windows.Forms.TextBox();
            this.radiusLabel = new System.Windows.Forms.Label();
            this.entryView = new System.Windows.Forms.DataGridView();
            this.yBox = new System.Windows.Forms.TextBox();
            this.xBox = new System.Windows.Forms.TextBox();
            this.yLabel = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.typeCombo = new System.Windows.Forms.ComboBox();
            this.controlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entryView)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvas.BackColor = System.Drawing.SystemColors.Window;
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(667, 509);
            this.canvas.TabIndex = 0;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // controlsPanel
            // 
            this.controlsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlsPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.controlsPanel.Controls.Add(this.radiusBox);
            this.controlsPanel.Controls.Add(this.radiusLabel);
            this.controlsPanel.Controls.Add(this.entryView);
            this.controlsPanel.Controls.Add(this.yBox);
            this.controlsPanel.Controls.Add(this.xBox);
            this.controlsPanel.Controls.Add(this.yLabel);
            this.controlsPanel.Controls.Add(this.xLabel);
            this.controlsPanel.Controls.Add(this.addButton);
            this.controlsPanel.Controls.Add(this.typeCombo);
            this.controlsPanel.Location = new System.Drawing.Point(665, -1);
            this.controlsPanel.Name = "controlsPanel";
            this.controlsPanel.Size = new System.Drawing.Size(220, 513);
            this.controlsPanel.TabIndex = 1;
            // 
            // radiusBox
            // 
            this.radiusBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radiusBox.Enabled = false;
            this.radiusBox.Location = new System.Drawing.Point(61, 75);
            this.radiusBox.Name = "radiusBox";
            this.radiusBox.Size = new System.Drawing.Size(61, 20);
            this.radiusBox.TabIndex = 8;
            // 
            // radiusLabel
            // 
            this.radiusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radiusLabel.AutoSize = true;
            this.radiusLabel.Location = new System.Drawing.Point(9, 78);
            this.radiusLabel.Name = "radiusLabel";
            this.radiusLabel.Size = new System.Drawing.Size(46, 13);
            this.radiusLabel.TabIndex = 7;
            this.radiusLabel.Text = "Radius: ";
            this.radiusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // entryView
            // 
            this.entryView.AllowUserToAddRows = false;
            this.entryView.AllowUserToDeleteRows = false;
            this.entryView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entryView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.entryView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.entryView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.entryView.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.entryView.Location = new System.Drawing.Point(0, 226);
            this.entryView.Name = "entryView";
            this.entryView.RowHeadersVisible = false;
            this.entryView.Size = new System.Drawing.Size(217, 287);
            this.entryView.TabIndex = 6;
            this.entryView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.entryView_CellContentClick);
            // 
            // yBox
            // 
            this.yBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yBox.Location = new System.Drawing.Point(118, 44);
            this.yBox.Name = "yBox";
            this.yBox.Size = new System.Drawing.Size(61, 20);
            this.yBox.TabIndex = 5;
            this.yBox.TextChanged += new System.EventHandler(this.yBox_TextChanged);
            // 
            // xBox
            // 
            this.xBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xBox.Location = new System.Drawing.Point(25, 44);
            this.xBox.Name = "xBox";
            this.xBox.Size = new System.Drawing.Size(61, 20);
            this.xBox.TabIndex = 4;
            this.xBox.TextChanged += new System.EventHandler(this.xBox_TextChanged);
            // 
            // yLabel
            // 
            this.yLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(101, 47);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(20, 13);
            this.yLabel.TabIndex = 3;
            this.yLabel.Text = "Y: ";
            this.yLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel
            // 
            this.xLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(9, 47);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(20, 13);
            this.xLabel.TabIndex = 2;
            this.xLabel.Text = "X: ";
            this.xLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(159, 13);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(48, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // typeCombo
            // 
            this.typeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.typeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeCombo.Items.AddRange(new object[] {
            "Point",
            "Circle",
            "Triangle",
            "Polygon"});
            this.typeCombo.Location = new System.Drawing.Point(9, 13);
            this.typeCombo.Name = "typeCombo";
            this.typeCombo.Size = new System.Drawing.Size(144, 21);
            this.typeCombo.TabIndex = 0;
            this.typeCombo.SelectedIndexChanged += new System.EventHandler(this.typeCombo_SelectedIndexChanged);
            // 
            // Geometria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 511);
            this.Controls.Add(this.controlsPanel);
            this.Controls.Add(this.canvas);
            this.MinimumSize = new System.Drawing.Size(900, 550);
            this.Name = "Geometria";
            this.Text = "Program Geometria";
            this.Load += new System.EventHandler(this.Geometria_Load);
            this.controlsPanel.ResumeLayout(false);
            this.controlsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entryView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.Panel controlsPanel;
        private System.Windows.Forms.ComboBox typeCombo;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.TextBox yBox;
        private System.Windows.Forms.TextBox xBox;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.DataGridView entryView;
        private System.Windows.Forms.TextBox radiusBox;
        private System.Windows.Forms.Label radiusLabel;
    }
}

