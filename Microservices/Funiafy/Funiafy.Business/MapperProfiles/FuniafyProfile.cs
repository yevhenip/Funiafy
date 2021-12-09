using AutoMapper;
using Funiafy.Domain;
using Funiafy.Domain.SongCollections;
using Funiafy.Domain.SongJoinEntities;
using Funiafy.Domain.UserJoinEntities;
using Shared.Services.Interfaces.DTO.Funiafy;
using Shared.Services.Interfaces.DTO.Funiafy.SongCollections;
using Shared.Services.Interfaces.DTO.Funiafy.SongJoinEntities;
using Shared.Services.Interfaces.DTO.Funiafy.UserJoinEntities;

namespace Funiafy.Business.MapperProfiles
{
    public class FuniafyProfile : Profile
    {
        public FuniafyProfile()
        {
            CreateMap<Artist, ArtistDTO>().ReverseMap();
            
            CreateMap<Genre, GenreDTO>().ReverseMap();
            
            CreateMap<Song, SongDTO>().ReverseMap();
            
            CreateMap<SongCollection, SongCollectionDTO>().ReverseMap();
            CreateMap<Album, AlbumDTO>().ReverseMap();
            CreateMap<Ep, EpDTO>().ReverseMap();
            CreateMap<Playlist, PlaylistDTO>().ReverseMap();
            
            CreateMap<AlbumSong, AlbumSongDTO>().ReverseMap();
            CreateMap<ArtistSong, ArtistSongDTO>().ReverseMap();
            CreateMap<PlaylistSong, PlaylistSongDTO>().ReverseMap();
            
            CreateMap<UserAlbum, UserAlbumDTO>().ReverseMap();
            CreateMap<UserArtist, UserArtistDTO>().ReverseMap();
            CreateMap<UserPlaylist, UserPlaylistDTO>().ReverseMap();
            CreateMap<UserSong, UserSongDTO>().ReverseMap();
        }
    }
}