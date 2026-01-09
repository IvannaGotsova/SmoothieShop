namespace SmoothieShop.Models
{
    /// <summary>
    /// This class holds ErrorViewModel.
    /// </summary>
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}