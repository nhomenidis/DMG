using DMG.AuthProvider;
using DMG.Business.Dtos;
using DMG.Business.Mappers;
using DMG.DatabaseContext.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DMG.Models;

namespace DMG.Business.Services
{
    public interface IBillService
    {
        Task<BillDto> GetBill(Guid billId);
        Task<IEnumerable<BillDto>> GetBillsbyUser(User user);
        Task<BillDto> CreateBill(CreateBillDto newBill);
    }

    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper<Bill, BillDto> _billMapper;
        private readonly IMapper<CreateBillDto, Bill> _createBillDtoMapper;

        public BillService(
            IBillRepository billRepository,
            IMapper<Bill, BillDto> billMapper,
            IMapper<CreateBillDto, Bill> createBillDtoMapper)
        {
            _billRepository = billRepository;
            _billMapper = billMapper;
            _createBillDtoMapper = createBillDtoMapper;
        }

        public async Task<BillDto> GetBill(Guid id)
        {
            var bill = await _billRepository.GetById(id);
            var billdto = _billMapper.Map(bill);

            return billdto;

        }

        public async Task<IEnumerable<BillDto>> GetBillsbyUser(User user)
        {
            var bills = await _billRepository.GetByUserId(user.Id);
            var billsdto = _billMapper.Map(bills);

            return billsdto;
        }

        

        public async Task<BillDto> CreateBill(CreateBillDto newBill)
        {
            var bill = _createBillDtoMapper.Map(newBill);
            bill = await _billRepository.Insert(bill);

            return _billMapper.Map(bill);
        }
    }
}
