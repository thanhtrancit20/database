namespace WebApplication1.DTO.Response
{
    public class AppFileResponse
    {
        public int FileID { get; set; }
        public int UserID_FK { get; set; }
        public DateTime DateUploaded { get; set; }
        public string FileName_Actual { get; set; }
        public string FileName_Stored { get; set; }
        public long FileSize { get; set; }
        public string FileExtension { get; set; }
    }

}
