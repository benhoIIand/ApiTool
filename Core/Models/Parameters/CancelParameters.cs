namespace Core.Models.Parameters
{
    public class CancelParameters
    {
        public int RestaurantId { get; set; }
        public int ConfirmationNumber { get; set; }
        public string Email { get; set; }
    }
}