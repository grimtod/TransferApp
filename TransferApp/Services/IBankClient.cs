using System.Net.Http;
using System.Threading.Tasks;

namespace TransferApp.Services
{
	interface IBankClient
	{
		/// <summary>
		/// Выполняет пополнение или списание денежных средств с указанного счёта.
		/// </summary>
		/// <param name="account">Целевой счёт.</param>
		/// <param name="sum">Сумма перевода. Если больше нуля, то пополнение, если меньше нуля, то списание.</param>
		/// <returns>Ответ внешнего сервиса.</returns>
		/// <exception cref="HttpRequestException">Исключение выбрасывается в случае сетевых проблем при отправке запроса.</exception>
		Task<HttpResponseMessage> TransferAsync(string account, decimal sum);
	}
}
