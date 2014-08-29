using System;
using System.Linq;
using System.Windows.Forms;
using NinjaFactory.DataBase;
using NinjaFactory.XMLReporting;

namespace NinjaFactory
{
    /// <summary>
    /// Every ninja fabricator should buy this!
    /// </summary>
    public partial class NinjaFactoryApp : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NinjaFactoryApp" /> class.
        /// </summary>
        public NinjaFactoryApp()
        {
            InitializeComponent();
            this.DB = new NinjasData();
        }

        /// <summary>
        /// Gets or sets the database.
        /// </summary>
        /// <value> The database. </value>
        private INinjaFactoryData DB { get; set; }

        /// <summary>
        /// Adds the new orders.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="EventArgs" /> instance containing the event data. </param>
        /// <exception cref="System.NotImplementedException"> Not Implemented </exception>
        private void AddNewOrders(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "ZIP files (*.zip)|*.zip";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                INinjaFactoryData db = this.DB;

                // TODO: Implement and use a library doing this task. Use the filePath and db from above.
                throw new NotImplementedException("Not Implemented");
            }
        }

        /// <summary>
        /// Creates the income report.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="EventArgs" /> instance containing the event data. </param>
        /// <exception cref="System.NotImplementedException"> Not Implemented </exception>
        private void CreateIncomeReport(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog.FileName = "IncomeReport";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                INinjaFactoryData db = this.DB;

                // TODO: Implement and use a library doing this task. Use the filePath and db from above.

                throw new NotImplementedException("Not Implemented");
            }
        }

        /// <summary>
        /// Creates the ninja catalogue.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="EventArgs" /> instance containing the event data. </param>
        /// <exception cref="System.NotImplementedException"> Not Implemented </exception>
        private void CreateNinjaCatalogue(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "JSON files (*.json)|*.json";
            saveFileDialog.FileName = "NinjaCatalogue";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                INinjaFactoryData db = this.DB;

                // TODO: Implement and use a library doing this task. Use the filePath and db from above.

                throw new NotImplementedException("Not Implemented");
            }
        }

        /// <summary>
        /// Creates the ninja ranking raport.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="EventArgs" /> instance containing the event data. </param>
        /// <exception cref="System.NotImplementedException"> Not Implemented </exception>
        private void CreateNinjaRankingRaport(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
            saveFileDialog.FileName = "NinjaRankingReport";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                INinjaFactoryData db = this.DB;

                // TODO: Implement and use a library doing this task. Use the filePath and db from above.

                throw new NotImplementedException("Not Implemented");
            }
        }

        /// <summary>
        /// Creates the report for lost ninjas.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="EventArgs" /> instance containing the event data. </param>
        /// <exception cref="System.NotImplementedException"> Not Implemented </exception>
        private void CreateReportForLostNinjas(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "xml files (*.xml)|*.xml";
            saveFileDialog.FileName = "LostNinjasReport";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                INinjaFactoryData db = this.DB;
                XmlLostNinjaReportCreator creator = new XmlLostNinjaReportCreator();
                creator.CreateLostNinjasReport(db, filePath);
            }
        }

        /// <summary>
        /// Gets the reports and finalize orders.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="EventArgs" /> instance containing the event data. </param>
        /// <exception cref="System.NotImplementedException"> Not Implemented </exception>
        private void GetReportsAndFinalizeOrders(object sender, EventArgs e)
        {
            throw new NotImplementedException("Not Implemented");
        }

        /// <summary>
        /// Creates the backup.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="EventArgs" /> instance containing the event data. </param>
        /// <exception cref="System.NotImplementedException"> Not Implemented </exception>
        private void LoadCatalogueInMySql(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "JSON files (*.json)|*.json";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                INinjaFactoryData db = this.DB;

                // TODO: Implement and use a library doing this task. Use the filePath and db from above.
                throw new NotImplementedException("Not Implemented");
            }
        }

        /// <summary>
        /// Removes the lost ninjas.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="EventArgs" /> instance containing the event data. </param>
        /// <exception cref="System.NotImplementedException"> Not Implemented </exception>
        private void RemoveLostNinjas(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "xml files (*.xml)|*.xml";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                INinjaFactoryData db = this.DB;

                XmlLostNinjaReportParser reportParser = new XmlLostNinjaReportParser();
                reportParser.DeleteNinjasMentionedInLostNinjaReport(db, filePath);
            }
        }
    }
}