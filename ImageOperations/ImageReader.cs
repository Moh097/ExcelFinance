using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ReadDataFromExcel;
using Font = System.Drawing.Font;
using Image = System.Drawing.Image;

namespace ImageOperations
{
    public class ImageReader
    {
        const float nameFONT_SIZE = 22;
        const float restFONT_SIZE = 12;
        const float idFONT_SIZE = 14;
        const float MEMBERSHIP_END_X = 700f;
        const float MEMBERSHIP_Y = 1270f;
        const float ADDRESS_END_X = 620f;
        const float ADDRESS_Y = 1392f;
        const float JOIN_END_X = 620f;
        const float JOIN_Y = 1517f;
        const float ID_X = 500f;
        const float ID_Y = 1774f;
        const float IMAGE_X = 295f;
        const float IMAGE_Y = 264f;
        const float NAME_X = 420f;
        float nameX;
        const float NAME_Y = 995f;
        float membershipX;
        float adressX;
        float joinX;
        float nameWidth;
        const float PHOTO_WIDTH = 543; // Adjust the photo width as needed
        const float PHOTO_HEIGHT = 628; // Adjust the photo height as needed

        private static string path;
        private static Image image;
        string outputDirectory;
        string pdfFolder;
        string exeFile;
        string exeDir;
        string nameFontPath;
        string IDFontPath;
        string restFontPath;
        string defImagePath;
        static Color customColor = Color.FromArgb(0, 53, 108);
        SolidBrush brush = new SolidBrush(customColor);



        public ImageReader()
        {
            exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
            exeDir = Path.GetDirectoryName(exeFile);

            if (string.IsNullOrWhiteSpace(exeDir))
            {
                // Handle the case where exeDir is null or empty
                throw new InvalidOperationException("Unable to determine the application directory.");
            }

            path = Path.GetFullPath(Path.Combine(exeDir, "Template.jpg"));
            defImagePath = Path.GetFullPath(Path.Combine(exeDir, "Default.jpeg"));
            image = Bitmap.FromFile(path);

            outputDirectory = Path.GetFullPath(Path.Combine(exeDir, "IMAGES"));
            pdfFolder = Path.GetFullPath(Path.Combine(exeDir, "PDFs"));

            nameFontPath = Path.GetFullPath(Path.Combine(exeDir, "Fonts\\Madani Arabic Semi Bold.ttf"));
            IDFontPath = Path.GetFullPath(Path.Combine(exeDir, "Fonts\\Madani Arabic Regular.ttf"));
            restFontPath = Path.GetFullPath(Path.Combine(exeDir, "Fonts\\Madani Arabic Regular.ttf"));
        }

        public void SetTextAndPhotoData()
        {
            ExcelReader reader = new ExcelReader();
            //string cs = Parameters.WriteToLog("SetTextAndPhotoData, " + Parameters.excelFilePath);
           
            foreach (MemberDto memberDto in reader.Members)
            {
                string pdfFileName = Path.Combine(pdfFolder, $"{memberDto.Name}.pdf");

                // Create a new document for each member
                using (Document document = new Document(PageSize.A4)) // Use A4 size (adjust if needed)
                {
                    try
                    {
                        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdfFileName, FileMode.Create));

                        // Open the document before adding content
                        document.Open();

                        // Add content here
                        CreateAndSaveImage(memberDto);
                        AddImageToPdf(memberDto, document, writer);

                        // Close the document after adding content
                        document.Close();
                    }
                    catch (Exception ex)
                    {
                        // Handle or log the exception here
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }
        }


        public void CreateAndSaveImage(MemberDto memberDto)
        {
            // Construct the unique filename for the member
            string uniqueFilename = Path.Combine(outputDirectory, $"{memberDto.Name}.jpg");

            // Check if the output directory exists; if not, create it
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Check if the image file already exists; if yes, delete it
            if (File.Exists(uniqueFilename))
            {
                File.Delete(uniqueFilename);
            }

            // Clone the base image
            using (Image clonedImage = (Image)image.Clone())
            {
                using (Graphics graphics = Graphics.FromImage(clonedImage))
                {
                    Font nameFont = new Font(nameFontPath, nameFONT_SIZE);
                    Font IDFont = new Font(IDFontPath, idFONT_SIZE);
                    Font restFont = new Font(restFontPath, restFONT_SIZE);

                    SizeF membershipSize = graphics.MeasureString(memberDto.Membership, restFont);
                    SizeF adressSize = graphics.MeasureString(memberDto.Address, restFont);
                    SizeF joinSize = graphics.MeasureString(memberDto.JoinDate, restFont);

                    membershipX = MEMBERSHIP_END_X - membershipSize.Width;
                    adressX = ADDRESS_END_X - adressSize.Width;
                    joinX = JOIN_END_X - joinSize.Width;
                    nameWidth = graphics.MeasureString(memberDto.Name, nameFont).Width;
                    nameX = 600 - (nameWidth / 2); // Adjust as needed

                    graphics.DrawString(memberDto.Membership, restFont, brush, membershipX, MEMBERSHIP_Y);
                    graphics.DrawString(memberDto.Address, restFont, brush, adressX, ADDRESS_Y);
                    graphics.DrawString(memberDto.JoinDate, restFont, brush, joinX, JOIN_Y);
                    graphics.DrawString(memberDto.Id, IDFont, Brushes.White, ID_X, ID_Y);
                    graphics.DrawString(memberDto.Name, nameFont, brush, nameX, NAME_Y);

                    if (memberDto.Photo != null)
                    {
                        RectangleF photoRect = new RectangleF(IMAGE_X, IMAGE_Y, PHOTO_WIDTH, PHOTO_HEIGHT);
                        graphics.DrawImage(memberDto.Photo, photoRect);
                    }
                    else
                    {
                        // Load and draw the default image
                        using (Image defaultImage = Image.FromFile(defImagePath))
                        {
                            RectangleF photoRect = new RectangleF(IMAGE_X, IMAGE_Y, PHOTO_WIDTH, PHOTO_HEIGHT);
                            graphics.DrawImage(defaultImage, photoRect);
                        }
                    }
                }

                // Save the new image
                clonedImage.Save(uniqueFilename, ImageFormat.Jpeg);
            }
        }



        public void AddImageToPdf(MemberDto memberDto, Document document, PdfWriter writer)
        {
            // Check if the image file exists
            string uniqueFilename = Path.Combine(outputDirectory, $"{memberDto.Name}.jpg");

            if (File.Exists(uniqueFilename))
            {
                // Open the document before adding content
                document.Open();

                // Load the image
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(uniqueFilename);

                // Adjust the size of the image to fit the page
                img.ScaleToFit(document.PageSize.Width, document.PageSize.Height);

                // Add the image to the PDF document
                document.Add(img);

                // Close the document after adding content
                document.Close();
            }
            else
            {
                Console.WriteLine("Image file not found: " + uniqueFilename);
            }
        }



    }
}
