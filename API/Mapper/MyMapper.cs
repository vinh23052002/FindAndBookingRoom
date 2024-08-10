using API.Dtos.Chat;
using API.Dtos.District;
using API.Dtos.Image;
using API.Dtos.Message;
using API.Dtos.Province;
using API.Dtos.Review;
using API.Dtos.Room;
using API.Dtos.RoomAmenities;
using API.Dtos.RoomAmentiesMapping;
using API.Dtos.User;
using API.Dtos.Ward;
using API.Models;
using AutoMapper;

namespace API.Mapper
{
    public class MyMapper : Profile
    {
        public MyMapper()
        {
            CreateMap<Province, ProvinceResponse>();
            CreateMap<ProvinceRequest, Province>();

            CreateMap<District, DistrictResponse>();
            CreateMap<DistrictRequest, District>();

            CreateMap<Ward, WardResponse>();
            CreateMap<WardRequest, Ward>();

            CreateMap<Image, ImageResponse>();
            CreateMap<ImageRequest, Image>();

            CreateMap<RoomAmenities, RoomAmenitiesResponse>();
            CreateMap<RoomAmenitiesRequest, RoomAmenities>();

            CreateMap<Message, MessageResponse>();
            CreateMap<MessageRequest, Message>();

            CreateMap<Review, ReviewResponse>();
            CreateMap<ReviewRequest, Review>();

            CreateMap<Room, RoomResponse>();
            CreateMap<RoomRequest, Room>();
            CreateMap<RoomAddRequest, Room>();
            CreateMap<RoomUpdateRequest, Room>();
            CreateMap<RoomUpdateRequest, RoomAddRequest>();

            CreateMap<User, UserResponse>();
            CreateMap<UserRequest, User>();
            CreateMap<UserUpdateProfileRequest, User>();

            CreateMap<RoomAmenitiesMapping, RoomAmenitiesMappingResponse>();
            CreateMap<RoomAmenitiesMappingRequest, RoomAmenitiesMapping>();

            CreateMap<ChatRequest, Chat>();
            CreateMap<Chat, ChatResponse>()
                .ForMember(x => x.userName, y => y.MapFrom(p => p.User.fullName));


        }
    }
}
