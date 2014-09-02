namespace NinjaFactory
{
    partial class NinjaFactoryApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NinjaFactoryApp));
            this.AddNewOrdersButton = new System.Windows.Forms.Button();
            this.GetReportsAndFinalizeOrdersButton = new System.Windows.Forms.Button();
            this.LoadCatalogueInMySQLButton = new System.Windows.Forms.Button();
            this.CreateReportForLostNinjasButton = new System.Windows.Forms.Button();
            this.RemoveLostNinjasButton = new System.Windows.Forms.Button();
            this.CreateNinjaCatalogueButton = new System.Windows.Forms.Button();
            this.CreateIncomeReportButton = new System.Windows.Forms.Button();
            this.CreateNinjaRankingRaportButton = new System.Windows.Forms.Button();
            this.SetMongoDbForTestingButton = new System.Windows.Forms.Button();
            this.LoadNinjaCatalogueToMySqlDirectlyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddNewOrdersButton
            // 
            this.AddNewOrdersButton.Location = new System.Drawing.Point(12, 12);
            this.AddNewOrdersButton.Name = "AddNewOrdersButton";
            this.AddNewOrdersButton.Size = new System.Drawing.Size(175, 106);
            this.AddNewOrdersButton.TabIndex = 0;
            this.AddNewOrdersButton.Text = "Add New Orders (zipped exel tables)";
            this.AddNewOrdersButton.UseVisualStyleBackColor = true;
            this.AddNewOrdersButton.Click += new System.EventHandler(this.AddNewOrders);
            // 
            // GetReportsAndFinalizeOrdersButton
            // 
            this.GetReportsAndFinalizeOrdersButton.Location = new System.Drawing.Point(12, 124);
            this.GetReportsAndFinalizeOrdersButton.Name = "GetReportsAndFinalizeOrdersButton";
            this.GetReportsAndFinalizeOrdersButton.Size = new System.Drawing.Size(175, 106);
            this.GetReportsAndFinalizeOrdersButton.TabIndex = 1;
            this.GetReportsAndFinalizeOrdersButton.Text = "Get reports (from MongoDB) and finalize operations";
            this.GetReportsAndFinalizeOrdersButton.UseVisualStyleBackColor = true;
            this.GetReportsAndFinalizeOrdersButton.Click += new System.EventHandler(this.GetReportsAndFinalizeOrders);
            // 
            // LoadCatalogueInMySQLButton
            // 
            this.LoadCatalogueInMySQLButton.Location = new System.Drawing.Point(12, 408);
            this.LoadCatalogueInMySQLButton.Name = "LoadCatalogueInMySQLButton";
            this.LoadCatalogueInMySQLButton.Size = new System.Drawing.Size(207, 37);
            this.LoadCatalogueInMySQLButton.TabIndex = 2;
            this.LoadCatalogueInMySQLButton.Text = "Load JSON Catalogue in MySQL";
            this.LoadCatalogueInMySQLButton.UseVisualStyleBackColor = true;
            this.LoadCatalogueInMySQLButton.Click += new System.EventHandler(this.LoadCatalogueInMySql);
            // 
            // CreateReportForLostNinjasButton
            // 
            this.CreateReportForLostNinjasButton.Location = new System.Drawing.Point(12, 451);
            this.CreateReportForLostNinjasButton.Name = "CreateReportForLostNinjasButton";
            this.CreateReportForLostNinjasButton.Size = new System.Drawing.Size(207, 37);
            this.CreateReportForLostNinjasButton.TabIndex = 3;
            this.CreateReportForLostNinjasButton.Text = "Create report for lost ninjas (XML)";
            this.CreateReportForLostNinjasButton.UseVisualStyleBackColor = true;
            this.CreateReportForLostNinjasButton.Click += new System.EventHandler(this.CreateReportForLostNinjas);
            // 
            // RemoveLostNinjasButton
            // 
            this.RemoveLostNinjasButton.Location = new System.Drawing.Point(12, 494);
            this.RemoveLostNinjasButton.Name = "RemoveLostNinjasButton";
            this.RemoveLostNinjasButton.Size = new System.Drawing.Size(207, 37);
            this.RemoveLostNinjasButton.TabIndex = 4;
            this.RemoveLostNinjasButton.Text = "Remove lost ninjas (from XML)";
            this.RemoveLostNinjasButton.UseVisualStyleBackColor = true;
            this.RemoveLostNinjasButton.Click += new System.EventHandler(this.RemoveLostNinjas);
            // 
            // CreateNinjaCatalogueButton
            // 
            this.CreateNinjaCatalogueButton.Location = new System.Drawing.Point(327, 12);
            this.CreateNinjaCatalogueButton.Name = "CreateNinjaCatalogueButton";
            this.CreateNinjaCatalogueButton.Size = new System.Drawing.Size(151, 106);
            this.CreateNinjaCatalogueButton.TabIndex = 5;
            this.CreateNinjaCatalogueButton.Text = "Create ninja catalogue (JSON)";
            this.CreateNinjaCatalogueButton.UseVisualStyleBackColor = true;
            this.CreateNinjaCatalogueButton.Click += new System.EventHandler(this.CreateNinjaCatalogue);
            // 
            // CreateIncomeReportButton
            // 
            this.CreateIncomeReportButton.Location = new System.Drawing.Point(484, 12);
            this.CreateIncomeReportButton.Name = "CreateIncomeReportButton";
            this.CreateIncomeReportButton.Size = new System.Drawing.Size(151, 106);
            this.CreateIncomeReportButton.TabIndex = 6;
            this.CreateIncomeReportButton.Text = "Create monthly income repport (PDF)";
            this.CreateIncomeReportButton.UseVisualStyleBackColor = true;
            this.CreateIncomeReportButton.Click += new System.EventHandler(this.CreateIncomeReport);
            // 
            // CreateNinjaRankingRaportButton
            // 
            this.CreateNinjaRankingRaportButton.Location = new System.Drawing.Point(641, 12);
            this.CreateNinjaRankingRaportButton.Name = "CreateNinjaRankingRaportButton";
            this.CreateNinjaRankingRaportButton.Size = new System.Drawing.Size(151, 106);
            this.CreateNinjaRankingRaportButton.TabIndex = 7;
            this.CreateNinjaRankingRaportButton.Text = "CreateNinja ranking raport (from MySQL and SQLite to Exel)";
            this.CreateNinjaRankingRaportButton.UseVisualStyleBackColor = true;
            this.CreateNinjaRankingRaportButton.Click += new System.EventHandler(this.CreateNinjaRankingRaport);
            // 
            // SetMongoDbForTestingButton
            // 
            this.SetMongoDbForTestingButton.Location = new System.Drawing.Point(12, 236);
            this.SetMongoDbForTestingButton.Name = "SetMongoDbForTestingButton";
            this.SetMongoDbForTestingButton.Size = new System.Drawing.Size(175, 37);
            this.SetMongoDbForTestingButton.TabIndex = 8;
            this.SetMongoDbForTestingButton.Text = "Fill MongoDB for testing";
            this.SetMongoDbForTestingButton.UseVisualStyleBackColor = true;
            this.SetMongoDbForTestingButton.Click += new System.EventHandler(this.SetMongoDbForTesting);
            // 
            // LoadNinjaCatalogueToMySqlDirectlyButton
            // 
            this.LoadNinjaCatalogueToMySqlDirectlyButton.Location = new System.Drawing.Point(12, 365);
            this.LoadNinjaCatalogueToMySqlDirectlyButton.Name = "LoadNinjaCatalogueToMySqlDirectlyButton";
            this.LoadNinjaCatalogueToMySqlDirectlyButton.Size = new System.Drawing.Size(207, 37);
            this.LoadNinjaCatalogueToMySqlDirectlyButton.TabIndex = 9;
            this.LoadNinjaCatalogueToMySqlDirectlyButton.Text = "Load Catalogue to MySQL (directly)";
            this.LoadNinjaCatalogueToMySqlDirectlyButton.UseVisualStyleBackColor = true;
            this.LoadNinjaCatalogueToMySqlDirectlyButton.Click += new System.EventHandler(this.LoadNinjaCatalogueToMySqlDirectly);
            // 
            // NinjaFactoryApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(804, 543);
            this.Controls.Add(this.LoadNinjaCatalogueToMySqlDirectlyButton);
            this.Controls.Add(this.SetMongoDbForTestingButton);
            this.Controls.Add(this.CreateNinjaRankingRaportButton);
            this.Controls.Add(this.CreateIncomeReportButton);
            this.Controls.Add(this.CreateNinjaCatalogueButton);
            this.Controls.Add(this.RemoveLostNinjasButton);
            this.Controls.Add(this.CreateReportForLostNinjasButton);
            this.Controls.Add(this.LoadCatalogueInMySQLButton);
            this.Controls.Add(this.GetReportsAndFinalizeOrdersButton);
            this.Controls.Add(this.AddNewOrdersButton);
            this.Name = "NinjaFactoryApp";
            this.Text = "Ninja Factory - TeamBlackDragon";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddNewOrdersButton;
        private System.Windows.Forms.Button GetReportsAndFinalizeOrdersButton;
        private System.Windows.Forms.Button LoadCatalogueInMySQLButton;
        private System.Windows.Forms.Button CreateReportForLostNinjasButton;
        private System.Windows.Forms.Button RemoveLostNinjasButton;
        private System.Windows.Forms.Button CreateNinjaCatalogueButton;
        private System.Windows.Forms.Button CreateIncomeReportButton;
        private System.Windows.Forms.Button CreateNinjaRankingRaportButton;
        private System.Windows.Forms.Button SetMongoDbForTestingButton;
        private System.Windows.Forms.Button LoadNinjaCatalogueToMySqlDirectlyButton;
    }
}

