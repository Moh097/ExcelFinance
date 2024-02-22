    using ClosedXML.Excel;
    using ClosedXML.Excel.Drawings;
    using System.Drawing;
    using System.Security.Cryptography.X509Certificates;

    namespace ReadDataFromExcel
    {
        public class ExcelReader
        {
            //string cs = Parameters.WriteToLog(Parameters.excelFilePath);
            public ExcelReader() {
            // excelFilePath = Parameters.excelFilePath;
        }
            
            public List<MemberDto> Members = new();
            public void ReadData()
            {

                int counter = 1;
                using (var workbook = new XLWorkbook(Parameters.excelFilePath))
                {
                    string ID;
                    string Name;
                    string Membership;
                    string JoinDate;
                    Image Photo;
                    string Address;
                    IXLWorksheet worksheet = workbook.Worksheet("Memembers");
                    IXLWorksheet TakweenWS = workbook.Worksheet("TAKWEEN");
                    foreach (var row in worksheet.RowsUsed())
                    {
                        
                        if (worksheet.Row(counter).Cell(3).Value.ToString() == "TAKWEEN")
                        {
                            ID = row.Cell(1).Value.ToString();
                            Name = row.Cell(2).Value.ToString();
                            Address = $"{row.Cell(4).Value}-{row.Cell(5).Value}";

                            // Parse the date as a DateTime object
                            DateTime dateValue;
                            if (DateTime.TryParse(row.Cell(6).Value.ToString(), out dateValue))
                            {
                                // Format the date as just the date portion (without time)
                                JoinDate = dateValue.ToString("dd-MM-yyyy");
                            }
                            else
                            {
                                JoinDate = row.Cell(6).Value.ToString();
                            }
                            Membership = TakweenWS.Row(counter).Cell(3).Value.ToString();
                            Photo = (Image)FindPictureInWorksheet(TakweenWS, counter);

                            Members.Add(new MemberDto(ID, Name, Photo, Membership, Address, JoinDate));
                        }
                        
                        counter++;
                    }
                }
            }


            public MemberDto GetMemberFromName(string name)
            {
                foreach(MemberDto member in Members) { 
                if(member.Name == name) return member;  
                }
                return new MemberDto();
            }

            public MemberDto GetMemberFromId(string id)
            {
                foreach(MemberDto member in Members)
                {
                    if(member.Id == id) return member;
                }
                return null;
            }
            private Image FindPictureInWorksheet(IXLWorksheet worksheet, int targetRow)
            {
                foreach (var picture in worksheet.Pictures)
                {
                    if (picture.TopLeftCell.Address.RowNumber == targetRow)
                    {
                        // Extract image data from XLPicture and convert to System.Drawing.Image
                        byte[] imageBytes = picture.ImageStream.ToArray();
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            return Image.FromStream(ms);
                        }
                    }
                }
                return null;
            }

        }
    }