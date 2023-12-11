using AutoMapper;
using Izeem.DAL.IRepositories;
using Izeem.Domain.Configurations;
using Izeem.Domain.Entities.Payments;
using Izeem.Service.DTOs.Payments;
using Izeem.Service.Exceptions;
using Izeem.Service.Extensions;
using Izeem.Service.Interfaces.Payments;

namespace Izeem.Service.Services.Payments;

public class PaymentService : IPaymentService
{
    private readonly IMapper _mapper;
    private readonly IRepository<Payment> _repository;
    public PaymentService(IRepository<Payment> repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<PaymentResultDto> AddAsync(PaymentCreationDto dto)
    {
        var mappedPayment = _mapper.Map<Payment>(dto);
        await _repository.AddAsync(mappedPayment);
        await _repository.SaveAsync();

        return _mapper.Map<PaymentResultDto>(mappedPayment);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var existPayment = await _repository.SelectAsync(p => p.Id == id)
            ?? throw new IzeemException(404, $"This payment is not found with ID = {id}");

        _repository.Delete(existPayment);
        await _repository.SaveAsync();

        return true;
    }

    public async Task<PaymentResultDto> ModifyAsync(PaymentUpdateDto dto)
    {
        var existPayment = await _repository.SelectAsync(p => p.Id == dto.Id)
            ?? throw new IzeemException(404, $"This payment is not found with ID = {dto.Id}");

        _mapper.Map(dto, existPayment);
        _repository.Update(existPayment);

        await _repository.SaveAsync();

        return _mapper.Map<PaymentResultDto>(existPayment);
    }

    public async Task<PaymentResultDto> RetrieveByIdAsync(long id)
    {
        var existPayment = await _repository.SelectAsync(p => p.Id == id)
              ?? throw new IzeemException(404, $"This payment is not found with ID = {id}");

        return _mapper.Map<PaymentResultDto>(existPayment);
    }

    public async Task<IEnumerable<PaymentResultDto>> RetrieveAllAsync(PaginationParams pagination, string search = null)
    {
        var payments = _repository.SelectAll()
            .ToPagedList(pagination);

        return _mapper.Map<IEnumerable<PaymentResultDto>>(payments);
    }
}
