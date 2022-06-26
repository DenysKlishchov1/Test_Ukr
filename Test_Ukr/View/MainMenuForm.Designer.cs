namespace Test_Ukr.View
{
    partial class MainMenuForm
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
            this.dataGridEmloyee = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCreateEmployee = new System.Windows.Forms.Button();
            this.btnPosition = new System.Windows.Forms.Button();
            this.btnDepartment = new System.Windows.Forms.Button();
            this.comboBoxFilter = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPayments = new System.Windows.Forms.Label();
            this.comboBoxPayments = new System.Windows.Forms.ComboBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.dialogForReport = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmloyee)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridEmloyee
            // 
            this.dataGridEmloyee.AllowUserToAddRows = false;
            this.dataGridEmloyee.AllowUserToDeleteRows = false;
            this.dataGridEmloyee.AllowUserToResizeRows = false;
            this.dataGridEmloyee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEmloyee.Location = new System.Drawing.Point(491, 63);
            this.dataGridEmloyee.Name = "dataGridEmloyee";
            this.dataGridEmloyee.ReadOnly = true;
            this.dataGridEmloyee.RowHeadersWidth = 51;
            this.dataGridEmloyee.RowTemplate.Height = 24;
            this.dataGridEmloyee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridEmloyee.Size = new System.Drawing.Size(1032, 635);
            this.dataGridEmloyee.TabIndex = 0;
            this.dataGridEmloyee.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridEmloyee_CellContentClick);
            this.dataGridEmloyee.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridEmloyee_DataError);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnCreateEmployee);
            this.panel1.Controls.Add(this.btnPosition);
            this.panel1.Controls.Add(this.btnDepartment);
            this.panel1.Location = new System.Drawing.Point(12, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 245);
            this.panel1.TabIndex = 1;
            // 
            // btnCreateEmployee
            // 
            this.btnCreateEmployee.Location = new System.Drawing.Point(27, 155);
            this.btnCreateEmployee.Name = "btnCreateEmployee";
            this.btnCreateEmployee.Size = new System.Drawing.Size(376, 60);
            this.btnCreateEmployee.TabIndex = 2;
            this.btnCreateEmployee.Text = "Добавить сотрудника";
            this.btnCreateEmployee.UseVisualStyleBackColor = true;
            this.btnCreateEmployee.Click += new System.EventHandler(this.btnCreateEmployee_Click);
            // 
            // btnPosition
            // 
            this.btnPosition.Location = new System.Drawing.Point(27, 89);
            this.btnPosition.Name = "btnPosition";
            this.btnPosition.Size = new System.Drawing.Size(376, 60);
            this.btnPosition.TabIndex = 1;
            this.btnPosition.Text = "Редактирование должностей";
            this.btnPosition.UseVisualStyleBackColor = true;
            this.btnPosition.Click += new System.EventHandler(this.btnPosition_Click);
            // 
            // btnDepartment
            // 
            this.btnDepartment.Location = new System.Drawing.Point(27, 21);
            this.btnDepartment.Name = "btnDepartment";
            this.btnDepartment.Size = new System.Drawing.Size(376, 60);
            this.btnDepartment.TabIndex = 0;
            this.btnDepartment.Text = "Редактирование отделов";
            this.btnDepartment.UseVisualStyleBackColor = true;
            this.btnDepartment.Click += new System.EventHandler(this.btnDepartment_Click);
            // 
            // comboBoxFilter
            // 
            this.comboBoxFilter.FormattingEnabled = true;
            this.comboBoxFilter.Location = new System.Drawing.Point(491, 23);
            this.comboBoxFilter.Name = "comboBoxFilter";
            this.comboBoxFilter.Size = new System.Drawing.Size(283, 24);
            this.comboBoxFilter.TabIndex = 2;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(780, 20);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(159, 28);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.Text = "Фильтр";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(1364, 23);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(159, 28);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Перечитать";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.labelPayments);
            this.panel2.Controls.Add(this.comboBoxPayments);
            this.panel2.Location = new System.Drawing.Point(12, 325);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(427, 79);
            this.panel2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выплаты";
            // 
            // labelPayments
            // 
            this.labelPayments.AutoSize = true;
            this.labelPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPayments.Location = new System.Drawing.Point(236, 33);
            this.labelPayments.Name = "labelPayments";
            this.labelPayments.Size = new System.Drawing.Size(132, 24);
            this.labelPayments.TabIndex = 1;
            this.labelPayments.Text = "labelPayments";
            // 
            // comboBoxPayments
            // 
            this.comboBoxPayments.FormattingEnabled = true;
            this.comboBoxPayments.Location = new System.Drawing.Point(27, 35);
            this.comboBoxPayments.Name = "comboBoxPayments";
            this.comboBoxPayments.Size = new System.Drawing.Size(142, 24);
            this.comboBoxPayments.TabIndex = 0;
            this.comboBoxPayments.SelectedIndexChanged += new System.EventHandler(this.comboBoxPayments_SelectedIndexChanged);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(44, 445);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(372, 60);
            this.btnReport.TabIndex = 6;
            this.btnReport.Text = "Сформировать отчет";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1535, 710);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.comboBoxFilter);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridEmloyee);
            this.Name = "MainMenuForm";
            this.Text = "MainMenuForm";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEmloyee)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridEmloyee;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCreateEmployee;
        private System.Windows.Forms.Button btnPosition;
        private System.Windows.Forms.Button btnDepartment;
        private System.Windows.Forms.ComboBox comboBoxFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPayments;
        private System.Windows.Forms.ComboBox comboBoxPayments;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.FolderBrowserDialog dialogForReport;
    }
}