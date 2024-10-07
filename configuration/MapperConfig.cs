using AutoMapper;
using apekade.Models;
using apekade.Models.Dto.AuthDto;
using apekade.Models.Dto.UserDto;
using apekade.Models.Dto.VendorDto;
using apekade.Models.Dto.BuyerDto;
using apekade.Models.Dto.StockDto;

namespace apekade.Configuration;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<LoginDto, User>();
        CreateMap<User, LoginResDto>();

        CreateMap<RegisterDto, User>();
        CreateMap<User, RegisterResDto>();
        
        CreateMap<CreateUserDto, User>();
        CreateMap<User, RegisterResDto>();

        CreateMap<UpdateVendorDto, User>();
        CreateMap<User, UpdateVendorResDto>();

        CreateMap<UpdateBuyerDto, User>();
        CreateMap<User, UpdateBuyerResDto>();

        CreateMap<UpdateUserDto, User>();
        CreateMap<User, UpdateUserResDto>();

        CreateMap<GetUserByIdDto, User>();
        CreateMap<User, GetUserResDto>();

        CreateMap<AddVendorRatingDto, Rating>();
        CreateMap<Rating, AddVendorRatingDto>();

        CreateMap<CreateStockReqDto, Stock>();
        CreateMap<Stock, CreateStockResDto>();
    
    }
}