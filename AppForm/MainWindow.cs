using ReadDataFromExcel;
using ImageOperations;

namespace AppForm
{
    public partial class MainWindow : Form
    {
        
        ExcelReader excelReader = new ExcelReader();
        ImageReader image = new ImageReader();
        public MainWindow()
        {
            InitializeComponent();
            this.FormClosing += Form_Closing;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you wanna print for this ID?", "confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                MemberDto memberDto = excelReader.GetMemberFromId(txtID.Text);
                image.CreateAndSaveImage(memberDto);

                if (memberDto == null)
                {
                    MessageBox.Show("Can't find ID in given Excel sheet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
           // string cs = Parameters.WriteToLog("btnBrowse_Click, " + Parameters.excelFilePath);
            try
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtUpload.Text = fileDialog.FileName;

                 //   string cs1 = Parameters.WriteToLog("btnBrowse_Click, " + Parameters.excelFilePath);
                    Parameters.excelFilePath = fileDialog.FileName;
                    excelReader.ReadData(); // You might want to re-read data here if needed.
                }
            }
            catch (Exception ex) {
                //cs = Parameters.WriteToLog("btnBrowse_Click, Exception " + ex.Message.ToString());
            }
            finally
            {

            }
        }

        private void cmbServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = cmbServices.SelectedItem.ToString();
            label1.Visible = false;
            txtID.Visible = false;
            btnPrint.Visible = false;

            if (selectedOption == "Print by ID")
            {
                label1.Visible = true;
                txtID.Visible = true;
                btnPrint.Visible = true;


            }
            else if (selectedOption == "Print only for Takween Memembers")
            {

                if (MessageBox.Show("Are you sure you wanna save all Takween Memebership cards?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ImageReader imageReader = new ImageReader();
                    imageReader.SetTextAndPhotoData();
                    MessageBox.Show("The process is done", "Done", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
            else if (selectedOption == "Print Kun Memembers")
            {
                MessageBox.Show("This option is not available Yet!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtUpload_TextChanged(object sender, EventArgs e)
        {
            cmbServices.Visible = true;
            label3.Visible = true;
        }
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit(); // Close the application when the form is closed by clicking the X button.
            }
        }

    }
}