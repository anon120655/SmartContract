using AutoMapper;
using SmartContract.Infrastructure.Resources.DTO;
using SmartContract.Infrastructure.Resources.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartContract.Infrastructure.Data.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            //ContractSbbCklHeadingDTO
            CreateMap<EntityFramework.VNhsoServiceUnit, VNhsoServiceUnitDTO>().ReverseMap();
            CreateMap<EntityFramework.ViewHraRegister, ViewHraRegisterDTO>().ReverseMap();
            CreateMap<EntityFramework.VMasterVendor, VMasterVendorDTO>().ReverseMap();
            CreateMap<EntityFramework.UserSmct, UserSmctDTO>().ReverseMap();
            CreateMap<EntityFramework.UserSmctVendor, UserSmctVendorDTO>().ReverseMap();
            CreateMap<EntityFramework.UserLevel, UserLevelDTO>().ReverseMap();
            CreateMap<EntityFramework.UserRight, UserRightDTO>().ReverseMap();
            CreateMap<EntityFramework.UserRole, UserRoleDTO>().ReverseMap();
            CreateMap<EntityFramework.RegisterNhsoFile, RegisterNhsoFileDTO>().ReverseMap();
            CreateMap<EntityFramework.UserSmctSigner, UserSmctSignerDTO>()
                     .ForMember(dest => dest.UserSmctSignerFiles, opt => opt.MapFrom(src => src.UserSmctSignerFiles)).ReverseMap();
            CreateMap<EntityFramework.SmctMasterSignerDetail1, UserSmctSignerDTO>().ReverseMap();
            CreateMap<EntityFramework.UserSmctSignerFile, UserSmctSignerFileDTO>().ReverseMap();
            CreateMap<EntityFramework.SmctMasterFile, SmctMasterFileDTO>().ReverseMap();
            CreateMap<EntityFramework.ContractStation, ContractStationDTO>().ReverseMap();
            CreateMap<EntityFramework.ContractStationGuarantee, ContractStationGuaranteeDTO>().ReverseMap();
            CreateMap<EntityFramework.ContractStationSuccess, ContractStationSuccessDTO>().ReverseMap();
            CreateMap<EntityFramework.ContractStation, EntityFramework.ContractStationSuccess>().ReverseMap();
            CreateMap<EntityFramework.ContractStation, EntityFramework.ContractStationGuarantee>().ReverseMap();
            CreateMap<EntityFramework.ApprovalReq, ApprovalReqDTO>()
            .ForMember(dest => dest.ApprovalReqStations, opt => opt.MapFrom(src => src.ApprovalReqStations)).ReverseMap();
            CreateMap<EntityFramework.ApprovalReqStation, ApprovalReqStationDTO>().ReverseMap();
            CreateMap<EntityFramework.VendorLinkReq, VendorLinkReqDTO>()
                    .ForMember(dest => dest.VendorLinkReqStations, opt => opt.MapFrom(src => src.VendorLinkReqStations)).ReverseMap();
            CreateMap<EntityFramework.VendorLinkReqStation, VendorLinkReqStationDTO>().ReverseMap();
            CreateMap<EntityFramework.VNhsoBorad, VNhsoBoradDTO>().ReverseMap();
            CreateMap<EntityFramework.BudgetcodeView, BudgetcodeViewDTO>().ReverseMap();
            CreateMap<EntityFramework.ContractPeriod, ContractPeriodDTO>();
            CreateMap<EntityFramework.ContractPeriodDetail, ContractPeriodDetailDTO>().ReverseMap();
            CreateMap<EntityFramework.SmctMasterSignerDetail1, SmctMasterSignerDetail1DTO>().ReverseMap();
            CreateMap<EntityFramework.SmctMasterSigner, SmctMasterSignerDTO>().ReverseMap();
            CreateMap<EntityFramework.SmctMasterSendmail, SmctMasterSendmailDTO>().ReverseMap();

            CreateMap<EntityFramework.ContractSbbCklDetail, ContractSbbCklDetailDTO>().ReverseMap();
            CreateMap<EntityFramework.ContractSbbCkl, ContractSbbCklDTO>().ReverseMap()
                     .ForMember(dest => dest.ContractSbbCklDetails, opt => opt.MapFrom(src => src.ContractSbbCklDetails)).ReverseMap();

            CreateMap<EntityFramework.ContractDetail01, ContractDetail01DTO>().ReverseMap()
             .ForMember(q => q.IdContractDetail01, opt => opt.Ignore())
             .ForMember(q => q.IdContract, opt => opt.Ignore())
             .ForMember(q => q.CreateUser, opt => opt.Ignore())
             .ForMember(q => q.CreateDate, opt => opt.Ignore())
             .ForMember(q => q.Used, opt => opt.Ignore());
            CreateMap<EntityFramework.ContractDetail02, ContractDetail02DTO>().ReverseMap()
             .ForMember(q => q.IdContractDetail02, opt => opt.Ignore())
             .ForMember(q => q.IdContract, opt => opt.Ignore())
             .ForMember(q => q.CreateUser, opt => opt.Ignore())
             .ForMember(q => q.CreateDate, opt => opt.Ignore())
             .ForMember(q => q.Used, opt => opt.Ignore());
            CreateMap<EntityFramework.ContractDetail03, ContractDetail03DTO>().ReverseMap()
             .ForMember(q => q.IdContractDetail03, opt => opt.Ignore())
             .ForMember(q => q.IdContract, opt => opt.Ignore())
             .ForMember(q => q.CreateUser, opt => opt.Ignore())
             .ForMember(q => q.CreateDate, opt => opt.Ignore())
             .ForMember(q => q.Used, opt => opt.Ignore());
            CreateMap<EntityFramework.ContractDetail04, ContractDetail04DTO>().ReverseMap()
             .ForMember(q => q.IdContractDetail04, opt => opt.Ignore())
             .ForMember(q => q.IdContract, opt => opt.Ignore())
             .ForMember(q => q.CreateUser, opt => opt.Ignore())
             .ForMember(q => q.CreateDate, opt => opt.Ignore())
             .ForMember(q => q.Used, opt => opt.Ignore());
            CreateMap<EntityFramework.ContractDetail05, ContractDetail05DTO>().ReverseMap()
             .ForMember(q => q.IdContractDetail05, opt => opt.Ignore())
             .ForMember(q => q.IdContract, opt => opt.Ignore())
             .ForMember(q => q.CreateUser, opt => opt.Ignore())
             .ForMember(q => q.CreateDate, opt => opt.Ignore())
             .ForMember(q => q.Used, opt => opt.Ignore());
            CreateMap<EntityFramework.ContractDetail06, ContractDetail06DTO>().ReverseMap()
             .ForMember(q => q.IdContractDetail06, opt => opt.Ignore())
             .ForMember(q => q.IdContract, opt => opt.Ignore())
             .ForMember(q => q.CreateUser, opt => opt.Ignore())
             .ForMember(q => q.CreateDate, opt => opt.Ignore())
             .ForMember(q => q.Used, opt => opt.Ignore());
            CreateMap<EntityFramework.ContractDetail07, ContractDetail07DTO>().ReverseMap()
             .ForMember(q => q.IdContractDetail07, opt => opt.Ignore())
             .ForMember(q => q.IdContract, opt => opt.Ignore())
             .ForMember(q => q.CreateUser, opt => opt.Ignore())
             .ForMember(q => q.CreateDate, opt => opt.Ignore())
             .ForMember(q => q.Used, opt => opt.Ignore());
            CreateMap<EntityFramework.ContractDetail08, ContractDetail08DTO>().ReverseMap()
             .ForMember(q => q.IdContractDetail08, opt => opt.Ignore())
             .ForMember(q => q.IdContract, opt => opt.Ignore())
             .ForMember(q => q.CreateUser, opt => opt.Ignore())
             .ForMember(q => q.CreateDate, opt => opt.Ignore())
             .ForMember(q => q.Used, opt => opt.Ignore());
            CreateMap<EntityFramework.ContractDetail09, ContractDetail09DTO>().ReverseMap()
             .ForMember(q => q.IdContractDetail09, opt => opt.Ignore())
             .ForMember(q => q.IdContract, opt => opt.Ignore())
             .ForMember(q => q.CreateUser, opt => opt.Ignore())
             .ForMember(q => q.CreateDate, opt => opt.Ignore())
             .ForMember(q => q.Used, opt => opt.Ignore());
            CreateMap<EntityFramework.ContractDetail10, ContractDetail10DTO>().ReverseMap()
             .ForMember(q => q.IdContractDetail10, opt => opt.Ignore())
             .ForMember(q => q.IdContract, opt => opt.Ignore())
             .ForMember(q => q.CreateUser, opt => opt.Ignore())
             .ForMember(q => q.CreateDate, opt => opt.Ignore())
             .ForMember(q => q.Used, opt => opt.Ignore());
            CreateMap<EntityFramework.ContractDetail12, ContractDetail12DTO>().ReverseMap()
             .ForMember(q => q.IdContractDetail12, opt => opt.Ignore())
             .ForMember(q => q.IdContract, opt => opt.Ignore())
             .ForMember(q => q.CreateUser, opt => opt.Ignore())
             .ForMember(q => q.CreateDate, opt => opt.Ignore())
             .ForMember(q => q.Used, opt => opt.Ignore());
            CreateMap<EntityFramework.ContractDetail13, ContractDetail13DTO>().ReverseMap()
             .ForMember(q => q.IdContractDetail13, opt => opt.Ignore())
             .ForMember(q => q.IdContract, opt => opt.Ignore())
             .ForMember(q => q.CreateUser, opt => opt.Ignore())
             .ForMember(q => q.CreateDate, opt => opt.Ignore())
             .ForMember(q => q.Used, opt => opt.Ignore());
            CreateMap<EntityFramework.ContractDetail14, ContractDetail14DTO>().ReverseMap()
             .ForMember(q => q.IdContractDetail14, opt => opt.Ignore())
             .ForMember(q => q.IdContract, opt => opt.Ignore())
             .ForMember(q => q.CreateUser, opt => opt.Ignore())
             .ForMember(q => q.CreateDate, opt => opt.Ignore())
             .ForMember(q => q.Used, opt => opt.Ignore());

        }
    }
}
