﻿
namespace NYSEPro
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.CPU = new MetroFramework.Controls.MetroLabel();
            this.RAM = new MetroFramework.Controls.MetroLabel();
            this.HDD = new MetroFramework.Controls.MetroLabel();
            this.metroProgressBarCPU = new MetroFramework.Controls.MetroProgressBar();
            this.metroProgressBarRAM = new MetroFramework.Controls.MetroProgressBar();
            this.metroProgressBarHDD = new MetroFramework.Controls.MetroProgressBar();
            this.metroLabelCPU = new MetroFramework.Controls.MetroLabel();
            this.metroLabelHDD = new MetroFramework.Controls.MetroLabel();
            this.metroLabelRAM = new MetroFramework.Controls.MetroLabel();
            this.perfCounterCPU = new System.Diagnostics.PerformanceCounter();
            this.perfCounterRAM = new System.Diagnostics.PerformanceCounter();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.perfCounterHDD = new System.Diagnostics.PerformanceCounter();
            ((System.ComponentModel.ISupportInitialize)(this.perfCounterCPU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perfCounterRAM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perfCounterHDD)).BeginInit();
            this.SuspendLayout();
            // 
            // CPU
            // 
            this.CPU.AutoSize = true;
            this.CPU.Location = new System.Drawing.Point(310, 393);
            this.CPU.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.CPU.Name = "CPU";
            this.CPU.Size = new System.Drawing.Size(35, 19);
            this.CPU.TabIndex = 0;
            this.CPU.Text = "CPU";
            // 
            // RAM
            // 
            this.RAM.AutoSize = true;
            this.RAM.Location = new System.Drawing.Point(310, 532);
            this.RAM.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.RAM.Name = "RAM";
            this.RAM.Size = new System.Drawing.Size(38, 19);
            this.RAM.TabIndex = 1;
            this.RAM.Text = "RAM";
            // 
            // HDD
            // 
            this.HDD.AutoSize = true;
            this.HDD.Location = new System.Drawing.Point(317, 683);
            this.HDD.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.HDD.Name = "HDD";
            this.HDD.Size = new System.Drawing.Size(36, 19);
            this.HDD.TabIndex = 2;
            this.HDD.Text = "HDD";
            // 
            // metroProgressBarCPU
            // 
            this.metroProgressBarCPU.Location = new System.Drawing.Point(469, 393);
            this.metroProgressBarCPU.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.metroProgressBarCPU.Name = "metroProgressBarCPU";
            this.metroProgressBarCPU.Size = new System.Drawing.Size(757, 65);
            this.metroProgressBarCPU.TabIndex = 3;
            this.metroProgressBarCPU.Click += new System.EventHandler(this.MetroProgressBarCPU_Click);
            // 
            // metroProgressBarRAM
            // 
            this.metroProgressBarRAM.Location = new System.Drawing.Point(469, 521);
            this.metroProgressBarRAM.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.metroProgressBarRAM.Name = "metroProgressBarRAM";
            this.metroProgressBarRAM.Size = new System.Drawing.Size(757, 65);
            this.metroProgressBarRAM.TabIndex = 4;
            this.metroProgressBarRAM.Click += new System.EventHandler(this.MetroProgressBarRAM_Click);
            // 
            // metroProgressBarHDD
            // 
            this.metroProgressBarHDD.Location = new System.Drawing.Point(469, 672);
            this.metroProgressBarHDD.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.metroProgressBarHDD.Name = "metroProgressBarHDD";
            this.metroProgressBarHDD.Size = new System.Drawing.Size(757, 65);
            this.metroProgressBarHDD.TabIndex = 5;
            this.metroProgressBarHDD.Click += new System.EventHandler(this.MetroProgressBarHDD_Click);
            // 
            // metroLabelCPU
            // 
            this.metroLabelCPU.AutoSize = true;
            this.metroLabelCPU.Location = new System.Drawing.Point(1245, 404);
            this.metroLabelCPU.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.metroLabelCPU.Name = "metroLabelCPU";
            this.metroLabelCPU.Size = new System.Drawing.Size(27, 19);
            this.metroLabelCPU.TabIndex = 6;
            this.metroLabelCPU.Text = "0%";
            // 
            // metroLabelHDD
            // 
            this.metroLabelHDD.AutoSize = true;
            this.metroLabelHDD.Location = new System.Drawing.Point(1245, 672);
            this.metroLabelHDD.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.metroLabelHDD.Name = "metroLabelHDD";
            this.metroLabelHDD.Size = new System.Drawing.Size(27, 19);
            this.metroLabelHDD.TabIndex = 7;
            this.metroLabelHDD.Text = "0%";
            // 
            // metroLabelRAM
            // 
            this.metroLabelRAM.AutoSize = true;
            this.metroLabelRAM.Location = new System.Drawing.Point(1245, 532);
            this.metroLabelRAM.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.metroLabelRAM.Name = "metroLabelRAM";
            this.metroLabelRAM.Size = new System.Drawing.Size(27, 19);
            this.metroLabelRAM.TabIndex = 8;
            this.metroLabelRAM.Text = "0%";
            // 
            // perfCounterCPU
            // 
            this.perfCounterCPU.CategoryName = "Processor";
            this.perfCounterCPU.CounterName = "% Processor Time";
            this.perfCounterCPU.InstanceName = "_Total";
            // 
            // perfCounterRAM
            // 
            this.perfCounterRAM.CategoryName = "Memory";
            this.perfCounterRAM.CounterName = "% Committed Bytes in Use";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // perfCounterHDD
            // 
            this.perfCounterHDD.CategoryName = "PhysicalDisk";
            this.perfCounterHDD.CounterName = "% Idle Time";
            this.perfCounterHDD.InstanceName = "_Total";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1870, 969);
            this.Controls.Add(this.metroLabelRAM);
            this.Controls.Add(this.metroLabelHDD);
            this.Controls.Add(this.metroLabelCPU);
            this.Controls.Add(this.metroProgressBarHDD);
            this.Controls.Add(this.metroProgressBarRAM);
            this.Controls.Add(this.metroProgressBarCPU);
            this.Controls.Add(this.HDD);
            this.Controls.Add(this.RAM);
            this.Controls.Add(this.CPU);
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(63, 171, 63, 57);
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.perfCounterCPU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perfCounterRAM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perfCounterHDD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel CPU;
        private MetroFramework.Controls.MetroLabel RAM;
        private MetroFramework.Controls.MetroLabel HDD;
        private MetroFramework.Controls.MetroProgressBar metroProgressBarCPU;
        private MetroFramework.Controls.MetroProgressBar metroProgressBarRAM;
        private MetroFramework.Controls.MetroProgressBar metroProgressBarHDD;
        private MetroFramework.Controls.MetroLabel metroLabelCPU;
        private MetroFramework.Controls.MetroLabel metroLabelHDD;
        private MetroFramework.Controls.MetroLabel metroLabelRAM;
        private System.Diagnostics.PerformanceCounter perfCounterCPU;
        private System.Windows.Forms.Timer timer;
        private System.Diagnostics.PerformanceCounter perfCounterRAM;
        private System.Diagnostics.PerformanceCounter perfCounterHDD;
    }
}