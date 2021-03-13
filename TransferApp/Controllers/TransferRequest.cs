namespace TransferApp.Controllers
{
	public class TransferRequest
	{
		public string FromAccount { get; set; }

		public string ToAccount { get; set; }

		public decimal Sum { get; set; }
	}
}
