using Microsoft.AspNetCore.Mvc;
using Project.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Project.Application.Features.Queries.GetBestSellingDay;
using Project.Application.Features.Queries.GetMonthWithMostSales;
using Project.Application.Features.Queries.GetMaxProfitInADay;
using Project.Application.Features.Queries.GetMonthlyVendasCaixinhas;
using Swashbuckle.AspNetCore.Annotations;

namespace Project.WebApi.Controllers;

/// <summary>
/// Controlador responsável por métricas das vendas de caixinhas.
/// </summary>
[ApiController]
[SwaggerTag("Reúne endpoints para métricas das vendas de caixinhas, incluindo análise de vendas mensais e diárias.")]
[Route("api/v1/[controller]")]
public class VendasCaixinhasMetricsController : BaseController
{
    private readonly IMediator _mediatorHandler;

    /// <summary>
    /// Construtor do controlador de métricas de vendas de caixinhas.
    /// </summary>
    /// <param name="notifications">Manipulador de notificações de erro de domínio.</param>
    /// <param name="successNotifications">Manipulador de notificações de sucesso de domínio.</param>
    /// <param name="mediatorHandler">Instância do Mediator para comunicação com a aplicação.</param>
    public VendasCaixinhasMetricsController(INotificationHandler<DomainNotification> notifications,
                                            INotificationHandler<DomainSuccessNotification> successNotifications,
                                            IMediator mediatorHandler)
        : base(notifications, successNotifications, mediatorHandler)
    {
        _mediatorHandler = mediatorHandler;
    }

    /// <summary>
    /// Retorna o dia com mais vendas no mês especificado.
    /// </summary>
    /// <param name="year">Ano para análise.</param>
    /// <param name="month">Mês para análise.</param>
    /// <param name="cancellationToken">Token para cancelamento da operação.</param>
    /// <returns>O dia com mais vendas no mês.</returns>
    /// <response code="200">Dia com mais vendas retornado com sucesso.</response>
    [Authorize(Roles = "Admin, User")]
    [HttpGet("best-selling-day")]
    [ProducesResponseType(typeof(GetBestSellingDayQueryResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBestSellingDay(
        [FromQuery] int year, 
        [FromQuery] int month, 
        CancellationToken cancellationToken)
    {
        var query = new GetBestSellingDayQuery(year, month);
        return Response(await _mediatorHandler.Send(query, cancellationToken));
    }

    /// <summary>
    /// Retorna o mês com mais vendas no ano especificado.
    /// </summary>
    /// <param name="year">Ano para análise.</param>
    /// <param name="cancellationToken">Token para cancelamento da operação.</param>
    /// <returns>O mês com mais vendas no ano.</returns>
    /// <response code="200">Mês com mais vendas retornado com sucesso.</response>
    [Authorize(Roles = "Admin, User")]
    [HttpGet("month-with-most-sales")]
    [ProducesResponseType(typeof(GetMonthWithMostSalesQueryResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMonthWithMostSales(
        [FromQuery] int year, 
        CancellationToken cancellationToken)
    {
        var query = new GetMonthWithMostSalesQuery(year);
        return Response(await _mediatorHandler.Send(query, cancellationToken));
    }

    /// <summary>
    /// Retorna o dia com maior lucro no mês especificado.
    /// </summary>
    /// <param name="year">Ano para análise.</param>
    /// <param name="month">Mês para análise.</param>
    /// <param name="cancellationToken">Token para cancelamento da operação.</param>
    /// <returns>O dia com maior lucro no mês.</returns>
    /// <response code="200">Dia com maior lucro retornado com sucesso.</response>
    [Authorize(Roles = "Admin, User")]
    [HttpGet("max-profit-day")]
    [ProducesResponseType(typeof(GetMaxProfitInADayQueryResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMaxProfitInADay(
        [FromQuery] int year, 
        [FromQuery] int month, 
        CancellationToken cancellationToken)
    {
        var query = new GetMaxProfitInADayQuery(year, month);
        return Response(await _mediatorHandler.Send(query, cancellationToken));
    }

    /// <summary>
    /// Retorna as vendas mensais de caixinhas.
    /// </summary>
    /// <param name="year">Ano para análise.</param>
    /// <param name="month">Mês para análise.</param>
    /// <param name="cancellationToken">Token para cancelamento da operação.</param>
    /// <returns>As vendas mensais de caixinhas.</returns>
    /// <response code="200">Vendas mensais retornadas com sucesso.</response>
    [HttpGet("monthly-sales")]
    [ProducesResponseType(typeof(GetMonthlyVendasCaixinhasQueryResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMonthlySales([FromQuery] int year, [FromQuery] int month, CancellationToken cancellationToken)
    {
        var query = new GetMonthlyVendasCaixinhasQuery(year, month);
        return Response(await _mediatorHandler.Send(query, cancellationToken));
    }
}
