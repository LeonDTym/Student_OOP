namespace WindowsFormsApp1.Forms {
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
            this.studentGridView = new System.Windows.Forms.DataGridView();
            this.studentGroupBox = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnChek = new System.Windows.Forms.Button();
            this.lbChek = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.studentGridView)).BeginInit();
            this.studentGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // studentGridView
            // 
            this.studentGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studentGridView.Location = new System.Drawing.Point(8, 23);
            this.studentGridView.Margin = new System.Windows.Forms.Padding(4);
            this.studentGridView.MultiSelect = false;
            this.studentGridView.Name = "studentGridView";
            this.studentGridView.RowHeadersWidth = 51;
            this.studentGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.studentGridView.Size = new System.Drawing.Size(581, 277);
            this.studentGridView.TabIndex = 0;
            // 
            // studentGroupBox
            // 
            this.studentGroupBox.Controls.Add(this.studentGridView);
            this.studentGroupBox.Location = new System.Drawing.Point(16, 15);
            this.studentGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.studentGroupBox.Name = "studentGroupBox";
            this.studentGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.studentGroupBox.Size = new System.Drawing.Size(597, 308);
            this.studentGroupBox.TabIndex = 1;
            this.studentGroupBox.TabStop = false;
            this.studentGroupBox.Text = "Студенты";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(232, 330);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 28);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Tag = "DELETE";
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(124, 331);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 28);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Tag = "UPDATE";
            this.btnUpdate.Text = "Изменить";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(16, 331);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(4);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(100, 28);
            this.btnInsert.TabIndex = 5;
            this.btnInsert.Tag = "INSERT";
            this.btnInsert.Text = "Добавить";
            this.btnInsert.UseVisualStyleBackColor = true;
            // 
            // btnChek
            // 
            this.btnChek.Location = new System.Drawing.Point(737, 76);
            this.btnChek.Name = "btnChek";
            this.btnChek.Size = new System.Drawing.Size(75, 23);
            this.btnChek.TabIndex = 6;
            this.btnChek.Text = "button1";
            this.btnChek.UseVisualStyleBackColor = true;
            this.btnChek.Click += new System.EventHandler(this.btnChek_Click);
            // 
            // lbChek
            // 
            this.lbChek.AutoSize = true;
            this.lbChek.Location = new System.Drawing.Point(739, 121);
            this.lbChek.Name = "lbChek";
            this.lbChek.Size = new System.Drawing.Size(46, 17);
            this.lbChek.TabIndex = 7;
            this.lbChek.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 374);
            this.Controls.Add(this.lbChek);
            this.Controls.Add(this.btnChek);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.studentGroupBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.studentGridView)).EndInit();
            this.studentGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView studentGridView;
        private System.Windows.Forms.GroupBox studentGroupBox;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnChek;
        private System.Windows.Forms.Label lbChek;
    }
}