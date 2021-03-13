using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TransferApp.Services
{
	public class BankClientMock : IBankClient
	{
		private static readonly Random _random = new Random();

		public Task<HttpResponseMessage> TransferAsync(string account, decimal sum)
		{
			if (account == null)
			{
				throw new ArgumentNullException(nameof(account));
			}

			if (IsNetworkFailed())
			{
				throw new HttpRequestException("Network failed");
			}

			if (IsServiceFailed())
			{
				return CreateResult(HttpStatusCode.ServiceUnavailable, "Service unavailable");
			}

			if (IsAccountNotFound(account))
			{
				return CreateResult(HttpStatusCode.NotFound, "Account not found");
			}

			if (IsSumInvalid(sum))
			{
				return CreateResult(HttpStatusCode.BadRequest, "Invalid sum");
			}

			if (IsInsufficientFunds(sum))
			{
				return CreateResult(HttpStatusCode.BadRequest, "Insufficient funds");
			}

			return CreateResult(HttpStatusCode.OK, "Transfer completed");
		}

		private Task<HttpResponseMessage> CreateResult(HttpStatusCode statusCode, string message)
		{
			var response = new HttpResponseMessage(statusCode);
			response.Content = new StringContent(message);

			return Task.FromResult(response);
		}

		private bool IsNetworkFailed()
		{
			return _random.Next(10) == 0;
		}

		private bool IsServiceFailed()
		{
			return _random.Next(10) == 0;
		}

		private bool IsAccountNotFound(string account)
		{
			return account.GetHashCode() % 5 == 0;
		}

		private bool IsSumInvalid(decimal sum)
		{
			return sum == 0;
		}

		private bool IsInsufficientFunds(decimal sum)
		{
			return sum < 0 && _random.Next(10) == 0;
		}
	}
}
