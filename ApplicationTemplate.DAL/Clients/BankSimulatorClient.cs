using System.Net;
using ApplicationTemplate.Shared.Configuration;
using ApplicationTemplate.Shared.Exceptions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ApplicationTemplate.DAL.Clients;

public class BankSimulatorClient(
    IBaseClientFactory baseClientFactory,
    IOptions<ConfigOptions> options,
    ILogger<BankSimulatorClient> logger)
{
    public async Task<PaymentResponseDao> ProcessPaymentRequestAsync(PaymentRequestDao paymentRequestDao)
    {
        var baseClient = baseClientFactory.CreateBaseClient(options.Value.BankSimulatorService.ClientName);
        try
        {
            var requestUri = new Uri(new Uri(options.Value.BankSimulatorService.ClientName), "/payments");
            
            var postResponse = await baseClient.PostAsync<PaymentRequestDao, PaymentResponseDao>(requestUri, paymentRequestDao);
            logger.LogInformation("Payment processed by bank for card ending in: {Last4}", paymentRequestDao.CardNumber[^4..]);

            return postResponse;
        }
        catch (HttpRequestException e) when (e.StatusCode == HttpStatusCode.ServiceUnavailable)
        {
            logger.LogError(e, "{StatusCode}: Upstream service bank simulator unavailable. No payment processed for card ending in: {Last4}", e.StatusCode, paymentRequestDao.CardNumber[^4..]);
            throw new BankUnavailableException($"Bank simulator returned {e.StatusCode}.");
        }
    }
}