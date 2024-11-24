using System.Globalization;
using Project.Domain.Interfaces.Data.Repositories;

namespace Project.Application.Features.Queries.GetResumoVendasCaixinhas;

public class GetResumoVendasCaixinhasQueryHandler : IRequestHandler<GetResumoVendasCaixinhasQuery, GetResumoVendasCaixinhasQueryResponse>
{
    private readonly IVendasCaixinhasRepository _vendasCaixinhasRepository;

    public GetResumoVendasCaixinhasQueryHandler(IVendasCaixinhasRepository vendasCaixinhasRepository)
    {
        _vendasCaixinhasRepository = vendasCaixinhasRepository;
    }

    public async Task<GetResumoVendasCaixinhasQueryResponse> Handle(GetResumoVendasCaixinhasQuery request, CancellationToken cancellationToken)
    {
        var vendas = await _vendasCaixinhasRepository.GetAllAsync(cancellationToken);

        // Filtrar por vendedor, se fornecido
        if (!string.IsNullOrEmpty(request.NomeVendedor))
        {
            vendas = vendas.Where(v => v.NomeVendedor.Equals(request.NomeVendedor, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // Filtrar por mês e ano, se fornecidos
        if (request.Mes.HasValue && request.Ano.HasValue)
        {
            vendas = vendas.Where(v => v.DataVenda.Month == request.Mes.Value && v.DataVenda.Year == request.Ano.Value).ToList();
        }

        // Agrupar os dados
        var resumo = vendas
            .GroupBy(v => new { v.NomeVendedor, v.DataVenda.Year, v.DataVenda.Month })
            .Select(group => new ResumoVendedoraDTO
            {
                NomeVendedor = group.Key.NomeVendedor,
                TotalLucro = group.Sum(v => v.Lucro),
                TotalCusto = group.Sum(v => v.CustoTotal),
                TotalSalario = group.Sum(v => v.Salario),
                TotalFaturamento = group.Sum(v => v.PrecoTotalVenda),
                Date = new DateTime(group.Key.Year, group.Key.Month, 1).ToString("MMM yyyy", CultureInfo.InvariantCulture)
            })
            .ToList();

        // Paginação
        var totalItems = resumo.Count;
        var paginatedResumo = resumo
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        return new GetResumoVendasCaixinhasQueryResponse
        {
            ResumoPorVendedora = paginatedResumo,
            TotalItems = totalItems,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
    }
}
