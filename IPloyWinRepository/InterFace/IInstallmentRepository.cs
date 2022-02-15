using PloyWinContext.Entities;
using PloyWinDto.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPloyWinRepository.InterFace
{
    public interface IInstallmentRepository : IGenericRepository<TblInstallment>
    {
        bool AddNewInstallment(string clientId, int ContractId, List<DtoListInstallment> dto);
        List<DtoListInstallment> CheckInstallment(DtoInstallment dto);
        bool UpdateInstallment(int Id);
        List<DtoInstallmentForView> GetAllInstallmentByContractId(int ContractId);
    }
}
